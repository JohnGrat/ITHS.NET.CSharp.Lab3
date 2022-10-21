namespace WinFormsApp1
{
    partial class Words
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
            this.listDataGridView = new System.Windows.Forms.DataGridView();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.warning = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listDataGridView
            // 
            this.listDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDataGridView.Location = new System.Drawing.Point(0, 0);
            this.listDataGridView.Name = "listDataGridView";
            this.listDataGridView.RowTemplate.Height = 25;
            this.listDataGridView.Size = new System.Drawing.Size(549, 524);
            this.listDataGridView.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(474, 0);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 33);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.warning);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 491);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 33);
            this.panel1.TabIndex = 3;
            // 
            // warning
            // 
            this.warning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.warning.AutoSize = true;
            this.warning.ForeColor = System.Drawing.Color.Red;
            this.warning.Location = new System.Drawing.Point(340, 9);
            this.warning.Name = "warning";
            this.warning.Size = new System.Drawing.Size(128, 15);
            this.warning.TabIndex = 3;
            this.warning.Text = "Datagrid contains error";
            this.warning.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.warning.Visible = false;
            // 
            // Words
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listDataGridView);
            this.Name = "Words";
            this.Size = new System.Drawing.Size(549, 524);
            ((System.ComponentModel.ISupportInitialize)(this.listDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView listDataGridView;
        private Button saveButton;
        private Panel panel1;
        private Label warning;
    }
}
