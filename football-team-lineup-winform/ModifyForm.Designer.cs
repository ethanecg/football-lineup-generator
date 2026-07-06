namespace football_team_lineup_winform
{
    partial class ModifyForm
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
            rtbPlayers = new RichTextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnSave = new Button();
            btnInstruction = new Button();
            btnCancel = new Button();
            rtbLineNumber = new RichTextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // rtbPlayers
            // 
            rtbPlayers.Dock = DockStyle.Fill;
            rtbPlayers.Location = new Point(79, 3);
            rtbPlayers.Name = "rtbPlayers";
            rtbPlayers.Size = new Size(678, 383);
            rtbPlayers.TabIndex = 0;
            rtbPlayers.Text = "";
            rtbPlayers.TextChanged += rtbPlayers_TextChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(btnSave, 0, 0);
            tableLayoutPanel1.Controls.Add(btnInstruction, 1, 0);
            tableLayoutPanel1.Controls.Add(btnCancel, 2, 0);
            tableLayoutPanel1.Location = new Point(12, 407);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(760, 42);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Fill;
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(247, 36);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnInstruction
            // 
            btnInstruction.Dock = DockStyle.Fill;
            btnInstruction.Location = new Point(256, 3);
            btnInstruction.Name = "btnInstruction";
            btnInstruction.Size = new Size(247, 36);
            btnInstruction.TabIndex = 0;
            btnInstruction.Text = "Instruction";
            btnInstruction.UseVisualStyleBackColor = true;
            btnInstruction.Click += btnInstruction_Click;
            // 
            // btnCancel
            // 
            btnCancel.Dock = DockStyle.Fill;
            btnCancel.Location = new Point(509, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(248, 36);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // rtbLineNumber
            // 
            rtbLineNumber.Dock = DockStyle.Fill;
            rtbLineNumber.Location = new Point(3, 3);
            rtbLineNumber.Name = "rtbLineNumber";
            rtbLineNumber.Size = new Size(70, 383);
            rtbLineNumber.TabIndex = 2;
            rtbLineNumber.Text = "";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
            tableLayoutPanel2.Controls.Add(rtbPlayers, 1, 0);
            tableLayoutPanel2.Controls.Add(rtbLineNumber, 0, 0);
            tableLayoutPanel2.Location = new Point(12, 12);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(760, 389);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // ModifyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(800, 500);
            Name = "ModifyForm";
            Text = "ModifyForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtbPlayers;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnInstruction;
        private Button btnCancel;
        private Button btnSave;
        private RichTextBox rtbLineNumber;
        private TableLayoutPanel tableLayoutPanel2;
    }
}