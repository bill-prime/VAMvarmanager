﻿
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
            this.components = new System.ComponentModel.Container();
            this.btnVamfolder = new System.Windows.Forms.Button();
            this.btnBackupfolder = new System.Windows.Forms.Button();
            this.txtBackupfolder = new System.Windows.Forms.TextBox();
            this.txtVamfolder = new System.Windows.Forms.TextBox();
            this.btnBackupUnref = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRestoreLastConfig = new System.Windows.Forms.Button();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnRestoreConfig = new System.Windows.Forms.Button();
            this.btnResetSettings = new System.Windows.Forms.Button();
            this.lblBackupcount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblVamcount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBackupUnrefSpec = new System.Windows.Forms.Button();
            this.btnBackupSpec = new System.Windows.Forms.Button();
            this.btnRestoreSpec = new System.Windows.Forms.Button();
            this.btnRestoreAll = new System.Windows.Forms.Button();
            this.gbCreatorEx = new System.Windows.Forms.GroupBox();
            this.clbCreatorsRestore = new System.Windows.Forms.CheckedListBox();
            this.clbCreators = new System.Windows.Forms.CheckedListBox();
            this.cbInvertCreators = new System.Windows.Forms.CheckBox();
            this.cbAllCreators = new System.Windows.Forms.CheckBox();
            this.txtCreatorFilter = new System.Windows.Forms.TextBox();
            this.gbFolderEx = new System.Windows.Forms.GroupBox();
            this.clbFoldersRestore = new System.Windows.Forms.CheckedListBox();
            this.clbFolders = new System.Windows.Forms.CheckedListBox();
            this.cbInvertFolders = new System.Windows.Forms.CheckBox();
            this.cbAllFolders = new System.Windows.Forms.CheckBox();
            this.txtFolderFilter = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbIgnoreHidden = new System.Windows.Forms.CheckBox();
            this.dgvTypes = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OR = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AND = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NOT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnRestoreRef = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnMorphPresets = new System.Windows.Forms.Button();
            this.btnRevertpreloadmorphs = new System.Windows.Forms.Button();
            this.btnDisablepreloadmorphs = new System.Windows.Forms.Button();
            this.btnDisableClothing = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.gbPresets = new System.Windows.Forms.GroupBox();
            this.cbSkin = new System.Windows.Forms.CheckBox();
            this.cbPlugins = new System.Windows.Forms.CheckBox();
            this.cbMorphs = new System.Windows.Forms.CheckBox();
            this.cbHair = new System.Windows.Forms.CheckBox();
            this.cbClothing = new System.Windows.Forms.CheckBox();
            this.cbAppearance = new System.Windows.Forms.CheckBox();
            this.cbSavesScene = new System.Windows.Forms.CheckBox();
            this.toolTipSaves = new System.Windows.Forms.ToolTip(this.components);
            this.gbCreatorFilters = new System.Windows.Forms.GroupBox();
            this.gbFolderFilters = new System.Windows.Forms.GroupBox();
            this.cbRestoreEx = new System.Windows.Forms.CheckBox();
            this.cbBackupEx = new System.Windows.Forms.CheckBox();
            this.btnMoveOldVarVersions = new System.Windows.Forms.Button();
            this.gbMisc = new System.Windows.Forms.GroupBox();
            this.sfdVarConfig = new System.Windows.Forms.SaveFileDialog();
            this.ofdVarConfig = new System.Windows.Forms.OpenFileDialog();
            this.cbSkipFavorites = new System.Windows.Forms.CheckBox();
            this.dtpFilter = new System.Windows.Forms.DateTimePicker();
            this.cbDateFilter = new System.Windows.Forms.CheckBox();
            this.toolTipDateFilter = new System.Windows.Forms.ToolTip(this.components);
            this.cbUIAssist = new System.Windows.Forms.CheckBox();
            this.btnSaveFilters = new System.Windows.Forms.Button();
            this.btnLoadFilters = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbCreatorEx.SuspendLayout();
            this.gbFolderEx.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypes)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.gbPresets.SuspendLayout();
            this.gbCreatorFilters.SuspendLayout();
            this.gbFolderFilters.SuspendLayout();
            this.gbMisc.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVamfolder
            // 
            this.btnVamfolder.Location = new System.Drawing.Point(804, 22);
            this.btnVamfolder.Name = "btnVamfolder";
            this.btnVamfolder.Size = new System.Drawing.Size(246, 51);
            this.btnVamfolder.TabIndex = 0;
            this.btnVamfolder.Text = "Choose VAM Folder";
            this.btnVamfolder.UseVisualStyleBackColor = true;
            this.btnVamfolder.Click += new System.EventHandler(this.btnVamfolder_Click);
            // 
            // btnBackupfolder
            // 
            this.btnBackupfolder.Location = new System.Drawing.Point(804, 79);
            this.btnBackupfolder.Name = "btnBackupfolder";
            this.btnBackupfolder.Size = new System.Drawing.Size(246, 51);
            this.btnBackupfolder.TabIndex = 1;
            this.btnBackupfolder.Text = "Choose Backup Folder";
            this.btnBackupfolder.UseVisualStyleBackColor = true;
            this.btnBackupfolder.Click += new System.EventHandler(this.btnBackupfolder_Click);
            // 
            // txtBackupfolder
            // 
            this.txtBackupfolder.Location = new System.Drawing.Point(330, 52);
            this.txtBackupfolder.Name = "txtBackupfolder";
            this.txtBackupfolder.Size = new System.Drawing.Size(445, 23);
            this.txtBackupfolder.TabIndex = 2;
            // 
            // txtVamfolder
            // 
            this.txtVamfolder.Location = new System.Drawing.Point(330, 21);
            this.txtVamfolder.Name = "txtVamfolder";
            this.txtVamfolder.Size = new System.Drawing.Size(445, 23);
            this.txtVamfolder.TabIndex = 3;
            // 
            // btnBackupUnref
            // 
            this.btnBackupUnref.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnBackupUnref.Location = new System.Drawing.Point(6, 22);
            this.btnBackupUnref.Name = "btnBackupUnref";
            this.btnBackupUnref.Size = new System.Drawing.Size(207, 45);
            this.btnBackupUnref.TabIndex = 4;
            this.btnBackupUnref.Text = "Backup Unreferenced vars";
            this.btnBackupUnref.UseVisualStyleBackColor = true;
            this.btnBackupUnref.Click += new System.EventHandler(this.btnBackupUnref_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRestoreLastConfig);
            this.groupBox1.Controls.Add(this.btnSaveConfig);
            this.groupBox1.Controls.Add(this.btnRestoreConfig);
            this.groupBox1.Controls.Add(this.btnResetSettings);
            this.groupBox1.Controls.Add(this.lblBackupcount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblVamcount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtVamfolder);
            this.groupBox1.Controls.Add(this.txtBackupfolder);
            this.groupBox1.Controls.Add(this.btnBackupfolder);
            this.groupBox1.Controls.Add(this.btnVamfolder);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1059, 140);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Config";
            // 
            // btnRestoreLastConfig
            // 
            this.btnRestoreLastConfig.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRestoreLastConfig.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnRestoreLastConfig.Location = new System.Drawing.Point(338, 96);
            this.btnRestoreLastConfig.Name = "btnRestoreLastConfig";
            this.btnRestoreLastConfig.Size = new System.Drawing.Size(160, 38);
            this.btnRestoreLastConfig.TabIndex = 15;
            this.btnRestoreLastConfig.Text = "Restore Last Config\r\n(200 active vars)";
            this.btnRestoreLastConfig.UseVisualStyleBackColor = true;
            this.btnRestoreLastConfig.Click += new System.EventHandler(this.btnRestoreLastConfig_Click);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSaveConfig.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnSaveConfig.Location = new System.Drawing.Point(6, 96);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(160, 38);
            this.btnSaveConfig.TabIndex = 14;
            this.btnSaveConfig.Text = "Save var Config";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // btnRestoreConfig
            // 
            this.btnRestoreConfig.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRestoreConfig.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnRestoreConfig.Location = new System.Drawing.Point(172, 96);
            this.btnRestoreConfig.Name = "btnRestoreConfig";
            this.btnRestoreConfig.Size = new System.Drawing.Size(160, 38);
            this.btnRestoreConfig.TabIndex = 13;
            this.btnRestoreConfig.Text = "Restore var Config";
            this.btnRestoreConfig.UseVisualStyleBackColor = true;
            this.btnRestoreConfig.Click += new System.EventHandler(this.btnRestoreConfig_Click);
            // 
            // btnResetSettings
            // 
            this.btnResetSettings.Location = new System.Drawing.Point(615, 85);
            this.btnResetSettings.Name = "btnResetSettings";
            this.btnResetSettings.Size = new System.Drawing.Size(160, 38);
            this.btnResetSettings.TabIndex = 12;
            this.btnResetSettings.Text = "Reset Settings";
            this.btnResetSettings.UseVisualStyleBackColor = true;
            this.btnResetSettings.Click += new System.EventHandler(this.btnResetSettings_Click);
            // 
            // lblBackupcount
            // 
            this.lblBackupcount.AutoSize = true;
            this.lblBackupcount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBackupcount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBackupcount.Location = new System.Drawing.Point(151, 55);
            this.lblBackupcount.Name = "lblBackupcount";
            this.lblBackupcount.Size = new System.Drawing.Size(0, 19);
            this.lblBackupcount.TabIndex = 10;
            this.lblBackupcount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(14, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "var Count Backup:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVamcount
            // 
            this.lblVamcount.AutoSize = true;
            this.lblVamcount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblVamcount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVamcount.Location = new System.Drawing.Point(151, 21);
            this.lblVamcount.Name = "lblVamcount";
            this.lblVamcount.Size = new System.Drawing.Size(0, 19);
            this.lblVamcount.TabIndex = 8;
            this.lblVamcount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(32, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "var Count VAM:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Backup Folder:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "VAM Root Folder:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBackupUnrefSpec);
            this.groupBox2.Controls.Add(this.btnBackupSpec);
            this.groupBox2.Controls.Add(this.btnBackupUnref);
            this.groupBox2.Location = new System.Drawing.Point(12, 387);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 180);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Backup";
            // 
            // btnBackupUnrefSpec
            // 
            this.btnBackupUnrefSpec.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnBackupUnrefSpec.Location = new System.Drawing.Point(6, 73);
            this.btnBackupUnrefSpec.Name = "btnBackupUnrefSpec";
            this.btnBackupUnrefSpec.Size = new System.Drawing.Size(207, 45);
            this.btnBackupUnrefSpec.TabIndex = 7;
            this.btnBackupUnrefSpec.Text = "Backup Unreferenced \r\nSpecific-Type vars";
            this.btnBackupUnrefSpec.UseVisualStyleBackColor = true;
            this.btnBackupUnrefSpec.Click += new System.EventHandler(this.btnBackupUnrefSpec_Click);
            // 
            // btnBackupSpec
            // 
            this.btnBackupSpec.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnBackupSpec.Location = new System.Drawing.Point(6, 126);
            this.btnBackupSpec.Name = "btnBackupSpec";
            this.btnBackupSpec.Size = new System.Drawing.Size(207, 45);
            this.btnBackupSpec.TabIndex = 6;
            this.btnBackupSpec.Text = "Backup All \r\nSpecific-Type vars";
            this.btnBackupSpec.UseVisualStyleBackColor = true;
            this.btnBackupSpec.Click += new System.EventHandler(this.btnBackupSpec_Click);
            // 
            // btnRestoreSpec
            // 
            this.btnRestoreSpec.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnRestoreSpec.Location = new System.Drawing.Point(6, 73);
            this.btnRestoreSpec.Name = "btnRestoreSpec";
            this.btnRestoreSpec.Size = new System.Drawing.Size(207, 45);
            this.btnRestoreSpec.TabIndex = 7;
            this.btnRestoreSpec.Text = "Restore All Specific-Type vars";
            this.btnRestoreSpec.UseVisualStyleBackColor = true;
            this.btnRestoreSpec.Click += new System.EventHandler(this.btnRestoreSpec_Click);
            // 
            // btnRestoreAll
            // 
            this.btnRestoreAll.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnRestoreAll.Location = new System.Drawing.Point(6, 124);
            this.btnRestoreAll.Name = "btnRestoreAll";
            this.btnRestoreAll.Size = new System.Drawing.Size(207, 45);
            this.btnRestoreAll.TabIndex = 5;
            this.btnRestoreAll.Text = "Restore All vars";
            this.btnRestoreAll.UseVisualStyleBackColor = true;
            this.btnRestoreAll.Click += new System.EventHandler(this.btnRestoreAll_Click);
            // 
            // gbCreatorEx
            // 
            this.gbCreatorEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbCreatorEx.Controls.Add(this.clbCreatorsRestore);
            this.gbCreatorEx.Controls.Add(this.clbCreators);
            this.gbCreatorEx.Location = new System.Drawing.Point(240, 255);
            this.gbCreatorEx.Name = "gbCreatorEx";
            this.gbCreatorEx.Size = new System.Drawing.Size(274, 489);
            this.gbCreatorEx.TabIndex = 7;
            this.gbCreatorEx.TabStop = false;
            this.gbCreatorEx.Text = "Creator Exceptions";
            // 
            // clbCreatorsRestore
            // 
            this.clbCreatorsRestore.CheckOnClick = true;
            this.clbCreatorsRestore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbCreatorsRestore.FormattingEnabled = true;
            this.clbCreatorsRestore.Location = new System.Drawing.Point(3, 19);
            this.clbCreatorsRestore.Name = "clbCreatorsRestore";
            this.clbCreatorsRestore.Size = new System.Drawing.Size(268, 467);
            this.clbCreatorsRestore.TabIndex = 9;
            // 
            // clbCreators
            // 
            this.clbCreators.CheckOnClick = true;
            this.clbCreators.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbCreators.FormattingEnabled = true;
            this.clbCreators.Location = new System.Drawing.Point(3, 19);
            this.clbCreators.Name = "clbCreators";
            this.clbCreators.Size = new System.Drawing.Size(268, 467);
            this.clbCreators.TabIndex = 8;
            // 
            // cbInvertCreators
            // 
            this.cbInvertCreators.AutoSize = true;
            this.cbInvertCreators.Location = new System.Drawing.Point(52, 22);
            this.cbInvertCreators.Name = "cbInvertCreators";
            this.cbInvertCreators.Size = new System.Drawing.Size(56, 19);
            this.cbInvertCreators.TabIndex = 15;
            this.cbInvertCreators.Text = "Invert";
            this.cbInvertCreators.UseVisualStyleBackColor = true;
            this.cbInvertCreators.CheckedChanged += new System.EventHandler(this.cbInvertCreators_CheckedChanged);
            // 
            // cbAllCreators
            // 
            this.cbAllCreators.AutoSize = true;
            this.cbAllCreators.Location = new System.Drawing.Point(6, 22);
            this.cbAllCreators.Name = "cbAllCreators";
            this.cbAllCreators.Size = new System.Drawing.Size(40, 19);
            this.cbAllCreators.TabIndex = 14;
            this.cbAllCreators.Text = "All";
            this.cbAllCreators.UseVisualStyleBackColor = true;
            this.cbAllCreators.CheckedChanged += new System.EventHandler(this.cbAllCreators_CheckedChanged);
            // 
            // txtCreatorFilter
            // 
            this.txtCreatorFilter.Location = new System.Drawing.Point(6, 47);
            this.txtCreatorFilter.Name = "txtCreatorFilter";
            this.txtCreatorFilter.Size = new System.Drawing.Size(265, 23);
            this.txtCreatorFilter.TabIndex = 12;
            this.txtCreatorFilter.TextChanged += new System.EventHandler(this.txtCreatorFilter_TextChanged);
            // 
            // gbFolderEx
            // 
            this.gbFolderEx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFolderEx.Controls.Add(this.clbFoldersRestore);
            this.gbFolderEx.Controls.Add(this.clbFolders);
            this.gbFolderEx.Location = new System.Drawing.Point(520, 255);
            this.gbFolderEx.Name = "gbFolderEx";
            this.gbFolderEx.Size = new System.Drawing.Size(273, 489);
            this.gbFolderEx.TabIndex = 9;
            this.gbFolderEx.TabStop = false;
            this.gbFolderEx.Text = "Folder Exceptions";
            // 
            // clbFoldersRestore
            // 
            this.clbFoldersRestore.CheckOnClick = true;
            this.clbFoldersRestore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbFoldersRestore.FormattingEnabled = true;
            this.clbFoldersRestore.HorizontalScrollbar = true;
            this.clbFoldersRestore.Location = new System.Drawing.Point(3, 19);
            this.clbFoldersRestore.Name = "clbFoldersRestore";
            this.clbFoldersRestore.Size = new System.Drawing.Size(267, 467);
            this.clbFoldersRestore.TabIndex = 9;
            // 
            // clbFolders
            // 
            this.clbFolders.CheckOnClick = true;
            this.clbFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbFolders.FormattingEnabled = true;
            this.clbFolders.HorizontalScrollbar = true;
            this.clbFolders.Location = new System.Drawing.Point(3, 19);
            this.clbFolders.Name = "clbFolders";
            this.clbFolders.Size = new System.Drawing.Size(267, 467);
            this.clbFolders.TabIndex = 8;
            // 
            // cbInvertFolders
            // 
            this.cbInvertFolders.AutoSize = true;
            this.cbInvertFolders.Location = new System.Drawing.Point(52, 22);
            this.cbInvertFolders.Name = "cbInvertFolders";
            this.cbInvertFolders.Size = new System.Drawing.Size(56, 19);
            this.cbInvertFolders.TabIndex = 17;
            this.cbInvertFolders.Text = "Invert";
            this.cbInvertFolders.UseVisualStyleBackColor = true;
            this.cbInvertFolders.CheckedChanged += new System.EventHandler(this.cbInvertFolders_CheckedChanged);
            // 
            // cbAllFolders
            // 
            this.cbAllFolders.AutoSize = true;
            this.cbAllFolders.Location = new System.Drawing.Point(6, 22);
            this.cbAllFolders.Name = "cbAllFolders";
            this.cbAllFolders.Size = new System.Drawing.Size(40, 19);
            this.cbAllFolders.TabIndex = 16;
            this.cbAllFolders.Text = "All";
            this.cbAllFolders.UseVisualStyleBackColor = true;
            this.cbAllFolders.CheckedChanged += new System.EventHandler(this.cbAllFolders_CheckedChanged);
            // 
            // txtFolderFilter
            // 
            this.txtFolderFilter.Location = new System.Drawing.Point(6, 47);
            this.txtFolderFilter.Name = "txtFolderFilter";
            this.txtFolderFilter.Size = new System.Drawing.Size(264, 23);
            this.txtFolderFilter.TabIndex = 13;
            this.txtFolderFilter.TextChanged += new System.EventHandler(this.txtFolderFilter_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.cbIgnoreHidden);
            this.groupBox5.Controls.Add(this.dgvTypes);
            this.groupBox5.Location = new System.Drawing.Point(800, 446);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(271, 298);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Specific-Type Backup/Restore";
            // 
            // cbIgnoreHidden
            // 
            this.cbIgnoreHidden.AutoSize = true;
            this.cbIgnoreHidden.Location = new System.Drawing.Point(6, 22);
            this.cbIgnoreHidden.Name = "cbIgnoreHidden";
            this.cbIgnoreHidden.Size = new System.Drawing.Size(165, 19);
            this.cbIgnoreHidden.TabIndex = 19;
            this.cbIgnoreHidden.Text = "Don\'t Count Hidden Items";
            this.cbIgnoreHidden.UseVisualStyleBackColor = true;
            // 
            // dgvTypes
            // 
            this.dgvTypes.AllowUserToAddRows = false;
            this.dgvTypes.AllowUserToDeleteRows = false;
            this.dgvTypes.AllowUserToResizeRows = false;
            this.dgvTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.OR,
            this.AND,
            this.NOT});
            this.dgvTypes.Location = new System.Drawing.Point(6, 52);
            this.dgvTypes.MultiSelect = false;
            this.dgvTypes.Name = "dgvTypes";
            this.dgvTypes.ReadOnly = true;
            this.dgvTypes.RowHeadersVisible = false;
            this.dgvTypes.RowTemplate.Height = 25;
            this.dgvTypes.Size = new System.Drawing.Size(262, 237);
            this.dgvTypes.TabIndex = 14;
            this.dgvTypes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTypes_CellClick);
            this.dgvTypes.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTypes_ColumnHeaderMouseClick);
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // OR
            // 
            this.OR.HeaderText = "OR";
            this.OR.Name = "OR";
            this.OR.ReadOnly = true;
            this.OR.Width = 40;
            // 
            // AND
            // 
            this.AND.HeaderText = "AND";
            this.AND.Name = "AND";
            this.AND.ReadOnly = true;
            this.AND.Width = 40;
            // 
            // NOT
            // 
            this.NOT.HeaderText = "NOT";
            this.NOT.Name = "NOT";
            this.NOT.ReadOnly = true;
            this.NOT.Width = 40;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnRestoreRef);
            this.groupBox6.Controls.Add(this.btnRestoreAll);
            this.groupBox6.Controls.Add(this.btnRestoreSpec);
            this.groupBox6.Location = new System.Drawing.Point(12, 567);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(219, 174);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Restore";
            // 
            // btnRestoreRef
            // 
            this.btnRestoreRef.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnRestoreRef.Location = new System.Drawing.Point(6, 22);
            this.btnRestoreRef.Name = "btnRestoreRef";
            this.btnRestoreRef.Size = new System.Drawing.Size(207, 45);
            this.btnRestoreRef.TabIndex = 8;
            this.btnRestoreRef.Text = "Restore All Referenced vars";
            this.btnRestoreRef.UseVisualStyleBackColor = true;
            this.btnRestoreRef.Click += new System.EventHandler(this.btnRestoreRef_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.btnMorphPresets);
            this.groupBox7.Controls.Add(this.btnRevertpreloadmorphs);
            this.groupBox7.Controls.Add(this.btnDisablepreloadmorphs);
            this.groupBox7.Location = new System.Drawing.Point(800, 180);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(271, 181);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Morphs";
            // 
            // btnMorphPresets
            // 
            this.btnMorphPresets.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMorphPresets.ForeColor = System.Drawing.Color.BlueViolet;
            this.btnMorphPresets.Location = new System.Drawing.Point(9, 126);
            this.btnMorphPresets.Name = "btnMorphPresets";
            this.btnMorphPresets.Size = new System.Drawing.Size(259, 46);
            this.btnMorphPresets.TabIndex = 15;
            this.btnMorphPresets.Text = "Morph Preset Maker";
            this.btnMorphPresets.UseVisualStyleBackColor = true;
            this.btnMorphPresets.Click += new System.EventHandler(this.btnMorphPresets_Click);
            // 
            // btnRevertpreloadmorphs
            // 
            this.btnRevertpreloadmorphs.ForeColor = System.Drawing.Color.BlueViolet;
            this.btnRevertpreloadmorphs.Location = new System.Drawing.Point(6, 75);
            this.btnRevertpreloadmorphs.Name = "btnRevertpreloadmorphs";
            this.btnRevertpreloadmorphs.Size = new System.Drawing.Size(259, 46);
            this.btnRevertpreloadmorphs.TabIndex = 14;
            this.btnRevertpreloadmorphs.Text = "Revert Preload Morphs Settings";
            this.btnRevertpreloadmorphs.UseVisualStyleBackColor = true;
            this.btnRevertpreloadmorphs.Click += new System.EventHandler(this.btnRevertpreloadmorphs_Click);
            // 
            // btnDisablepreloadmorphs
            // 
            this.btnDisablepreloadmorphs.ForeColor = System.Drawing.Color.BlueViolet;
            this.btnDisablepreloadmorphs.Location = new System.Drawing.Point(6, 25);
            this.btnDisablepreloadmorphs.Name = "btnDisablepreloadmorphs";
            this.btnDisablepreloadmorphs.Size = new System.Drawing.Size(259, 46);
            this.btnDisablepreloadmorphs.TabIndex = 13;
            this.btnDisablepreloadmorphs.Text = "Disable Preload Morphs";
            this.btnDisablepreloadmorphs.UseVisualStyleBackColor = true;
            this.btnDisablepreloadmorphs.Click += new System.EventHandler(this.btnDisablepreloadmorphs_Click);
            // 
            // btnDisableClothing
            // 
            this.btnDisableClothing.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDisableClothing.ForeColor = System.Drawing.Color.DarkRed;
            this.btnDisableClothing.Location = new System.Drawing.Point(6, 21);
            this.btnDisableClothing.Name = "btnDisableClothing";
            this.btnDisableClothing.Size = new System.Drawing.Size(259, 46);
            this.btnDisableClothing.TabIndex = 13;
            this.btnDisableClothing.Text = "Duplicate Items Resolver";
            this.btnDisableClothing.UseVisualStyleBackColor = true;
            this.btnDisableClothing.Click += new System.EventHandler(this.btnDisableClothing_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.btnDisableClothing);
            this.groupBox8.Location = new System.Drawing.Point(800, 367);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(271, 73);
            this.groupBox8.TabIndex = 15;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Duplicate Clothing/Hair Resolver";
            // 
            // gbPresets
            // 
            this.gbPresets.Controls.Add(this.cbSkin);
            this.gbPresets.Controls.Add(this.cbPlugins);
            this.gbPresets.Controls.Add(this.cbMorphs);
            this.gbPresets.Controls.Add(this.cbHair);
            this.gbPresets.Controls.Add(this.cbClothing);
            this.gbPresets.Controls.Add(this.cbAppearance);
            this.gbPresets.Location = new System.Drawing.Point(12, 205);
            this.gbPresets.Name = "gbPresets";
            this.gbPresets.Size = new System.Drawing.Size(219, 105);
            this.gbPresets.TabIndex = 16;
            this.gbPresets.TabStop = false;
            this.gbPresets.Text = "Scan Local Presets for References";
            // 
            // cbSkin
            // 
            this.cbSkin.AutoSize = true;
            this.cbSkin.Location = new System.Drawing.Point(6, 72);
            this.cbSkin.Name = "cbSkin";
            this.cbSkin.Size = new System.Drawing.Size(48, 19);
            this.cbSkin.TabIndex = 6;
            this.cbSkin.Text = "Skin";
            this.cbSkin.UseVisualStyleBackColor = true;
            // 
            // cbPlugins
            // 
            this.cbPlugins.AutoSize = true;
            this.cbPlugins.Location = new System.Drawing.Point(124, 72);
            this.cbPlugins.Name = "cbPlugins";
            this.cbPlugins.Size = new System.Drawing.Size(65, 19);
            this.cbPlugins.TabIndex = 5;
            this.cbPlugins.Text = "Plugins";
            this.cbPlugins.UseVisualStyleBackColor = true;
            // 
            // cbMorphs
            // 
            this.cbMorphs.AutoSize = true;
            this.cbMorphs.Location = new System.Drawing.Point(124, 47);
            this.cbMorphs.Name = "cbMorphs";
            this.cbMorphs.Size = new System.Drawing.Size(67, 19);
            this.cbMorphs.TabIndex = 4;
            this.cbMorphs.Text = "Morphs";
            this.cbMorphs.UseVisualStyleBackColor = true;
            // 
            // cbHair
            // 
            this.cbHair.AutoSize = true;
            this.cbHair.Location = new System.Drawing.Point(6, 47);
            this.cbHair.Name = "cbHair";
            this.cbHair.Size = new System.Drawing.Size(48, 19);
            this.cbHair.TabIndex = 3;
            this.cbHair.Text = "Hair";
            this.cbHair.UseVisualStyleBackColor = true;
            // 
            // cbClothing
            // 
            this.cbClothing.AutoSize = true;
            this.cbClothing.Location = new System.Drawing.Point(124, 22);
            this.cbClothing.Name = "cbClothing";
            this.cbClothing.Size = new System.Drawing.Size(72, 19);
            this.cbClothing.TabIndex = 2;
            this.cbClothing.Text = "Clothing";
            this.cbClothing.UseVisualStyleBackColor = true;
            // 
            // cbAppearance
            // 
            this.cbAppearance.AutoSize = true;
            this.cbAppearance.Location = new System.Drawing.Point(6, 22);
            this.cbAppearance.Name = "cbAppearance";
            this.cbAppearance.Size = new System.Drawing.Size(89, 19);
            this.cbAppearance.TabIndex = 1;
            this.cbAppearance.Text = "Appearence";
            this.cbAppearance.UseVisualStyleBackColor = true;
            // 
            // cbSavesScene
            // 
            this.cbSavesScene.AutoSize = true;
            this.cbSavesScene.Location = new System.Drawing.Point(15, 158);
            this.cbSavesScene.Name = "cbSavesScene";
            this.cbSavesScene.Size = new System.Drawing.Size(197, 19);
            this.cbSavesScene.TabIndex = 0;
            this.cbSavesScene.Text = "Scan Saves\\Scene for References";
            this.cbSavesScene.UseVisualStyleBackColor = true;
            this.cbSavesScene.MouseHover += new System.EventHandler(this.cbSavesScene_MouseHover);
            // 
            // gbCreatorFilters
            // 
            this.gbCreatorFilters.Controls.Add(this.txtCreatorFilter);
            this.gbCreatorFilters.Controls.Add(this.cbAllCreators);
            this.gbCreatorFilters.Controls.Add(this.cbInvertCreators);
            this.gbCreatorFilters.Location = new System.Drawing.Point(240, 180);
            this.gbCreatorFilters.Name = "gbCreatorFilters";
            this.gbCreatorFilters.Size = new System.Drawing.Size(274, 77);
            this.gbCreatorFilters.TabIndex = 9;
            this.gbCreatorFilters.TabStop = false;
            this.gbCreatorFilters.Text = "Creator Filters";
            // 
            // gbFolderFilters
            // 
            this.gbFolderFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFolderFilters.Controls.Add(this.txtFolderFilter);
            this.gbFolderFilters.Controls.Add(this.cbInvertFolders);
            this.gbFolderFilters.Controls.Add(this.cbAllFolders);
            this.gbFolderFilters.Location = new System.Drawing.Point(520, 180);
            this.gbFolderFilters.Name = "gbFolderFilters";
            this.gbFolderFilters.Size = new System.Drawing.Size(274, 77);
            this.gbFolderFilters.TabIndex = 16;
            this.gbFolderFilters.TabStop = false;
            this.gbFolderFilters.Text = "Folder Filters";
            // 
            // cbRestoreEx
            // 
            this.cbRestoreEx.AutoSize = true;
            this.cbRestoreEx.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbRestoreEx.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbRestoreEx.Location = new System.Drawing.Point(382, 158);
            this.cbRestoreEx.Name = "cbRestoreEx";
            this.cbRestoreEx.Size = new System.Drawing.Size(133, 19);
            this.cbRestoreEx.TabIndex = 18;
            this.cbRestoreEx.Text = "Restore Exceptions";
            this.cbRestoreEx.UseVisualStyleBackColor = true;
            this.cbRestoreEx.CheckedChanged += new System.EventHandler(this.cbRestoreEx_CheckedChanged);
            // 
            // cbBackupEx
            // 
            this.cbBackupEx.AutoSize = true;
            this.cbBackupEx.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbBackupEx.ForeColor = System.Drawing.Color.DarkGreen;
            this.cbBackupEx.Location = new System.Drawing.Point(246, 158);
            this.cbBackupEx.Name = "cbBackupEx";
            this.cbBackupEx.Size = new System.Drawing.Size(130, 19);
            this.cbBackupEx.TabIndex = 11;
            this.cbBackupEx.Text = "Backup Exceptions";
            this.cbBackupEx.UseVisualStyleBackColor = true;
            this.cbBackupEx.CheckedChanged += new System.EventHandler(this.cbBackupEx_CheckedChanged);
            // 
            // btnMoveOldVarVersions
            // 
            this.btnMoveOldVarVersions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMoveOldVarVersions.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMoveOldVarVersions.Location = new System.Drawing.Point(6, 22);
            this.btnMoveOldVarVersions.Name = "btnMoveOldVarVersions";
            this.btnMoveOldVarVersions.Size = new System.Drawing.Size(207, 45);
            this.btnMoveOldVarVersions.TabIndex = 19;
            this.btnMoveOldVarVersions.Text = "Move Old Versions of vars\r\n(Unreferenced)";
            this.btnMoveOldVarVersions.UseVisualStyleBackColor = true;
            this.btnMoveOldVarVersions.Click += new System.EventHandler(this.btnMoveOldVarVersions_Click);
            // 
            // gbMisc
            // 
            this.gbMisc.Controls.Add(this.btnMoveOldVarVersions);
            this.gbMisc.Location = new System.Drawing.Point(12, 310);
            this.gbMisc.Name = "gbMisc";
            this.gbMisc.Size = new System.Drawing.Size(219, 76);
            this.gbMisc.TabIndex = 20;
            this.gbMisc.TabStop = false;
            this.gbMisc.Text = "Misc";
            // 
            // cbSkipFavorites
            // 
            this.cbSkipFavorites.AutoSize = true;
            this.cbSkipFavorites.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbSkipFavorites.ForeColor = System.Drawing.Color.Firebrick;
            this.cbSkipFavorites.Location = new System.Drawing.Point(526, 158);
            this.cbSkipFavorites.Name = "cbSkipFavorites";
            this.cbSkipFavorites.Size = new System.Drawing.Size(104, 19);
            this.cbSkipFavorites.TabIndex = 21;
            this.cbSkipFavorites.Text = "Skip Favorites";
            this.cbSkipFavorites.UseVisualStyleBackColor = true;
            this.cbSkipFavorites.CheckedChanged += new System.EventHandler(this.cbSkipFavorites_CheckedChanged);
            // 
            // dtpFilter
            // 
            this.dtpFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilter.Location = new System.Drawing.Point(973, 158);
            this.dtpFilter.MaxDate = new System.DateTime(2022, 6, 22, 0, 0, 0, 0);
            this.dtpFilter.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dtpFilter.Name = "dtpFilter";
            this.dtpFilter.Size = new System.Drawing.Size(98, 23);
            this.dtpFilter.TabIndex = 22;
            this.dtpFilter.Value = new System.DateTime(2022, 6, 22, 0, 0, 0, 0);
            // 
            // cbDateFilter
            // 
            this.cbDateFilter.AutoSize = true;
            this.cbDateFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbDateFilter.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cbDateFilter.Location = new System.Drawing.Point(882, 159);
            this.cbDateFilter.Name = "cbDateFilter";
            this.cbDateFilter.Size = new System.Drawing.Size(85, 19);
            this.cbDateFilter.TabIndex = 23;
            this.cbDateFilter.Text = "Date Filter";
            this.cbDateFilter.UseVisualStyleBackColor = true;
            this.cbDateFilter.CheckedChanged += new System.EventHandler(this.cbDateFilter_CheckedChanged);
            this.cbDateFilter.MouseHover += new System.EventHandler(this.cbDateFilter_MouseHover);
            // 
            // cbUIAssist
            // 
            this.cbUIAssist.AutoSize = true;
            this.cbUIAssist.Location = new System.Drawing.Point(15, 182);
            this.cbUIAssist.Name = "cbUIAssist";
            this.cbUIAssist.Size = new System.Drawing.Size(215, 19);
            this.cbUIAssist.TabIndex = 24;
            this.cbUIAssist.Text = "Scan UIAssist Profiles for References";
            this.cbUIAssist.UseVisualStyleBackColor = true;
            // 
            // btnSaveFilters
            // 
            this.btnSaveFilters.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSaveFilters.Location = new System.Drawing.Point(636, 153);
            this.btnSaveFilters.Name = "btnSaveFilters";
            this.btnSaveFilters.Size = new System.Drawing.Size(101, 27);
            this.btnSaveFilters.TabIndex = 16;
            this.btnSaveFilters.Text = "Save Filters";
            this.btnSaveFilters.UseVisualStyleBackColor = true;
            this.btnSaveFilters.Click += new System.EventHandler(this.btnSaveFilters_Click);
            // 
            // btnLoadFilters
            // 
            this.btnLoadFilters.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnLoadFilters.Location = new System.Drawing.Point(743, 153);
            this.btnLoadFilters.Name = "btnLoadFilters";
            this.btnLoadFilters.Size = new System.Drawing.Size(101, 27);
            this.btnLoadFilters.TabIndex = 25;
            this.btnLoadFilters.Text = "Load Filters";
            this.btnLoadFilters.UseVisualStyleBackColor = true;
            this.btnLoadFilters.Click += new System.EventHandler(this.btnLoadFilters_Click);
            // 
            // frmVARManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 747);
            this.Controls.Add(this.btnLoadFilters);
            this.Controls.Add(this.btnSaveFilters);
            this.Controls.Add(this.cbUIAssist);
            this.Controls.Add(this.cbDateFilter);
            this.Controls.Add(this.dtpFilter);
            this.Controls.Add(this.cbSkipFavorites);
            this.Controls.Add(this.gbMisc);
            this.Controls.Add(this.cbRestoreEx);
            this.Controls.Add(this.gbFolderFilters);
            this.Controls.Add(this.cbBackupEx);
            this.Controls.Add(this.gbCreatorFilters);
            this.Controls.Add(this.gbPresets);
            this.Controls.Add(this.cbSavesScene);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.gbFolderEx);
            this.Controls.Add(this.gbCreatorEx);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1096, 786);
            this.Name = "frmVARManager";
            this.Text = "VAR Manager";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.gbCreatorEx.ResumeLayout(false);
            this.gbFolderEx.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypes)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.gbPresets.ResumeLayout(false);
            this.gbPresets.PerformLayout();
            this.gbCreatorFilters.ResumeLayout(false);
            this.gbCreatorFilters.PerformLayout();
            this.gbFolderFilters.ResumeLayout(false);
            this.gbFolderFilters.PerformLayout();
            this.gbMisc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

