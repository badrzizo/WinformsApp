using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace WinFormsApp.Feasability
{
    public partial class FeasabilityBoards: Form
    {
        public FeasabilityBoards()
        {
            InitializeComponent();

            //Enable Datagrid update
            DataGridViewFeasibility.ReadOnly = false;

            DataGridViewFeasibility.EnableHeadersVisualStyles = false;
            DataGridViewFeasibility.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Green;
            DataGridViewFeasibility.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            DataGridViewFeasibility.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(DataGridViewFeasibility.Font, FontStyle.Bold);


            // Hide id column
            DataGridViewFeasibility.Columns["id"].Visible = false;


            DataGridViewFeasibility.Columns["integration"].HeaderText = "Integration";
            DataGridViewFeasibility.Columns["board_availability"].HeaderText = "Board Availability";
            DataGridViewFeasibility.Columns["holders_board"].HeaderText = "Holders Board";
            DataGridViewFeasibility.Columns["holders_eol"].HeaderText = "Holders EOL";
            DataGridViewFeasibility.Columns["programme"].HeaderText = "Programme";
            DataGridViewFeasibility.Columns["serial_board_integration"].HeaderText = "Serial Board Integration";
            DataGridViewFeasibility.Columns["workplace_integration"].HeaderText = "Workplace Integration";
            DataGridViewFeasibility.Columns["date"].HeaderText = "Date";
            DataGridViewFeasibility.Columns["phase"].HeaderText = "Phase";
            DataGridViewFeasibility.Columns["carline"].HeaderText = "Carline";
            DataGridViewFeasibility.Columns["fam"].HeaderText = "Family";
            DataGridViewFeasibility.Columns["MYC"].HeaderText = "MYC";
            DataGridViewFeasibility.Columns["type_of_change"].HeaderText = "Type of Change";
            DataGridViewFeasibility.Columns["what_is_the_change"].HeaderText = "What is the Change";
            DataGridViewFeasibility.Columns["what_is_the_change"].Width = 200;
            DataGridViewFeasibility.Columns["type_of_change"].Width = 200;
            DataGridViewFeasibility.Columns["date"].Width = 100;
            DataGridViewFeasibility.Columns["phase"].Width = 100;
            DataGridViewFeasibility.Columns["carline"].Width = 100;
            DataGridViewFeasibility.Columns["fam"].Width = 100;
            DataGridViewFeasibility.Columns["MYC"].Width = 100;
            DataGridViewFeasibility.Columns["type_of_change"].Width = 100;
            DataGridViewFeasibility.Columns["what_is_the_change"].Width = 100;
            DataGridViewFeasibility.Columns["integration"].Width = 100;
            DataGridViewFeasibility.Columns["board_availability"].Width = 100;
            DataGridViewFeasibility.Columns["holders_board"].Width = 100;
            DataGridViewFeasibility.Columns["holders_eol"].Width = 100;
            DataGridViewFeasibility.Columns["programme"].Width = 100;
            DataGridViewFeasibility.Columns["serial_board_integration"].Width = 100;
            DataGridViewFeasibility.Columns["workplace_integration"].Width = 100;

            DataGridViewFeasibility.Columns["integration"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewFeasibility.Columns["board_availability"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewFeasibility.Columns["holders_board"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewFeasibility.Columns["holders_eol"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewFeasibility.Columns["programme"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewFeasibility.Columns["serial_board_integration"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewFeasibility.Columns["workplace_integration"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewFeasibility.Columns["date"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewFeasibility.Columns["phase"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewFeasibility.Columns["carline"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewFeasibility.Columns["fam"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewFeasibility.Columns["MYC"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewFeasibility.Columns["type_of_change"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewFeasibility.Columns["what_is_the_change"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            DataGridViewFeasibility.Columns["integration"].HeaderCell.Style.BackColor = Color.DarkBlue;
            DataGridViewFeasibility.Columns["board_availability"].HeaderCell.Style.BackColor = Color.DarkBlue;
            DataGridViewFeasibility.Columns["holders_board"].HeaderCell.Style.BackColor = Color.DarkBlue;
            DataGridViewFeasibility.Columns["holders_eol"].HeaderCell.Style.BackColor = Color.DarkBlue;
            DataGridViewFeasibility.Columns["programme"].HeaderCell.Style.BackColor = Color.DarkBlue;
            DataGridViewFeasibility.Columns["serial_board_integration"].HeaderCell.Style.BackColor = Color.DarkBlue;
            DataGridViewFeasibility.Columns["workplace_integration"].HeaderCell.Style.BackColor = Color.DarkBlue;


            DataGridViewFeasibility.Columns["integration"].HeaderCell.Style.ForeColor = Color.White;
            DataGridViewFeasibility.Columns["board_availability"].HeaderCell.Style.ForeColor = Color.White;
            DataGridViewFeasibility.Columns["holders_board"].HeaderCell.Style.ForeColor = Color.White;
            DataGridViewFeasibility.Columns["holders_eol"].HeaderCell.Style.ForeColor = Color.White;
            DataGridViewFeasibility.Columns["programme"].HeaderCell.Style.ForeColor = Color.White;
            DataGridViewFeasibility.Columns["serial_board_integration"].HeaderCell.Style.ForeColor = Color.White;
            DataGridViewFeasibility.Columns["workplace_integration"].HeaderCell.Style.ForeColor = Color.White;

            






            // Handle the CellValueChanged event to color the cells
            DataGridViewFeasibility.CellValueChanged += DataGridViewFeasibility_CellValueChanged;

            DataGridViewFeasibility.DataError += DataGridViewFeasibility_DataError;

            DataGridViewFeasibility.CellEndEdit += DataGridViewFeasibility_CellEndEdit;

            DataGridViewFeasibility.UserDeletingRow += DataGridViewFeasibility_UserDeletingRow;

            DataGridViewFeasibility.CellContentClick += DataGridViewFeasibility_CellContentClick;

        }

        private void DataGridViewFeasibility_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Handle data error if needed
            MessageBox.Show("Data error: " + e.Exception.Message);
        }


        private void UpdateFeasabilityInDatabase(int id, string columnName, string value)
        
        {
            // Update the database with the new value
            using (SqlConnection connection = new SqlConnection("Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;"))
            {
                connection.Open();
                string query = $"UPDATE Feasibility SET {columnName} = @value WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@value", value);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }


        }
               

        private void DeleteFromfeasability(int id)
        {
            // Delete the record from the database
            using (SqlConnection connection = new SqlConnection("Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;"))
            {
                connection.Open();
                string query = "DELETE FROM Feasibility WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }


        private void DataGridViewFeasibility_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Get the ID of the row being deleted
            int id = Convert.ToInt32(e.Row.Cells["id"].Value);
            // Confirm deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Delete the record from the database
                DeleteFromfeasability(id);
            }
            else
            {
                e.Cancel = true; // Cancel the deletion if user selects No
            }
        }


        // Adding Delete button to each row
        private void DataGridViewFeasibility_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == DataGridViewFeasibility.Columns["Delete"].Index)
            {
                // Get the ID of the row being deleted
                int id = Convert.ToInt32(DataGridViewFeasibility.Rows[e.RowIndex].Cells["id"].Value);
                // Confirm deletion
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Delete the record from the database
                    DeleteFromfeasability(id);
                    // Refresh the DataGridView
                    this.feasibilityTableAdapter.Fill(this.boardDBDataSet.Feasibility);
                    ColorYesNoCells();
                }
            }
        }







        private void DataGridViewFeasibility_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the edited cell is in a yes/no column
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = DataGridViewFeasibility.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null)
                {
                    string cellText = cell.Value.ToString().Trim();
                    int id = Convert.ToInt32(DataGridViewFeasibility.Rows[e.RowIndex].Cells["id"].Value);
                    // Update the database with the new value
                    UpdateFeasabilityInDatabase(id, DataGridViewFeasibility.Columns[e.ColumnIndex].Name, cellText);
                }
            }else
            {
                MessageBox.Show("Error Editing Data");
            }
        }




        private void DataGridViewFeasibility_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the changed cell is in a yes/no column
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = DataGridViewFeasibility.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null)
                {
                    string cellText = cell.Value.ToString().Trim().ToLower();
                    if (cellText == "yes")
                    {
                        cell.Style.BackColor = System.Drawing.Color.LightGreen;
                        cell.Style.ForeColor = System.Drawing.Color.Black;
                    }
                    else if (cellText == "no")
                    {
                        cell.Style.BackColor = System.Drawing.Color.Red;
                        cell.Style.ForeColor = System.Drawing.Color.White;
                    }
                }
            }
        }


        private void ColorYesNoCells()
        {
            // Define columns to target based on the DataGridView column names
            string[] yesNoColumns = { "Integration", "board_availability", "holders_board", "holders_eol", "programme", "serial_board_integration", "workplace_integration" };

            foreach (DataGridViewRow row in DataGridViewFeasibility.Rows)
            {
                foreach (string colName in yesNoColumns)
                {
                    // Only apply color if the cell is in the target column
                    var cell = row.Cells[colName];
                    if (cell.Value != null)
                    {
                        string cellText = cell.Value.ToString().Trim().ToLower();

                        if (cellText == "yes")
                        {
                            cell.Style.BackColor = System.Drawing.Color.LightGreen;
                            cell.Style.ForeColor = System.Drawing.Color.Black;
                        }
                        else if (cellText == "no")
                        {
                            cell.Style.BackColor = System.Drawing.Color.Red;
                            cell.Style.ForeColor = System.Drawing.Color.White;
                        }
                    }
                }
            }
        }




        private void FeasabilityBoards_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'boardDBDataSet.Feasibility'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.feasibilityTableAdapter.Fill(this.boardDBDataSet.Feasibility);


            ColorYesNoCells();


            // Set the DataGridView to allow user to delete rows
            DataGridViewFeasibility.AllowUserToDeleteRows = true;

            // Add a button column for deleting rows
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();

            deleteButtonColumn.HeaderText = "Delete";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            deleteButtonColumn.Name = "Delete";
            deleteButtonColumn.Width = 50; // Set the width of the button column
            deleteButtonColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Center the button
            DataGridViewFeasibility.Columns.Add(deleteButtonColumn);

            // Style the button column
            deleteButtonColumn.DefaultCellStyle.BackColor = Color.Red;
            deleteButtonColumn.DefaultCellStyle.ForeColor = Color.White;
            deleteButtonColumn.DefaultCellStyle.Font = new Font(DataGridViewFeasibility.Font, FontStyle.Bold);
            deleteButtonColumn.HeaderCell.Style.BackColor = Color.Red;
            deleteButtonColumn.HeaderCell.Style.ForeColor = Color.White;
            deleteButtonColumn.HeaderCell.Style.Font = new Font(DataGridViewFeasibility.Font, FontStyle.Bold);
            deleteButtonColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }



        private void button1_Click(object sender, EventArgs e)
        {
            Feasability.AddFormFeasabilty addFormFeasabilty = new Feasability.AddFormFeasabilty();
            if (addFormFeasabilty.ShowDialog() == DialogResult.OK)
            {
                // Refresh the DataGridView after adding a new record
                this.feasibilityTableAdapter.Fill(this.boardDBDataSet.Feasibility);
                ColorYesNoCells();
            }

        }
    }
}
