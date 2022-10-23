using Word;
using Word.Models;

namespace WinFormsApp1
{
    public partial class Practice : UserControl
    {
        private WordList _wordList;
        private WordModel _word;
        private int _correct;
        private int _questions;
        private string _score => $"You praticed {_questions} words with a successrate of {((double)_correct / _questions):P1}";

        public Practice(WordList wordlist)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            _wordList = wordlist;
            NextRound();
            textBox1.KeyDown += TextBox1_KeyDown;
        }

        private void TextBox1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) correct();
        }

        void NextRound()
        {
            textBox1.Focus();
            WordModel word = _wordList.GetWordToPractice();
            _word = word;
            string fromWord = word.Translations[word.FromLanguage];
            string fromLang = _wordList.Languages[word.FromLanguage];
            string toLang = _wordList.Languages[word.ToLanguage];
            questionLabel.Text = $"Translate the word {fromWord} from ({fromLang}) to ({toLang})";
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            _correct = 0;
            _questions = 0;
            scoreLabel.Text = _score;
            NextRound();
        }

        private void correctButton_Click(object sender, EventArgs e)
        {
            correct();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            correctButton.Enabled = !String.IsNullOrWhiteSpace(textBox1.Text);
        }

        private void correct()
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text)) return;
            string toWord = _word.Translations[_word.ToLanguage];
            if (String.Equals(textBox1.Text, toWord, StringComparison.CurrentCultureIgnoreCase)) _correct++;
            else MessageBox.Show($"Wrong the correct answear is: {toWord}");
            _questions++;
            textBox1.Text = "";
            scoreLabel.Text = _score;
            NextRound();
        }
    }
}
