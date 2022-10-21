using System.Data;
using Word;

namespace WinFormsApp1
{
    public partial class Words : UserControl
    {
        private WordList _wordList;
        private DataTable _dt = new DataTable();

        public Words(WordList wordlist)
        {
            InitializeComponent();
            _wordList = wordlist;
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
            warning.Hide();
        }

        private void ListView_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            warning.Hide();
        }

        private void seedDataTable()
        {
            _dt.Columns.AddRange(_wordList.Languages.Select(x => new DataColumn(x)).ToArray());
            _wordList.List(0, (translations) => _dt.Rows.Add(translations));
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            _wordList.ClearWords();
            DataGridViewRow[] dataGrid = listDataGridView.Rows.Cast<DataGridViewRow>().ToArray();
            foreach (DataGridViewRow row in dataGrid)
            {
                string[] translations = row.Cells.Cast<DataGridViewCell>().Select(cell => (string)cell.FormattedValue).ToArray();
                if (!translations.Any(word => string.IsNullOrWhiteSpace(word))) _wordList.Add(translations);
            }
            _wordList.Save();
            saveButton.Enabled = false;
        }

        private bool ValidateForm()
        {
            bool hasErrorText = false;
            foreach (DataGridViewRow row in listDataGridView.Rows)
            {
                if (row.Cells.Cast<DataGridViewCell>().All(cell => string.IsNullOrWhiteSpace(cell.Value as string))) continue;
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
