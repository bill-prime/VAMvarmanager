using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Text.Json;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace VAMvarmanager
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmVARManager());
        }
    }

    public class varmanager
    {
        #region "Structs/Classes"

        public partial class varfile
        {
            public FileInfo fi;
            public DirectoryInfo di;
            public bool unpacked;
            public string Name;
            public string creator;
            public int version;
            public bool boolTextures;
            public bool boolAssets;
            public bool boolMorphs;
            public bool boolPreloadMorphs;
            public bool boolLooks;
            public bool boolLookPresets;
            public bool boolScenes;
            public bool boolSubScenes;
            public bool boolPoses;
            public bool boolPosePresets;
            public bool boolHair;
            public bool boolHairPreset;
            public bool boolClothing;
            public bool boolClothingPreset;
            public bool boolScripts;
            public int countMorphs;

            public varfile()
            {
                Name = "";
                creator = "";
                boolScripts = false;
                boolTextures = false;
                boolAssets = false;
                boolMorphs = false;
                boolPreloadMorphs = false;
                boolLooks = false;
                boolLookPresets = false;
                boolScenes = false;
                boolSubScenes = false;
                boolPoses = false;
                boolPosePresets = false;
                boolHair = false;
                boolHairPreset = false;
                boolClothing = false;
                boolClothingPreset = false;
                boolScripts = false;

                countMorphs = 0;
            }
        }

        public partial class varItem
        {
            public varfile var;
            public string Name;
            public string FullName;
            public vamFile Properties;

            public varItem(varfile v, string strName, string strFullName, vamFile vfProperties = null)
            {
                var = v;
                Name = strName;
                FullName = strFullName;
                Properties = vfProperties;
            }
        }

        public partial class vamFile
        {
            public string itemType { get; set; }
            public string uid { get; set; }
            public string displayName { get; set; }
            public string creatorName { get; set; }
            public string tags { get; set; }
        }

        public partial class dependenydetails
        {
            public string licenseType { get; set; }
            public Dictionary<string, dependenydetails> dependencies { get; set; }
        }

        public partial class customOptions
        {
            public JsonElement? preloadMorphs { get; set; }
        }

        public partial class varMeta
        {
            public string? licenseType { get; set; }
            public string? creatorName { get; set; }
            public string? packageName { get; set; }
            public string? standardReferenceVersionOption { get; set; }
            public string? scriptReferenceVersionOption { get; set; }
            public string? description { get; set; }
            public string? credits { get; set; }
            public string? instructions { get; set; }
            public string? promotionalLink { get; set; }
            public string? programVersion { get; set; }
            public IList<string>? contentList { get; set; }
            public Dictionary<string, dependenydetails> dependencies { get; set; }
            public customOptions? customOptions { get; set; }
            //public dynamic hadReferenceIssues { get; set; }
        }
        public partial class varUserPrefFile
        {
            public string? userNotes { get; set; }
            public customOptions customOptions { get; set; }
        }

        private partial class varconfig
        {
            public List<varfile> vars;
            public List<string> deps;
            public Dictionary<string, int> latestvars;
        }

        public partial class varItemReplacement
        {
            public int varItemReplacementType;
            public string itemtype;
            public string? mastervar;
            public string creator;
            public string itemname;
            public List<varItem> lstVi;

            public const int DISABLE = 0;
            public const int SAMECREATOR = 1;
            public const int NOMASTER = 2;

            public varItemReplacement(int intReplacementType, string strItemType)
            {
                varItemReplacementType = intReplacementType;
                itemtype = strItemType;
                mastervar = null;
                creator = "";
                itemname = "";
                lstVi = new List<varItem>();
            }
        }

        public partial class varCounts
        {
            public int countVAMvars;
            public int countBackupvars;
            public int countOldvars;
        }

        private partial class typeFilter
        {
            public string type;
            public bool OR;
            public bool AND;
            public bool NOT;
        }

        #endregion

        private string _strVAMdir;
        private string _strVAMbackupdir;

        public varmanager(string strVAMdir, string strVAMbackupdir)
        {
            _strVAMdir = strVAMdir;
            _strVAMbackupdir = strVAMbackupdir;
        }


        #region "var Management"

        public varCounts BackupUnrefVars(List<string> lstLocalFiles, bool skipFavorites = false, DateTime dtMaxDate = default)
        {
            varconfig vc = GetVarconfig(_strVAMdir + @"\AddonPackages", lstLocalFiles);
            string[] lstFilePrefs = null;
            if (skipFavorites)
            {
                lstFilePrefs = Directory.GetFiles(_strVAMdir + @"\AddonPackagesFilePrefs","*.fav",SearchOption.AllDirectories);
            }

            var unusedVars = from v in vc.vars
                             where
                                !vc.deps.Contains(v.Name + "." + v.version.ToString(), StringComparer.OrdinalIgnoreCase) && 
                                !(vc.deps.Contains(v.Name + ".latest", StringComparer.OrdinalIgnoreCase) && vc.latestvars.TryGetValue(v.Name,out int intLatestVer) && intLatestVer == v.version) &&
                                (!skipFavorites || (v.unpacked == false && !lstFilePrefs.Any(x => x.Contains(Strings.Left(v.fi.Name, v.fi.Name.Length - 4)))) || (v.unpacked == true && !lstFilePrefs.Any(x => x.Contains(Strings.Left(v.di.Name, v.di.Name.Length - 4))))) &&
                                ((dtMaxDate == default) || (v.unpacked == false && v.fi.LastWriteTime < dtMaxDate) || (v.unpacked == true && v.di.LastWriteTime < dtMaxDate))
                             select v;

            foreach (var f in unusedVars)
            {
                if (f.unpacked == false)
                {
                    if (!Directory.Exists(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                    }

                    if (!File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                    { 
                        File.Move(Convert.ToString(f.fi.FullName), Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))); 
                    }
                }
                else
                {
                    if (!Directory.Exists(Path.GetDirectoryName(f.di.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                    {
                        Directory.Delete(Path.GetDirectoryName(f.di.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                    }

                    Directory.Move(Convert.ToString(f.di.FullName), Convert.ToString(f.di.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                }
            }

            return GetVarCounts();
        }

        public varCounts BackupUnrefVarsEx(System.Windows.Forms.CheckedListBox.CheckedItemCollection lstFolderEx, System.Windows.Forms.CheckedListBox.CheckedItemCollection lstCreatorEx, List<string> lstLocalFiles, bool skipFavorites = false, DateTime dtMaxDate = default)
        {
            varconfig vc = GetVarconfig(_strVAMdir + @"\AddonPackages", lstLocalFiles);
            string[] lstFilePrefs = null;
            if (skipFavorites)
            {
                lstFilePrefs = Directory.GetFiles(_strVAMdir + @"\AddonPackagesFilePrefs", "*.fav", SearchOption.AllDirectories);
            }

            var unusedVars = from v in vc.vars
                             where
                                !vc.deps.Contains(v.Name + "." + v.version.ToString(), StringComparer.OrdinalIgnoreCase) &&
                                !(vc.deps.Contains(v.Name + ".latest", StringComparer.OrdinalIgnoreCase) && vc.latestvars.TryGetValue(v.Name, out int intLatestVer) && intLatestVer == v.version) &&
                                ((v.unpacked == false && !lstFolderEx.Contains(Convert.ToString(v.fi.Directory.Name))) || (v.unpacked == true && !lstFolderEx.Contains(Convert.ToString(Directory.GetParent(v.di.FullName).Name)))) &&
                                ((v.unpacked == false && !(lstFolderEx.Contains(@"\root\") && Path.GetDirectoryName(v.fi.FullName) == _strVAMdir + @"\AddonPackages")) || (v.unpacked == true && !(lstFolderEx.Contains(@"\root\") && Directory.GetParent(v.di.FullName).FullName == _strVAMdir + @"\AddonPackages"))) &&
                                !lstCreatorEx.Contains(Convert.ToString(v.creator)) &&
                                (!skipFavorites || (v.unpacked == false && !lstFilePrefs.Any(x => x.Contains(Strings.Left(v.fi.Name, v.fi.Name.Length - 4)))) || (v.unpacked == true && !lstFilePrefs.Any(x => x.Contains(Strings.Left(v.di.Name, v.di.Name.Length - 4))))) && 
                                ((dtMaxDate == default) || (v.unpacked == false && v.fi.LastWriteTime < dtMaxDate) || (v.unpacked == true && v.di.LastWriteTime < dtMaxDate))
                             select v;

            foreach (var f in unusedVars)
            {

                if (f.unpacked == false)
                {
                    if (!Directory.Exists(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                    }

                    if (!File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                    {
                        File.Move(Convert.ToString(f.fi.FullName), Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                    }
                }
                else
                {
                    if (!Directory.Exists(Path.GetDirectoryName(f.di.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                    {
                        Directory.Delete(Path.GetDirectoryName(f.di.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                    }

                    Directory.Move(Convert.ToString(f.di.FullName), Convert.ToString(f.di.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                }
            }

            return GetVarCounts();
        }

        public varCounts BackupUnrefSpecVars(DataGridView dgvTypes, bool ignoreHidden, List<string> lstLocalFiles, bool skipFavorites = false, DateTime dtMaxDate = default)
        {
            varconfig vc = GetVarconfig(_strVAMdir + @"\AddonPackages", lstLocalFiles, null, null, ignoreHidden);
            string[] lstFilePrefs = null;
            if (skipFavorites)
            {
                lstFilePrefs = Directory.GetFiles(_strVAMdir + @"\AddonPackagesFilePrefs", "*.fav", SearchOption.AllDirectories);
            }

            List<typeFilter> lstTypes = new List<typeFilter>();

            foreach (DataGridViewRow row in dgvTypes.Rows)
            {
                var typeFilt = new typeFilter();
                typeFilt.type = row.Cells["Type"].Value.ToString();
                typeFilt.OR = (bool)row.Cells["OR"].Value;
                typeFilt.AND = (bool)row.Cells["AND"].Value;
                typeFilt.NOT = (bool)row.Cells["NOT"].Value;
                lstTypes.Add(typeFilt);
            }

            var backupvars = from v in vc.vars
                             where
                             (
                                (
                                    lstTypes.Any(x => (x.AND || x.NOT)) &&
                                    ((!lstTypes.Any(x => x.type == "Assets" && (x.AND || x.NOT))) || (v.boolAssets && lstTypes.Any(x => x.type == "Assets" && x.AND)) || (!v.boolAssets && lstTypes.Any(x => x.type == "Assets" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Clothing" && (x.AND || x.NOT))) || (v.boolClothing && lstTypes.Any(x => x.type == "Clothing" && x.AND)) || (!v.boolClothing && lstTypes.Any(x => x.type == "Clothing" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Clothing Presets" && (x.AND || x.NOT))) || (v.boolClothingPreset && lstTypes.Any(x => x.type == "Clothing Presets" && x.AND)) || (!v.boolClothingPreset && lstTypes.Any(x => x.type == "Clothing Presets" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Hair" && (x.AND || x.NOT))) || (v.boolHair && lstTypes.Any(x => x.type == "Hair" && x.AND)) || (!v.boolHair && lstTypes.Any(x => x.type == "Hair" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Hair Presets" && (x.AND || x.NOT))) || (v.boolHairPreset && lstTypes.Any(x => x.type == "Hair Presets" && x.AND)) || (!v.boolHairPreset && lstTypes.Any(x => x.type == "Hair Presets" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Looks" && (x.AND || x.NOT))) || ((v.boolLooks || v.boolLookPresets) && lstTypes.Any(x => x.type == "Looks" && x.AND)) || (!(v.boolLooks || v.boolLookPresets) && lstTypes.Any(x => x.type == "Looks" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Morphs" && (x.AND || x.NOT))) || (v.boolMorphs && lstTypes.Any(x => x.type == "Morphs" && x.AND)) || (!v.boolMorphs && lstTypes.Any(x => x.type == "Morphs" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Poses" && (x.AND || x.NOT))) || ((v.boolPoses || v.boolPosePresets) && lstTypes.Any(x => x.type == "Poses" && x.AND)) || (!(v.boolPoses || v.boolPosePresets) && lstTypes.Any(x => x.type == "Poses" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Scenes" && (x.AND || x.NOT))) || (v.boolScenes && lstTypes.Any(x => x.type == "Scenes" && x.AND)) || (!v.boolScenes && lstTypes.Any(x => x.type == "Scenes" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "SubScenes" && (x.AND || x.NOT))) || (v.boolSubScenes && lstTypes.Any(x => x.type == "SubScenes" && x.AND)) || (!v.boolSubScenes && lstTypes.Any(x => x.type == "SubScenes" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Scripts" && (x.AND || x.NOT))) || (v.boolScripts && lstTypes.Any(x => x.type == "Scripts" && x.AND)) || (!v.boolScripts && lstTypes.Any(x => x.type == "Scripts" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Skin Textures" && (x.AND || x.NOT))) || (v.boolTextures && lstTypes.Any(x => x.type == "Skin Textures" && x.AND)) || (!v.boolTextures && lstTypes.Any(x => x.type == "Skin Textures" && x.NOT)))
                                ) ||
                                (
                                    (v.boolAssets && lstTypes.Any(x => x.type == "Assets" && x.OR)) ||
                                    (v.boolClothing && lstTypes.Any(x => x.type == "Clothing" && x.OR)) ||
                                    (v.boolClothingPreset && lstTypes.Any(x => x.type == "Clothing Presets" && x.OR)) ||
                                    (v.boolHair && lstTypes.Any(x => x.type == "Hair" && x.OR)) ||
                                    (v.boolHairPreset && lstTypes.Any(x => x.type == "Hair Presets" && x.OR)) ||
                                    ((v.boolLooks || v.boolLookPresets) && lstTypes.Any(x => x.type == "Looks" && x.OR)) ||
                                    (v.boolMorphs && lstTypes.Any(x => x.type == "Morphs" && x.OR)) ||
                                    ((v.boolPoses || v.boolPosePresets) && lstTypes.Any(x => x.type == "Poses" && x.OR)) ||
                                    (v.boolScenes && lstTypes.Any(x => x.type == "Scenes" && x.OR)) ||
                                    (v.boolSubScenes && lstTypes.Any(x => x.type == "SubScenes" && x.OR)) ||
                                    (v.boolScripts && lstTypes.Any(x => x.type == "Scripts" && x.OR)) ||
                                    (v.boolTextures && lstTypes.Any(x => x.type == "Skin Textures" && x.OR))
                                )
                            ) &&
                                !vc.deps.Contains(v.Name + "." + v.version.ToString(), StringComparer.OrdinalIgnoreCase) &&
                                !(vc.deps.Contains(v.Name + ".latest", StringComparer.OrdinalIgnoreCase) && vc.latestvars.TryGetValue(v.Name, out int intLatestVer) && intLatestVer == v.version) &&
                                (!skipFavorites || (v.unpacked == false && !lstFilePrefs.Any(x => x.Contains(Strings.Left(v.fi.Name, v.fi.Name.Length - 4)))) || (v.unpacked == true && !lstFilePrefs.Any(x => x.Contains(Strings.Left(v.di.Name, v.di.Name.Length - 4))))) &&
                                ((dtMaxDate == default) || (v.unpacked == false && v.fi.LastWriteTime < dtMaxDate) || (v.unpacked == true && v.di.LastWriteTime < dtMaxDate))
                             select v;

            foreach (var f in backupvars)
            {
                if (f.unpacked == false)
                {
                    if (!Directory.Exists(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                    }

                    if (!File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                    {
                        File.Move(Convert.ToString(f.fi.FullName), Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                    }
                }
                else
                {
                    if (!Directory.Exists(Path.GetDirectoryName(f.di.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                    {
                        Directory.Delete(Path.GetDirectoryName(f.di.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                    }

                    Directory.Move(Convert.ToString(f.di.FullName), Convert.ToString(f.di.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                }
            }

            return GetVarCounts();
        }

        public varCounts BackupUnrefSpecVarsEx(DataGridView dgvTypes, bool ignoreHidden, System.Windows.Forms.CheckedListBox.CheckedItemCollection lstFolderEx, System.Windows.Forms.CheckedListBox.CheckedItemCollection lstCreatorEx, List<string> lstLocalFiles, bool skipFavorites = false, DateTime dtMaxDate = default)
        {
            varconfig vc = GetVarconfig(_strVAMdir + @"\AddonPackages", lstLocalFiles, null, null, ignoreHidden);
            string[] lstFilePrefs = null;
            if (skipFavorites)
            {
                lstFilePrefs = Directory.GetFiles(_strVAMdir + @"\AddonPackagesFilePrefs", "*.fav", SearchOption.AllDirectories);
            }

            List<typeFilter> lstTypes = new List<typeFilter>();

            foreach (DataGridViewRow row in dgvTypes.Rows)
            {
                var typeFilt = new typeFilter();
                typeFilt.type = row.Cells["Type"].Value.ToString();
                typeFilt.OR = (bool)row.Cells["OR"].Value;
                typeFilt.AND = (bool)row.Cells["AND"].Value;
                typeFilt.NOT = (bool)row.Cells["NOT"].Value;
                lstTypes.Add(typeFilt);
            }

            var backupvars = from v in vc.vars
                             where
                             (
                                (
                                    lstTypes.Any(x => (x.AND || x.NOT)) &&
                                    ((!lstTypes.Any(x => x.type == "Assets" && (x.AND || x.NOT))) || (v.boolAssets && lstTypes.Any(x => x.type == "Assets" && x.AND)) || (!v.boolAssets && lstTypes.Any(x => x.type == "Assets" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Clothing" && (x.AND || x.NOT))) || (v.boolClothing && lstTypes.Any(x => x.type == "Clothing" && x.AND)) || (!v.boolClothing && lstTypes.Any(x => x.type == "Clothing" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Clothing Presets" && (x.AND || x.NOT))) || (v.boolClothingPreset && lstTypes.Any(x => x.type == "Clothing Presets" && x.AND)) || (!v.boolClothingPreset && lstTypes.Any(x => x.type == "Clothing Presets" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Hair" && (x.AND || x.NOT))) || (v.boolHair && lstTypes.Any(x => x.type == "Hair" && x.AND)) || (!v.boolHair && lstTypes.Any(x => x.type == "Hair" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Hair Presets" && (x.AND || x.NOT))) || (v.boolHairPreset && lstTypes.Any(x => x.type == "Hair Presets" && x.AND)) || (!v.boolHairPreset && lstTypes.Any(x => x.type == "Hair Presets" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Looks" && (x.AND || x.NOT))) || ((v.boolLooks || v.boolLookPresets) && lstTypes.Any(x => x.type == "Looks" && x.AND)) || (!(v.boolLooks || v.boolLookPresets) && lstTypes.Any(x => x.type == "Looks" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Morphs" && (x.AND || x.NOT))) || (v.boolMorphs && lstTypes.Any(x => x.type == "Morphs" && x.AND)) || (!v.boolMorphs && lstTypes.Any(x => x.type == "Morphs" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Poses" && (x.AND || x.NOT))) || ((v.boolPoses || v.boolPosePresets) && lstTypes.Any(x => x.type == "Poses" && x.AND)) || (!(v.boolPoses || v.boolPosePresets) && lstTypes.Any(x => x.type == "Poses" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Scenes" && (x.AND || x.NOT))) || (v.boolScenes && lstTypes.Any(x => x.type == "Scenes" && x.AND)) || (!v.boolScenes && lstTypes.Any(x => x.type == "Scenes" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "SubScenes" && (x.AND || x.NOT))) || (v.boolSubScenes && lstTypes.Any(x => x.type == "SubScenes" && x.AND)) || (!v.boolSubScenes && lstTypes.Any(x => x.type == "SubScenes" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Scripts" && (x.AND || x.NOT))) || (v.boolScripts && lstTypes.Any(x => x.type == "Scripts" && x.AND)) || (!v.boolScripts && lstTypes.Any(x => x.type == "Scripts" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Skin Textures" && (x.AND || x.NOT))) || (v.boolTextures && lstTypes.Any(x => x.type == "Skin Textures" && x.AND)) || (!v.boolTextures && lstTypes.Any(x => x.type == "Skin Textures" && x.NOT)))
                                ) ||
                                (
                                    (v.boolAssets && lstTypes.Any(x => x.type == "Assets" && x.OR)) ||
                                    (v.boolClothing && lstTypes.Any(x => x.type == "Clothing" && x.OR)) ||
                                    (v.boolClothingPreset && lstTypes.Any(x => x.type == "Clothing Presets" && x.OR)) ||
                                    (v.boolHair && lstTypes.Any(x => x.type == "Hair" && x.OR)) ||
                                    (v.boolHairPreset && lstTypes.Any(x => x.type == "Hair Presets" && x.OR)) ||
                                    ((v.boolLooks || v.boolLookPresets) && lstTypes.Any(x => x.type == "Looks" && x.OR)) ||
                                    (v.boolMorphs && lstTypes.Any(x => x.type == "Morphs" && x.OR)) ||
                                    ((v.boolPoses || v.boolPosePresets) && lstTypes.Any(x => x.type == "Poses" && x.OR)) ||
                                    (v.boolScenes && lstTypes.Any(x => x.type == "Scenes" && x.OR)) ||
                                    (v.boolSubScenes && lstTypes.Any(x => x.type == "SubScenes" && x.OR)) ||
                                    (v.boolScripts && lstTypes.Any(x => x.type == "Scripts" && x.OR)) ||
                                    (v.boolTextures && lstTypes.Any(x => x.type == "Skin Textures" && x.OR))
                                )
                            ) &&
                                !vc.deps.Contains(v.Name + "." + v.version.ToString(), StringComparer.OrdinalIgnoreCase) &&
                                !(vc.deps.Contains(v.Name + ".latest", StringComparer.OrdinalIgnoreCase) && vc.latestvars.TryGetValue(v.Name, out int intLatestVer) && intLatestVer == v.version) &&
                                ((v.unpacked == false && !lstFolderEx.Contains(Convert.ToString(v.fi.Directory.Name))) || (v.unpacked == true && !lstFolderEx.Contains(Convert.ToString(Directory.GetParent(v.di.FullName).Name)))) &&
                                ((v.unpacked == false && !(lstFolderEx.Contains(@"\root\") && Path.GetDirectoryName(v.fi.FullName) == _strVAMdir + @"\AddonPackages")) || (v.unpacked == true && !(lstFolderEx.Contains(@"\root\") && Directory.GetParent(v.di.FullName).FullName == _strVAMdir + @"\AddonPackages"))) &&
                                !lstCreatorEx.Contains(Convert.ToString(v.creator)) &&
                                (!skipFavorites || (v.unpacked == false && !lstFilePrefs.Any(x => x.Contains(Strings.Left(v.fi.Name, v.fi.Name.Length - 4)))) || (v.unpacked == true && !lstFilePrefs.Any(x => x.Contains(Strings.Left(v.di.Name, v.di.Name.Length - 4))))) &&
                                ((dtMaxDate == default) || (v.unpacked == false && v.fi.LastWriteTime < dtMaxDate) || (v.unpacked == true && v.di.LastWriteTime < dtMaxDate))
                             select v;

            foreach (var f in backupvars)
            {
                if (f.unpacked == false)
                {
                    if (!Directory.Exists(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                    }

                    if (!File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                    {
                        File.Move(Convert.ToString(f.fi.FullName), Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                    }
                }
                else
                {
                    if (!Directory.Exists(Path.GetDirectoryName(f.di.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                    {
                        Directory.Delete(Path.GetDirectoryName(f.di.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                    }

                    Directory.Move(Convert.ToString(f.di.FullName), Convert.ToString(f.di.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                }
            }

            return GetVarCounts();
        }

        public varCounts BackupSpecVars(DataGridView dgvTypes, bool ignoreHidden, bool skipFavorites = false, DateTime dtMaxDate = default)
        {
            varconfig vc = GetVarconfig(_strVAMdir + @"\AddonPackages",null,null,null,ignoreHidden);
            string[] lstFilePrefs = null;
            if (skipFavorites)
            {
                lstFilePrefs = Directory.GetFiles(_strVAMdir + @"\AddonPackagesFilePrefs", "*.fav", SearchOption.AllDirectories);
            }

            List<typeFilter> lstTypes = new List<typeFilter>();

            foreach (DataGridViewRow row in dgvTypes.Rows)
            {
                var typeFilt = new typeFilter();
                typeFilt.type = row.Cells["Type"].Value.ToString();
                typeFilt.OR = (bool)row.Cells["OR"].Value;
                typeFilt.AND = (bool)row.Cells["AND"].Value;
                typeFilt.NOT = (bool)row.Cells["NOT"].Value;
                lstTypes.Add(typeFilt);
            }

            var backupvars = from v in vc.vars
                             where
                             (
                                (
                                    lstTypes.Any(x => (x.AND || x.NOT)) &&
                                    ((!lstTypes.Any(x => x.type == "Assets" && (x.AND || x.NOT))) || (v.boolAssets && lstTypes.Any(x => x.type == "Assets" && x.AND)) || (!v.boolAssets && lstTypes.Any(x => x.type == "Assets" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Clothing" && (x.AND || x.NOT))) || (v.boolClothing && lstTypes.Any(x => x.type == "Clothing" && x.AND)) || (!v.boolClothing && lstTypes.Any(x => x.type == "Clothing" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Clothing Presets" && (x.AND || x.NOT))) || (v.boolClothingPreset && lstTypes.Any(x => x.type == "Clothing Presets" && x.AND)) || (!v.boolClothingPreset && lstTypes.Any(x => x.type == "Clothing Presets" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Hair" && (x.AND || x.NOT))) || (v.boolHair && lstTypes.Any(x => x.type == "Hair" && x.AND)) || (!v.boolHair && lstTypes.Any(x => x.type == "Hair" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Hair Presets" && (x.AND || x.NOT))) || (v.boolHairPreset && lstTypes.Any(x => x.type == "Hair Presets" && x.AND)) || (!v.boolHairPreset && lstTypes.Any(x => x.type == "Hair Presets" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Looks" && (x.AND || x.NOT))) || ((v.boolLooks || v.boolLookPresets) && lstTypes.Any(x => x.type == "Looks" && x.AND)) || (!(v.boolLooks || v.boolLookPresets) && lstTypes.Any(x => x.type == "Looks" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Morphs" && (x.AND || x.NOT))) || (v.boolMorphs && lstTypes.Any(x => x.type == "Morphs" && x.AND)) || (!v.boolMorphs && lstTypes.Any(x => x.type == "Morphs" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Poses" && (x.AND || x.NOT))) || ((v.boolPoses || v.boolPosePresets) && lstTypes.Any(x => x.type == "Poses" && x.AND)) || (!(v.boolPoses || v.boolPosePresets) && lstTypes.Any(x => x.type == "Poses" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Scenes" && (x.AND || x.NOT))) || (v.boolScenes && lstTypes.Any(x => x.type == "Scenes" && x.AND)) || (!v.boolScenes && lstTypes.Any(x => x.type == "Scenes" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "SubScenes" && (x.AND || x.NOT))) || (v.boolSubScenes && lstTypes.Any(x => x.type == "SubScenes" && x.AND)) || (!v.boolSubScenes && lstTypes.Any(x => x.type == "SubScenes" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Scripts" && (x.AND || x.NOT))) || (v.boolScripts && lstTypes.Any(x => x.type == "Scripts" && x.AND)) || (!v.boolScripts && lstTypes.Any(x => x.type == "Scripts" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Skin Textures" && (x.AND || x.NOT))) || (v.boolTextures && lstTypes.Any(x => x.type == "Skin Textures" && x.AND)) || (!v.boolTextures && lstTypes.Any(x => x.type == "Skin Textures" && x.NOT)))
                                ) ||
                                (
                                    (v.boolAssets && lstTypes.Any(x => x.type == "Assets" && x.OR)) ||
                                    (v.boolClothing && lstTypes.Any(x => x.type == "Clothing" && x.OR)) ||
                                    (v.boolClothingPreset && lstTypes.Any(x => x.type == "Clothing Presets" && x.OR)) ||
                                    (v.boolHair && lstTypes.Any(x => x.type == "Hair" && x.OR)) ||
                                    (v.boolHairPreset && lstTypes.Any(x => x.type == "Hair Presets" && x.OR)) ||
                                    ((v.boolLooks || v.boolLookPresets) && lstTypes.Any(x => x.type == "Looks" && x.OR)) ||
                                    (v.boolMorphs && lstTypes.Any(x => x.type == "Morphs" && x.OR)) ||
                                    ((v.boolPoses || v.boolPosePresets) && lstTypes.Any(x => x.type == "Poses" && x.OR)) ||
                                    (v.boolScenes && lstTypes.Any(x => x.type == "Scenes" && x.OR)) ||
                                    (v.boolSubScenes && lstTypes.Any(x => x.type == "SubScenes" && x.OR)) ||
                                    (v.boolScripts && lstTypes.Any(x => x.type == "Scripts" && x.OR)) ||
                                    (v.boolTextures && lstTypes.Any(x => x.type == "Skin Textures" && x.OR))
                                )
                            ) &&
                            (!skipFavorites || (v.unpacked == false && !lstFilePrefs.Any(x => x.Contains(Strings.Left(v.fi.Name, v.fi.Name.Length - 4)))) || (v.unpacked == true && !lstFilePrefs.Any(x => x.Contains(Strings.Left(v.di.Name, v.di.Name.Length - 4))))) &&
                            ((dtMaxDate == default) || (v.unpacked == false && v.fi.LastWriteTime < dtMaxDate) || (v.unpacked == true && v.di.LastWriteTime < dtMaxDate))
                             select v;

            foreach (var f in backupvars)
            {
                if (f.unpacked == false)
                {
                    if (!Directory.Exists(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                    }

                    if (!File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                    {
                        File.Move(Convert.ToString(f.fi.FullName), Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                    }
                }
                else
                {
                    if (!Directory.Exists(Path.GetDirectoryName(f.di.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                    {
                        Directory.Delete(Path.GetDirectoryName(f.di.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                    }

                    Directory.Move(Convert.ToString(f.di.FullName), Convert.ToString(f.di.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                }
            }

            return GetVarCounts();
        }
        public varCounts BackupSpecVarsEx(DataGridView dgvTypes,bool ignoreHidden, System.Windows.Forms.CheckedListBox.CheckedItemCollection lstFolderEx, System.Windows.Forms.CheckedListBox.CheckedItemCollection lstCreatorEx, bool skipFavorites = false, DateTime dtMaxDate = default)
        {
            varconfig vc = GetVarconfig(_strVAMdir + @"\AddonPackages", null, null, null, ignoreHidden);
            string[] lstFilePrefs = null;
            if (skipFavorites)
            {
                lstFilePrefs = Directory.GetFiles(_strVAMdir + @"\AddonPackagesFilePrefs", "*.fav", SearchOption.AllDirectories);
            }

            List<typeFilter> lstTypes = new List<typeFilter>();

            foreach (DataGridViewRow row in dgvTypes.Rows)
            {
                var typeFilt = new typeFilter();
                typeFilt.type = row.Cells["Type"].Value.ToString();
                typeFilt.OR = (bool)row.Cells["OR"].Value;
                typeFilt.AND = (bool)row.Cells["AND"].Value;
                typeFilt.NOT = (bool)row.Cells["NOT"].Value;
                lstTypes.Add(typeFilt);
            }

            var backupvars = from v in vc.vars
                             where
                             (
                                (
                                    lstTypes.Any(x => (x.AND || x.NOT)) &&
                                    ((!lstTypes.Any(x => x.type == "Assets" && (x.AND || x.NOT))) || (v.boolAssets && lstTypes.Any(x => x.type == "Assets" && x.AND)) || (!v.boolAssets && lstTypes.Any(x => x.type == "Assets" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Clothing" && (x.AND || x.NOT))) || (v.boolClothing && lstTypes.Any(x => x.type == "Clothing" && x.AND)) || (!v.boolClothing && lstTypes.Any(x => x.type == "Clothing" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Clothing Presets" && (x.AND || x.NOT))) || (v.boolClothingPreset && lstTypes.Any(x => x.type == "Clothing Presets" && x.AND)) || (!v.boolClothingPreset && lstTypes.Any(x => x.type == "Clothing Presets" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Hair" && (x.AND || x.NOT))) || (v.boolHair && lstTypes.Any(x => x.type == "Hair" && x.AND)) || (!v.boolHair && lstTypes.Any(x => x.type == "Hair" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Hair Presets" && (x.AND || x.NOT))) || (v.boolHairPreset && lstTypes.Any(x => x.type == "Hair Presets" && x.AND)) || (!v.boolHairPreset && lstTypes.Any(x => x.type == "Hair Presets" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Looks" && (x.AND || x.NOT))) || ((v.boolLooks || v.boolLookPresets) && lstTypes.Any(x => x.type == "Looks" && x.AND)) || (!(v.boolLooks || v.boolLookPresets) && lstTypes.Any(x => x.type == "Looks" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Morphs" && (x.AND || x.NOT))) || (v.boolMorphs && lstTypes.Any(x => x.type == "Morphs" && x.AND)) || (!v.boolMorphs && lstTypes.Any(x => x.type == "Morphs" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Poses" && (x.AND || x.NOT))) || ((v.boolPoses || v.boolPosePresets) && lstTypes.Any(x => x.type == "Poses" && x.AND)) || (!(v.boolPoses || v.boolPosePresets) && lstTypes.Any(x => x.type == "Poses" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Scenes" && (x.AND || x.NOT))) || (v.boolScenes && lstTypes.Any(x => x.type == "Scenes" && x.AND)) || (!v.boolScenes && lstTypes.Any(x => x.type == "Scenes" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "SubScenes" && (x.AND || x.NOT))) || (v.boolSubScenes && lstTypes.Any(x => x.type == "SubScenes" && x.AND)) || (!v.boolSubScenes && lstTypes.Any(x => x.type == "SubScenes" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Scripts" && (x.AND || x.NOT))) || (v.boolScripts && lstTypes.Any(x => x.type == "Scripts" && x.AND)) || (!v.boolScripts && lstTypes.Any(x => x.type == "Scripts" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Skin Textures" && (x.AND || x.NOT))) || (v.boolTextures && lstTypes.Any(x => x.type == "Skin Textures" && x.AND)) || (!v.boolTextures && lstTypes.Any(x => x.type == "Skin Textures" && x.NOT)))
                                ) ||
                                (
                                    (v.boolAssets && lstTypes.Any(x => x.type == "Assets" && x.OR)) ||
                                    (v.boolClothing && lstTypes.Any(x => x.type == "Clothing" && x.OR)) ||
                                    (v.boolClothingPreset && lstTypes.Any(x => x.type == "Clothing Presets" && x.OR)) ||
                                    (v.boolHair && lstTypes.Any(x => x.type == "Hair" && x.OR)) ||
                                    (v.boolHairPreset && lstTypes.Any(x => x.type == "Hair Presets" && x.OR)) ||
                                    ((v.boolLooks || v.boolLookPresets) && lstTypes.Any(x => x.type == "Looks" && x.OR)) ||
                                    (v.boolMorphs && lstTypes.Any(x => x.type == "Morphs" && x.OR)) ||
                                    ((v.boolPoses || v.boolPosePresets) && lstTypes.Any(x => x.type == "Poses" && x.OR)) ||
                                    (v.boolScenes && lstTypes.Any(x => x.type == "Scenes" && x.OR)) ||
                                    (v.boolSubScenes && lstTypes.Any(x => x.type == "SubScenes" && x.OR)) ||
                                    (v.boolScripts && lstTypes.Any(x => x.type == "Scripts" && x.OR)) ||
                                    (v.boolTextures && lstTypes.Any(x => x.type == "Skin Textures" && x.OR))
                                )
                            ) &&
                                ((v.unpacked == false && !lstFolderEx.Contains(Convert.ToString(v.fi.Directory.Name))) || (v.unpacked == true && !lstFolderEx.Contains(Convert.ToString(Directory.GetParent(v.di.FullName).Name)))) &&
                                ((v.unpacked == false && !(lstFolderEx.Contains(@"\root\") && Path.GetDirectoryName(v.fi.FullName) == _strVAMdir + @"\AddonPackages")) || (v.unpacked == true && !(lstFolderEx.Contains(@"\root\") && Directory.GetParent(v.di.FullName).FullName == _strVAMdir + @"\AddonPackages"))) &&
                                !lstCreatorEx.Contains(Convert.ToString(v.creator)) &&
                                (!skipFavorites || (v.unpacked == false && !lstFilePrefs.Any(x => x.Contains(Strings.Left(v.fi.Name, v.fi.Name.Length - 4)))) || (v.unpacked == true && !lstFilePrefs.Any(x => x.Contains(Strings.Left(v.di.Name, v.di.Name.Length - 4))))) &&
                                ((dtMaxDate == default) || (v.unpacked == false && v.fi.LastWriteTime < dtMaxDate) || (v.unpacked == true && v.di.LastWriteTime < dtMaxDate))
                             select v;

            foreach (var f in backupvars)
            {
                if (f.unpacked == false)
                {
                    if (!Directory.Exists(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                    }

                    if (!File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                    {
                        File.Move(Convert.ToString(f.fi.FullName), Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                    }
                }
                else
                {
                    if (!Directory.Exists(Path.GetDirectoryName(f.di.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                    {
                        Directory.Delete(Path.GetDirectoryName(f.di.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                    }

                    Directory.Move(Convert.ToString(f.di.FullName), Convert.ToString(f.di.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                }
            }

            return GetVarCounts();
        }

        public varCounts RestoreNeededVars(List<string> lstLocalFiles)
        {
            varconfig vc = GetVarconfig(_strVAMdir + @"\AddonPackages", lstLocalFiles);
            varconfig vcbackup = GetVarconfig(_strVAMbackupdir);
            DirectoryInfo diBackup = new DirectoryInfo(_strVAMbackupdir);
            var neededFiles = new List<FileInfo>();
            var neededDirs = new List<DirectoryInfo>();
            var lstErrorvars = new List<string>();
            bool boolNewDeps;
            bool boolNewFiles;

            foreach (varfile f in vcbackup.vars)
            {
                try
                {
                    if ((vc.deps.Contains(f.Name + "." + f.version.ToString(), StringComparer.OrdinalIgnoreCase) ||
                        ((vc.deps.Contains(f.Name + ".latest", StringComparer.OrdinalIgnoreCase)) &&
                        (!vc.latestvars.ContainsKey(f.Name) && vcbackup.latestvars.TryGetValue(f.Name, out int intLatestVerBackup) && intLatestVerBackup == f.version) ||
                        (vc.latestvars.TryGetValue(f.Name, out int intLatestVer) && vcbackup.latestvars.TryGetValue(f.Name, out int intLatestVerBackup2) && intLatestVerBackup2 == f.version && intLatestVerBackup2 > intLatestVer)
                        ) && ((f.unpacked == false && !File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))) || (f.unpacked == true && !Directory.Exists(Convert.ToString(f.di.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))))
                        ))
                    {
                        if (f.unpacked == false)
                        {
                            neededFiles.Add(f.fi);
                        }
                        else
                        {
                            neededDirs.Add(f.di);
                        }
                    }
                }
                catch
                { lstErrorvars.Add(f.fi.Name); }
            }

            if (neededFiles.Any() || neededDirs.Any())
            {
                
                while (true)
                {
                    varconfig vcNeededFiles = GetVarconfig(_strVAMbackupdir, null, neededFiles, neededDirs);

                    boolNewDeps = false;
                    boolNewFiles = false;

                    foreach (string d in vcNeededFiles.deps)
                    {
                        if (!vc.deps.Contains(d))
                        {
                            boolNewDeps = true;
                            vc.deps.Add(d);
                        }
                    }

                    if (boolNewDeps)
                    {
                        foreach (varfile f in vcbackup.vars)
                        {
                            try
                            {
                                if ((vc.deps.Contains(f.Name + "." + f.version.ToString(), StringComparer.OrdinalIgnoreCase) ||
                                    ((vc.deps.Contains(f.Name + ".latest", StringComparer.OrdinalIgnoreCase)) &&
                                    (!vc.latestvars.ContainsKey(f.Name) && vcbackup.latestvars.TryGetValue(f.Name, out int intLatestVerBackup) && intLatestVerBackup == f.version) ||
                                    (vc.latestvars.TryGetValue(f.Name, out int intLatestVer) && vcbackup.latestvars.TryGetValue(f.Name, out int intLatestVerBackup2) && intLatestVerBackup2 == f.version && intLatestVerBackup2 > intLatestVer)
                                    ) 
                                    && !neededFiles.Any(x => x.FullName == f.fi.FullName)
                                    && ((f.unpacked == false && !File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))) || (f.unpacked == true && !Directory.Exists(Convert.ToString(f.di.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))))))
                                {
                                    if (f.unpacked == false)
                                    {
                                        boolNewFiles = true;
                                        neededFiles.Add(f.fi);
                                    }
                                    else
                                    {
                                        boolNewFiles = true;
                                        neededDirs.Add(f.di);
                                    }
                                }
                            }
                            catch
                            { lstErrorvars.Add(f.fi.Name); }
                        }
                        if (!boolNewFiles)
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                    
                foreach (FileInfo f in neededFiles)
                {

                    if (!Directory.Exists(Path.GetDirectoryName(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")));
                    }

                    if (!File.Exists(Convert.ToString(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))) 
                    { 
                        File.Move(Convert.ToString(f.FullName), Convert.ToString(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))); 
                    }
                }

                foreach (DirectoryInfo d in neededDirs)
                {

                    if (!Directory.Exists(d.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))
                    {
                        Directory.Move(d.FullName, d.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"));
                    }
                }

            }

            //MessageBox.Show("Please manually remove file from VAM/backup folders:" + Environment.NewLine + f.Name, "Skipping Restore file, incorrect .var file naming format.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return GetVarCounts();
        }

        public varCounts RestoreNeededVarsEx(List<string> lstLocalFiles, System.Windows.Forms.CheckedListBox.CheckedItemCollection lstFolderEx, System.Windows.Forms.CheckedListBox.CheckedItemCollection lstCreatorEx)
        {
            varconfig vc = GetVarconfig(_strVAMdir + @"\AddonPackages", lstLocalFiles);
            varconfig vcbackup = GetVarconfig(_strVAMbackupdir);
            DirectoryInfo diBackup = new DirectoryInfo(_strVAMbackupdir);
            var neededFiles = new List<FileInfo>();
            var neededDirs = new List<DirectoryInfo>();
            var lstErrorvars = new List<string>();
            bool boolNewDeps;
            bool boolNewFiles;

            var backupvars = from v in vcbackup.vars
                             where
                                ((v.unpacked == false && !lstFolderEx.Contains(Convert.ToString(v.fi.Directory.Name))) || (v.unpacked == true && !lstFolderEx.Contains(Convert.ToString(Directory.GetParent(v.di.FullName).Name)))) &&
                                ((v.unpacked == false && !(lstFolderEx.Contains(@"\root\") && Path.GetDirectoryName(v.fi.FullName) == _strVAMdir + @"\AddonPackages")) || (v.unpacked == true && !(lstFolderEx.Contains(@"\root\") && Directory.GetParent(v.di.FullName).FullName == _strVAMdir + @"\AddonPackages"))) &&
                                !lstCreatorEx.Contains(Convert.ToString(v.creator))
                             select v;

            foreach (varfile f in backupvars)
            {
                try
                {
                    if ((vc.deps.Contains(f.Name + "." + f.version.ToString(), StringComparer.OrdinalIgnoreCase) ||
                        ((vc.deps.Contains(f.Name + ".latest", StringComparer.OrdinalIgnoreCase)) &&
                        (!vc.latestvars.ContainsKey(f.Name) && vcbackup.latestvars.TryGetValue(f.Name, out int intLatestVerBackup) && intLatestVerBackup == f.version) ||
                        (vc.latestvars.TryGetValue(f.Name, out int intLatestVer) && vcbackup.latestvars.TryGetValue(f.Name, out int intLatestVerBackup2) && intLatestVerBackup2 == f.version && intLatestVerBackup2 > intLatestVer)
                        ) && ((f.unpacked == false && !File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))) || (f.unpacked == true && !Directory.Exists(Convert.ToString(f.di.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))))
                        ))
                    {
                        if (f.unpacked == false)
                        {
                            neededFiles.Add(f.fi);
                        }
                        else
                        {
                            neededDirs.Add(f.di);
                        }
                    }
                }
                catch
                { lstErrorvars.Add(f.fi.Name); }
            }

            if (neededFiles.Any() || neededDirs.Any())
            {

                while (true)
                {
                    varconfig vcNeededFiles = GetVarconfig(_strVAMbackupdir, null, neededFiles, neededDirs);

                    boolNewDeps = false;
                    boolNewFiles = false;

                    foreach (string d in vcNeededFiles.deps)
                    {
                        if (!vc.deps.Contains(d))
                        {
                            boolNewDeps = true;
                            vc.deps.Add(d);
                        }
                    }

                    if (boolNewDeps)
                    {
                        foreach (varfile f in vcbackup.vars)
                        {
                            try
                            {
                                if ((vc.deps.Contains(f.Name + "." + f.version.ToString(), StringComparer.OrdinalIgnoreCase) ||
                                    ((vc.deps.Contains(f.Name + ".latest", StringComparer.OrdinalIgnoreCase)) &&
                                    (!vc.latestvars.ContainsKey(f.Name) && vcbackup.latestvars.TryGetValue(f.Name, out int intLatestVerBackup) && intLatestVerBackup == f.version) ||
                                    (vc.latestvars.TryGetValue(f.Name, out int intLatestVer) && vcbackup.latestvars.TryGetValue(f.Name, out int intLatestVerBackup2) && intLatestVerBackup2 == f.version && intLatestVerBackup2 > intLatestVer)
                                    )
                                    && !neededFiles.Any(x => x.FullName == f.fi.FullName)
                                    && ((f.unpacked == false && !File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))) || (f.unpacked == true && !Directory.Exists(Convert.ToString(f.di.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))))))
                                {
                                    if (f.unpacked == false)
                                    {
                                        boolNewFiles = true;
                                        neededFiles.Add(f.fi);
                                    }
                                    else
                                    {
                                        boolNewFiles = true;
                                        neededDirs.Add(f.di);
                                    }
                                }
                            }
                            catch
                            { lstErrorvars.Add(f.fi.Name); }
                        }
                        if (!boolNewFiles)
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                foreach (FileInfo f in neededFiles)
                {

                    if (!Directory.Exists(Path.GetDirectoryName(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")));
                    }

                    if (!File.Exists(Convert.ToString(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))))
                    {
                        File.Move(Convert.ToString(f.FullName), Convert.ToString(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")));
                    }
                }

                foreach (DirectoryInfo d in neededDirs)
                {

                    if (!Directory.Exists(d.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))
                    {
                        Directory.Move(d.FullName, d.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"));
                    }
                }

            }

            //MessageBox.Show("Please manually remove file from VAM/backup folders:" + Environment.NewLine + f.Name, "Skipping Restore file, incorrect .var file naming format.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return GetVarCounts();
        }

        public varCounts RestoreNeededVarsOld(List<string> lstLocalFiles)
        {
            varconfig vc = GetVarconfig(_strVAMdir + @"\AddonPackages", lstLocalFiles);
            varconfig vcbackup = GetVarconfig(_strVAMbackupdir);
            DirectoryInfo diBackup = new DirectoryInfo(_strVAMbackupdir);
            var neededFiles = new List<FileInfo>();
            var lstErrorvars = new List<string>();

            //IEnumerable<FileInfo> neededFiles;
            //neededFiles = diBackup
            //    .GetFiles("*.var", SearchOption.AllDirectories)
            //    .Where(file => vc.deps.Contains(file.Name.Replace(".var", "").Substring(0, file.Name.Replace(".var", "").LastIndexOf(".")), StringComparer.OrdinalIgnoreCase));

            foreach (varfile f in vcbackup.vars)
            {
                try
                {
                    if ((vc.deps.Contains(f.Name + "." + f.version.ToString(), StringComparer.OrdinalIgnoreCase) || 
                        ((vc.deps.Contains(f.Name + ".latest", StringComparer.OrdinalIgnoreCase)) && 
                        (!vc.latestvars.ContainsKey(f.Name) && vcbackup.latestvars.TryGetValue(f.Name, out int intLatestVerBackup) && intLatestVerBackup == f.version) ||
                        (vc.latestvars.TryGetValue(f.Name, out int intLatestVer) && vcbackup.latestvars.TryGetValue(f.Name, out int intLatestVerBackup2) && intLatestVerBackup2 == f.version && intLatestVerBackup2 > intLatestVer)
                        ) && !File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))))
                    {
                        neededFiles.Add(f.fi);
                    }
                }
                catch
                { lstErrorvars.Add(f.fi.Name); }
            }

            while (neededFiles.Count() > 0)
            {
                foreach (FileInfo f in neededFiles)
                {

                    if (!Directory.Exists(Path.GetDirectoryName(f.FullName.Replace( _strVAMbackupdir, _strVAMdir + @"\AddonPackages"))))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")));
                    }

                    if (!File.Exists(Convert.ToString(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))) { File.Move(Convert.ToString(f.FullName), Convert.ToString(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))); }
                }

                vc = GetVarconfig(_strVAMdir + @"\AddonPackages", lstLocalFiles);
                vcbackup = GetVarconfig(_strVAMbackupdir, new List<string>());
                neededFiles = new List<FileInfo>();

                foreach (varfile f in vcbackup.vars)
                {
                    try
                    {
                        if ((vc.deps.Contains(f.Name + "." + f.version.ToString(), StringComparer.OrdinalIgnoreCase) ||
                            ((vc.deps.Contains(f.Name + ".latest", StringComparer.OrdinalIgnoreCase)) &&
                            (!vc.latestvars.ContainsKey(f.Name) && vcbackup.latestvars.TryGetValue(f.Name, out int intLatestVerBackup) && intLatestVerBackup == f.version) ||
                            (vc.latestvars.TryGetValue(f.Name, out int intLatestVer) && vcbackup.latestvars.TryGetValue(f.Name, out int intLatestVerBackup2) && intLatestVerBackup2 == f.version && intLatestVerBackup2 > intLatestVer)
                            ) && !File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))))
                        {
                            neededFiles.Add(f.fi); 
                        }
                    }
                    catch
                    { lstErrorvars.Add(f.fi.Name); }
                }
            }

            //MessageBox.Show("Please manually remove file from VAM/backup folders:" + Environment.NewLine + f.Name, "Skipping Restore file, incorrect .var file naming format.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return GetVarCounts();
        }

        public varCounts RestoreNeededVarsExOld(List<string> lstLocalFiles, System.Windows.Forms.CheckedListBox.CheckedItemCollection lstFolderEx, System.Windows.Forms.CheckedListBox.CheckedItemCollection lstCreatorEx)
        {
            varconfig vc = GetVarconfig(_strVAMdir + @"\AddonPackages", lstLocalFiles);
            varconfig vcbackup = GetVarconfig(_strVAMbackupdir);
            DirectoryInfo diBackup = new DirectoryInfo(_strVAMbackupdir);
            var neededFiles = new List<FileInfo>();
            var lstErrorvars = new List<string>();

            //IEnumerable<FileInfo> neededFiles;
            //neededFiles = diBackup
            //    .GetFiles("*.var", SearchOption.AllDirectories)
            //    .Where(file => vc.deps.Contains(file.Name.Replace(".var", "").Substring(0, file.Name.Replace(".var", "").LastIndexOf(".")), StringComparer.OrdinalIgnoreCase));

            var backupvars = from v in vcbackup.vars
                             where
                                !lstFolderEx.Contains(Convert.ToString(v.fi.Directory.Name)) &&
                                !(lstFolderEx.Contains(@"\root\") && Path.GetDirectoryName(v.fi.FullName) == _strVAMbackupdir) &&
                                !lstCreatorEx.Contains(Convert.ToString(v.creator))
                             select v;

            foreach (varfile f in backupvars)
            {
                try
                {
                    if ((vc.deps.Contains(f.Name + "." + f.version.ToString(), StringComparer.OrdinalIgnoreCase) ||
                            ((vc.deps.Contains(f.Name + ".latest", StringComparer.OrdinalIgnoreCase) && vcbackup.latestvars.TryGetValue(f.Name, out int intLatestVer) && intLatestVer == f.version))) &&
                            !File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))))
                    {
                        neededFiles.Add(f.fi);
                    }
                }
                catch
                { lstErrorvars.Add(f.fi.Name); }
            }

            while (neededFiles.Count() > 0)
            {
                foreach (FileInfo f in neededFiles)
                {

                    if (!Directory.Exists(Path.GetDirectoryName(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")));
                    }

                    if (!File.Exists(Convert.ToString(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))) { File.Move(Convert.ToString(f.FullName), Convert.ToString(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))); }
                }

                vc = GetVarconfig(_strVAMdir + @"\AddonPackages", lstLocalFiles);
                vcbackup = GetVarconfig(_strVAMbackupdir, new List<string>());
                neededFiles = new List<FileInfo>();

                backupvars = from v in vcbackup.vars
                             where
                             !lstFolderEx.Contains(Convert.ToString(v.fi.Directory.Name)) &&
                             !(lstFolderEx.Contains(@"\root\") && Path.GetDirectoryName(v.fi.FullName) == _strVAMbackupdir) &&
                             !lstCreatorEx.Contains(Convert.ToString(v.creator))
                             select v;

                foreach (varfile f in backupvars)
                {
                    try
                    {
                        if ((vc.deps.Contains(f.Name + "." + f.version.ToString(), StringComparer.OrdinalIgnoreCase) ||
                            ((vc.deps.Contains(f.Name + ".latest", StringComparer.OrdinalIgnoreCase) && vcbackup.latestvars.TryGetValue(f.Name, out int intLatestVer) && intLatestVer == f.version))) &&
                            !File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))))
                        {
                            neededFiles.Add(f.fi);
                        }
                    }
                    catch
                    { lstErrorvars.Add(f.fi.Name); }
                }
            }

            //MessageBox.Show("Please manually remove file from VAM/backup folders:" + Environment.NewLine + f.Name, "Skipping Restore file, incorrect .var file naming format.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return GetVarCounts();
        }

        public varCounts RestoreSpecificVars(DataGridView dgvTypes, bool ignoreHidden)
        {
            varconfig vc = GetVarconfig(_strVAMbackupdir, null, null, null, ignoreHidden);

            List<typeFilter> lstTypes = new List<typeFilter>();

            foreach (DataGridViewRow row in dgvTypes.Rows)
            {
                var typeFilt = new typeFilter();
                typeFilt.type = row.Cells["Type"].Value.ToString();
                typeFilt.OR = (bool)row.Cells["OR"].Value;
                typeFilt.AND = (bool)row.Cells["AND"].Value;
                typeFilt.NOT = (bool)row.Cells["NOT"].Value;
                lstTypes.Add(typeFilt);
            }

            var backupvars = from v in vc.vars
                             where
                             (
                                (
                                    lstTypes.Any(x => (x.AND || x.NOT)) &&
                                    ((!lstTypes.Any(x => x.type == "Assets" && (x.AND || x.NOT))) || (v.boolAssets && lstTypes.Any(x => x.type == "Assets" && x.AND)) || (!v.boolAssets && lstTypes.Any(x => x.type == "Assets" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Clothing" && (x.AND || x.NOT))) || (v.boolClothing && lstTypes.Any(x => x.type == "Clothing" && x.AND)) || (!v.boolClothing && lstTypes.Any(x => x.type == "Clothing" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Clothing Presets" && (x.AND || x.NOT))) || (v.boolClothingPreset && lstTypes.Any(x => x.type == "Clothing Presets" && x.AND)) || (!v.boolClothingPreset && lstTypes.Any(x => x.type == "Clothing Presets" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Hair" && (x.AND || x.NOT))) || (v.boolHair && lstTypes.Any(x => x.type == "Hair" && x.AND)) || (!v.boolHair && lstTypes.Any(x => x.type == "Hair" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Hair Presets" && (x.AND || x.NOT))) || (v.boolHairPreset && lstTypes.Any(x => x.type == "Hair Presets" && x.AND)) || (!v.boolHairPreset && lstTypes.Any(x => x.type == "Hair Presets" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Looks" && (x.AND || x.NOT))) || ((v.boolLooks || v.boolLookPresets) && lstTypes.Any(x => x.type == "Looks" && x.AND)) || (!(v.boolLooks || v.boolLookPresets) && lstTypes.Any(x => x.type == "Looks" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Morphs" && (x.AND || x.NOT))) || (v.boolMorphs && lstTypes.Any(x => x.type == "Morphs" && x.AND)) || (!v.boolMorphs && lstTypes.Any(x => x.type == "Morphs" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Poses" && (x.AND || x.NOT))) || ((v.boolPoses || v.boolPosePresets) && lstTypes.Any(x => x.type == "Poses" && x.AND)) || (!(v.boolPoses || v.boolPosePresets) && lstTypes.Any(x => x.type == "Poses" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Scenes" && (x.AND || x.NOT))) || (v.boolScenes && lstTypes.Any(x => x.type == "Scenes" && x.AND)) || (!v.boolScenes && lstTypes.Any(x => x.type == "Scenes" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "SubScenes" && (x.AND || x.NOT))) || (v.boolSubScenes && lstTypes.Any(x => x.type == "SubScenes" && x.AND)) || (!v.boolSubScenes && lstTypes.Any(x => x.type == "SubScenes" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Scripts" && (x.AND || x.NOT))) || (v.boolScripts && lstTypes.Any(x => x.type == "Scripts" && x.AND)) || (!v.boolScripts && lstTypes.Any(x => x.type == "Scripts" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Skin Textures" && (x.AND || x.NOT))) || (v.boolTextures && lstTypes.Any(x => x.type == "Skin Textures" && x.AND)) || (!v.boolTextures && lstTypes.Any(x => x.type == "Skin Textures" && x.NOT)))
                                ) ||
                                (
                                    (v.boolAssets && lstTypes.Any(x => x.type == "Assets" && x.OR)) ||
                                    (v.boolClothing && lstTypes.Any(x => x.type == "Clothing" && x.OR)) ||
                                    (v.boolClothingPreset && lstTypes.Any(x => x.type == "Clothing Presets" && x.OR)) ||
                                    (v.boolHair && lstTypes.Any(x => x.type == "Hair" && x.OR)) ||
                                    (v.boolHairPreset && lstTypes.Any(x => x.type == "Hair Presets" && x.OR)) ||
                                    ((v.boolLooks || v.boolLookPresets) && lstTypes.Any(x => x.type == "Looks" && x.OR)) ||
                                    (v.boolMorphs && lstTypes.Any(x => x.type == "Morphs" && x.OR)) ||
                                    ((v.boolPoses || v.boolPosePresets) && lstTypes.Any(x => x.type == "Poses" && x.OR)) ||
                                    (v.boolScenes && lstTypes.Any(x => x.type == "Scenes" && x.OR)) ||
                                    (v.boolSubScenes && lstTypes.Any(x => x.type == "SubScenes" && x.OR)) ||
                                    (v.boolScripts && lstTypes.Any(x => x.type == "Scripts" && x.OR)) ||
                                    (v.boolTextures && lstTypes.Any(x => x.type == "Skin Textures" && x.OR))
                                )
                            )
                             select v;

            foreach (var f in backupvars)
            {
                if (f.unpacked == false)
                {
                    if (!Directory.Exists(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")));
                    }

                    if (!File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))) { File.Move(Convert.ToString(f.fi.FullName), Convert.ToString(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))); }
                }
                else
                {
                    if (!Directory.Exists(f.di.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))
                    {
                        Directory.Move(f.di.FullName, f.di.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"));
                    }
                }
            }

            return GetVarCounts();
        }

        public varCounts RestoreSpecificVarsEx(DataGridView dgvTypes, bool ignoreHidden, System.Windows.Forms.CheckedListBox.CheckedItemCollection lstFolderEx, System.Windows.Forms.CheckedListBox.CheckedItemCollection lstCreatorEx)
        {
            varconfig vc = GetVarconfig(_strVAMbackupdir, null, null, null, ignoreHidden);

            List<typeFilter> lstTypes = new List<typeFilter>();

            foreach (DataGridViewRow row in dgvTypes.Rows)
            {
                var typeFilt = new typeFilter();
                typeFilt.type = row.Cells["Type"].Value.ToString();
                typeFilt.OR = (bool)row.Cells["OR"].Value;
                typeFilt.AND = (bool)row.Cells["AND"].Value;
                typeFilt.NOT = (bool)row.Cells["NOT"].Value;
                lstTypes.Add(typeFilt);
            }

            var backupvars = from v in vc.vars
                             where
                             (
                                (
                                    lstTypes.Any(x => (x.AND || x.NOT)) &&
                                    ((!lstTypes.Any(x => x.type == "Assets" && (x.AND || x.NOT))) || (v.boolAssets && lstTypes.Any(x => x.type == "Assets" && x.AND)) || (!v.boolAssets && lstTypes.Any(x => x.type == "Assets" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Clothing" && (x.AND || x.NOT))) || (v.boolClothing && lstTypes.Any(x => x.type == "Clothing" && x.AND)) || (!v.boolClothing && lstTypes.Any(x => x.type == "Clothing" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Clothing Presets" && (x.AND || x.NOT))) || (v.boolClothingPreset && lstTypes.Any(x => x.type == "Clothing Presets" && x.AND)) || (!v.boolClothingPreset && lstTypes.Any(x => x.type == "Clothing Presets" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Hair" && (x.AND || x.NOT))) || (v.boolHair && lstTypes.Any(x => x.type == "Hair" && x.AND)) || (!v.boolHair && lstTypes.Any(x => x.type == "Hair" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Hair Presets" && (x.AND || x.NOT))) || (v.boolHairPreset && lstTypes.Any(x => x.type == "Hair Presets" && x.AND)) || (!v.boolHairPreset && lstTypes.Any(x => x.type == "Hair Presets" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Looks" && (x.AND || x.NOT))) || ((v.boolLooks || v.boolLookPresets) && lstTypes.Any(x => x.type == "Looks" && x.AND)) || (!(v.boolLooks || v.boolLookPresets) && lstTypes.Any(x => x.type == "Looks" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Morphs" && (x.AND || x.NOT))) || (v.boolMorphs && lstTypes.Any(x => x.type == "Morphs" && x.AND)) || (!v.boolMorphs && lstTypes.Any(x => x.type == "Morphs" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Poses" && (x.AND || x.NOT))) || ((v.boolPoses || v.boolPosePresets) && lstTypes.Any(x => x.type == "Poses" && x.AND)) || (!(v.boolPoses || v.boolPosePresets) && lstTypes.Any(x => x.type == "Poses" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Scenes" && (x.AND || x.NOT))) || (v.boolScenes && lstTypes.Any(x => x.type == "Scenes" && x.AND)) || (!v.boolScenes && lstTypes.Any(x => x.type == "Scenes" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "SubScenes" && (x.AND || x.NOT))) || (v.boolSubScenes && lstTypes.Any(x => x.type == "SubScenes" && x.AND)) || (!v.boolSubScenes && lstTypes.Any(x => x.type == "SubScenes" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Scripts" && (x.AND || x.NOT))) || (v.boolScripts && lstTypes.Any(x => x.type == "Scripts" && x.AND)) || (!v.boolScripts && lstTypes.Any(x => x.type == "Scripts" && x.NOT))) &&
                                    ((!lstTypes.Any(x => x.type == "Skin Textures" && (x.AND || x.NOT))) || (v.boolTextures && lstTypes.Any(x => x.type == "Skin Textures" && x.AND)) || (!v.boolTextures && lstTypes.Any(x => x.type == "Skin Textures" && x.NOT)))
                                ) ||
                                (
                                    (v.boolAssets && lstTypes.Any(x => x.type == "Assets" && x.OR)) ||
                                    (v.boolClothing && lstTypes.Any(x => x.type == "Clothing" && x.OR)) ||
                                    (v.boolClothingPreset && lstTypes.Any(x => x.type == "Clothing Presets" && x.OR)) ||
                                    (v.boolHair && lstTypes.Any(x => x.type == "Hair" && x.OR)) ||
                                    (v.boolHairPreset && lstTypes.Any(x => x.type == "Hair Presets" && x.OR)) ||
                                    ((v.boolLooks || v.boolLookPresets) && lstTypes.Any(x => x.type == "Looks" && x.OR)) ||
                                    (v.boolMorphs && lstTypes.Any(x => x.type == "Morphs" && x.OR)) ||
                                    ((v.boolPoses || v.boolPosePresets) && lstTypes.Any(x => x.type == "Poses" && x.OR)) ||
                                    (v.boolScenes && lstTypes.Any(x => x.type == "Scenes" && x.OR)) ||
                                    (v.boolSubScenes && lstTypes.Any(x => x.type == "SubScenes" && x.OR)) ||
                                    (v.boolScripts && lstTypes.Any(x => x.type == "Scripts" && x.OR)) ||
                                    (v.boolTextures && lstTypes.Any(x => x.type == "Skin Textures" && x.OR))
                                )
                            ) &&
                            ((v.unpacked == false && !lstFolderEx.Contains(Convert.ToString(v.fi.Directory.Name))) || (v.unpacked == true && !lstFolderEx.Contains(Convert.ToString(Directory.GetParent(v.di.FullName).Name)))) &&
                            ((v.unpacked == false && !(lstFolderEx.Contains(@"\root\") && Path.GetDirectoryName(v.fi.FullName) == _strVAMdir + @"\AddonPackages")) || (v.unpacked == true && !(lstFolderEx.Contains(@"\root\") && Directory.GetParent(v.di.FullName).FullName == _strVAMdir + @"\AddonPackages"))) &&
                            !lstCreatorEx.Contains(Convert.ToString(v.creator))
                             select v;

            foreach (var f in backupvars)
            {

                if (f.unpacked == false)
                {
                    if (!Directory.Exists(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")));
                    }

                    if (!File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))) { File.Move(Convert.ToString(f.fi.FullName), Convert.ToString(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))); }
                }
                else
                {
                    if (!Directory.Exists(f.di.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))
                    {
                        Directory.Move(f.di.FullName, f.di.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"));
                    }
                }

            }

            return GetVarCounts();
        }

        public varCounts RestoreAllvars()
        {
            DirectoryInfo diBackup = new DirectoryInfo(_strVAMbackupdir);

            foreach (FileInfo f in diBackup.GetFiles("*.var", SearchOption.AllDirectories))
            {
                if (!Directory.Exists(Path.GetDirectoryName(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")));
                }

                if (!File.Exists(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))){ File.Move(f.FullName, f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"), false); }
            }

            foreach (DirectoryInfo d in diBackup.GetDirectories("*.var", SearchOption.AllDirectories))
            {
                if (!Directory.Exists(d.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))
                {
                    Directory.Move(d.FullName,d.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"));
                }
            }

            return GetVarCounts();
        }

        public varCounts RestoreAllvarsEx(System.Windows.Forms.CheckedListBox.CheckedItemCollection lstFolderEx, System.Windows.Forms.CheckedListBox.CheckedItemCollection lstCreatorEx)
        {
            varconfig vc = GetVarconfig(_strVAMbackupdir);

            var backupvars = from v in vc.vars
                             where
                             ((v.unpacked == false && !lstFolderEx.Contains(Convert.ToString(v.fi.Directory.Name))) || (v.unpacked == true && !lstFolderEx.Contains(Convert.ToString(Directory.GetParent(v.di.FullName).Name)))) &&
                             ((v.unpacked == false && !(lstFolderEx.Contains(@"\root\") && Path.GetDirectoryName(v.fi.FullName) == _strVAMdir + @"\AddonPackages")) || (v.unpacked == true && !(lstFolderEx.Contains(@"\root\") && Directory.GetParent(v.di.FullName).FullName == _strVAMdir + @"\AddonPackages"))) &&
                             !lstCreatorEx.Contains(Convert.ToString(v.creator))
                             select v;

            foreach (var f in backupvars)
            {
                if (f.unpacked == false)
                {
                    if (!Directory.Exists(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")));
                    }

                    if (!File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))) { File.Move(Convert.ToString(f.fi.FullName), Convert.ToString(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))); }
                }
                else
                {
                    if (!Directory.Exists(f.di.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))
                    {
                        Directory.Move(f.di.FullName, f.di.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"));
                    }
                }
            }

            return GetVarCounts();
        }

        public varCounts MoveOldVarVersions()
        {
            string strOldVarDirectory = _strVAMdir + @"\_oldvars";
            varconfig vc = GetVarconfig(_strVAMdir + @"\AddonPackages");
            varconfig vcbackup = GetVarconfig(_strVAMbackupdir);
            int countMoved = 0;

            var oldvars = from v in vc.vars
                          where
                          (vc.latestvars.TryGetValue(v.Name, out int intLatestVer) && intLatestVer != v.version) &&
                          !vc.deps.Contains(v.Name + "." + v.version.ToString(), StringComparer.OrdinalIgnoreCase) &&
                          !vcbackup.deps.Contains(v.Name + "." + v.version.ToString(), StringComparer.OrdinalIgnoreCase) &&
                          v.creator != "LO"
                          select v;

            foreach (var f in oldvars)
            {

                if (!Directory.Exists(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", strOldVarDirectory))))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", strOldVarDirectory)));
                }

                if (!File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", strOldVarDirectory)))) 
                { 
                    File.Move(Convert.ToString(f.fi.FullName), Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", strOldVarDirectory)));
                    countMoved += 1;
                }
            }

            return GetVarCounts(countMoved);
        }


        public List<string> getActiveVarConfig()
        {
            DirectoryInfo diVam = new DirectoryInfo(_strVAMdir + @"\AddonPackages");

            var activefiles = from f in diVam.GetFiles("*.var", SearchOption.AllDirectories)
                              orderby f.Name
                              select f.Name;

            var activedirs = from d in diVam.GetDirectories("*.var", SearchOption.AllDirectories)
                             orderby d.Name
                             select d.Name;

            var activevars = activefiles.Concat(activedirs).OrderBy(x => x).ToList<string>();

            return activevars;
        }

        public void SaveVarConfig(string strFileName)
        {
            DirectoryInfo diVam = new DirectoryInfo(_strVAMdir + @"\AddonPackages");

            var activefiles = from f in diVam.GetFiles("*.var", SearchOption.AllDirectories)
                              orderby f.Name
                              select f;

            var activedirs = from f in diVam.GetDirectories("*.var", SearchOption.AllDirectories)
                             orderby f.Name
                             select f;

            StreamWriter sw = new StreamWriter(strFileName);

            foreach (FileInfo f in activefiles)
            {
                sw.WriteLine(f.Name);
            }

            foreach (DirectoryInfo d in activedirs)
            {
                sw.WriteLine(d.Name);
            }

            sw.Close();
            sw.Dispose();
        }

        public varCounts RestoreVarConfig(string strFileName)
        {
            var activevarconfig = File.ReadLines(strFileName);

            DirectoryInfo diVam = new DirectoryInfo(_strVAMdir + @"\AddonPackages");
            DirectoryInfo diBackup = new DirectoryInfo(_strVAMbackupdir);

            var varsToBackup = from f in diVam.GetFiles("*.var", SearchOption.AllDirectories)
                               where !activevarconfig.Contains(f.Name)
                               select f;
            
            var varsToRestore = from f in diBackup.GetFiles("*.var", SearchOption.AllDirectories)
                                where activevarconfig.Contains(f.Name)
                                select f;

            foreach (var f in varsToBackup)
            {
                if (!Directory.Exists(Path.GetDirectoryName(f.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(f.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                }

                if (!File.Exists(Convert.ToString(f.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                {
                    File.Move(Convert.ToString(f.FullName), Convert.ToString(f.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                }
            }

            foreach (var f in varsToRestore)
            {
                if (!Directory.Exists(Path.GetDirectoryName(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")));
                }

                if (!File.Exists(Convert.ToString(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))))
                {
                    File.Move(Convert.ToString(f.FullName), Convert.ToString(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")));
                }
            }

            var dirsToBackup = from d in diVam.GetDirectories("*.var", SearchOption.AllDirectories)
                               where !activevarconfig.Contains(d.Name)
                               select d;

            var dirsToRestore = from d in diBackup.GetDirectories("*.var", SearchOption.AllDirectories)
                                where activevarconfig.Contains(d.Name)
                                select d;

            foreach (var d in dirsToBackup)
            {
                if (!Directory.Exists(d.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)))
                {
                    Directory.Move(d.FullName, d.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir));
                }
            }

            foreach (var d in dirsToRestore)
            {
                if (!Directory.Exists(d.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))
                {
                    Directory.Move(d.FullName,d.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"));
                }
            }

            return GetVarCounts();
        }

        public varCounts restoreLastVarConfig(System.Collections.Specialized.StringCollection lstLastActiveVars)
        {

            DirectoryInfo diVam = new DirectoryInfo(_strVAMdir + @"\AddonPackages");
            DirectoryInfo diBackup = new DirectoryInfo(_strVAMbackupdir);

            var varsToBackup = from f in diVam.GetFiles("*.var", SearchOption.AllDirectories)
                               where !lstLastActiveVars.Contains(f.Name)
                               select f;

            var varsToRestore = from f in diBackup.GetFiles("*.var", SearchOption.AllDirectories)
                                where lstLastActiveVars.Contains(f.Name)
                                select f;

            foreach (var f in varsToBackup)
            {
                if (!Directory.Exists(Path.GetDirectoryName(f.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(f.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                }

                if (!File.Exists(Convert.ToString(f.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                {
                    File.Move(Convert.ToString(f.FullName), Convert.ToString(f.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                }
            }

            foreach (var f in varsToRestore)
            {
                if (!Directory.Exists(Path.GetDirectoryName(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")));
                }

                if (!File.Exists(Convert.ToString(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))))
                {
                    File.Move(Convert.ToString(f.FullName), Convert.ToString(f.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")));
                }
            }

            var dirsToBackup = from d in diVam.GetDirectories("*.var", SearchOption.AllDirectories)
                               where !lstLastActiveVars.Contains(d.Name)
                               select d;

            var dirsToRestore = from d in diBackup.GetDirectories("*.var", SearchOption.AllDirectories)
                                where lstLastActiveVars.Contains(d.Name)
                                select d;

            foreach (var d in dirsToBackup)
            {
                if (!Directory.Exists(d.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)))
                {
                    Directory.Move(d.FullName, d.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir));
                }
            }

            foreach (var d in dirsToRestore)
            {
                if (!Directory.Exists(d.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))
                {
                    Directory.Move(d.FullName, d.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"));
                }
            }

            return GetVarCounts();
        }

        public varCounts GetVarCounts(int intOldVarVersionsMoved = 0)
        {
            varCounts vcount = new varCounts();
            vcount.countVAMvars = Directory.GetFiles(_strVAMdir + @"\AddonPackages", "*.var", SearchOption.AllDirectories).Count();
            vcount.countVAMvars += Directory.GetDirectories(_strVAMdir + @"\AddonPackages", "*.var", SearchOption.AllDirectories).Count();
            vcount.countBackupvars = Directory.GetFiles(_strVAMbackupdir, "*.var", SearchOption.AllDirectories).Count();
            vcount.countBackupvars += Directory.GetDirectories(_strVAMbackupdir, "*.var", SearchOption.AllDirectories).Count();
            vcount.countOldvars = intOldVarVersionsMoved;
            return vcount;
        }

        public int DisablePreloadMorphs()
        {
            varconfig vc = GetVarconfig(_strVAMdir + @"\AddonPackages");
            string strFileuserpref;
            string strUserPrefContents;
            string strLine;
            bool boolOverwrite;

            var morphvars = from v in vc.vars
                            where v.boolPreloadMorphs && v.boolMorphs
                            select v;

            foreach (varfile vf in morphvars)
            {
                try
                {
                    if (vf.unpacked == false)
                    {
                        strFileuserpref = _strVAMdir + @"\AddonPackagesUserPrefs\" + Strings.Left(vf.fi.Name, vf.fi.Name.IndexOf(".", vf.fi.Name.IndexOf(".") + 1)) + ".prefs";
                    }
                    else
                    {
                        strFileuserpref = _strVAMdir + @"\AddonPackagesUserPrefs\" + Strings.Left(vf.di.Name, vf.di.Name.IndexOf(".", vf.di.Name.IndexOf(".") + 1)) + ".prefs";
                    }
                    
                    strUserPrefContents = "";

                    if (File.Exists(strFileuserpref))
                    {
                        boolOverwrite = false;
                        var objReader = new StreamReader(strFileuserpref);

                        while (!objReader.EndOfStream)
                        {
                            strLine = objReader.ReadLine();
                            if (strLine.Contains("preloadMorphs") && strLine.Contains("true"))
                            {
                                strLine = strLine.Replace("true", "false");
                                boolOverwrite = true;
                            }
                            strUserPrefContents += strLine + Environment.NewLine;
                        }

                        objReader.Close();
                        objReader.Dispose();

                        if (boolOverwrite)
                        {
                            File.WriteAllText(strFileuserpref, strUserPrefContents);
                        }
                    }
                    else
                    {
                        strUserPrefContents = "{ " + Environment.NewLine + @"   ""userNotes"" : """", " + Environment.NewLine + @"   ""customOptions"" : { " + Environment.NewLine + @"      ""preloadMorphs"" : ""false""" + Environment.NewLine + "   }" + Environment.NewLine + "}";

                        File.WriteAllText(strFileuserpref, strUserPrefContents);
                    }
                }
                catch
                {

                }
            }

            return 1;
        }

        public int RevertPreloadMorphs()
        {
            varconfig vc = GetVarconfig(_strVAMdir + @"\AddonPackages");
            string strFileuserpref;

            var morphvars = from v in vc.vars
                            where v.boolPreloadMorphs && v.boolMorphs
                            select v;

            foreach (varfile vf in morphvars)
            {
                try
                {
                    strFileuserpref = _strVAMdir + @"\AddonPackagesUserPrefs\" + Strings.Left(vf.fi.Name, vf.fi.Name.IndexOf(".", vf.fi.Name.IndexOf(".") + 1)) + ".prefs";

                    if (File.Exists(strFileuserpref))
                    {
                        File.Move(strFileuserpref, strFileuserpref + ".bak", true);
                    }
                }
                catch
                {

                }
            }

            return 1;
        }

        private varconfig GetVarconfig(string strDir, List<string> lstLocalFiles = null, List<FileInfo> lstFilesToScan = null, List<DirectoryInfo> lstDirsToScan = null, bool ignoreHidden = false)
        {
            var diFolder = new DirectoryInfo(strDir);
            varfile vf;
            var lstVars = new List<varfile>();
            var lstDepvars = new List<string>();
            var latestvars = new Dictionary<string, int>();
            int intlatest;
            bool boolSkip = false;

            var lstErrorsFilename = new List<string>();
            var lstErrorsJson = new List<string>();
            var lstErrorsZipFile = new List<string>();

            FileInfo[] lstHideFiles = null;

            if (ignoreHidden)
            {
                var diFolderFilePrefs = new DirectoryInfo(_strVAMdir + @"\AddonPackagesFilePrefs");
                lstHideFiles = diFolderFilePrefs.GetFiles("*.hide", SearchOption.AllDirectories);
            }

            foreach (FileInfo fi in diFolder.GetFiles("*.var", SearchOption.AllDirectories))
            {
                if (lstFilesToScan == null || lstFilesToScan.Any(x => x.FullName == fi.FullName))
                {

                    vf = new varfile();
                    vf.fi = fi;
                    vf.unpacked = false;
                    boolSkip = false;

                    try
                    {
                        vf.creator = Strings.Left(fi.Name, fi.Name.IndexOf(".")).Replace(" ", "_");
                        vf.Name = Strings.Left(fi.Name, fi.Name.IndexOf(".", fi.Name.IndexOf(".") + 1)).Replace(" ", "_");
                        vf.version = Convert.ToInt32(fi.Name.Split(".")[fi.Name.Split(".").Length - 2]);
                    }
                    catch (Exception exFilename)
                    {
                        lstErrorsFilename.Add(fi.Name);
                        vf.version = 1;
                    }

                    // Read file contents
                    try
                    {
                        ZipArchive varZip = ZipFile.Open(fi.FullName, ZipArchiveMode.Read);

                        foreach (ZipArchiveEntry e in varZip.Entries)
                        {
                            if (e.FullName.IndexOf("custom/atom/person/textures/", 0, StringComparison.CurrentCultureIgnoreCase) > -1)
                            {
                                vf.boolTextures = true;
                            }

                            if (e.FullName.IndexOf("custom/atom/person/morphs/", 0, StringComparison.CurrentCultureIgnoreCase) > -1)
                            {
                                vf.boolMorphs = true;
                                if (e.FullName.EndsWith("vmi"))
                                {
                                    vf.countMorphs += 1;
                                }
                            }

                            if (e.FullName.IndexOf("custom/assets/", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith("assetbundle", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if (!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + fi.Name.Replace(".var", "") + "\\", "").Replace(@"\", "/") == e.FullName + ".hide"))
                                    {
                                        vf.boolAssets = true;
                                    }
                                }
                                else { vf.boolAssets = true; }
                            }

                            if (e.FullName.IndexOf("saves/person/appearance/", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith("json", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if(!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + fi.Name.Replace(".var", "") + "\\", "").Replace(@"\", "/") == e.FullName + ".hide"))
                                    {
                                        vf.boolLooks = true;
                                    }
                                }
                                else { vf.boolLooks = true; }
                            }

                            if (e.FullName.IndexOf("custom/atom/person/appearance/", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith(".vap", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if (!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + fi.Name.Replace(".var", "") + "\\", "").Replace(@"\", "/") == e.FullName + ".hide"))
                                    {
                                        vf.boolLookPresets = true;
                                    }
                                }
                                else { vf.boolLookPresets = true; }
                            }

                            if (e.FullName.IndexOf("saves/scene/", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if (!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + fi.Name.Replace(".var", "") + "\\", "").Replace(@"\", "/") == e.FullName + ".hide"))
                                    {
                                        vf.boolScenes = true;
                                    }
                                }
                                else { vf.boolScenes = true; }
                            }

                            if (e.FullName.IndexOf("custom/subscene/", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if (!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + fi.Name.Replace(".var", "") + "\\", "").Replace(@"\", "/") == e.FullName + ".hide"))
                                    {
                                        vf.boolSubScenes = true;
                                    }
                                }
                                else { vf.boolSubScenes = true; }
                            }

                            if (e.FullName.IndexOf("saves/person/pose/", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if (!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + fi.Name.Replace(".var", "") + "\\", "").Replace(@"\", "/") == e.FullName + ".hide"))
                                    {
                                        vf.boolPoses = true;
                                    }
                                }
                                else { vf.boolPoses = true; }
                            }

                            if (e.FullName.IndexOf("custom/atom/person/pose/", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith(".vap", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if (!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + fi.Name.Replace(".var", "") + "\\", "").Replace(@"\", "/") == e.FullName + ".hide"))
                                    {
                                        vf.boolPosePresets = true;
                                    }
                                }
                                else { vf.boolPosePresets = true; }
                            }

                            if (e.FullName.IndexOf("custom/hair/", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith(".vam", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if (!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + fi.Name.Replace(".var", "") + "\\", "").Replace(@"\", "/") == e.FullName + ".hide"))
                                    {
                                        vf.boolHair = true;
                                    }
                                }
                                else { vf.boolHair = true; }
                            }

                            if (e.FullName.IndexOf("custom/atom/person/hair/", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith(".vap", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if (!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + fi.Name.Replace(".var", "") + "\\", "").Replace(@"\", "/") == e.FullName + ".hide"))
                                    {
                                        vf.boolHairPreset = true;
                                    }
                                }
                                else { vf.boolHairPreset = true; }
                            }

                            if (e.FullName.IndexOf("custom/clothing/", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith(".vam", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if (!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + fi.Name.Replace(".var", "") + "\\", "").Replace(@"\", "/") == e.FullName + ".hide"))
                                    {
                                        vf.boolClothing = true;
                                    }
                                }
                                else { vf.boolClothing = true; }
                            }

                            if (e.FullName.IndexOf("custom/atom/person/clothing/", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith(".vap", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if (!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + fi.Name.Replace(".var", "") + "\\", "").Replace(@"\", "/") == e.FullName + ".hide"))
                                    {
                                        vf.boolClothingPreset = true;
                                    }
                                }
                                else { vf.boolClothingPreset = true; }
                            }

                            if (e.FullName.IndexOf("custom/scripts/", 0, StringComparison.CurrentCultureIgnoreCase) > -1)
                            {
                                vf.boolScripts = true;
                            }

                            if (e.FullName == "meta.json")
                            {
                                var objReader = new StreamReader(e.Open());
                                try
                                {
                                    var jsonOptions = new JsonSerializerOptions { AllowTrailingCommas = true };
                                    varMeta? metaJS = JsonSerializer.Deserialize<varMeta>(objReader.ReadToEnd(), jsonOptions);

                                    if (vf.creator == "")
                                    { vf.creator = metaJS.creatorName.Replace(" ", "_"); }

                                    if (vf.Name == "")
                                    { vf.Name = metaJS.creatorName.Replace(" ", "_") + "." + metaJS.packageName.Replace(" ", "_"); }

                                    if (metaJS.dependencies != null)
                                    {
                                        var dependencies = metaJS.dependencies;
                                        foreach (string dep in dependencies.Keys)
                                        {
                                            if (!lstDepvars.Contains(dep.Split(".")[0].Replace(" ", "_") + "." + dep.Split(".")[1].Replace(" ", "_") + "." + dep.Split(".")[2]))
                                            {
                                                lstDepvars.Add(dep.Split(".")[0].Replace(" ", "_") + "." + dep.Split(".")[1].Replace(" ", "_") + "." + dep.Split(".")[2]);
                                            }
                                        }
                                    }

                                    if ((metaJS.customOptions != null) && (metaJS.customOptions.preloadMorphs != null))
                                    {
                                        if (metaJS.customOptions.preloadMorphs.HasValue && metaJS.customOptions.preloadMorphs.ToString() == "true")
                                        {
                                            vf.boolPreloadMorphs = true;
                                        }
                                    }
                                }
                                catch (Exception exJson)
                                {
                                    Debug.Print(fi.FullName);
                                    lstErrorsJson.Add(fi.Name);
                                }

                                objReader.Close();
                                objReader.Dispose();
                            }
                        }

                        varZip.Dispose();
                    }
                    catch (Exception exZip) //broken or unreadable zip file, skip
                    {
                        lstErrorsZipFile.Add(fi.Name);
                        boolSkip = true;
                    }

                    if (!boolSkip)
                    {
                        if (latestvars.TryGetValue(vf.Name, out intlatest))
                        {
                            if (vf.version > intlatest)
                            {
                                latestvars[vf.Name] = vf.version;
                            }
                        }
                        else
                        {
                            latestvars.Add(vf.Name, vf.version);
                        }

                        lstVars.Add(vf);
                    }
                }    
            }

            foreach (DirectoryInfo di in diFolder.GetDirectories("*.var", SearchOption.AllDirectories))
            {
                if (lstDirsToScan == null || lstDirsToScan.Any(x => x.FullName == di.FullName))
                {

                    vf = new varfile();
                    vf.di = di;
                    vf.unpacked = true;
                    boolSkip = false;

                    try
                    {
                        vf.creator = Strings.Left(di.Name, di.Name.IndexOf(".")).Replace(" ", "_");
                        vf.Name = Strings.Left(di.Name, di.Name.IndexOf(".", di.Name.IndexOf(".") + 1)).Replace(" ", "_");
                        vf.version = Convert.ToInt32(di.Name.Split(".")[di.Name.Split(".").Length - 2]);
                    }
                    catch (Exception exFilename)
                    {
                        lstErrorsFilename.Add(di.Name);
                        vf.version = 1;
                    }

                    // Read file contents
                    try
                    {

                        foreach (FileInfo e in di.GetFiles("*.*", SearchOption.AllDirectories))
                        {
                            if (e.FullName.IndexOf(@"custom\atom\person\textures\", 0, StringComparison.CurrentCultureIgnoreCase) > -1)
                            {
                                vf.boolTextures = true;
                            }

                            if (e.FullName.IndexOf(@"custom\atom\person\morphs\", 0, StringComparison.CurrentCultureIgnoreCase) > -1)
                            {
                                vf.boolMorphs = true;
                                if (e.FullName.EndsWith("vmi"))
                                {
                                    vf.countMorphs += 1;
                                }
                            }

                            if (e.FullName.IndexOf(@"custom\assets\", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith(".assetbundle", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if (!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + di.Name.Replace(".var", "") + "\\", "") == Strings.Right(e.FullName, e.FullName.Length - e.FullName.IndexOf(di.Name)).Replace(di.Name + "\\", "") + ".hide"))
                                    {
                                        vf.boolAssets = true;
                                    }
                                }
                                else { vf.boolAssets = true; }
                            }

                            if (e.FullName.IndexOf(@"saves\person\appearance\", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if (!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + di.Name.Replace(".var", "") + "\\", "") == Strings.Right(e.FullName, e.FullName.Length - e.FullName.IndexOf(di.Name)).Replace(di.Name + "\\", "") + ".hide"))
                                    {
                                        vf.boolLooks = true;
                                    }
                                }
                                else { vf.boolLooks = true; }
                            }

                            if (e.FullName.IndexOf(@"custom\atom\person\appearance\", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith(".vap", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if (!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + di.Name.Replace(".var", "") + "\\", "") == Strings.Right(e.FullName, e.FullName.Length - e.FullName.IndexOf(di.Name)).Replace(di.Name + "\\", "") + ".hide"))
                                    {
                                        vf.boolLookPresets = true;
                                    }
                                }
                                else { vf.boolLookPresets = true; }
                            }

                            if (e.FullName.IndexOf(@"saves\scene\", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if (!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + di.Name.Replace(".var", "") + "\\", "") == Strings.Right(e.FullName, e.FullName.Length - e.FullName.IndexOf(di.Name)).Replace(di.Name + "\\", "") + ".hide"))
                                    {
                                        vf.boolScenes = true;
                                    }
                                }
                                else { vf.boolScenes = true; }
                            }

                            if (e.FullName.IndexOf(@"custom\subscene\", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if (!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + di.Name.Replace(".var", "") + "\\", "") == Strings.Right(e.FullName, e.FullName.Length - e.FullName.IndexOf(di.Name)).Replace(di.Name + "\\", "") + ".hide"))
                                    {
                                        vf.boolSubScenes = true;
                                    }
                                }
                                else { vf.boolSubScenes = true; }
                            }

                            if (e.FullName.IndexOf(@"saves\person\pose\", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if (!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + di.Name.Replace(".var", "") + "\\", "") == Strings.Right(e.FullName, e.FullName.Length - e.FullName.IndexOf(di.Name)).Replace(di.Name + "\\", "") + ".hide"))
                                    {
                                        vf.boolPoses = true;
                                    }
                                }
                                else { vf.boolPoses = true; }
                            }

                            if (e.FullName.IndexOf(@"custom\atom\person\pose\", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith(".vap", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if (!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + di.Name.Replace(".var", "") + "\\", "") == Strings.Right(e.FullName, e.FullName.Length - e.FullName.IndexOf(di.Name)).Replace(di.Name + "\\", "") + ".hide"))
                                    {
                                        vf.boolPosePresets = true;
                                    }
                                }
                                else { vf.boolPosePresets = true; }
                            }

                            if (e.FullName.IndexOf(@"custom\hair\", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith(".vam", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if (!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + di.Name.Replace(".var", "") + "\\", "") == Strings.Right(e.FullName, e.FullName.Length - e.FullName.IndexOf(di.Name)).Replace(di.Name + "\\", "") + ".hide"))
                                    {
                                        vf.boolHair = true;
                                    }
                                }
                                else { vf.boolHair = true; }
                            }

                            if (e.FullName.IndexOf(@"custom\atom\person\hair\", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith(".vap", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if (!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + di.Name.Replace(".var", "") + "\\", "") == Strings.Right(e.FullName, e.FullName.Length - e.FullName.IndexOf(di.Name)).Replace(di.Name + "\\", "") + ".hide"))
                                    {
                                        vf.boolHairPreset = true;
                                    }
                                }
                                else { vf.boolHairPreset = true; }
                            }

                            if (e.FullName.IndexOf(@"custom\clothing\", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith(".vam", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if (!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + di.Name.Replace(".var", "") + "\\", "") == Strings.Right(e.FullName, e.FullName.Length - e.FullName.IndexOf(di.Name)).Replace(di.Name + "\\", "") + ".hide"))
                                    {
                                        vf.boolClothing = true;
                                    }
                                }
                                else { vf.boolClothing = true; }
                            }

                            if (e.FullName.IndexOf(@"custom\atom\person\clothing\", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.EndsWith(".vap", StringComparison.OrdinalIgnoreCase))
                            {
                                if (ignoreHidden)
                                {
                                    if (!lstHideFiles.Any(x => x.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + di.Name.Replace(".var", "") + "\\", "") == Strings.Right(e.FullName, e.FullName.Length - e.FullName.IndexOf(di.Name)).Replace(di.Name + "\\", "") + ".hide"))
                                    {
                                        vf.boolClothingPreset = true;
                                    }
                                }
                                else { vf.boolClothingPreset = true; }
                            }

                            if (e.FullName.IndexOf(@"custom\scripts\", 0, StringComparison.CurrentCultureIgnoreCase) > -1)
                            {
                                vf.boolScripts = true;
                            }

                            if (e.Name == "meta.json")
                            {
                                var objReader = new StreamReader(e.FullName);
                                try
                                {
                                    var jsonOptions = new JsonSerializerOptions { AllowTrailingCommas = true };
                                    varMeta? metaJS = JsonSerializer.Deserialize<varMeta>(objReader.ReadToEnd());

                                    if (vf.creator == "")
                                    { vf.creator = metaJS.creatorName.Replace(" ", "_"); }

                                    if (vf.Name == "")
                                    { vf.Name = metaJS.creatorName.Replace(" ", "_") + "." + metaJS.packageName.Replace(" ", "_"); }

                                    if (metaJS.dependencies != null)
                                    {
                                        var dependencies = metaJS.dependencies;
                                        foreach (string dep in dependencies.Keys)
                                        {
                                            if (!lstDepvars.Contains(dep.Split(".")[0].Replace(" ", "_") + "." + dep.Split(".")[1].Replace(" ", "_") + "." + dep.Split(".")[2]))
                                            {
                                                lstDepvars.Add(dep.Split(".")[0].Replace(" ", "_") + "." + dep.Split(".")[1].Replace(" ", "_") + "." + dep.Split(".")[2]);
                                            }
                                        }
                                    }

                                    if ((metaJS.customOptions != null) && (metaJS.customOptions.preloadMorphs != null))
                                    {
                                        if (metaJS.customOptions.preloadMorphs.HasValue && metaJS.customOptions.preloadMorphs.ToString() == "true")
                                        {
                                            vf.boolPreloadMorphs = true;
                                        }
                                    }
                                }
                                catch (Exception exJson)
                                {
                                    Debug.Print(e.FullName);
                                    lstErrorsJson.Add(e.Name);
                                }

                                objReader.Close();
                                objReader.Dispose();
                            }
                        }

                    }
                    catch (Exception exZip) //broken or unreadable zip file, skip
                    {
                        lstErrorsZipFile.Add(di.Name);
                        boolSkip = true;
                    }

                    if (!boolSkip)
                    {
                        if (latestvars.TryGetValue(vf.Name, out intlatest))
                        {
                            if (vf.version > intlatest)
                            {
                                latestvars[vf.Name] = vf.version;
                            }
                        }
                        else
                        {
                            latestvars.Add(vf.Name, vf.version);
                        }

                        lstVars.Add(vf);
                    }
                }
            }

            if (lstLocalFiles != null)
            {
                foreach (var s in lstLocalFiles)
                {
                    lstDepvars = ScanJsonForDependencies(_strVAMdir + s, (s.Contains("Saves\\scene") ? "json" : (s.Contains("\\Saves\\PluginData\\JayJayWon\\UIAssist") ? "uiap" :  "vap")), lstDepvars);
                }
            }

            varconfig vc = new varconfig();
            vc.vars = lstVars;
            vc.deps = lstDepvars;
            vc.latestvars = latestvars;

            if (lstErrorsZipFile.Count > 0)
            {
                //var message = string.Join(Environment.NewLine, lstErrorsFilename);
                //MessageBox.Show("These .vars have incorrect file names, though should not cause issues:" + Environment.NewLine + message, "Warning: Incorrectly named files.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                var message = string.Join(Environment.NewLine, lstErrorsZipFile);
                MessageBox.Show("Broken/Unreadable .vars were skipped." + Environment.NewLine + "Manually remove or try re-zipping these files:" + Environment.NewLine + message, "Broken/Unreadable .vars Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return vc;
        }

        private List<string> ScanJsonForDependencies(string strDirectory,string strExtension, List<string> lstDepvars)
        {
            string strDepvar;

            foreach (var fi in Directory.GetFiles(strDirectory, "*." + strExtension, SearchOption.AllDirectories))
            {
                foreach (string line in System.IO.File.ReadLines(fi))
                {
                    if ((line.Contains(":/Custom") && !line.Contains("SELF:/")) || (strExtension == "uiap" && line.Contains(":/Saves",StringComparison.OrdinalIgnoreCase)))
                    {    
                        try
                        {
                            strDepvar = line.Substring(0, line.IndexOf(":/"));
                            strDepvar = strDepvar.Substring(strDepvar.LastIndexOf(@"""") + 1, strDepvar.Length - strDepvar.LastIndexOf(@"""") - 1);
                            strDepvar = strDepvar.Split(".")[0].Replace(" ", "_") + "." + strDepvar.Split(".")[1].Replace(" ", "_") + "." + strDepvar.Split(".")[2];
                            if (!lstDepvars.Contains(strDepvar))
                            {
                                lstDepvars.Add(strDepvar);
                            }
                        }
                        catch
                        {
                            Debug.Print(line);
                        }
                    }
                }
            }

            return lstDepvars;
        }

        public List<string> GetCreatorList(bool backupdir = false)
        {
            ZipArchive var;
            DirectoryInfo diFolder;
            if (!backupdir) { diFolder = new DirectoryInfo(_strVAMdir + @"\AddonPackages"); }
            else { diFolder = new DirectoryInfo(_strVAMbackupdir); }

            varfile vf;
            var lstVars = new List<varfile>();
            var lstDepvars = new List<string>();
            var latestvars = new Dictionary<string, int>();
            var intlatest = default(int);

            var lstErrorsFilename = new List<string>();
            var lstErrorsZipFile = new List<string>();

            foreach (FileInfo fi in diFolder.GetFiles("*.var", SearchOption.AllDirectories))
            {
                vf = new varfile();
                vf.fi = fi;

                try
                {
                    vf.creator = Strings.Left(fi.Name, fi.Name.IndexOf(".")).Replace(" ", "_");
                    vf.Name = Strings.Left(fi.Name, fi.Name.IndexOf(".", fi.Name.IndexOf(".") + 1)).Replace(" ", "_");
                    vf.version = Convert.ToInt32(fi.Name.Split(".")[fi.Name.Split(".").Length - 2]);
                }
                catch
                {
                    lstErrorsFilename.Add(fi.Name);
                    vf.version = 1;
                }

                if (vf.creator == "")
                {
                    try
                    {
                        var = ZipFile.Open(fi.FullName, ZipArchiveMode.Read);

                        var objReader = new StreamReader(var.GetEntry("meta.json").Open());
                        varMeta? metaJS = JsonSerializer.Deserialize<varMeta>(objReader.ReadToEnd());

                        vf.creator = metaJS.creatorName.Replace(" ", "_");
                        vf.Name = metaJS.creatorName.Replace(" ", "_") + "." + metaJS.packageName.Replace(" ", "_");

                        objReader.Close();
                        objReader.Dispose();

                        var.Dispose();
                    }
                    catch
                    {
                        lstErrorsZipFile.Add(fi.Name);
                    }
                }

                if (latestvars.TryGetValue(vf.Name, out intlatest))
                {
                    if (vf.version > intlatest)
                    {
                        latestvars[vf.Name] = vf.version;
                    }
                }
                else
                {
                    latestvars.Add(vf.Name, vf.version);
                }

                lstVars.Add(vf);
            }

            foreach (DirectoryInfo di in diFolder.GetDirectories("*.var", SearchOption.AllDirectories))
            {
                vf = new varfile();
                vf.di = di;

                try
                {
                    vf.creator = Strings.Left(di.Name, di.Name.IndexOf(".")).Replace(" ", "_");
                    vf.Name = Strings.Left(di.Name, di.Name.IndexOf(".", di.Name.IndexOf(".") + 1)).Replace(" ", "_");
                    vf.version = Convert.ToInt32(di.Name.Split(".")[di.Name.Split(".").Length - 2]);
                }
                catch
                {
                    lstErrorsFilename.Add(di.Name);
                    vf.version = 1;
                }

                if (vf.creator == "")
                {
                    try
                    {
                        var objReader = new StreamReader(di.FullName + @"\meta.json");
                        varMeta? metaJS = JsonSerializer.Deserialize<varMeta>(objReader.ReadToEnd());

                        vf.creator = metaJS.creatorName.Replace(" ", "_");
                        vf.Name = metaJS.creatorName.Replace(" ", "_") + "." + metaJS.packageName.Replace(" ", "_");

                        objReader.Close();
                        objReader.Dispose();

                    }
                    catch
                    {
                        lstErrorsZipFile.Add(di.Name);
                    }
                }

                if (latestvars.TryGetValue(vf.Name, out intlatest))
                {
                    if (vf.version > intlatest)
                    {
                        latestvars[vf.Name] = vf.version;
                    }
                }
                else
                {
                    latestvars.Add(vf.Name, vf.version);
                }

                lstVars.Add(vf);
            }

            //var message = string.Join(Environment.NewLine, lstErrorvars);
            //MessageBox.Show("These .vars have incorrect file names, though should not cause issues:" + Environment.NewLine + message, "Warning: Incorrectly named files.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            var creators = (from v in lstVars
                            select v.creator).Distinct().ToList();

            creators.Sort();

            return creators;
        }

        #endregion

        #region "Item Management"
        
        public List<varItemReplacement> GetDuplicateItems(string strType, string strSex, List<string> lstMasterVars, List<string> lstMasterVarItems)
        {
            Dictionary<string,string> lstSpecialCaseReplacements = GetItemReplacements(strType);
            List<varItemReplacement> lstDuplicates = new List<varItemReplacement>();
            varItemReplacement vir;
            string strDirAddonFilePrefs = _strVAMdir + @"\AddonPackagesFilePrefs";
            string strFileHide;

            var viLatest = GetLatestVarItems(GetVarconfig(_strVAMdir + @"\AddonPackages"), strType, strSex);
            
            //All duplicate items with count of each item
            var varItemsDuplicates = from vi in viLatest
                                     group vi by new
                                     {
                                         vi.Properties.uid,
                                         vi.Properties.displayName,
                                         vi.Properties.creatorName
                                     } into grp
                                     where grp.Count() > 1
                                     select new
                                     {
                                         uid = grp.Key.uid,
                                         displayName = grp.Key.displayName,
                                         creatorName = grp.Key.creatorName,
                                         cnt = grp.Count()
                                     } into selection
                                     orderby selection.creatorName, selection.uid
                                     select selection;

            foreach (var itemDistinct in varItemsDuplicates)
            {
                varItem viMaster = null;

                //Details & var info for each duplicate
                var matches = from viMatch in viLatest
                              where viMatch.Properties.uid == itemDistinct.uid && viMatch.Properties.displayName == itemDistinct.displayName && viMatch.Properties.creatorName == itemDistinct.creatorName
                              select viMatch;

                if (matches.Any())
                {
                    //Check if there are duplicates withing the same .var creator
                    var matchesVarCreator = from viMatch in matches
                                            where viMatch.var.creator.ToLower().Replace(" ","_") == viMatch.Properties.creatorName.ToLower().Replace(" ", "_")
                                            select viMatch;

                    if (matchesVarCreator.Count() > 1)
                    {
                        //Check if hide file already created
                        var matchesVarCreatorActiveFiles = from viMatch in matchesVarCreator
                                                           where 
                                                            (viMatch.var.unpacked == false && !File.Exists(strDirAddonFilePrefs + @"\" + viMatch.var.fi.Name.Replace(".var", "") + @"\" + viMatch.FullName.Replace("/", @"\") + ".hide")) ||
                                                            (viMatch.var.unpacked == true && !File.Exists(strDirAddonFilePrefs + @"\" + viMatch.var.di.Name.Replace(".var", "") + @"\" + viMatch.FullName.Replace("/", @"\") + ".hide"))
                                                           select viMatch;
                        
                        if (matchesVarCreatorActiveFiles.Count() > 1)
                        {
                            //Duplicates files where the .var creater matches the .vam item creator, need to manually fix/disable these first
                            vir = new varItemReplacement(varItemReplacement.SAMECREATOR, strType);
                            vir.itemname = (itemDistinct.displayName == "" ? (itemDistinct.uid.IndexOf(":") > 0 ? itemDistinct.uid.Substring(itemDistinct.uid.IndexOf(":") + 1, itemDistinct.uid.Length - itemDistinct.uid.IndexOf(":") - 1) : itemDistinct.uid) : itemDistinct.displayName);
                            vir.creator = itemDistinct.creatorName;

                            foreach (var fix in matchesVarCreatorActiveFiles)
                            {
                                //Debug.Print("    " + fix.var.fi.Name);
                                vir.lstVi.Add(fix);
                            }

                            lstDuplicates.Add(vir);
                        }
                        else if (matchesVarCreatorActiveFiles.Count() == 1)
                        {
                            viMaster = matchesVarCreatorActiveFiles.First();
                        }
                    }
                    else if (matchesVarCreator.Count() == 1)
                    {
                        //Only 1 match with .var creator as item creator, don't need to check active files
                        viMaster = matchesVarCreator.First();
                    }
                }

                if (viMaster != null) //Master item & var found, disable duplicates
                {
                    //Get list of active files for current distinct item
                    var matchesActiveFiles = from viMatch in matches 
                                             where (viMatch.var.creator.ToLower().Replace(" ", "_") != viMatch.Properties.creatorName.ToLower().Replace(" ", "_")) &&
                                             (
                                                 (viMatch.var.unpacked == false && !File.Exists(strDirAddonFilePrefs + @"\" + viMatch.var.fi.Name.Replace(".var", "") + @"\" + viMatch.FullName.Replace("/", @"\") + ".hide")) ||
                                                 (viMatch.var.unpacked == true && !File.Exists(strDirAddonFilePrefs + @"\" + viMatch.var.di.Name.Replace(".var", "") + @"\" + viMatch.FullName.Replace("/", @"\") + ".hide"))
                                             )
                                             select viMatch;

                    if (matchesActiveFiles.Any())
                    {
                        //Print master found
                        vir = new varItemReplacement(varItemReplacement.DISABLE, strType);
                        vir.itemname = (itemDistinct.displayName == "" ? (itemDistinct.uid.IndexOf(":") > 0 ? itemDistinct.uid.Substring(itemDistinct.uid.IndexOf(":") + 1, itemDistinct.uid.Length - itemDistinct.uid.IndexOf(":") - 1) : itemDistinct.uid) : itemDistinct.displayName);
                        vir.creator = itemDistinct.creatorName;
                        vir.mastervar = viMaster.var.Name;
                            
                        foreach (var match in matchesActiveFiles)
                        {
                            vir.lstVi.Add(match);
                        }

                        lstDuplicates.Add(vir);
                    }
                }
                else //No Master item & var found, need to fix these manually
                {
                    //Get list of active files for current distinct item
                    var matchesActiveFiles = from viMatch in matches
                                             where (viMatch.var.creator.ToLower().Replace(" ", "_") != viMatch.Properties.creatorName.ToLower().Replace(" ", "_")) &&
                                             (
                                                 (viMatch.var.unpacked == false && !File.Exists(strDirAddonFilePrefs + @"\" + viMatch.var.fi.Name.Replace(".var", "") + @"\" + viMatch.FullName.Replace("/", @"\") + ".hide")) ||
                                                 (viMatch.var.unpacked == true && !File.Exists(strDirAddonFilePrefs + @"\" + viMatch.var.di.Name.Replace(".var", "") + @"\" + viMatch.FullName.Replace("/", @"\") + ".hide"))
                                             )
                                             select viMatch;

                    if (matchesActiveFiles.Count() > 1)
                    {
                        //Debug.Print((itemDistinct.displayName == "" ? itemDistinct.uid : itemDistinct.displayName) + "|" + itemDistinct.creatorName);
                        vir = new varItemReplacement(varItemReplacement.NOMASTER, strType);
                        vir.itemname = (itemDistinct.displayName == "" ? (itemDistinct.uid.IndexOf(":") > 0 ? itemDistinct.uid.Substring(itemDistinct.uid.IndexOf(":") + 1, itemDistinct.uid.Length - itemDistinct.uid.IndexOf(":") - 1) : itemDistinct.uid) : itemDistinct.displayName);
                        vir.creator = itemDistinct.creatorName;

                        foreach (var match in matchesActiveFiles)
                        {
                            //Debug.Print("    " + match.var.fi.Name);
                            vir.lstVi.Add(match);
                        }

                        lstDuplicates.Add(vir);
                    }
                }
            }

            //Debug.Print("-------------Duplicates with same creator-------------");
            //foreach (var v in lstDuplicates.Where(v => v.varItemReplacementType == varItemReplacement.SAMECREATOR))
            //{
            //    Debug.Print(v.creator + "." + v.itemname);
            //    foreach (var dup in v.lstVi) 
            //    { 
            //        Debug.Print("    " + dup.var.fi.Name); 
            //    }
            //}
            //Debug.Print("-------------Duplicates no master-------------");
            //foreach (var v in lstDuplicates.Where(v => v.varItemReplacementType == varItemReplacement.NOMASTER))
            //{
            //    Debug.Print(v.creator + "." + v.itemname);
            //    foreach (var dup in v.lstVi) 
            //    { 
            //        Debug.Print("    " + dup.var.fi.Name); 
            //    }
            //}
            //Debug.Print("-------------Master Found-------------");
            //foreach (var v in lstDuplicates.Where(v => v.varItemReplacementType == varItemReplacement.DISABLE))
            //{
            //    Debug.Print(v.creator + "." + v.itemname + "|Master = " + v.mastervar + "|");
            //    foreach (var dup in v.lstVi) 
            //    {
            //        strFileHide = strDirAddonFilePrefs + @"\" + dup.var.fi.Name.Replace(".var", "") + @"\" + dup.FullName.Replace("/", @"\") + ".hide";
            //        Debug.Print("    " + dup.var.fi.Name);
            //    }
            //}

            return lstDuplicates;
        }

        public void DisableDuplicateItem(string varname, string itemfullpath)
        {
            string strDirAddonFilePrefs = _strVAMdir + @"\AddonPackagesFilePrefs";
            string strFileHide;

            strFileHide = strDirAddonFilePrefs + @"\" + varname.Replace(".var", "") + @"\" + itemfullpath.Replace("/", @"\") + ".hide";

            if (!Directory.Exists(Path.GetDirectoryName(strFileHide))) { Directory.CreateDirectory(Path.GetDirectoryName(strFileHide)); }
            File.Create(strFileHide).Close();
        }

        private List<varItem> GetLatestVarItems(varconfig vc, string strType, string strSex = "female")
        {
            ZipArchive zipVar;
            List<varItem> lstVarItems = new List<varItem>();
            IEnumerable<varfile> selectedVars;
            StreamReader objReader;
            vamFile vf;

            if (strType == "clothing")
            {
                selectedVars = from v in vc.vars
                               where v.boolClothing && vc.latestvars[v.Name] == v.version
                               select v;
            }
            else if (strType == "hair")
            {
                selectedVars = from v in vc.vars
                               where v.boolHair && vc.latestvars[v.Name] == v.version
                               select v;
            }
            else { selectedVars = null; }

            if (selectedVars != null)
            {
                foreach (varfile v in selectedVars)
                {
                    try
                    {
                        if (v.unpacked == false)
                        {
                            zipVar = ZipFile.Open(v.fi.FullName, ZipArchiveMode.Read);

                            foreach (ZipArchiveEntry e in zipVar.Entries)
                            {
                                if (strType == "clothing")
                                {
                                    if (e.FullName.IndexOf("custom/clothing/", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.ToLower().Contains("/" + strSex + "/") && e.FullName.EndsWith(".vam"))
                                    {
                                        objReader = new StreamReader(e.Open());
                                        vf = JsonSerializer.Deserialize<vamFile>(objReader.ReadToEnd());
                                        lstVarItems.Add(new varItem(v, e.Name, e.FullName, vf));
                                        objReader.Close();
                                    }
                                }
                                else if (strType == "hair")
                                {
                                    if (e.FullName.IndexOf("custom/hair/", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.ToLower().Contains("/" + strSex + "/") && e.FullName.EndsWith(".vam"))
                                    {
                                        objReader = new StreamReader(e.Open());
                                        vf = JsonSerializer.Deserialize<vamFile>(objReader.ReadToEnd());
                                        lstVarItems.Add(new varItem(v, e.Name, e.FullName, vf));
                                        objReader.Close();
                                    }
                                }
                            }

                            zipVar.Dispose();
                        }
                        else
                        {
                            foreach (FileInfo e in v.di.GetFiles("*.*",SearchOption.AllDirectories))
                            {
                                if (strType == "clothing")
                                {
                                    if (e.FullName.IndexOf(@"custom\clothing\", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.ToLower().Contains(@"\" + strSex + @"\") && e.FullName.EndsWith(".vam"))
                                    {
                                        objReader = new StreamReader(e.FullName);
                                        vf = JsonSerializer.Deserialize<vamFile>(objReader.ReadToEnd());
                                        //lstVarItems.Add(new varItem(v, e.Name, e.FullName.Replace(_strVAMdir + @"\AddonPackagesFilePrefs\" + di.Name.Replace(".var", "") + "\\", "").Replace(@"\", "/"), vf));
                                        lstVarItems.Add(new varItem(v, e.Name, e.FullName.Replace(v.di.FullName + @"\", "").Replace(@"\","/"), vf));
                                        objReader.Close();
                                    }
                                }
                                else if (strType == "hair")
                                {
                                    if (e.FullName.IndexOf(@"custom\hair\", 0, StringComparison.CurrentCultureIgnoreCase) > -1 && e.FullName.ToLower().Contains(@"\" + strSex + @"\") && e.FullName.EndsWith(".vam"))
                                    {
                                        objReader = new StreamReader(e.FullName);
                                        vf = JsonSerializer.Deserialize<vamFile>(objReader.ReadToEnd());
                                        lstVarItems.Add(new varItem(v, e.Name, e.FullName.Replace(v.di.FullName + @"\","").Replace(@"\", "/"), vf));
                                        objReader.Close();
                                    }
                                }
                            }
                        }
                    }
                    catch 
                    { 
                        //Unable to read zip archive
                    }
                }
            }

            return lstVarItems; 
        }

        public List<varfile> GetMorphVars()
        {
            List<varItem> lstVarItems = new List<varItem>();

            varconfig vc = GetVarconfig(_strVAMdir + @"\AddonPackages");

            var latestVars = (from v in vc.vars
                             where v.boolMorphs && vc.latestvars[v.Name] == v.version
                             orderby v.Name
                             select v).ToList();


            return latestVars;
        }

        private Dictionary<string, string> GetItemReplacements(string strType)
        {
            Dictionary<string, string> itemReplacements = new Dictionary<string, string>();

            switch (strType)
            {
                case "clothing":
                    itemReplacements.Add("Braces|Braces|Electric Dreams", "Captain Varghoss.Braces.1.var");
                    break;
                case "hair":
                    //itemReplacements.Add("JayC Re-Animator:Curly Bob-Bangs||JayC Re-animator", "JayC_Re-animator.Hair_Curly_Bob.1.var");
                    break;
            }

            return itemReplacements;

        }

        #endregion
    }
}
