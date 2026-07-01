using ClassLibrary;

namespace football_team_lineup_winform
{
    public partial class MainForm : Form
    {
        Team SelectedTeam { get; set; }

        public MainForm()
        {
            InitializeComponent();
            #region idk what name

            btnGenerate.Visible = false;
            btnModify.Visible = false;
            btnDelete.Visible = false;

            txtFormationTitle.Visible = false;
            txtFormation.Visible = false;
            txtOptionTitle.Visible = false;
            cboOption.Visible = false;

            cboOption.Items.Add("AM");
            cboOption.Items.Add("DM");

            #endregion


        }

        private void MakeEverythingAppear()
        {
            btnGenerate.Visible = true;
            btnModify.Visible = true;
            btnDelete.Visible = true;

            txtFormationTitle.Visible = true;
            txtFormation.Visible = true;
            txtOptionTitle.Visible = true;
            cboOption.Visible = true;
        }

        private void btnTeam_Click(object sender, EventArgs e)
        {
            using (TeamForm teamForm = new TeamForm())
            {
                if (teamForm.ShowDialog() == DialogResult.OK)
                {
                    SelectedTeam = teamForm.SelectedTeam;
                    txtSelectedTeam.Text = $"selected team : {SelectedTeam.Name}";
                    txtSelectedTeam.ForeColor = Color.Green;

                    MakeEverythingAppear();
                }
            }
        }
    }
}
