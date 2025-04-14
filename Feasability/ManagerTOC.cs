using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BoardsApp.FeasabilityFolder
{
    public partial class ManagerTOC: Form
    {
        public ManagerTOC()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         string TOCname = materialTextBox1.Text;

         if (string.IsNullOrWhiteSpace(TOCname))
            {
                MessageBox.Show("Please enter a valid Type of change value.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

         string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Check if TOC already exists
                    string checkQuery = "SELECT COUNT(*) FROM Type_of_change WHERE Text = @Text";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Text", TOCname);
                        int exists = (int)checkCmd.ExecuteScalar();
                        if (exists > 0)
                        {
                            MessageBox.Show("This Type Of change already exists.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    // Insert new TOC
                    string insertQuery = "INSERT INTO Type_of_change (Text) VALUES (@Text)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Text", TOCname);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Type of change added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
