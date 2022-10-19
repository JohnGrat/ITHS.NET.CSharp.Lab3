namespace WinFormsApp1
{
    partial class CreateList
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
            this.listNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.warningLabel = new System.Windows.Forms.Label();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.deleteColumnButton = new System.Windows.Forms.Button();
            this.addColumnButton = new System.Windows.Forms.Button();
            this.columnListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listNameBox
            // 
            this.listNameBox.Location = new System.Drawing.Point(23, 40);
            this.listNameBox.Name = "listNameBox";
            this.listNameBox.Size = new System.Drawing.Size(165, 23);
            this.listNameBox.TabIndex = 1;
            this.listNameBox.TextChanged += new System.EventHandler(this.ValidateForm);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Listname";
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.ForeColor = System.Drawing.Color.Red;
            this.warningLabel.Location = new System.Drawing.Point(194, 43);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(84, 15);
            this.warningLabel.TabIndex = 3;
            this.warningLabel.Text = "Already in use.";
            this.warningLabel.Visible = false;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Enabled = false;
            this.SubmitButton.Location = new System.Drawing.Point(218, 322);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 4;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // deleteColumnButton
            // 
            this.deleteColumnButton.Enabled = false;
            this.deleteColumnButton.Location = new System.Drawing.Point(23, 322);
            this.deleteColumnButton.Name = "deleteColumnButton";
            this.deleteColumnButton.Size = new System.Drawing.Size(75, 23);
            this.deleteColumnButton.TabIndex = 5;
            this.deleteColumnButton.Text = "Delete";
            this.deleteColumnButton.UseVisualStyleBackColor = true;
            this.deleteColumnButton.Click += new System.EventHandler(this.DeleteItemButton_Click);
            // 
            // addColumnButton
            // 
            this.addColumnButton.Enabled = false;
            this.addColumnButton.Location = new System.Drawing.Point(104, 322);
            this.addColumnButton.Name = "addColumnButton";
            this.addColumnButton.Size = new System.Drawing.Size(84, 23);
            this.addColumnButton.TabIndex = 6;
            this.addColumnButton.Text = "Add";
            this.addColumnButton.UseVisualStyleBackColor = true;
            this.addColumnButton.Click += new System.EventHandler(this.addColumnButton_Click);
            // 
            // columnListBox
            // 
            this.columnListBox.FormattingEnabled = true;
            this.columnListBox.ItemHeight = 15;
            this.columnListBox.Location = new System.Drawing.Point(23, 102);
            this.columnListBox.Name = "columnListBox";
            this.columnListBox.Size = new System.Drawing.Size(165, 214);
            this.columnListBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Languages";
            // 
            // CreateList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 365);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.columnListBox);
            this.Controls.Add(this.addColumnButton);
            this.Controls.Add(this.deleteColumnButton);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listNameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CreateList";
            this.Text = "Create";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox listNameBox;
        private Label label1;
        private Label warningLabel;
        private Button SubmitButton;
        private Button deleteColumnButton;
        private Button addColumnButton;
        private ListBox columnListBox;
        private Label label2;
    }
}