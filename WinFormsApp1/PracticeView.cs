using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word;
using Word.Model;

namespace WinFormsApp1
{
    public partial class PracticeView : UserControl
    {
        private WordList _wordList;
        private WordModel _word;
        private int _correct;
        private int _questions;
        private string Score => $"You praticed {_questions} words with a successrate of {((double)_correct / _questions):P1}";

        public PracticeView(WordList a)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            _wordList = a;
            NextRound();
        }

        void NextRound()
        {
            WordModel b = _wordList.GetWordToPractice();
            _word = b;
            var fromWord = b.Translations[b.FromLanguage];
            var fromLang = _wordList.Languages[b.FromLanguage];
            var toLang = _wordList.Languages[b.ToLanguage];
            questionLabel.Text = $"Translate the word {fromWord} from ({fromLang}) to ({toLang})";
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            _correct = 0;
            _questions = 0;
            scoreLabel.Text = Score;
            NextRound();
        }

        private void correctButton_Click(object sender, EventArgs e)
        {
            var toWord = _word.Translations[_word.ToLanguage];
            if (string.Equals(textBox1.Text, toWord, StringComparison.CurrentCultureIgnoreCase)) _correct++;
            else MessageBox.Show($"Wrong the correct answear is: {toWord}");
            _questions++;
            textBox1.Text = "";
            scoreLabel.Text = Score;
            NextRound();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            correctButton.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text);
        }
    }
}
