using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp.RoadsBlock
{
    public partial class AddingPointsForm: Form
    {
        public AddingPointsForm()
        {
            InitializeComponent();
        }

        private void linkLabelProject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RoadsBlock.ManagerRoadsBloackProject managerRoadsBloackProject = new ManagerRoadsBloackProject();
            managerRoadsBloackProject.Show();

        }

        private void linkLabelFamily_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ManagerRoadsBlockFamily managerRoadsBlockFamily = new ManagerRoadsBlockFamily();
            managerRoadsBlockFamily.Show();
        }

        private void linkLabelDepartement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ManagerRoadsBlockDepartement managerRoadsBlockDepartement = new ManagerRoadsBlockDepartement();
            managerRoadsBlockDepartement.Show();
        }
    }
}
