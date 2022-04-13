using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VAMvarmanager
{

    public partial class frmMorphPresetMaker : Form
    {
        private frmVARManager _frmVM;
        private List<varmanager.varfile> _lstMorphVars;
        private List<string> _lstSelectedVars;

        public frmMorphPresetMaker(frmVARManager frmVM)
        {
            InitializeComponent();
            _frmVM = frmVM;

            txtDefaultMorphValue.Text = "0.001";

            _lstMorphVars = _frmVM.vm.GetMorphVars();

            _lstSelectedVars = new List<string>();

            this.clbMorphvars.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbMorphvars_ItemCheck);

            comboSex.Items.Clear();
            comboSex.Items.Add("female");
            comboSex.Items.Add("male");
            comboSex.SelectedIndex = 0;
            clbMorphvars.Items.Clear();

            foreach(var vf in _lstMorphVars)
            {
                clbMorphvars.Items.Add(vf.fi.Name + "|" + vf.countMorphs + " Morphs".ToString(),false);
            }

        }

        private void clbMorphvars_ItemCheck(Object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                if (!_lstSelectedVars.Contains(clbMorphvars.GetItemText(clbMorphvars.Items[e.Index]).Split("|")[0]))
                {
                    _lstSelectedVars.Add(clbMorphvars.GetItemText(clbMorphvars.Items[e.Index]).Split("|")[0]);
                }
            }
            else
            {
                if (_lstSelectedVars.Contains(clbMorphvars.GetItemText(clbMorphvars.Items[e.Index]).Split("|")[0]))
                {
                    _lstSelectedVars.Remove(clbMorphvars.GetItemText(clbMorphvars.Items[e.Index]).Split("|")[0]);
                }
            }
        }
        private void txtNameFilter_TextChanged(object sender, EventArgs e)
        {
            clbFilter(ref clbMorphvars);
        }

        private void cbPreloadMorphs_CheckedChanged(object sender, EventArgs e)
        {
            clbFilter(ref clbMorphvars);

        }

        private void cbSortNumMorphs_CheckedChanged(object sender, EventArgs e)
        {
            clbFilter(ref clbMorphvars);

        }

        private void clbFilter(ref CheckedListBox clb)
        {
            IEnumerable<string> itemsNeeded;

            if (cbSortNumMorphs.Checked)
            {
                itemsNeeded = from vf in _lstMorphVars
                              where (cbPreloadMorphs.CheckState == CheckState.Checked ? vf.boolPreloadMorphs == true : 1 == 1) && (txtNameFilter.Text != "" ? vf.fi.Name.Contains(txtNameFilter.Text, StringComparison.OrdinalIgnoreCase) : 1 == 1)
                              orderby vf.countMorphs descending
                              select vf.fi.Name + "|" + vf.countMorphs + " Morphs".ToString();
            }
            else
            {
                itemsNeeded = from vf in _lstMorphVars
                              where (cbPreloadMorphs.CheckState == CheckState.Checked ? vf.boolPreloadMorphs == true : 1 == 1) && (txtNameFilter.Text != "" ? vf.fi.Name.Contains(txtNameFilter.Text, StringComparison.OrdinalIgnoreCase) : 1 == 1)
                              orderby vf.fi.Name
                              select vf.fi.Name + "|" + vf.countMorphs + " Morphs".ToString();
            }

            clb.Items.Clear();

            foreach (var i in itemsNeeded)
            {
                if (_lstSelectedVars != null)
                {
                    if (_lstSelectedVars.Contains(i.Split("|")[0])) { clb.Items.Add(i, true); }
                    else { clb.Items.Add(i, false); }
                }
                else { clb.Items.Add(i, false); }
            }

        }

        private void btnSaveMorphPreset_Click(object sender, EventArgs e)
        {
            if(double.TryParse(txtDefaultMorphValue.Text, out double number1))
            {
                Cursor = Cursors.WaitCursor;

                string strPresetFileName;
                this.sfdMorphPreset = new SaveFileDialog();
                sfdMorphPreset.InitialDirectory = _frmVM._strVamdir + @"\Custom\Atom\Person\Morphs";
                sfdMorphPreset.FileName = "Preset_" + txtPresetName.Text;
                sfdMorphPreset.DefaultExt = "vap";
                sfdMorphPreset.AddExtension = true;
                sfdMorphPreset.ShowDialog();

                strPresetFileName = sfdMorphPreset.FileName;

                if (strPresetFileName != null)
                {
                    if (!strPresetFileName.EndsWith(".vap"))
                    {
                        strPresetFileName = strPresetFileName + ".vap";

                    }
                }

                saveMorphPreset(strPresetFileName, txtDefaultMorphValue.Text);
                
                Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Invalid Default Morph Value", "Invalid Default Morph Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void saveMorphPreset(string strFileName, string strDefaultValue)
        {
            ZipArchive zipVar;
            DirectoryInfo diFolder = new DirectoryInfo(_frmVM._strVamdir + @"\AddonPackages");
            bool boolfirst = true;
            StreamReader srVmi;
            string strLine;
            string strVmiPath;
            var strDisplayName = default(string);
            string strMorphPresetText;
            string strMorphSexLookup = comboSex.Text == "female" ? "custom/atom/person/morphs/female" : "custom/atom/person/morphs/male";
            strMorphPresetText = "{ " + Environment.NewLine + "   \"setUnlistedParamsToDefault\" : \"true\", " + Environment.NewLine + "   \"storables\" : [ " + Environment.NewLine + "      { " + Environment.NewLine + "         \"id\" : \"geometry\", " + Environment.NewLine + "         \"morphs\" : [ ";

            var selectedVars = from vf in _lstMorphVars
                               where _lstSelectedVars.Contains(vf.fi.Name)
                               select vf;

            foreach (var vf in selectedVars)
            {
                zipVar = ZipFile.Open(vf.fi.FullName, ZipArchiveMode.Read);

                // Read morphs
                foreach (ZipArchiveEntry e in zipVar.Entries)
                {
                    if (e.FullName.IndexOf(strMorphSexLookup, 0, StringComparison.CurrentCultureIgnoreCase) > -1 & e.FullName.EndsWith(".vmi"))
                    {
                        strVmiPath = vf.Name + "." + vf.version + ":/" + e.FullName;
                        srVmi = new StreamReader(e.Open());
                        strLine = srVmi.ReadLine();
                        while (!srVmi.EndOfStream)
                        {
                            if (strLine.ToLower().Contains("displayname"))
                            {
                                strDisplayName = strLine.Replace("displayName", "");
                                strDisplayName = strDisplayName.Replace("displayname", "");
                                strDisplayName = strDisplayName.Replace("\":", "\"");
                                strDisplayName = strDisplayName.Replace("\" :", "\"");
                                strDisplayName = strDisplayName.Replace("\",", "\"");
                                strDisplayName = strDisplayName.Replace("\"", "");
                                strDisplayName = strDisplayName.Trim();
                                break;
                            }

                            strLine = srVmi.ReadLine();
                        }

                        srVmi.Close();
                        if (boolfirst)
                        {
                            boolfirst = false;
                            strMorphPresetText += Environment.NewLine;
                        }
                        else
                        {
                            strMorphPresetText += ", " + Environment.NewLine;
                        }

                        strMorphPresetText += "            { " + Environment.NewLine;
                        strMorphPresetText += "               \"uid\" : \"" + strVmiPath + "\", " + Environment.NewLine;
                        strMorphPresetText += "               \"name\" : \"" + strDisplayName + "\", " + Environment.NewLine;
                        strMorphPresetText += "               \"value\" : \"" + strDefaultValue + "\"" + Environment.NewLine;
                        strMorphPresetText += "            }";
                    }
                }
            }

            strMorphPresetText += Environment.NewLine + "         ]" + Environment.NewLine + "      }, " + Environment.NewLine + "      { " + Environment.NewLine + "         \"id\" : \"geometry\"" + Environment.NewLine + "      }, " + Environment.NewLine + "      { " + Environment.NewLine + "         \"id\" : \"geometry\", " + Environment.NewLine + "         \"useMaleMorphsOnFemale\" : \"false\"" + Environment.NewLine + "      }, " + Environment.NewLine + "      { " + Environment.NewLine + "         \"id\" : \"geometry\", " + Environment.NewLine + "         \"useFemaleMorphsOnMale\" : \"false\"" + Environment.NewLine + "      }" + Environment.NewLine + "   ]" + Environment.NewLine + "}";

            // Write to preset file
            File.WriteAllText(strFileName, strMorphPresetText);
        }

        private void btnReturnToVM_Click(object sender, EventArgs e)
        {
            _frmVM.Show();
            this.Close();
        }

        private void frmMorphPresetMaker_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            _frmVM.Show();
        }
    }
}
