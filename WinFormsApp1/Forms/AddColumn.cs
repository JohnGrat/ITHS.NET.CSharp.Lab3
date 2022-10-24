using System.ComponentModel;

namespace WinFormsApp1;

public partial class AddColumn : Form
{
    private readonly BindingList<string> _listColumn;

    public AddColumn(BindingList<string> newList)
    {
        InitializeComponent();
        _listColumn = newList;
    }

    private void submitButton_Click(object sender, EventArgs e)
    {
        if (_listColumn.Contains(columnNameBox.Text))
        {
            warningLabel.Show();
        }
        else
        {
            _listColumn.Add(columnNameBox.Text);
            columnNameBox.Text = "";
            warningLabel.Hide();
        }
    }

    private void columnNameBox_TextChanged(object sender, EventArgs e)
    {
        submitButton.Enabled = !string.IsNullOrWhiteSpace(columnNameBox.Text);
    }
}