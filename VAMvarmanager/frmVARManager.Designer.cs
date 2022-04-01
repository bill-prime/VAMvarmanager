
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
            this.btnVamfolder = new System.Windows.Forms.Button();
            this.btnBackupfolder = new System.Windows.Forms.Button();
            this.txtBackupfolder = new System.Windows.Forms.TextBox();
            this.txtVamfolder = new System.Windows.Forms.TextBox();
            this.btnBackupUnref = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnResetSettings = new System.Windows.Forms.Button();
            this.cbEx = new System.Windows.Forms.CheckBox();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbInvertCreators = new System.Windows.Forms.CheckBox();
            this.cbAllCreators = new System.Windows.Forms.CheckBox();
            this.txtCreatorFilter = new System.Windows.Forms.TextBox();
            this.clbCreators = new System.Windows.Forms.CheckedListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbInvertFolders = new System.Windows.Forms.CheckBox();
            this.cbAllFolders = new System.Windows.Forms.CheckBox();
            this.txtFolderFilter = new System.Windows.Forms.TextBox();
            this.clbFolders = new System.Windows.Forms.CheckedListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbInvertSpec = new System.Windows.Forms.CheckBox();
            this.cbAllSpec = new System.Windows.Forms.CheckBox();
            this.clbTypes = new System.Windows.Forms.CheckedListBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnRestoreRef = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            this.btnBackupUnref.Size = new System.Drawing.Size(207, 51);
            this.btnBackupUnref.TabIndex = 4;
            this.btnBackupUnref.Text = "Backup Unreferenced vars";
            this.btnBackupUnref.UseVisualStyleBackColor = true;
            this.btnBackupUnref.Click += new System.EventHandler(this.btnBackupUnref_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnResetSettings);
            this.groupBox1.Controls.Add(this.cbEx);
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
            // cbEx
            // 
            this.cbEx.AutoSize = true;
            this.cbEx.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbEx.Location = new System.Drawing.Point(6, 111);
            this.cbEx.Name = "cbEx";
            this.cbEx.Size = new System.Drawing.Size(86, 19);
            this.cbEx.TabIndex = 11;
            this.cbEx.Text = "Exceptions";
            this.cbEx.UseVisualStyleBackColor = true;
            this.cbEx.CheckedChanged += new System.EventHandler(this.cbEx_CheckedChanged);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 198);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Backup";
            // 
            // btnBackupUnrefSpec
            // 
            this.btnBackupUnrefSpec.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnBackupUnrefSpec.Location = new System.Drawing.Point(6, 79);
            this.btnBackupUnrefSpec.Name = "btnBackupUnrefSpec";
            this.btnBackupUnrefSpec.Size = new System.Drawing.Size(207, 51);
            this.btnBackupUnrefSpec.TabIndex = 7;
            this.btnBackupUnrefSpec.Text = "Backup Unreferenced \r\nSpecific-Type vars";
            this.btnBackupUnrefSpec.UseVisualStyleBackColor = true;
            this.btnBackupUnrefSpec.Click += new System.EventHandler(this.btnBackupUnrefSpec_Click);
            // 
            // btnBackupSpec
            // 
            this.btnBackupSpec.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnBackupSpec.Location = new System.Drawing.Point(6, 136);
            this.btnBackupSpec.Name = "btnBackupSpec";
            this.btnBackupSpec.Size = new System.Drawing.Size(207, 51);
            this.btnBackupSpec.TabIndex = 6;
            this.btnBackupSpec.Text = "Backup All \r\nSpecific-Type vars";
            this.btnBackupSpec.UseVisualStyleBackColor = true;
            this.btnBackupSpec.Click += new System.EventHandler(this.btnBackupSpec_Click);
            // 
            // btnRestoreSpec
            // 
            this.btnRestoreSpec.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnRestoreSpec.Location = new System.Drawing.Point(6, 79);
            this.btnRestoreSpec.Name = "btnRestoreSpec";
            this.btnRestoreSpec.Size = new System.Drawing.Size(207, 51);
            this.btnRestoreSpec.TabIndex = 7;
            this.btnRestoreSpec.Text = "Restore All Specific-Type vars";
            this.btnRestoreSpec.UseVisualStyleBackColor = true;
            this.btnRestoreSpec.Click += new System.EventHandler(this.btnRestoreSpec_Click);
            // 
            // btnRestoreAll
            // 
            this.btnRestoreAll.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnRestoreAll.Location = new System.Drawing.Point(6, 136);
            this.btnRestoreAll.Name = "btnRestoreAll";
            this.btnRestoreAll.Size = new System.Drawing.Size(207, 51);
            this.btnRestoreAll.TabIndex = 5;
            this.btnRestoreAll.Text = "Restore All vars";
            this.btnRestoreAll.UseVisualStyleBackColor = true;
            this.btnRestoreAll.Click += new System.EventHandler(this.btnRestoreAll_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbInvertCreators);
            this.groupBox3.Controls.Add(this.cbAllCreators);
            this.groupBox3.Controls.Add(this.txtCreatorFilter);
            this.groupBox3.Controls.Add(this.clbCreators);
            this.groupBox3.Location = new System.Drawing.Point(237, 158);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(274, 577);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Creator Exceptions";
            // 
            // cbInvertCreators
            // 
            this.cbInvertCreators.AutoSize = true;
            this.cbInvertCreators.Location = new System.Drawing.Point(65, 34);
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
            this.cbAllCreators.Location = new System.Drawing.Point(9, 34);
            this.cbAllCreators.Name = "cbAllCreators";
            this.cbAllCreators.Size = new System.Drawing.Size(40, 19);
            this.cbAllCreators.TabIndex = 14;
            this.cbAllCreators.Text = "All";
            this.cbAllCreators.UseVisualStyleBackColor = true;
            this.cbAllCreators.CheckedChanged += new System.EventHandler(this.cbAllCreators_CheckedChanged);
            // 
            // txtCreatorFilter
            // 
            this.txtCreatorFilter.Location = new System.Drawing.Point(6, 63);
            this.txtCreatorFilter.Name = "txtCreatorFilter";
            this.txtCreatorFilter.Size = new System.Drawing.Size(262, 23);
            this.txtCreatorFilter.TabIndex = 12;
            this.txtCreatorFilter.TextChanged += new System.EventHandler(this.txtCreatorFilter_TextChanged);
            // 
            // clbCreators
            // 
            this.clbCreators.CheckOnClick = true;
            this.clbCreators.FormattingEnabled = true;
            this.clbCreators.Location = new System.Drawing.Point(6, 92);
            this.clbCreators.Name = "clbCreators";
            this.clbCreators.Size = new System.Drawing.Size(262, 472);
            this.clbCreators.TabIndex = 8;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbInvertFolders);
            this.groupBox4.Controls.Add(this.cbAllFolders);
            this.groupBox4.Controls.Add(this.txtFolderFilter);
            this.groupBox4.Controls.Add(this.clbFolders);
            this.groupBox4.Location = new System.Drawing.Point(517, 158);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(274, 577);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Folder Exceptions";
            // 
            // cbInvertFolders
            // 
            this.cbInvertFolders.AutoSize = true;
            this.cbInvertFolders.Location = new System.Drawing.Point(68, 34);
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
            this.cbAllFolders.Location = new System.Drawing.Point(12, 34);
            this.cbAllFolders.Name = "cbAllFolders";
            this.cbAllFolders.Size = new System.Drawing.Size(40, 19);
            this.cbAllFolders.TabIndex = 16;
            this.cbAllFolders.Text = "All";
            this.cbAllFolders.UseVisualStyleBackColor = true;
            this.cbAllFolders.CheckedChanged += new System.EventHandler(this.cbAllFolders_CheckedChanged);
            // 
            // txtFolderFilter
            // 
            this.txtFolderFilter.Location = new System.Drawing.Point(9, 63);
            this.txtFolderFilter.Name = "txtFolderFilter";
            this.txtFolderFilter.Size = new System.Drawing.Size(259, 23);
            this.txtFolderFilter.TabIndex = 13;
            this.txtFolderFilter.TextChanged += new System.EventHandler(this.txtFolderFilter_TextChanged);
            // 
            // clbFolders
            // 
            this.clbFolders.CheckOnClick = true;
            this.clbFolders.FormattingEnabled = true;
            this.clbFolders.Location = new System.Drawing.Point(9, 92);
            this.clbFolders.Name = "clbFolders";
            this.clbFolders.Size = new System.Drawing.Size(259, 472);
            this.clbFolders.TabIndex = 8;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbInvertSpec);
            this.groupBox5.Controls.Add(this.cbAllSpec);
            this.groupBox5.Controls.Add(this.clbTypes);
            this.groupBox5.Location = new System.Drawing.Point(797, 425);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(274, 310);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Specific-Type Backup/Restore";
            // 
            // cbInvertSpec
            // 
            this.cbInvertSpec.AutoSize = true;
            this.cbInvertSpec.Location = new System.Drawing.Point(65, 27);
            this.cbInvertSpec.Name = "cbInvertSpec";
            this.cbInvertSpec.Size = new System.Drawing.Size(56, 19);
            this.cbInvertSpec.TabIndex = 13;
            this.cbInvertSpec.Text = "Invert";
            this.cbInvertSpec.UseVisualStyleBackColor = true;
            this.cbInvertSpec.CheckedChanged += new System.EventHandler(this.cbInvertSpec_CheckedChanged);
            // 
            // cbAllSpec
            // 
            this.cbAllSpec.AutoSize = true;
            this.cbAllSpec.Location = new System.Drawing.Point(9, 27);
            this.cbAllSpec.Name = "cbAllSpec";
            this.cbAllSpec.Size = new System.Drawing.Size(40, 19);
            this.cbAllSpec.TabIndex = 12;
            this.cbAllSpec.Text = "All";
            this.cbAllSpec.UseVisualStyleBackColor = true;
            this.cbAllSpec.CheckedChanged += new System.EventHandler(this.cbAllSpec_CheckedChanged);
            // 
            // clbTypes
            // 
            this.clbTypes.CheckOnClick = true;
            this.clbTypes.FormattingEnabled = true;
            this.clbTypes.Location = new System.Drawing.Point(6, 59);
            this.clbTypes.Name = "clbTypes";
            this.clbTypes.Size = new System.Drawing.Size(259, 238);
            this.clbTypes.TabIndex = 8;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnRestoreRef);
            this.groupBox6.Controls.Add(this.btnRestoreAll);
            this.groupBox6.Controls.Add(this.btnRestoreSpec);
            this.groupBox6.Location = new System.Drawing.Point(12, 442);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(219, 196);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Restore";
            // 
            // btnRestoreRef
            // 
            this.btnRestoreRef.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnRestoreRef.Location = new System.Drawing.Point(6, 22);
            this.btnRestoreRef.Name = "btnRestoreRef";
            this.btnRestoreRef.Size = new System.Drawing.Size(207, 51);
            this.btnRestoreRef.TabIndex = 8;
            this.btnRestoreRef.Text = "Restore All Referenced vars";
            this.btnRestoreRef.UseVisualStyleBackColor = true;
            this.btnRestoreRef.Click += new System.EventHandler(this.btnRestoreRef_Click);
            // 
            // frmVARManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 747);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmVARManager";
            this.Text = "VAR Manager";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox clbCreators;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox clbFolders;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckedListBox clbTypes;
        private System.Windows.Forms.Label lblBackupcount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblVamcount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBackupSpec;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox cbEx;
        private System.Windows.Forms.Button btnBackupUnrefSpec;
        private System.Windows.Forms.Button btnRestoreRef;
        private System.Windows.Forms.Button btnResetSettings;
        private System.Windows.Forms.TextBox txtCreatorFilter;
        private System.Windows.Forms.TextBox txtFolderFilter;
        private System.Windows.Forms.CheckBox cbInvertCreators;
        private System.Windows.Forms.CheckBox cbAllCreators;
        private System.Windows.Forms.CheckBox cbInvertFolders;
        private System.Windows.Forms.CheckBox cbAllFolders;
        private System.Windows.Forms.CheckBox cbInvertSpec;
        private System.Windows.Forms.CheckBox cbAllSpec;
    }
}

