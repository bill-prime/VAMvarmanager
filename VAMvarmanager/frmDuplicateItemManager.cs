using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VAMvarmanager
{
    public partial class frmDuplicateItemManager : Form
    {
        private frmVARManager _frmVM;
        private System.Collections.Specialized.StringCollection _mastervars;
        private List<string> _lstmastervars;
        private System.Collections.Specialized.StringCollection _masteritems;
        private List<string> _lstmasteritems;
        private List<varmanager.varItemReplacement> _lstVirAll;
        private List<varmanager.varItemReplacement> _lstVirManualResolve;
        private int _intManualIndex;
        private int _intManualTotal;

        public frmDuplicateItemManager(frmVARManager frmVM)
        {
            InitializeComponent();
            _frmVM = frmVM;

            try
            { 
                var mv = (System.Collections.Specialized.StringCollection)Properties.Settings.Default["mastervars"];
                if(mv != null)
                {
                    _mastervars = mv;
                    _lstmastervars = mv.Cast<string>().ToList();
                    
                }
                else
                {
                    _mastervars = null;
                    _lstmastervars = new List<string>();
                }
            }
            catch
            {
                Properties.Settings.Default["mastervars"] = null;
                Properties.Settings.Default.Save();
            }

            try
            {
                var mi = (System.Collections.Specialized.StringCollection)Properties.Settings.Default["masteritems"];
                if (mi != null)
                {
                    _masteritems = mi;
                    _lstmasteritems = mi.Cast<string>().ToList();
                }
                else
                {
                    _masteritems = null;
                    _lstmasteritems = new List<string>();
                }
            }
            catch
            {
                Properties.Settings.Default["masteritems"] = null;
                Properties.Settings.Default.Save();
            }

            gbManualResolve.Enabled = false;
            txtCreatorName.Enabled = false;
            txtItemName.Enabled = false;
            clbDuplicatesManual.Items.Clear();
            clbDuplicatesManual.Enabled = false;
            lblDuplicateManualCount.Hide();
            lblDuplicateManualCount.Text = "";

            lblDuplicatesUnique.Text = "";
            lblDuplicatesUnique.Hide();
            lblDuplicatesTotal.Text = "";
            lblDuplicatesTotal.Hide();
            btnDisableDuplicates.Enabled = false;
            gbDisable.Enabled = false;
            
            comboSex.Items.Clear();
            comboSex.Items.Add("female");
            comboSex.Items.Add("male");
            comboSex.SelectedIndex = 0;
            comboType.Items.Clear();
            comboType.Items.Add("clothing");
            comboType.Items.Add("hair");
            comboType.SelectedIndex = 0;
        }

        private void frmDuplicateItemManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            _frmVM.Show();
        }

        private void cbSetMasterAll_MouseHover(object sender, EventArgs e)
        {
            toolTipMasterVars.Show("Saves setting in VAR Manager to set the selected var below as the master/active item for any duplicates of it's contian items," + Environment.NewLine + "now and for future runs of disable duplicates.", cbSetMasterAll);
            
        }

        private void cbSetMasterItem_MouseHover(object sender, EventArgs e)
        {
            toolTipMasterVars.Show("Saves setting in VAR Manager to set the selected below var as the master/active item for the current unique item," + Environment.NewLine + "now and for future runs of disable duplicates.", cbSetMasterItem);
        }

        private void btnFindDuplicates_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _lstVirAll = _frmVM.vm.GetDuplicateItems(comboType.Text, comboSex.Text, _lstmastervars, _lstmasteritems);

            if (_lstVirAll.Any())
            {
                //Check Master Lists
                for(int i = 0; i < _lstVirAll.Count; i++)
                { 
                    if (_lstVirAll[i].varItemReplacementType != varmanager.varItemReplacement.DISABLE)
                    {
                        foreach (var vir in _lstVirAll[i].lstVi)
                        {
                            if (_lstmastervars.Contains(comboType.Text + "|" + comboSex.Text + "|" + vir.var.Name))
                            {
                                _lstVirAll[i].mastervar = vir.var.Name;
                                _lstVirAll[i].varItemReplacementType = varmanager.varItemReplacement.DISABLE;
                                continue;
                            }

                            foreach (string s in _lstmasteritems)
                            {
                                if (s.Split('|')[0] == comboType.Text && s.Split('|')[1] == comboSex.Text && s.Split('|')[3] == _lstVirAll[i].creator && s.Split('|')[4] == _lstVirAll[i].itemname)
                                {
                                    _lstVirAll[i].mastervar = s.Split('|')[2];
                                    _lstVirAll[i].varItemReplacementType = varmanager.varItemReplacement.DISABLE;
                                    continue;
                                }
                            }
                        }
                    }
                }

                //Check Manual Resolve needed, and then get ready for auto resolve
                checkManualResolveNeeded();
            }
            else
            {
                //No Duplicates, Congrats!
                Cursor = Cursors.Default;
                MessageBox.Show("No Duplicates found, well done!", "No Duplicates Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool checkManualResolveNeeded()
        {
            //Same Creator duplicates first
            _lstVirManualResolve = (from vir in _lstVirAll
                                    where vir.varItemReplacementType == varmanager.varItemReplacement.SAMECREATOR
                                    select vir).ToList();
            
            if (_lstVirManualResolve.Any())
            {
                gbConfig.Enabled = false;
                _intManualIndex = 1;
                _intManualTotal = _lstVirManualResolve.Count();

                MessageBox.Show(_intManualTotal + " Duplicates where the var creater is the same as the item creator found." + Environment.NewLine + "Resolve manully first before automated duplicate disabling can be run.", "Same Creator duplicates", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                lblDuplicateManualCount.Text = "Item " + _intManualIndex.ToString() + " of " + _intManualTotal.ToString();
                lblDuplicateManualCount.Show();
                
                txtCreatorName.Text = _lstVirManualResolve[0].creator;
                txtItemName.Text = _lstVirManualResolve[0].itemname;
                clbDuplicatesManual.Items.Clear();

                foreach (var virVar in _lstVirManualResolve[0].lstVi)
                {
                    clbDuplicatesManual.Items.Add(virVar.var.Name, false);
                }

                clbDuplicatesManual.Enabled = true;

                gbManualResolve.Enabled = true;

                Cursor = Cursors.Default;

                return true;
            }
            else 
            {
                _lstVirManualResolve = (from vir in _lstVirAll
                                        where vir.varItemReplacementType == varmanager.varItemReplacement.NOMASTER
                                        select vir).ToList();

                if (_lstVirManualResolve.Any())
                {
                    gbConfig.Enabled = false;
                    _intManualIndex = 1;
                    _intManualTotal = _lstVirManualResolve.Count();

                    MessageBox.Show(_intManualTotal + " Unresolveable duplicates found." + Environment.NewLine + "Resolve manully first before automated duplicate disabling can be run.", "Unresolveable duplicates", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    lblDuplicateManualCount.Text = "Item " + _intManualIndex.ToString() + " of " + _intManualTotal.ToString();
                    lblDuplicateManualCount.Show();

                    txtCreatorName.Text = _lstVirManualResolve[0].creator;
                    txtItemName.Text = _lstVirManualResolve[0].itemname;
                    clbDuplicatesManual.Items.Clear();

                    foreach (var virVar in _lstVirManualResolve[0].lstVi)
                    {
                        clbDuplicatesManual.Items.Add(virVar.var.Name, false);
                    }

                    clbDuplicatesManual.Enabled = true;

                    gbManualResolve.Enabled = true;

                    Cursor = Cursors.Default;

                    return true;
                }
                else
                {
                    //No manual duplicates, disable!
                    lblDuplicatesUnique.Text = _lstVirAll.Select(v => v.creator + "|" + v.itemname).Distinct().Count().ToString() + " Unique Items with Duplicates";
                    lblDuplicatesUnique.Show();

                    int intTotalItems = 0;
                    foreach(var virMain in _lstVirAll)
                    {
                        foreach(var vir in virMain.lstVi)
                        {
                         if (vir.var.Name != virMain.mastervar)
                            {
                                intTotalItems += 1;
                            }
                        }
                    }

                    lblDuplicatesTotal.Text = intTotalItems + " Total Duplicate Items"; ;
                    lblDuplicatesTotal.Show();
                    btnDisableDuplicates.Enabled = true;
                    gbDisable.Enabled = true;

                    Cursor = Cursors.Default;

                    return false;
                }
            }

        }

        private void clbDuplicatesManual_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                if(e.NewValue == CheckState.Checked)
                {
                    clbDuplicatesManual.Enabled = false;

                    string strMaster = clbDuplicatesManual.Items[e.Index].ToString();

                    if(cbSetMasterAll.Checked)
                    {
                        if (_mastervars == null) { _mastervars = new System.Collections.Specialized.StringCollection(); }

                        _mastervars.Add(comboType.Text + "|" + comboSex.Text + "|" + strMaster);
                        _lstmastervars.Add(comboType.Text + "|" + comboSex.Text + "|" + strMaster);

                        Properties.Settings.Default["mastervars"] = _mastervars;
                        Properties.Settings.Default.Save();
                    }
                    else if (cbSetMasterItem.Checked)
                    {
                        if (_masteritems == null) { _masteritems = new System.Collections.Specialized.StringCollection(); }

                        _masteritems.Add(comboType.Text + "|" + comboSex.Text + "|" + strMaster + "|" + _lstVirManualResolve[0].creator + "|" + _lstVirManualResolve[0].itemname);
                        _lstmasteritems.Add(comboType.Text + "|" + comboSex.Text + "|" + strMaster + "|" + _lstVirManualResolve[0].creator + "|" + _lstVirManualResolve[0].itemname);

                        Properties.Settings.Default["masteritems"] = _masteritems;
                        Properties.Settings.Default.Save();
                    }

                    cbSetMasterAll.Checked = false;
                    cbSetMasterItem.Checked = false;

                    //Update main list
                    for (int i = 0; i < _lstVirAll.Count(); i++)
                    {
                        if(_lstVirAll[i].varItemReplacementType != varmanager.varItemReplacement.DISABLE && _lstVirAll[i].creator == _lstVirManualResolve[0].creator && _lstVirAll[i].itemname == _lstVirManualResolve[0].itemname)
                        {
                            _lstVirAll[i].mastervar = strMaster;
                            _lstVirAll[i].varItemReplacementType = varmanager.varItemReplacement.DISABLE;
                        }
                    }

                    _lstVirManualResolve.RemoveAt(0);
                    _intManualIndex += 1;

                    if (_lstVirManualResolve.Any())
                    {
                        //Check master lists for var/item and automatically disable
                        var matchMasterLists = from vir in _lstVirManualResolve[0].lstVi
                                               where _lstmastervars.Contains(comboType.Text + "|" + comboSex.Text + "|" + vir.var.Name) || _lstmasteritems.Contains(comboType.Text + "|" + comboSex.Text + "|" + vir.var.Name + "|" + _lstVirManualResolve[0].creator + "|" + _lstVirManualResolve[0].itemname)
                                               select vir;

                        while (matchMasterLists != null && matchMasterLists.Any())
                        {
                            //Update main list
                            for (int i = 0; i < _lstVirAll.Count(); i++)
                            {
                                if (_lstVirAll[i].varItemReplacementType != varmanager.varItemReplacement.DISABLE && _lstVirAll[i].creator == _lstVirManualResolve[0].creator && _lstVirAll[i].itemname == _lstVirManualResolve[0].itemname)
                                {
                                    _lstVirAll[i].mastervar = matchMasterLists.First().var.Name;
                                    _lstVirAll[i].varItemReplacementType = varmanager.varItemReplacement.DISABLE;
                                }
                            }

                            _lstVirManualResolve.RemoveAt(0);
                            _intManualIndex += 1;

                            if (_lstVirManualResolve.Any())
                            {
                                matchMasterLists = from vir in _lstVirManualResolve[0].lstVi
                                                   where _lstmastervars.Contains(comboType.Text + "|" + comboSex.Text + "|" + vir.var.Name) || _lstmasteritems.Contains(comboType.Text + "|" + comboSex.Text + "|" + vir.var.Name + "|" + _lstVirManualResolve[0].creator + "|" + _lstVirManualResolve[0].itemname)
                                                   select vir;
                            }
                            else
                            {
                                matchMasterLists = null;
                            }
                        }

                        //continue manual resolve
                        if (_lstVirManualResolve.Any())
                        {
                            lblDuplicateManualCount.Text = "Item " + _intManualIndex.ToString() + " of " + _intManualTotal.ToString();

                            txtCreatorName.Text = _lstVirManualResolve[0].creator;
                            txtItemName.Text = _lstVirManualResolve[0].itemname;
                            clbDuplicatesManual.ClearSelected();
                            clbDuplicatesManual.Items.Clear();

                            foreach (var virVar in _lstVirManualResolve[0].lstVi)
                            {
                                clbDuplicatesManual.Items.Add(virVar.var.Name, false);
                            }

                            clbDuplicatesManual.Enabled = true;
                        }
                        else
                        {
                            //Done
                            gbManualResolve.Enabled = false;
                            txtCreatorName.Text = "";
                            txtItemName.Text = "";
                            clbDuplicatesManual.Enabled = false;
                            clbDuplicatesManual.ClearSelected();
                            clbDuplicatesManual.Items.Clear();
                            lblDuplicateManualCount.Hide();
                            lblDuplicateManualCount.Text = "";

                            checkManualResolveNeeded();
                        }
                    }
                    else
                    {
                        //Done
                        gbManualResolve.Enabled = false;
                        txtCreatorName.Text = "";
                        txtItemName.Text = "";
                        clbDuplicatesManual.Enabled = false;
                        clbDuplicatesManual.ClearSelected();
                        clbDuplicatesManual.Items.Clear();
                        lblDuplicateManualCount.Hide();
                        lblDuplicateManualCount.Text = "";
                        
                        checkManualResolveNeeded();
                    }

                }
            }));
        }

        private void cbSetMasterItem_CheckStateChanged(object sender, EventArgs e)
        {
            if(cbSetMasterItem.Checked)
            { cbSetMasterAll.Checked = false; }
            
        }

        private void cbSetMasterAll_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbSetMasterAll.Checked)
            { cbSetMasterItem.Checked = false; }
        }

        private void btnReturnToVM_Click(object sender, EventArgs e)
        {
            _frmVM.Show();
            this.Close();
        }

        private void btnDisableDuplicates_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string strLog = "";
            strLog += "itemCreator:itemName|mastervar";
            strLog += Environment.NewLine + "    disabledvarname";
            strLog += Environment.NewLine + "--------------------------------------------";


            foreach (var virDistinct in _lstVirAll)
            {
                strLog += Environment.NewLine + virDistinct.creator + ":" + virDistinct.itemname + "|" + virDistinct.mastervar;

                foreach (var viDisable in virDistinct.lstVi.Where(v => v.var.Name != virDistinct.mastervar))
                {
                    //Debug.Print(viDisable.var.Name);
                    strLog += Environment.NewLine + "    " + viDisable.var.fi.Name;
                    //Disable item
                    _frmVM.vm.DisableDuplicateItem(viDisable.var.fi.Name, viDisable.FullName);
                }
            }

            gbConfig.Enabled = true;
            
            lblDuplicatesUnique.Text = "";
            lblDuplicatesUnique.Hide();
            lblDuplicatesTotal.Text = "";
            lblDuplicatesTotal.Hide();
            btnDisableDuplicates.Enabled = false;
            gbDisable.Enabled = false;

            System.IO.File.WriteAllText(_frmVM._strVamdir + @"\VARManager_DisableDuplicateLog.txt", strLog);

            Cursor = Cursors.Default;
            MessageBox.Show("Done! Log file available at:" + Environment.NewLine + _frmVM._strVamdir + @"\VARManager_DisableDuplicateLog.txt", "Done disabling duplicates!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClearMasterLists_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["mastervars"] = null;
            Properties.Settings.Default["masteritems"] = null;
            Properties.Settings.Default.Save();

            _mastervars = null;
            _lstmastervars = new List<string>();

            _masteritems = null;
            _lstmasteritems = new List<string>();
        }
    }
}
