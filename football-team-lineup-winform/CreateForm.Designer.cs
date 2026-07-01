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
            txtNameTitle = new TextBox();
            txtName = new TextBox();
            btnCreate = new Button();
            tlpMainLayout.SuspendLayout();
            SuspendLayout();
            // 
            // tlpMainLayout
            // 
            tlpMainLayout.ColumnCount = 2;
            tlpMainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlpMainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tlpMainLayout.Controls.Add(txtNameTitle, 0, 0);
            tlpMainLayout.Controls.Add(txtName, 1, 0);
            tlpMainLayout.Controls.Add(btnCreate, 1, 1);
            tlpMainLayout.Location = new Point(12, 12);
            tlpMainLayout.Name = "tlpMainLayout";
            tlpMainLayout.RowCount = 2;
            tlpMainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpMainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpMainLayout.Size = new Size(310, 87);
            tlpMainLayout.TabIndex = 0;
            // 
            // txtNameTitle
            // 
            txtNameTitle.Anchor = AnchorStyles.None;
            txtNameTitle.BackColor = SystemColors.Menu;
            txtNameTitle.BorderStyle = BorderStyle.None;
            txtNameTitle.Location = new Point(3, 13);
            txtNameTitle.Name = "txtNameTitle";
            txtNameTitle.Size = new Size(87, 16);
            txtNameTitle.TabIndex = 0;
            txtNameTitle.Text = "Name :";
            txtNameTitle.TextAlign = HorizontalAlignment.Right;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(96, 10);
            txtName.Name = "txtName";
            txtName.Size = new Size(211, 23);
            txtName.TabIndex = 1;
            // 
            // btnCreate
            // 
            btnCreate.Anchor = AnchorStyles.Right;
            btnCreate.Location = new Point(220, 46);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(87, 38);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // CreateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 111);
            Controls.Add(tlpMainLayout);
            Name = "CreateForm";
            Text = "CreateFrom";
            tlpMainLayout.ResumeLayout(false);
            tlpMainLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMainLayout;
        private TextBox txtNameTitle;
        private TextBox txtName;
        private Button btnCreate;
    }
}