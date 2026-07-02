using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace football_team_lineup_winform
{
    public partial class TeamForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Team SelectedTeam { get; set; }

        public TeamForm()
        {
            InitializeComponent();
            UpdateLstTeam();
        }

        private void UpdateLstTeam()
        {
            lstTeam.Items.Clear();
            if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Teams")))
            {
                Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Teams"));
            }
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Teams");
            string[] allFiles = Directory.GetFiles(path);

            foreach (string file in allFiles)
            {
                string[] onlyFileName = file.Split('\\');
                int indexWhereFileNameLocated = onlyFileName.Length - 1;
                string name = onlyFileName[indexWhereFileNameLocated].Replace(".csv", "");
                lstTeam.Items.Add(name);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lstTeam.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    "You did not select anything.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            else
            {
                string teamName = lstTeam.SelectedItem.ToString();

                try
                {
                    SelectedTeam = new Team(teamName);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (CreateForm createForm = new CreateForm())
            {
                if (createForm.ShowDialog() == DialogResult.OK)
                {
                    UpdateLstTeam();
                }
            }
        }
    }
}
