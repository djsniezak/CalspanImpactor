namespace Controls
{
    partial class CtlTestSetUp
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
            this.grpTestSetup = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.cboTestType = new System.Windows.Forms.ComboBox();
            this.lblTestType = new System.Windows.Forms.Label();
            this.txtOperator = new System.Windows.Forms.TextBox();
            this.lblOperator = new System.Windows.Forms.Label();
            this.txtEngineer = new System.Windows.Forms.TextBox();
            this.lblEngineer = new System.Windows.Forms.Label();
            this.txtClientCode = new System.Windows.Forms.TextBox();
            this.lblClientCode = new System.Windows.Forms.Label();
            this.txtClientPrefix = new System.Windows.Forms.TextBox();
            this.lblClientPrefix = new System.Windows.Forms.Label();
            this.cmbClientName = new System.Windows.Forms.ComboBox();
            this.lblClientName = new System.Windows.Forms.Label();
            this.dteTestDateTime = new System.Windows.Forms.DateTimePicker();
            this.lblTestDate = new System.Windows.Forms.Label();
            this.txtImpactorID = new System.Windows.Forms.TextBox();
            this.lblImpactorTest = new System.Windows.Forms.Label();
            this.grpTestSetup.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTestSetup
            // 
            this.grpTestSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTestSetup.Controls.Add(this.txtNotes);
            this.grpTestSetup.Controls.Add(this.lblNotes);
            this.grpTestSetup.Controls.Add(this.cboTestType);
            this.grpTestSetup.Controls.Add(this.lblTestType);
            this.grpTestSetup.Controls.Add(this.txtOperator);
            this.grpTestSetup.Controls.Add(this.lblOperator);
            this.grpTestSetup.Controls.Add(this.txtEngineer);
            this.grpTestSetup.Controls.Add(this.lblEngineer);
            this.grpTestSetup.Controls.Add(this.txtClientCode);
            this.grpTestSetup.Controls.Add(this.lblClientCode);
            this.grpTestSetup.Controls.Add(this.txtClientPrefix);
            this.grpTestSetup.Controls.Add(this.lblClientPrefix);
            this.grpTestSetup.Controls.Add(this.cmbClientName);
            this.grpTestSetup.Controls.Add(this.lblClientName);
            this.grpTestSetup.Controls.Add(this.dteTestDateTime);
            this.grpTestSetup.Controls.Add(this.lblTestDate);
            this.grpTestSetup.Controls.Add(this.txtImpactorID);
            this.grpTestSetup.Controls.Add(this.lblImpactorTest);
            this.grpTestSetup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTestSetup.Location = new System.Drawing.Point(3, 3);
            this.grpTestSetup.Name = "grpTestSetup";
            this.grpTestSetup.Size = new System.Drawing.Size(468, 195);
            this.grpTestSetup.TabIndex = 0;
            this.grpTestSetup.TabStop = false;
            this.grpTestSetup.Text = "Test Setup";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(111, 145);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(351, 44);
            this.txtNotes.TabIndex = 10;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(63, 157);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(42, 15);
            this.lblNotes.TabIndex = 99;
            this.lblNotes.Text = "Notes:";
            // 
            // cboTestType
            // 
            this.cboTestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTestType.FormattingEnabled = true;
            this.cboTestType.Location = new System.Drawing.Point(111, 118);
            this.cboTestType.Name = "cboTestType";
            this.cboTestType.Size = new System.Drawing.Size(351, 21);
            this.cboTestType.TabIndex = 9;
            // 
            // lblTestType
            // 
            this.lblTestType.AutoSize = true;
            this.lblTestType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestType.Location = new System.Drawing.Point(43, 121);
            this.lblTestType.Name = "lblTestType";
            this.lblTestType.Size = new System.Drawing.Size(62, 15);
            this.lblTestType.TabIndex = 99;
            this.lblTestType.Text = "Test Type:";
            // 
            // txtOperator
            // 
            this.txtOperator.Location = new System.Drawing.Point(327, 94);
            this.txtOperator.Name = "txtOperator";
            this.txtOperator.Size = new System.Drawing.Size(135, 20);
            this.txtOperator.TabIndex = 8;
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperator.Location = new System.Drawing.Point(263, 95);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(58, 15);
            this.lblOperator.TabIndex = 99;
            this.lblOperator.Text = "Operator:";
            // 
            // txtEngineer
            // 
            this.txtEngineer.Location = new System.Drawing.Point(111, 92);
            this.txtEngineer.Name = "txtEngineer";
            this.txtEngineer.Size = new System.Drawing.Size(146, 20);
            this.txtEngineer.TabIndex = 7;
            // 
            // lblEngineer
            // 
            this.lblEngineer.AutoSize = true;
            this.lblEngineer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEngineer.Location = new System.Drawing.Point(45, 94);
            this.lblEngineer.Name = "lblEngineer";
            this.lblEngineer.Size = new System.Drawing.Size(60, 15);
            this.lblEngineer.TabIndex = 99;
            this.lblEngineer.Text = "Engineer:";
            // 
            // txtClientCode
            // 
            this.txtClientCode.Location = new System.Drawing.Point(397, 68);
            this.txtClientCode.Name = "txtClientCode";
            this.txtClientCode.Size = new System.Drawing.Size(65, 20);
            this.txtClientCode.TabIndex = 5;
            // 
            // lblClientCode
            // 
            this.lblClientCode.AutoSize = true;
            this.lblClientCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientCode.Location = new System.Drawing.Point(316, 70);
            this.lblClientCode.Name = "lblClientCode";
            this.lblClientCode.Size = new System.Drawing.Size(73, 15);
            this.lblClientCode.TabIndex = 99;
            this.lblClientCode.Text = "Client Code:";
            // 
            // txtClientPrefix
            // 
            this.txtClientPrefix.Location = new System.Drawing.Point(192, 66);
            this.txtClientPrefix.Name = "txtClientPrefix";
            this.txtClientPrefix.Size = new System.Drawing.Size(65, 20);
            this.txtClientPrefix.TabIndex = 4;
            // 
            // lblClientPrefix
            // 
            this.lblClientPrefix.AutoSize = true;
            this.lblClientPrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientPrefix.Location = new System.Drawing.Point(111, 68);
            this.lblClientPrefix.Name = "lblClientPrefix";
            this.lblClientPrefix.Size = new System.Drawing.Size(75, 15);
            this.lblClientPrefix.TabIndex = 99;
            this.lblClientPrefix.Text = "Client Prefix:";
            // 
            // cmbClientName
            // 
            this.cmbClientName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClientName.FormattingEnabled = true;
            this.cmbClientName.Location = new System.Drawing.Point(111, 39);
            this.cmbClientName.Name = "cmbClientName";
            this.cmbClientName.Size = new System.Drawing.Size(351, 21);
            this.cmbClientName.TabIndex = 3;
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientName.Location = new System.Drawing.Point(27, 42);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(78, 15);
            this.lblClientName.TabIndex = 99;
            this.lblClientName.Text = "Client Name:";
            // 
            // dteTestDateTime
            // 
            this.dteTestDateTime.CustomFormat = "MM/dd/yyyy   hh:mm tt";
            this.dteTestDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteTestDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteTestDateTime.Location = new System.Drawing.Point(291, 13);
            this.dteTestDateTime.Name = "dteTestDateTime";
            this.dteTestDateTime.Size = new System.Drawing.Size(171, 21);
            this.dteTestDateTime.TabIndex = 2;
            this.dteTestDateTime.Value = new System.DateTime(2023, 7, 2, 15, 45, 0, 0);
            // 
            // lblTestDate
            // 
            this.lblTestDate.AutoSize = true;
            this.lblTestDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestDate.Location = new System.Drawing.Point(217, 16);
            this.lblTestDate.Name = "lblTestDate";
            this.lblTestDate.Size = new System.Drawing.Size(68, 15);
            this.lblTestDate.TabIndex = 99;
            this.lblTestDate.Text = "Date-Time:";
            // 
            // txtImpactorID
            // 
            this.txtImpactorID.Location = new System.Drawing.Point(111, 13);
            this.txtImpactorID.Name = "txtImpactorID";
            this.txtImpactorID.Size = new System.Drawing.Size(100, 20);
            this.txtImpactorID.TabIndex = 1;
            // 
            // lblImpactorTest
            // 
            this.lblImpactorTest.AutoSize = true;
            this.lblImpactorTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImpactorTest.Location = new System.Drawing.Point(6, 16);
            this.lblImpactorTest.Name = "lblImpactorTest";
            this.lblImpactorTest.Size = new System.Drawing.Size(99, 15);
            this.lblImpactorTest.TabIndex = 0;
            this.lblImpactorTest.Text = "Impactor Test ID:";
            // 
            // CtlTestSetUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpTestSetup);
            this.Name = "CtlTestSetUp";
            this.Size = new System.Drawing.Size(474, 201);
            this.grpTestSetup.ResumeLayout(false);
            this.grpTestSetup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTestSetup;
        private System.Windows.Forms.Label lblImpactorTest;
        private System.Windows.Forms.DateTimePicker dteTestDateTime;
        private System.Windows.Forms.Label lblTestDate;
        private System.Windows.Forms.TextBox txtImpactorID;
        private System.Windows.Forms.ComboBox cmbClientName;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.TextBox txtClientPrefix;
        private System.Windows.Forms.Label lblClientPrefix;
        private System.Windows.Forms.TextBox txtEngineer;
        private System.Windows.Forms.Label lblEngineer;
        private System.Windows.Forms.TextBox txtClientCode;
        private System.Windows.Forms.Label lblClientCode;
        private System.Windows.Forms.TextBox txtOperator;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.ComboBox cboTestType;
        private System.Windows.Forms.Label lblTestType;
    }
}
