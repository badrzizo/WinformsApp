using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Collections.Generic;
using PdfSharp.Drawing;



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

            if (!dataGridView1.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.Name = "Delete";  // Make sure the column name is "Delete"
                deleteButtonColumn.HeaderText = "Delete";
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(deleteButtonColumn);
            }

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
                    dataGridView1.Columns["issues"].Width = 300;
                    dataGridView1.Columns["actions"].Width = 300;
                    dataGridView1.Columns["owner"].Width = 100;
                    dataGridView1.Columns["due_date"].Width = 100;

                    
                    dataGridView1.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;
                    dataGridView1.Columns["Delete"].DefaultCellStyle.ForeColor = Color.White;
                    
                    
                    // Reorder columns if needed
                    dataGridView1.Columns["project_name"].DisplayIndex = 0;
                    dataGridView1.Columns["family_name"].DisplayIndex = 1;
                    dataGridView1.Columns["departement_name"].DisplayIndex = 2;
                    dataGridView1.Columns["status"].DisplayIndex = 7;
                    dataGridView1.Columns["issues"].DisplayIndex = 3;
                    dataGridView1.Columns["actions"].DisplayIndex = 4;
                    dataGridView1.Columns["owner"].DisplayIndex = 5;
                    dataGridView1.Columns["due_date"].DisplayIndex = 6;
                    dataGridView1.Columns["Delete"].DisplayIndex = 8;
                    
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

                    SetDataGridViewStyles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        private void DeleteRoadblockFromDatabase(int idToDelete)
        {
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";

            try
            {
                // Establish connection with the database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Query to delete the record
                    string deleteQuery = "DELETE FROM Roadblocks WHERE id = @Id";

                    // Execute the delete command
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", idToDelete);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors during the database operation
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void SetColumnHeaderStyle()
        {
            // Disable default visual styles to allow custom styling
            dataGridView1.EnableHeadersVisualStyles = false;

            // Create a style for the column headers
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle()
            {
                BackColor = System.Drawing.Color.Blue,// Header background color
                ForeColor = System.Drawing.Color.White,// Header text color
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
            dataGridView1.AllowUserToOrderColumns = true;

            // Refresh to apply changes
            dataGridView1.Refresh();
        }

        private void SetDataGridViewStyles()
        {
            // Disable default visual styles to allow full customization
            dataGridView1.EnableHeadersVisualStyles = false;

            // Set basic grid properties
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.FromArgb(240, 240, 240);
            dataGridView1.BackgroundColor = Color.White;

            // Set default cell style
            dataGridView1.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(64, 64, 64),
                Font = new Font("Segoe UI", 9),
                SelectionBackColor = Color.FromArgb(0, 120, 215),
                SelectionForeColor = Color.White,
                Padding = new Padding(3),
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };

            // Set alternating row colors
            dataGridView1.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(248, 248, 248),
                ForeColor = Color.FromArgb(64, 64, 64)
            };

            // Set column header style
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(0, 114, 198),
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Padding = new Padding(5, 5, 5, 5)
            };
            dataGridView1.ColumnHeadersDefaultCellStyle = headerStyle;
            dataGridView1.ColumnHeadersHeight = 35;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Set row headers style (if visible)
            dataGridView1.RowHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = SystemColors.ControlText,
                Font = new Font("Segoe UI", 8)
            };

            // Set row height and selection mode
            dataGridView1.RowTemplate.Height = 28;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeRows = false;

            // Customize the Delete button column
            if (dataGridView1.Columns.Contains("Delete"))
            {
                dataGridView1.Columns["Delete"].DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(220, 53, 69),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                };
            }

            // Apply custom formatting to specific columns
            dataGridView1.Columns["due_date"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["due_date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            // Ensure the Delete button column doesn't grow too much
            if (dataGridView1.Columns.Contains("Delete"))
            {
                dataGridView1.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns["Delete"].Width = 80;
            }
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

        private void ExportDataGridViewToPdf_PdfSharp(DataGridView dgv, string filePath)
        {
            try
            {
                using (PdfSharp.Pdf.PdfDocument pdf = new PdfSharp.Pdf.PdfDocument())
                {
                    PdfSharp.Pdf.PdfPage page = pdf.AddPage();
                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    XFont headerFont = new XFont("Arial", 12, XFontStyleEx.Bold);
                    XFont cellFont = new XFont("Arial", 10);

                    // Reorder columns in the same order as DisplayIndex
                    var columnsInOrder = new List<DataGridViewColumn>();
                    columnsInOrder.Add(dgv.Columns["project_name"]);
                    columnsInOrder.Add(dgv.Columns["family_name"]);
                    columnsInOrder.Add(dgv.Columns["departement_name"]);
                    columnsInOrder.Add(dgv.Columns["issues"]);
                    columnsInOrder.Add(dgv.Columns["actions"]);
                    columnsInOrder.Add(dgv.Columns["owner"]);
                    columnsInOrder.Add(dgv.Columns["due_date"]);
                    columnsInOrder.Add(dgv.Columns["status"]);

                    float x = 20;
                    float y = 50;
                    float cellHeight = 20;
                    float totalWidth = 0;
                    Dictionary<string, float> columnWidths = new Dictionary<string, float>();

                    // Calculate column widths
                    foreach (var column in columnsInOrder)
                    {
                        if (!column.Visible) continue;
                        float width = (float)(gfx.MeasureString(column.HeaderText, headerFont).Width + 10);
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (row.IsNewRow) continue;
                            string cellValue = row.Cells[column.Name].Value?.ToString() ?? "";
                            float cellWidth = (float)(gfx.MeasureString(cellValue, cellFont).Width + 10);
                            width = Math.Max(width, cellWidth);
                        }
                        columnWidths[column.Name] = width;
                        totalWidth += width;
                    }

                    // Adjust page width if needed
                    if (totalWidth > page.Width - 50)
                    {
                        // Handle case where content is wider than the page (e.g., scale or adjust font)
                        MessageBox.Show("Data width exceeds page width. PDF output may be truncated.");
                    }

                    // Draw headers
                    foreach (var column in columnsInOrder)
                    {
                        if (!column.Visible) continue;
                        XBrush headerBrush = XBrushes.Blue;
                        gfx.DrawRectangle(headerBrush, x, y, columnWidths[column.Name], cellHeight);
                        gfx.DrawString(column.HeaderText, headerFont, XBrushes.White, new XRect(x, y, columnWidths[column.Name], cellHeight), XStringFormats.Center);
                        x += columnWidths[column.Name];
                    }

                    y += cellHeight;
                    x = 20;

                    // Draw data
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.IsNewRow) continue;
                        x = 20;
                        foreach (var column in columnsInOrder)
                        {
                            if (!column.Visible) continue;
                            string cellValue = row.Cells[column.Name].Value?.ToString() ?? "";
                            XBrush cellBrush = XBrushes.Black; // Default brush

                            // Apply color based on "status" column
                            if (column.Name == "status")
                            {
                                if (cellValue == "Open") cellBrush = XBrushes.Red;
                                else if (cellValue == "Closed") cellBrush = XBrushes.Green;
                                else if (cellValue == "Ongoing") cellBrush = XBrushes.Orange;
                            }

                            gfx.DrawString(cellValue, cellFont, cellBrush, new XRect(x, y, columnWidths[column.Name], cellHeight), XStringFormats.Center);
                            x += columnWidths[column.Name];
                        }
                        y += cellHeight;

                        // Add new page if needed
                        if (y > page.Height - 50)
                        {
                            page = pdf.AddPage();
                            gfx = XGraphics.FromPdfPage(page);
                            y = 50; // Reset y for new page
                            x = 20;
                            // Redraw headers on new page
                            foreach (var column in columnsInOrder)
                            {
                                if (!column.Visible) continue;
                                XBrush headerBrush = XBrushes.Blue;
                                gfx.DrawRectangle(headerBrush, x, y - cellHeight, columnWidths[column.Name], cellHeight);
                                gfx.DrawString(column.HeaderText, headerFont, XBrushes.White, new XRect(x, y - cellHeight, columnWidths[column.Name], cellHeight), XStringFormats.Center);
                                x += columnWidths[column.Name];
                            }
                            y += cellHeight;
                        }
                    }

                    pdf.Save(filePath);
                    MessageBox.Show($"PDF file saved successfully at:\n{filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to export PDF:\n" + ex.Message);
            }
        }

        private void DownloadPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveFileDialog.FileName = $"Roadblocks_Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            saveFileDialog.Title = "Save PDF File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportDataGridViewToPdf_PdfSharp(dataGridView1, saveFileDialog.FileName);
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

        private void ExportDataGridViewToExcel(DataGridView dgv)
        {
            using (XLWorkbook workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Roadblocks");

                // Reorder columns in the same order as DisplayIndex
                var columnsInOrder = new List<DataGridViewColumn>();
                columnsInOrder.Add(dgv.Columns["project_name"]);
                columnsInOrder.Add(dgv.Columns["family_name"]);
                columnsInOrder.Add(dgv.Columns["departement_name"]);
                columnsInOrder.Add(dgv.Columns["issues"]);
                columnsInOrder.Add(dgv.Columns["actions"]);
                columnsInOrder.Add(dgv.Columns["owner"]);
                columnsInOrder.Add(dgv.Columns["due_date"]);
                columnsInOrder.Add(dgv.Columns["status"]);

                // Adding headers with custom styles
                int colIndex = 1;
                foreach (var column in columnsInOrder)
                {
                    if (!column.Visible) continue;

                    var headerCell = worksheet.Cell(1, colIndex);
                    headerCell.Value = column.HeaderText;
                    headerCell.Style.Font.Bold = true;
                    headerCell.Style.Fill.BackgroundColor = XLColor.Blue;
                    headerCell.Style.Font.FontColor = XLColor.White;
                    headerCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    headerCell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    headerCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    colIndex++;
                }

                // Adding data with formatting
                int rowIndex = 2;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;

                    colIndex = 1;
                    foreach (var column in columnsInOrder)
                    {
                        if (!column.Visible) continue;

                        var cellValue = row.Cells[column.Name].Value?.ToString() ?? "";
                        var excelCell = worksheet.Cell(rowIndex, colIndex);
                        excelCell.Value = cellValue;

                        // Apply background color and text color based on the DataGridView cell styles
                        var cellStyle = row.Cells[column.Name].Style;
                        if (column.Name == "status") // Example: Apply different formatting to the "status" column
                        {
                            if (cellValue == "Open")
                            {
                                excelCell.Style.Fill.BackgroundColor = XLColor.Red;
                                excelCell.Style.Font.FontColor = XLColor.White;
                            }
                            else if (cellValue == "Closed")
                            {
                                excelCell.Style.Fill.BackgroundColor = XLColor.Green;
                                excelCell.Style.Font.FontColor = XLColor.White;
                            }
                            else if (cellValue == "Ongoing")
                            {
                                excelCell.Style.Fill.BackgroundColor = XLColor.Orange;
                                excelCell.Style.Font.FontColor = XLColor.Black;
                            }
                        }

                        // Apply text alignment from DataGridView style
                        excelCell.Style.Alignment.Horizontal = (cellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter) ?
                                                                XLAlignmentHorizontalValues.Center : XLAlignmentHorizontalValues.Left;

                        excelCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        colIndex++;
                    }
                    rowIndex++;
                }

                // Auto-fit columns and save the file
                worksheet.Columns().AdjustToContents();

                // Save the file
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Roadblocks_Report_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
                workbook.SaveAs(filePath);
                MessageBox.Show($"Excel file saved successfully at:\n{filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void buttonDownloadExcel_Click(object sender, EventArgs e)
        {

            try
            {
                ExportDataGridViewToExcel(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to export Excel:\n" + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked column is the "Delete" button
            // Ensure that column exists before accessing it
            if (e.ColumnIndex >= 0 && dataGridView1.Columns.Contains("Delete") &&
                e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                // Get the "ID" value of the row clicked (make sure the 'id' column exists)
                var idCell = dataGridView1.Rows[e.RowIndex].Cells["id"];
                if (idCell != null && idCell.Value != DBNull.Value)
                {
                    int idToDelete = Convert.ToInt32(idCell.Value);

                    // Ask for confirmation before deletion
                    if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Call the method to delete from the database
                        DeleteRoadblockFromDatabase(idToDelete);

                        // Reload data after deletion
                        RoadBlockBoards_Load1(this, EventArgs.Empty);
                        UpdateCounts();
                    }
                }
                else
                {
                    MessageBox.Show("ID not found in the row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid column or row clicked.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
