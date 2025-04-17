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
using Org.BouncyCastle.Cms;

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

            LoadPhaseComboBoxData();
            LoadCarlineComboBoxData();
            LoadFamComboBoxData();
            LoadMYCcomboBox();
            LoadTocComboBox();
            //GetDataPhaseComboBox();
            //GetDataCarlineComboBox();
            //GetDataFamComboBox();
            //GetDataMycComboBox();
            //GetDataTOCComboBox();


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

            try
            {
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
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"SQL Error: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BoardsApp.FeasabilityFolder.ManagerPhase managerPhase = new BoardsApp.FeasabilityFolder.ManagerPhase();
            if(managerPhase.ShowDialog() == DialogResult.OK)
            {
                // Refresh Phase ComboBox
                GetPhaseDataFromDatabase();
            }
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

        private void LoadPhaseComboBoxData()
        {
            // Fetch the data from the database
            DataTable dt = GetPhaseDataFromDatabase();

            // Clear the existing items in the ComboBox
            PhaseComboBox.Items.Clear();

            // Add items to the ComboBox, ensuring only the 'Name' column is added as a string
            foreach (DataRow row in dt.Rows)
            {
                // Add the 'Name' column value to the ComboBox as a string
                PhaseComboBox.Items.Add(row["Name"].ToString());
            }

            // Optionally, set the selected item if you have a default value
            if (PhaseComboBox.Items.Count > 0)
            {
                PhaseComboBox.SelectedIndex = 0; // Set default selected index if needed
            }
        }

        private void LoadCarlineComboBoxData()
        {
            // Fetch the data from the database
            DataTable dt = GetCarlineDataFromDatabase();

            // Clear the existing items in the ComboBox
            CarlineCombobox.Items.Clear();

            // Add items to the ComboBox, ensuring only the 'Name' column is added as a string
            foreach (DataRow row in dt.Rows)
            {
                // Add the 'Name' column value to the ComboBox as a string
                CarlineCombobox.Items.Add(row["Name"].ToString());
            }

            // Optionally, set the selected item if you have a default value
            if (CarlineCombobox.Items.Count > 0)
            {
                CarlineCombobox.SelectedIndex = 0; // Set default selected index if needed
            }
        }

        private void LoadFamComboBoxData()
        {
            // Fetch the data from the database
            DataTable dt = GetFamilyFromDatabase();

            // Clear the existing items in the ComboBox
            FamComboBox.Items.Clear();

            // Add items to the ComboBox, ensuring only the 'Name' column is added as a string
            foreach (DataRow row in dt.Rows)
            {
                // Add the 'Name' column value to the ComboBox as a string
                FamComboBox.Items.Add(row["Name"].ToString());
            }

            // Optionally, set the selected item if you have a default value
            if (FamComboBox.Items.Count > 0)
            {
                FamComboBox.SelectedIndex = 0; // Set default selected index if needed
            }
        }

        private void LoadMYCcomboBox()
        {
            // Fetch the data from the database
            DataTable dt = GetMycFromDatabase();

            // Clear the existing items in the ComboBox
            MycComboBox.Items.Clear();

            // Add items to the ComboBox, ensuring only the 'Name' column is added as a string
            foreach (DataRow row in dt.Rows)
            {
                // Add the 'Name' column value to the ComboBox as a string
                MycComboBox.Items.Add(row["Name"].ToString());
            }

            // Optionally, set the selected item if you have a default value
            if (MycComboBox.Items.Count > 0)
            {
                MycComboBox.SelectedIndex = 0; // Set default selected index if needed
            }
        }


        private void LoadTocComboBox()
        {
            // Fetch the data from the database
            DataTable dt = GetTocFromDataBase();

            // Clear the existing items in the ComboBox
            TOCcombobox.Items.Clear();

            // Add items to the ComboBox, ensuring only the 'Text' column is added as a string
            foreach (DataRow row in dt.Rows)
            {
                // Add the 'Text' column value to the ComboBox as a string
                TOCcombobox.Items.Add(row["Text"].ToString());
            }

            // Optionally, set the selected item if you have a default value
            if (TOCcombobox.Items.Count > 0)
            {
                TOCcombobox.SelectedIndex = 0; // Set default selected index if needed
            }
        }


        private DataTable GetMycFromDatabase()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection("Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;"))
            {
                string sql = "SELECT id,Name FROM MYC";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            return dt;
        }

        


        private bool DeleteMycFromDatabase(int id)
        {
            using (SqlConnection conn = new SqlConnection("Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;"))
            {

                string sql = "DELETE FROM MYC WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    return
                    cmd.ExecuteNonQuery() > 0;

                }
            }
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (PhaseComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select item to delete", "Information",

                MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            int selectedId = (int)PhaseComboBox.SelectedValue;

            if (MessageBox.Show("Delete this Item?", "Confirm",

                MessageBoxButtons.YesNo) ==

                DialogResult.Yes)
            {

                try
                {
                    if (DeleteItemsPhaseComboBox(selectedId))
                    {
                        PhaseComboBox.DataSource = GetPhaseDataFromDatabase();

                        MessageBox.Show("Items deleted successfully.");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting item:{ex.Message} ");
                }
            }

        }

        private bool DeleteItemsPhaseComboBox(int id)
        {
            using (SqlConnection conn = new SqlConnection("Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;"))
            {
                
                string sql = "DELETE FROM PhaseFeasability WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    return
                    cmd.ExecuteNonQuery() > 0;
                    
                }
            }
        }

        private bool DeleteCarlineComboboxItem(int id)
        {
            using (SqlConnection conn = new SqlConnection("Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;"))
            {

                string sql = "DELETE FROM Carline WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    return
                    cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        private bool DeleteFamilyFromDataBase(int id)
        {
            using (SqlConnection conn = new SqlConnection("Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;"))
            {

                string sql = "DELETE FROM Feasability_Family WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    return
                    cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        private bool DeleteTocFromDataBase(int id)
        {
            using (SqlConnection conn = new SqlConnection("Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;"))
            {

                string sql = "DELETE FROM Type_of_change WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    return
                    cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        private DataTable GetCarlineDataFromDatabase()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection("Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;"))
            {
                string sql = "SELECT id, Name FROM Carline ";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            return dt;
        }

        private DataTable GetPhaseDataFromDatabase()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection("Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;"))
            {
                string sql = "SELECT id,Name FROM PhaseFeasability";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            return dt;
        }

        private DataTable GetFamilyFromDatabase()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection("Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;"))
            {
                string sql = "SELECT id,Name FROM Feasability_Family";
                SqlDataAdapter da = new SqlDataAdapter( sql, conn);
                da.Fill(dataTable);
            }
            return dataTable;

        }

        private DataTable GetTocFromDataBase()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection("Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;"))
            {
                string sql = "SELECT id,Text FROM Type_of_change";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dataTable);
            }
            return dataTable;
        }


        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CarlineCombobox.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Carline To Delete", "Information",

                MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            int selectedId = (int)CarlineCombobox.SelectedValue;

            if (MessageBox.Show("Delete this Carline?", "Confirm",

                MessageBoxButtons.YesNo) ==

                DialogResult.Yes)
            {

                try
                {
                    if (DeleteCarlineComboboxItem(selectedId))
                    {
                        CarlineCombobox.DataSource = GetCarlineDataFromDatabase();

                        MessageBox.Show("Items deleted successfully.");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting item:{ex.Message} ");
                }
            }

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (FamComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select A Family","Information",

                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            int selectedId = (int)FamComboBox.SelectedValue;

            if(MessageBox.Show("Delete this Family?","Confirm",
                
                MessageBoxButtons.YesNo) ==
                
               DialogResult.Yes )
            {
                try
                {
                    if(DeleteFamilyFromDataBase(selectedId))
                    {
                        FamComboBox.DataSource = GetFamilyFromDatabase();

                        MessageBox.Show("Items deleted successfully.");
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show($"Error deleting Family: {ex.Message}");
                }
            }
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MycComboBox.SelectedIndex == -1)
            {

                MessageBox.Show("Please Select the Myc to Delete","Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int selectedId = (int)MycComboBox.SelectedValue;



            if (MessageBox.Show("Delete This MYC? ", "Confirm",
                MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {

                try
                {
                    if(DeleteMycFromDatabase(selectedId))
                    {
                        MycComboBox.DataSource = GetMycFromDatabase();

                        MessageBox.Show("Items Deleted succesfully.");
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show($"Error Deleting Item :{ex.Message } ");
                }
           }     
            
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (TOCcombobox.SelectedIndex == -1)
            {

                MessageBox.Show("Please Select the Myc to Delete", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int selectedId = (int)TOCcombobox.SelectedValue;



            if (MessageBox.Show("Delete This MYC? ", "Confirm",
                MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {

                try
                {
                    if (DeleteTocFromDataBase(selectedId))
                    {
                        TOCcombobox.DataSource = GetTocFromDataBase();

                        MessageBox.Show("Items Deleted succesfully.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error Deleting Item :{ex.Message} ");
                }
            }
        }
    }
    }

