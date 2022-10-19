using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using System.Xml.Linq;
using Word;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class CreateList : Form
    {
        private BindingList<string> _listColumn = new BindingList<string>();
        private BindingList<string> _lists;

        public CreateList(BindingList<string> lists)
        {
            InitializeComponent();
            _lists = lists;
            _listColumn.ListChanged += ValidateForm;
            columnListBox.DataSource = _listColumn;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            new WordList(listNameBox.Text, _listColumn.Select(x => x).ToArray()).Save();
            _lists.Add(listNameBox.Text);
            Close();
        }

        private void addColumnButton_Click(object sender, EventArgs e)
        {
            AddColumn form = new AddColumn(_listColumn);
            form.Location = new Point(Location.X + 200, Location.Y + 100);
            form.ShowDialog();
        }

        private void ValidateForm(object sender, EventArgs e)
        {
            addColumnButton.Enabled = !string.IsNullOrEmpty(listNameBox.Text);
            deleteColumnButton.Enabled = _listColumn.Any();
            if (_lists.Any(s => s == listNameBox.Text)) warningLabel.Show();
            else warningLabel.Hide();
            SubmitButton.Enabled = (_listColumn.Count > 1 && warningLabel.Visible == false && addColumnButton.Enabled == true);
        }

        private void DeleteItemButton_Click(object sender, EventArgs e)
        {
            _listColumn.Remove(columnListBox.Text);
        }
    }
}
