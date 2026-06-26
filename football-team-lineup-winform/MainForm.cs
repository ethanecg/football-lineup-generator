using ClassLibrary;

namespace football_team_lineup_winform
{
    public partial class MainForm : Form
    {
        Team SelectedTeam { get; set; }

        public MainForm()
        {
            InitializeComponent();
            Team team;
        }

        private void btnTeam_Click(object sender, EventArgs e)
        {
            using (TeamForm teamForm = new TeamForm())
            {
                if (teamForm.ShowDialog() == DialogResult.OK)
                {
                    SelectedTeam = teamForm.SelectedTeam;
                }
            }
        }
    }
}
