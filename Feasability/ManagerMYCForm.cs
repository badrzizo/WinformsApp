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
    public partial class ManagerMYCForm : Form
    {
        public ManagerMYCForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mycName = materialTextBox1.Text;

            if (string.IsNullOrWhiteSpace(mycName))
            {
                MessageBox.Show("Please enter a valid MYC value.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Check if MYC already exists
                    string checkQuery = "SELECT COUNT(*) FROM MYC WHERE Name = @Name";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Name", mycName);
                        int exists = (int)checkCmd.ExecuteScalar();

                        if (exists > 0)
                        {
                            MessageBox.Show("This MYC already exists.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    // Insert new MYC
                    string insertQuery = "INSERT INTO MYC (Name) VALUES (@Name)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", mycName);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("MYC added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    materialTextBox1.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding MYC: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
