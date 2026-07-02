using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace football_team_lineup_winform
{
    public partial class ModifyForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Team SelectedTeam { get; set; }

        public ModifyForm(Team selectedTeam)
        {
            InitializeComponent();
            SelectedTeam = selectedTeam;
            MakeFileContentAppear();
            rtbLineNumber.SelectionAlignment = HorizontalAlignment.Right;

            rtbPlayers_TextChanged(null, EventArgs.Empty); // Make the line number appear when you load.
        }

        private void MakeFileContentAppear()
        {
            using (StreamReader reader = new StreamReader(SelectedTeam.TeamFilePath))
            {
                string fullText = "";
                while (!reader.EndOfStream)
                {
                    fullText += $"{reader.ReadLine()}\n";
                }
                rtbPlayers.Text = fullText;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnInstruction_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Each line corresponds to a player. You need to write the player's full name, followed by a semicolon (';'). After that, write all the positions they can occupy, separating each position with a comma (',').\nExample of a line:\nPedro Neto;LW,RW",
                "Instruction",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool valid = true;
            // Verify that everything is well formated
            using (StringReader reader = new StringReader(rtbPlayers.Text))
            {
                int lineNumber = 0;

                // .EndOfStream() but for string
                while (reader.Peek() != -1)
                {
                    lineNumber++;
                    string line = reader.ReadLine();
                    // This prevent file corruption
                    try
                    {
                        Player _ = new Player(line);
                    }
                    catch (Exception ex)
                    {
                        valid = false;
                        MessageBox.Show(
                            $"Save was interupted : {ex.Message} at line {lineNumber}",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );
                        break;
                    }
                }
            }
            // Save
            if (valid)
            {
                using (StreamWriter writer = new StreamWriter(SelectedTeam.TeamFilePath))
                {
                    using (StringReader reader = new StringReader(rtbPlayers.Text))
                    {
                        while (reader.Peek() != -1)
                        {
                            string line = reader.ReadLine();
                            writer.WriteLine(line);
                        }
                    }
                }
                MessageBox.Show(
                    "Success!"
                    );
                DialogResult = DialogResult.OK;
            }
        }

        private void rtbPlayers_TextChanged(object sender, EventArgs e)
        {
            string lineNumbers = "";
            int lineNumber = 0;
            using (StringReader reader = new StringReader(rtbPlayers.Text))
            {
                while (reader.Peek() != -1)
                {
                    lineNumber++;
                    reader.ReadLine();
                    lineNumbers += $"{lineNumber}\n";
                }
            }
            rtbLineNumber.Text = lineNumbers;
        }
    }
}
