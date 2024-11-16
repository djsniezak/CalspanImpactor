namespace Impactor
{
    partial class IMPClient
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
            this.lstClient = new System.Windows.Forms.ListBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.lblShortNamw = new System.Windows.Forms.Label();
            this.txtClientPrefix = new System.Windows.Forms.TextBox();
            this.lblClientPrefix = new System.Windows.Forms.Label();
            this.txtClientCode = new System.Windows.Forms.TextBox();
            this.lblClientCode = new System.Windows.Forms.Label();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.lblZip = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.ckActive = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblRequired1 = new System.Windows.Forms.Label();
            this.lblRequired2 = new System.Windows.Forms.Label();
            this.lblRequired3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(568, 277);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // lstClient
            // 
            this.lstClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstClient.FormattingEnabled = true;
            this.lstClient.Location = new System.Drawing.Point(12, 12);
            this.lstClient.Name = "lstClient";
            this.lstClient.Size = new System.Drawing.Size(228, 277);
            this.lstClient.TabIndex = 1;
            this.lstClient.SelectedIndexChanged += new System.EventHandler(this.LstClient_SelectedIndexChanged);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(266, 12);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(85, 13);
            this.lblCompanyName.TabIndex = 99;
            this.lblCompanyName.Text = "Company Name:";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(357, 9);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(214, 20);
            this.txtCompanyName.TabIndex = 2;
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(357, 35);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(68, 20);
            this.txtShortName.TabIndex = 5;
            // 
            // lblShortNamw
            // 
            this.lblShortNamw.AutoSize = true;
            this.lblShortNamw.Location = new System.Drawing.Point(285, 38);
            this.lblShortNamw.Name = "lblShortNamw";
            this.lblShortNamw.Size = new System.Drawing.Size(66, 13);
            this.lblShortNamw.TabIndex = 99;
            this.lblShortNamw.Text = "Short Name:";
            // 
            // txtClientPrefix
            // 
            this.txtClientPrefix.Location = new System.Drawing.Point(357, 61);
            this.txtClientPrefix.Name = "txtClientPrefix";
            this.txtClientPrefix.Size = new System.Drawing.Size(68, 20);
            this.txtClientPrefix.TabIndex = 6;
            // 
            // lblClientPrefix
            // 
            this.lblClientPrefix.AutoSize = true;
            this.lblClientPrefix.Location = new System.Drawing.Point(286, 64);
            this.lblClientPrefix.Name = "lblClientPrefix";
            this.lblClientPrefix.Size = new System.Drawing.Size(65, 13);
            this.lblClientPrefix.TabIndex = 99;
            this.lblClientPrefix.Text = "Client Prefix:";
            // 
            // txtClientCode
            // 
            this.txtClientCode.Location = new System.Drawing.Point(357, 87);
            this.txtClientCode.Name = "txtClientCode";
            this.txtClientCode.Size = new System.Drawing.Size(68, 20);
            this.txtClientCode.TabIndex = 7;
            // 
            // lblClientCode
            // 
            this.lblClientCode.AutoSize = true;
            this.lblClientCode.Location = new System.Drawing.Point(287, 90);
            this.lblClientCode.Name = "lblClientCode";
            this.lblClientCode.Size = new System.Drawing.Size(64, 13);
            this.lblClientCode.TabIndex = 99;
            this.lblClientCode.Text = "Client Code:";
            // 
            // txtAddress1
            // 
            this.txtAddress1.Location = new System.Drawing.Point(357, 141);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(214, 20);
            this.txtAddress1.TabIndex = 8;
            // 
            // lblAddress1
            // 
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Location = new System.Drawing.Point(294, 144);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(57, 13);
            this.lblAddress1.TabIndex = 99;
            this.lblAddress1.Text = "Address 1:";
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(357, 167);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(214, 20);
            this.txtAddress2.TabIndex = 9;
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Location = new System.Drawing.Point(294, 170);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(57, 13);
            this.lblAddress2.TabIndex = 99;
            this.lblAddress2.Text = "Address 2:";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(357, 193);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(94, 20);
            this.txtCity.TabIndex = 10;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(324, 196);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(27, 13);
            this.lblCity.TabIndex = 99;
            this.lblCity.Text = "City:";
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(500, 193);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(37, 20);
            this.txtState.TabIndex = 11;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(459, 196);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(35, 13);
            this.lblState.TabIndex = 99;
            this.lblState.Text = "State:";
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(578, 193);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(66, 20);
            this.txtZip.TabIndex = 12;
            // 
            // lblZip
            // 
            this.lblZip.AutoSize = true;
            this.lblZip.Location = new System.Drawing.Point(547, 196);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(25, 13);
            this.lblZip.TabIndex = 99;
            this.lblZip.Text = "Zip:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(357, 232);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(94, 20);
            this.txtPhone.TabIndex = 13;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(270, 235);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(81, 13);
            this.lblPhoneNumber.TabIndex = 99;
            this.lblPhoneNumber.Text = "Phone Number:";
            // 
            // ckActive
            // 
            this.ckActive.AutoSize = true;
            this.ckActive.Location = new System.Drawing.Point(590, 12);
            this.ckActive.Name = "ckActive";
            this.ckActive.Size = new System.Drawing.Size(56, 17);
            this.ckActive.TabIndex = 4;
            this.ckActive.Text = "Active";
            this.ckActive.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(487, 277);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Clicked);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(406, 277);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 14;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Clicked);
            // 
            // lblRequired1
            // 
            this.lblRequired1.AutoSize = true;
            this.lblRequired1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequired1.ForeColor = System.Drawing.Color.Red;
            this.lblRequired1.Location = new System.Drawing.Point(251, 9);
            this.lblRequired1.Name = "lblRequired1";
            this.lblRequired1.Size = new System.Drawing.Size(16, 20);
            this.lblRequired1.TabIndex = 100;
            this.lblRequired1.Text = "*";
            // 
            // lblRequired2
            // 
            this.lblRequired2.AutoSize = true;
            this.lblRequired2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequired2.ForeColor = System.Drawing.Color.Red;
            this.lblRequired2.Location = new System.Drawing.Point(272, 35);
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
            this.lblRequired3.Location = new System.Drawing.Point(272, 61);
            this.lblRequired3.Name = "lblRequired3";
            this.lblRequired3.Size = new System.Drawing.Size(16, 20);
            this.lblRequired3.TabIndex = 102;
            this.lblRequired3.Text = "*";
            // 
            // IMPClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 312);
            this.Controls.Add(this.lblRequired3);
            this.Controls.Add(this.lblRequired2);
            this.Controls.Add(this.lblRequired1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.ckActive);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.lblZip);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txtAddress2);
            this.Controls.Add(this.lblAddress2);
            this.Controls.Add(this.txtAddress1);
            this.Controls.Add(this.lblAddress1);
            this.Controls.Add(this.txtClientCode);
            this.Controls.Add(this.lblClientCode);
            this.Controls.Add(this.txtClientPrefix);
            this.Controls.Add(this.lblClientPrefix);
            this.Controls.Add(this.txtShortName);
            this.Controls.Add(this.lblShortNamw);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.lstClient);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IMPClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lstClient;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.Label lblShortNamw;
        private System.Windows.Forms.TextBox txtClientPrefix;
        private System.Windows.Forms.Label lblClientPrefix;
        private System.Windows.Forms.TextBox txtClientCode;
        private System.Windows.Forms.Label lblClientCode;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.Label lblAddress1;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.Label lblZip;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.CheckBox ckActive;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblRequired1;
        private System.Windows.Forms.Label lblRequired2;
        private System.Windows.Forms.Label lblRequired3;
    }
}