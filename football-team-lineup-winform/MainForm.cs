using ClassLibrary;
using System.Numerics;
using System.Security.Policy;

namespace football_team_lineup_winform
{
    public partial class MainForm : Form
    {
        Team SelectedTeam { get; set; }
        Lineup SelectedLineup { get; set; }

        public MainForm()
        {
            InitializeComponent();

            SetButtonsVisibility(false);

            cboOption.Items.Add("AM");
            cboOption.Items.Add("DM");
            cboOption.SelectedIndex = 0;

            tlpFormation.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
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

            tlpFormation.Visible = visible;
        }

        private void ResetFormation()
        {
            tlpFormation.RowCount = 1;
            tlpFormation.RowStyles.Clear();
            tlpFormation.Controls.Clear();
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
                    ResetFormation();
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
                File.Delete(SelectedTeam.FilePath);
                SelectedTeam = null;
                txtSelectedTeam.Text = $"no team selected";
                txtSelectedTeam.ForeColor = Color.Red;

                SetButtonsVisibility(false);
                ResetFormation();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            using (ModifyForm modifyForm = new ModifyForm(SelectedTeam))
            {
                if (modifyForm.ShowDialog() == DialogResult.OK)
                {
                    SelectedTeam = new Team(SelectedTeam.Name); // Refresh player
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            bool valid = false;
            try
            {
                Lineup lineup = new Lineup(txtFormation.Text, SelectedTeam, cboOption.Text);
                SelectedLineup = lineup;
                valid = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Formation error : {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            if (valid)
            {
                // Add tlpFormation rows and format it well.
                ResetFormation();
                int rowNumber = SelectedLineup.PitchPositions.Count();
                tlpFormation.RowCount = rowNumber;
                tlpFormation.RowStyles.Clear();

                float rowSize = 100f / tlpFormation.RowCount;
                for (int i = 0; i < tlpFormation.RowCount; i++)
                {
                    tlpFormation.RowStyles.Add(new RowStyle(SizeType.Percent, rowSize));
                }

                // Generate Fill PitchPosition and PitchPlayer.
                SelectedLineup.FillPitchPositions();
                SelectedLineup.FillPitchPlayersWithRandomPlayers();

                // Add table layout structure and fill with players.
                int rowNumberLayout = SelectedLineup.PitchPositions.Count;
                for (int r = 0; r < SelectedLineup.PitchPositions.Count; r++)
                {
                    rowNumberLayout--;

                    TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
                    tableLayoutPanel.ColumnCount = SelectedLineup.PitchPositions[r].Count;
                    tableLayoutPanel.Dock = DockStyle.Fill;

                    rowSize = 100f / tableLayoutPanel.ColumnCount;
                    for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
                    {
                        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, rowSize));
                    }

                    for (int c = 0; c < SelectedLineup.PitchPositions[r].Count; c++)
                    {
                        Label label = new Label();
                        label.Text = $"{SelectedLineup.PitchPlayers[r][c].LastName}\n{SelectedLineup.PitchPositions[r][c]}";
                        label.TextAlign = ContentAlignment.MiddleCenter;
                        label.BorderStyle = BorderStyle.FixedSingle;
                        label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
                        tableLayoutPanel.Controls.Add(label, c, r);
                    }

                    tlpFormation.Controls.Add(tableLayoutPanel, 1, rowNumberLayout);
                }
            }
        }
    }
}
