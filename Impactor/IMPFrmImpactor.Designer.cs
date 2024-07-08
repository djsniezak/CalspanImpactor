namespace Impactor
{
    partial class IMPFrmImpactor
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
            this.ctrlTestFilter1 = new Controls.CtrlTestFilter();
            this.ctlTestSetUp1 = new Controls.CtlTestSetUp();
            this.ctlParameters1 = new Controls.CtlParameters();
            this.SuspendLayout();
            // 
            // ctrlTestFilter1
            // 
            this.ctrlTestFilter1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ctrlTestFilter1.Location = new System.Drawing.Point(12, 28);
            this.ctrlTestFilter1.Name = "ctrlTestFilter1";
            this.ctrlTestFilter1.Size = new System.Drawing.Size(218, 560);
            this.ctrlTestFilter1.TabIndex = 0;
            // 
            // ctlTestSetUp1
            // 
            this.ctlTestSetUp1.Location = new System.Drawing.Point(236, 28);
            this.ctlTestSetUp1.Name = "ctlTestSetUp1";
            this.ctlTestSetUp1.Size = new System.Drawing.Size(474, 201);
            this.ctlTestSetUp1.TabIndex = 1;
            // 
            // ctlParameters1
            // 
            this.ctlParameters1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlParameters1.Location = new System.Drawing.Point(236, 235);
            this.ctlParameters1.Name = "ctlParameters1";
            this.ctlParameters1.Size = new System.Drawing.Size(593, 353);
            this.ctlParameters1.TabIndex = 2;
            // 
            // IMPFrmImpactor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 596);
            this.Controls.Add(this.ctlParameters1);
            this.Controls.Add(this.ctlTestSetUp1);
            this.Controls.Add(this.ctrlTestFilter1);
            this.Name = "IMPFrmImpactor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Impactor Test";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CtrlTestFilter ctrlTestFilter1;
        private Controls.CtlTestSetUp ctlTestSetUp1;
        private Controls.CtlParameters ctlParameters1;
    }
}