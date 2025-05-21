namespace Controls
{
    partial class IMPFrmSelectTime
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
            this.lblSelect = new System.Windows.Forms.Label();
            this.cmboTime = new System.Windows.Forms.ComboBox();
            this.grpTime = new System.Windows.Forms.GroupBox();
            this.ckMinTimeUsed = new System.Windows.Forms.CheckBox();
            this.ckMinValueUsed = new System.Windows.Forms.CheckBox();
            this.ckMaxTimeUsed = new System.Windows.Forms.CheckBox();
            this.ckMaxValueUsed = new System.Windows.Forms.CheckBox();
            this.lblDefaultUnitsValue = new System.Windows.Forms.Label();
            this.lblDefaultUnits = new System.Windows.Forms.Label();
            this.lblDescriptionValue = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblInjuryDefinitionValue = new System.Windows.Forms.Label();
            this.lblInjuryDefinition = new System.Windows.Forms.Label();
            this.lblShortValue = new System.Windows.Forms.Label();
            this.lblShort = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUse = new System.Windows.Forms.Button();
            this.grpTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(12, 9);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(109, 13);
            this.lblSelect.TabIndex = 0;
            this.lblSelect.Text = "Select an Injury Time:";
            // 
            // cmboTime
            // 
            this.cmboTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboTime.FormattingEnabled = true;
            this.cmboTime.Location = new System.Drawing.Point(127, 6);
            this.cmboTime.Name = "cmboTime";
            this.cmboTime.Size = new System.Drawing.Size(158, 21);
            this.cmboTime.TabIndex = 1;
            this.cmboTime.SelectedIndexChanged += new System.EventHandler(this.CmboTime_SelectionChanged);
            // 
            // grpTime
            // 
            this.grpTime.Controls.Add(this.ckMinTimeUsed);
            this.grpTime.Controls.Add(this.ckMinValueUsed);
            this.grpTime.Controls.Add(this.ckMaxTimeUsed);
            this.grpTime.Controls.Add(this.ckMaxValueUsed);
            this.grpTime.Controls.Add(this.lblDefaultUnitsValue);
            this.grpTime.Controls.Add(this.lblDefaultUnits);
            this.grpTime.Controls.Add(this.lblDescriptionValue);
            this.grpTime.Controls.Add(this.lblDescription);
            this.grpTime.Controls.Add(this.lblInjuryDefinitionValue);
            this.grpTime.Controls.Add(this.lblInjuryDefinition);
            this.grpTime.Controls.Add(this.lblShortValue);
            this.grpTime.Controls.Add(this.lblShort);
            this.grpTime.Location = new System.Drawing.Point(12, 47);
            this.grpTime.Name = "grpTime";
            this.grpTime.Size = new System.Drawing.Size(458, 163);
            this.grpTime.TabIndex = 2;
            this.grpTime.TabStop = false;
            this.grpTime.Text = "Properties";
            // 
            // ckMinTimeUsed
            // 
            this.ckMinTimeUsed.AutoSize = true;
            this.ckMinTimeUsed.Location = new System.Drawing.Point(341, 135);
            this.ckMinTimeUsed.Name = "ckMinTimeUsed";
            this.ckMinTimeUsed.Size = new System.Drawing.Size(97, 17);
            this.ckMinTimeUsed.TabIndex = 11;
            this.ckMinTimeUsed.Text = "Min Time Used";
            this.ckMinTimeUsed.UseVisualStyleBackColor = true;
            // 
            // ckMinValueUsed
            // 
            this.ckMinValueUsed.AutoSize = true;
            this.ckMinValueUsed.Location = new System.Drawing.Point(231, 135);
            this.ckMinValueUsed.Name = "ckMinValueUsed";
            this.ckMinValueUsed.Size = new System.Drawing.Size(101, 17);
            this.ckMinValueUsed.TabIndex = 10;
            this.ckMinValueUsed.Text = "Min Value Used";
            this.ckMinValueUsed.UseVisualStyleBackColor = true;
            // 
            // ckMaxTimeUsed
            // 
            this.ckMaxTimeUsed.AutoSize = true;
            this.ckMaxTimeUsed.Location = new System.Drawing.Point(121, 135);
            this.ckMaxTimeUsed.Name = "ckMaxTimeUsed";
            this.ckMaxTimeUsed.Size = new System.Drawing.Size(100, 17);
            this.ckMaxTimeUsed.TabIndex = 9;
            this.ckMaxTimeUsed.Text = "Max Time Used";
            this.ckMaxTimeUsed.UseVisualStyleBackColor = true;
            // 
            // ckMaxValueUsed
            // 
            this.ckMaxValueUsed.AutoSize = true;
            this.ckMaxValueUsed.Location = new System.Drawing.Point(11, 135);
            this.ckMaxValueUsed.Name = "ckMaxValueUsed";
            this.ckMaxValueUsed.Size = new System.Drawing.Size(104, 17);
            this.ckMaxValueUsed.TabIndex = 8;
            this.ckMaxValueUsed.Text = "Max Value Used";
            this.ckMaxValueUsed.UseVisualStyleBackColor = true;
            // 
            // lblDefaultUnitsValue
            // 
            this.lblDefaultUnitsValue.AutoSize = true;
            this.lblDefaultUnitsValue.Location = new System.Drawing.Point(94, 102);
            this.lblDefaultUnitsValue.Name = "lblDefaultUnitsValue";
            this.lblDefaultUnitsValue.Size = new System.Drawing.Size(68, 13);
            this.lblDefaultUnitsValue.TabIndex = 7;
            this.lblDefaultUnitsValue.Text = "Default Units";
            // 
            // lblDefaultUnits
            // 
            this.lblDefaultUnits.AutoSize = true;
            this.lblDefaultUnits.Location = new System.Drawing.Point(20, 102);
            this.lblDefaultUnits.Name = "lblDefaultUnits";
            this.lblDefaultUnits.Size = new System.Drawing.Size(71, 13);
            this.lblDefaultUnits.TabIndex = 6;
            this.lblDefaultUnits.Text = "Default Units:";
            // 
            // lblDescriptionValue
            // 
            this.lblDescriptionValue.AutoSize = true;
            this.lblDescriptionValue.Location = new System.Drawing.Point(94, 77);
            this.lblDescriptionValue.Name = "lblDescriptionValue";
            this.lblDescriptionValue.Size = new System.Drawing.Size(60, 13);
            this.lblDescriptionValue.TabIndex = 5;
            this.lblDescriptionValue.Text = "Description";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(25, 77);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description:";
            // 
            // lblInjuryDefinitionValue
            // 
            this.lblInjuryDefinitionValue.AutoSize = true;
            this.lblInjuryDefinitionValue.Location = new System.Drawing.Point(94, 52);
            this.lblInjuryDefinitionValue.Name = "lblInjuryDefinitionValue";
            this.lblInjuryDefinitionValue.Size = new System.Drawing.Size(79, 13);
            this.lblInjuryDefinitionValue.TabIndex = 3;
            this.lblInjuryDefinitionValue.Text = "Injury Definition";
            // 
            // lblInjuryDefinition
            // 
            this.lblInjuryDefinition.AutoSize = true;
            this.lblInjuryDefinition.Location = new System.Drawing.Point(6, 52);
            this.lblInjuryDefinition.Name = "lblInjuryDefinition";
            this.lblInjuryDefinition.Size = new System.Drawing.Size(82, 13);
            this.lblInjuryDefinition.TabIndex = 2;
            this.lblInjuryDefinition.Text = "Injury Definition:";
            // 
            // lblShortValue
            // 
            this.lblShortValue.AutoSize = true;
            this.lblShortValue.Location = new System.Drawing.Point(94, 26);
            this.lblShortValue.Name = "lblShortValue";
            this.lblShortValue.Size = new System.Drawing.Size(63, 13);
            this.lblShortValue.TabIndex = 1;
            this.lblShortValue.Text = "Short Name";
            // 
            // lblShort
            // 
            this.lblShort.AutoSize = true;
            this.lblShort.Location = new System.Drawing.Point(22, 26);
            this.lblShort.Name = "lblShort";
            this.lblShort.Size = new System.Drawing.Size(66, 13);
            this.lblShort.TabIndex = 0;
            this.lblShort.Text = "Short Name:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(399, 217);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnUse
            // 
            this.btnUse.Location = new System.Drawing.Point(271, 217);
            this.btnUse.Name = "btnUse";
            this.btnUse.Size = new System.Drawing.Size(122, 23);
            this.btnUse.TabIndex = 4;
            this.btnUse.Text = "Use This Selection";
            this.btnUse.UseVisualStyleBackColor = true;
            this.btnUse.Click += new System.EventHandler(this.BtnUse_Click);
            // 
            // IMPFrmSelectTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 252);
            this.Controls.Add(this.btnUse);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpTime);
            this.Controls.Add(this.cmboTime);
            this.Controls.Add(this.lblSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IMPFrmSelectTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Injury Time";
            this.grpTime.ResumeLayout(false);
            this.grpTime.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.ComboBox cmboTime;
        private System.Windows.Forms.GroupBox grpTime;
        private System.Windows.Forms.Label lblShort;
        private System.Windows.Forms.Label lblShortValue;
        private System.Windows.Forms.Label lblInjuryDefinitionValue;
        private System.Windows.Forms.Label lblInjuryDefinition;
        private System.Windows.Forms.CheckBox ckMinTimeUsed;
        private System.Windows.Forms.CheckBox ckMinValueUsed;
        private System.Windows.Forms.CheckBox ckMaxTimeUsed;
        private System.Windows.Forms.CheckBox ckMaxValueUsed;
        private System.Windows.Forms.Label lblDefaultUnitsValue;
        private System.Windows.Forms.Label lblDefaultUnits;
        private System.Windows.Forms.Label lblDescriptionValue;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUse;
    }
}