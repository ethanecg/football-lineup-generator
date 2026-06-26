namespace football_team_lineup_winform
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTitle = new TextBox();
            tlpMainLayout = new TableLayoutPanel();
            btnTeam = new Button();
            btnGenerate = new Button();
            btnModify = new Button();
            btnDelete = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            tlpMainLayout.SuspendLayout();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTitle.BorderStyle = BorderStyle.FixedSingle;
            txtTitle.Enabled = false;
            txtTitle.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitle.Location = new Point(12, 9);
            txtTitle.Name = "txtTitle";
            txtTitle.ReadOnly = true;
            txtTitle.Size = new Size(760, 35);
            txtTitle.TabIndex = 0;
            txtTitle.Text = "football lineup generator";
            txtTitle.TextAlign = HorizontalAlignment.Center;
            // 
            // tlpMainLayout
            // 
            tlpMainLayout.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlpMainLayout.AutoSize = true;
            tlpMainLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpMainLayout.ColumnCount = 4;
            tlpMainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMainLayout.Controls.Add(btnTeam, 0, 0);
            tlpMainLayout.Controls.Add(btnGenerate, 1, 0);
            tlpMainLayout.Controls.Add(btnModify, 2, 0);
            tlpMainLayout.Controls.Add(btnDelete, 3, 0);
            tlpMainLayout.Location = new Point(12, 50);
            tlpMainLayout.Name = "tlpMainLayout";
            tlpMainLayout.RowCount = 1;
            tlpMainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMainLayout.Size = new Size(760, 47);
            tlpMainLayout.TabIndex = 1;
            // 
            // btnTeam
            // 
            btnTeam.Dock = DockStyle.Fill;
            btnTeam.Location = new Point(3, 3);
            btnTeam.Name = "btnTeam";
            btnTeam.Size = new Size(184, 41);
            btnTeam.TabIndex = 0;
            btnTeam.Text = "Team";
            btnTeam.UseVisualStyleBackColor = true;
            btnTeam.Click += btnTeam_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.Dock = DockStyle.Fill;
            btnGenerate.Location = new Point(193, 3);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(184, 41);
            btnGenerate.TabIndex = 1;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            // 
            // btnModify
            // 
            btnModify.Dock = DockStyle.Fill;
            btnModify.Location = new Point(383, 3);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(184, 41);
            btnModify.TabIndex = 2;
            btnModify.Text = "Modify";
            btnModify.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Location = new Point(573, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(184, 41);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Location = new Point(732, 429);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(8, 8);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tlpMainLayout);
            Controls.Add(txtTitle);
            Name = "MainForm";
            Text = "Form1";
            tlpMainLayout.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private TableLayoutPanel tlpMainLayout;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnTeam;
        private Button btnGenerate;
        private Button btnModify;
        private Button btnDelete;
    }
}
