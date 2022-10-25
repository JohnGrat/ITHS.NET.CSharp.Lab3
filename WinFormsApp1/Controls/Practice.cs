using Word;
using Word.Models;

namespace WinFormsApp1;

public partial class Practice : UserControl
{
    private readonly WordList _wordList;
    private int _correct;
    private int _questions;
    private WordModel _word;

    public Practice(WordList wordlist)
    {
        InitializeComponent();
        Dock = DockStyle.Fill;
        _wordList = wordlist;
        NextRound();
        textBox1.KeyDown += TextBox1_KeyDown;
    }

    private string _score =>
        $"You praticed {_questions} words with a successrate of {(double)_correct / _questions:P1}";

    private void TextBox1_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter) correct();
    }

    private void NextRound()
    {
        textBox1.Focus();
        var word = _wordList.GetWordToPractice();
        _word = word;
        var fromWord = word.Translations[word.FromLanguage];
        var fromLang = _wordList.Languages[word.FromLanguage];
        var toLang = _wordList.Languages[word.ToLanguage];
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
        correctButton.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text);
    }

    private void correct()
    {
        if (string.IsNullOrWhiteSpace(textBox1.Text)) return;
        var toWord = _word.Translations[_word.ToLanguage];
        if (string.Equals(textBox1.Text, toWord, StringComparison.CurrentCultureIgnoreCase)) _correct++;
        else MessageBox.Show($"Wrong the correct answear is: {toWord}");
        _questions++;
        textBox1.Text = "";
        scoreLabel.Text = _score;
        NextRound();
    }
}