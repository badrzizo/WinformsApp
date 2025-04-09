using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp.RoadsBlock
{
    public partial class AddingPointsForm : Form
    {
        public AddingPointsForm()
        {
            InitializeComponent();
            LoadComboBoxData();  // Only load the combo boxes data here
            comboBoxProject.SelectedIndexChanged += comboBoxProject_SelectedIndexChanged;
        }

        private void LoadComboBoxData()
        {
            // Connection string to your database
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";

            // Load Projects into comboBoxProject
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string projectQuery = "SELECT project_name FROM Project"; // Replace with your actual table and column names
                SqlDataAdapter projectAdapter = new SqlDataAdapter(projectQuery, conn);
                DataTable projectTable = new DataTable();
                projectAdapter.Fill(projectTable);
                comboBoxProject.DataSource = projectTable;
                comboBoxProject.DisplayMember = "project_name"; // Display the project name
                comboBoxProject.ValueMember = "project_name";   // Use the project name as the value
            }

            // Load Departments into comboBoxDpt
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string departmentQuery = "SELECT departement_name FROM Department"; // Replace with your actual table and column names
                SqlDataAdapter departmentAdapter = new SqlDataAdapter(departmentQuery, conn);
                DataTable departmentTable = new DataTable();
                departmentAdapter.Fill(departmentTable);
                comboBoxDpt.DataSource = departmentTable;
                comboBoxDpt.DisplayMember = "departement_name"; // Display the department name
                comboBoxDpt.ValueMember = "departement_name";   // Use the department name as the value
            }

            // Set Status options
            comboBoxStatus.Items.AddRange(new string[] { "Open", "Closed", "Ongoing" });
            comboBoxStatus.SelectedIndex = 0;  // Set default selection
        }

        private void comboBoxProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When the selected project changes, load the corresponding families
            if (comboBoxProject.SelectedItem != null)
            {
                // Get the DataRowView from the SelectedItem
                DataRowView selectedRow = comboBoxProject.SelectedItem as DataRowView;

                // Extract the project name from the DataRowView
                string selectedProject = selectedRow["project_name"].ToString();

                if (!string.IsNullOrEmpty(selectedProject))
                {
                    LoadFamiliesForProject(selectedProject);
                }
            }
        }


        private void LoadFamiliesForProject(string projectName)
        {
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";
            comboBoxFam.Items.Clear(); // Clear existing items in comboBoxFam

            

            // Get family names related to the selected project
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT f.family_name
            FROM Family f
            INNER JOIN ProjectFamily pf ON f.id = pf.family_id
            INNER JOIN Project p ON pf.project_id = p.id
            WHERE p.project_name = @ProjectName";  // Ensure correct parameter usage

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add the parameter correctly
                    cmd.Parameters.AddWithValue("@ProjectName", projectName);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBoxFam.Items.Add(reader["family_name"].ToString());
                    }
                    comboBoxFam.SelectedIndex = 0;


                    // Set default selection if items are available
                    if (comboBoxFam.Items.Count > 0)
                    {
                        comboBoxFam.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No families found for this project.");
                    }
                }
            }
        }


        private void linkLabelProject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RoadsBlock.ManagerRoadsBloackProject managerRoadsBloackProject = new ManagerRoadsBloackProject();
            managerRoadsBloackProject.Show();
        }

        private void linkLabelFamily_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ManagerRoadsBlockFamily managerRoadsBlockFamily = new ManagerRoadsBlockFamily();
            managerRoadsBlockFamily.Show();
        }

        private void linkLabelDepartement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ManagerRoadsBlockDepartement managerRoadsBlockDepartement = new ManagerRoadsBlockDepartement();
            managerRoadsBlockDepartement.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get selected values from ComboBoxes and TextBoxes
            string project = comboBoxProject.SelectedItem?.ToString();
            string fam = comboBoxFam.SelectedItem?.ToString();
            string dpt = comboBoxDpt.SelectedItem?.ToString();
            string status = comboBoxStatus.SelectedItem?.ToString();
            string issues = textBoxIssues.Text.Trim();
            string actions = textBoxActions.Text.Trim();
            string owner = textBoxOwner.Text.Trim();
            string dueDate = dateTimePickerDueDate.Value.ToString("yyyy-MM-dd");

            // Validate required fields
            if (string.IsNullOrEmpty(project) || string.IsNullOrEmpty(fam) ||
                string.IsNullOrEmpty(dpt) || string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Please select all required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Insert data into database
            InsertRoadblock(project, fam, dpt, status, issues, actions, owner, dueDate);

            // Notify parent form (Roadblocks) that data has been inserted
            this.DialogResult = DialogResult.OK; // Will be used in the parent form

            // Close form after insertion
            this.Close();
        }

        private void InsertRoadblock(string project, string fam, string dpt, string status,
                            string issues, string actions, string owner, string dueDate)
        {
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Roadblocks (project, fam, dpt, status, issues, actions, owner, due_date) " +
                               "VALUES (@Project, @Fam, @Dpt, @Status, @Issues, @Actions, @Owner, @DueDate)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Project", project);
                    cmd.Parameters.AddWithValue("@Fam", fam);
                    cmd.Parameters.AddWithValue("@Dpt", dpt);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@Issues", issues);
                    cmd.Parameters.AddWithValue("@Actions", actions);
                    cmd.Parameters.AddWithValue("@Owner", owner);
                    cmd.Parameters.AddWithValue("@DueDate", dueDate);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Data inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
