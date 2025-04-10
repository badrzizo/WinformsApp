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
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Colors;
using iText.Layout.Properties;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Exceptions;

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

            // Query to get the total number of roadblocks for each status (Open, Closed, Ongoing)
            string countQuery = @"
        SELECT 
            SUM(CASE WHEN r.status = 'Open' THEN 1 ELSE 0 END) AS OpenCount,
            SUM(CASE WHEN r.status = 'Closed' THEN 1 ELSE 0 END) AS ClosedCount,
            SUM(CASE WHEN r.status = 'Ongoing' THEN 1 ELSE 0 END) AS OngoingCount
        FROM Roadblocks r;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(countQuery, conn);
                    DataTable countTable = new DataTable();
                    dataAdapter.Fill(countTable);

                    // Get the counts from the result
                    int openCount = Convert.ToInt32(countTable.Rows[0]["OpenCount"]);
                    int closedCount = Convert.ToInt32(countTable.Rows[0]["ClosedCount"]);
                    int ongoingCount = Convert.ToInt32(countTable.Rows[0]["OngoingCount"]);

                    // Update labels with the respective counts
                    label6.Text = $"Open: {openCount}";
                    label5.Text = $"Closed: {closedCount}";
                    label4.Text = $"Ongoing: {ongoingCount}";

                    // Now execute the original query for fetching the roadblocks data
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

                    SqlDataAdapter dataAdapter2 = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter2.Fill(dataTable);

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

                    // Set the header column color after the DataGridView is populated
                    SetColumnHeaderStyle();


                    dataGridView1.Refresh();

                    // Attach the CellFormatting event handler
                    dataGridView1.CellFormatting += DataGridView1_CellFormatting;

                    // Allow editing on the required columns
                    dataGridView1.Columns["status"].ReadOnly = false; // Allow editing on status column
                    dataGridView1.Columns["issues"].ReadOnly = false; // Allow editing on issues column
                    dataGridView1.Columns["actions"].ReadOnly = false; // Allow editing on actions column
                    dataGridView1.Columns["owner"].ReadOnly = false; // Allow editing on owner column
                    dataGridView1.Columns["due_date"].ReadOnly = false; // Allow editing on due date column

                    // Handle the CellValueChanged event to update the database when a value is modified
                    dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void SetColumnHeaderStyle()
        {
            // Disable default visual styles to allow custom styling
            dataGridView1.EnableHeadersVisualStyles = false;

            // Create a style for the column headers
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle()
            {
                BackColor = System.Drawing.Color.Blue,               // Header background color
                ForeColor = System.Drawing.Color.White,             // Header text color
                Font = new Font("Arial", 10, FontStyle.Bold),  // Font style
                Alignment = DataGridViewContentAlignment.MiddleCenter  // Text alignment
            };

            // Apply the style to all column headers
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style = headerStyle;
            }

            // Optional: Set the height of the header row
            dataGridView1.ColumnHeadersHeight = 35;

            // Refresh to apply changes
            dataGridView1.Refresh();
        }



        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the edited column is one that requires an update
            if (e.RowIndex >= 0)
            {
                // Get the updated values
                var updatedId = dataGridView1.Rows[e.RowIndex].Cells["id"].Value;
                var updatedStatus = dataGridView1.Rows[e.RowIndex].Cells["status"].Value.ToString();
                var updatedIssues = dataGridView1.Rows[e.RowIndex].Cells["issues"].Value.ToString();
                var updatedActions = dataGridView1.Rows[e.RowIndex].Cells["actions"].Value.ToString();
                var updatedOwner = dataGridView1.Rows[e.RowIndex].Cells["owner"].Value.ToString();
                var updatedDueDate = dataGridView1.Rows[e.RowIndex].Cells["due_date"].Value.ToString();

                // Call a method to update the database
                UpdateRoadblockInDatabase(updatedId, updatedStatus, updatedIssues, updatedActions, updatedOwner, updatedDueDate);

                // After updating the roadblock, reload the count
                UpdateCounts();
            }
        }

        private void UpdateCounts()
        {
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";

            // Query to get the total number of roadblocks for each status (Open, Closed, Ongoing)
            string countQuery = @"
        SELECT 
            SUM(CASE WHEN r.status = 'Open' THEN 1 ELSE 0 END) AS OpenCount,
            SUM(CASE WHEN r.status = 'Closed' THEN 1 ELSE 0 END) AS ClosedCount,
            SUM(CASE WHEN r.status = 'Ongoing' THEN 1 ELSE 0 END) AS OngoingCount
        FROM Roadblocks r;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(countQuery, conn);
                    DataTable countTable = new DataTable();
                    dataAdapter.Fill(countTable);

                    // Get the counts from the result
                    int openCount = Convert.ToInt32(countTable.Rows[0]["OpenCount"]);
                    int closedCount = Convert.ToInt32(countTable.Rows[0]["ClosedCount"]);
                    int ongoingCount = Convert.ToInt32(countTable.Rows[0]["OngoingCount"]);

                    // Update labels with the respective counts
                    label6.Text = $"Open: {openCount}";
                    label5.Text = $"Closed: {closedCount}";
                    label4.Text = $"Ongoing: {ongoingCount}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void UpdateRoadblockInDatabase(object updatedId, string updatedStatus, string updatedIssues, string updatedActions, string updatedOwner, string updatedDueDate)
        {
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string updateQuery = @"
                UPDATE Roadblocks 
                SET status = @Status, 
                    issues = @Issues, 
                    actions = @Actions, 
                    owner = @Owner, 
                    due_date = @DueDate
                WHERE id = @Id";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", updatedId);
                        cmd.Parameters.AddWithValue("@Status", updatedStatus);
                        cmd.Parameters.AddWithValue("@Issues", updatedIssues);
                        cmd.Parameters.AddWithValue("@Actions", updatedActions);
                        cmd.Parameters.AddWithValue("@Owner", updatedOwner);
                        cmd.Parameters.AddWithValue("@DueDate", updatedDueDate);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    e.CellStyle.BackColor = System.Drawing.Color.Red;
                    e.CellStyle.ForeColor = System.Drawing.Color.White;
                }
                else if (e.Value != null && e.Value.ToString() == "Closed")
                {
                    e.CellStyle.BackColor = System.Drawing.Color.Green;
                    e.CellStyle.ForeColor = System.Drawing.Color.White;
                }
                else if(e.Value != null && e.Value.ToString() == "Ongoing")
                {
                    e.CellStyle.BackColor = System.Drawing.Color.Orange;
                    e.CellStyle.ForeColor = System.Drawing.Color.Black;
                }
            }

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style.BackColor = System.Drawing.Color.Blue;
                column.HeaderCell.Style.ForeColor = System.Drawing.Color.White;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            RoadsBlock.AddingPointsForm addingPointsForm = new RoadsBlock.AddingPointsForm();
            if (addingPointsForm.ShowDialog() == DialogResult.OK)
            {
                // Reload the data when the adding form closes successfully
                RoadBlockBoards_Load1(this, EventArgs.Empty);
            }
        }

        private void DownloadPDF_Click(object sender, EventArgs e)
        {
            // Configure save file dialog
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveDialog.Title = "Export Roadblocks to PDF";
                saveDialog.FileName = $"Roadblocks_Export_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Initialize PDF writer with error handling
                        using (PdfWriter writer = new PdfWriter(saveDialog.FileName))
                        using (PdfDocument pdfDoc = new PdfDocument(writer))
                        using (Document document = new Document(pdfDoc))
                        {
                            // Add report title
                            document.Add(new Paragraph("ROADBLOCKS REPORT")
                                .SetTextAlignment(TextAlignment.CENTER)
                                .SetFontSize(18)
                                .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)));

                            // Add report date
                            document.Add(new Paragraph($"Generated: {DateTime.Now.ToString("yyyy-MM-dd HH:mm")}")
                                .SetTextAlignment(TextAlignment.CENTER)
                                .SetFontSize(10)
                                .SetMarginBottom(15));

                            // Create data table
                            Table table = new Table(dataGridView1.Columns.Count)
                                .UseAllAvailableWidth()
                                .SetMarginTop(10);

                            // Add column headers
                            foreach (DataGridViewColumn col in dataGridView1.Columns)
                            {
                                if (col.Visible)
                                {
                                    table.AddHeaderCell(new Cell()
                                        .Add(new Paragraph(col.HeaderText))
                                        .SetBackgroundColor(new DeviceRgb(0, 0, 139)) // Dark blue
                                        .SetFontColor(DeviceRgb.WHITE)
                                        .SetFontSize(10)
                                        .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD))
                                        .SetTextAlignment(TextAlignment.CENTER));
                                }
                            }

                            // Add data rows
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        if (cell.OwningColumn.Visible)
                                        {
                                            var cellValue = cell.Value?.ToString() ?? string.Empty;
                                            var pdfCell = new Cell()
                                                .Add(new Paragraph(cellValue))
                                                .SetPadding(5)
                                                .SetTextAlignment(TextAlignment.LEFT);

                                            // Apply status colors
                                            if (cell.OwningColumn.Name == "status")
                                            {
                                                switch (cellValue.ToUpper())
                                                {
                                                    case "OPEN":
                                                        pdfCell.SetBackgroundColor(new DeviceRgb(220, 20, 60)) // Crimson
                                                            .SetFontColor(DeviceRgb.WHITE);
                                                        break;
                                                    case "CLOSED":
                                                        pdfCell.SetBackgroundColor(new DeviceRgb(50, 205, 50)) // LimeGreen
                                                            .SetFontColor(DeviceRgb.WHITE);
                                                        break;
                                                    case "ONGOING":
                                                        pdfCell.SetBackgroundColor(new DeviceRgb(255, 165, 0)); // Orange
                                                break;
                                                }
                                            }

                                            table.AddCell(pdfCell);
                                        }
                                    }
                                }
                            }

                            document.Add(table);
                        }

                        MessageBox.Show("PDF exported successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (PdfException pdfEx)
                    {
                        MessageBox.Show($"PDF Generation Error: {pdfEx.Message}\n\n" +
                            "Please ensure:\n" +
                            "1. The file isn't already open in another program\n" +
                            "2. You have write permissions to the location\n" +
                            "3. There's enough disk space",
                            "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Unexpected Error: {ex.Message}",
                            "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }




        private void comboBoxProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reload data with updated filter
            RoadBlockBoards_Load1(this, EventArgs.Empty);
        }

        private void comboBoxFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reload data with updated filter
            RoadBlockBoards_Load1(this, EventArgs.Empty);
        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reload data with updated filter
            RoadBlockBoards_Load1(this, EventArgs.Empty);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
