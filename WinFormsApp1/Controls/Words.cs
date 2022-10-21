using System.Data;
using Word;

namespace WinFormsApp1
{
    public partial class Words : UserControl
    {
        private WordList _wordList;
        private DataTable _dt = new DataTable();

        public Words(WordList a)
        {
            InitializeComponent();
            _wordList = a;
            seedDataTable();
            listDataGridView.DataSource = _dt;
            listDataGridView.CellEndEdit += ListView_CellEndEdit;
            listDataGridView.CellBeginEdit += ListDataGridView_CellBeginEdit;
            listDataGridView.Validated += ListDataGridView_Validated;
        }

        private void ListDataGridView_Validated(object? sender, EventArgs e)
        {
            bool valid = ValidateForm();
            saveButton.Enabled = valid;
            warning.Visible = !valid;
        }

        private void ListDataGridView_CellBeginEdit(object? sender, DataGridViewCellCancelEventArgs e)
        {
            listDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "";
            saveButton.Enabled = true;
        }

        private void ListView_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            warning.Hide();
        }

        private void seedDataTable()
        {
            _dt.Columns.AddRange(_wordList.Languages.Select(x => new DataColumn(x)).ToArray());
            _wordList.List(0, (x) => _dt.Rows.Add(x));
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            _wordList.ClearWords();
            DataGridViewRow[] dataGrid = listDataGridView.Rows.Cast<DataGridViewRow>().Select(x => x).ToArray();
            foreach (DataGridViewRow item in dataGrid)
            {
                string[] word = item.Cells.Cast<DataGridViewCell>().Select(x => (string)x.FormattedValue).ToArray();
                if (!word.Any(x => string.IsNullOrWhiteSpace(x))) _wordList.Add(word);
            }
            _wordList.Save();
            saveButton.Enabled = false;
        }

        private bool ValidateForm()
        {
            bool hasErrorText = false;
            foreach (DataGridViewRow row in listDataGridView.Rows)
            {
                if (row.Cells.Cast<DataGridViewCell>().All(x => string.IsNullOrWhiteSpace(x.Value as string))) continue;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (string.IsNullOrWhiteSpace(cell.Value as string))
                    {
                        cell.ErrorText = "Cannot be empty";
                        hasErrorText = true;
                    }
                    else cell.ErrorText = "";
                }
            }
            return !hasErrorText;
        }
    }
}
