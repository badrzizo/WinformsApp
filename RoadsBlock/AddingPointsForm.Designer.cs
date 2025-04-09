namespace WinFormsApp.RoadsBlock
{
    partial class AddingPointsForm
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
            this.feasibilityTableAdapter1 = new WinFormsApp.BoardDBDataSetTableAdapters.FeasibilityTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel6 = new System.Windows.Forms.LinkLabel();
            this.linkLabelDepartement = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabelFamily = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabelProject = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePickerDueDate = new System.Windows.Forms.DateTimePicker();
            this.tableAdapterManager1 = new WinFormsApp.BoardDBDataSetTableAdapters.TableAdapterManager();
            this.textBoxIssues = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.textBoxActions = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.comboBoxProject = new MaterialSkin.Controls.MaterialComboBox();
            this.comboBoxFam = new MaterialSkin.Controls.MaterialComboBox();
            this.comboBoxDpt = new MaterialSkin.Controls.MaterialComboBox();
            this.comboBoxStatus = new MaterialSkin.Controls.MaterialComboBox();
            this.textBoxOwner = new MaterialSkin.Controls.MaterialTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // feasibilityTableAdapter1
            // 
            this.feasibilityTableAdapter1.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.SeaShell;
            this.groupBox1.Controls.Add(this.textBoxOwner);
            this.groupBox1.Controls.Add(this.comboBoxStatus);
            this.groupBox1.Controls.Add(this.comboBoxDpt);
            this.groupBox1.Controls.Add(this.comboBoxFam);
            this.groupBox1.Controls.Add(this.comboBoxProject);
            this.groupBox1.Controls.Add(this.textBoxActions);
            this.groupBox1.Controls.Add(this.textBoxIssues);
            this.groupBox1.Controls.Add(this.linkLabel6);
            this.groupBox1.Controls.Add(this.linkLabelDepartement);
            this.groupBox1.Controls.Add(this.linkLabel4);
            this.groupBox1.Controls.Add(this.linkLabelFamily);
            this.groupBox1.Controls.Add(this.linkLabel2);
            this.groupBox1.Controls.Add(this.linkLabelProject);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dateTimePickerDueDate);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1037, 583);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Forms";
            // 
            // linkLabel6
            // 
            this.linkLabel6.AutoSize = true;
            this.linkLabel6.Location = new System.Drawing.Point(309, 270);
            this.linkLabel6.Name = "linkLabel6";
            this.linkLabel6.Size = new System.Drawing.Size(128, 16);
            this.linkLabel6.TabIndex = 22;
            this.linkLabel6.TabStop = true;
            this.linkLabel6.Text = "Delete Departement";
            // 
            // linkLabelDepartement
            // 
            this.linkLabelDepartement.AutoSize = true;
            this.linkLabelDepartement.Location = new System.Drawing.Point(309, 237);
            this.linkLabelDepartement.Name = "linkLabelDepartement";
            this.linkLabelDepartement.Size = new System.Drawing.Size(113, 16);
            this.linkLabelDepartement.TabIndex = 21;
            this.linkLabelDepartement.TabStop = true;
            this.linkLabelDepartement.Text = "Add Departement";
            this.linkLabelDepartement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDepartement_LinkClicked);
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(309, 191);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(90, 16);
            this.linkLabel4.TabIndex = 20;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Delete Family";
            // 
            // linkLabelFamily
            // 
            this.linkLabelFamily.AutoSize = true;
            this.linkLabelFamily.Location = new System.Drawing.Point(309, 159);
            this.linkLabelFamily.Name = "linkLabelFamily";
            this.linkLabelFamily.Size = new System.Drawing.Size(78, 16);
            this.linkLabelFamily.TabIndex = 19;
            this.linkLabelFamily.TabStop = true;
            this.linkLabelFamily.Text = "Add Familiy";
            this.linkLabelFamily.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelFamily_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(309, 112);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(92, 16);
            this.linkLabel2.TabIndex = 18;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Delete Project";
            // 
            // linkLabelProject
            // 
            this.linkLabelProject.AutoSize = true;
            this.linkLabelProject.Location = new System.Drawing.Point(309, 79);
            this.linkLabelProject.Name = "linkLabelProject";
            this.linkLabelProject.Size = new System.Drawing.Size(77, 16);
            this.linkLabelProject.TabIndex = 17;
            this.linkLabelProject.TabStop = true;
            this.linkLabelProject.Text = "Add Project";
            this.linkLabelProject.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelProject_LinkClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(473, 334);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Owner";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(473, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Actions";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(478, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Issues";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 383);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Due Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Departement";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Familiy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Project";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(38, 457);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 46);
            this.button1.TabIndex = 6;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePickerDueDate
            // 
            this.dateTimePickerDueDate.Location = new System.Drawing.Point(11, 412);
            this.dateTimePickerDueDate.Name = "dateTimePickerDueDate";
            this.dateTimePickerDueDate.Size = new System.Drawing.Size(254, 22);
            this.dateTimePickerDueDate.TabIndex = 5;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.FeasibilityTableAdapter = this.feasibilityTableAdapter1;
            this.tableAdapterManager1.UpdateOrder = WinFormsApp.BoardDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // textBoxIssues
            // 
            this.textBoxIssues.AnimateReadOnly = false;
            this.textBoxIssues.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxIssues.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxIssues.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxIssues.Depth = 0;
            this.textBoxIssues.HideSelection = true;
            this.textBoxIssues.Location = new System.Drawing.Point(476, 70);
            this.textBoxIssues.MaxLength = 32767;
            this.textBoxIssues.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxIssues.Name = "textBoxIssues";
            this.textBoxIssues.PasswordChar = '\0';
            this.textBoxIssues.ReadOnly = false;
            this.textBoxIssues.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxIssues.SelectedText = "";
            this.textBoxIssues.SelectionLength = 0;
            this.textBoxIssues.SelectionStart = 0;
            this.textBoxIssues.ShortcutsEnabled = true;
            this.textBoxIssues.Size = new System.Drawing.Size(467, 100);
            this.textBoxIssues.TabIndex = 23;
            this.textBoxIssues.TabStop = false;
            this.textBoxIssues.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxIssues.UseSystemPasswordChar = false;
            // 
            // textBoxActions
            // 
            this.textBoxActions.AnimateReadOnly = false;
            this.textBoxActions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxActions.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxActions.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxActions.Depth = 0;
            this.textBoxActions.HideSelection = true;
            this.textBoxActions.Location = new System.Drawing.Point(476, 211);
            this.textBoxActions.MaxLength = 32767;
            this.textBoxActions.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxActions.Name = "textBoxActions";
            this.textBoxActions.PasswordChar = '\0';
            this.textBoxActions.ReadOnly = false;
            this.textBoxActions.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxActions.SelectedText = "";
            this.textBoxActions.SelectionLength = 0;
            this.textBoxActions.SelectionStart = 0;
            this.textBoxActions.ShortcutsEnabled = true;
            this.textBoxActions.Size = new System.Drawing.Size(467, 100);
            this.textBoxActions.TabIndex = 25;
            this.textBoxActions.TabStop = false;
            this.textBoxActions.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxActions.UseSystemPasswordChar = false;
            // 
            // comboBoxProject
            // 
            this.comboBoxProject.AutoResize = false;
            this.comboBoxProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxProject.Depth = 0;
            this.comboBoxProject.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxProject.DropDownHeight = 174;
            this.comboBoxProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProject.DropDownWidth = 121;
            this.comboBoxProject.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxProject.FormattingEnabled = true;
            this.comboBoxProject.IntegralHeight = false;
            this.comboBoxProject.ItemHeight = 43;
            this.comboBoxProject.Location = new System.Drawing.Point(6, 79);
            this.comboBoxProject.MaxDropDownItems = 4;
            this.comboBoxProject.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxProject.Name = "comboBoxProject";
            this.comboBoxProject.Size = new System.Drawing.Size(297, 49);
            this.comboBoxProject.StartIndex = 0;
            this.comboBoxProject.TabIndex = 26;
            // 
            // comboBoxFam
            // 
            this.comboBoxFam.AutoResize = false;
            this.comboBoxFam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxFam.Depth = 0;
            this.comboBoxFam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxFam.DropDownHeight = 174;
            this.comboBoxFam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFam.DropDownWidth = 121;
            this.comboBoxFam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxFam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxFam.FormattingEnabled = true;
            this.comboBoxFam.IntegralHeight = false;
            this.comboBoxFam.ItemHeight = 43;
            this.comboBoxFam.Location = new System.Drawing.Point(6, 159);
            this.comboBoxFam.MaxDropDownItems = 4;
            this.comboBoxFam.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxFam.Name = "comboBoxFam";
            this.comboBoxFam.Size = new System.Drawing.Size(297, 49);
            this.comboBoxFam.StartIndex = 0;
            this.comboBoxFam.TabIndex = 27;
            // 
            // comboBoxDpt
            // 
            this.comboBoxDpt.AutoResize = false;
            this.comboBoxDpt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxDpt.Depth = 0;
            this.comboBoxDpt.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxDpt.DropDownHeight = 174;
            this.comboBoxDpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDpt.DropDownWidth = 121;
            this.comboBoxDpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxDpt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxDpt.FormattingEnabled = true;
            this.comboBoxDpt.IntegralHeight = false;
            this.comboBoxDpt.ItemHeight = 43;
            this.comboBoxDpt.Location = new System.Drawing.Point(9, 237);
            this.comboBoxDpt.MaxDropDownItems = 4;
            this.comboBoxDpt.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxDpt.Name = "comboBoxDpt";
            this.comboBoxDpt.Size = new System.Drawing.Size(297, 49);
            this.comboBoxDpt.StartIndex = 0;
            this.comboBoxDpt.TabIndex = 28;
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.AutoResize = false;
            this.comboBoxStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxStatus.Depth = 0;
            this.comboBoxStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxStatus.DropDownHeight = 174;
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.DropDownWidth = 121;
            this.comboBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.IntegralHeight = false;
            this.comboBoxStatus.ItemHeight = 43;
            this.comboBoxStatus.Location = new System.Drawing.Point(6, 320);
            this.comboBoxStatus.MaxDropDownItems = 4;
            this.comboBoxStatus.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(297, 49);
            this.comboBoxStatus.StartIndex = 0;
            this.comboBoxStatus.TabIndex = 29;
            // 
            // textBoxOwner
            // 
            this.textBoxOwner.AnimateReadOnly = false;
            this.textBoxOwner.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxOwner.Depth = 0;
            this.textBoxOwner.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxOwner.LeadingIcon = null;
            this.textBoxOwner.Location = new System.Drawing.Point(476, 364);
            this.textBoxOwner.MaxLength = 50;
            this.textBoxOwner.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxOwner.Multiline = false;
            this.textBoxOwner.Name = "textBoxOwner";
            this.textBoxOwner.Size = new System.Drawing.Size(304, 50);
            this.textBoxOwner.TabIndex = 30;
            this.textBoxOwner.Text = "";
            this.textBoxOwner.TrailingIcon = null;
            // 
            // AddingPointsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 608);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddingPointsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddingPointsForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BoardDBDataSetTableAdapters.FeasibilityTableAdapter feasibilityTableAdapter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePickerDueDate;
        private BoardDBDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.LinkLabel linkLabel6;
        private System.Windows.Forms.LinkLabel linkLabelDepartement;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabelFamily;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabelProject;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 textBoxActions;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 textBoxIssues;
        private MaterialSkin.Controls.MaterialComboBox comboBoxStatus;
        private MaterialSkin.Controls.MaterialComboBox comboBoxDpt;
        private MaterialSkin.Controls.MaterialComboBox comboBoxFam;
        private MaterialSkin.Controls.MaterialComboBox comboBoxProject;
        private MaterialSkin.Controls.MaterialTextBox textBoxOwner;
    }
}