namespace Impactor
{
    partial class IMPFrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IMPFrmMain));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatabaseEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClient = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImpactorType = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTestType = new System.Windows.Forms.ToolStripMenuItem();
            this.testsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImpactor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProtocol = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuDatabaseEditor,
            this.testsToolStripMenuItem,
            this.mnuReports,
            this.mnuAbout});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(800, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(93, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.MnuExit);
            // 
            // mnuDatabaseEditor
            // 
            this.mnuDatabaseEditor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClient,
            this.mnuImpactorType,
            this.mnuProtocol,
            this.mnuTestType});
            this.mnuDatabaseEditor.Name = "mnuDatabaseEditor";
            this.mnuDatabaseEditor.Size = new System.Drawing.Size(101, 20);
            this.mnuDatabaseEditor.Text = "Database Editor";
            // 
            // mnuClient
            // 
            this.mnuClient.Name = "mnuClient";
            this.mnuClient.Size = new System.Drawing.Size(180, 22);
            this.mnuClient.Text = "Client";
            this.mnuClient.Click += new System.EventHandler(this.MnuClient_Click);
            // 
            // mnuImpactorType
            // 
            this.mnuImpactorType.Name = "mnuImpactorType";
            this.mnuImpactorType.Size = new System.Drawing.Size(180, 22);
            this.mnuImpactorType.Text = "Impactor Type";
            this.mnuImpactorType.Click += new System.EventHandler(this.MnuImpactorType_Click);
            // 
            // mnuTestType
            // 
            this.mnuTestType.Name = "mnuTestType";
            this.mnuTestType.Size = new System.Drawing.Size(180, 22);
            this.mnuTestType.Text = "Test Type";
            this.mnuTestType.Click += new System.EventHandler(this.MnuTestType_Click);
            // 
            // testsToolStripMenuItem
            // 
            this.testsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImpactor});
            this.testsToolStripMenuItem.Name = "testsToolStripMenuItem";
            this.testsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.testsToolStripMenuItem.Text = "Tests";
            // 
            // mnuImpactor
            // 
            this.mnuImpactor.Name = "mnuImpactor";
            this.mnuImpactor.Size = new System.Drawing.Size(122, 22);
            this.mnuImpactor.Text = "Impactor";
            this.mnuImpactor.Click += new System.EventHandler(this.MnuImpactor_Click);
            // 
            // mnuReports
            // 
            this.mnuReports.Name = "mnuReports";
            this.mnuReports.Size = new System.Drawing.Size(59, 20);
            this.mnuReports.Text = "Reports";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(52, 20);
            this.mnuAbout.Text = "About";
            this.mnuAbout.Click += new System.EventHandler(this.MnuAbout_Click);
            // 
            // mnuProtocol
            // 
            this.mnuProtocol.Name = "mnuProtocol";
            this.mnuProtocol.Size = new System.Drawing.Size(180, 22);
            this.mnuProtocol.Text = "Protocol";
            this.mnuProtocol.Click += new System.EventHandler(this.MnuProtocil_Click);
            // 
            // IMPFrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "IMPFrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calspan Impactor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuDatabaseEditor;
        private System.Windows.Forms.ToolStripMenuItem mnuClient;
        private System.Windows.Forms.ToolStripMenuItem mnuTestType;
        private System.Windows.Forms.ToolStripMenuItem testsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuImpactor;
        private System.Windows.Forms.ToolStripMenuItem mnuReports;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuImpactorType;
        private System.Windows.Forms.ToolStripMenuItem mnuProtocol;
    }
}

