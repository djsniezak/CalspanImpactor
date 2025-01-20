namespace Impactor
{
    partial class FrmReports
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
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmboCustomer = new System.Windows.Forms.ComboBox();
            this.lblTestDates = new System.Windows.Forms.Label();
            this.dteBegin = new System.Windows.Forms.DateTimePicker();
            this.lblDatesTo = new System.Windows.Forms.Label();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpRunReports = new System.Windows.Forms.GroupBox();
            this.btnFinal = new System.Windows.Forms.Button();
            this.btnSummary = new System.Windows.Forms.Button();
            this.btnData = new System.Windows.Forms.Button();
            this.lblCustomerPrefix = new System.Windows.Forms.Label();
            this.lblPrefix = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblCustomerCode = new System.Windows.Forms.Label();
            this.btnLoadTests = new System.Windows.Forms.Button();
            this.dgvTest = new System.Windows.Forms.DataGridView();
            this.TestRun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Make = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpRunReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(20, 9);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(54, 13);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Customer:";
            // 
            // cmboCustomer
            // 
            this.cmboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboCustomer.FormattingEnabled = true;
            this.cmboCustomer.Location = new System.Drawing.Point(80, 6);
            this.cmboCustomer.Name = "cmboCustomer";
            this.cmboCustomer.Size = new System.Drawing.Size(229, 21);
            this.cmboCustomer.TabIndex = 1;
            this.cmboCustomer.SelectedIndexChanged += new System.EventHandler(this.CmboCustomer_SelectedIndexChanged);
            // 
            // lblTestDates
            // 
            this.lblTestDates.AutoSize = true;
            this.lblTestDates.Location = new System.Drawing.Point(12, 66);
            this.lblTestDates.Name = "lblTestDates";
            this.lblTestDates.Size = new System.Drawing.Size(62, 13);
            this.lblTestDates.TabIndex = 2;
            this.lblTestDates.Text = "Test Dates:";
            // 
            // dteBegin
            // 
            this.dteBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteBegin.Location = new System.Drawing.Point(80, 61);
            this.dteBegin.Name = "dteBegin";
            this.dteBegin.Size = new System.Drawing.Size(97, 20);
            this.dteBegin.TabIndex = 3;
            // 
            // lblDatesTo
            // 
            this.lblDatesTo.AutoSize = true;
            this.lblDatesTo.Location = new System.Drawing.Point(183, 66);
            this.lblDatesTo.Name = "lblDatesTo";
            this.lblDatesTo.Size = new System.Drawing.Size(23, 13);
            this.lblDatesTo.TabIndex = 4;
            this.lblDatesTo.Text = "To:";
            // 
            // dteEnd
            // 
            this.dteEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteEnd.Location = new System.Drawing.Point(212, 61);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(97, 20);
            this.dteEnd.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(1064, 263);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // grpRunReports
            // 
            this.grpRunReports.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpRunReports.Controls.Add(this.btnFinal);
            this.grpRunReports.Controls.Add(this.btnSummary);
            this.grpRunReports.Controls.Add(this.btnData);
            this.grpRunReports.Location = new System.Drawing.Point(52, 186);
            this.grpRunReports.Name = "grpRunReports";
            this.grpRunReports.Size = new System.Drawing.Size(257, 71);
            this.grpRunReports.TabIndex = 10;
            this.grpRunReports.TabStop = false;
            this.grpRunReports.Text = "Reports";
            // 
            // btnFinal
            // 
            this.btnFinal.Enabled = false;
            this.btnFinal.Location = new System.Drawing.Point(171, 19);
            this.btnFinal.Name = "btnFinal";
            this.btnFinal.Size = new System.Drawing.Size(75, 38);
            this.btnFinal.TabIndex = 2;
            this.btnFinal.Text = "Run Final Report";
            this.btnFinal.UseVisualStyleBackColor = true;
            this.btnFinal.Click += new System.EventHandler(this.BtnRunFinal_Clicked);
            // 
            // btnSummary
            // 
            this.btnSummary.Enabled = false;
            this.btnSummary.Location = new System.Drawing.Point(90, 19);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(75, 38);
            this.btnSummary.TabIndex = 1;
            this.btnSummary.Text = "Run Summary";
            this.btnSummary.UseVisualStyleBackColor = true;
            this.btnSummary.Click += new System.EventHandler(this.BtnRunSummary_Clicked);
            // 
            // btnData
            // 
            this.btnData.Enabled = false;
            this.btnData.Location = new System.Drawing.Point(6, 19);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(75, 38);
            this.btnData.TabIndex = 0;
            this.btnData.Text = "Run Data";
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.BtnRunData_Clicked);
            // 
            // lblCustomerPrefix
            // 
            this.lblCustomerPrefix.AutoSize = true;
            this.lblCustomerPrefix.Location = new System.Drawing.Point(20, 38);
            this.lblCustomerPrefix.Name = "lblCustomerPrefix";
            this.lblCustomerPrefix.Size = new System.Drawing.Size(83, 13);
            this.lblCustomerPrefix.TabIndex = 11;
            this.lblCustomerPrefix.Text = "Customer Prefix:";
            // 
            // lblPrefix
            // 
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.Location = new System.Drawing.Point(109, 38);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(0, 13);
            this.lblPrefix.TabIndex = 12;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(272, 38);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(0, 13);
            this.lblCode.TabIndex = 14;
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.AutoSize = true;
            this.lblCustomerCode.Location = new System.Drawing.Point(183, 38);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(82, 13);
            this.lblCustomerCode.TabIndex = 13;
            this.lblCustomerCode.Text = "Customer Code:";
            // 
            // btnLoadTests
            // 
            this.btnLoadTests.Location = new System.Drawing.Point(80, 102);
            this.btnLoadTests.Name = "btnLoadTests";
            this.btnLoadTests.Size = new System.Drawing.Size(229, 23);
            this.btnLoadTests.TabIndex = 15;
            this.btnLoadTests.Text = "Load Customer Tests";
            this.btnLoadTests.UseVisualStyleBackColor = true;
            this.btnLoadTests.Click += new System.EventHandler(this.BtnLoadTests_Clicked);
            // 
            // dgvTest
            // 
            this.dgvTest.AllowUserToAddRows = false;
            this.dgvTest.AllowUserToDeleteRows = false;
            this.dgvTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TestRun,
            this.TestName,
            this.Year,
            this.Make,
            this.Model,
            this.VIN,
            this.TestId});
            this.dgvTest.Location = new System.Drawing.Point(315, 6);
            this.dgvTest.Name = "dgvTest";
            this.dgvTest.ReadOnly = true;
            this.dgvTest.Size = new System.Drawing.Size(824, 251);
            this.dgvTest.TabIndex = 16;
            // 
            // TestRun
            // 
            this.TestRun.HeaderText = "Test Run";
            this.TestRun.Name = "TestRun";
            this.TestRun.ReadOnly = true;
            // 
            // TestName
            // 
            this.TestName.HeaderText = "Test Name";
            this.TestName.Name = "TestName";
            this.TestName.ReadOnly = true;
            this.TestName.Width = 200;
            // 
            // Year
            // 
            this.Year.HeaderText = "Year";
            this.Year.Name = "Year";
            this.Year.ReadOnly = true;
            // 
            // Make
            // 
            this.Make.HeaderText = "Make";
            this.Make.Name = "Make";
            this.Make.ReadOnly = true;
            // 
            // Model
            // 
            this.Model.HeaderText = "Model";
            this.Model.Name = "Model";
            this.Model.ReadOnly = true;
            // 
            // VIN
            // 
            this.VIN.HeaderText = "VIN";
            this.VIN.Name = "VIN";
            this.VIN.ReadOnly = true;
            this.VIN.Width = 150;
            // 
            // TestId
            // 
            this.TestId.HeaderText = "TestId";
            this.TestId.Name = "TestId";
            this.TestId.ReadOnly = true;
            this.TestId.Visible = false;
            // 
            // FrmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 298);
            this.ControlBox = false;
            this.Controls.Add(this.dgvTest);
            this.Controls.Add(this.btnLoadTests);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblCustomerCode);
            this.Controls.Add(this.lblPrefix);
            this.Controls.Add(this.lblCustomerPrefix);
            this.Controls.Add(this.grpRunReports);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.lblDatesTo);
            this.Controls.Add(this.dteBegin);
            this.Controls.Add(this.lblTestDates);
            this.Controls.Add(this.cmboCustomer);
            this.Controls.Add(this.lblCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.grpRunReports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmboCustomer;
        private System.Windows.Forms.Label lblTestDates;
        private System.Windows.Forms.DateTimePicker dteBegin;
        private System.Windows.Forms.Label lblDatesTo;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpRunReports;
        private System.Windows.Forms.Button btnFinal;
        private System.Windows.Forms.Button btnSummary;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.Label lblCustomerPrefix;
        private System.Windows.Forms.Label lblPrefix;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblCustomerCode;
        private System.Windows.Forms.Button btnLoadTests;
        private System.Windows.Forms.DataGridView dgvTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestRun;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Make;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn VIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestId;
    }
}