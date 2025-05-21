namespace Impactor
{
    partial class IMPSpecimen
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
            this.lstSpecimens = new System.Windows.Forms.ListBox();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.txtMass = new System.Windows.Forms.TextBox();
            this.lblMass = new System.Windows.Forms.Label();
            this.txtVIN = new System.Windows.Forms.TextBox();
            this.lblVIN = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.txtMake = new System.Windows.Forms.TextBox();
            this.lblMake = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmboCustomer = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdateSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.ckActive = new System.Windows.Forms.CheckBox();
            this.ckShowAll = new System.Windows.Forms.CheckBox();
            this.grpGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstSpecimens
            // 
            this.lstSpecimens.FormattingEnabled = true;
            this.lstSpecimens.Location = new System.Drawing.Point(12, 12);
            this.lstSpecimens.Name = "lstSpecimens";
            this.lstSpecimens.Size = new System.Drawing.Size(271, 355);
            this.lstSpecimens.TabIndex = 0;
            this.lstSpecimens.SelectedIndexChanged += new System.EventHandler(this.LstSpecimen_SelectIndexChanged);
            // 
            // grpGeneral
            // 
            this.grpGeneral.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grpGeneral.Controls.Add(this.ckActive);
            this.grpGeneral.Controls.Add(this.txtMass);
            this.grpGeneral.Controls.Add(this.lblMass);
            this.grpGeneral.Controls.Add(this.txtVIN);
            this.grpGeneral.Controls.Add(this.lblVIN);
            this.grpGeneral.Controls.Add(this.txtModel);
            this.grpGeneral.Controls.Add(this.lblModel);
            this.grpGeneral.Controls.Add(this.txtMake);
            this.grpGeneral.Controls.Add(this.lblMake);
            this.grpGeneral.Controls.Add(this.txtYear);
            this.grpGeneral.Controls.Add(this.lblYear);
            this.grpGeneral.Location = new System.Drawing.Point(304, 65);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(318, 189);
            this.grpGeneral.TabIndex = 3;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General Data";
            // 
            // txtMass
            // 
            this.txtMass.Enabled = false;
            this.txtMass.Location = new System.Drawing.Point(65, 122);
            this.txtMass.Name = "txtMass";
            this.txtMass.Size = new System.Drawing.Size(47, 20);
            this.txtMass.TabIndex = 4;
            this.txtMass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMass
            // 
            this.lblMass.AutoSize = true;
            this.lblMass.Location = new System.Drawing.Point(3, 125);
            this.lblMass.Name = "lblMass";
            this.lblMass.Size = new System.Drawing.Size(56, 13);
            this.lblMass.TabIndex = 99;
            this.lblMass.Text = "Mass (kg):";
            // 
            // txtVIN
            // 
            this.txtVIN.Enabled = false;
            this.txtVIN.Location = new System.Drawing.Point(65, 96);
            this.txtVIN.Name = "txtVIN";
            this.txtVIN.Size = new System.Drawing.Size(235, 20);
            this.txtVIN.TabIndex = 3;
            // 
            // lblVIN
            // 
            this.lblVIN.AutoSize = true;
            this.lblVIN.Location = new System.Drawing.Point(31, 99);
            this.lblVIN.Name = "lblVIN";
            this.lblVIN.Size = new System.Drawing.Size(28, 13);
            this.lblVIN.TabIndex = 99;
            this.lblVIN.Text = "VIN:";
            // 
            // txtModel
            // 
            this.txtModel.Enabled = false;
            this.txtModel.Location = new System.Drawing.Point(65, 70);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(136, 20);
            this.txtModel.TabIndex = 2;
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(20, 73);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(39, 13);
            this.lblModel.TabIndex = 99;
            this.lblModel.Text = "Model:";
            // 
            // txtMake
            // 
            this.txtMake.Enabled = false;
            this.txtMake.Location = new System.Drawing.Point(65, 44);
            this.txtMake.Name = "txtMake";
            this.txtMake.Size = new System.Drawing.Size(136, 20);
            this.txtMake.TabIndex = 1;
            // 
            // lblMake
            // 
            this.lblMake.AutoSize = true;
            this.lblMake.Location = new System.Drawing.Point(22, 47);
            this.lblMake.Name = "lblMake";
            this.lblMake.Size = new System.Drawing.Size(37, 13);
            this.lblMake.TabIndex = 99;
            this.lblMake.Text = "Make:";
            // 
            // txtYear
            // 
            this.txtYear.Enabled = false;
            this.txtYear.Location = new System.Drawing.Point(65, 18);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(37, 20);
            this.txtYear.TabIndex = 0;
            this.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(27, 21);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(32, 13);
            this.lblYear.TabIndex = 99;
            this.lblYear.Text = "Year:";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(300, 9);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(54, 13);
            this.lblCustomer.TabIndex = 99;
            this.lblCustomer.Text = "Customer:";
            // 
            // cmboCustomer
            // 
            this.cmboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboCustomer.Enabled = false;
            this.cmboCustomer.FormattingEnabled = true;
            this.cmboCustomer.Location = new System.Drawing.Point(303, 25);
            this.cmboCustomer.Name = "cmboCustomer";
            this.cmboCustomer.Size = new System.Drawing.Size(219, 21);
            this.cmboCustomer.Sorted = true;
            this.cmboCustomer.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(521, 373);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 25);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnUpdateSave
            // 
            this.btnUpdateSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateSave.Enabled = false;
            this.btnUpdateSave.Location = new System.Drawing.Point(410, 373);
            this.btnUpdateSave.Name = "btnUpdateSave";
            this.btnUpdateSave.Size = new System.Drawing.Size(105, 25);
            this.btnUpdateSave.TabIndex = 7;
            this.btnUpdateSave.UseVisualStyleBackColor = true;
            this.btnUpdateSave.Click += new System.EventHandler(this.BtnUpdateSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(299, 373);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(105, 25);
            this.btnNew.TabIndex = 6;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(300, 269);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 99;
            this.lblNotes.Text = "Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Enabled = false;
            this.txtNotes.Location = new System.Drawing.Point(303, 285);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(319, 82);
            this.txtNotes.TabIndex = 4;
            // 
            // ckActive
            // 
            this.ckActive.AutoSize = true;
            this.ckActive.Location = new System.Drawing.Point(23, 148);
            this.ckActive.Name = "ckActive";
            this.ckActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckActive.Size = new System.Drawing.Size(56, 17);
            this.ckActive.TabIndex = 101;
            this.ckActive.Text = "Active";
            this.ckActive.UseVisualStyleBackColor = true;
            // 
            // ckShowAll
            // 
            this.ckShowAll.AutoSize = true;
            this.ckShowAll.Location = new System.Drawing.Point(528, 27);
            this.ckShowAll.Name = "ckShowAll";
            this.ckShowAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckShowAll.Size = new System.Drawing.Size(67, 17);
            this.ckShowAll.TabIndex = 102;
            this.ckShowAll.Text = "Show All";
            this.ckShowAll.UseVisualStyleBackColor = true;
            this.ckShowAll.CheckedChanged += new System.EventHandler(this.CkShowAll_Clicked);
            // 
            // IMPSpecimen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 410);
            this.Controls.Add(this.ckShowAll);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnUpdateSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cmboCustomer);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.grpGeneral);
            this.Controls.Add(this.lstSpecimens);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IMPSpecimen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Specimen";
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstSpecimens;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblMake;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmboCustomer;
        private System.Windows.Forms.TextBox txtVIN;
        private System.Windows.Forms.Label lblVIN;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox txtMake;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdateSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtMass;
        private System.Windows.Forms.Label lblMass;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.CheckBox ckActive;
        private System.Windows.Forms.CheckBox ckShowAll;
    }
}