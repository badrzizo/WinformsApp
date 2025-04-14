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
    public partial class ManagerPhase : Form
    {
        public ManagerPhase()
        {
            InitializeComponent();
        }


        string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";

        private void button1_Click(object sender, EventArgs e)
        {
            string phaseName = materialTextBox1.Text;

            if (string.IsNullOrWhiteSpace(phaseName))
            {
                MessageBox.Show("Please enter a valid Phase value.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Check if Phase already exists
                    string checkQuery = "SELECT COUNT(*) FROM PhaseFeasability WHERE Name = @Name";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Name", phaseName);
                        int exists = (int)checkCmd.ExecuteScalar();
                        if (exists > 0)
                        {
                            MessageBox.Show("This Phase already exists.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    // Insert new Phase
                    string insertQuery = "INSERT INTO PhaseFeasability (Name) VALUES (@Name)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", phaseName);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Phase added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }

}


      
    

