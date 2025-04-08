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
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Dashboard - Boards App";
            this.WindowState = FormWindowState.Maximized;
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
            string connectionString = "Server=localhost;Database=master;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                SELECT dpt_id, COUNT(*) AS OpenPoints
                FROM Roadblocks
                WHERE status = 'Open'
                GROUP BY dpt_id
                ORDER BY OpenPoints DESC";// Sort by open points

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dataTable);
                }
                return dataTable;
            }
        }

        private DataTable GetOpenPointByFamily()
        {
            DataTable dataTable = new DataTable();
            string connectionString = "Server=localhost;Database=master;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                SELECT fam_id, COUNT(*) AS OpenPoints
                FROM Roadblocks
                WHERE status = 'Open'
                GROUP BY fam_id
                ORDER BY OpenPoints DESC";


                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dataTable);
                }
                return dataTable;

            }
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
                string department = row["dpt_id"].ToString();
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
            chart2.ChartAreas[0].AxisX.Title = "Fam";
            chart2.ChartAreas[0].AxisY.Title = "Open Issues";

            // Create new series
            Series series = new Series("Open Points By Fam");
            series.ChartType = SeriesChartType.Column; // Bar Chart

            // Set color for the series
            series.Color = Color.SeaGreen; // Change to any color you prefer

            foreach (DataRow row in dataTable.Rows)
            {
                string fam = row["fam"].ToString();
                int count = Convert.ToInt32(row["OpenPoints"]);
                series.Points.AddXY(fam, count);
            }

            chart2.Series.Add(series);
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

            chart.Series[0].IsValueShownAsLabel = true;
            chart.Series[0].LabelForeColor = Color.Black;
            chart.Series[0].Font = new Font("Arial", 10, FontStyle.Bold);
            chart.Series[0]["PieLabelStyle"] = "Outside";

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
