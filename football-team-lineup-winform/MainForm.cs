using ClassLibrary;
using System.Security.Policy;

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
            cboOption.SelectedIndex = 0;

            #endregion
        }

        private void SetButtonsVisibility(bool visible)
        {
            btnGenerate.Visible = visible;
            btnModify.Visible = visible;
            btnDelete.Visible = visible;

            txtFormationTitle.Visible = visible;
            txtFormation.Visible = visible;
            txtOptionTitle.Visible = visible;
            cboOption.Visible = visible;
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

                    SetButtonsVisibility(true);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this team?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );
            if (result == DialogResult.Yes)
            {
                File.Delete(SelectedTeam.TeamFilePath);
                SelectedTeam = null;
                txtSelectedTeam.Text = $"no team selected";
                txtSelectedTeam.ForeColor = Color.Red;
                SetButtonsVisibility(false);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            using (ModifyForm modifyForm = new ModifyForm(SelectedTeam))
            {
                if (modifyForm.ShowDialog() == DialogResult.OK)
                {
                    
                }
            }
        }
    }
}
