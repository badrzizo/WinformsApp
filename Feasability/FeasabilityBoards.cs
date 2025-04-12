using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Feasability.AddFormFeasabilty addFormFeasabilty = new Feasability.AddFormFeasabilty();
            addFormFeasabilty.ShowDialog();
        }
    }
}
