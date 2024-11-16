namespace Impactor
{
    partial class IMPFrmProtocol
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.lstProtocols = new System.Windows.Forms.ListBox();
            this.lblTestType = new System.Windows.Forms.Label();
            this.cmboTestType = new System.Windows.Forms.ComboBox();
            this.lblImpactorMass = new System.Windows.Forms.Label();
            this.txtKg = new System.Windows.Forms.TextBox();
            this.lblKg = new System.Windows.Forms.Label();
            this.lblTargetingMethod = new System.Windows.Forms.Label();
            this.cmboTargetingMethod = new System.Windows.Forms.ComboBox();
            this.lblMetersPerSecond = new System.Windows.Forms.Label();
            this.txtMetersPerSecond = new System.Windows.Forms.TextBox();
            this.lblNormalImactSpeed = new System.Windows.Forms.Label();
            this.lblDeg = new System.Windows.Forms.Label();
            this.txtNormalImpactAngle = new System.Windows.Forms.TextBox();
            this.lblNormalImpactAngle = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblRequred1 = new System.Windows.Forms.Label();
            this.lblRequired2 = new System.Windows.Forms.Label();
            this.lblRequired3 = new System.Windows.Forms.Label();
            this.lblRequired4 = new System.Windows.Forms.Label();
            this.lblRequired5 = new System.Windows.Forms.Label();
            this.lblRequired6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(514, 232);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // lstProtocols
            // 
            this.lstProtocols.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstProtocols.FormattingEnabled = true;
            this.lstProtocols.Location = new System.Drawing.Point(12, 12);
            this.lstProtocols.Name = "lstProtocols";
            this.lstProtocols.Size = new System.Drawing.Size(203, 225);
            this.lstProtocols.TabIndex = 0;
            this.lstProtocols.SelectedIndexChanged += new System.EventHandler(this.LstProtocol_SlectedIndexChanged);
            // 
            // lblTestType
            // 
            this.lblTestType.AutoSize = true;
            this.lblTestType.Location = new System.Drawing.Point(240, 55);
            this.lblTestType.Name = "lblTestType";
            this.lblTestType.Size = new System.Drawing.Size(58, 13);
            this.lblTestType.TabIndex = 99;
            this.lblTestType.Text = "Test Type:";
            // 
            // cmboTestType
            // 
            this.cmboTestType.FormattingEnabled = true;
            this.cmboTestType.Location = new System.Drawing.Point(304, 52);
            this.cmboTestType.Name = "cmboTestType";
            this.cmboTestType.Size = new System.Drawing.Size(121, 21);
            this.cmboTestType.TabIndex = 2;
            this.cmboTestType.SelectedIndexChanged += new System.EventHandler(this.CmboTestType_SelectedIndexChanged);
            // 
            // lblImpactorMass
            // 
            this.lblImpactorMass.AutoSize = true;
            this.lblImpactorMass.Location = new System.Drawing.Point(280, 114);
            this.lblImpactorMass.Name = "lblImpactorMass";
            this.lblImpactorMass.Size = new System.Drawing.Size(79, 13);
            this.lblImpactorMass.TabIndex = 99;
            this.lblImpactorMass.Text = "Impactor Mass:";
            // 
            // txtKg
            // 
            this.txtKg.Location = new System.Drawing.Point(365, 111);
            this.txtKg.Name = "txtKg";
            this.txtKg.Size = new System.Drawing.Size(46, 20);
            this.txtKg.TabIndex = 3;
            // 
            // lblKg
            // 
            this.lblKg.AutoSize = true;
            this.lblKg.Location = new System.Drawing.Point(417, 114);
            this.lblKg.Name = "lblKg";
            this.lblKg.Size = new System.Drawing.Size(20, 13);
            this.lblKg.TabIndex = 99;
            this.lblKg.Text = "Kg";
            // 
            // lblTargetingMethod
            // 
            this.lblTargetingMethod.AutoSize = true;
            this.lblTargetingMethod.Location = new System.Drawing.Point(265, 140);
            this.lblTargetingMethod.Name = "lblTargetingMethod";
            this.lblTargetingMethod.Size = new System.Drawing.Size(94, 13);
            this.lblTargetingMethod.TabIndex = 99;
            this.lblTargetingMethod.Text = "Targeting Method:";
            // 
            // cmboTargetingMethod
            // 
            this.cmboTargetingMethod.FormattingEnabled = true;
            this.cmboTargetingMethod.Location = new System.Drawing.Point(365, 137);
            this.cmboTargetingMethod.Name = "cmboTargetingMethod";
            this.cmboTargetingMethod.Size = new System.Drawing.Size(72, 21);
            this.cmboTargetingMethod.TabIndex = 4;
            // 
            // lblMetersPerSecond
            // 
            this.lblMetersPerSecond.AutoSize = true;
            this.lblMetersPerSecond.Location = new System.Drawing.Point(417, 167);
            this.lblMetersPerSecond.Name = "lblMetersPerSecond";
            this.lblMetersPerSecond.Size = new System.Drawing.Size(25, 13);
            this.lblMetersPerSecond.TabIndex = 99;
            this.lblMetersPerSecond.Text = "m/s";
            // 
            // txtMetersPerSecond
            // 
            this.txtMetersPerSecond.Location = new System.Drawing.Point(365, 164);
            this.txtMetersPerSecond.Name = "txtMetersPerSecond";
            this.txtMetersPerSecond.Size = new System.Drawing.Size(46, 20);
            this.txtMetersPerSecond.TabIndex = 5;
            // 
            // lblNormalImactSpeed
            // 
            this.lblNormalImactSpeed.AutoSize = true;
            this.lblNormalImactSpeed.Location = new System.Drawing.Point(250, 167);
            this.lblNormalImactSpeed.Name = "lblNormalImactSpeed";
            this.lblNormalImactSpeed.Size = new System.Drawing.Size(109, 13);
            this.lblNormalImactSpeed.TabIndex = 99;
            this.lblNormalImactSpeed.Text = "Normal Impact Speed";
            // 
            // lblDeg
            // 
            this.lblDeg.AutoSize = true;
            this.lblDeg.Location = new System.Drawing.Point(417, 193);
            this.lblDeg.Name = "lblDeg";
            this.lblDeg.Size = new System.Drawing.Size(25, 13);
            this.lblDeg.TabIndex = 99;
            this.lblDeg.Text = "deg";
            // 
            // txtNormalImpactAngle
            // 
            this.txtNormalImpactAngle.Location = new System.Drawing.Point(365, 190);
            this.txtNormalImpactAngle.Name = "txtNormalImpactAngle";
            this.txtNormalImpactAngle.Size = new System.Drawing.Size(46, 20);
            this.txtNormalImpactAngle.TabIndex = 6;
            // 
            // lblNormalImpactAngle
            // 
            this.lblNormalImpactAngle.AutoSize = true;
            this.lblNormalImpactAngle.Location = new System.Drawing.Point(251, 193);
            this.lblNormalImpactAngle.Name = "lblNormalImpactAngle";
            this.lblNormalImpactAngle.Size = new System.Drawing.Size(108, 13);
            this.lblNormalImpactAngle.TabIndex = 99;
            this.lblNormalImpactAngle.Text = "Normal Imapct Angle:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(433, 232);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(327, 232);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add Test Type";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(245, 232);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 7;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Control;
            this.txtName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(304, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(98, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(260, 25);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 99;
            this.lblName.Text = "Name:";
            // 
            // lblRequred1
            // 
            this.lblRequred1.AutoSize = true;
            this.lblRequred1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequred1.ForeColor = System.Drawing.Color.Red;
            this.lblRequred1.Location = new System.Drawing.Point(248, 22);
            this.lblRequred1.Name = "lblRequred1";
            this.lblRequred1.Size = new System.Drawing.Size(16, 20);
            this.lblRequred1.TabIndex = 100;
            this.lblRequred1.Text = "*";
            // 
            // lblRequired2
            // 
            this.lblRequired2.AutoSize = true;
            this.lblRequired2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequired2.ForeColor = System.Drawing.Color.Red;
            this.lblRequired2.Location = new System.Drawing.Point(228, 52);
            this.lblRequired2.Name = "lblRequired2";
            this.lblRequired2.Size = new System.Drawing.Size(16, 20);
            this.lblRequired2.TabIndex = 101;
            this.lblRequired2.Text = "*";
            // 
            // lblRequired3
            // 
            this.lblRequired3.AutoSize = true;
            this.lblRequired3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequired3.ForeColor = System.Drawing.Color.Red;
            this.lblRequired3.Location = new System.Drawing.Point(268, 114);
            this.lblRequired3.Name = "lblRequired3";
            this.lblRequired3.Size = new System.Drawing.Size(16, 20);
            this.lblRequired3.TabIndex = 102;
            this.lblRequired3.Text = "*";
            // 
            // lblRequired4
            // 
            this.lblRequired4.AutoSize = true;
            this.lblRequired4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequired4.ForeColor = System.Drawing.Color.Red;
            this.lblRequired4.Location = new System.Drawing.Point(253, 137);
            this.lblRequired4.Name = "lblRequired4";
            this.lblRequired4.Size = new System.Drawing.Size(16, 20);
            this.lblRequired4.TabIndex = 103;
            this.lblRequired4.Text = "*";
            // 
            // lblRequired5
            // 
            this.lblRequired5.AutoSize = true;
            this.lblRequired5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequired5.ForeColor = System.Drawing.Color.Red;
            this.lblRequired5.Location = new System.Drawing.Point(238, 164);
            this.lblRequired5.Name = "lblRequired5";
            this.lblRequired5.Size = new System.Drawing.Size(16, 20);
            this.lblRequired5.TabIndex = 104;
            this.lblRequired5.Text = "*";
            // 
            // lblRequired6
            // 
            this.lblRequired6.AutoSize = true;
            this.lblRequired6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequired6.ForeColor = System.Drawing.Color.Red;
            this.lblRequired6.Location = new System.Drawing.Point(239, 191);
            this.lblRequired6.Name = "lblRequired6";
            this.lblRequired6.Size = new System.Drawing.Size(16, 20);
            this.lblRequired6.TabIndex = 105;
            this.lblRequired6.Text = "*";
            // 
            // IMPFrmProtocol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 267);
            this.Controls.Add(this.lblRequired6);
            this.Controls.Add(this.lblRequired5);
            this.Controls.Add(this.lblRequired4);
            this.Controls.Add(this.lblRequired3);
            this.Controls.Add(this.lblRequired2);
            this.Controls.Add(this.lblRequred1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblDeg);
            this.Controls.Add(this.txtNormalImpactAngle);
            this.Controls.Add(this.lblNormalImpactAngle);
            this.Controls.Add(this.lblMetersPerSecond);
            this.Controls.Add(this.txtMetersPerSecond);
            this.Controls.Add(this.lblNormalImactSpeed);
            this.Controls.Add(this.cmboTargetingMethod);
            this.Controls.Add(this.lblTargetingMethod);
            this.Controls.Add(this.lblKg);
            this.Controls.Add(this.txtKg);
            this.Controls.Add(this.lblImpactorMass);
            this.Controls.Add(this.cmboTestType);
            this.Controls.Add(this.lblTestType);
            this.Controls.Add(this.lstProtocols);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IMPFrmProtocol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Protocol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lstProtocols;
        private System.Windows.Forms.Label lblTestType;
        private System.Windows.Forms.ComboBox cmboTestType;
        private System.Windows.Forms.Label lblImpactorMass;
        private System.Windows.Forms.TextBox txtKg;
        private System.Windows.Forms.Label lblKg;
        private System.Windows.Forms.Label lblTargetingMethod;
        private System.Windows.Forms.ComboBox cmboTargetingMethod;
        private System.Windows.Forms.Label lblMetersPerSecond;
        private System.Windows.Forms.TextBox txtMetersPerSecond;
        private System.Windows.Forms.Label lblNormalImactSpeed;
        private System.Windows.Forms.Label lblDeg;
        private System.Windows.Forms.TextBox txtNormalImpactAngle;
        private System.Windows.Forms.Label lblNormalImpactAngle;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblRequred1;
        private System.Windows.Forms.Label lblRequired2;
        private System.Windows.Forms.Label lblRequired3;
        private System.Windows.Forms.Label lblRequired4;
        private System.Windows.Forms.Label lblRequired5;
        private System.Windows.Forms.Label lblRequired6;
    }
}