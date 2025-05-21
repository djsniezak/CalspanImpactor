namespace Controls
{
    partial class IMPFrmSelectCritical
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
            this.btnSelect = new System.Windows.Forms.Button();
            this.lblSelectCriticalInjury = new System.Windows.Forms.Label();
            this.cboCriticalInjury = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(459, 53);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(322, 53);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(131, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Select this Critcal Injury";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // lblSelectCriticalInjury
            // 
            this.lblSelectCriticalInjury.AutoSize = true;
            this.lblSelectCriticalInjury.Location = new System.Drawing.Point(12, 15);
            this.lblSelectCriticalInjury.Name = "lblSelectCriticalInjury";
            this.lblSelectCriticalInjury.Size = new System.Drawing.Size(102, 13);
            this.lblSelectCriticalInjury.TabIndex = 2;
            this.lblSelectCriticalInjury.Text = "Select Critical Injury:";
            // 
            // cboCriticalInjury
            // 
            this.cboCriticalInjury.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriticalInjury.FormattingEnabled = true;
            this.cboCriticalInjury.Location = new System.Drawing.Point(120, 12);
            this.cboCriticalInjury.Name = "cboCriticalInjury";
            this.cboCriticalInjury.Size = new System.Drawing.Size(200, 21);
            this.cboCriticalInjury.TabIndex = 3;
            this.cboCriticalInjury.SelectedIndexChanged += new System.EventHandler(this.CcoCriticalInjury_SelectionChanged);
            // 
            // IMPFrmSelectCritical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 88);
            this.Controls.Add(this.cboCriticalInjury);
            this.Controls.Add(this.lblSelectCriticalInjury);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IMPFrmSelectCritical";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Critical Injury";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label lblSelectCriticalInjury;
        private System.Windows.Forms.ComboBox cboCriticalInjury;
    }
}