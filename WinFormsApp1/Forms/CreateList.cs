using System.ComponentModel;
using System.Data;
using Word;

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
            addColumnButton.Enabled = !string.IsNullOrWhiteSpace(listNameBox.Text);
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
