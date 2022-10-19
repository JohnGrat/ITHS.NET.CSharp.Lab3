namespace WinFormsApp1
{
    partial class ChooseList
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
            this.directoryListBox = new System.Windows.Forms.ListBox();
            this.columnListBox = new System.Windows.Forms.ListBox();
            this.createButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.wordsCountLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // directoryListBox
            // 
            this.directoryListBox.FormattingEnabled = true;
            this.directoryListBox.ItemHeight = 15;
            this.directoryListBox.Location = new System.Drawing.Point(13, 54);
            this.directoryListBox.Name = "directoryListBox";
            this.directoryListBox.Size = new System.Drawing.Size(155, 199);
            this.directoryListBox.TabIndex = 0;
            this.directoryListBox.SelectedIndexChanged += new System.EventHandler(this.directoryListBox_SelectedIndexChanged);
            // 
            // columnListBox
            // 
            this.columnListBox.Enabled = false;
            this.columnListBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.columnListBox.FormattingEnabled = true;
            this.columnListBox.ItemHeight = 15;
            this.columnListBox.Location = new System.Drawing.Point(174, 54);
            this.columnListBox.Name = "columnListBox";
            this.columnListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.columnListBox.Size = new System.Drawing.Size(123, 199);
            this.columnListBox.TabIndex = 1;
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(12, 259);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 2;
            this.createButton.Text = "New";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(93, 259);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lists";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Languages:";
            // 
            // wordsCountLabel
            // 
            this.wordsCountLabel.AutoSize = true;
            this.wordsCountLabel.Location = new System.Drawing.Point(174, 263);
            this.wordsCountLabel.Name = "wordsCountLabel";
            this.wordsCountLabel.Size = new System.Drawing.Size(44, 15);
            this.wordsCountLabel.TabIndex = 6;
            this.wordsCountLabel.Text = "Words:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Doubleclick or press Enter to open list";
            // 
            // ChooseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 294);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.wordsCountLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.columnListBox);
            this.Controls.Add(this.directoryListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChooseList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChooseList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox directoryListBox;
        private ListBox columnListBox;
        private Button createButton;
        private Button deleteButton;
        private Label label1;
        private Label label2;
        private Label wordsCountLabel;
        private Label label3;
    }
}