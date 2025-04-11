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
                string projectQuery = "SELECT project_name FROM Project"; 
                SqlDataAdapter projectAdapter = new SqlDataAdapter(projectQuery, conn);
                DataTable projectTable = new DataTable();
                projectAdapter.Fill(projectTable);
                comboBoxProject.DataSource = projectTable;
                comboBoxProject.DisplayMember = "project_name"; // Display the project name
                comboBoxProject.ValueMember = "project_name";   // Use the project name as the value
                comboBoxProject.SelectedIndex = 0;
            }

            // Load Departments into comboBoxDpt
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string departmentQuery = "SELECT departement_name FROM Department"; 
                SqlDataAdapter departmentAdapter = new SqlDataAdapter(departmentQuery, conn);
                DataTable departmentTable = new DataTable();
                departmentAdapter.Fill(departmentTable);
                comboBoxDpt.DataSource = departmentTable;
                comboBoxDpt.DisplayMember = "departement_name"; // Display the department name
                comboBoxDpt.ValueMember = "departement_name";   // Use the department name as the value
                comboBoxDpt.SelectedIndex = 0;
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
                string selectedProject = selectedRow["project_name"].ToString(); // Use correct column name

                // Debugging: Show the selected project name
                MessageBox.Show($"Selected Project: {selectedProject}");

                if (!string.IsNullOrEmpty(selectedProject))
                {
                    LoadFamiliesForProject(selectedProject);
                }
            }
        }




        private void LoadFamiliesForProject(string projectName)
        {
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";

            // Get family names related to the selected project
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT f.family_name
            FROM Family f
            INNER JOIN ProjectFamily pf ON f.id = pf.family_id
            INNER JOIN Project p ON pf.project_id = p.id
            WHERE p.project_name = @ProjectName";  

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
            string project = comboBoxProject.SelectedItem is DataRowView rowProject ? rowProject["project_name"].ToString() : comboBoxProject.SelectedItem?.ToString(); // Handle DataRowView and MannuallyField
            string fam = comboBoxFam.SelectedItem?.ToString();
            string dpt = comboBoxDpt.SelectedItem is DataRowView rowDpt ? rowDpt["departement_name"].ToString() : comboBoxDpt.SelectedItem?.ToString();
            string status = comboBoxStatus.SelectedItem?.ToString();
            string issues = textBoxIssues.Text.Trim();
            string actions = textBoxActions.Text.Trim();
            string owner = textBoxOwner.Text.Trim();
            DateTime dueDate = dateTimePickerDueDate.Value; // Corrected to use DateTime instead of string

            // Validate required fields
            if (string.IsNullOrEmpty(project) || string.IsNullOrEmpty(fam) ||
                string.IsNullOrEmpty(dpt) || string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Please select all required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Insert data into databasex
            InsertRoadblock(project, fam, dpt, status, issues, actions, owner, dueDate); // Pass DateTime directly

            // Notify parent form (Roadblocks) that data has been inserted
            this.DialogResult = DialogResult.OK; // Will be used in the parent form

            // Close form after insertion
            this.Close();
        }


        // Handle the Insert Of Data
        private void InsertRoadblock(string project, string family, string department, string status,
                    string issues, string actions, string owner, DateTime dueDate)
        {
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";

            try
            {
                // Fetch the IDs first
                int projectId = GetProjectId(project);
                int famId = GetFamilyId(family);
                int dptId = GetDepartmentId(department);

                // Validate all required IDs were found
                if (projectId == -1 || famId == -1 || dptId == -1)
                {
                    MessageBox.Show("Invalid project, family or department selection",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate required text fields
                if (string.IsNullOrWhiteSpace(issues))
                {
                    MessageBox.Show("Issues field cannot be empty", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(actions))
                {
                    MessageBox.Show("Actions field cannot be empty", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(owner))
                {
                    MessageBox.Show("Owner field cannot be empty", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Roadblocks 
                           (project_id, fam_id, dpt_id, status, issues, actions, owner, due_date) 
                           VALUES (@ProjectId, @FamId, @DptId, @Status, @Issues, @Actions, @Owner, @DueDate)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProjectId", projectId);
                        cmd.Parameters.AddWithValue("@FamId", famId);
                        cmd.Parameters.AddWithValue("@DptId", dptId);

                        // Status is the only nullable field
                        if (string.IsNullOrWhiteSpace(status))
                            cmd.Parameters.AddWithValue("@Status", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@Status", status);

                        // Required fields
                        cmd.Parameters.AddWithValue("@Issues", issues);
                        cmd.Parameters.AddWithValue("@Actions", actions);
                        cmd.Parameters.AddWithValue("@Owner", owner);
                        cmd.Parameters.AddWithValue("@DueDate", dueDate.Date); // Ensure only date part is used

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Point added successfully!", "Success",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to add Point", "Error",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle specific SQL errors
                if (sqlEx.Number == 547) // Foreign key violation
                {
                    MessageBox.Show("Invalid project, family or department reference",
                                  "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Database error: {sqlEx.Message}", "Database Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private int GetProjectId(string projectName)
        {
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id FROM Project WHERE project_name = @ProjectName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProjectName", projectName);
                    var result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show($"Project '{projectName}' not found in the database.");
                        return -1; // Return -1 if not found
                    }

                    return Convert.ToInt32(result);
                
                }
            }
        }



        private int GetFamilyId(string familyName)
        {
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id FROM Family WHERE family_name = @FamilyName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FamilyName", familyName);
                    var result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show($"Family '{familyName}' not found in the database.");
                        return -1; // Return -1 if not found
                    }

                    return Convert.ToInt32(result);
                }
            }
        }




        private int GetDepartmentId(string departmentName)
        {
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id FROM Department WHERE departement_name = @DepartmentName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                    var result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show($"Department '{departmentName}' not found in the database.");
                        return -1; // Return -1 if not found
                    }

                    return Convert.ToInt32(result);
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
