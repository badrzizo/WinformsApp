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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeasabilityBoards));
            this.DataGridViewFeasibility = new System.Windows.Forms.DataGridView();
            this.feasibilityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.boardDBDataSet = new WinFormsApp.BoardDBDataSet();
            this.feasibilityTableAdapter = new WinFormsApp.BoardDBDataSetTableAdapters.FeasibilityTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mYC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type_of_change = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.what_is_the_change = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.integration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.board_availability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.holders_board = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.holders_eol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serial_board_integration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workplace_integration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewFeasibility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feasibilityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardDBDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridViewFeasibility
            // 
            this.DataGridViewFeasibility.AutoGenerateColumns = false;
            this.DataGridViewFeasibility.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewFeasibility.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.date,
            this.phase,
            this.carline,
            this.fam,
            this.mYC,
            this.type_of_change,
            this.what_is_the_change,
            this.integration,
            this.board_availability,
            this.holders_board,
            this.holders_eol,
            this.programme,
            this.serial_board_integration,
            this.workplace_integration});
            this.DataGridViewFeasibility.DataSource = this.feasibilityBindingSource;
            this.DataGridViewFeasibility.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewFeasibility.Location = new System.Drawing.Point(200, 0);
            this.DataGridViewFeasibility.Name = "DataGridViewFeasibility";
            this.DataGridViewFeasibility.RowHeadersWidth = 51;
            this.DataGridViewFeasibility.RowTemplate.Height = 24;
            this.DataGridViewFeasibility.Size = new System.Drawing.Size(1045, 552);
            this.DataGridViewFeasibility.TabIndex = 0;
            // 
            // feasibilityBindingSource
            // 
            this.feasibilityBindingSource.DataMember = "Feasibility";
            this.feasibilityBindingSource.DataSource = this.boardDBDataSet;
            // 
            // boardDBDataSet
            // 
            this.boardDBDataSet.DataSetName = "BoardDBDataSet";
            this.boardDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // feasibilityTableAdapter
            // 
            this.feasibilityTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 552);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(12, 207);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 86);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Point";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 125;
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "date";
            this.date.MinimumWidth = 6;
            this.date.Name = "date";
            this.date.Width = 125;
            // 
            // phase
            // 
            this.phase.DataPropertyName = "phase";
            this.phase.HeaderText = "phase";
            this.phase.MinimumWidth = 6;
            this.phase.Name = "phase";
            this.phase.Width = 125;
            // 
            // carline
            // 
            this.carline.DataPropertyName = "carline";
            this.carline.HeaderText = "carline";
            this.carline.MinimumWidth = 6;
            this.carline.Name = "carline";
            this.carline.Width = 125;
            // 
            // fam
            // 
            this.fam.DataPropertyName = "fam";
            this.fam.HeaderText = "fam";
            this.fam.MinimumWidth = 6;
            this.fam.Name = "fam";
            this.fam.Width = 125;
            // 
            // mYC
            // 
            this.mYC.DataPropertyName = "MYC";
            this.mYC.HeaderText = "MYC";
            this.mYC.MinimumWidth = 6;
            this.mYC.Name = "mYC";
            this.mYC.Width = 125;
            // 
            // type_of_change
            // 
            this.type_of_change.DataPropertyName = "type_of_change";
            this.type_of_change.HeaderText = "type_of_change";
            this.type_of_change.MinimumWidth = 6;
            this.type_of_change.Name = "type_of_change";
            this.type_of_change.Width = 125;
            // 
            // what_is_the_change
            // 
            this.what_is_the_change.DataPropertyName = "what_is_the_change";
            this.what_is_the_change.HeaderText = "what_is_the_change";
            this.what_is_the_change.MinimumWidth = 6;
            this.what_is_the_change.Name = "what_is_the_change";
            this.what_is_the_change.Width = 125;
            // 
            // integration
            // 
            this.integration.DataPropertyName = "integration";
            this.integration.HeaderText = "integration";
            this.integration.MinimumWidth = 6;
            this.integration.Name = "integration";
            this.integration.Width = 125;
            // 
            // board_availability
            // 
            this.board_availability.DataPropertyName = "board_availability";
            this.board_availability.HeaderText = "board_availability";
            this.board_availability.MinimumWidth = 6;
            this.board_availability.Name = "board_availability";
            this.board_availability.Width = 125;
            // 
            // holders_board
            // 
            this.holders_board.DataPropertyName = "holders_board";
            this.holders_board.HeaderText = "holders_board";
            this.holders_board.MinimumWidth = 6;
            this.holders_board.Name = "holders_board";
            this.holders_board.Width = 125;
            // 
            // holders_eol
            // 
            this.holders_eol.DataPropertyName = "holders_eol";
            this.holders_eol.HeaderText = "holders_eol";
            this.holders_eol.MinimumWidth = 6;
            this.holders_eol.Name = "holders_eol";
            this.holders_eol.Width = 125;
            // 
            // programme
            // 
            this.programme.DataPropertyName = "programme";
            this.programme.HeaderText = "programme";
            this.programme.MinimumWidth = 6;
            this.programme.Name = "programme";
            this.programme.Width = 125;
            // 
            // serial_board_integration
            // 
            this.serial_board_integration.DataPropertyName = "serial_board_integration";
            this.serial_board_integration.HeaderText = "serial_board_integration";
            this.serial_board_integration.MinimumWidth = 6;
            this.serial_board_integration.Name = "serial_board_integration";
            this.serial_board_integration.Width = 125;
            // 
            // workplace_integration
            // 
            this.workplace_integration.DataPropertyName = "workplace_integration";
            this.workplace_integration.HeaderText = "workplace_integration";
            this.workplace_integration.MinimumWidth = 6;
            this.workplace_integration.Name = "workplace_integration";
            this.workplace_integration.Width = 125;
            // 
            // FeasabilityBoards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 552);
            this.Controls.Add(this.DataGridViewFeasibility);
            this.Controls.Add(this.panel1);
            this.Name = "FeasabilityBoards";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FeasabilityBoards";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FeasabilityBoards_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewFeasibility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feasibilityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardDBDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewFeasibility;
        private BoardDBDataSet boardDBDataSet;
        private System.Windows.Forms.BindingSource feasibilityBindingSource;
        private BoardDBDataSetTableAdapters.FeasibilityTableAdapter feasibilityTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn phase;
        private System.Windows.Forms.DataGridViewTextBoxColumn carline;
        private System.Windows.Forms.DataGridViewTextBoxColumn fam;
        private System.Windows.Forms.DataGridViewTextBoxColumn mYC;
        private System.Windows.Forms.DataGridViewTextBoxColumn type_of_change;
        private System.Windows.Forms.DataGridViewTextBoxColumn what_is_the_change;
        private System.Windows.Forms.DataGridViewTextBoxColumn integration;
        private System.Windows.Forms.DataGridViewTextBoxColumn board_availability;
        private System.Windows.Forms.DataGridViewTextBoxColumn holders_board;
        private System.Windows.Forms.DataGridViewTextBoxColumn holders_eol;
        private System.Windows.Forms.DataGridViewTextBoxColumn programme;
        private System.Windows.Forms.DataGridViewTextBoxColumn serial_board_integration;
        private System.Windows.Forms.DataGridViewTextBoxColumn workplace_integration;
    }
}