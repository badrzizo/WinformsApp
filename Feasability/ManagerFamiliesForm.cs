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

namespace BoardsApp.FeasabilityFolder
{
    public partial class ManagerFamiliesForm: Form
    {
        public ManagerFamiliesForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string familyName = materialTextBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(familyName))
            {
                MessageBox.Show("Please enter a family name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Check if family already exists
                    string checkQuery = "SELECT COUNT(*) FROM Families WHERE Name = @Name";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Name", familyName);
                        int exists = (int)checkCmd.ExecuteScalar();

                        if (exists > 0)
                        {
                            MessageBox.Show("This family already exists.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    // Insert new family
                    string insertQuery = "INSERT INTO Families (Name) VALUES (@Name)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", familyName);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Family added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    materialTextBox1.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding family: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
