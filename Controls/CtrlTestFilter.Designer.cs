namespace Controls
{
    partial class CtrlTestFilter
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
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.txtImpactorTestId = new System.Windows.Forms.TextBox();
            this.lblmpactTestId = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dteFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.btnAllTest = new System.Windows.Forms.Button();
            this.lstTests = new System.Windows.Forms.ListBox();
            this.grpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFilter
            // 
            this.grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFilter.Controls.Add(this.btnClearFilters);
            this.grpFilter.Controls.Add(this.txtImpactorTestId);
            this.grpFilter.Controls.Add(this.lblmpactTestId);
            this.grpFilter.Controls.Add(this.dateTimePicker1);
            this.grpFilter.Controls.Add(this.lblTo);
            this.grpFilter.Controls.Add(this.dteFrom);
            this.grpFilter.Controls.Add(this.lblFrom);
            this.grpFilter.Controls.Add(this.btnAllTest);
            this.grpFilter.Cursor = System.Windows.Forms.Cursors.Default;
            this.grpFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFilter.Location = new System.Drawing.Point(3, 0);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(196, 177);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter";
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFilters.Location = new System.Drawing.Point(98, 138);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(92, 24);
            this.btnClearFilters.TabIndex = 7;
            this.btnClearFilters.Text = "Clear Filters";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            // 
            // txtImpactorTestId
            // 
            this.txtImpactorTestId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImpactorTestId.Location = new System.Drawing.Point(95, 112);
            this.txtImpactorTestId.Name = "txtImpactorTestId";
            this.txtImpactorTestId.Size = new System.Drawing.Size(95, 20);
            this.txtImpactorTestId.TabIndex = 6;
            // 
            // lblmpactTestId
            // 
            this.lblmpactTestId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblmpactTestId.AutoSize = true;
            this.lblmpactTestId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmpactTestId.Location = new System.Drawing.Point(9, 115);
            this.lblmpactTestId.Name = "lblmpactTestId";
            this.lblmpactTestId.Size = new System.Drawing.Size(80, 13);
            this.lblmpactTestId.TabIndex = 5;
            this.lblmpactTestId.Text = "Impact Test ID:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(48, 82);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowCheckBox = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(117, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(14, 86);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "To:";
            // 
            // dteFrom
            // 
            this.dteFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dteFrom.Checked = false;
            this.dteFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteFrom.Location = new System.Drawing.Point(48, 56);
            this.dteFrom.Name = "dteFrom";
            this.dteFrom.ShowCheckBox = true;
            this.dteFrom.Size = new System.Drawing.Size(117, 20);
            this.dteFrom.TabIndex = 2;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(9, 59);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "From:";
            // 
            // btnAllTest
            // 
            this.btnAllTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllTest.Location = new System.Drawing.Point(10, 22);
            this.btnAllTest.Name = "btnAllTest";
            this.btnAllTest.Size = new System.Drawing.Size(84, 24);
            this.btnAllTest.TabIndex = 0;
            this.btnAllTest.Text = "All Tests";
            this.btnAllTest.UseVisualStyleBackColor = true;
            // 
            // lstTests
            // 
            this.lstTests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTests.FormattingEnabled = true;
            this.lstTests.Location = new System.Drawing.Point(3, 186);
            this.lstTests.Name = "lstTests";
            this.lstTests.Size = new System.Drawing.Size(196, 550);
            this.lstTests.TabIndex = 1;
            // 
            // CtrlTestFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstTests);
            this.Controls.Add(this.grpFilter);
            this.Name = "CtrlTestFilter";
            this.Size = new System.Drawing.Size(202, 739);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.ListBox lstTests;
        private System.Windows.Forms.DateTimePicker dteFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Button btnAllTest;
        private System.Windows.Forms.TextBox txtImpactorTestId;
        private System.Windows.Forms.Label lblmpactTestId;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Button btnClearFilters;
    }
}
