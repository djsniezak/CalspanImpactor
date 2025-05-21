namespace Controls
{
    partial class CtlInjuryTimeData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpInjuryData = new System.Windows.Forms.GroupBox();
            this.btnCriticalDelete = new System.Windows.Forms.Button();
            this.btnCriticalAdd = new System.Windows.Forms.Button();
            this.dgvCriticalInjury = new System.Windows.Forms.DataGridView();
            this.btnExDelete = new System.Windows.Forms.Button();
            this.btnExAdd = new System.Windows.Forms.Button();
            this.dgvTestParms = new System.Windows.Forms.DataGridView();
            this.TestParameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestParameterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvInjuryData = new System.Windows.Forms.DataGridView();
            this.InjuryType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Units = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImpactorInjuryTimeDataId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImpactorInjuryTimeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpInjuryData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriticalInjury)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestParms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInjuryData)).BeginInit();
            this.SuspendLayout();
            // 
            // grpInjuryData
            // 
            this.grpInjuryData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInjuryData.Controls.Add(this.btnCriticalDelete);
            this.grpInjuryData.Controls.Add(this.btnCriticalAdd);
            this.grpInjuryData.Controls.Add(this.dgvCriticalInjury);
            this.grpInjuryData.Controls.Add(this.btnExDelete);
            this.grpInjuryData.Controls.Add(this.btnExAdd);
            this.grpInjuryData.Controls.Add(this.dgvTestParms);
            this.grpInjuryData.Controls.Add(this.btnDelete);
            this.grpInjuryData.Controls.Add(this.btnAdd);
            this.grpInjuryData.Controls.Add(this.dgvInjuryData);
            this.grpInjuryData.Location = new System.Drawing.Point(3, 3);
            this.grpInjuryData.Name = "grpInjuryData";
            this.grpInjuryData.Size = new System.Drawing.Size(575, 555);
            this.grpInjuryData.TabIndex = 0;
            this.grpInjuryData.TabStop = false;
            // 
            // btnCriticalDelete
            // 
            this.btnCriticalDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCriticalDelete.Location = new System.Drawing.Point(413, 285);
            this.btnCriticalDelete.Name = "btnCriticalDelete";
            this.btnCriticalDelete.Size = new System.Drawing.Size(75, 23);
            this.btnCriticalDelete.TabIndex = 8;
            this.btnCriticalDelete.Text = "Delete Record";
            this.btnCriticalDelete.UseVisualStyleBackColor = true;
            this.btnCriticalDelete.Click += new System.EventHandler(this.BtnCriticalDelete_Click);
            // 
            // btnCriticalAdd
            // 
            this.btnCriticalAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCriticalAdd.Location = new System.Drawing.Point(494, 285);
            this.btnCriticalAdd.Name = "btnCriticalAdd";
            this.btnCriticalAdd.Size = new System.Drawing.Size(75, 23);
            this.btnCriticalAdd.TabIndex = 7;
            this.btnCriticalAdd.Text = "Add Record";
            this.btnCriticalAdd.UseVisualStyleBackColor = true;
            this.btnCriticalAdd.Click += new System.EventHandler(this.BtnCriticalAdd_Click);
            // 
            // dgvCriticalInjury
            // 
            this.dgvCriticalInjury.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvCriticalInjury.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCriticalInjury.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6});
            this.dgvCriticalInjury.Location = new System.Drawing.Point(6, 166);
            this.dgvCriticalInjury.Name = "dgvCriticalInjury";
            this.dgvCriticalInjury.Size = new System.Drawing.Size(563, 113);
            this.dgvCriticalInjury.TabIndex = 6;
            // 
            // btnExDelete
            // 
            this.btnExDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExDelete.Location = new System.Drawing.Point(413, 137);
            this.btnExDelete.Name = "btnExDelete";
            this.btnExDelete.Size = new System.Drawing.Size(75, 23);
            this.btnExDelete.TabIndex = 5;
            this.btnExDelete.Text = "Delete Record";
            this.btnExDelete.UseVisualStyleBackColor = true;
            this.btnExDelete.Click += new System.EventHandler(this.BtnExDelete_Click);
            // 
            // btnExAdd
            // 
            this.btnExAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExAdd.Location = new System.Drawing.Point(494, 137);
            this.btnExAdd.Name = "btnExAdd";
            this.btnExAdd.Size = new System.Drawing.Size(75, 23);
            this.btnExAdd.TabIndex = 4;
            this.btnExAdd.Text = "Add Record";
            this.btnExAdd.UseVisualStyleBackColor = true;
            this.btnExAdd.Click += new System.EventHandler(this.BtnExAdd_Click);
            // 
            // dgvTestParms
            // 
            this.dgvTestParms.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvTestParms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestParms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TestParameter,
            this.Value,
            this.Time1,
            this.Time2,
            this.Duration,
            this.TestParameterId});
            this.dgvTestParms.Location = new System.Drawing.Point(6, 18);
            this.dgvTestParms.Name = "dgvTestParms";
            this.dgvTestParms.Size = new System.Drawing.Size(563, 113);
            this.dgvTestParms.TabIndex = 3;
            // 
            // TestParameter
            // 
            this.TestParameter.DataPropertyName = "ParameterName";
            this.TestParameter.HeaderText = "Test Parameter";
            this.TestParameter.Name = "TestParameter";
            this.TestParameter.Width = 200;
            // 
            // Value
            // 
            this.Value.DataPropertyName = "Value";
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.Width = 75;
            // 
            // Time1
            // 
            this.Time1.DataPropertyName = "TimeOne";
            this.Time1.HeaderText = "Time 1 msec";
            this.Time1.Name = "Time1";
            this.Time1.Width = 75;
            // 
            // Time2
            // 
            this.Time2.DataPropertyName = "TimeTwo";
            this.Time2.HeaderText = "Time 2 msec";
            this.Time2.Name = "Time2";
            this.Time2.Width = 75;
            // 
            // Duration
            // 
            this.Duration.DataPropertyName = "Duration";
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            this.Duration.Width = 75;
            // 
            // TestParameterId
            // 
            this.TestParameterId.DataPropertyName = "ImpactorTestParameterId";
            this.TestParameterId.HeaderText = "ID";
            this.TestParameterId.Name = "TestParameterId";
            this.TestParameterId.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(413, 526);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete Record";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(494, 526);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add Record";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // dgvInjuryData
            // 
            this.dgvInjuryData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInjuryData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInjuryData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InjuryType,
            this.Units,
            this.MaxValue,
            this.MaxTime,
            this.MinValue,
            this.MinTime,
            this.ImpactorInjuryTimeDataId,
            this.ImpactorInjuryTimeId});
            this.dgvInjuryData.Location = new System.Drawing.Point(6, 314);
            this.dgvInjuryData.Name = "dgvInjuryData";
            this.dgvInjuryData.Size = new System.Drawing.Size(563, 206);
            this.dgvInjuryData.TabIndex = 0;
            this.dgvInjuryData.SelectionChanged += new System.EventHandler(this.DgvInjusryDate_SelectionChanged);
            // 
            // InjuryType
            // 
            this.InjuryType.DataPropertyName = "ShortName";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InjuryType.DefaultCellStyle = dataGridViewCellStyle1;
            this.InjuryType.HeaderText = "Injury Type";
            this.InjuryType.Name = "InjuryType";
            this.InjuryType.Width = 150;
            // 
            // Units
            // 
            this.Units.DataPropertyName = "Units";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Units.DefaultCellStyle = dataGridViewCellStyle2;
            this.Units.HeaderText = "Units";
            this.Units.Name = "Units";
            this.Units.Width = 50;
            // 
            // MaxValue
            // 
            this.MaxValue.DataPropertyName = "MaxValue";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.MaxValue.DefaultCellStyle = dataGridViewCellStyle3;
            this.MaxValue.HeaderText = "Max Value";
            this.MaxValue.Name = "MaxValue";
            this.MaxValue.Width = 75;
            // 
            // MaxTime
            // 
            this.MaxTime.DataPropertyName = "MaxTime";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.MaxTime.DefaultCellStyle = dataGridViewCellStyle4;
            this.MaxTime.HeaderText = "Max Time";
            this.MaxTime.Name = "MaxTime";
            this.MaxTime.Width = 75;
            // 
            // MinValue
            // 
            this.MinValue.DataPropertyName = "MinValue";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.MinValue.DefaultCellStyle = dataGridViewCellStyle5;
            this.MinValue.HeaderText = "Min Value";
            this.MinValue.Name = "MinValue";
            this.MinValue.Width = 75;
            // 
            // MinTime
            // 
            this.MinTime.DataPropertyName = "MinTime";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.MinTime.DefaultCellStyle = dataGridViewCellStyle6;
            this.MinTime.HeaderText = "Min Time";
            this.MinTime.Name = "MinTime";
            this.MinTime.Width = 75;
            // 
            // ImpactorInjuryTimeDataId
            // 
            this.ImpactorInjuryTimeDataId.DataPropertyName = "ImpactorInjuryTimeDataId";
            this.ImpactorInjuryTimeDataId.HeaderText = "DataId";
            this.ImpactorInjuryTimeDataId.Name = "ImpactorInjuryTimeDataId";
            this.ImpactorInjuryTimeDataId.Visible = false;
            this.ImpactorInjuryTimeDataId.Width = 10;
            // 
            // ImpactorInjuryTimeId
            // 
            this.ImpactorInjuryTimeId.DataPropertyName = "ImpactorInjuryTimeId";
            this.ImpactorInjuryTimeId.HeaderText = "TimeId";
            this.ImpactorInjuryTimeId.Name = "ImpactorInjuryTimeId";
            this.ImpactorInjuryTimeId.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TestParameterName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Critical Injury Parameter";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Channel";
            this.dataGridViewTextBoxColumn2.HeaderText = "Channel";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn3.HeaderText = "Value";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 75;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Time";
            this.dataGridViewTextBoxColumn4.HeaderText = "Time";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 75;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ImpactorCriticalInjuryDataId";
            this.dataGridViewTextBoxColumn6.HeaderText = "ID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // CtlInjuryTimeData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpInjuryData);
            this.Name = "CtlInjuryTimeData";
            this.Size = new System.Drawing.Size(581, 569);
            this.grpInjuryData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriticalInjury)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestParms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInjuryData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInjuryData;
        private System.Windows.Forms.DataGridView dgvInjuryData;
        private System.Windows.Forms.DataGridViewTextBoxColumn InjuryType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Units;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImpactorInjuryTimeDataId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImpactorInjuryTimeId;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExDelete;
        private System.Windows.Forms.Button btnExAdd;
        private System.Windows.Forms.DataGridView dgvTestParms;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestParameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestParameterId;
        private System.Windows.Forms.Button btnCriticalDelete;
        private System.Windows.Forms.Button btnCriticalAdd;
        private System.Windows.Forms.DataGridView dgvCriticalInjury;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}
