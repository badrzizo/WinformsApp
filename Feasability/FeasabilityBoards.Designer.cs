namespace WinFormsApp.Feasability
{
    partial class FeasabilityBoards
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.boardDBDataSet = new WinFormsApp.BoardDBDataSet();
            this.feasibilityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.feasibilityTableAdapter = new WinFormsApp.BoardDBDataSetTableAdapters.FeasibilityTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carlineDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.famDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mYCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeofchangeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.whatisthechangeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.integrationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boardavailabilityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.holdersboardDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.holderseolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programmeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialboardintegrationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workplaceintegrationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feasibilityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.phaseDataGridViewTextBoxColumn,
            this.carlineDataGridViewTextBoxColumn,
            this.famDataGridViewTextBoxColumn,
            this.mYCDataGridViewTextBoxColumn,
            this.typeofchangeDataGridViewTextBoxColumn,
            this.whatisthechangeDataGridViewTextBoxColumn,
            this.integrationDataGridViewTextBoxColumn,
            this.boardavailabilityDataGridViewTextBoxColumn,
            this.holdersboardDataGridViewTextBoxColumn,
            this.holderseolDataGridViewTextBoxColumn,
            this.programmeDataGridViewTextBoxColumn,
            this.serialboardintegrationDataGridViewTextBoxColumn,
            this.workplaceintegrationDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.feasibilityBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(200, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(600, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // boardDBDataSet
            // 
            this.boardDBDataSet.DataSetName = "BoardDBDataSet";
            this.boardDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // feasibilityBindingSource
            // 
            this.feasibilityBindingSource.DataMember = "Feasibility";
            this.feasibilityBindingSource.DataSource = this.boardDBDataSet;
            // 
            // feasibilityTableAdapter
            // 
            this.feasibilityTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "date";
            this.dateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.Width = 125;
            // 
            // phaseDataGridViewTextBoxColumn
            // 
            this.phaseDataGridViewTextBoxColumn.DataPropertyName = "phase";
            this.phaseDataGridViewTextBoxColumn.HeaderText = "phase";
            this.phaseDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.phaseDataGridViewTextBoxColumn.Name = "phaseDataGridViewTextBoxColumn";
            this.phaseDataGridViewTextBoxColumn.Width = 125;
            // 
            // carlineDataGridViewTextBoxColumn
            // 
            this.carlineDataGridViewTextBoxColumn.DataPropertyName = "carline";
            this.carlineDataGridViewTextBoxColumn.HeaderText = "carline";
            this.carlineDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.carlineDataGridViewTextBoxColumn.Name = "carlineDataGridViewTextBoxColumn";
            this.carlineDataGridViewTextBoxColumn.Width = 125;
            // 
            // famDataGridViewTextBoxColumn
            // 
            this.famDataGridViewTextBoxColumn.DataPropertyName = "fam";
            this.famDataGridViewTextBoxColumn.HeaderText = "fam";
            this.famDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.famDataGridViewTextBoxColumn.Name = "famDataGridViewTextBoxColumn";
            this.famDataGridViewTextBoxColumn.Width = 125;
            // 
            // mYCDataGridViewTextBoxColumn
            // 
            this.mYCDataGridViewTextBoxColumn.DataPropertyName = "MYC";
            this.mYCDataGridViewTextBoxColumn.HeaderText = "MYC";
            this.mYCDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mYCDataGridViewTextBoxColumn.Name = "mYCDataGridViewTextBoxColumn";
            this.mYCDataGridViewTextBoxColumn.Width = 125;
            // 
            // typeofchangeDataGridViewTextBoxColumn
            // 
            this.typeofchangeDataGridViewTextBoxColumn.DataPropertyName = "type_of_change";
            this.typeofchangeDataGridViewTextBoxColumn.HeaderText = "type_of_change";
            this.typeofchangeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.typeofchangeDataGridViewTextBoxColumn.Name = "typeofchangeDataGridViewTextBoxColumn";
            this.typeofchangeDataGridViewTextBoxColumn.Width = 125;
            // 
            // whatisthechangeDataGridViewTextBoxColumn
            // 
            this.whatisthechangeDataGridViewTextBoxColumn.DataPropertyName = "what_is_the_change";
            this.whatisthechangeDataGridViewTextBoxColumn.HeaderText = "what_is_the_change";
            this.whatisthechangeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.whatisthechangeDataGridViewTextBoxColumn.Name = "whatisthechangeDataGridViewTextBoxColumn";
            this.whatisthechangeDataGridViewTextBoxColumn.Width = 125;
            // 
            // integrationDataGridViewTextBoxColumn
            // 
            this.integrationDataGridViewTextBoxColumn.DataPropertyName = "integration";
            this.integrationDataGridViewTextBoxColumn.HeaderText = "integration";
            this.integrationDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.integrationDataGridViewTextBoxColumn.Name = "integrationDataGridViewTextBoxColumn";
            this.integrationDataGridViewTextBoxColumn.Width = 125;
            // 
            // boardavailabilityDataGridViewTextBoxColumn
            // 
            this.boardavailabilityDataGridViewTextBoxColumn.DataPropertyName = "board_availability";
            this.boardavailabilityDataGridViewTextBoxColumn.HeaderText = "board_availability";
            this.boardavailabilityDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.boardavailabilityDataGridViewTextBoxColumn.Name = "boardavailabilityDataGridViewTextBoxColumn";
            this.boardavailabilityDataGridViewTextBoxColumn.Width = 125;
            // 
            // holdersboardDataGridViewTextBoxColumn
            // 
            this.holdersboardDataGridViewTextBoxColumn.DataPropertyName = "holders_board";
            this.holdersboardDataGridViewTextBoxColumn.HeaderText = "holders_board";
            this.holdersboardDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.holdersboardDataGridViewTextBoxColumn.Name = "holdersboardDataGridViewTextBoxColumn";
            this.holdersboardDataGridViewTextBoxColumn.Width = 125;
            // 
            // holderseolDataGridViewTextBoxColumn
            // 
            this.holderseolDataGridViewTextBoxColumn.DataPropertyName = "holders_eol";
            this.holderseolDataGridViewTextBoxColumn.HeaderText = "holders_eol";
            this.holderseolDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.holderseolDataGridViewTextBoxColumn.Name = "holderseolDataGridViewTextBoxColumn";
            this.holderseolDataGridViewTextBoxColumn.Width = 125;
            // 
            // programmeDataGridViewTextBoxColumn
            // 
            this.programmeDataGridViewTextBoxColumn.DataPropertyName = "programme";
            this.programmeDataGridViewTextBoxColumn.HeaderText = "programme";
            this.programmeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.programmeDataGridViewTextBoxColumn.Name = "programmeDataGridViewTextBoxColumn";
            this.programmeDataGridViewTextBoxColumn.Width = 125;
            // 
            // serialboardintegrationDataGridViewTextBoxColumn
            // 
            this.serialboardintegrationDataGridViewTextBoxColumn.DataPropertyName = "serial_board_integration";
            this.serialboardintegrationDataGridViewTextBoxColumn.HeaderText = "serial_board_integration";
            this.serialboardintegrationDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.serialboardintegrationDataGridViewTextBoxColumn.Name = "serialboardintegrationDataGridViewTextBoxColumn";
            this.serialboardintegrationDataGridViewTextBoxColumn.Width = 125;
            // 
            // workplaceintegrationDataGridViewTextBoxColumn
            // 
            this.workplaceintegrationDataGridViewTextBoxColumn.DataPropertyName = "workplace_integration";
            this.workplaceintegrationDataGridViewTextBoxColumn.HeaderText = "workplace_integration";
            this.workplaceintegrationDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.workplaceintegrationDataGridViewTextBoxColumn.Name = "workplaceintegrationDataGridViewTextBoxColumn";
            this.workplaceintegrationDataGridViewTextBoxColumn.Width = 125;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 450);
            this.panel1.TabIndex = 1;
            // 
            // FeasabilityBoards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FeasabilityBoards";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FeasabilityBoards";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FeasabilityBoards_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feasibilityBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private BoardDBDataSet boardDBDataSet;
        private System.Windows.Forms.BindingSource feasibilityBindingSource;
        private BoardDBDataSetTableAdapters.FeasibilityTableAdapter feasibilityTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phaseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn carlineDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn famDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mYCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeofchangeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn whatisthechangeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn integrationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn boardavailabilityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn holdersboardDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn holderseolDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn programmeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialboardintegrationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workplaceintegrationDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
    }
}