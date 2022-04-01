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
            public string itemType;
            public string uid;
            public string displayName;
            public string creatorName;
            public string tags;
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

        private partial class varconfig
        {
            public List<varfile> vars;
            public List<string> deps;
            public Dictionary<string, int> latestvars;
        }

        public partial class varCounts
        {
            public int countVAMvars;
            public int countBackupvars;
        }

        #endregion

        private string _strVAMdir;
        private string _strVAMbackupdir;

        public varmanager(string strVAMdir, string strVAMbackupdir)
        {
            _strVAMdir = strVAMdir;
            _strVAMbackupdir = strVAMbackupdir;
        }

        public varCounts BackupUnrefVars()
        {
            varconfig vc = GetVarconfig(_strVAMdir + @"\AddonPackages");

            var unusedVars = from v in vc.vars
                             where
                                !vc.deps.Contains(Convert.ToString(v.Name), StringComparer.OrdinalIgnoreCase)
                             select v;

            foreach (var f in unusedVars)
            {
                if (!Directory.Exists(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                }

                if (!File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)))) 
                { File.Move(Convert.ToString(f.fi.FullName), Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))); }
            }

            return GetVarCounts();
        }

        public varCounts BackupUnrefVarsEx(System.Windows.Forms.CheckedListBox.CheckedItemCollection lstFolderEx, System.Windows.Forms.CheckedListBox.CheckedItemCollection lstCreatorEx)
        {
            varconfig vc = GetVarconfig(_strVAMdir + @"\AddonPackages");

            var unusedVars = from v in vc.vars
                             where
                                !vc.deps.Contains(Convert.ToString(v.Name), StringComparer.OrdinalIgnoreCase) &&
                                !lstFolderEx.Contains(Convert.ToString(v.fi.Directory.Name)) &&
                                !lstFolderEx.Contains(Path.GetDirectoryName(v.fi.FullName).Replace(_strVAMdir + @"\AddonPackages\", "")) &&
                                !lstCreatorEx.Contains(Convert.ToString(v.creator))
                             select v;

            foreach (var f in unusedVars)
            {

                if (!Directory.Exists(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                }

                if (!File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)))) { File.Move(Convert.ToString(f.fi.FullName), Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))); }
            }

            return GetVarCounts();
        }

        public varCounts BackupUnrefSpecVars(System.Windows.Forms.CheckedListBox.CheckedItemCollection lstTypes)
        {
            varconfig vc = GetVarconfig(_strVAMdir + @"\AddonPackages");

            var backupvars = from v in vc.vars
                             where
                                (
                                    (v.boolAssets && lstTypes.Contains("Assets")) ||
                                    (v.boolClothing && lstTypes.Contains("Clothing")) ||
                                    (v.boolClothingPreset && lstTypes.Contains("Clothing Presets")) ||
                                    (v.boolHair && lstTypes.Contains("Hair")) ||
                                    (v.boolHairPreset && lstTypes.Contains("Hair Presets")) ||
                                    ((v.boolLooks || v.boolLookPresets) && lstTypes.Contains("Looks")) ||
                                    (v.boolMorphs && lstTypes.Contains("Morphs")) ||
                                    ((v.boolPoses || v.boolPosePresets) && lstTypes.Contains("Poses")) ||
                                    (v.boolScenes && lstTypes.Contains("Scenes")) ||
                                    (v.boolSubScenes && lstTypes.Contains("SubScenes")) ||
                                    (v.boolScripts && lstTypes.Contains("Scripts")) ||
                                    (v.boolTextures && lstTypes.Contains("Skin Textures"))
                                ) &&
                                !vc.deps.Contains(Convert.ToString(v.Name), StringComparer.OrdinalIgnoreCase)
                             select v;

            foreach (var f in backupvars)
            {
                if (!Directory.Exists(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                }

                if (!File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)))) { File.Move(Convert.ToString(f.fi.FullName), Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))); }
            }

            return GetVarCounts();
        }

        public varCounts BackupUnrefSpecVarsEx(System.Windows.Forms.CheckedListBox.CheckedItemCollection lstTypes, System.Windows.Forms.CheckedListBox.CheckedItemCollection lstFolderEx, System.Windows.Forms.CheckedListBox.CheckedItemCollection lstCreatorEx)
        {
            varconfig vc = GetVarconfig(_strVAMdir + @"\AddonPackages");

            var backupvars = from v in vc.vars
                             where
                                (
                                    (v.boolAssets && lstTypes.Contains("Assets")) ||
                                    (v.boolClothing && lstTypes.Contains("Clothing")) ||
                                    (v.boolClothingPreset && lstTypes.Contains("Clothing Presets")) ||
                                    (v.boolHair && lstTypes.Contains("Hair")) ||
                                    (v.boolHairPreset && lstTypes.Contains("Hair Presets")) ||
                                    ((v.boolLooks || v.boolLookPresets) && lstTypes.Contains("Looks")) ||
                                    (v.boolMorphs && lstTypes.Contains("Morphs")) ||
                                    ((v.boolPoses || v.boolPosePresets) && lstTypes.Contains("Poses")) ||
                                    (v.boolScenes && lstTypes.Contains("Scenes")) ||
                                    (v.boolSubScenes && lstTypes.Contains("SubScenes")) ||
                                    (v.boolScripts && lstTypes.Contains("Scripts")) ||
                                    (v.boolTextures && lstTypes.Contains("Skin Textures"))
                                ) &&
                                !vc.deps.Contains(Convert.ToString(v.Name), StringComparer.OrdinalIgnoreCase) &&
                                !lstFolderEx.Contains(Convert.ToString(v.fi.Directory.Name)) &&
                                !lstFolderEx.Contains(Path.GetDirectoryName(v.fi.FullName).Replace(_strVAMdir + @"\AddonPackages\", "")) &&
                                !lstCreatorEx.Contains(Convert.ToString(v.creator))
                             select v;

            foreach (var f in backupvars)
            {
                if (!Directory.Exists(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                }

                if (!File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)))) { File.Move(Convert.ToString(f.fi.FullName), Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))); }
            }

            return GetVarCounts();
        }

        public varCounts BackupSpecVars(System.Windows.Forms.CheckedListBox.CheckedItemCollection lstTypes)
        {
            varconfig vc = GetVarconfig(_strVAMdir + @"\AddonPackages");

            var backupvars = from v in vc.vars
                             where
                                (v.boolAssets && lstTypes.Contains("Assets")) ||
                                (v.boolClothing && lstTypes.Contains("Clothing")) ||
                                (v.boolClothingPreset && lstTypes.Contains("Clothing Presets")) ||
                                (v.boolHair && lstTypes.Contains("Hair")) ||
                                (v.boolHairPreset && lstTypes.Contains("Hair Presets")) ||
                                ((v.boolLooks || v.boolLookPresets) && lstTypes.Contains("Looks")) ||
                                (v.boolMorphs && lstTypes.Contains("Morphs")) ||
                                ((v.boolPoses || v.boolPosePresets) && lstTypes.Contains("Poses")) ||
                                (v.boolScenes && lstTypes.Contains("Scenes")) ||
                                (v.boolSubScenes && lstTypes.Contains("SubScenes")) ||
                                (v.boolScripts && lstTypes.Contains("Scripts")) ||
                                (v.boolTextures && lstTypes.Contains("Skin Textures"))
                             select v;

            foreach (var f in backupvars)
            {
                if (!Directory.Exists(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                }

                if (!File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)))) { File.Move(Convert.ToString(f.fi.FullName), Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))); }
            }

            return GetVarCounts();
        }
        public varCounts BackupSpecVarsEx(System.Windows.Forms.CheckedListBox.CheckedItemCollection lstTypes, System.Windows.Forms.CheckedListBox.CheckedItemCollection lstFolderEx, System.Windows.Forms.CheckedListBox.CheckedItemCollection lstCreatorEx)
        {
            varconfig vc = GetVarconfig(_strVAMdir + @"\AddonPackages");

            var backupvars = from v in vc.vars
                             where
                                (   
                                    (v.boolAssets && lstTypes.Contains("Assets")) ||
                                    (v.boolClothing && lstTypes.Contains("Clothing")) ||
                                    (v.boolClothingPreset && lstTypes.Contains("Clothing Presets")) ||
                                    (v.boolHair && lstTypes.Contains("Hair")) ||
                                    (v.boolHairPreset && lstTypes.Contains("Hair Presets")) ||
                                    ((v.boolLooks || v.boolLookPresets) && lstTypes.Contains("Looks")) ||
                                    (v.boolMorphs && lstTypes.Contains("Morphs")) ||
                                    ((v.boolPoses || v.boolPosePresets) && lstTypes.Contains("Poses")) ||
                                    (v.boolScenes && lstTypes.Contains("Scenes")) ||
                                    (v.boolSubScenes && lstTypes.Contains("SubScenes")) ||
                                    (v.boolScripts && lstTypes.Contains("Scripts")) ||
                                    (v.boolTextures && lstTypes.Contains("Skin Textures"))
                                ) &&
                                !lstFolderEx.Contains(Convert.ToString(v.fi.Directory.Name)) &&
                                !lstFolderEx.Contains(Path.GetDirectoryName(v.fi.FullName).Replace(_strVAMdir + @"\AddonPackages\", "")) &&
                                !lstCreatorEx.Contains(Convert.ToString(v.creator))
                             select v;

            foreach (var f in backupvars)
            {
                if (!Directory.Exists(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)));
                }

                if (!File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir)))) { File.Move(Convert.ToString(f.fi.FullName), Convert.ToString(f.fi.FullName.Replace(_strVAMdir + @"\AddonPackages", _strVAMbackupdir))); }
            }

            return GetVarCounts();
        }

        public varCounts RestoreNeededVars()
        {
            varconfig vc = GetVarconfig(_strVAMdir + @"\AddonPackages");
            varconfig vcbakup = GetVarconfig(_strVAMbackupdir);
            DirectoryInfo diBackup = new DirectoryInfo(_strVAMbackupdir);
            var neededFiles = new List<FileInfo>();
            var lstErrorvars = new List<string>();

            //IEnumerable<FileInfo> neededFiles;
            //neededFiles = diBackup
            //    .GetFiles("*.var", SearchOption.AllDirectories)
            //    .Where(file => vc.deps.Contains(file.Name.Replace(".var", "").Substring(0, file.Name.Replace(".var", "").LastIndexOf(".")), StringComparer.OrdinalIgnoreCase));

            foreach (varfile f in vcbakup.vars)
            {
                try
                {
                    if (vc.deps.Contains(f.Name, StringComparer.OrdinalIgnoreCase))
                    { neededFiles.Add(f.fi); }
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

                vc = GetVarconfig(_strVAMdir + @"\AddonPackages");
                vcbakup = GetVarconfig(_strVAMbackupdir);
                neededFiles = new List<FileInfo>();

                foreach (varfile f in vcbakup.vars)
                {
                    try
                    {
                        if (vc.deps.Contains(f.Name, StringComparer.OrdinalIgnoreCase))
                        { neededFiles.Add(f.fi); }
                    }
                    catch
                    { lstErrorvars.Add(f.fi.Name); }
                }
            }

            //MessageBox.Show("Please manually remove file from VAM/backup folders:" + Environment.NewLine + f.Name, "Skipping Restore file, incorrect .var file naming format.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return GetVarCounts();
        }

        public varCounts RestoreSpecificVars(System.Windows.Forms.CheckedListBox.CheckedItemCollection lstTypes)
        {
            varconfig vc = GetVarconfig(_strVAMbackupdir);

            var backupvars = from v in vc.vars
                             where
                                (v.boolAssets && lstTypes.Contains("Assets")) ||
                                (v.boolClothing && lstTypes.Contains("Clothing")) ||
                                (v.boolClothingPreset && lstTypes.Contains("Clothing Presets")) ||
                                (v.boolHair && lstTypes.Contains("Hair")) ||
                                (v.boolHairPreset && lstTypes.Contains("Hair Presets")) ||
                                ((v.boolLooks || v.boolLookPresets) && lstTypes.Contains("Looks")) ||
                                (v.boolMorphs && lstTypes.Contains("Morphs")) ||
                                ((v.boolPoses || v.boolPosePresets) && lstTypes.Contains("Poses")) ||
                                (v.boolScenes && lstTypes.Contains("Scenes")) ||
                                (v.boolSubScenes && lstTypes.Contains("SubScenes")) ||
                                (v.boolScripts && lstTypes.Contains("Scripts")) ||
                                (v.boolTextures && lstTypes.Contains("Skin Textures"))
                             select v;

            foreach (var f in backupvars)
            {

                if (!Directory.Exists(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")));
                }

                if (!File.Exists(Convert.ToString(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages")))) { File.Move(Convert.ToString(f.fi.FullName), Convert.ToString(f.fi.FullName.Replace(_strVAMbackupdir, _strVAMdir + @"\AddonPackages"))); }
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

            return GetVarCounts();
        }

        public varCounts GetVarCounts()
        {
            varCounts vcount = new varCounts();
            vcount.countVAMvars = Directory.GetFiles(_strVAMdir + @"\AddonPackages", "*.var", SearchOption.AllDirectories).Count();
            vcount.countBackupvars = Directory.GetFiles(_strVAMbackupdir, "*.var", SearchOption.AllDirectories).Count();
            return vcount;
        }

        private varconfig GetVarconfig(string strDir)
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

            foreach (FileInfo fi in diFolder.GetFiles("*.var", SearchOption.AllDirectories))
            {
                vf = new varfile();
                vf.fi = fi;
                boolSkip = false;

                try
                { 
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
                        }

                        if (e.FullName.IndexOf("custom/assets/", 0, StringComparison.CurrentCultureIgnoreCase) > -1)
                        {
                            vf.boolAssets = true;
                        }

                        if (e.FullName.IndexOf("saves/person/appearance/", 0, StringComparison.CurrentCultureIgnoreCase) > -1)
                        {
                            vf.boolLooks = true;
                        }

                        if (e.FullName.IndexOf("custom/atom/person/appearance/", 0, StringComparison.CurrentCultureIgnoreCase) > -1)
                        {
                            vf.boolLookPresets = true;
                        }

                        if (e.FullName.IndexOf("saves/scene/", 0, StringComparison.CurrentCultureIgnoreCase) > -1)
                        {
                            vf.boolScenes = true;
                        }

                        if (e.FullName.IndexOf("custom/subscene/", 0, StringComparison.CurrentCultureIgnoreCase) > -1)
                        {
                            vf.boolSubScenes = true;
                        }

                        if (e.FullName.IndexOf("saves/person/pose/", 0, StringComparison.CurrentCultureIgnoreCase) > -1)
                        {
                            vf.boolPoses = true;
                        }

                        if (e.FullName.IndexOf("custom/atom/person/pose/", 0, StringComparison.CurrentCultureIgnoreCase) > -1)
                        {
                            vf.boolPosePresets = true;
                        }

                        if (e.FullName.IndexOf("custom/hair/", 0, StringComparison.CurrentCultureIgnoreCase) > -1)
                        {
                            vf.boolHair = true;
                        }

                        if (e.FullName.IndexOf("custom/atom/person/hair/", 0, StringComparison.CurrentCultureIgnoreCase) > -1)
                        {
                            vf.boolHairPreset = true;
                        }

                        if (e.FullName.IndexOf("custom/clothing/", 0, StringComparison.CurrentCultureIgnoreCase) > -1)
                        {
                            vf.boolClothing = true;
                        }

                        if (e.FullName.IndexOf("custom/atom/person/clothing/", 0, StringComparison.CurrentCultureIgnoreCase) > -1)
                        {
                            vf.boolClothingPreset = true;
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
                                varMeta? metaJS = JsonSerializer.Deserialize<varMeta>(objReader.ReadToEnd());

                                vf.creator = metaJS.creatorName.Replace(" ","_");
                                vf.Name = metaJS.creatorName.Replace(" ", "_") + "." + metaJS.packageName.Replace(" ", "_");

                                if (metaJS.dependencies != null)
                                {
                                    var dependencies = metaJS.dependencies;
                                    foreach (string dep in dependencies.Keys)
                                    {                                        
                                        if (!lstDepvars.Contains(dep.Split(".")[0].Replace(" ", "_") + "." + dep.Split(".")[1].Replace(" ", "_")))
                                        {
                                            lstDepvars.Add(dep.Split(".")[0].Replace(" ", "_") + "." + dep.Split(".")[1].Replace(" ", "_"));
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

                                if (vf.creator == "")
                                { try { vf.creator = Strings.Left(fi.Name, fi.Name.IndexOf(".")).Replace(" ", "_"); } catch { vf.creator = ""; } }

                                if (vf.Name == "")
                                { try { vf.Name = fi.Name.Replace(".var", "").Replace("." + vf.version, "").Replace(" ", "_"); } catch { vf.Name = ""; } }
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
                    if (latestvars.TryGetValue(vf.creator + "." + vf.Name, out intlatest))
                    {
                        if (vf.version > intlatest)
                        {
                            latestvars[vf.creator + "." + vf.Name] = vf.version;
                        }
                    }
                    else
                    {
                        latestvars.Add(vf.creator + "." + vf.Name, vf.version);
                    }

                    lstVars.Add(vf);
                }
            }

            varconfig vc = new varconfig();
            vc.vars = lstVars;
            vc.deps = lstDepvars;
            vc.latestvars = latestvars;

            if(lstErrorsZipFile.Count > 0) 
            {
                //var message = string.Join(Environment.NewLine, lstErrorsFilename);
                //MessageBox.Show("These .vars have incorrect file names, though should not cause issues:" + Environment.NewLine + message, "Warning: Incorrectly named files.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                var message = string.Join(Environment.NewLine, lstErrorsZipFile);
                MessageBox.Show("Broken/Unreadable .vars were skipped." + Environment.NewLine + "Manually remove or try re-zipping these files:" + Environment.NewLine + message, "Broken/Unreadable .vars Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return vc;
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
            string curFile;

            var lstErrorsFilename = new List<string>();
            var lstErrorsZipFile = new List<string>();

            foreach (FileInfo fi in diFolder.GetFiles("*.var", SearchOption.AllDirectories))
            {
                vf = new varfile();
                vf.fi = fi;

                try
                {
                    vf.version = Convert.ToInt32(fi.Name.Split(".")[fi.Name.Split(".").Length - 2]);
                }
                catch
                {
                    lstErrorsFilename.Add(fi.Name);
                    vf.version = 1;
                }

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
                    if (vf.creator == "")
                    { try { vf.creator = Strings.Left(fi.Name, fi.Name.IndexOf(".")).Replace(" ", "_"); } catch { vf.creator = ""; } }

                    if (vf.Name == "")
                    { try { vf.Name = fi.Name.Replace(".var", "").Replace("." + vf.version, "").Replace(" ", "_"); } catch { vf.Name = ""; } }
                }

                if (latestvars.TryGetValue(vf.creator + "." + vf.Name, out intlatest))
                {
                    if (vf.version > intlatest)
                    {
                        latestvars[vf.creator + "." + vf.Name] = vf.version;
                    }
                }
                else
                {
                    latestvars.Add(vf.creator + "." + vf.Name, vf.version);
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
    }
}
