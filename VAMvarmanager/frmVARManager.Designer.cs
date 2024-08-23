
namespace VAMvarmanager
{
    partial class frmVARManager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnVamfolder = new System.Windows.Forms.Button();
            btnBackupfolder = new System.Windows.Forms.Button();
            txtBackupfolder = new System.Windows.Forms.TextBox();
            txtVamfolder = new System.Windows.Forms.TextBox();
            btnBackupUnref = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            btnRestoreLastConfig = new System.Windows.Forms.Button();
            btnSaveConfig = new System.Windows.Forms.Button();
            btnRestoreConfig = new System.Windows.Forms.Button();
            btnResetSettings = new System.Windows.Forms.Button();
            lblBackupcount = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            lblVamcount = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            btnBackupUnrefSpec = new System.Windows.Forms.Button();
            btnBackupSpec = new System.Windows.Forms.Button();
            btnRestoreSpec = new System.Windows.Forms.Button();
            btnRestoreAll = new System.Windows.Forms.Button();
            gbCreatorEx = new System.Windows.Forms.GroupBox();
            clbCreatorsRestore = new System.Windows.Forms.CheckedListBox();
            clbCreators = new System.Windows.Forms.CheckedListBox();
            cbInvertCreators = new System.Windows.Forms.CheckBox();
            cbAllCreators = new System.Windows.Forms.CheckBox();
            txtCreatorFilter = new System.Windows.Forms.TextBox();
            gbFolderEx = new System.Windows.Forms.GroupBox();
            clbFoldersRestore = new System.Windows.Forms.CheckedListBox();
            clbFolders = new System.Windows.Forms.CheckedListBox();
            cbInvertFolders = new System.Windows.Forms.CheckBox();
            cbAllFolders = new System.Windows.Forms.CheckBox();
            txtFolderFilter = new System.Windows.Forms.TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox5 = new System.Windows.Forms.GroupBox();
            cbIgnoreHidden = new System.Windows.Forms.CheckBox();
            dgvTypes = new System.Windows.Forms.DataGridView();
            Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            OR = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            AND = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            NOT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            groupBox6 = new System.Windows.Forms.GroupBox();
            btnRestoreRef = new System.Windows.Forms.Button();
            groupBox7 = new System.Windows.Forms.GroupBox();
            btnMorphPresets = new System.Windows.Forms.Button();
            btnRevertpreloadmorphs = new System.Windows.Forms.Button();
            btnDisablepreloadmorphs = new System.Windows.Forms.Button();
            btnDisableClothing = new System.Windows.Forms.Button();
            groupBox8 = new System.Windows.Forms.GroupBox();
            gbPresets = new System.Windows.Forms.GroupBox();
            cbSkin = new System.Windows.Forms.CheckBox();
            cbPlugins = new System.Windows.Forms.CheckBox();
            cbMorphs = new System.Windows.Forms.CheckBox();
            cbHair = new System.Windows.Forms.CheckBox();
            cbClothing = new System.Windows.Forms.CheckBox();
            cbAppearance = new System.Windows.Forms.CheckBox();
            cbSavesScene = new System.Windows.Forms.CheckBox();
            toolTipSaves = new System.Windows.Forms.ToolTip(components);
            gbCreatorFilters = new System.Windows.Forms.GroupBox();
            gbFolderFilters = new System.Windows.Forms.GroupBox();
            cbRestoreEx = new System.Windows.Forms.CheckBox();
            cbBackupEx = new System.Windows.Forms.CheckBox();
            btnMoveOldVarVersions = new System.Windows.Forms.Button();
            gbMisc = new System.Windows.Forms.GroupBox();
            sfdVarConfig = new System.Windows.Forms.SaveFileDialog();
            ofdVarConfig = new System.Windows.Forms.OpenFileDialog();
            cbSkipFavorites = new System.Windows.Forms.CheckBox();
            dtpFilter = new System.Windows.Forms.DateTimePicker();
            cbDateFilter = new System.Windows.Forms.CheckBox();
            toolTipDateFilter = new System.Windows.Forms.ToolTip(components);
            cbUIAssist = new System.Windows.Forms.CheckBox();
            btnSaveFilters = new System.Windows.Forms.Button();
            btnLoadFilters = new System.Windows.Forms.Button();
            cbOverwrite = new System.Windows.Forms.CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            gbCreatorEx.SuspendLayout();
            gbFolderEx.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTypes).BeginInit();
            groupBox6.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox8.SuspendLayout();
            gbPresets.SuspendLayout();
            gbCreatorFilters.SuspendLayout();
            gbFolderFilters.SuspendLayout();
            gbMisc.SuspendLayout();
            SuspendLayout();
            // 
            // btnVamfolder
            // 
            btnVamfolder.Location = new System.Drawing.Point(804, 22);
            btnVamfolder.Name = "btnVamfolder";
            btnVamfolder.Size = new System.Drawing.Size(246, 51);
            btnVamfolder.TabIndex = 0;
            btnVamfolder.Text = "Choose VAM Folder";
            btnVamfolder.UseVisualStyleBackColor = true;
            btnVamfolder.Click += btnVamfolder_Click;
            // 
            // btnBackupfolder
            // 
            btnBackupfolder.Location = new System.Drawing.Point(804, 79);
            btnBackupfolder.Name = "btnBackupfolder";
            btnBackupfolder.Size = new System.Drawing.Size(246, 51);
            btnBackupfolder.TabIndex = 1;
            btnBackupfolder.Text = "Choose Backup Folder";
            btnBackupfolder.UseVisualStyleBackColor = true;
            btnBackupfolder.Click += btnBackupfolder_Click;
            // 
            // txtBackupfolder
            // 
            txtBackupfolder.Location = new System.Drawing.Point(330, 52);
            txtBackupfolder.Name = "txtBackupfolder";
            txtBackupfolder.Size = new System.Drawing.Size(445, 23);
            txtBackupfolder.TabIndex = 2;
            // 
            // txtVamfolder
            // 
            txtVamfolder.Location = new System.Drawing.Point(330, 21);
            txtVamfolder.Name = "txtVamfolder";
            txtVamfolder.Size = new System.Drawing.Size(445, 23);
            txtVamfolder.TabIndex = 3;
            // 
            // btnBackupUnref
            // 
            btnBackupUnref.ForeColor = System.Drawing.Color.DarkGreen;
            btnBackupUnref.Location = new System.Drawing.Point(6, 22);
            btnBackupUnref.Name = "btnBackupUnref";
            btnBackupUnref.Size = new System.Drawing.Size(207, 45);
            btnBackupUnref.TabIndex = 4;
            btnBackupUnref.Text = "Backup Unreferenced vars";
            btnBackupUnref.UseVisualStyleBackColor = true;
            btnBackupUnref.Click += btnBackupUnref_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnRestoreLastConfig);
            groupBox1.Controls.Add(btnSaveConfig);
            groupBox1.Controls.Add(btnRestoreConfig);
            groupBox1.Controls.Add(btnResetSettings);
            groupBox1.Controls.Add(lblBackupcount);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(lblVamcount);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtVamfolder);
            groupBox1.Controls.Add(txtBackupfolder);
            groupBox1.Controls.Add(btnBackupfolder);
            groupBox1.Controls.Add(btnVamfolder);
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(1059, 140);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Config";
            // 
            // btnRestoreLastConfig
            // 
            btnRestoreLastConfig.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnRestoreLastConfig.ForeColor = System.Drawing.Color.ForestGreen;
            btnRestoreLastConfig.Location = new System.Drawing.Point(338, 96);
            btnRestoreLastConfig.Name = "btnRestoreLastConfig";
            btnRestoreLastConfig.Size = new System.Drawing.Size(160, 38);
            btnRestoreLastConfig.TabIndex = 15;
            btnRestoreLastConfig.Text = "Restore Last Config\r\n(200 active vars)";
            btnRestoreLastConfig.UseVisualStyleBackColor = true;
            btnRestoreLastConfig.Click += btnRestoreLastConfig_Click;
            // 
            // btnSaveConfig
            // 
            btnSaveConfig.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSaveConfig.ForeColor = System.Drawing.Color.OrangeRed;
            btnSaveConfig.Location = new System.Drawing.Point(6, 96);
            btnSaveConfig.Name = "btnSaveConfig";
            btnSaveConfig.Size = new System.Drawing.Size(160, 38);
            btnSaveConfig.TabIndex = 14;
            btnSaveConfig.Text = "Save var Config";
            btnSaveConfig.UseVisualStyleBackColor = true;
            btnSaveConfig.Click += btnSaveConfig_Click;
            // 
            // btnRestoreConfig
            // 
            btnRestoreConfig.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnRestoreConfig.ForeColor = System.Drawing.Color.OrangeRed;
            btnRestoreConfig.Location = new System.Drawing.Point(172, 96);
            btnRestoreConfig.Name = "btnRestoreConfig";
            btnRestoreConfig.Size = new System.Drawing.Size(160, 38);
            btnRestoreConfig.TabIndex = 13;
            btnRestoreConfig.Text = "Restore var Config";
            btnRestoreConfig.UseVisualStyleBackColor = true;
            btnRestoreConfig.Click += btnRestoreConfig_Click;
            // 
            // btnResetSettings
            // 
            btnResetSettings.Location = new System.Drawing.Point(615, 85);
            btnResetSettings.Name = "btnResetSettings";
            btnResetSettings.Size = new System.Drawing.Size(160, 38);
            btnResetSettings.TabIndex = 12;
            btnResetSettings.Text = "Reset Settings";
            btnResetSettings.UseVisualStyleBackColor = true;
            btnResetSettings.Click += btnResetSettings_Click;
            // 
            // lblBackupcount
            // 
            lblBackupcount.AutoSize = true;
            lblBackupcount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblBackupcount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblBackupcount.Location = new System.Drawing.Point(151, 55);
            lblBackupcount.Name = "lblBackupcount";
            lblBackupcount.Size = new System.Drawing.Size(0, 19);
            lblBackupcount.TabIndex = 10;
            lblBackupcount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(14, 52);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(131, 19);
            label5.TabIndex = 9;
            label5.Text = "var Count Backup:";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVamcount
            // 
            lblVamcount.AutoSize = true;
            lblVamcount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblVamcount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblVamcount.Location = new System.Drawing.Point(151, 21);
            lblVamcount.Name = "lblVamcount";
            lblVamcount.Size = new System.Drawing.Size(0, 19);
            lblVamcount.TabIndex = 8;
            lblVamcount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(32, 22);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(113, 19);
            label3.TabIndex = 6;
            label3.Text = "var Count VAM:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(234, 55);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(85, 15);
            label2.TabIndex = 5;
            label2.Text = "Backup Folder:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(220, 24);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(99, 15);
            label1.TabIndex = 4;
            label1.Text = "VAM Root Folder:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnBackupUnrefSpec);
            groupBox2.Controls.Add(btnBackupSpec);
            groupBox2.Controls.Add(btnBackupUnref);
            groupBox2.Location = new System.Drawing.Point(12, 428);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(219, 180);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Backup";
            // 
            // btnBackupUnrefSpec
            // 
            btnBackupUnrefSpec.ForeColor = System.Drawing.Color.DarkGreen;
            btnBackupUnrefSpec.Location = new System.Drawing.Point(6, 73);
            btnBackupUnrefSpec.Name = "btnBackupUnrefSpec";
            btnBackupUnrefSpec.Size = new System.Drawing.Size(207, 45);
            btnBackupUnrefSpec.TabIndex = 7;
            btnBackupUnrefSpec.Text = "Backup Unreferenced \r\nSpecific-Type vars";
            btnBackupUnrefSpec.UseVisualStyleBackColor = true;
            btnBackupUnrefSpec.Click += btnBackupUnrefSpec_Click;
            // 
            // btnBackupSpec
            // 
            btnBackupSpec.ForeColor = System.Drawing.Color.DarkGreen;
            btnBackupSpec.Location = new System.Drawing.Point(6, 126);
            btnBackupSpec.Name = "btnBackupSpec";
            btnBackupSpec.Size = new System.Drawing.Size(207, 45);
            btnBackupSpec.TabIndex = 6;
            btnBackupSpec.Text = "Backup All \r\nSpecific-Type vars";
            btnBackupSpec.UseVisualStyleBackColor = true;
            btnBackupSpec.Click += btnBackupSpec_Click;
            // 
            // btnRestoreSpec
            // 
            btnRestoreSpec.ForeColor = System.Drawing.Color.DarkBlue;
            btnRestoreSpec.Location = new System.Drawing.Point(6, 73);
            btnRestoreSpec.Name = "btnRestoreSpec";
            btnRestoreSpec.Size = new System.Drawing.Size(207, 45);
            btnRestoreSpec.TabIndex = 7;
            btnRestoreSpec.Text = "Restore All Specific-Type vars";
            btnRestoreSpec.UseVisualStyleBackColor = true;
            btnRestoreSpec.Click += btnRestoreSpec_Click;
            // 
            // btnRestoreAll
            // 
            btnRestoreAll.ForeColor = System.Drawing.Color.DarkBlue;
            btnRestoreAll.Location = new System.Drawing.Point(6, 124);
            btnRestoreAll.Name = "btnRestoreAll";
            btnRestoreAll.Size = new System.Drawing.Size(207, 45);
            btnRestoreAll.TabIndex = 5;
            btnRestoreAll.Text = "Restore All vars";
            btnRestoreAll.UseVisualStyleBackColor = true;
            btnRestoreAll.Click += btnRestoreAll_Click;
            // 
            // gbCreatorEx
            // 
            gbCreatorEx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            gbCreatorEx.Controls.Add(clbCreatorsRestore);
            gbCreatorEx.Controls.Add(clbCreators);
            gbCreatorEx.Location = new System.Drawing.Point(240, 255);
            gbCreatorEx.Name = "gbCreatorEx";
            gbCreatorEx.Size = new System.Drawing.Size(274, 536);
            gbCreatorEx.TabIndex = 7;
            gbCreatorEx.TabStop = false;
            gbCreatorEx.Text = "Creator Exceptions";
            // 
            // clbCreatorsRestore
            // 
            clbCreatorsRestore.CheckOnClick = true;
            clbCreatorsRestore.Dock = System.Windows.Forms.DockStyle.Fill;
            clbCreatorsRestore.FormattingEnabled = true;
            clbCreatorsRestore.Location = new System.Drawing.Point(3, 19);
            clbCreatorsRestore.Name = "clbCreatorsRestore";
            clbCreatorsRestore.Size = new System.Drawing.Size(268, 514);
            clbCreatorsRestore.TabIndex = 9;
            // 
            // clbCreators
            // 
            clbCreators.CheckOnClick = true;
            clbCreators.Dock = System.Windows.Forms.DockStyle.Fill;
            clbCreators.FormattingEnabled = true;
            clbCreators.Location = new System.Drawing.Point(3, 19);
            clbCreators.Name = "clbCreators";
            clbCreators.Size = new System.Drawing.Size(268, 514);
            clbCreators.TabIndex = 8;
            // 
            // cbInvertCreators
            // 
            cbInvertCreators.AutoSize = true;
            cbInvertCreators.Location = new System.Drawing.Point(52, 22);
            cbInvertCreators.Name = "cbInvertCreators";
            cbInvertCreators.Size = new System.Drawing.Size(56, 19);
            cbInvertCreators.TabIndex = 15;
            cbInvertCreators.Text = "Invert";
            cbInvertCreators.UseVisualStyleBackColor = true;
            cbInvertCreators.CheckedChanged += cbInvertCreators_CheckedChanged;
            // 
            // cbAllCreators
            // 
            cbAllCreators.AutoSize = true;
            cbAllCreators.Location = new System.Drawing.Point(6, 22);
            cbAllCreators.Name = "cbAllCreators";
            cbAllCreators.Size = new System.Drawing.Size(40, 19);
            cbAllCreators.TabIndex = 14;
            cbAllCreators.Text = "All";
            cbAllCreators.UseVisualStyleBackColor = true;
            cbAllCreators.CheckedChanged += cbAllCreators_CheckedChanged;
            // 
            // txtCreatorFilter
            // 
            txtCreatorFilter.Location = new System.Drawing.Point(6, 47);
            txtCreatorFilter.Name = "txtCreatorFilter";
            txtCreatorFilter.Size = new System.Drawing.Size(265, 23);
            txtCreatorFilter.TabIndex = 12;
            txtCreatorFilter.TextChanged += txtCreatorFilter_TextChanged;
            // 
            // gbFolderEx
            // 
            gbFolderEx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gbFolderEx.Controls.Add(clbFoldersRestore);
            gbFolderEx.Controls.Add(clbFolders);
            gbFolderEx.Location = new System.Drawing.Point(520, 255);
            gbFolderEx.Name = "gbFolderEx";
            gbFolderEx.Size = new System.Drawing.Size(273, 536);
            gbFolderEx.TabIndex = 9;
            gbFolderEx.TabStop = false;
            gbFolderEx.Text = "Folder Exceptions";
            // 
            // clbFoldersRestore
            // 
            clbFoldersRestore.CheckOnClick = true;
            clbFoldersRestore.Dock = System.Windows.Forms.DockStyle.Fill;
            clbFoldersRestore.FormattingEnabled = true;
            clbFoldersRestore.HorizontalScrollbar = true;
            clbFoldersRestore.Location = new System.Drawing.Point(3, 19);
            clbFoldersRestore.Name = "clbFoldersRestore";
            clbFoldersRestore.Size = new System.Drawing.Size(267, 514);
            clbFoldersRestore.TabIndex = 9;
            // 
            // clbFolders
            // 
            clbFolders.CheckOnClick = true;
            clbFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            clbFolders.FormattingEnabled = true;
            clbFolders.HorizontalScrollbar = true;
            clbFolders.Location = new System.Drawing.Point(3, 19);
            clbFolders.Name = "clbFolders";
            clbFolders.Size = new System.Drawing.Size(267, 514);
            clbFolders.TabIndex = 8;
            // 
            // cbInvertFolders
            // 
            cbInvertFolders.AutoSize = true;
            cbInvertFolders.Location = new System.Drawing.Point(52, 22);
            cbInvertFolders.Name = "cbInvertFolders";
            cbInvertFolders.Size = new System.Drawing.Size(56, 19);
            cbInvertFolders.TabIndex = 17;
            cbInvertFolders.Text = "Invert";
            cbInvertFolders.UseVisualStyleBackColor = true;
            cbInvertFolders.CheckedChanged += cbInvertFolders_CheckedChanged;
            // 
            // cbAllFolders
            // 
            cbAllFolders.AutoSize = true;
            cbAllFolders.Location = new System.Drawing.Point(6, 22);
            cbAllFolders.Name = "cbAllFolders";
            cbAllFolders.Size = new System.Drawing.Size(40, 19);
            cbAllFolders.TabIndex = 16;
            cbAllFolders.Text = "All";
            cbAllFolders.UseVisualStyleBackColor = true;
            cbAllFolders.CheckedChanged += cbAllFolders_CheckedChanged;
            // 
            // txtFolderFilter
            // 
            txtFolderFilter.Location = new System.Drawing.Point(6, 47);
            txtFolderFilter.Name = "txtFolderFilter";
            txtFolderFilter.Size = new System.Drawing.Size(264, 23);
            txtFolderFilter.TabIndex = 13;
            txtFolderFilter.TextChanged += txtFolderFilter_TextChanged;
            // 
            // groupBox5
            // 
            groupBox5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            groupBox5.Controls.Add(cbIgnoreHidden);
            groupBox5.Controls.Add(dgvTypes);
            groupBox5.Location = new System.Drawing.Point(800, 446);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(271, 298);
            groupBox5.TabIndex = 10;
            groupBox5.TabStop = false;
            groupBox5.Text = "Specific-Type Backup/Restore";
            // 
            // cbIgnoreHidden
            // 
            cbIgnoreHidden.AutoSize = true;
            cbIgnoreHidden.Location = new System.Drawing.Point(6, 22);
            cbIgnoreHidden.Name = "cbIgnoreHidden";
            cbIgnoreHidden.Size = new System.Drawing.Size(165, 19);
            cbIgnoreHidden.TabIndex = 19;
            cbIgnoreHidden.Text = "Don't Count Hidden Items";
            cbIgnoreHidden.UseVisualStyleBackColor = true;
            // 
            // dgvTypes
            // 
            dgvTypes.AllowUserToAddRows = false;
            dgvTypes.AllowUserToDeleteRows = false;
            dgvTypes.AllowUserToResizeRows = false;
            dgvTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Type, OR, AND, NOT });
            dgvTypes.Location = new System.Drawing.Point(6, 52);
            dgvTypes.MultiSelect = false;
            dgvTypes.Name = "dgvTypes";
            dgvTypes.ReadOnly = true;
            dgvTypes.RowHeadersVisible = false;
            dgvTypes.RowTemplate.Height = 25;
            dgvTypes.Size = new System.Drawing.Size(262, 237);
            dgvTypes.TabIndex = 14;
            dgvTypes.CellClick += dgvTypes_CellClick;
            dgvTypes.ColumnHeaderMouseClick += dgvTypes_ColumnHeaderMouseClick;
            // 
            // Type
            // 
            Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Type.HeaderText = "Type";
            Type.Name = "Type";
            Type.ReadOnly = true;
            // 
            // OR
            // 
            OR.HeaderText = "OR";
            OR.Name = "OR";
            OR.ReadOnly = true;
            OR.Width = 40;
            // 
            // AND
            // 
            AND.HeaderText = "AND";
            AND.Name = "AND";
            AND.ReadOnly = true;
            AND.Width = 40;
            // 
            // NOT
            // 
            NOT.HeaderText = "NOT";
            NOT.Name = "NOT";
            NOT.ReadOnly = true;
            NOT.Width = 40;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(btnRestoreRef);
            groupBox6.Controls.Add(btnRestoreAll);
            groupBox6.Controls.Add(btnRestoreSpec);
            groupBox6.Location = new System.Drawing.Point(12, 614);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new System.Drawing.Size(219, 174);
            groupBox6.TabIndex = 11;
            groupBox6.TabStop = false;
            groupBox6.Text = "Restore";
            // 
            // btnRestoreRef
            // 
            btnRestoreRef.ForeColor = System.Drawing.Color.DarkBlue;
            btnRestoreRef.Location = new System.Drawing.Point(6, 22);
            btnRestoreRef.Name = "btnRestoreRef";
            btnRestoreRef.Size = new System.Drawing.Size(207, 45);
            btnRestoreRef.TabIndex = 8;
            btnRestoreRef.Text = "Restore All Referenced vars";
            btnRestoreRef.UseVisualStyleBackColor = true;
            btnRestoreRef.Click += btnRestoreRef_Click;
            // 
            // groupBox7
            // 
            groupBox7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            groupBox7.Controls.Add(btnMorphPresets);
            groupBox7.Controls.Add(btnRevertpreloadmorphs);
            groupBox7.Controls.Add(btnDisablepreloadmorphs);
            groupBox7.Location = new System.Drawing.Point(800, 180);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new System.Drawing.Size(271, 181);
            groupBox7.TabIndex = 12;
            groupBox7.TabStop = false;
            groupBox7.Text = "Morphs";
            // 
            // btnMorphPresets
            // 
            btnMorphPresets.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnMorphPresets.ForeColor = System.Drawing.Color.BlueViolet;
            btnMorphPresets.Location = new System.Drawing.Point(9, 126);
            btnMorphPresets.Name = "btnMorphPresets";
            btnMorphPresets.Size = new System.Drawing.Size(259, 46);
            btnMorphPresets.TabIndex = 15;
            btnMorphPresets.Text = "Morph Preset Maker";
            btnMorphPresets.UseVisualStyleBackColor = true;
            btnMorphPresets.Click += btnMorphPresets_Click;
            // 
            // btnRevertpreloadmorphs
            // 
            btnRevertpreloadmorphs.ForeColor = System.Drawing.Color.BlueViolet;
            btnRevertpreloadmorphs.Location = new System.Drawing.Point(6, 75);
            btnRevertpreloadmorphs.Name = "btnRevertpreloadmorphs";
            btnRevertpreloadmorphs.Size = new System.Drawing.Size(259, 46);
            btnRevertpreloadmorphs.TabIndex = 14;
            btnRevertpreloadmorphs.Text = "Revert Preload Morphs Settings";
            btnRevertpreloadmorphs.UseVisualStyleBackColor = true;
            btnRevertpreloadmorphs.Click += btnRevertpreloadmorphs_Click;
            // 
            // btnDisablepreloadmorphs
            // 
            btnDisablepreloadmorphs.ForeColor = System.Drawing.Color.BlueViolet;
            btnDisablepreloadmorphs.Location = new System.Drawing.Point(6, 25);
            btnDisablepreloadmorphs.Name = "btnDisablepreloadmorphs";
            btnDisablepreloadmorphs.Size = new System.Drawing.Size(259, 46);
            btnDisablepreloadmorphs.TabIndex = 13;
            btnDisablepreloadmorphs.Text = "Disable Preload Morphs";
            btnDisablepreloadmorphs.UseVisualStyleBackColor = true;
            btnDisablepreloadmorphs.Click += btnDisablepreloadmorphs_Click;
            // 
            // btnDisableClothing
            // 
            btnDisableClothing.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnDisableClothing.ForeColor = System.Drawing.Color.DarkRed;
            btnDisableClothing.Location = new System.Drawing.Point(6, 21);
            btnDisableClothing.Name = "btnDisableClothing";
            btnDisableClothing.Size = new System.Drawing.Size(259, 46);
            btnDisableClothing.TabIndex = 13;
            btnDisableClothing.Text = "Duplicate Items Resolver";
            btnDisableClothing.UseVisualStyleBackColor = true;
            btnDisableClothing.Click += btnDisableClothing_Click;
            // 
            // groupBox8
            // 
            groupBox8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            groupBox8.Controls.Add(btnDisableClothing);
            groupBox8.Location = new System.Drawing.Point(800, 367);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new System.Drawing.Size(271, 73);
            groupBox8.TabIndex = 15;
            groupBox8.TabStop = false;
            groupBox8.Text = "Duplicate Clothing/Hair Resolver";
            // 
            // gbPresets
            // 
            gbPresets.Controls.Add(cbSkin);
            gbPresets.Controls.Add(cbPlugins);
            gbPresets.Controls.Add(cbMorphs);
            gbPresets.Controls.Add(cbHair);
            gbPresets.Controls.Add(cbClothing);
            gbPresets.Controls.Add(cbAppearance);
            gbPresets.Location = new System.Drawing.Point(12, 205);
            gbPresets.Name = "gbPresets";
            gbPresets.Size = new System.Drawing.Size(219, 105);
            gbPresets.TabIndex = 16;
            gbPresets.TabStop = false;
            gbPresets.Text = "Scan Local Presets for References";
            // 
            // cbSkin
            // 
            cbSkin.AutoSize = true;
            cbSkin.Location = new System.Drawing.Point(6, 72);
            cbSkin.Name = "cbSkin";
            cbSkin.Size = new System.Drawing.Size(48, 19);
            cbSkin.TabIndex = 6;
            cbSkin.Text = "Skin";
            cbSkin.UseVisualStyleBackColor = true;
            // 
            // cbPlugins
            // 
            cbPlugins.AutoSize = true;
            cbPlugins.Location = new System.Drawing.Point(124, 72);
            cbPlugins.Name = "cbPlugins";
            cbPlugins.Size = new System.Drawing.Size(65, 19);
            cbPlugins.TabIndex = 5;
            cbPlugins.Text = "Plugins";
            cbPlugins.UseVisualStyleBackColor = true;
            // 
            // cbMorphs
            // 
            cbMorphs.AutoSize = true;
            cbMorphs.Location = new System.Drawing.Point(124, 47);
            cbMorphs.Name = "cbMorphs";
            cbMorphs.Size = new System.Drawing.Size(67, 19);
            cbMorphs.TabIndex = 4;
            cbMorphs.Text = "Morphs";
            cbMorphs.UseVisualStyleBackColor = true;
            // 
            // cbHair
            // 
            cbHair.AutoSize = true;
            cbHair.Location = new System.Drawing.Point(6, 47);
            cbHair.Name = "cbHair";
            cbHair.Size = new System.Drawing.Size(48, 19);
            cbHair.TabIndex = 3;
            cbHair.Text = "Hair";
            cbHair.UseVisualStyleBackColor = true;
            // 
            // cbClothing
            // 
            cbClothing.AutoSize = true;
            cbClothing.Location = new System.Drawing.Point(124, 22);
            cbClothing.Name = "cbClothing";
            cbClothing.Size = new System.Drawing.Size(72, 19);
            cbClothing.TabIndex = 2;
            cbClothing.Text = "Clothing";
            cbClothing.UseVisualStyleBackColor = true;
            // 
            // cbAppearance
            // 
            cbAppearance.AutoSize = true;
            cbAppearance.Location = new System.Drawing.Point(6, 22);
            cbAppearance.Name = "cbAppearance";
            cbAppearance.Size = new System.Drawing.Size(89, 19);
            cbAppearance.TabIndex = 1;
            cbAppearance.Text = "Appearence";
            cbAppearance.UseVisualStyleBackColor = true;
            // 
            // cbSavesScene
            // 
            cbSavesScene.AutoSize = true;
            cbSavesScene.Location = new System.Drawing.Point(15, 158);
            cbSavesScene.Name = "cbSavesScene";
            cbSavesScene.Size = new System.Drawing.Size(197, 19);
            cbSavesScene.TabIndex = 0;
            cbSavesScene.Text = "Scan Saves\\Scene for References";
            cbSavesScene.UseVisualStyleBackColor = true;
            cbSavesScene.MouseHover += cbSavesScene_MouseHover;
            // 
            // gbCreatorFilters
            // 
            gbCreatorFilters.Controls.Add(txtCreatorFilter);
            gbCreatorFilters.Controls.Add(cbAllCreators);
            gbCreatorFilters.Controls.Add(cbInvertCreators);
            gbCreatorFilters.Location = new System.Drawing.Point(240, 180);
            gbCreatorFilters.Name = "gbCreatorFilters";
            gbCreatorFilters.Size = new System.Drawing.Size(274, 77);
            gbCreatorFilters.TabIndex = 9;
            gbCreatorFilters.TabStop = false;
            gbCreatorFilters.Text = "Creator Filters";
            // 
            // gbFolderFilters
            // 
            gbFolderFilters.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gbFolderFilters.Controls.Add(txtFolderFilter);
            gbFolderFilters.Controls.Add(cbInvertFolders);
            gbFolderFilters.Controls.Add(cbAllFolders);
            gbFolderFilters.Location = new System.Drawing.Point(520, 180);
            gbFolderFilters.Name = "gbFolderFilters";
            gbFolderFilters.Size = new System.Drawing.Size(274, 77);
            gbFolderFilters.TabIndex = 16;
            gbFolderFilters.TabStop = false;
            gbFolderFilters.Text = "Folder Filters";
            // 
            // cbRestoreEx
            // 
            cbRestoreEx.AutoSize = true;
            cbRestoreEx.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            cbRestoreEx.ForeColor = System.Drawing.Color.DarkBlue;
            cbRestoreEx.Location = new System.Drawing.Point(382, 158);
            cbRestoreEx.Name = "cbRestoreEx";
            cbRestoreEx.Size = new System.Drawing.Size(133, 19);
            cbRestoreEx.TabIndex = 18;
            cbRestoreEx.Text = "Restore Exceptions";
            cbRestoreEx.UseVisualStyleBackColor = true;
            cbRestoreEx.CheckedChanged += cbRestoreEx_CheckedChanged;
            // 
            // cbBackupEx
            // 
            cbBackupEx.AutoSize = true;
            cbBackupEx.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            cbBackupEx.ForeColor = System.Drawing.Color.DarkGreen;
            cbBackupEx.Location = new System.Drawing.Point(246, 158);
            cbBackupEx.Name = "cbBackupEx";
            cbBackupEx.Size = new System.Drawing.Size(130, 19);
            cbBackupEx.TabIndex = 11;
            cbBackupEx.Text = "Backup Exceptions";
            cbBackupEx.UseVisualStyleBackColor = true;
            cbBackupEx.CheckedChanged += cbBackupEx_CheckedChanged;
            // 
            // btnMoveOldVarVersions
            // 
            btnMoveOldVarVersions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnMoveOldVarVersions.ForeColor = System.Drawing.SystemColors.ControlText;
            btnMoveOldVarVersions.Location = new System.Drawing.Point(6, 22);
            btnMoveOldVarVersions.Name = "btnMoveOldVarVersions";
            btnMoveOldVarVersions.Size = new System.Drawing.Size(207, 45);
            btnMoveOldVarVersions.TabIndex = 19;
            btnMoveOldVarVersions.Text = "Move Old Versions of vars\r\n(Unreferenced)";
            btnMoveOldVarVersions.UseVisualStyleBackColor = true;
            btnMoveOldVarVersions.Click += btnMoveOldVarVersions_Click;
            // 
            // gbMisc
            // 
            gbMisc.Controls.Add(btnMoveOldVarVersions);
            gbMisc.Location = new System.Drawing.Point(12, 346);
            gbMisc.Name = "gbMisc";
            gbMisc.Size = new System.Drawing.Size(219, 76);
            gbMisc.TabIndex = 20;
            gbMisc.TabStop = false;
            gbMisc.Text = "Misc";
            // 
            // cbSkipFavorites
            // 
            cbSkipFavorites.AutoSize = true;
            cbSkipFavorites.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            cbSkipFavorites.ForeColor = System.Drawing.Color.Firebrick;
            cbSkipFavorites.Location = new System.Drawing.Point(526, 158);
            cbSkipFavorites.Name = "cbSkipFavorites";
            cbSkipFavorites.Size = new System.Drawing.Size(104, 19);
            cbSkipFavorites.TabIndex = 21;
            cbSkipFavorites.Text = "Skip Favorites";
            cbSkipFavorites.UseVisualStyleBackColor = true;
            cbSkipFavorites.CheckedChanged += cbSkipFavorites_CheckedChanged;
            // 
            // dtpFilter
            // 
            dtpFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpFilter.Location = new System.Drawing.Point(973, 158);
            dtpFilter.MaxDate = new System.DateTime(2022, 6, 22, 0, 0, 0, 0);
            dtpFilter.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            dtpFilter.Name = "dtpFilter";
            dtpFilter.Size = new System.Drawing.Size(98, 23);
            dtpFilter.TabIndex = 22;
            dtpFilter.Value = new System.DateTime(2022, 6, 22, 0, 0, 0, 0);
            // 
            // cbDateFilter
            // 
            cbDateFilter.AutoSize = true;
            cbDateFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            cbDateFilter.ForeColor = System.Drawing.SystemColors.MenuText;
            cbDateFilter.Location = new System.Drawing.Point(882, 159);
            cbDateFilter.Name = "cbDateFilter";
            cbDateFilter.Size = new System.Drawing.Size(85, 19);
            cbDateFilter.TabIndex = 23;
            cbDateFilter.Text = "Date Filter";
            cbDateFilter.UseVisualStyleBackColor = true;
            cbDateFilter.CheckedChanged += cbDateFilter_CheckedChanged;
            cbDateFilter.MouseHover += cbDateFilter_MouseHover;
            // 
            // cbUIAssist
            // 
            cbUIAssist.AutoSize = true;
            cbUIAssist.Location = new System.Drawing.Point(15, 182);
            cbUIAssist.Name = "cbUIAssist";
            cbUIAssist.Size = new System.Drawing.Size(215, 19);
            cbUIAssist.TabIndex = 24;
            cbUIAssist.Text = "Scan UIAssist Profiles for References";
            cbUIAssist.UseVisualStyleBackColor = true;
            // 
            // btnSaveFilters
            // 
            btnSaveFilters.ForeColor = System.Drawing.Color.DarkBlue;
            btnSaveFilters.Location = new System.Drawing.Point(636, 153);
            btnSaveFilters.Name = "btnSaveFilters";
            btnSaveFilters.Size = new System.Drawing.Size(101, 27);
            btnSaveFilters.TabIndex = 16;
            btnSaveFilters.Text = "Save Filters";
            btnSaveFilters.UseVisualStyleBackColor = true;
            btnSaveFilters.Click += btnSaveFilters_Click;
            // 
            // btnLoadFilters
            // 
            btnLoadFilters.ForeColor = System.Drawing.Color.DarkGreen;
            btnLoadFilters.Location = new System.Drawing.Point(743, 153);
            btnLoadFilters.Name = "btnLoadFilters";
            btnLoadFilters.Size = new System.Drawing.Size(101, 27);
            btnLoadFilters.TabIndex = 25;
            btnLoadFilters.Text = "Load Filters";
            btnLoadFilters.UseVisualStyleBackColor = true;
            btnLoadFilters.Click += btnLoadFilters_Click;
            // 
            // cbOverwrite
            // 
            cbOverwrite.AutoSize = true;
            cbOverwrite.Location = new System.Drawing.Point(18, 321);
            cbOverwrite.Name = "cbOverwrite";
            cbOverwrite.Size = new System.Drawing.Size(145, 19);
            cbOverwrite.TabIndex = 26;
            cbOverwrite.Text = "Overwrite existing files";
            cbOverwrite.UseVisualStyleBackColor = true;
            // 
            // frmVARManager
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1080, 794);
            Controls.Add(cbOverwrite);
            Controls.Add(btnLoadFilters);
            Controls.Add(btnSaveFilters);
            Controls.Add(cbUIAssist);
            Controls.Add(cbDateFilter);
            Controls.Add(dtpFilter);
            Controls.Add(cbSkipFavorites);
            Controls.Add(gbMisc);
            Controls.Add(cbRestoreEx);
            Controls.Add(gbFolderFilters);
            Controls.Add(cbBackupEx);
            Controls.Add(gbCreatorFilters);
            Controls.Add(gbPresets);
            Controls.Add(cbSavesScene);
            Controls.Add(groupBox8);
            Controls.Add(groupBox7);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(gbFolderEx);
            Controls.Add(gbCreatorEx);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            MinimumSize = new System.Drawing.Size(1096, 786);
            Name = "frmVARManager";
            Text = "VAR Manager";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            gbCreatorEx.ResumeLayout(false);
            gbFolderEx.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTypes).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            gbPresets.ResumeLayout(false);
            gbPresets.PerformLayout();
            gbCreatorFilters.ResumeLayout(false);
            gbCreatorFilters.PerformLayout();
            gbFolderFilters.ResumeLayout(false);
            gbFolderFilters.PerformLayout();
            gbMisc.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button btnVamfolder;
        private System.Windows.Forms.Button btnBackupfolder;
        private System.Windows.Forms.TextBox txtBackupfolder;
        private System.Windows.Forms.TextBox txtVamfolder;
        private System.Windows.Forms.Button btnBackupUnref;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRestoreAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRestoreSpec;
        private System.Windows.Forms.GroupBox gbCreatorEx;
        private System.Windows.Forms.CheckedListBox clbCreators;
        private System.Windows.Forms.GroupBox gbFolderEx;
        private System.Windows.Forms.CheckedListBox clbFolders;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblBackupcount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblVamcount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBackupSpec;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnBackupUnrefSpec;
        private System.Windows.Forms.Button btnRestoreRef;
        private System.Windows.Forms.Button btnResetSettings;
        private System.Windows.Forms.TextBox txtCreatorFilter;
        private System.Windows.Forms.TextBox txtFolderFilter;
        private System.Windows.Forms.CheckBox cbInvertCreators;
        private System.Windows.Forms.CheckBox cbAllCreators;
        private System.Windows.Forms.CheckBox cbInvertFolders;
        private System.Windows.Forms.CheckBox cbAllFolders;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnDisablepreloadmorphs;
        private System.Windows.Forms.Button btnRevertpreloadmorphs;
        private System.Windows.Forms.Button btnDisableClothing;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnMorphPresets;
        private System.Windows.Forms.GroupBox gbPresets;
        private System.Windows.Forms.CheckBox cbAppearance;
        private System.Windows.Forms.CheckBox cbSavesScene;
        private System.Windows.Forms.CheckBox cbSkin;
        private System.Windows.Forms.CheckBox cbPlugins;
        private System.Windows.Forms.CheckBox cbMorphs;
        private System.Windows.Forms.CheckBox cbHair;
        private System.Windows.Forms.CheckBox cbClothing;
        private System.Windows.Forms.ToolTip toolTipSaves;
        private System.Windows.Forms.GroupBox gbCreatorFilters;
        private System.Windows.Forms.GroupBox gbFolderFilters;
        private System.Windows.Forms.CheckedListBox clbCreatorsRestore;
        private System.Windows.Forms.CheckedListBox clbFoldersRestore;
        private System.Windows.Forms.CheckBox cbRestoreEx;
        private System.Windows.Forms.CheckBox cbBackupEx;
        private System.Windows.Forms.Button btnMoveOldVarVersions;
        private System.Windows.Forms.GroupBox gbMisc;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Button btnRestoreConfig;
        private System.Windows.Forms.SaveFileDialog sfdVarConfig;
        private System.Windows.Forms.OpenFileDialog ofdVarConfig;
        private System.Windows.Forms.CheckBox cbSkipFavorites;
        private System.Windows.Forms.DateTimePicker dtpFilter;
        private System.Windows.Forms.CheckBox cbDateFilter;
        private System.Windows.Forms.Button btnRestoreLastConfig;
        private System.Windows.Forms.ToolTip toolTipDateFilter;
        private System.Windows.Forms.DataGridView dgvTypes;
        private System.Windows.Forms.CheckBox cbIgnoreHidden;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OR;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AND;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NOT;
        private System.Windows.Forms.CheckBox cbUIAssist;
        private System.Windows.Forms.Button btnSaveFilters;
        private System.Windows.Forms.Button btnLoadFilters;
        private System.Windows.Forms.CheckBox cbOverwrite;
    }
}

