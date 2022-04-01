using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VAMvarmanager
{
    public partial class frmVARManager : Form
    {
        private varmanager _vm;
        private FolderBrowserDialog fbVam;
        private FolderBrowserDialog fbBackup;
        private bool _enabled = false;
        private string _strVamdir;
        private string _strBackupdir;
        private System.Collections.Specialized.StringCollection _creatorex;
        private System.Collections.Specialized.StringCollection _folderex;
        private List<string> _creatorListvam;
        private List<string> _creatorListbak;
        private List<string> _folderListvam;
        private List<string> _folderListbak;

        public frmVARManager()
        {
            InitializeComponent();
            txtVamfolder.Enabled = false;
            txtBackupfolder.Enabled = false;

            //Reset settings
            //Properties.Settings.Default["vamfolder"] = null;
            //Properties.Settings.Default["backupfolder"] = null;
            //Properties.Settings.Default.Save();

            // Copy user settings from previous application version if they exist
            if (Properties.Settings.Default.UpdateSettings)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.Reload();
                Properties.Settings.Default.UpdateSettings = false;
                Properties.Settings.Default.Save();
            }

            this.clbFolders.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbFolders_ItemCheck);
            this.clbCreators.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCreators_ItemCheck);

            _enabled = checkValiddirs();

            //Clear saved filters if there is an error
            try { _creatorex = (System.Collections.Specialized.StringCollection)Properties.Settings.Default["creatorex"]; }
            catch 
            { 
                _creatorex = null;
                Properties.Settings.Default["creatorex"] = null;
                Properties.Settings.Default.Save();
            }

            try { _folderex = (System.Collections.Specialized.StringCollection)Properties.Settings.Default["folderex"]; }
            catch
            {
                _folderex = null;
                Properties.Settings.Default["folderex"] = null;
                Properties.Settings.Default.Save();
            }

            cbEx.Checked = true;

            clbTypes.Items.Add("Assets");
            clbTypes.Items.Add("Clothing");
            clbTypes.Items.Add("Clothing Presets");
            clbTypes.Items.Add("Hair");
            clbTypes.Items.Add("Hair Presets");
            clbTypes.Items.Add("Looks");
            clbTypes.Items.Add("Morphs");
            clbTypes.Items.Add("Poses");
            clbTypes.Items.Add("Scenes");
            clbTypes.Items.Add("SubScenes");
            clbTypes.Items.Add("Scripts");
            clbTypes.Items.Add("Skin Textures");

            setfunctionstatus();
            
        }

        private void setfunctionstatus() 
        {
            if (_enabled)
            {
                _vm = new varmanager(_strVamdir, _strBackupdir);

                varmanager.varCounts vc = _vm.GetVarCounts();
                lblVamcount.Text = vc.countVAMvars.ToString();
                lblBackupcount.Text = vc.countBackupvars.ToString();

                clbCreators.Items.Clear();
                _creatorListvam = _vm.GetCreatorList();

                foreach (string c in _creatorListvam)
                {
                    if (_creatorex == null)
                    {
                        clbCreators.Items.Add(c, false);
                    }
                    else
                    {
                        if (_creatorex.Contains(c)) { clbCreators.Items.Add(c, true); }
                        else { clbCreators.Items.Add(c, false); }
                    }
                }
                this.clbCreators.Enabled = true;
                this.clbCreators.Show();
                clbFolders.Items.Clear();

                var dirs = from f in Directory.GetDirectories(_strVamdir + @"\AddonPackages", "*", SearchOption.AllDirectories)
                                     select f.Replace(_strVamdir + @"\AddonPackages\", "");

                _folderListvam = dirs.ToList<string>();
                _folderListvam.Add("AddonPackages");

                foreach (string f in _folderListvam)
                {
                    if (_folderex == null)
                    {
                        clbFolders.Items.Add(f, false);
                    }
                    else
                    {
                        if (_folderex.Contains(f)) { clbFolders.Items.Add(f, true); }
                        else { clbFolders.Items.Add(f, false); }
                    }
                }
                
                this.clbFolders.Sorted = true;
                for (int i = clbFolders.Items.Count - 1; i >= 0; i--)
                {
                    if (clbFolders.Items[i].ToString() == "AddonPackages" && i != 0)
                    {
                        var temp = clbFolders.Items[0];
                        clbFolders.Items[0] = clbFolders.Items[i];
                        clbFolders.Items[i] = temp;
                    }
                }
                this.clbFolders.Enabled = true;
                this.clbFolders.Show();

                this.btnBackupUnref.Enabled = true;
                this.btnBackupUnrefSpec.Enabled = true;
                this.btnBackupSpec.Enabled = true;
                this.btnRestoreRef.Enabled = true;
                this.btnRestoreSpec.Enabled = true;
                this.btnRestoreAll.Enabled = true;
            }
            else
            {
                this.btnBackupUnref.Enabled = false;
                this.btnBackupUnrefSpec.Enabled = false;
                this.btnBackupSpec.Enabled = false;
                this.btnRestoreRef.Enabled = false;
                this.btnRestoreSpec.Enabled = false;
                this.btnRestoreAll.Enabled = false;
                this.clbCreators.Enabled = false;
                this.clbCreators.Hide();
                this.clbFolders.Enabled = false;
                this.clbFolders.Hide();
            }
        }

        private bool checkValiddirs()
        {
            if ((Properties.Settings.Default["vamfolder"] != null) && System.IO.Directory.Exists(Properties.Settings.Default["vamfolder"].ToString()) && System.IO.Directory.Exists(Properties.Settings.Default["vamfolder"].ToString() + @"\AddonPackages"))
            {
                _strVamdir = Properties.Settings.Default["vamfolder"].ToString();
                txtVamfolder.Text = Properties.Settings.Default["vamfolder"].ToString();
            }
            else { txtVamfolder.Text = "INVALID DIRECTORY"; }

            if ((Properties.Settings.Default["backupfolder"] != null) && System.IO.Directory.Exists(Properties.Settings.Default["backupfolder"].ToString()))
            {
                _strBackupdir = Properties.Settings.Default["backupfolder"].ToString();
                txtBackupfolder.Text = Properties.Settings.Default["backupfolder"].ToString();
            }
            else { txtBackupfolder.Text = "INVALID DIRECTORY"; }

            if ((Properties.Settings.Default["vamfolder"] != null) && System.IO.Directory.Exists(Properties.Settings.Default["vamfolder"].ToString()) && (Properties.Settings.Default["backupfolder"] != null) && System.IO.Directory.Exists(Properties.Settings.Default["backupfolder"].ToString()) && System.IO.Directory.Exists(Properties.Settings.Default["vamfolder"].ToString() + @"\AddonPackages"))
            {
                return true;
            }
            else { return false; }
         }

        private void clbCreators_ItemCheck(Object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked && _creatorex == null)
            {
                _creatorex = new System.Collections.Specialized.StringCollection();
                _creatorex.Add(clbCreators.GetItemText(clbCreators.Items[e.Index]));
            }
            else if (e.NewValue == CheckState.Checked) 
            {
                if (!_creatorex.Contains(clbCreators.GetItemText(clbCreators.Items[e.Index])))
                {
                    _creatorex.Add(clbCreators.GetItemText(clbCreators.Items[e.Index]));
                }
            }
            else 
            {
                if (_creatorex.Contains(clbCreators.GetItemText(clbCreators.Items[e.Index])))
                {
                    _creatorex.Remove(clbCreators.GetItemText(clbCreators.Items[e.Index]));
                }
            }

            Properties.Settings.Default["creatorex"] = _creatorex;
            Properties.Settings.Default.Save();
        }

        private void clbFolders_ItemCheck(Object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked && _folderex == null)
            {
                _folderex = new System.Collections.Specialized.StringCollection();
                _folderex.Add(clbFolders.GetItemText(clbFolders.Items[e.Index]));
            }
            else if (e.NewValue == CheckState.Checked)
            {
                if (!_folderex.Contains(clbFolders.GetItemText(clbFolders.Items[e.Index])))
                {
                    _folderex.Add(clbFolders.GetItemText(clbFolders.Items[e.Index]));
                }

            }
            else
            {
                if (_folderex.Contains(clbFolders.GetItemText(clbFolders.Items[e.Index])))
                {
                    _folderex.Remove(clbFolders.GetItemText(clbFolders.Items[e.Index]));
                }
            }

            Properties.Settings.Default["folderex"] = _folderex;
            Properties.Settings.Default.Save();
        }

        private void btnVamfolder_Click(object sender, EventArgs e)
        {
            this.fbVam = new FolderBrowserDialog();
            fbVam.RootFolder = Environment.SpecialFolder.Desktop;
            fbVam.ShowDialog();
            Properties.Settings.Default["vamfolder"] = fbVam.SelectedPath;
            Properties.Settings.Default.Save();

            _enabled = checkValiddirs();

            setfunctionstatus();
        }

        private void btnBackupfolder_Click(object sender, EventArgs e)
        {
            this.fbBackup = new FolderBrowserDialog();
            fbBackup.RootFolder = Environment.SpecialFolder.Desktop;
            fbBackup.ShowDialog();
            Properties.Settings.Default["backupfolder"] = fbBackup.SelectedPath;
            Properties.Settings.Default.Save();
            txtBackupfolder.Text = Properties.Settings.Default["backupfolder"].ToString();

            _enabled = checkValiddirs();

            setfunctionstatus();
        }

        private void btnBackupUnref_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            
            if (cbEx.Checked)
            {
                varmanager.varCounts vc = _vm.BackupUnrefVarsEx(clbFolders.CheckedItems, clbCreators.CheckedItems);
                lblVamcount.Text = vc.countVAMvars.ToString();
                lblBackupcount.Text = vc.countBackupvars.ToString();
            }
            else
            {
                varmanager.varCounts vc = _vm.BackupUnrefVars();
                lblVamcount.Text = vc.countVAMvars.ToString();
                lblBackupcount.Text = vc.countBackupvars.ToString();
            }

            Cursor = Cursors.Default;
        }

        private void btnBackupUnrefSpec_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if (cbEx.Checked)
            {
                varmanager.varCounts vc = _vm.BackupUnrefSpecVarsEx(clbTypes.CheckedItems, clbFolders.CheckedItems, clbCreators.CheckedItems);
                lblVamcount.Text = vc.countVAMvars.ToString();
                lblBackupcount.Text = vc.countBackupvars.ToString();
            }
            else
            {
                varmanager.varCounts vc = _vm.BackupUnrefSpecVars(clbTypes.CheckedItems);
                lblVamcount.Text = vc.countVAMvars.ToString();
                lblBackupcount.Text = vc.countBackupvars.ToString();
            }

            Cursor = Cursors.Default;
        }

        private void btnBackupSpec_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if (cbEx.Checked)
            {
                varmanager.varCounts vc = _vm.BackupSpecVarsEx(clbTypes.CheckedItems, clbFolders.CheckedItems, clbCreators.CheckedItems);
                lblVamcount.Text = vc.countVAMvars.ToString();
                lblBackupcount.Text = vc.countBackupvars.ToString();
            }
            else
            {
                varmanager.varCounts vc = _vm.BackupSpecVars(clbTypes.CheckedItems);
                lblVamcount.Text = vc.countVAMvars.ToString();
                lblBackupcount.Text = vc.countBackupvars.ToString();
            }

            Cursor = Cursors.Default;
        }

        private void btnRestoreRef_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            varmanager.varCounts vc = _vm.RestoreNeededVars();
            lblVamcount.Text = vc.countVAMvars.ToString();
            lblBackupcount.Text = vc.countBackupvars.ToString();

            setfunctionstatus();

            Cursor = Cursors.Default;
        }

        private void btnRestoreSpec_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            varmanager.varCounts vc = _vm.RestoreSpecificVars(clbTypes.CheckedItems);
            lblVamcount.Text = vc.countVAMvars.ToString();
            lblBackupcount.Text = vc.countBackupvars.ToString();

            setfunctionstatus();

            Cursor = Cursors.Default;
        }

        private void btnRestoreAll_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            varmanager.varCounts vc = _vm.RestoreAllvars();
            lblVamcount.Text = vc.countVAMvars.ToString();
            lblBackupcount.Text = vc.countBackupvars.ToString();

            setfunctionstatus();

            Cursor = Cursors.Default;
        }

        private void cbEx_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEx.Checked) { clbCreators.Enabled = true; clbFolders.Enabled = true; }
            else { clbCreators.Enabled = false; clbFolders.Enabled = false; }
        }

        private void btnResetSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["vamfolder"] = null;
            Properties.Settings.Default["backupfolder"] = null;
            Properties.Settings.Default["creatorex"] = null;
            Properties.Settings.Default["folderex"] = null;
            Properties.Settings.Default.Save();
            txtVamfolder.Text = "";
            txtBackupfolder.Text = "";
            _creatorex = null;
            _folderex = null;
            lblVamcount.Text = "";
            lblBackupcount.Text = "";

            _enabled = false;

            setfunctionstatus();
        }

        private void txtCreatorFilter_TextChanged(object sender, EventArgs e)
        {
            clbFilter(ref clbCreators, txtCreatorFilter.Text, _creatorListvam, _creatorex);
        }

        private void txtFolderFilter_TextChanged(object sender, EventArgs e)
        {
            clbFilter(ref clbFolders, txtFolderFilter.Text, _folderListvam, _folderex);
        }

        private void cbAllCreators_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            clbSetAll(ref clbCreators, cbAllCreators.Checked);
            Cursor = Cursors.Default;
        }

        private void cbInvertCreators_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            clbInvert(ref clbCreators);
            Cursor = Cursors.Default;
        }

        private void cbAllFolders_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            clbSetAll(ref clbFolders, cbAllFolders.Checked);
            Cursor = Cursors.Default;
        }

        private void cbInvertFolders_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            clbInvert(ref clbFolders);
            Cursor = Cursors.Default;
        }

        private void cbAllSpec_CheckedChanged(object sender, EventArgs e)
        {
            clbSetAll(ref clbTypes, cbAllSpec.Checked);
        }

        private void cbInvertSpec_CheckedChanged(object sender, EventArgs e)
        {
            clbInvert(ref clbTypes);
        }

        private void clbSetAll(ref CheckedListBox clb, bool boolChecked)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                clb.SetItemChecked(i, boolChecked);
            }
        }

        private void clbInvert(ref CheckedListBox clb)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                clb.SetItemChecked(i, !clb.GetItemChecked(i));
            }
        }

        private void clbFilter(ref CheckedListBox clb, string strfilter, List<string> fulllist, System.Collections.Specialized.StringCollection checkedlist)
        {
            var itemsNeeded = from strItem in fulllist
                              where strItem.Contains(strfilter,StringComparison.OrdinalIgnoreCase)
                              select strItem;

            //Add Items
            foreach (var i in itemsNeeded)
            {
                if (!clb.Items.Contains(i))
                {
                    if (checkedlist !=  null)
                    {
                        if (checkedlist.Contains(i)) { clb.Items.Add(i, true); }
                        else { clb.Items.Add(i, false); }
                    }
                    else { clb.Items.Add(i, false); }
                }
            }

            //Remove Iitems
            for (int i = clb.Items.Count -1; i >=0; i--)
            {
                if (!itemsNeeded.Contains(clb.Items[i].ToString()))
                {
                    clb.Items.RemoveAt(i);
                }
            }

            clb.Sorted = true;

            for (int i = clb.Items.Count - 1; i >= 0; i--)
            {
                if (clb.Items[i].ToString() == "AddonPackages" && i != 0)
                {
                    var temp = clb.Items[0];
                    clb.Items[0] = clb.Items[i];
                    clb.Items[i] = temp;
                }
            }
        }
    }
}
