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

        private void RoadBlockBoards_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'boardDBDataSet1.Roadblocks'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            //this.roadblocksTableAdapter.Fill(this.boardDBDataSet1.Roadblocks);

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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
    }
}
