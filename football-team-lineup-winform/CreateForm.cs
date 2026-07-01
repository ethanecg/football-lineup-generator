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
    public partial class CreateForm : Form
    {
        Team team { get; set; }
        public CreateForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // todo (there is a bug)
            try
            {
                team = new Team(txtName.Text);
                
                // verify that team
                foreach (string path in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Teams")))
                {
                    string[] files = path.Split("\\");
                    int indexOfFile = files.Length;
                    string file = files[indexOfFile].Replace(".csv", "");
                    if (file == team.Name)
                    {
                        throw new ArgumentNullException(nameof(team.Name), "The team already exist cannot create another one.");
                    }
                }

                DialogResult = DialogResult.OK;
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
}
