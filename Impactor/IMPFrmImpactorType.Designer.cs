namespace Impactor
{
    partial class IMPFrmImpactorType
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
            this.lstImpactorType = new System.Windows.Forms.ListBox();
            this.lblImpactorType = new System.Windows.Forms.Label();
            this.cmboImpactorTestType = new System.Windows.Forms.ComboBox();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.lblOwner = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblRequired1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(451, 154);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // lstImpactorType
            // 
            this.lstImpactorType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstImpactorType.FormattingEnabled = true;
            this.lstImpactorType.Location = new System.Drawing.Point(12, 12);
            this.lstImpactorType.Name = "lstImpactorType";
            this.lstImpactorType.Size = new System.Drawing.Size(200, 147);
            this.lstImpactorType.TabIndex = 0;
            this.lstImpactorType.SelectedIndexChanged += new System.EventHandler(this.LstImpactorType_SelectedIndexChanged);
            // 
            // lblImpactorType
            // 
            this.lblImpactorType.AutoSize = true;
            this.lblImpactorType.Location = new System.Drawing.Point(239, 12);
            this.lblImpactorType.Name = "lblImpactorType";
            this.lblImpactorType.Size = new System.Drawing.Size(81, 13);
            this.lblImpactorType.TabIndex = 99;
            this.lblImpactorType.Text = "Impactor Type: ";
            // 
            // cmboImpactorTestType
            // 
            this.cmboImpactorTestType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmboImpactorTestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboImpactorTestType.FormattingEnabled = true;
            this.cmboImpactorTestType.Location = new System.Drawing.Point(326, 9);
            this.cmboImpactorTestType.Name = "cmboImpactorTestType";
            this.cmboImpactorTestType.Size = new System.Drawing.Size(200, 21);
            this.cmboImpactorTestType.TabIndex = 1;
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.AutoSize = true;
            this.lblSerialNumber.Location = new System.Drawing.Point(244, 39);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(76, 13);
            this.lblSerialNumber.TabIndex = 99;
            this.lblSerialNumber.Text = "Serial Number:";
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Location = new System.Drawing.Point(326, 36);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(100, 20);
            this.txtSerialNumber.TabIndex = 2;
            // 
            // txtOwner
            // 
            this.txtOwner.Location = new System.Drawing.Point(326, 62);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(100, 20);
            this.txtOwner.TabIndex = 3;
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = true;
            this.lblOwner.Location = new System.Drawing.Point(279, 65);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(41, 13);
            this.lblOwner.TabIndex = 99;
            this.lblOwner.Text = "Owner:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(370, 154);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(289, 154);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // lblRequired1
            // 
            this.lblRequired1.AutoSize = true;
            this.lblRequired1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequired1.ForeColor = System.Drawing.Color.Red;
            this.lblRequired1.Location = new System.Drawing.Point(226, 8);
            this.lblRequired1.Name = "lblRequired1";
            this.lblRequired1.Size = new System.Drawing.Size(16, 20);
            this.lblRequired1.TabIndex = 100;
            this.lblRequired1.Text = "*";
            // 
            // IMPFrmImpactorType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 189);
            this.Controls.Add(this.lblRequired1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtOwner);
            this.Controls.Add(this.lblOwner);
            this.Controls.Add(this.txtSerialNumber);
            this.Controls.Add(this.lblSerialNumber);
            this.Controls.Add(this.cmboImpactorTestType);
            this.Controls.Add(this.lblImpactorType);
            this.Controls.Add(this.lstImpactorType);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IMPFrmImpactorType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impactor Type";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lstImpactorType;
        private System.Windows.Forms.Label lblImpactorType;
        private System.Windows.Forms.ComboBox cmboImpactorTestType;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblRequired1;
    }
}