namespace Impactor
{
    partial class IMPFrmInjuryTime
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
            this.btnClose = new System.Windows.Forms.Button();
            this.lstInjuryType = new System.Windows.Forms.ListBox();
            this.btnSaveUpdate = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblInjuryTypeId = new System.Windows.Forms.Label();
            this.lblInjuryTimeIdValue = new System.Windows.Forms.Label();
            this.lblShortName = new System.Windows.Forms.Label();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.txtInjuryDefinition = new System.Windows.Forms.TextBox();
            this.lblInjuryDefinition = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDefaultUnits = new System.Windows.Forms.TextBox();
            this.lblDefaultUnits = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmboStatus = new System.Windows.Forms.ComboBox();
            this.grpValue = new System.Windows.Forms.GroupBox();
            this.ckMinValue = new System.Windows.Forms.CheckBox();
            this.ckMaxValue = new System.Windows.Forms.CheckBox();
            this.grpTime = new System.Windows.Forms.GroupBox();
            this.ckMinTime = new System.Windows.Forms.CheckBox();
            this.ckMaxTime = new System.Windows.Forms.CheckBox();
            this.ckShowAll = new System.Windows.Forms.CheckBox();
            this.grpValue.SuspendLayout();
            this.grpTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(732, 255);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lstInjuryType
            // 
            this.lstInjuryType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstInjuryType.FormattingEnabled = true;
            this.lstInjuryType.Location = new System.Drawing.Point(12, 12);
            this.lstInjuryType.Name = "lstInjuryType";
            this.lstInjuryType.Size = new System.Drawing.Size(234, 238);
            this.lstInjuryType.TabIndex = 1;
            this.lstInjuryType.SelectedIndexChanged += new System.EventHandler(this.LstInjuryType_SelectedIndexChanged);
            // 
            // btnSaveUpdate
            // 
            this.btnSaveUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveUpdate.Location = new System.Drawing.Point(651, 255);
            this.btnSaveUpdate.Name = "btnSaveUpdate";
            this.btnSaveUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnSaveUpdate.TabIndex = 19;
            this.btnSaveUpdate.UseVisualStyleBackColor = true;
            this.btnSaveUpdate.Click += new System.EventHandler(this.BtnSaveUpdate_Clicked);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(570, 255);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 18;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Clicked);
            // 
            // lblInjuryTypeId
            // 
            this.lblInjuryTypeId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInjuryTypeId.AutoSize = true;
            this.lblInjuryTypeId.Location = new System.Drawing.Point(251, 12);
            this.lblInjuryTypeId.Name = "lblInjuryTypeId";
            this.lblInjuryTypeId.Size = new System.Drawing.Size(120, 13);
            this.lblInjuryTypeId.TabIndex = 4;
            this.lblInjuryTypeId.Text = "Impactor Injury Time Id: ";
            // 
            // lblInjuryTimeIdValue
            // 
            this.lblInjuryTimeIdValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInjuryTimeIdValue.AutoSize = true;
            this.lblInjuryTimeIdValue.Location = new System.Drawing.Point(369, 12);
            this.lblInjuryTimeIdValue.Name = "lblInjuryTimeIdValue";
            this.lblInjuryTimeIdValue.Size = new System.Drawing.Size(0, 13);
            this.lblInjuryTimeIdValue.TabIndex = 5;
            // 
            // lblShortName
            // 
            this.lblShortName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShortName.AutoSize = true;
            this.lblShortName.Location = new System.Drawing.Point(267, 43);
            this.lblShortName.Name = "lblShortName";
            this.lblShortName.Size = new System.Drawing.Size(66, 13);
            this.lblShortName.TabIndex = 6;
            this.lblShortName.Text = "Short Name:";
            // 
            // txtShortName
            // 
            this.txtShortName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShortName.Location = new System.Drawing.Point(339, 40);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(100, 20);
            this.txtShortName.TabIndex = 7;
            // 
            // txtInjuryDefinition
            // 
            this.txtInjuryDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInjuryDefinition.Location = new System.Drawing.Point(339, 66);
            this.txtInjuryDefinition.Name = "txtInjuryDefinition";
            this.txtInjuryDefinition.Size = new System.Drawing.Size(100, 20);
            this.txtInjuryDefinition.TabIndex = 9;
            // 
            // lblInjuryDefinition
            // 
            this.lblInjuryDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInjuryDefinition.AutoSize = true;
            this.lblInjuryDefinition.Location = new System.Drawing.Point(251, 69);
            this.lblInjuryDefinition.Name = "lblInjuryDefinition";
            this.lblInjuryDefinition.Size = new System.Drawing.Size(82, 13);
            this.lblInjuryDefinition.TabIndex = 8;
            this.lblInjuryDefinition.Text = "Injury Definition:";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(339, 92);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(468, 20);
            this.txtDescription.TabIndex = 11;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(270, 95);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Description:";
            // 
            // txtDefaultUnits
            // 
            this.txtDefaultUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDefaultUnits.Location = new System.Drawing.Point(339, 118);
            this.txtDefaultUnits.Name = "txtDefaultUnits";
            this.txtDefaultUnits.Size = new System.Drawing.Size(100, 20);
            this.txtDefaultUnits.TabIndex = 13;
            // 
            // lblDefaultUnits
            // 
            this.lblDefaultUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDefaultUnits.AutoSize = true;
            this.lblDefaultUnits.Location = new System.Drawing.Point(262, 121);
            this.lblDefaultUnits.Name = "lblDefaultUnits";
            this.lblDefaultUnits.Size = new System.Drawing.Size(71, 13);
            this.lblDefaultUnits.TabIndex = 12;
            this.lblDefaultUnits.Text = "Default Units:";
            this.lblDefaultUnits.UseWaitCursor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(293, 147);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Status:";
            this.lblStatus.UseWaitCursor = true;
            // 
            // cmboStatus
            // 
            this.cmboStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmboStatus.FormattingEnabled = true;
            this.cmboStatus.Location = new System.Drawing.Point(339, 144);
            this.cmboStatus.Name = "cmboStatus";
            this.cmboStatus.Size = new System.Drawing.Size(100, 21);
            this.cmboStatus.TabIndex = 15;
            // 
            // grpValue
            // 
            this.grpValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpValue.Controls.Add(this.ckMinValue);
            this.grpValue.Controls.Add(this.ckMaxValue);
            this.grpValue.Location = new System.Drawing.Point(266, 209);
            this.grpValue.Name = "grpValue";
            this.grpValue.Size = new System.Drawing.Size(143, 71);
            this.grpValue.TabIndex = 16;
            this.grpValue.TabStop = false;
            this.grpValue.Text = "Max/Min Value";
            // 
            // ckMinValue
            // 
            this.ckMinValue.AutoSize = true;
            this.ckMinValue.Location = new System.Drawing.Point(6, 42);
            this.ckMinValue.Name = "ckMinValue";
            this.ckMinValue.Size = new System.Drawing.Size(119, 17);
            this.ckMinValue.TabIndex = 1;
            this.ckMinValue.Text = "Use Minimum Value";
            this.ckMinValue.UseVisualStyleBackColor = true;
            // 
            // ckMaxValue
            // 
            this.ckMaxValue.AutoSize = true;
            this.ckMaxValue.Location = new System.Drawing.Point(6, 19);
            this.ckMaxValue.Name = "ckMaxValue";
            this.ckMaxValue.Size = new System.Drawing.Size(122, 17);
            this.ckMaxValue.TabIndex = 0;
            this.ckMaxValue.Text = "Use Maximum Value";
            this.ckMaxValue.UseVisualStyleBackColor = true;
            // 
            // grpTime
            // 
            this.grpTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpTime.Controls.Add(this.ckMinTime);
            this.grpTime.Controls.Add(this.ckMaxTime);
            this.grpTime.Location = new System.Drawing.Point(415, 209);
            this.grpTime.Name = "grpTime";
            this.grpTime.Size = new System.Drawing.Size(143, 71);
            this.grpTime.TabIndex = 17;
            this.grpTime.TabStop = false;
            this.grpTime.Text = "Max/Min Time";
            // 
            // ckMinTime
            // 
            this.ckMinTime.AutoSize = true;
            this.ckMinTime.Location = new System.Drawing.Point(6, 42);
            this.ckMinTime.Name = "ckMinTime";
            this.ckMinTime.Size = new System.Drawing.Size(115, 17);
            this.ckMinTime.TabIndex = 1;
            this.ckMinTime.Text = "Use Minimum Time";
            this.ckMinTime.UseVisualStyleBackColor = true;
            // 
            // ckMaxTime
            // 
            this.ckMaxTime.AutoSize = true;
            this.ckMaxTime.Location = new System.Drawing.Point(6, 19);
            this.ckMaxTime.Name = "ckMaxTime";
            this.ckMaxTime.Size = new System.Drawing.Size(118, 17);
            this.ckMaxTime.TabIndex = 0;
            this.ckMaxTime.Text = "Use Maximum Time";
            this.ckMaxTime.UseVisualStyleBackColor = true;
            // 
            // ckShowAll
            // 
            this.ckShowAll.AutoSize = true;
            this.ckShowAll.Location = new System.Drawing.Point(12, 263);
            this.ckShowAll.Name = "ckShowAll";
            this.ckShowAll.Size = new System.Drawing.Size(67, 17);
            this.ckShowAll.TabIndex = 21;
            this.ckShowAll.Text = "Show All";
            this.ckShowAll.UseVisualStyleBackColor = true;
            this.ckShowAll.CheckedChanged += new System.EventHandler(this.CkShow_All_CheckChanged);
            // 
            // IMPFrmInjuryTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 290);
            this.Controls.Add(this.ckShowAll);
            this.Controls.Add(this.grpTime);
            this.Controls.Add(this.grpValue);
            this.Controls.Add(this.cmboStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtDefaultUnits);
            this.Controls.Add(this.lblDefaultUnits);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtInjuryDefinition);
            this.Controls.Add(this.lblInjuryDefinition);
            this.Controls.Add(this.txtShortName);
            this.Controls.Add(this.lblShortName);
            this.Controls.Add(this.lblInjuryTimeIdValue);
            this.Controls.Add(this.lblInjuryTypeId);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSaveUpdate);
            this.Controls.Add(this.lstInjuryType);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IMPFrmInjuryTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Injury Time";
            this.grpValue.ResumeLayout(false);
            this.grpValue.PerformLayout();
            this.grpTime.ResumeLayout(false);
            this.grpTime.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox lstInjuryType;
        private System.Windows.Forms.Button btnSaveUpdate;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblInjuryTypeId;
        private System.Windows.Forms.Label lblInjuryTimeIdValue;
        private System.Windows.Forms.Label lblShortName;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.TextBox txtInjuryDefinition;
        private System.Windows.Forms.Label lblInjuryDefinition;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDefaultUnits;
        private System.Windows.Forms.Label lblDefaultUnits;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmboStatus;
        private System.Windows.Forms.GroupBox grpValue;
        private System.Windows.Forms.CheckBox ckMinValue;
        private System.Windows.Forms.CheckBox ckMaxValue;
        private System.Windows.Forms.GroupBox grpTime;
        private System.Windows.Forms.CheckBox ckMinTime;
        private System.Windows.Forms.CheckBox ckMaxTime;
        private System.Windows.Forms.CheckBox ckShowAll;
    }
}