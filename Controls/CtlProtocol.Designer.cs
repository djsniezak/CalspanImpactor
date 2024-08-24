namespace Controls
{
    partial class CtlProtocol
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpProtocol = new System.Windows.Forms.GroupBox();
            this.lblProtocol = new System.Windows.Forms.Label();
            this.cboProtocol = new System.Windows.Forms.ComboBox();
            this.lblImpactorMass = new System.Windows.Forms.Label();
            this.txtImpactorMass = new System.Windows.Forms.TextBox();
            this.txtTargetingMethod = new System.Windows.Forms.TextBox();
            this.lblTargetingMethod = new System.Windows.Forms.Label();
            this.txtSpeedPerSecond = new System.Windows.Forms.TextBox();
            this.lblSpeedPerSecod = new System.Windows.Forms.Label();
            this.txtImpactAngle = new System.Windows.Forms.TextBox();
            this.lblImpactAngle = new System.Windows.Forms.Label();
            this.grpProtocol.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpProtocol
            // 
            this.grpProtocol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProtocol.Controls.Add(this.txtImpactAngle);
            this.grpProtocol.Controls.Add(this.lblImpactAngle);
            this.grpProtocol.Controls.Add(this.txtSpeedPerSecond);
            this.grpProtocol.Controls.Add(this.lblSpeedPerSecod);
            this.grpProtocol.Controls.Add(this.txtTargetingMethod);
            this.grpProtocol.Controls.Add(this.lblTargetingMethod);
            this.grpProtocol.Controls.Add(this.txtImpactorMass);
            this.grpProtocol.Controls.Add(this.lblImpactorMass);
            this.grpProtocol.Controls.Add(this.cboProtocol);
            this.grpProtocol.Controls.Add(this.lblProtocol);
            this.grpProtocol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpProtocol.Location = new System.Drawing.Point(3, 3);
            this.grpProtocol.Name = "grpProtocol";
            this.grpProtocol.Size = new System.Drawing.Size(326, 238);
            this.grpProtocol.TabIndex = 0;
            this.grpProtocol.TabStop = false;
            this.grpProtocol.Text = "Protocol";
            // 
            // lblProtocol
            // 
            this.lblProtocol.AutoSize = true;
            this.lblProtocol.Location = new System.Drawing.Point(6, 45);
            this.lblProtocol.Name = "lblProtocol";
            this.lblProtocol.Size = new System.Drawing.Size(58, 13);
            this.lblProtocol.TabIndex = 0;
            this.lblProtocol.Text = "Protocol:";
            // 
            // cboProtocol
            // 
            this.cboProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProtocol.FormattingEnabled = true;
            this.cboProtocol.Location = new System.Drawing.Point(70, 42);
            this.cboProtocol.Name = "cboProtocol";
            this.cboProtocol.Size = new System.Drawing.Size(135, 21);
            this.cboProtocol.TabIndex = 1;
            // 
            // lblImpactorMass
            // 
            this.lblImpactorMass.AutoSize = true;
            this.lblImpactorMass.Location = new System.Drawing.Point(54, 85);
            this.lblImpactorMass.Name = "lblImpactorMass";
            this.lblImpactorMass.Size = new System.Drawing.Size(119, 13);
            this.lblImpactorMass.TabIndex = 99;
            this.lblImpactorMass.Text = "Impactor Mass (kg):";
            // 
            // txtImpactorMass
            // 
            this.txtImpactorMass.Location = new System.Drawing.Point(179, 82);
            this.txtImpactorMass.Name = "txtImpactorMass";
            this.txtImpactorMass.Size = new System.Drawing.Size(100, 20);
            this.txtImpactorMass.TabIndex = 3;
            // 
            // txtTargetingMethod
            // 
            this.txtTargetingMethod.Location = new System.Drawing.Point(179, 108);
            this.txtTargetingMethod.Name = "txtTargetingMethod";
            this.txtTargetingMethod.Size = new System.Drawing.Size(100, 20);
            this.txtTargetingMethod.TabIndex = 100;
            // 
            // lblTargetingMethod
            // 
            this.lblTargetingMethod.AutoSize = true;
            this.lblTargetingMethod.Location = new System.Drawing.Point(62, 111);
            this.lblTargetingMethod.Name = "lblTargetingMethod";
            this.lblTargetingMethod.Size = new System.Drawing.Size(111, 13);
            this.lblTargetingMethod.TabIndex = 101;
            this.lblTargetingMethod.Text = "Targeting Method:";
            // 
            // txtSpeedPerSecond
            // 
            this.txtSpeedPerSecond.Location = new System.Drawing.Point(179, 134);
            this.txtSpeedPerSecond.Name = "txtSpeedPerSecond";
            this.txtSpeedPerSecond.Size = new System.Drawing.Size(100, 20);
            this.txtSpeedPerSecond.TabIndex = 102;
            // 
            // lblSpeedPerSecod
            // 
            this.lblSpeedPerSecod.AutoSize = true;
            this.lblSpeedPerSecod.Location = new System.Drawing.Point(6, 137);
            this.lblSpeedPerSecod.Name = "lblSpeedPerSecod";
            this.lblSpeedPerSecod.Size = new System.Drawing.Size(167, 13);
            this.lblSpeedPerSecod.TabIndex = 103;
            this.lblSpeedPerSecod.Text = "Nominal Impact Speed (m/s)";
            // 
            // txtImpactAngle
            // 
            this.txtImpactAngle.Location = new System.Drawing.Point(179, 160);
            this.txtImpactAngle.Name = "txtImpactAngle";
            this.txtImpactAngle.Size = new System.Drawing.Size(100, 20);
            this.txtImpactAngle.TabIndex = 104;
            // 
            // lblImpactAngle
            // 
            this.lblImpactAngle.AutoSize = true;
            this.lblImpactAngle.Location = new System.Drawing.Point(6, 163);
            this.lblImpactAngle.Name = "lblImpactAngle";
            this.lblImpactAngle.Size = new System.Drawing.Size(167, 13);
            this.lblImpactAngle.TabIndex = 105;
            this.lblImpactAngle.Text = "Nominal Impact Angle (deg):";
            // 
            // CtlProtocol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpProtocol);
            this.Name = "CtlProtocol";
            this.Size = new System.Drawing.Size(332, 244);
            this.grpProtocol.ResumeLayout(false);
            this.grpProtocol.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProtocol;
        private System.Windows.Forms.Label lblProtocol;
        private System.Windows.Forms.TextBox txtTargetingMethod;
        private System.Windows.Forms.Label lblTargetingMethod;
        private System.Windows.Forms.TextBox txtImpactorMass;
        private System.Windows.Forms.Label lblImpactorMass;
        private System.Windows.Forms.ComboBox cboProtocol;
        private System.Windows.Forms.TextBox txtImpactAngle;
        private System.Windows.Forms.Label lblImpactAngle;
        private System.Windows.Forms.TextBox txtSpeedPerSecond;
        private System.Windows.Forms.Label lblSpeedPerSecod;
    }
}
