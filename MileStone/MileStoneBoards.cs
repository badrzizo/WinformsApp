using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace WinFormsApp.MileStone
{
    public partial class MileStoneBoards : Form
    {
        public MileStoneBoards()
        {
            InitializeComponent();
            // Configure DataGridView settings for better display
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog.Title = "Select Excel File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    LoadExcelToDataGridView(filePath);
                }
            }
        }

        private void LoadExcelToDataGridView(string filePath)
        {
            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    // Check if there are any worksheets
                    if (workbook.Worksheets.Count == 0)
                    {
                        MessageBox.Show("The Excel file contains no worksheets.");
                        return;
                    }

                    // Get the first worksheet (you could also let user choose which sheet to load)
                    var worksheet = workbook.Worksheet(1);

                    // Create DataTable from worksheet
                    DataTable dataTable = CreateDataTableFromWorksheet(worksheet);

                    // Bind to DataGridView
                    dataGridView1.DataSource = dataTable;

                    // Apply formatting
                    ApplyExcelFormatting(worksheet);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Excel file: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable CreateDataTableFromWorksheet(IXLWorksheet worksheet)
        {
            DataTable dataTable = new DataTable();

            // Get the first row for column names
            var firstRow = worksheet.FirstRowUsed();
            if (firstRow == null) return dataTable;

            // Add columns
            foreach (var cell in firstRow.CellsUsed())
            {
                string columnName = cell.Value.ToString();
                if (string.IsNullOrWhiteSpace(columnName))
                {
                    columnName = $"Column{cell.Address.ColumnNumber}";
                }

                // Handle duplicate column names
                string uniqueColumnName = columnName;
                int counter = 1;
                while (dataTable.Columns.Contains(uniqueColumnName))
                {
                    uniqueColumnName = $"{columnName}_{counter++}";
                }

                dataTable.Columns.Add(uniqueColumnName);
            }

            // Add data rows
            foreach (var row in worksheet.RowsUsed().Skip(1)) // Skip header row
            {
                DataRow dataRow = dataTable.NewRow();
                int columnIndex = 0;

                foreach (var cell in row.Cells(1, dataTable.Columns.Count))
                {
                    if (columnIndex >= dataTable.Columns.Count) break;

                    // Handle different data types more gracefully
                    if (cell.Value.IsBlank)
                    {
                        dataRow[columnIndex] = DBNull.Value;
                    }
                    else if (cell.DataType == XLDataType.DateTime)
                    {
                        dataRow[columnIndex] = cell.GetDateTime();
                    }
                    else if (cell.DataType == XLDataType.Number)
                    {
                        dataRow[columnIndex] = cell.GetDouble();
                    }
                    else if (cell.DataType == XLDataType.Boolean)
                    {
                        dataRow[columnIndex] = cell.GetBoolean();
                    }
                    else
                    {
                        dataRow[columnIndex] = cell.Value.ToString();
                    }
                    columnIndex++;
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }

        private void ApplyExcelFormatting(IXLWorksheet worksheet)
        {
            if (dataGridView1.Rows.Count == 0) return;

            // Only format used cells for better performance
            var usedRange = worksheet.RangeUsed();
            if (usedRange == null) return;

            int startRow = usedRange.FirstRow().RowNumber();
            int endRow = usedRange.LastRow().RowNumber();
            int startCol = usedRange.FirstColumn().ColumnNumber();
            int endCol = usedRange.LastColumn().ColumnNumber();

            // Adjust for DataGridView (0-based) vs Excel (1-based)
            for (int row = startRow; row <= endRow; row++)
            {
                // Skip header row if needed (depends on your DataTable creation)
                int dgvRowIndex = startRow;
                if (dgvRowIndex >= dataGridView1.Rows.Count) continue;

                for (int col = startCol; col <= endCol; col++)
                {
                    int dgvColIndex = col - startCol;
                    if (dgvColIndex >= dataGridView1.Columns.Count) continue;

                    try
                    {
                        var cell = worksheet.Cell(row, col);
                        var dgvCell = dataGridView1.Rows[dgvRowIndex].Cells[dgvColIndex];

                        // Apply background color if not default
                        if (cell.Style.Fill.BackgroundColor.ColorType != XLColorType.Color)
                        {
                            dgvCell.Style.BackColor = ToColor(cell.Style.Fill.BackgroundColor);
                        }

                        // Apply font styling
                        var font = new Font(
                            cell.Style.Font.FontName,
                            (float)cell.Style.Font.FontSize,
                            GetFontStyle(cell.Style.Font)
                        );
                        dgvCell.Style.Font = font;

                        // Apply font color if not default
                        if (cell.Style.Font.FontColor.ColorType != XLColorType.Color)
                        {
                            dgvCell.Style.ForeColor = ToColor(cell.Style.Font.FontColor);
                        }

                        // Apply alignment
                        dgvCell.Style.Alignment = ToDataGridViewAlignment(cell.Style.Alignment);
                    }
                    catch (Exception ex)
                    {
                        // Log error if needed
                        Debug.WriteLine($"Error formatting cell [{row},{col}]: {ex.Message}");
                    }
                }
            }
        }

        private DataGridViewContentAlignment ToDataGridViewAlignment(IXLAlignment excelAlignment)
        {
            if (excelAlignment.Horizontal == XLAlignmentHorizontalValues.Center)
            {
                return excelAlignment.Vertical == XLAlignmentVerticalValues.Top
                    ? DataGridViewContentAlignment.TopCenter
                    : excelAlignment.Vertical == XLAlignmentVerticalValues.Bottom
                        ? DataGridViewContentAlignment.BottomCenter
                        : DataGridViewContentAlignment.MiddleCenter;
            }
            else if (excelAlignment.Horizontal == XLAlignmentHorizontalValues.Right)
            {
                return excelAlignment.Vertical == XLAlignmentVerticalValues.Top
                    ? DataGridViewContentAlignment.TopRight
                    : excelAlignment.Vertical == XLAlignmentVerticalValues.Bottom
                        ? DataGridViewContentAlignment.BottomRight
                        : DataGridViewContentAlignment.MiddleRight;
            }
            else // Left or default
            {
                return excelAlignment.Vertical == XLAlignmentVerticalValues.Top
                    ? DataGridViewContentAlignment.TopLeft
                    : excelAlignment.Vertical == XLAlignmentVerticalValues.Bottom
                        ? DataGridViewContentAlignment.BottomLeft
                        : DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private Color ToColor(XLColor xlColor)
        {
            try
            {
                return Color.FromArgb(xlColor.Color.ToArgb());
            }
            catch
            {
                return Color.Empty;
            }
        }

        private FontStyle GetFontStyle(IXLFont font)
        {
            FontStyle style = FontStyle.Regular;
            if (font.Bold) style |= FontStyle.Bold;
            if (font.Italic) style |= FontStyle.Italic;
            if (font.Underline != XLFontUnderlineValues.None) style |= FontStyle.Underline;
            return style;
        }
    }
}