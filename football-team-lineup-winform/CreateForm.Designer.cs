namespace football_team_lineup_winform
{
    partial class CreateForm
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
            tlpMainLayout = new TableLayoutPanel();
            txtName = new TextBox();
            txtNameTitle = new TextBox();
            btnCreate = new Button();
            btnCancel = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tlpMainLayout.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tlpMainLayout
            // 
            tlpMainLayout.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlpMainLayout.ColumnCount = 2;
            tlpMainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlpMainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tlpMainLayout.Controls.Add(txtName, 1, 0);
            tlpMainLayout.Controls.Add(txtNameTitle, 0, 0);
            tlpMainLayout.Location = new Point(12, 12);
            tlpMainLayout.Name = "tlpMainLayout";
            tlpMainLayout.RowCount = 1;
            tlpMainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpMainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpMainLayout.Size = new Size(310, 44);
            tlpMainLayout.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(96, 10);
            txtName.Name = "txtName";
            txtName.Size = new Size(211, 23);
            txtName.TabIndex = 1;
            // 
            // txtNameTitle
            // 
            txtNameTitle.Anchor = AnchorStyles.Right;
            txtNameTitle.BackColor = SystemColors.Menu;
            txtNameTitle.BorderStyle = BorderStyle.None;
            txtNameTitle.Location = new Point(3, 14);
            txtNameTitle.Name = "txtNameTitle";
            txtNameTitle.Size = new Size(87, 16);
            txtNameTitle.TabIndex = 0;
            txtNameTitle.Text = "Name :";
            txtNameTitle.TextAlign = HorizontalAlignment.Right;
            // 
            // btnCreate
            // 
            btnCreate.Dock = DockStyle.Fill;
            btnCreate.Location = new Point(3, 3);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(101, 31);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Dock = DockStyle.Fill;
            btnCancel.Location = new Point(110, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(101, 31);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnCancel, 1, 0);
            tableLayoutPanel1.Controls.Add(btnCreate, 0, 0);
            tableLayoutPanel1.Location = new Point(108, 62);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(214, 37);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // CreateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 111);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tlpMainLayout);
            MinimumSize = new Size(350, 150);
            Name = "CreateForm";
            Text = "CreateFrom";
            tlpMainLayout.ResumeLayout(false);
            tlpMainLayout.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMainLayout;
        private TextBox txtNameTitle;
        private TextBox txtName;
        private Button btnCreate;
        private Button btnCancel;
        private TableLayoutPanel tableLayoutPanel1;
    }
}