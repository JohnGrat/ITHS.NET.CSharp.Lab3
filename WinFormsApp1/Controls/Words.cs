using System.Data;
using Word;

namespace WinFormsApp1
{
    public partial class Words : UserControl
    {
        private WordList _wordList;
        private DataTable dt = new DataTable();
        public event Action<string[]> addWord;

        public Words(WordList a)
        {
            InitializeComponent();
            _wordList = a;
            addWord += addWordHandler;
            seedDataTable();
            listDataGridView.DataSource = dt;
            listDataGridView.CellEndEdit += ListView_CellEndEdit;
            listDataGridView.CellBeginEdit += ListDataGridView_CellBeginEdit;
            listDataGridView.Validated += ListDataGridView_Validated;
        }

        private void ListDataGridView_Validated(object? sender, EventArgs e)
        {
            saveButton.Enabled = ValidateForm();
        }

        private void ListDataGridView_CellBeginEdit(object? sender, DataGridViewCellCancelEventArgs e)
        {
            listDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "";
            saveButton.Enabled = true;
        }

        private void addWordHandler(string[] obj)
        {         
            dt.Rows.Add(obj);
        }

        private void ListView_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            Warning.Hide();
        }

        private void seedDataTable()
        {
            dt.Columns.AddRange(_wordList.Languages.Select(x => new DataColumn(x)).ToArray());
            _wordList.List(0, addWord);
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
            MessageBox.Show("save successful");
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
