using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Word.Models;

namespace Word;

public class WordList
{
    static WordList()
    {
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var folderName = "Word";
        _filePath = Path.Combine(appDataPath, folderName);
        if (!Directory.Exists(_filePath)) Directory.CreateDirectory(_filePath);
    }

    public WordList(string name, List<string[]> words, params string[] languages)
    {
        if (languages.Length < 2)
            throw new Exception("list needs to have at least 2 languages");
        Name = name;
        Languages = languages;
        _words = words.Select(translations => new WordModel(translations)).ToList();
    }

    public WordList(string name, params string[] languages) : this(name, new List<string[]>(), languages)
    {
    }

    private static string _filePath { get; }

    public string Name { get; }
    public string[] Languages { get; }
    private List<WordModel> _words { get; }

    public int Count => _words.Count();

    private int GetLongestStringLength()
    {
        var strings = new List<string>();
        strings.AddRange(Languages);
        strings.AddRange(_words.SelectMany(word => word.Translations));
        return strings.Max(@string => @string.Length);
    }

    private static string GetFilePath(string name)
    {
        return _filePath + "\\" + name + ".dat";
    }

    public event Action<int>? SaveSuccess;

    public string ToString(int sortByIndex = 0, bool usePadding = false)
    {
        var delimiter = usePadding ? '\0' : ';';
        var padding = usePadding ? GetLongestStringLength() + 1 : 0;
        var dataTable = new StringBuilder();
        dataTable.AppendLine(string.Join(delimiter,
            Languages.Append("").Select(field => field.PadRight(padding).ToUpper()).ToArray()));
        List(sortByIndex,
            translations => dataTable.AppendLine(string.Join(delimiter,
                translations.Append("").Select(field => field.PadRight(padding)).ToArray())));
        return dataTable.ToString().Trim();
    }

    public static string[] GetLists()
    {
        return Directory.EnumerateFiles(_filePath, "*.dat").Select(f => Path.GetFileNameWithoutExtension(f)).ToArray();
    }

    public static WordList LoadList(string name)
    {
        return File.Exists(GetFilePath(name)) ? ParseFile(name) : throw new Exception("List does not exist");
    }

    public void Save()
    {
        File.WriteAllText(GetFilePath(Name), ToString());
        SaveSuccess?.Invoke(Count);
    }

    public void Add(params string[] translations)
    {
        if (translations.Length < Languages.Length) new ArgumentException("Missing translations");
        var translationsTrimmed = translations.Select(word => word.Trim()).ToArray();
        _words.Add(new WordModel(translationsTrimmed));
    }

    public bool Remove(int translation, string name)
    {
        var toBeDeleted = _words.RemoveAll(word =>
            string.Equals(word.Translations[translation], name, StringComparison.OrdinalIgnoreCase));
        return toBeDeleted > 0;
    }

    public void ClearWords()
    {
        _words.Clear();
    }

    public void List(int sortByTranslation, Action<string[]> showTranslations)
    {
        var culture = _words.Any(word => word.Translations.Any(word => new Regex(@"[äåöÄÅÖ]").IsMatch(word)))
            ? new CultureInfo("sv-SE")
            : CultureInfo.CurrentCulture;
        var wordsSorted = _words
            .OrderBy(word => word.Translations[sortByTranslation], StringComparer.Create(culture, false)).ToArray();
        Array.ForEach(wordsSorted, word => showTranslations?.Invoke(word.Translations));
    }

    public WordModel GetWordToPractice()
    {
        var rnd = new Random();
        var randomNumber = rnd.Next(_words.Count);
        var randomIndex = _words[randomNumber].Translations.Select((word, index) => index)
            .OrderBy(index => rnd.Next()).Take(2).ToArray();
        return new WordModel(randomIndex[0], randomIndex[1], _words[randomNumber].Translations);
    }

    public static void DeleteList(string name)
    {
        File.Delete(GetFilePath(name));
    }

    private static WordList ParseFile(string fileName)
    {
        var delimiter = ';';
        var file = File.ReadAllLines(GetFilePath(fileName));
        var headers = file.FirstOrDefault().Split(delimiter).SkipLast(1).ToArray();
        var fields = file.Skip(1).Select(row => row.Split(delimiter).SkipLast(1).ToArray()).ToList();
        return new WordList(fileName, fields, headers);
    }
}