using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word;

namespace WinFormsApp1
{
    public partial class WordsView : UserControl
    {
        private WordList _wordList;
        private DataTable dt = new DataTable();
        public event Action<string[]> addWord;

        public WordsView(WordList a)
        {
            InitializeComponent();
            _wordList = a;
            addWord += addWordHandler;
            seedDataTable();
            listDataGridView.DataSource = dt;
            listDataGridView.CellEndEdit += ListView_CellEndEdit;
            listDataGridView.UserDeletedRow += ListDataGridView_UserDeletedRow;
            listDataGridView.CellBeginEdit += ListDataGridView_CellBeginEdit;
        }

        private void ListDataGridView_UserDeletedRow(object? sender, DataGridViewRowEventArgs e)
        {
            ValidateForm();
        }

        private void ListDataGridView_CellBeginEdit(object? sender, DataGridViewCellCancelEventArgs e)
        {
            saveButton.Enabled = false;
            Warning.Show();
        }

        private void addWordHandler(string[] obj)
        {         
            dt.Rows.Add(obj);
        }

        private void ListView_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            Warning.Hide();
            DataGridViewCell[] cells = listDataGridView.Rows[e.RowIndex].Cells.Cast<DataGridViewCell>().Select(x => x).ToArray();
            DataGridViewCell[] emptyCells = cells.Where(x => string.IsNullOrEmpty((string)x.FormattedValue)).ToArray();
            foreach (DataGridViewCell cell in cells)
            {
                if (cells.Count() == emptyCells.Count())
                    cell.ErrorText = "";
                else if (string.IsNullOrEmpty((string)cell.FormattedValue) && !cell.IsInEditMode)
                    cell.ErrorText = "Cannot be empty";
                else cell.ErrorText = "";
            }
            ValidateForm();
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
                if (!word.Any(x => string.IsNullOrEmpty(x))) _wordList.Add(word);
            }
            _wordList.Save();
            MessageBox.Show("save successful");
        }

        private void ValidateForm()
        {
            bool hasErrorText = false;
            foreach (DataGridViewRow row in listDataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ErrorText.Length > 0)
                    {
                        hasErrorText = true;
                        break;
                    }
                }
                if (hasErrorText)
                    break;
            }
            saveButton.Enabled = !hasErrorText;
        }
    }
}
