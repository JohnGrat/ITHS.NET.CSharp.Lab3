namespace WinFormsApp1
{
    partial class PracticeView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.resetButton = new System.Windows.Forms.Button();
            this.questionLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.correctButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resetButton
            // 
            this.resetButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.resetButton.Location = new System.Drawing.Point(102, 265);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 0;
            this.resetButton.Text = "Restart";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // questionLabel
            // 
            this.questionLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.questionLabel.AutoSize = true;
            this.questionLabel.Location = new System.Drawing.Point(102, 145);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(55, 15);
            this.questionLabel.TabIndex = 2;
            this.questionLabel.Text = "Question";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(102, 180);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(256, 23);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // scoreLabel
            // 
            this.scoreLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(102, 223);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(256, 15);
            this.scoreLabel.TabIndex = 4;
            this.scoreLabel.Text = "You praticed 0 words with a successrate of NaN";
            // 
            // correctButton
            // 
            this.correctButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.correctButton.Enabled = false;
            this.correctButton.Location = new System.Drawing.Point(283, 265);
            this.correctButton.Name = "correctButton";
            this.correctButton.Size = new System.Drawing.Size(75, 23);
            this.correctButton.TabIndex = 5;
            this.correctButton.Text = "Send";
            this.correctButton.UseVisualStyleBackColor = true;
            this.correctButton.Click += new System.EventHandler(this.correctButton_Click);
            // 
            // PracticeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.correctButton);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.questionLabel);
            this.Controls.Add(this.resetButton);
            this.Name = "PracticeView";
            this.Size = new System.Drawing.Size(463, 390);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button resetButton;
        private Label questionLabel;
        private TextBox textBox1;
        private Label scoreLabel;
        private Button correctButton;
    }
}
