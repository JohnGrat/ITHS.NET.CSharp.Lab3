namespace Word.Models;

public class WordModel
{
    public WordModel(params string[] translations)
    {
        Translations = translations;
    }

    public WordModel(int fromLanguage, int toLanguage, params string[] translations)
    {
        FromLanguage = fromLanguage;
        ToLanguage = toLanguage;
        Translations = translations;
    }

    public string[] Translations { get; set; }
    public int FromLanguage { get; }
    public int ToLanguage { get; }
}