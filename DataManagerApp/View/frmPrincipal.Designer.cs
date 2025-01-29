namespace DataManagerApp.View
{
	partial class frmPrincipal
	{
		private System.ComponentModel.IContainer components = null;
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            comboBoxEntity = new ComboBox();
            dataGridViewEntity = new DataGridView();
            buttonAdd = new Button();
            buttonDelete = new Button();
            textFilter = new TextBox();
            ButtonLog = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEntity).BeginInit();
            SuspendLayout();
            // 
            // comboBoxEntity
            // 
            comboBoxEntity.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxEntity.FormattingEnabled = true;
            resources.ApplyResources(comboBoxEntity, "comboBoxEntity");
            comboBoxEntity.Name = "comboBoxEntity";
            comboBoxEntity.Sorted = true;
            comboBoxEntity.SelectedIndexChanged += comboBoxEntity_SelectedIndexChanged;
            // 
            // dataGridViewEntity
            // 
            dataGridViewEntity.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(dataGridViewEntity, "dataGridViewEntity");
            dataGridViewEntity.Name = "dataGridViewEntity";
            // 
            // buttonAdd
            // 
            resources.ApplyResources(buttonAdd, "buttonAdd");
            buttonAdd.Name = "buttonAdd";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonDelete
            // 
            resources.ApplyResources(buttonDelete, "buttonDelete");
            buttonDelete.Name = "buttonDelete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // textFilter
            // 
            resources.ApplyResources(textFilter, "textFilter");
            textFilter.Name = "textFilter";
            textFilter.TextChanged += textFilter_TextChanged;
            textFilter.Enter += textFilter_Enter;
            textFilter.Leave += textFilter_Leave;
            // 
            // ButtonLog
            // 
            resources.ApplyResources(ButtonLog, "ButtonLog");
            ButtonLog.Name = "ButtonLog";
            ButtonLog.UseVisualStyleBackColor = true;
            ButtonLog.Click += buttonShowLogs_Click;
            // 
            // frmPrincipal
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(ButtonLog);
            Controls.Add(textFilter);
            Controls.Add(buttonDelete);
            Controls.Add(buttonAdd);
            Controls.Add(dataGridViewEntity);
            Controls.Add(comboBoxEntity);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmPrincipal";
            Load += frmPrincipal_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewEntity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox comboBoxEntity;
        private DataGridView dataGridViewEntity;
        private Button buttonAdd;
        private Button buttonDelete;
        private TextBox textFilter;
        private Button ButtonLog;
    }
}

