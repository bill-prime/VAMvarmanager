namespace VAMvarmanager
{
    partial class frmMorphPresetMaker
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
            this.clbMorphvars = new System.Windows.Forms.CheckedListBox();
            this.txtPresetName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveMorphPreset = new System.Windows.Forms.Button();
            this.comboSex = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDefaultMorphValue = new System.Windows.Forms.TextBox();
            this.cbPreloadMorphs = new System.Windows.Forms.CheckBox();
            this.gbMorphvars = new System.Windows.Forms.GroupBox();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.cbSortNumMorphs = new System.Windows.Forms.CheckBox();
            this.txtNameFilter = new System.Windows.Forms.TextBox();
            this.btnReturnToVM = new System.Windows.Forms.Button();
            this.sfdMorphPreset = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.gbMorphvars.SuspendLayout();
            this.gbFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbMorphvars
            // 
            this.clbMorphvars.CheckOnClick = true;
            this.clbMorphvars.FormattingEnabled = true;
            this.clbMorphvars.Location = new System.Drawing.Point(6, 22);
            this.clbMorphvars.Name = "clbMorphvars";
            this.clbMorphvars.Size = new System.Drawing.Size(379, 454);
            this.clbMorphvars.TabIndex = 0;
            // 
            // txtPresetName
            // 
            this.txtPresetName.Location = new System.Drawing.Point(108, 90);
            this.txtPresetName.Name = "txtPresetName";
            this.txtPresetName.Size = new System.Drawing.Size(191, 23);
            this.txtPresetName.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSaveMorphPreset);
            this.groupBox1.Controls.Add(this.comboSex);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDefaultMorphValue);
            this.groupBox1.Controls.Add(this.txtPresetName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 193);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Morph Preset";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(69, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sex:";
            // 
            // btnSaveMorphPreset
            // 
            this.btnSaveMorphPreset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSaveMorphPreset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSaveMorphPreset.Location = new System.Drawing.Point(6, 136);
            this.btnSaveMorphPreset.Name = "btnSaveMorphPreset";
            this.btnSaveMorphPreset.Size = new System.Drawing.Size(293, 51);
            this.btnSaveMorphPreset.TabIndex = 7;
            this.btnSaveMorphPreset.Text = "Save Morph Preset";
            this.btnSaveMorphPreset.UseVisualStyleBackColor = true;
            this.btnSaveMorphPreset.Click += new System.EventHandler(this.btnSaveMorphPreset_Click);
            // 
            // comboSex
            // 
            this.comboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSex.FormattingEnabled = true;
            this.comboSex.Location = new System.Drawing.Point(108, 19);
            this.comboSex.Name = "comboSex";
            this.comboSex.Size = new System.Drawing.Size(121, 23);
            this.comboSex.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Preset Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Default Value:";
            // 
            // txtDefaultMorphValue
            // 
            this.txtDefaultMorphValue.Location = new System.Drawing.Point(108, 52);
            this.txtDefaultMorphValue.Name = "txtDefaultMorphValue";
            this.txtDefaultMorphValue.Size = new System.Drawing.Size(191, 23);
            this.txtDefaultMorphValue.TabIndex = 2;
            // 
            // cbPreloadMorphs
            // 
            this.cbPreloadMorphs.AutoSize = true;
            this.cbPreloadMorphs.Location = new System.Drawing.Point(6, 23);
            this.cbPreloadMorphs.Name = "cbPreloadMorphs";
            this.cbPreloadMorphs.Size = new System.Drawing.Size(217, 19);
            this.cbPreloadMorphs.TabIndex = 3;
            this.cbPreloadMorphs.Text = "Show Only vars with PreloadMorphs";
            this.cbPreloadMorphs.UseVisualStyleBackColor = true;
            this.cbPreloadMorphs.CheckedChanged += new System.EventHandler(this.cbPreloadMorphs_CheckedChanged);
            // 
            // gbMorphvars
            // 
            this.gbMorphvars.Controls.Add(this.clbMorphvars);
            this.gbMorphvars.Location = new System.Drawing.Point(323, 119);
            this.gbMorphvars.Name = "gbMorphvars";
            this.gbMorphvars.Size = new System.Drawing.Size(391, 483);
            this.gbMorphvars.TabIndex = 4;
            this.gbMorphvars.TabStop = false;
            this.gbMorphvars.Text = "Choose vars to include in Morph Preset";
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.cbSortNumMorphs);
            this.gbFilters.Controls.Add(this.txtNameFilter);
            this.gbFilters.Controls.Add(this.cbPreloadMorphs);
            this.gbFilters.Location = new System.Drawing.Point(323, 12);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(391, 101);
            this.gbFilters.TabIndex = 5;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Filters";
            // 
            // cbSortNumMorphs
            // 
            this.cbSortNumMorphs.AutoSize = true;
            this.cbSortNumMorphs.Location = new System.Drawing.Point(6, 47);
            this.cbSortNumMorphs.Name = "cbSortNumMorphs";
            this.cbSortNumMorphs.Size = new System.Drawing.Size(168, 19);
            this.cbSortNumMorphs.TabIndex = 4;
            this.cbSortNumMorphs.Text = "Sort by Number of Morphs";
            this.cbSortNumMorphs.UseVisualStyleBackColor = true;
            this.cbSortNumMorphs.CheckedChanged += new System.EventHandler(this.cbSortNumMorphs_CheckedChanged);
            // 
            // txtNameFilter
            // 
            this.txtNameFilter.Location = new System.Drawing.Point(6, 72);
            this.txtNameFilter.Name = "txtNameFilter";
            this.txtNameFilter.Size = new System.Drawing.Size(379, 23);
            this.txtNameFilter.TabIndex = 0;
            this.txtNameFilter.TextChanged += new System.EventHandler(this.txtNameFilter_TextChanged);
            // 
            // btnReturnToVM
            // 
            this.btnReturnToVM.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReturnToVM.ForeColor = System.Drawing.Color.DarkRed;
            this.btnReturnToVM.Location = new System.Drawing.Point(18, 545);
            this.btnReturnToVM.Name = "btnReturnToVM";
            this.btnReturnToVM.Size = new System.Drawing.Size(293, 51);
            this.btnReturnToVM.TabIndex = 12;
            this.btnReturnToVM.Text = "Return to VAR Manager";
            this.btnReturnToVM.UseVisualStyleBackColor = true;
            this.btnReturnToVM.Click += new System.EventHandler(this.btnReturnToVM_Click);
            // 
            // frmMorphPresetMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 614);
            this.Controls.Add(this.btnReturnToVM);
            this.Controls.Add(this.gbFilters);
            this.Controls.Add(this.gbMorphvars);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMorphPresetMaker";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Morph Preset Maker";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbMorphvars.ResumeLayout(false);
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbMorphvars;
        private System.Windows.Forms.TextBox txtPresetName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDefaultMorphValue;
        private System.Windows.Forms.CheckBox cbPreloadMorphs;
        private System.Windows.Forms.GroupBox gbMorphvars;
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.TextBox txtNameFilter;
        private System.Windows.Forms.Button btnReturnToVM;
        private System.Windows.Forms.Button btnSaveMorphPreset;
        private System.Windows.Forms.ComboBox comboSex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbSortNumMorphs;
        private System.Windows.Forms.SaveFileDialog sfdMorphPreset;
    }
}