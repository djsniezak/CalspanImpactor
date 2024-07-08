namespace Impactor
{
    partial class IMPAbout
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
            this.lblImpactor = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblVersionValue = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picCalspanLogo = new System.Windows.Forms.PictureBox();
            this.lblPoweredBy = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCalspanLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(345, 296);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblImpactor
            // 
            this.lblImpactor.AutoSize = true;
            this.lblImpactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImpactor.Location = new System.Drawing.Point(125, 150);
            this.lblImpactor.Name = "lblImpactor";
            this.lblImpactor.Size = new System.Drawing.Size(169, 42);
            this.lblImpactor.TabIndex = 2;
            this.lblImpactor.Text = "Impactor";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(12, 204);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(122, 31);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "Version:";
            // 
            // lblVersionValue
            // 
            this.lblVersionValue.AutoSize = true;
            this.lblVersionValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersionValue.Location = new System.Drawing.Point(140, 204);
            this.lblVersionValue.Name = "lblVersionValue";
            this.lblVersionValue.Size = new System.Drawing.Size(165, 31);
            this.lblVersionValue.TabIndex = 4;
            this.lblVersionValue.Text = "XX.XX.XXX";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Impactor.Properties.Resources.ProgramsPlus11;
            this.pictureBox1.Location = new System.Drawing.Point(204, 254);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 72);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // picCalspanLogo
            // 
            this.picCalspanLogo.Image = global::Impactor.Properties.Resources.Calspan_Logo;
            this.picCalspanLogo.InitialImage = global::Impactor.Properties.Resources.Calspan_Logo;
            this.picCalspanLogo.Location = new System.Drawing.Point(12, 12);
            this.picCalspanLogo.Name = "picCalspanLogo";
            this.picCalspanLogo.Size = new System.Drawing.Size(408, 114);
            this.picCalspanLogo.TabIndex = 1;
            this.picCalspanLogo.TabStop = false;
            // 
            // lblPoweredBy
            // 
            this.lblPoweredBy.AutoSize = true;
            this.lblPoweredBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoweredBy.Location = new System.Drawing.Point(12, 278);
            this.lblPoweredBy.Name = "lblPoweredBy";
            this.lblPoweredBy.Size = new System.Drawing.Size(179, 31);
            this.lblPoweredBy.TabIndex = 6;
            this.lblPoweredBy.Text = "Powered By:";
            // 
            // IMPAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 331);
            this.Controls.Add(this.lblPoweredBy);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblVersionValue);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblImpactor);
            this.Controls.Add(this.picCalspanLogo);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IMPAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About Calspan Impactor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCalspanLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox picCalspanLogo;
        private System.Windows.Forms.Label lblImpactor;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblVersionValue;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPoweredBy;
    }
}