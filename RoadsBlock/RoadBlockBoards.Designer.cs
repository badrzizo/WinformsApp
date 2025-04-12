namespace WinFormsApp.RoadsBlock
{
    partial class RoadBlockBoards
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoadBlockBoards));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonDownloadExcel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.roadblocksBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.boardDBDataSet4 = new WinFormsApp.BoardDBDataSet4();
            this.roadblocksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.boardDBDataSet1 = new WinFormsApp.BoardDBDataSet1();
            this.roadblocksTableAdapter = new WinFormsApp.BoardDBDataSet1TableAdapters.RoadblocksTableAdapter();
            this.boardDBDataSet3 = new WinFormsApp.BoardDBDataSet3();
            this.roadblocksBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.roadblocksTableAdapter1 = new WinFormsApp.BoardDBDataSet3TableAdapters.RoadblocksTableAdapter();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boardDBDataSet = new WinFormsApp.BoardDBDataSet();
            this.boardDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.roadblocksTableAdapter2 = new WinFormsApp.BoardDBDataSet4TableAdapters.RoadblocksTableAdapter();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadblocksBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardDBDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadblocksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardDBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardDBDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadblocksBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardDBDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.buttonDownloadExcel);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 799);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 189);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total Points";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Ongoing :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Open :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Closed : ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // buttonDownloadExcel
            // 
            this.buttonDownloadExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDownloadExcel.Image = ((System.Drawing.Image)(resources.GetObject("buttonDownloadExcel.Image")));
            this.buttonDownloadExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonDownloadExcel.Location = new System.Drawing.Point(3, 108);
            this.buttonDownloadExcel.Name = "buttonDownloadExcel";
            this.buttonDownloadExcel.Size = new System.Drawing.Size(240, 82);
            this.buttonDownloadExcel.TabIndex = 3;
            this.buttonDownloadExcel.Text = "Download";
            this.buttonDownloadExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDownloadExcel.UseVisualStyleBackColor = true;
            this.buttonDownloadExcel.Click += new System.EventHandler(this.buttonDownloadExcel_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(3, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(240, 88);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(266, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1312, 799);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // roadblocksBindingSource2
            // 
            this.roadblocksBindingSource2.DataMember = "Roadblocks";
            this.roadblocksBindingSource2.DataSource = this.boardDBDataSet4;
            // 
            // boardDBDataSet4
            // 
            this.boardDBDataSet4.DataSetName = "BoardDBDataSet4";
            this.boardDBDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // roadblocksBindingSource
            // 
            this.roadblocksBindingSource.DataMember = "Roadblocks";
            this.roadblocksBindingSource.DataSource = this.boardDBDataSet1;
            // 
            // boardDBDataSet1
            // 
            this.boardDBDataSet1.DataSetName = "BoardDBDataSet1";
            this.boardDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // roadblocksTableAdapter
            // 
            this.roadblocksTableAdapter.ClearBeforeFill = true;
            // 
            // boardDBDataSet3
            // 
            this.boardDBDataSet3.DataSetName = "BoardDBDataSet3";
            this.boardDBDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // roadblocksBindingSource1
            // 
            this.roadblocksBindingSource1.DataMember = "Roadblocks";
            this.roadblocksBindingSource1.DataSource = this.boardDBDataSet3;
            // 
            // roadblocksTableAdapter1
            // 
            this.roadblocksTableAdapter1.ClearBeforeFill = true;
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
            // boardDBDataSet
            // 
            this.boardDBDataSet.DataSetName = "BoardDBDataSet";
            this.boardDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // boardDBDataSetBindingSource
            // 
            this.boardDBDataSetBindingSource.DataSource = this.boardDBDataSet;
            this.boardDBDataSetBindingSource.Position = 0;
            // 
            // roadblocksTableAdapter2
            // 
            this.roadblocksTableAdapter2.ClearBeforeFill = true;
            // 
            // RoadBlockBoards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1578, 799);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "RoadBlockBoards";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RoadBlockBoards";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadblocksBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardDBDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadblocksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardDBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardDBDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadblocksBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardDBDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private BoardDBDataSet1 boardDBDataSet1;
        private System.Windows.Forms.BindingSource roadblocksBindingSource;
        private BoardDBDataSet1TableAdapters.RoadblocksTableAdapter roadblocksTableAdapter;
        private System.Windows.Forms.Button buttonDownloadExcel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn project_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fam_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn departement_name;
        private BoardDBDataSet3 boardDBDataSet3;
        private System.Windows.Forms.BindingSource roadblocksBindingSource1;
        private BoardDBDataSet3TableAdapters.RoadblocksTableAdapter roadblocksTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.BindingSource boardDBDataSetBindingSource;
        private BoardDBDataSet boardDBDataSet;
        private BoardDBDataSet4 boardDBDataSet4;
        private System.Windows.Forms.BindingSource roadblocksBindingSource2;
        private BoardDBDataSet4TableAdapters.RoadblocksTableAdapter roadblocksTableAdapter2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}