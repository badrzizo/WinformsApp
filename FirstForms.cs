using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.Feasability;
using WinFormsApp.MileStone;
using WinFormsApp.RoadsBlock;

namespace WinFormsApp
{
    public partial class FirstForms: Form
    {
        public FirstForms()
        {
            InitializeComponent();
            SetupButtonsUI();
        }

        private void SetupButtonsUI()
        {
            // Create a TableLayoutPanel to arrange buttons in 2x2 grid
            TableLayoutPanel layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 2,
                Padding = new Padding(20),
                BackColor = Color.White
            };

            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            // Create and style buttons
            Button[] buttons = new Button[4];
            string[] texts = { "Road Blocks", "Feasability", "Milestone", "Dashboard" };
            EventHandler[] handlers = {
        button1_Click, button2_Click, button3_Click, button4_Click
    };
            Color[] colors = {
        Color.FromArgb(255, 87, 34),
        Color.FromArgb(76, 175, 80),
        Color.FromArgb(33, 150, 243),
        Color.FromArgb(156, 39, 176)
    };

            for (int i = 0; i < 4; i++)
            {
                buttons[i] = new Button
                {
                    Text = texts[i],
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = colors[i],
                    FlatStyle = FlatStyle.Flat,
                    Margin = new Padding(10)
                };
                buttons[i].FlatAppearance.BorderSize = 0;
                buttons[i].Click += handlers[i];

                layout.Controls.Add(buttons[i], i % 2, i / 2);
            }

            // Clear existing controls and apply layout
            this.Controls.Clear();
            this.Controls.Add(layout);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            RoadBlockBoards roadBlockBoards = new RoadBlockBoards();
            roadBlockBoards.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FeasabilityBoards feasabilityBoards = new FeasabilityBoards();
            feasabilityBoards.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MileStoneBoards mileStoneBoards = new MileStoneBoards();
            mileStoneBoards.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();
        }
    }
}
