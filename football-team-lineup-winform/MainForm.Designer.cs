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
            txtSelectedTeam = new TextBox();
            txtFormationTitle = new TextBox();
            txtFormation = new TextBox();
            cboOption = new ComboBox();
            txtOptionTitle = new TextBox();
            tlpSecondaryLayout = new TableLayoutPanel();
            tlpFormation = new TableLayoutPanel();
            tlpMainLayout.SuspendLayout();
            tlpSecondaryLayout.SuspendLayout();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTitle.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTitle.BorderStyle = BorderStyle.FixedSingle;
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
            btnTeam.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            btnGenerate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnGenerate.Location = new Point(193, 3);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(184, 41);
            btnGenerate.TabIndex = 1;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // btnModify
            // 
            btnModify.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnModify.Location = new Point(383, 3);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(184, 41);
            btnModify.TabIndex = 2;
            btnModify.Text = "Modify";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnDelete.Location = new Point(573, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(184, 41);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtSelectedTeam
            // 
            txtSelectedTeam.Anchor = AnchorStyles.Right;
            txtSelectedTeam.BackColor = SystemColors.Menu;
            txtSelectedTeam.BorderStyle = BorderStyle.None;
            txtSelectedTeam.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSelectedTeam.ForeColor = Color.Red;
            txtSelectedTeam.Location = new Point(573, 8);
            txtSelectedTeam.Name = "txtSelectedTeam";
            txtSelectedTeam.ReadOnly = true;
            txtSelectedTeam.Size = new Size(184, 15);
            txtSelectedTeam.TabIndex = 3;
            txtSelectedTeam.Text = "no team selected";
            txtSelectedTeam.TextAlign = HorizontalAlignment.Right;
            // 
            // txtFormationTitle
            // 
            txtFormationTitle.Anchor = AnchorStyles.Right;
            txtFormationTitle.BackColor = SystemColors.Menu;
            txtFormationTitle.BorderStyle = BorderStyle.None;
            txtFormationTitle.ForeColor = SystemColors.WindowText;
            txtFormationTitle.Location = new Point(15, 7);
            txtFormationTitle.Name = "txtFormationTitle";
            txtFormationTitle.ReadOnly = true;
            txtFormationTitle.Size = new Size(58, 16);
            txtFormationTitle.TabIndex = 4;
            txtFormationTitle.Text = "Formation";
            // 
            // txtFormation
            // 
            txtFormation.Dock = DockStyle.Fill;
            txtFormation.Location = new Point(79, 3);
            txtFormation.Name = "txtFormation";
            txtFormation.PlaceholderText = "e.x, 1-4-4-2";
            txtFormation.Size = new Size(108, 23);
            txtFormation.TabIndex = 5;
            // 
            // cboOption
            // 
            cboOption.Dock = DockStyle.Fill;
            cboOption.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOption.FormattingEnabled = true;
            cboOption.Location = new Point(269, 3);
            cboOption.Name = "cboOption";
            cboOption.Size = new Size(70, 23);
            cboOption.TabIndex = 6;
            // 
            // txtOptionTitle
            // 
            txtOptionTitle.Anchor = AnchorStyles.Right;
            txtOptionTitle.BackColor = SystemColors.Menu;
            txtOptionTitle.BorderStyle = BorderStyle.None;
            txtOptionTitle.Location = new Point(224, 7);
            txtOptionTitle.Name = "txtOptionTitle";
            txtOptionTitle.ReadOnly = true;
            txtOptionTitle.Size = new Size(39, 16);
            txtOptionTitle.TabIndex = 7;
            txtOptionTitle.Text = "Option";
            // 
            // tlpSecondaryLayout
            // 
            tlpSecondaryLayout.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlpSecondaryLayout.ColumnCount = 6;
            tlpSecondaryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tlpSecondaryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tlpSecondaryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tlpSecondaryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tlpSecondaryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpSecondaryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlpSecondaryLayout.Controls.Add(txtFormationTitle, 0, 0);
            tlpSecondaryLayout.Controls.Add(txtOptionTitle, 2, 0);
            tlpSecondaryLayout.Controls.Add(txtFormation, 1, 0);
            tlpSecondaryLayout.Controls.Add(txtSelectedTeam, 5, 0);
            tlpSecondaryLayout.Controls.Add(cboOption, 3, 0);
            tlpSecondaryLayout.Location = new Point(12, 103);
            tlpSecondaryLayout.Name = "tlpSecondaryLayout";
            tlpSecondaryLayout.RowCount = 1;
            tlpSecondaryLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpSecondaryLayout.Size = new Size(760, 31);
            tlpSecondaryLayout.TabIndex = 8;
            // 
            // tlpFormation
            // 
            tlpFormation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlpFormation.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpFormation.ColumnCount = 1;
            tlpFormation.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpFormation.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpFormation.Location = new Point(12, 140);
            tlpFormation.Name = "tlpFormation";
            tlpFormation.RowCount = 1;
            tlpFormation.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpFormation.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpFormation.Size = new Size(760, 309);
            tlpFormation.TabIndex = 9;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(tlpFormation);
            Controls.Add(tlpSecondaryLayout);
            Controls.Add(tlpMainLayout);
            Controls.Add(txtTitle);
            Name = "MainForm";
            Text = "MainForm";
            tlpMainLayout.ResumeLayout(false);
            tlpSecondaryLayout.ResumeLayout(false);
            tlpSecondaryLayout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private TableLayoutPanel tlpMainLayout;
        private Button btnTeam;
        private Button btnGenerate;
        private Button btnModify;
        private Button btnDelete;
        private TextBox txtSelectedTeam;
        private TextBox txtFormationTitle;
        private TextBox txtFormation;
        private ComboBox cboOption;
        private TextBox txtOptionTitle;
        private TableLayoutPanel tlpSecondaryLayout;
        private TableLayoutPanel tlpFormation;
    }
}
