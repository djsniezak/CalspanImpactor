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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IMPFrmImpactor));
            this.ctrlTestFilter = new ImpactorControls.CtrlTestFilter();
            this.ctlTestSetUp = new ImpactorControls.CtlTestSetUp();
            this.ctlParameters = new ImpactorControls.CtlParameters();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnSeperatorOne = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnSeperatorTwo = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.btnSeperatorThree = new System.Windows.Forms.ToolStripButton();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.ctlProtocol1 = new Controls.CtlProtocol();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlTestFilter
            // 
            this.ctrlTestFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ctrlTestFilter.Location = new System.Drawing.Point(12, 28);
            this.ctrlTestFilter.Name = "ctrlTestFilter";
            this.ctrlTestFilter.Size = new System.Drawing.Size(218, 703);
            this.ctrlTestFilter.TabIndex = 0;
            // 
            // ctlTestSetUp
            // 
            this.ctlTestSetUp.Location = new System.Drawing.Point(236, 28);
            this.ctlTestSetUp.Name = "ctlTestSetUp";
            this.ctlTestSetUp.Size = new System.Drawing.Size(525, 236);
            this.ctlTestSetUp.TabIndex = 1;
            this.ctlTestSetUp.TestId = ((long)(-9223372036854775808));
            // 
            // ctlParameters
            // 
            this.ctlParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlParameters.ImpactorAxisId = ((long)(-9223372036854775808));
            this.ctlParameters.ImpactorParametersId = ((long)(-9223372036854775808));
            this.ctlParameters.Location = new System.Drawing.Point(236, 270);
            this.ctlParameters.Name = "ctlParameters";
            this.ctlParameters.Size = new System.Drawing.Size(729, 461);
            this.ctlParameters.TabIndex = 2;
            this.ctlParameters.TestId = ((long)(-9223372036854775808));
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnSeperatorOne,
            this.btnSave,
            this.btnSeperatorTwo,
            this.btnCopy,
            this.btnSeperatorThree,
            this.btnReload});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1455, 28);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(49, 25);
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.BtnNew);
            // 
            // btnSeperatorOne
            // 
            this.btnSeperatorOne.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSeperatorOne.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSeperatorOne.Name = "btnSeperatorOne";
            this.btnSeperatorOne.Size = new System.Drawing.Size(23, 25);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 25);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.BtnSave);
            // 
            // btnSeperatorTwo
            // 
            this.btnSeperatorTwo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSeperatorTwo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSeperatorTwo.Name = "btnSeperatorTwo";
            this.btnSeperatorTwo.Size = new System.Drawing.Size(23, 25);
            // 
            // btnCopy
            // 
            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCopy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(53, 25);
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.BtnCopy);
            // 
            // btnSeperatorThree
            // 
            this.btnSeperatorThree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSeperatorThree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSeperatorThree.Name = "btnSeperatorThree";
            this.btnSeperatorThree.Size = new System.Drawing.Size(23, 25);
            // 
            // btnReload
            // 
            this.btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReload.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(67, 25);
            this.btnReload.Text = "Reload";
            this.btnReload.Click += new System.EventHandler(this.BtnReload);
            // 
            // ctlProtocol1
            // 
            this.ctlProtocol1.Location = new System.Drawing.Point(971, 31);
            this.ctlProtocol1.Name = "ctlProtocol1";
            this.ctlProtocol1.Size = new System.Drawing.Size(472, 452);
            this.ctlProtocol1.TabIndex = 4;
            // 
            // IMPFrmImpactor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1455, 739);
            this.Controls.Add(this.ctlProtocol1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ctlParameters);
            this.Controls.Add(this.ctlTestSetUp);
            this.Controls.Add(this.ctrlTestFilter);
            this.Name = "IMPFrmImpactor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Impactor Test";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImpactorControls.CtrlTestFilter ctrlTestFilter;
        private ImpactorControls.CtlTestSetUp ctlTestSetUp;
        private ImpactorControls.CtlParameters ctlParameters;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnSeperatorOne;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnSeperatorTwo;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripButton btnSeperatorThree;
        private System.Windows.Forms.ToolStripButton btnReload;
        private Controls.CtlProtocol ctlProtocol1;
    }
}