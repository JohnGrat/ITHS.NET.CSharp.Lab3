using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Word;
using Word.Model;

namespace WinFormsApp1
{
    public partial class DashBoard : Form
    {
        private WordList _wordList;
        public DashBoard(WordList wordList)
        {
            InitializeComponent();
            Text = wordList.Name;
            _wordList = wordList;
            _wordList_SaveSuccess(_wordList.Count);
            _wordList.SaveSuccess += _wordList_SaveSuccess;
            panel1.Controls.Add(new WordsView(_wordList) { Dock = DockStyle.Fill });
        }

        private void _wordList_SaveSuccess(int obj)
        {
            practiceToolStripMenuItem.Enabled = obj > 0;
        }

        private void wordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            WordsView c = new WordsView(_wordList) { Dock = DockStyle.Fill };
            panel1.Controls.Add(c);
        }

        private void practiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            PracticeView c = new PracticeView(_wordList);
            panel1.Controls.Add(c);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chooseListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}