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
using System.Runtime.Serialization;
using System.Xml.Serialization;
using static VAMvarmanager.frmVARManager;

namespace VAMvarmanager
{
    public partial class frmVARManager : Form
    {
        public varmanager vm;
        private FolderBrowserDialog fbVam;
        private FolderBrowserDialog fbBackup;
        private bool _enabled = false;
        public string _strVamdir;
        private string _strBackupdir;
        private System.Collections.Specialized.StringCollection _creatorex;
        private System.Collections.Specialized.StringCollection _folderex;
        private List<string> _creatorListvam;
        private List<string> _folderListvam;
        private List<string> _creatorListbak;
        private List<string> _folderListbak;
        private System.Collections.Specialized.StringCollection _creatorRestoreex;
        private System.Collections.Specialized.StringCollection _folderRestoreex;
        private System.Collections.Specialized.StringCollection _lastActivevars;
        private int _lastActivevarcount;

        public class vmFilterConfig
        {
            public List<string> creatorex;
            public List<string> folderex;
            public List<string> creatorRestoreex;
            public List<string> folderRestoreex;
        }

        public frmVARManager()
        { 
            InitializeComponent();
            txtVamfolder.Enabled = false;
            txtBackupfolder.Enabled = false;
            txtCreatorFilter.Enabled = false;
            txtFolderFilter.Enabled = false;

            cbAllCreators.Enabled = false;
            cbInvertCreators.Enabled = false;
            cbAllFolders.Enabled = false;
            cbInvertFolders.Enabled = false;

            cbSavesScene.Enabled = false;
            cbUIAssist.Enabled = false;
            gbPresets.Enabled = false;

            btnMorphPresets.Enabled = false;
            btnSaveFilters.Enabled = false;
            btnLoadFilters.Enabled = false;

            cbBackupEx.Checked = true;
            cbBackupEx.Enabled = false;
            cbRestoreEx.Checked = false;
            cbRestoreEx.Enabled = false;
            cbSkipFavorites.Enabled = false;

            cbDateFilter.Checked = false;
            cbDateFilter.Enabled = false;
            dtpFilter.MaxDate = DateTime.Today;
            dtpFilter.Enabled = false;
            dtpFilter.Hide();

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
            this.clbFoldersRestore.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbFoldersRestore_ItemCheck);
            this.clbCreatorsRestore.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCreatorsRestore_ItemCheck);

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

            try { cbSkipFavorites.Checked = (bool)Properties.Settings.Default["skipFavorites"]; }
            catch
            {
                cbSkipFavorites.Checked = false;
            }

            _creatorRestoreex = new System.Collections.Specialized.StringCollection();
            _folderRestoreex = new System.Collections.Specialized.StringCollection();

            cbBackupEx.Checked = true;

            dgvTypes.Rows.Add("Assets", false, false, false);
            dgvTypes.Rows.Add("Clothing", false, false, false);
            dgvTypes.Rows.Add("Clothing Presets", false, false, false);
            dgvTypes.Rows.Add("Hair", false, false, false);
            dgvTypes.Rows.Add("Hair Presets", false, false, false);
            dgvTypes.Rows.Add("Looks", false, false, false);
            dgvTypes.Rows.Add("Morphs", false, false, false);
            dgvTypes.Rows.Add("Poses", false, false, false);
            dgvTypes.Rows.Add("Scenes", false, false, false);
            dgvTypes.Rows.Add("SubScenes", false, false, false);
            dgvTypes.Rows.Add("Scripts", false, false, false);
            dgvTypes.Rows.Add("Skin Textures", false, false, false);

            setfunctionstatus();
            
        }

        private void setfunctionstatus() 
        {
            Cursor = Cursors.WaitCursor;

            if (_enabled)
            {
                vm = new varmanager(_strVamdir, _strBackupdir);

                varmanager.varCounts vc = vm.GetVarCounts();
                lblVamcount.Text = vc.countVAMvars.ToString();
                lblBackupcount.Text = vc.countBackupvars.ToString();

                clbCreators.Items.Clear();
                _creatorListvam = vm.GetCreatorList();

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

                clbCreatorsRestore.Items.Clear();
                _creatorListbak = vm.GetCreatorList(true);

                foreach (string c in _creatorListbak)
                {
                    clbCreatorsRestore.Items.Add(c, false);
                }

                clbFolders.Items.Clear();

                _folderListvam = new List<string>();

                var dirs = from f in Directory.GetDirectories(_strVamdir + @"\AddonPackages", "*", SearchOption.AllDirectories)
                           where !f.EndsWith(".var") && !f.Contains(@".var\")
                           select f.Replace(_strVamdir + @"\AddonPackages\", "");

                _folderListvam.Add(@"\root\");
                _folderListvam.AddRange(dirs.ToList<string>());

                foreach (string f in _folderListvam)
                {
                    if (_folderex == null)
                    {
                        clbFolders.Items.Add(f, false);
                    }
                    else
                    {
                        if (_folderex.Contains(f)) { 
                            clbFolders.Items.Add(f, true); 
                        }
                        else { clbFolders.Items.Add(f, false); }
                    }
                }

                clbFolders.Sorted = true;

                for (int i = clbFolders.Items.Count - 1; i >= 0; i--)
                {
                    if (clbFolders.Items[i].ToString() == @"\root\" && i != 0)
                    {
                        var temp = clbFolders.Items[i];
                        bool tempChecked = clbFolders.GetItemChecked(i);
                        clbFolders.Sorted = false;
                        clbFolders.Items.RemoveAt(i);
                        clbFolders.Items.Insert(0, temp);
                        clbFolders.SetItemChecked(0, tempChecked);
                        break;
                    }
                }

                clbFoldersRestore.Items.Clear();

                _folderListbak = new List<string>();

                var dirsRestore = from f in Directory.GetDirectories(_strBackupdir, "*", SearchOption.AllDirectories)
                                  where !f.EndsWith(".var") && !f.Contains(@".var\")
                                  select f.Replace(_strBackupdir + @"\", "");

                _folderListbak.Add(@"\root\");
                _folderListbak.AddRange(dirsRestore.ToList<string>());

                foreach (string f in _folderListbak)
                {
                    clbFoldersRestore.Items.Add(f, false);
                }

                clbFoldersRestore.Sorted = true;

                for (int i = clbFoldersRestore.Items.Count - 1; i >= 0; i--)
                {
                    if (clbFoldersRestore.Items[i].ToString() == @"\root\" && i != 0)
                    {
                        var temp = clbFoldersRestore.Items[i];
                        bool tempChecked = clbFoldersRestore.GetItemChecked(i);
                        clbFoldersRestore.Sorted = false;
                        clbFoldersRestore.Items.RemoveAt(i);
                        clbFoldersRestore.Items.Insert(0, temp);
                        clbFoldersRestore.SetItemChecked(0, tempChecked);
                        break;
                    }
                }

                //Check auto-saved last config
                try { _lastActivevars = (System.Collections.Specialized.StringCollection)Properties.Settings.Default["lastActiveVars"]; }
                catch
                {
                    _lastActivevars = null;
                }

                try { _lastActivevarcount = (int)Properties.Settings.Default["lastActiveVarcount"]; }
                catch
                {
                    _lastActivevarcount = 0;
                }

                if( _lastActivevarcount == 0 || _lastActivevars == null)
                {
                    _lastActivevars = new System.Collections.Specialized.StringCollection();
                    _lastActivevars.AddRange(vm.getActiveVarConfig().ToArray());
                    Properties.Settings.Default["lastActiveVars"] = _lastActivevars;
                    _lastActivevarcount = vm.GetVarCounts().countVAMvars;
                    Properties.Settings.Default["lastActiveVarcount"] = _lastActivevarcount;
                    Properties.Settings.Default.Save();
                }

                btnRestoreLastConfig.Enabled = true;
                btnRestoreLastConfig.Text = "Restore Last Config/Undo" + Environment.NewLine + "(" + _lastActivevarcount.ToString() + " Active vars)";

                if (cbRestoreEx.Checked)
                {
                    this.clbCreatorsRestore.Enabled = true;
                    this.clbCreatorsRestore.Show();
                    this.clbFoldersRestore.Enabled = true;
                    this.clbFoldersRestore.Show();

                    this.clbCreators.Enabled = false;
                    this.clbCreators.Hide();
                    this.clbFolders.Enabled = false;
                    this.clbFolders.Hide();
                }
                else 
                {
                    this.clbCreatorsRestore.Enabled = false;
                    this.clbCreatorsRestore.Hide();
                    this.clbFoldersRestore.Enabled = false;
                    this.clbFoldersRestore.Hide();
                    
                    this.clbCreators.Enabled = true;
                    this.clbCreators.Show();
                    this.clbFolders.Enabled = true;
                    this.clbFolders.Show();
                }
                
                this.btnBackupUnref.Enabled = true;
                this.btnBackupUnrefSpec.Enabled = true;
                this.btnBackupSpec.Enabled = true;
                this.btnRestoreRef.Enabled = true;
                this.btnRestoreSpec.Enabled = true;
                this.btnRestoreAll.Enabled = true;
                this.btnMoveOldVarVersions.Enabled = true;
                this.btnDisablepreloadmorphs.Enabled = true;
                this.btnRevertpreloadmorphs.Enabled = true;
                this.btnDisableClothing.Enabled = true;
                this.btnMorphPresets.Enabled = true;
                this.btnSaveFilters.Enabled = true;
                this.btnLoadFilters.Enabled = true;
                this.btnSaveConfig.Enabled = true;
                this.btnRestoreConfig.Enabled = true;

                this.txtCreatorFilter.Enabled = true;
                this.txtFolderFilter.Enabled = true;

                this.cbAllCreators.Enabled = true;
                this.cbInvertCreators.Enabled = true;
                this.cbAllFolders.Enabled = true;
                this.cbInvertFolders.Enabled = true;

                this.cbBackupEx.Enabled = true;
                this.cbRestoreEx.Enabled = true;
                this.cbSkipFavorites.Enabled = true;

                this.cbDateFilter.Enabled = true;
                this.dtpFilter.Enabled = true;

                this.cbSavesScene.Enabled = true;
                this.cbUIAssist.Enabled = true;
                this.gbPresets.Enabled = true;
            }
            else
            {
                this.clbCreators.Enabled = false;
                this.clbCreators.Hide();
                this.clbFolders.Enabled = false;
                this.clbFolders.Hide();

                this.clbCreatorsRestore.Enabled = false;
                this.clbCreatorsRestore.Hide();
                this.clbFoldersRestore.Enabled = false;
                this.clbFoldersRestore.Hide();

                this.btnBackupUnref.Enabled = false;
                this.btnBackupUnrefSpec.Enabled = false;
                this.btnBackupSpec.Enabled = false;
                this.btnRestoreRef.Enabled = false;
                this.btnRestoreSpec.Enabled = false;
                this.btnRestoreAll.Enabled = false;
                this.btnMoveOldVarVersions.Enabled = false;
                this.btnDisablepreloadmorphs.Enabled = false;
                this.btnRevertpreloadmorphs.Enabled = false;
                this.btnDisableClothing.Enabled = false;
                this.btnMorphPresets.Enabled = false;
                this.btnSaveFilters.Enabled = false;
                this.btnLoadFilters.Enabled = false;
                this.btnSaveConfig.Enabled = false;
                this.btnRestoreConfig.Enabled = false;

                this.txtCreatorFilter.Enabled = false;
                this.txtFolderFilter.Enabled = false;

                this.cbAllCreators.Enabled = false;
                this.cbInvertCreators.Enabled = false;
                this.cbAllFolders.Enabled = false;
                this.cbInvertFolders.Enabled = false;

                this.cbBackupEx.Enabled = false;
                this.cbRestoreEx.Enabled = false;
                this.cbSkipFavorites.Enabled = false;

                this.cbDateFilter.Enabled = false;
                this.dtpFilter.Enabled = false;

                this.cbSavesScene.Enabled = false;
                this.cbUIAssist.Enabled = false;
                this.gbPresets.Enabled = false;

                btnRestoreLastConfig.Enabled = false;
                btnRestoreLastConfig.Text = "Restore Last Config/Undo" + Environment.NewLine + "(0 Active vars)";
            }

            Cursor = Cursors.Default;

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

        private void clbCreatorsRestore_ItemCheck(Object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked && _creatorRestoreex == null)
            {
                _creatorRestoreex = new System.Collections.Specialized.StringCollection();
                _creatorRestoreex.Add(clbCreators.GetItemText(clbCreatorsRestore.Items[e.Index]));
            }
            else if (e.NewValue == CheckState.Checked)
            {
                if (!_creatorRestoreex.Contains(clbCreatorsRestore.GetItemText(clbCreatorsRestore.Items[e.Index])))
                {
                    _creatorRestoreex.Add(clbCreatorsRestore.GetItemText(clbCreatorsRestore.Items[e.Index]));
                }
            }
            else
            {
                if (_creatorRestoreex.Contains(clbCreatorsRestore.GetItemText(clbCreatorsRestore.Items[e.Index])))
                {
                    _creatorRestoreex.Remove(clbCreatorsRestore.GetItemText(clbCreatorsRestore.Items[e.Index]));
                }
            }
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

        private void clbFoldersRestore_ItemCheck(Object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked && _folderRestoreex == null)
            {
                _folderRestoreex = new System.Collections.Specialized.StringCollection();
                _folderRestoreex.Add(clbFoldersRestore.GetItemText(clbFoldersRestore.Items[e.Index]));
            }
            else if (e.NewValue == CheckState.Checked)
            {
                if (!_folderRestoreex.Contains(clbFoldersRestore.GetItemText(clbFoldersRestore.Items[e.Index])))
                {
                    _folderRestoreex.Add(clbFoldersRestore.GetItemText(clbFoldersRestore.Items[e.Index]));
                }

            }
            else
            {
                if (_folderRestoreex.Contains(clbFoldersRestore.GetItemText(clbFoldersRestore.Items[e.Index])))
                {
                    _folderRestoreex.Remove(clbFoldersRestore.GetItemText(clbFoldersRestore.Items[e.Index]));
                }
            }
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

            saveLastActivevars();

            if (cbBackupEx.Checked)
            {
                varmanager.varCounts vc = vm.BackupUnrefVarsEx(clbFolders.CheckedItems, clbCreators.CheckedItems, getLocalFileFilters(), cbSkipFavorites.Checked, cbDateFilter.Checked ? dtpFilter.Value : default);
                lblVamcount.Text = vc.countVAMvars.ToString();
                lblBackupcount.Text = vc.countBackupvars.ToString();
            }
            else
            {
                varmanager.varCounts vc = vm.BackupUnrefVars(getLocalFileFilters(), cbSkipFavorites.Checked, cbDateFilter.Checked ? dtpFilter.Value : default);
                lblVamcount.Text = vc.countVAMvars.ToString();
                lblBackupcount.Text = vc.countBackupvars.ToString();
            }

            setfunctionstatus();

            Cursor = Cursors.Default;
        }

        private void btnBackupUnrefSpec_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            saveLastActivevars();

            if (cbBackupEx.Checked)
            {
                varmanager.varCounts vc = vm.BackupUnrefSpecVarsEx(dgvTypes, cbIgnoreHidden.Checked, clbFolders.CheckedItems, clbCreators.CheckedItems, getLocalFileFilters(), cbSkipFavorites.Checked, cbDateFilter.Checked ? dtpFilter.Value : default);
                lblVamcount.Text = vc.countVAMvars.ToString();
                lblBackupcount.Text = vc.countBackupvars.ToString();
            }
            else
            {
                varmanager.varCounts vc = vm.BackupUnrefSpecVars(dgvTypes, cbIgnoreHidden.Checked, getLocalFileFilters(), cbSkipFavorites.Checked, cbDateFilter.Checked ? dtpFilter.Value : default);
                lblVamcount.Text = vc.countVAMvars.ToString();
                lblBackupcount.Text = vc.countBackupvars.ToString();
            }

            setfunctionstatus();

            Cursor = Cursors.Default;
        }

        private void btnBackupSpec_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            saveLastActivevars();

            if (cbBackupEx.Checked)
            {
                varmanager.varCounts vc = vm.BackupSpecVarsEx(dgvTypes, cbIgnoreHidden.Checked, clbFolders.CheckedItems, clbCreators.CheckedItems, cbSkipFavorites.Checked, cbDateFilter.Checked ? dtpFilter.Value : default);
                lblVamcount.Text = vc.countVAMvars.ToString();
                lblBackupcount.Text = vc.countBackupvars.ToString();
            }
            else
            {
                varmanager.varCounts vc = vm.BackupSpecVars(dgvTypes, cbIgnoreHidden.Checked, cbSkipFavorites.Checked, cbDateFilter.Checked ? dtpFilter.Value : default);
                lblVamcount.Text = vc.countVAMvars.ToString();
                lblBackupcount.Text = vc.countBackupvars.ToString();
            }

            setfunctionstatus();

            Cursor = Cursors.Default;
        }

        private void btnRestoreRef_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            saveLastActivevars();

            if (cbRestoreEx.Checked)
            {
                varmanager.varCounts vc = vm.RestoreNeededVarsEx(getLocalFileFilters(), clbFoldersRestore.CheckedItems, clbCreatorsRestore.CheckedItems);
                lblVamcount.Text = vc.countVAMvars.ToString();
                lblBackupcount.Text = vc.countBackupvars.ToString();
            }
            else
            {
                varmanager.varCounts vc = vm.RestoreNeededVars(getLocalFileFilters());
                lblVamcount.Text = vc.countVAMvars.ToString();
                lblBackupcount.Text = vc.countBackupvars.ToString();
            }

            setfunctionstatus();

            Cursor = Cursors.Default;
        }

        private void btnRestoreSpec_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            saveLastActivevars();

            if (cbRestoreEx.Checked)
            {
                varmanager.varCounts vc = vm.RestoreSpecificVarsEx(dgvTypes, cbIgnoreHidden.Checked, clbFoldersRestore.CheckedItems, clbCreatorsRestore.CheckedItems);
                lblVamcount.Text = vc.countVAMvars.ToString();
                lblBackupcount.Text = vc.countBackupvars.ToString();
            }
            else
            {
                varmanager.varCounts vc = vm.RestoreSpecificVars(dgvTypes, cbIgnoreHidden.Checked);
                lblVamcount.Text = vc.countVAMvars.ToString();
                lblBackupcount.Text = vc.countBackupvars.ToString();
            }
            
            setfunctionstatus();

            Cursor = Cursors.Default;
        }

        private void btnRestoreAll_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            saveLastActivevars();

            if (cbRestoreEx.Checked)
            {
                varmanager.varCounts vc = vm.RestoreAllvarsEx(clbFoldersRestore.CheckedItems, clbCreatorsRestore.CheckedItems);
                lblVamcount.Text = vc.countVAMvars.ToString();
                lblBackupcount.Text = vc.countBackupvars.ToString();
            }
            else
            {
                varmanager.varCounts vc = vm.RestoreAllvars();
                lblVamcount.Text = vc.countVAMvars.ToString();
                lblBackupcount.Text = vc.countBackupvars.ToString();
            }
            
            setfunctionstatus();

            Cursor = Cursors.Default;
        }

        private void btnMoveOldVarVersions_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            varmanager.varCounts vc = vm.MoveOldVarVersions();
            lblVamcount.Text = vc.countVAMvars.ToString();
            lblBackupcount.Text = vc.countBackupvars.ToString();

            setfunctionstatus();

            MessageBox.Show(vc.countOldvars.ToString() + " old versions of vars moved to:" + Environment.NewLine + _strVamdir + @"\_oldvars", "Old vars Moved", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            Cursor = Cursors.Default;
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
            if (cbBackupEx.Checked)
            {
                clbFilter(ref clbCreators, txtCreatorFilter.Text, _creatorListvam, _creatorex);
            }
            else
            {
                clbFilter(ref clbCreatorsRestore, txtCreatorFilter.Text, _creatorListbak, _creatorRestoreex);
            }
        }

        private void txtFolderFilter_TextChanged(object sender, EventArgs e)
        {
            if (cbBackupEx.Checked)
            {
                clbFilter(ref clbFolders, txtFolderFilter.Text, _folderListvam, _folderex);
            }
            else
            {
                clbFilter(ref clbFoldersRestore, txtFolderFilter.Text, _folderListbak, _folderRestoreex);
            }
        }

        private void cbAllCreators_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (cbBackupEx.Checked)
            {
                clbSetAll(ref clbCreators, cbAllCreators.Checked);
            }
            else
            {
                clbSetAll(ref clbCreatorsRestore, cbAllCreators.Checked);
            }
            Cursor = Cursors.Default;
        }

        private void cbInvertCreators_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (cbBackupEx.Checked)
            {
                clbInvert(ref clbCreators);
            }
            else
            {
                clbInvert(ref clbCreatorsRestore);
            }
            Cursor = Cursors.Default;
        }

        private void cbAllFolders_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (cbBackupEx.Checked)
            {
                clbSetAll(ref clbFolders, cbAllFolders.Checked);
            }
            else
            {
                clbSetAll(ref clbFoldersRestore, cbAllFolders.Checked);
            }
            Cursor = Cursors.Default;
        }

        private void cbInvertFolders_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (cbBackupEx.Checked)
            {
                clbInvert(ref clbFolders);
            }
            else
            {
                clbInvert(ref clbFoldersRestore);
            }
            Cursor = Cursors.Default;
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

            clb.BeginUpdate();

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
                if (clb.Items[i].ToString() == @"\root\" && i != 0)
                {
                    var temp = clb.Items[i];
                    bool tempChecked = clb.GetItemChecked(i);
                    clb.Sorted = false;
                    clb.Items.RemoveAt(i);
                    clb.Items.Insert(0, temp);
                    clb.SetItemChecked(0, tempChecked);
                    break;
                }
            }

            clb.EndUpdate();
        }

        private void btnDisablepreloadmorphs_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int test = vm.DisablePreloadMorphs();
            Cursor = Cursors.Default;
        }

        private void btnRevertpreloadmorphs_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int test = vm.RevertPreloadMorphs();
            Cursor = Cursors.Default;
        }

        private void btnDisableClothing_Click(object sender, EventArgs e)
        {
            //Cursor = Cursors.WaitCursor;
            //Cursor = Cursors.Default;
            //_vm.GetDuplicateItems("clothing","female",true);

            frmDuplicateItemManager frmDIM = new frmDuplicateItemManager(this);
            this.Hide();
            frmDIM.Show();
        }

        private List<string> getLocalFileFilters()
        {
            List<string> lstReturn = new List<string> ();

            if (cbSavesScene.Checked) { lstReturn.Add(@"\Saves\scene"); }
            if (cbUIAssist.Checked) { lstReturn.Add(@"\Saves\PluginData\JayJayWon\UIAssist"); }
            if (cbAppearance.Checked) { lstReturn.Add(@"\Custom\Atom\Person\Appearance"); }
            if (cbClothing.Checked) { lstReturn.Add(@"\Custom\Atom\Person\Clothing"); }
            if (cbHair.Checked) { lstReturn.Add(@"\Custom\Atom\Person\Hair"); }
            if (cbMorphs.Checked) { lstReturn.Add(@"\Custom\Atom\Person\Morphs"); }
            if (cbPlugins.Checked) { lstReturn.Add(@"\Custom\Atom\Person\Plugins"); }
            if (cbSkin.Checked) { lstReturn.Add(@"\Custom\Atom\Person\Skin"); }

            return lstReturn;
        }

        private void cbSavesScene_MouseHover(object sender, EventArgs e)
        {
            toolTipSaves.Show(@"Scans all scenes in Saves\Scene\ and all sub-folders for dependencies." + Environment.NewLine + "May take some time to complete for many files/large scenes.", cbSavesScene);
        }

        private void btnMorphPresets_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmMorphPresetMaker frmMPM = new frmMorphPresetMaker(this);
            this.Hide();
            frmMPM.Show();
            Cursor = Cursors.Default;
        }

        private void cbBackupEx_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBackupEx.Checked)
            {
                this.cbRestoreEx.Checked = false;

                this.clbCreatorsRestore.Enabled = false;
                this.clbCreatorsRestore.Hide();
                this.clbFoldersRestore.Enabled = false;
                this.clbFoldersRestore.Hide();

                this.clbCreators.Enabled = true;
                this.clbCreators.Show();
                this.clbFolders.Enabled = true;
                this.clbFolders.Show();
            }
            else
            {
                this.clbCreators.Enabled = false;
                this.clbCreators.Hide();
                this.clbFolders.Enabled = false;
                this.clbFolders.Hide();
            }
        }

        private void cbRestoreEx_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRestoreEx.Checked)
            {
                this.cbBackupEx.Checked = false;

                this.clbCreatorsRestore.Enabled = true;
                this.clbCreatorsRestore.Show();
                this.clbFoldersRestore.Enabled = true;
                this.clbFoldersRestore.Show();

                this.clbCreators.Enabled = false;
                this.clbCreators.Hide();
                this.clbFolders.Enabled = false;
                this.clbFolders.Hide();
            }
            else
            {
                this.clbCreatorsRestore.Enabled = false;
                this.clbCreatorsRestore.Hide();
                this.clbFoldersRestore.Enabled = false;
                this.clbFoldersRestore.Hide();
            }
        }

        private void btnRestoreConfig_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            ofdVarConfig = new OpenFileDialog();
            ofdVarConfig.InitialDirectory = _strVamdir;
            ofdVarConfig.DefaultExt = "txt";
            ofdVarConfig.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (ofdVarConfig.ShowDialog() == DialogResult.OK)
            {
                saveLastActivevars();

                varmanager.varCounts vc = vm.RestoreVarConfig(ofdVarConfig.FileName); ;
                lblVamcount.Text = vc.countVAMvars.ToString();
                lblBackupcount.Text = vc.countBackupvars.ToString();
            }

            Cursor = Cursors.Default;
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            sfdVarConfig = new SaveFileDialog();
            sfdVarConfig.InitialDirectory = _strVamdir;
            sfdVarConfig.DefaultExt = "txt";
            sfdVarConfig.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            sfdVarConfig.AddExtension = true;

            if(sfdVarConfig.ShowDialog() == DialogResult.OK)
            {
                vm.SaveVarConfig(sfdVarConfig.FileName);
            }

            Cursor = Cursors.Default;
        }

        private void cbSkipFavorites_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["skipFavorites"] = cbSkipFavorites.Checked;
            Properties.Settings.Default.Save();
        }

        private void cbDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            if(cbDateFilter.Checked)
            {
                dtpFilter.Enabled = true;
                dtpFilter.Show();
            }
            else
            {
                dtpFilter.Enabled = false;
                dtpFilter.Hide();
            }
        }

        private void cbDateFilter_MouseHover(object sender, EventArgs e)
        {
            toolTipDateFilter.Show("Only move vars older than the selected date. BACKUP operations only.", cbDateFilter);
        }

        private void saveLastActivevars()
        {
            _lastActivevars = new System.Collections.Specialized.StringCollection();
            _lastActivevars.AddRange(vm.getActiveVarConfig().ToArray());
            Properties.Settings.Default["lastActiveVars"] = _lastActivevars;
            _lastActivevarcount = vm.GetVarCounts().countVAMvars;
            Properties.Settings.Default["lastActiveVarcount"] = _lastActivevarcount;
            Properties.Settings.Default.Save();

            btnRestoreLastConfig.Text = "Restore Last Config/Undo" + Environment.NewLine + "(" + _lastActivevarcount.ToString() + " Active vars)";
        }

        private void btnRestoreLastConfig_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            System.Collections.Specialized.StringCollection lastActiveVarstemp = _lastActivevars;
            int lastActiveVarcounttemp = _lastActivevarcount;

            saveLastActivevars();

            varmanager.varCounts vc = vm.restoreLastVarConfig(lastActiveVarstemp); ;
            lblVamcount.Text = vc.countVAMvars.ToString();
            lblBackupcount.Text = vc.countBackupvars.ToString();

            Cursor = Cursors.Default;
        }

        private void dgvTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTypes.Columns[e.ColumnIndex].Name != "Type" && e.RowIndex >= 0)
            {
                if((bool)dgvTypes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == true)
                {
                    dgvTypes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                }
                else
                {
                    dgvTypes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;

                    for (int i = 1; i < dgvTypes.ColumnCount; i++)
                    {
                        if (i != e.ColumnIndex)
                        {
                            if((bool)dgvTypes.Rows[e.RowIndex].Cells[i].Value == true)
                            {
                                dgvTypes.Rows[e.RowIndex].Cells[i].Value = false;
                            }
                        }
                    }
                }
            }

            dgvTypes.ClearSelection();
        }

        private void dgvTypes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int intCountChecked = 0;

            if (dgvTypes.Columns[e.ColumnIndex].Name != "Type")
            {
                foreach (DataGridViewRow dgvrow in dgvTypes.Rows)
                {
                    if ((bool)dgvrow.Cells[e.ColumnIndex].Value == false)
                    {
                        dgvrow.Cells[e.ColumnIndex].Value = true;

                        for (int i = 1; i < dgvTypes.ColumnCount; i++)
                        {
                            if (i != e.ColumnIndex)
                            {
                                if ((bool)dgvrow.Cells[i].Value == true)
                                {
                                    dgvrow.Cells[i].Value = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        intCountChecked += 1;
                    }
                }

                if (intCountChecked == dgvTypes.Rows.Count)
                {
                    foreach (DataGridViewRow dgvrow in dgvTypes.Rows)
                    {
                        dgvrow.Cells[e.ColumnIndex].Value = false;
                    }
                }
            }
        }

        private void btnSaveFilters_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string strFilterConfigFileName;
            SaveFileDialog sfdFilters = new SaveFileDialog();

            sfdFilters.InitialDirectory = _strVamdir;
            sfdFilters.FileName = "vm_filters_";
            sfdFilters.DefaultExt = "xml";
            sfdFilters.Filter = "XML Files (*.xml)|*.xml";
            sfdFilters.AddExtension = true;
            sfdFilters.ShowDialog();

            strFilterConfigFileName = sfdFilters.FileName;

            if (strFilterConfigFileName != null)
            {
                if (!strFilterConfigFileName.EndsWith(".xml"))
                {
                    strFilterConfigFileName = strFilterConfigFileName + ".xml";

                }
            }

            XmlSerializer ser = new XmlSerializer(typeof(vmFilterConfig));
            TextWriter writer = new StreamWriter(strFilterConfigFileName);
            List<string> lstCreatorEx = new List<string>();
            List<string> lstFolderEx = new List<string>();
            List<string> lstRestoreCreatorEx = new List<string>();
            List<string> lstRestoreFolderEx = new List<string>();
            foreach (string s in _creatorex)
            {
                lstCreatorEx.Add(s);
            }
            foreach (string s in _folderex)
            {
                lstFolderEx.Add(s);
            }
            foreach (string s in _creatorRestoreex)
            {
                lstRestoreCreatorEx.Add(s);
            }
            foreach (string s in _folderRestoreex)
            {
                lstRestoreFolderEx.Add(s);
            }

            vmFilterConfig fc = new vmFilterConfig();
            fc.creatorex= lstCreatorEx;
            fc.folderex = lstFolderEx;
            fc.creatorRestoreex = lstRestoreCreatorEx;
            fc.folderRestoreex = lstRestoreFolderEx;

            ser.Serialize(writer, fc);
            writer.Close();

            Cursor = Cursors.Default;
        }

        private void btnLoadFilters_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string strFilterConfigFileName;
            OpenFileDialog fdFilters = new OpenFileDialog();

            fdFilters.InitialDirectory = _strVamdir;
            fdFilters.DefaultExt = "xml";
            fdFilters.Filter = "XML Files (*.xml)|*.xml";
            fdFilters.ShowDialog();

            strFilterConfigFileName = fdFilters.FileName;

            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(vmFilterConfig));
                TextReader reader = new StreamReader(strFilterConfigFileName);

                vmFilterConfig fc = (vmFilterConfig)ser.Deserialize(reader);
                reader.Close();

                _creatorex.Clear();
                foreach (string s in fc.creatorex)
                {
                    _creatorex.Add(s);
                }
                _folderex.Clear();
                foreach (string s in fc.folderex)
                {
                    _folderex.Add(s);
                }
                _creatorRestoreex.Clear();
                foreach (string s in fc.creatorRestoreex)
                {
                    _creatorRestoreex.Add(s);
                }
                _folderRestoreex.Clear();
                foreach (string s in fc.folderRestoreex)
                {
                    _folderRestoreex.Add(s);
                }

                setfunctionstatus();
            }
            catch
            {
                MessageBox.Show("Error Loading Saved Filters", "Error Loading Saved Filters.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor = Cursors.Default;
        }
    }
}
