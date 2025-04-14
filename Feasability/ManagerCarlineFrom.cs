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
    public partial class ManagerCarlineFrom: Form
    {
        public ManagerCarlineFrom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string carlineName = materialTextBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(carlineName))
            {
                MessageBox.Show("Please enter a carline name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Check if the carline already exists
                    string checkQuery = "SELECT COUNT(*) FROM Carline WHERE Name = @Name";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Name", carlineName);
                        int exists = (int)checkCmd.ExecuteScalar();

                        if (exists > 0)
                        {
                            MessageBox.Show("This carline already exists.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    // Insert the new carline
                    string insertQuery = "INSERT INTO Carline (Name) VALUES (@Name)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", carlineName);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Carline added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    materialTextBox1.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding carline: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
