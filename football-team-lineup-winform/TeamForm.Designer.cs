namespace football_team_lineup_winform
{
    partial class TeamForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstTeam = new ListBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnSelect = new Button();
            btnNew = new Button();
            btnCancel = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lstTeam
            // 
            lstTeam.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lstTeam.FormattingEnabled = true;
            lstTeam.Location = new Point(12, 12);
            lstTeam.Name = "lstTeam";
            lstTeam.Size = new Size(360, 289);
            lstTeam.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(btnSelect, 0, 0);
            tableLayoutPanel1.Controls.Add(btnNew, 1, 0);
            tableLayoutPanel1.Controls.Add(btnCancel, 2, 0);
            tableLayoutPanel1.Location = new Point(12, 312);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(360, 37);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // btnSelect
            // 
            btnSelect.Dock = DockStyle.Fill;
            btnSelect.Location = new Point(3, 3);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(114, 31);
            btnSelect.TabIndex = 0;
            btnSelect.Text = "Select";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // btnNew
            // 
            btnNew.Dock = DockStyle.Fill;
            btnNew.Location = new Point(123, 3);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(114, 31);
            btnNew.TabIndex = 1;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Dock = DockStyle.Fill;
            btnCancel.Location = new Point(243, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 31);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // TeamForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(lstTeam);
            Name = "TeamForm";
            Text = "TeamForm";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstTeam;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnSelect;
        private Button btnNew;
        private Button btnCancel;
    }
}