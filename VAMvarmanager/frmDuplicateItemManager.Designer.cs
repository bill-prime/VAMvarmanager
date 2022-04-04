namespace VAMvarmanager
{
    partial class frmDuplicateItemManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.clbDuplicatesManual = new System.Windows.Forms.CheckedListBox();
            this.comboSex = new System.Windows.Forms.ComboBox();
            this.comboType = new System.Windows.Forms.ComboBox();
            this.btnFindDuplicates = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCreatorName = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.gbManualResolve = new System.Windows.Forms.GroupBox();
            this.cbSetMasterItem = new System.Windows.Forms.CheckBox();
            this.lblDuplicateManualCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSetMasterAll = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbConfig = new System.Windows.Forms.GroupBox();
            this.btnClearMasterLists = new System.Windows.Forms.Button();
            this.toolTipMasterVars = new System.Windows.Forms.ToolTip(this.components);
            this.gbDisable = new System.Windows.Forms.GroupBox();
            this.lblDuplicatesTotal = new System.Windows.Forms.Label();
            this.lblDuplicatesUnique = new System.Windows.Forms.Label();
            this.btnDisableDuplicates = new System.Windows.Forms.Button();
            this.btnReturnToVM = new System.Windows.Forms.Button();
            this.gbManualResolve.SuspendLayout();
            this.gbConfig.SuspendLayout();
            this.gbDisable.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbDuplicatesManual
            // 
            this.clbDuplicatesManual.CheckOnClick = true;
            this.clbDuplicatesManual.FormattingEnabled = true;
            this.clbDuplicatesManual.Location = new System.Drawing.Point(6, 186);
            this.clbDuplicatesManual.Name = "clbDuplicatesManual";
            this.clbDuplicatesManual.Size = new System.Drawing.Size(392, 184);
            this.clbDuplicatesManual.TabIndex = 0;
            this.clbDuplicatesManual.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbDuplicatesManual_ItemCheck);
            // 
            // comboSex
            // 
            this.comboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSex.FormattingEnabled = true;
            this.comboSex.Location = new System.Drawing.Point(150, 43);
            this.comboSex.Name = "comboSex";
            this.comboSex.Size = new System.Drawing.Size(121, 23);
            this.comboSex.TabIndex = 1;
            // 
            // comboType
            // 
            this.comboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboType.FormattingEnabled = true;
            this.comboType.Location = new System.Drawing.Point(6, 43);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(121, 23);
            this.comboType.TabIndex = 2;
            // 
            // btnFindDuplicates
            // 
            this.btnFindDuplicates.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFindDuplicates.Location = new System.Drawing.Point(6, 72);
            this.btnFindDuplicates.Name = "btnFindDuplicates";
            this.btnFindDuplicates.Size = new System.Drawing.Size(265, 51);
            this.btnFindDuplicates.TabIndex = 3;
            this.btnFindDuplicates.Text = "Find Duplicates";
            this.btnFindDuplicates.UseVisualStyleBackColor = true;
            this.btnFindDuplicates.Click += new System.EventHandler(this.btnFindDuplicates_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Item Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(150, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sex";
            // 
            // txtCreatorName
            // 
            this.txtCreatorName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtCreatorName.Location = new System.Drawing.Point(122, 40);
            this.txtCreatorName.Name = "txtCreatorName";
            this.txtCreatorName.Size = new System.Drawing.Size(276, 25);
            this.txtCreatorName.TabIndex = 6;
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtItemName.Location = new System.Drawing.Point(120, 71);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(276, 25);
            this.txtItemName.TabIndex = 7;
            // 
            // gbManualResolve
            // 
            this.gbManualResolve.Controls.Add(this.cbSetMasterItem);
            this.gbManualResolve.Controls.Add(this.lblDuplicateManualCount);
            this.gbManualResolve.Controls.Add(this.label5);
            this.gbManualResolve.Controls.Add(this.cbSetMasterAll);
            this.gbManualResolve.Controls.Add(this.label4);
            this.gbManualResolve.Controls.Add(this.label3);
            this.gbManualResolve.Controls.Add(this.clbDuplicatesManual);
            this.gbManualResolve.Controls.Add(this.txtCreatorName);
            this.gbManualResolve.Controls.Add(this.txtItemName);
            this.gbManualResolve.Enabled = false;
            this.gbManualResolve.Location = new System.Drawing.Point(295, 12);
            this.gbManualResolve.Name = "gbManualResolve";
            this.gbManualResolve.Size = new System.Drawing.Size(403, 379);
            this.gbManualResolve.TabIndex = 8;
            this.gbManualResolve.TabStop = false;
            this.gbManualResolve.Text = "Manual Duplicate Resolving";
            // 
            // cbSetMasterItem
            // 
            this.cbSetMasterItem.AutoSize = true;
            this.cbSetMasterItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbSetMasterItem.ForeColor = System.Drawing.Color.DarkMagenta;
            this.cbSetMasterItem.Location = new System.Drawing.Point(6, 109);
            this.cbSetMasterItem.Name = "cbSetMasterItem";
            this.cbSetMasterItem.Size = new System.Drawing.Size(281, 25);
            this.cbSetMasterItem.TabIndex = 11;
            this.cbSetMasterItem.Text = "Set var as Master for current item";
            this.cbSetMasterItem.UseVisualStyleBackColor = true;
            this.cbSetMasterItem.CheckStateChanged += new System.EventHandler(this.cbSetMasterItem_CheckStateChanged);
            this.cbSetMasterItem.MouseHover += new System.EventHandler(this.cbSetMasterItem_MouseHover);
            // 
            // lblDuplicateManualCount
            // 
            this.lblDuplicateManualCount.AutoSize = true;
            this.lblDuplicateManualCount.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblDuplicateManualCount.ForeColor = System.Drawing.Color.Green;
            this.lblDuplicateManualCount.Location = new System.Drawing.Point(6, 19);
            this.lblDuplicateManualCount.Name = "lblDuplicateManualCount";
            this.lblDuplicateManualCount.Size = new System.Drawing.Size(89, 21);
            this.lblDuplicateManualCount.TabIndex = 10;
            this.lblDuplicateManualCount.Text = "Item 1 of 5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(352, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Click on var to keep enabled for selected item (others will disable)";
            // 
            // cbSetMasterAll
            // 
            this.cbSetMasterAll.AutoSize = true;
            this.cbSetMasterAll.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbSetMasterAll.ForeColor = System.Drawing.Color.DarkRed;
            this.cbSetMasterAll.Location = new System.Drawing.Point(6, 140);
            this.cbSetMasterAll.Name = "cbSetMasterAll";
            this.cbSetMasterAll.Size = new System.Drawing.Size(278, 25);
            this.cbSetMasterAll.TabIndex = 10;
            this.cbSetMasterAll.Text = "Set var as Master for all it\'s items";
            this.cbSetMasterAll.UseVisualStyleBackColor = true;
            this.cbSetMasterAll.CheckStateChanged += new System.EventHandler(this.cbSetMasterAll_CheckStateChanged);
            this.cbSetMasterAll.MouseHover += new System.EventHandler(this.cbSetMasterAll_MouseHover);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(17, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Item Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(6, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Item Creator:";
            // 
            // gbConfig
            // 
            this.gbConfig.Controls.Add(this.btnClearMasterLists);
            this.gbConfig.Controls.Add(this.label1);
            this.gbConfig.Controls.Add(this.comboType);
            this.gbConfig.Controls.Add(this.btnFindDuplicates);
            this.gbConfig.Controls.Add(this.label2);
            this.gbConfig.Controls.Add(this.comboSex);
            this.gbConfig.Location = new System.Drawing.Point(12, 12);
            this.gbConfig.Name = "gbConfig";
            this.gbConfig.Size = new System.Drawing.Size(277, 175);
            this.gbConfig.TabIndex = 9;
            this.gbConfig.TabStop = false;
            this.gbConfig.Text = "Config";
            // 
            // btnClearMasterLists
            // 
            this.btnClearMasterLists.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnClearMasterLists.ForeColor = System.Drawing.Color.DarkRed;
            this.btnClearMasterLists.Location = new System.Drawing.Point(6, 129);
            this.btnClearMasterLists.Name = "btnClearMasterLists";
            this.btnClearMasterLists.Size = new System.Drawing.Size(265, 36);
            this.btnClearMasterLists.TabIndex = 6;
            this.btnClearMasterLists.Text = "Clear Saved Master Lists";
            this.btnClearMasterLists.UseVisualStyleBackColor = true;
            this.btnClearMasterLists.Click += new System.EventHandler(this.btnClearMasterLists_Click);
            // 
            // gbDisable
            // 
            this.gbDisable.Controls.Add(this.lblDuplicatesTotal);
            this.gbDisable.Controls.Add(this.lblDuplicatesUnique);
            this.gbDisable.Controls.Add(this.btnDisableDuplicates);
            this.gbDisable.Location = new System.Drawing.Point(12, 193);
            this.gbDisable.Name = "gbDisable";
            this.gbDisable.Size = new System.Drawing.Size(277, 128);
            this.gbDisable.TabIndex = 10;
            this.gbDisable.TabStop = false;
            this.gbDisable.Text = "Disable Duplicates";
            // 
            // lblDuplicatesTotal
            // 
            this.lblDuplicatesTotal.AutoSize = true;
            this.lblDuplicatesTotal.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblDuplicatesTotal.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblDuplicatesTotal.Location = new System.Drawing.Point(6, 40);
            this.lblDuplicatesTotal.Name = "lblDuplicatesTotal";
            this.lblDuplicatesTotal.Size = new System.Drawing.Size(199, 21);
            this.lblDuplicatesTotal.TabIndex = 13;
            this.lblDuplicatesTotal.Text = "500 Total Duplicate Items";
            // 
            // lblDuplicatesUnique
            // 
            this.lblDuplicatesUnique.AutoSize = true;
            this.lblDuplicatesUnique.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblDuplicatesUnique.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblDuplicatesUnique.Location = new System.Drawing.Point(6, 19);
            this.lblDuplicatesUnique.Name = "lblDuplicatesUnique";
            this.lblDuplicatesUnique.Size = new System.Drawing.Size(140, 21);
            this.lblDuplicatesUnique.TabIndex = 12;
            this.lblDuplicatesUnique.Text = "500 Unique Items";
            // 
            // btnDisableDuplicates
            // 
            this.btnDisableDuplicates.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDisableDuplicates.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDisableDuplicates.Location = new System.Drawing.Point(6, 65);
            this.btnDisableDuplicates.Name = "btnDisableDuplicates";
            this.btnDisableDuplicates.Size = new System.Drawing.Size(265, 51);
            this.btnDisableDuplicates.TabIndex = 6;
            this.btnDisableDuplicates.Text = "Disable Duplicates";
            this.btnDisableDuplicates.UseVisualStyleBackColor = true;
            this.btnDisableDuplicates.Click += new System.EventHandler(this.btnDisableDuplicates_Click);
            // 
            // btnReturnToVM
            // 
            this.btnReturnToVM.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReturnToVM.ForeColor = System.Drawing.Color.DarkRed;
            this.btnReturnToVM.Location = new System.Drawing.Point(18, 327);
            this.btnReturnToVM.Name = "btnReturnToVM";
            this.btnReturnToVM.Size = new System.Drawing.Size(265, 51);
            this.btnReturnToVM.TabIndex = 11;
            this.btnReturnToVM.Text = "Return to VAR Manager";
            this.btnReturnToVM.UseVisualStyleBackColor = true;
            this.btnReturnToVM.Click += new System.EventHandler(this.btnReturnToVM_Click);
            // 
            // frmDuplicateItemManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 398);
            this.Controls.Add(this.btnReturnToVM);
            this.Controls.Add(this.gbDisable);
            this.Controls.Add(this.gbConfig);
            this.Controls.Add(this.gbManualResolve);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDuplicateItemManager";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Duplicate Item Resolver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDuplicateItemManager_FormClosing);
            this.gbManualResolve.ResumeLayout(false);
            this.gbManualResolve.PerformLayout();
            this.gbConfig.ResumeLayout(false);
            this.gbConfig.PerformLayout();
            this.gbDisable.ResumeLayout(false);
            this.gbDisable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbDuplicatesManual;
        private System.Windows.Forms.ComboBox comboSex;
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.Button btnFindDuplicates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCreatorName;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.GroupBox gbManualResolve;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbConfig;
        private System.Windows.Forms.Label lblDuplicateManualCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbSetMasterAll;
        private System.Windows.Forms.ToolTip toolTipMasterVars;
        private System.Windows.Forms.CheckBox cbSetMasterItem;
        private System.Windows.Forms.GroupBox gbDisable;
        private System.Windows.Forms.Label lblDuplicatesTotal;
        private System.Windows.Forms.Label lblDuplicatesUnique;
        private System.Windows.Forms.Button btnDisableDuplicates;
        private System.Windows.Forms.Button btnReturnToVM;
        private System.Windows.Forms.Button btnClearMasterLists;
    }
}