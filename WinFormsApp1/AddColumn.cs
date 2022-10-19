using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class AddColumn : Form
    {
        private BindingList<string> _listColumn;

        public AddColumn(BindingList<string> newList)
        {
            InitializeComponent();
            _listColumn = newList;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (_listColumn.Contains(columnNameBox.Text)) warningLabel.Show();
            else
            {
                _listColumn.Add(columnNameBox.Text);
                warningLabel.Hide();
            }
        }

        private void columnNameBox_TextChanged(object sender, EventArgs e)
        {
            submitButton.Enabled = !string.IsNullOrEmpty(columnNameBox.Text);
        }
    }
}
