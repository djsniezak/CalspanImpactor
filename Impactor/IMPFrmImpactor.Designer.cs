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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnSeperatorOne = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnSeperatorTwo = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.btnSeperatorThree = new System.Windows.Forms.ToolStripButton();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnClearAll = new System.Windows.Forms.ToolStripButton();
            this.ctlProtocol = new Controls.CtlProtocol();
            this.ctlParameters = new ImpactorControls.CtlParameters();
            this.ctlTestSetUp = new ImpactorControls.CtlTestSetUp();
            this.ctrlTestFilter = new ImpactorControls.CtrlTestFilter();
            this.ctlTires = new Controls.CtlTires();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.btnReload,
            this.toolStripLabel1,
            this.btnClearAll});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1246, 28);
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
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(142, 25);
            this.toolStripLabel1.Text = "                                             ";
            // 
            // btnClearAll
            // 
            this.btnClearAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClearAll.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAll.Image = ((System.Drawing.Image)(resources.GetObject("btnClearAll.Image")));
            this.btnClearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(78, 25);
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.Click += new System.EventHandler(this.BrnClearAll_Click);
            // 
            // ctlProtocol
            // 
            this.ctlProtocol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlProtocol.Location = new System.Drawing.Point(971, 279);
            this.ctlProtocol.Name = "ctlProtocol";
            this.ctlProtocol.Size = new System.Drawing.Size(263, 230);
            this.ctlProtocol.TabIndex = 6;
            this.ctlProtocol.TestType = ((long)(-9223372036854775808));
            // 
            // ctlParameters
            // 
            this.ctlParameters.ImpactorParametersId = ((long)(-9223372036854775808));
            this.ctlParameters.Location = new System.Drawing.Point(236, 279);
            this.ctlParameters.Name = "ctlParameters";
            this.ctlParameters.Size = new System.Drawing.Size(732, 438);
            this.ctlParameters.TabIndex = 5;
            this.ctlParameters.TestId = ((long)(-9223372036854775808));
            this.ctlParameters.TestTypeId = ((long)(-9223372036854775808));
            // 
            // ctlTestSetUp
            // 
            this.ctlTestSetUp.Location = new System.Drawing.Point(237, 28);
            this.ctlTestSetUp.Name = "ctlTestSetUp";
            this.ctlTestSetUp.ProtocolId = ((long)(-9223372036854775808));
            this.ctlTestSetUp.Size = new System.Drawing.Size(525, 249);
            this.ctlTestSetUp.TabIndex = 1;
            this.ctlTestSetUp.TestId = ((long)(-9223372036854775808));
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
            // ctlTires
            // 
            this.ctlTires.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlTires.Location = new System.Drawing.Point(822, 28);
            this.ctlTires.Name = "ctlTires";
            this.ctlTires.Size = new System.Drawing.Size(412, 246);
            this.ctlTires.TabIndex = 7;
            // 
            // IMPFrmImpactor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 739);
            this.Controls.Add(this.ctlTires);
            this.Controls.Add(this.ctlProtocol);
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
        private Controls.CtlProtocol ctlProtocol;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnClearAll;
        private Controls.CtlTires ctlTires;
    }
}