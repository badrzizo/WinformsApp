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
            this.button3 = new System.Windows.Forms.Button();
            this.DownloadPDF = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.comboBoxFamily = new System.Windows.Forms.ComboBox();
            this.comboBoxProject = new System.Windows.Forms.ComboBox();
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.DownloadPDF);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.groupBox1);
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
            this.groupBox2.Location = new System.Drawing.Point(19, 565);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 189);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total Points";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(19, 461);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(240, 82);
            this.button3.TabIndex = 3;
            this.button3.Text = "Download";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // DownloadPDF
            // 
            this.DownloadPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadPDF.Image = ((System.Drawing.Image)(resources.GetObject("DownloadPDF.Image")));
            this.DownloadPDF.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.DownloadPDF.Location = new System.Drawing.Point(19, 371);
            this.DownloadPDF.Name = "DownloadPDF";
            this.DownloadPDF.Size = new System.Drawing.Size(240, 84);
            this.DownloadPDF.TabIndex = 2;
            this.DownloadPDF.Text = "Download";
            this.DownloadPDF.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.DownloadPDF.UseVisualStyleBackColor = true;
            this.DownloadPDF.Click += new System.EventHandler(this.DownloadPDF_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(19, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(240, 88);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxStatus);
            this.groupBox1.Controls.Add(this.comboBoxFamily);
            this.groupBox1.Controls.Add(this.comboBoxProject);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 259);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter By";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Familiy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Project";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(7, 207);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(234, 28);
            this.comboBoxStatus.TabIndex = 2;
            this.comboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatus_SelectedIndexChanged);
            // 
            // comboBoxFamily
            // 
            this.comboBoxFamily.FormattingEnabled = true;
            this.comboBoxFamily.Location = new System.Drawing.Point(7, 132);
            this.comboBoxFamily.Name = "comboBoxFamily";
            this.comboBoxFamily.Size = new System.Drawing.Size(234, 28);
            this.comboBoxFamily.TabIndex = 1;
            this.comboBoxFamily.SelectedIndexChanged += new System.EventHandler(this.comboBoxFamily_SelectedIndexChanged);
            // 
            // comboBoxProject
            // 
            this.comboBoxProject.FormattingEnabled = true;
            this.comboBoxProject.Location = new System.Drawing.Point(7, 55);
            this.comboBoxProject.Name = "comboBoxProject";
            this.comboBoxProject.Size = new System.Drawing.Size(234, 28);
            this.comboBoxProject.TabIndex = 0;
            this.comboBoxProject.SelectedIndexChanged += new System.EventHandler(this.comboBoxProject_SelectedIndexChanged);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button DownloadPDF;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.ComboBox comboBoxFamily;
        private System.Windows.Forms.ComboBox comboBoxProject;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
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