using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp.Feasability
{
    public partial class FeasabilityBoards: Form
    {
        public FeasabilityBoards()
        {
            InitializeComponent();
        }

        private void FeasabilityBoards_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'boardDBDataSet.Feasibility'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.feasibilityTableAdapter.Fill(this.boardDBDataSet.Feasibility);

        }
    }
}
