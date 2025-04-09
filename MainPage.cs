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
using System.Windows.Forms.DataVisualization.Charting;
using WinFormsApp.Feasability;
using WinFormsApp.MileStone;
using WinFormsApp.RoadsBlock;

namespace WinFormsApp
{
    public partial class MainPage: Form
    {
        public MainPage()
        {
            InitializeComponent();

            

            LoadChart1();
            LoadChart2();
            LoadChart3();
            LoadPieChart(chart4, GetOpenVsClosedPoints(), "Open vs Closed Points", "Open vs Closed");
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Dashboard - Boards App";
            this.WindowState = FormWindowState.Maximized;

            // Create a TableLayoutPanel with 2 rows and 2 columns
            TableLayoutPanel layoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill, // Make the TableLayoutPanel fill the form
                RowCount = 2,
                ColumnCount = 2
            };

            // Adjust the sizes for the rows and columns
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            // Add the charts to the TableLayoutPanel
            layoutPanel.Controls.Add(chart1, 0, 0); // Add chart1 to the top-left cell
            layoutPanel.Controls.Add(chart2, 1, 0); // Add chart2 to the top-right cell
            layoutPanel.Controls.Add(chart3, 0, 1); // Add chart3 to the bottom-left cell
            layoutPanel.Controls.Add(chart4, 1, 1); // Add chart4 to the bottom-right cell

            // Set each chart to fill its assigned cell
            chart1.Dock = DockStyle.Fill;
            chart2.Dock = DockStyle.Fill;
            chart3.Dock = DockStyle.Fill;
            chart4.Dock = DockStyle.Fill;

            // Add the layout panel to the form
            this.Controls.Add(layoutPanel);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FeasabilityBoards feasabilityBoards = new FeasabilityBoards();
            feasabilityBoards.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RoadBlockBoards roadBlockBoards = new RoadBlockBoards();
            roadBlockBoards.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MileStoneBoards mileStoneBoards = new MileStoneBoards();
            mileStoneBoards.Show();
        }


        private DataTable GetOpenPointsByDepartment()
        {
            DataTable dataTable = new DataTable();
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT d.departement_name, COUNT(*) AS OpenPoints
            FROM Roadblocks r
            JOIN Department d ON r.dpt_id = d.id
            WHERE r.status = 'Open'
            GROUP BY d.departement_name
            ORDER BY OpenPoints DESC"; // Sort by open points

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }



        private DataTable GetOpenPointByFamily()
        {
            DataTable dataTable = new DataTable();
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT f.family_name, COUNT(*) AS OpenPoints
            FROM Roadblocks r
            JOIN Family f ON r.fam_id = f.id
            WHERE r.status = 'Open'
            GROUP BY f.family_name
            ORDER BY OpenPoints DESC"; // Sort by open points

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        private DataTable GetOpenPointByProject()
        {
            DataTable dataTable = new DataTable();
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT p.project_name, COUNT(*) AS OpenPoints
            FROM Roadblocks r
            JOIN Project p ON r.project_id = p.id
            WHERE r.status = 'Open'
            GROUP BY p.project_name
            ORDER BY OpenPoints DESC"; // Sort by open points
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        private DataTable GetOpenVsClosedPoints()
        {
            DataTable dataTable = new DataTable();
            string connectionString = "Server=localhost;Database=BoardDB;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT r.status, COUNT(*) AS OpenPoints
            FROM Roadblocks r
            WHERE r.status IN ('Open', 'Closed')
            GROUP BY r.status";
            
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }


        private void LoadChart1()
        {
            DataTable dataTable = GetOpenPointsByDepartment();

            chart1.Series.Clear();

            LoadBarChart(chart1, dataTable, "Departement", "Open Issues", "Open Points By Department", Color.CornflowerBlue, Color.LightBlue);
            ConfigureChart(chart1);

            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "Department";
            chart1.ChartAreas[0].AxisY.Title = "Open Issues";

            Series series = new Series("Open Points By Dpt");
            series.ChartType = SeriesChartType.Column;

            series.Color = Color.CornflowerBlue;

            series.Color = Color.CornflowerBlue;

            foreach (DataRow row in dataTable.Rows)
            {
                string department = row["departement_name"].ToString();
                int count = Convert.ToInt32(row["OpenPoints"]);
                series.Points.AddXY(department, count);
            }

            chart1.Series.Add(series);
        }

        private void LoadChart2()
        {
            DataTable dataTable = GetOpenPointByFamily();
            chart2.Series.Clear();

            LoadBarChart(chart2, dataTable, "Family", "Open Issues", "Open Points By Fam", Color.SeaGreen, Color.LightGreen);
            ConfigureChart(chart2);

            chart2.Series.Clear();
            chart2.ChartAreas[0].AxisX.Title = "Family";
            chart2.ChartAreas[0].AxisY.Title = "Open Issues";

            // Create new series
            Series series = new Series("Open Points By Family");
            series.ChartType = SeriesChartType.Column; // Bar Chart

            // Set color for the series
            series.Color = Color.SeaGreen; // Change to any color you prefer

            foreach (DataRow row in dataTable.Rows)
            {
                string fam = row["family_name"].ToString();
                int count = Convert.ToInt32(row["OpenPoints"]);
                series.Points.AddXY(fam, count);
            }

            chart2.Series.Add(series);
        }

        private void LoadChart3()
        {
            DataTable dataTable = GetOpenPointByProject();
            chart3.Series.Clear();
            LoadBarChart(chart3, dataTable, "Project", "Open Issues", "Open Points By Project", Color.Red, Color.Green);
            ConfigureChart(chart3);
            chart3.Series.Clear();
            chart3.ChartAreas[0].AxisX.Title = "Project";
            chart3.ChartAreas[0].AxisY.Title = "Open Issues";
            // Create new series
            Series series = new Series("Open Points By Project");
            series.ChartType = SeriesChartType.Column; // Bar Chart
            // Set color for the series
            series.Color = Color.OrangeRed; // Change to any color you prefer
            foreach (DataRow row in dataTable.Rows)
            {
                string project = row["project_name"].ToString();
                int count = Convert.ToInt32(row["OpenPoints"]);
                series.Points.AddXY(project, count);
            }
            chart3.Series.Add(series);
        }

        private void LoadPieChart(Chart chart, DataTable dt, string title, string seriesName)
        {
            chart.Series.Clear();
            chart.Titles.Clear();
            chart.Titles.Add(title);
            chart.Legends.Clear();

            // Set chart type to doughnut
            Series series = new Series(seriesName)
            {
                ChartType = SeriesChartType.Doughnut, // Use Doughnut chart
                BackGradientStyle = GradientStyle.TopBottom,
                BorderWidth = 3,
                BorderColor = Color.White // Add a white border between slices
            };

            // Add data points to the series
            foreach (DataRow row in dt.Rows)
            {
                string category = row[0].ToString();
                int count = Convert.ToInt32(row[1]);

                // Assign colors based on the category (Open = Red, Closed = Green)
                if (category == "Open")
                {
                    series.Points.AddXY(category, count);
                    series.Points[series.Points.Count - 1].Color = Color.Red; // Open = Red
                }
                else if (category == "Closed")
                {
                    series.Points.AddXY(category, count);
                    series.Points[series.Points.Count - 1].Color = Color.Green; // Closed = Green
                }
            }

            // Add the series to the chart
            chart.Series.Add(series);

            // Show percentage labels on slices
            series.IsValueShownAsLabel = true;
            series.LabelForeColor = Color.Black;

            // Customize the chart's appearance
            ConfigurePieChart(chart);
        }

        private void LoadBarChart(Chart chart, DataTable dt, string xTitle, string yTitle, string seriesName, Color startColor, Color endColor)
        {
            chart.Series.Clear();
            chart.ChartAreas[0].AxisX.Title = xTitle;
            chart.ChartAreas[0].AxisY.Title = yTitle;

            Series series = new Series(seriesName)
            {
                ChartType = SeriesChartType.Column,
                Color = startColor,
                BackGradientStyle = GradientStyle.TopBottom,
                BackSecondaryColor = endColor
            };

            foreach (DataRow row in dt.Rows)
            {
                string category = row[0].ToString();
                int count = Convert.ToInt32(row[1]);
                series.Points.AddXY(category, count);
            }

            chart.Series.Add(series);
            chart.ChartAreas[0].AxisY.Interval = 1;
            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].RecalculateAxesScale();
        }

        private void ConfigureChart(Chart chart)
        {
            // General Chart Appearance
            chart.BackColor = Color.WhiteSmoke;
            chart.ChartAreas[0].BackColor = Color.White;

            // Make the chart fill the available space in its container
            chart.Dock = DockStyle.Fill; // This will make the chart fill its parent container

            // Border Styling
            chart.ChartAreas[0].BorderDashStyle = ChartDashStyle.Solid;
            chart.ChartAreas[0].BorderWidth = 1;
            chart.ChartAreas[0].BorderColor = Color.LightGray;
            chart.ChartAreas[0].ShadowColor = Color.Gray;
            chart.ChartAreas[0].ShadowOffset = 3;

            // Grid Styling
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            chart.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;

            // Axis Label Colors
            chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.DarkSlateGray;
            chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.DarkSlateGray;

            // Axis Titles
            chart.ChartAreas[0].AxisX.TitleForeColor = Color.Black;
            chart.ChartAreas[0].AxisY.TitleForeColor = Color.Black;
            chart.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 10, FontStyle.Bold);
            chart.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 10, FontStyle.Bold);

            // Legend Styling
            chart.Legends.Clear();
            Legend legend = new Legend
            {
                BackColor = Color.Transparent,
                ForeColor = Color.DarkSlateGray,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            chart.Legends.Add(legend);
        }

        private void ConfigurePieChart(Chart chart)
        {
            chart.BackColor = Color.WhiteSmoke;
            chart.ChartAreas[0].BackColor = Color.White;

            chart.ChartAreas[0].BorderDashStyle = ChartDashStyle.Solid;
            chart.ChartAreas[0].BorderWidth = 1;
            chart.ChartAreas[0].BorderColor = Color.LightGray;
            chart.ChartAreas[0].ShadowColor = Color.Gray;
            chart.ChartAreas[0].ShadowOffset = 3;

            // Set labels outside the pie chart
            chart.Series[0].IsValueShownAsLabel = true;
            chart.Series[0].LabelForeColor = Color.Black;
            chart.Series[0].Font = new Font("Arial", 10, FontStyle.Bold);
            chart.Series[0]["PieLabelStyle"] = "Outside";

            // Customize legend
            chart.Legends.Clear();
            Legend legend = new Legend
            {
                BackColor = Color.Transparent,
                ForeColor = Color.DarkSlateGray,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            chart.Legends.Add(legend);
        }
    }
}
