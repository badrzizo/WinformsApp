using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp.RoadsBlock
{
    public partial class RoadBlockBoards: Form
    {
        public RoadBlockBoards()
        {
            InitializeComponent();

            this.Load += RoadBlockBoards_Load1;
        }

        private void RoadBlockBoards_Load1(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";
            string query = @"
                SELECT 
                    r.id,
                    p.project_name,
                    f.family_name,
                    d.departement_name,
                    r.status,
                    r.issues,
                    r.actions,
                    r.owner,
                    r.due_date
                FROM 
                    Roadblocks r
                JOIN 
                    Project p ON r.project_id = p.id
                JOIN 
                    Family f ON r.fam_id = f.id
                JOIN 
                    Department d ON r.dpt_id = d.id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Bind the result to the DataGridView
                    dataGridView1.DataSource = dataTable;

                    // Hide the ID column
                    dataGridView1.Columns["id"].Visible = false;

                    // Set the column names
                    dataGridView1.Columns["project_name"].HeaderText = "Project";
                    dataGridView1.Columns["family_name"].HeaderText = "Family";
                    dataGridView1.Columns["departement_name"].HeaderText = "Department";
                    dataGridView1.Columns["status"].HeaderText = "Status";
                    dataGridView1.Columns["issues"].HeaderText = "Issues";
                    dataGridView1.Columns["actions"].HeaderText = "Actions";
                    dataGridView1.Columns["owner"].HeaderText = "Owner";
                    dataGridView1.Columns["due_date"].HeaderText = "Due Date";

                    // Set the width of the columns
                    dataGridView1.Columns["project_name"].Width = 100;
                    dataGridView1.Columns["family_name"].Width = 100;
                    dataGridView1.Columns["departement_name"].Width = 100;
                    dataGridView1.Columns["status"].Width = 100;
                    dataGridView1.Columns["issues"].Width = 100;
                    dataGridView1.Columns["actions"].Width = 100;
                    dataGridView1.Columns["owner"].Width = 100;
                    dataGridView1.Columns["due_date"].Width = 100;


                    // Reorder columns if needed
                    dataGridView1.Columns["project_name"].DisplayIndex = 0;
                    dataGridView1.Columns["family_name"].DisplayIndex = 1;
                    dataGridView1.Columns["departement_name"].DisplayIndex = 2;
                    dataGridView1.Columns["status"].DisplayIndex = 7;
                    dataGridView1.Columns["issues"].DisplayIndex = 3;
                    dataGridView1.Columns["actions"].DisplayIndex = 4;
                    dataGridView1.Columns["owner"].DisplayIndex = 5;
                    dataGridView1.Columns["due_date"].DisplayIndex = 6;


                    // Attach the CellFormatting event handler
                    dataGridView1.CellFormatting += DataGridView1_CellFormatting;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the current column is the "status" column
            if (dataGridView1.Columns[e.ColumnIndex].Name == "status")
            {
                // Check the value in the cell and set the color accordingly
                if (e.Value != null && e.Value.ToString() == "Open")
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (e.Value != null && e.Value.ToString() == "Closed")
                {
                    e.CellStyle.BackColor = Color.Green;
                    e.CellStyle.ForeColor = Color.White;
                }
                else if(e.Value != null && e.Value.ToString() == "Ongoing")
                {
                    e.CellStyle.BackColor = Color.Orange;
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            RoadsBlock.AddingPointsForm addingPointsForm = new RoadsBlock.AddingPointsForm();
            addingPointsForm.ShowDialog();

        }

        private void DownloadPDF_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxProject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxFamily_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
