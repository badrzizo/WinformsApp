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

namespace WinFormsApp.Feasability
{
    public partial class AddFormFeasabilty: Form
    {
        public AddFormFeasabilty()
        {
            InitializeComponent();

            IntegrationComboBox.Items.AddRange(new string[] {
            "Yes",
            "No"});
            IntegrationComboBox.SelectedIndex = 0;

            BoardCombobox.Items.AddRange(new String[] {
            "Yes",
            "No"});
            BoardCombobox.SelectedIndex = 0;

            HoldersComboBox.Items.AddRange(new string[] {
            "Yes",
            "No"});
            HoldersComboBox.SelectedIndex = 0;

            HoldersEOLcombobox.Items.AddRange(new string[] {
            "Yes",
            "No"});
            HoldersEOLcombobox.SelectedIndex = 0;

            ProgrammeCombobox.Items.AddRange(new string[] {
            "Yes",
            "No"});
            ProgrammeCombobox.SelectedIndex = 0;

            SerialBoardCombobox.Items.AddRange(new string[] {
            "Yes",
            "No"});
            SerialBoardCombobox.SelectedIndex = 0;

            WorkplaceCombobox.Items.AddRange(new string[] {
            "Yes",
            "No"});
            WorkplaceCombobox.SelectedIndex = 0;


            GetDataPhaseComboBox();
            GetDataCarlineComboBox();
            GetDataFamComboBox();
            GetDataMycComboBox();
            GetDataTOCComboBox();


            PhaseComboBox.SelectedIndex = 0;
            CarlineCombobox.SelectedIndex = 0;
            FamComboBox.SelectedIndex = 0;
            MycComboBox.SelectedIndex = 0;
            TOCcombobox.SelectedIndex = 0;


        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            string phase = PhaseComboBox.SelectedItem?.ToString();
            string carline = CarlineCombobox.SelectedItem?.ToString();
            string fam = FamComboBox.SelectedItem?.ToString();
            string Myc = MycComboBox.SelectedItem?.ToString();
            string TOC = TOCcombobox.SelectedItem?.ToString();
            string Integration = IntegrationComboBox.SelectedItem?.ToString();
            string Board = BoardCombobox.SelectedItem?.ToString();
            string Holders = HoldersComboBox.SelectedItem?.ToString();
            string wtc = WTCCombobox.Text.Trim();
            string HoldersEOL = HoldersEOLcombobox.SelectedItem?.ToString();
            string Programme = ProgrammeCombobox.SelectedItem?.ToString();
            string SerialBoard = SerialBoardCombobox.SelectedItem?.ToString();
            string Workplace = WorkplaceCombobox.SelectedItem?.ToString();

            // Get the DateTime value directly from the DateTimePicker
            DateTime Date = dateTimePicker1.Value;

            Insertfisiability(phase, carline, fam, Myc, TOC, Integration, Board, Holders, wtc, HoldersEOL, Programme, SerialBoard, Workplace, Date);



            this.DialogResult = DialogResult.OK;
            this.Close();


        }


        private void GetDataPhaseComboBox()
        {
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Name FROM PhaseFeasability";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PhaseComboBox.Items.Add(reader["Name"].ToString());
                    }
                }
            }
        }

        private void GetDataCarlineComboBox()
        {
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Name FROM Carline";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CarlineCombobox.Items.Add(reader["Name"].ToString());
                    }
                }
            }
        }

        private void GetDataFamComboBox()
        {
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT family_name FROM Family";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        FamComboBox.Items.Add(reader["family_name"].ToString());
                    }
                }
            }
        }

        private void GetDataMycComboBox()
        {
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Name FROM MYC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        MycComboBox.Items.Add(reader["Name"].ToString());
                    }
                }
            }
        }

        private void GetDataTOCComboBox()
        {
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Text FROM Type_Of_Change";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TOCcombobox.Items.Add(reader["Text"].ToString());
                    }
                }
            }
        }


        private void Insertfisiability(string phase,
            string carline, string fam, string Myc, string TOC, string Integration, string Board,
            string Holders, string wtc, string HoldersEOL, string Programme,
            string SerialBoard, string Workplace, DateTime Date)
        {
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Feasibility (date, phase, carline, fam, MYC, type_of_change, what_is_the_change, 
                          integration, board_availability, holders_board, holders_eol, programme, 
                          serial_board_integration, workplace_integration)
                         VALUES (@Date, @Phase, @Carline, @Fam, @Myc, @TOC, @WhatIsTheChange, @Integration, 
                                 @Board, @Holders,@HoldersEOL, @Programme, @SerialBoard, @Workplace)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Pass DateTime directly as parameter
                    cmd.Parameters.AddWithValue("@Date", Date); // No need to manually parse or convert Date
                    cmd.Parameters.AddWithValue("@Phase", phase);
                    cmd.Parameters.AddWithValue("@Carline", carline);
                    cmd.Parameters.AddWithValue("@Fam", fam);
                    cmd.Parameters.AddWithValue("@Myc", Myc);
                    cmd.Parameters.AddWithValue("@TOC", TOC);
                    cmd.Parameters.AddWithValue("@WhatIsTheChange", wtc);  // Adjust if necessary
                    cmd.Parameters.AddWithValue("@Integration", Integration);
                    cmd.Parameters.AddWithValue("@Board", Board);
                    cmd.Parameters.AddWithValue("@Holders", Holders);
                    cmd.Parameters.AddWithValue("@HoldersEOL", HoldersEOL);
                    cmd.Parameters.AddWithValue("@Programme", Programme);
                    cmd.Parameters.AddWithValue("@SerialBoard", SerialBoard);
                    cmd.Parameters.AddWithValue("@Workplace", Workplace);

                    // Execute the insert command
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Data inserted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BoardsApp.FeasabilityFolder.ManagerPhase managerPhase = new BoardsApp.FeasabilityFolder.ManagerPhase();
            managerPhase.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BoardsApp.FeasabilityFolder.ManagerCarlineFrom managerCarlineFrom = new BoardsApp.FeasabilityFolder.ManagerCarlineFrom();
            managerCarlineFrom.ShowDialog();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BoardsApp.FeasabilityFolder.ManagerFamiliesForm managerFam = new BoardsApp.FeasabilityFolder.ManagerFamiliesForm();
            managerFam.ShowDialog();

        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BoardsApp.FeasabilityFolder.ManagerMYCForm managerMYC = new BoardsApp.FeasabilityFolder.ManagerMYCForm();
            managerMYC.ShowDialog();

        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BoardsApp.FeasabilityFolder.ManagerTOC managerTOC = new BoardsApp.FeasabilityFolder.ManagerTOC();
            managerTOC.ShowDialog();
        }
    }
}
