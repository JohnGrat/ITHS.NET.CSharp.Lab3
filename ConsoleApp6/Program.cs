using CommandLine;
using ConsoleApp6.Options;
using Word;
using Word.Models;

try
{
    ParserResult<object> result = Parser.Default.ParseArguments<New, Lists, Add, Remove, Count, Words, Practice>(args);
    result.WithParsed<Lists>(o => PrintLists());
    result.WithParsed<New>(o => NewList(o));
    result.WithParsed<Add>(o => AddEntry(o));
    result.WithParsed<Remove>(o => RemoveWord(o));
    result.WithParsed<Count>(o => CountWords(o));
    result.WithParsed<Words>(o => PrintWords(o));
    result.WithParsed<Practice>(o => PracticeWords(o));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

void PrintLists()
{
    Array.ForEach(WordList.GetLists(), name => Console.WriteLine(name));
}

void NewList(New opts)
{
    if (WordList.GetLists().Contains(opts.ListName, StringComparer.OrdinalIgnoreCase))
        throw new Exception("Name already in use");
    new WordList(opts.ListName, opts.Languages as string[]).Save();
    AddEntry(new Add { ListName = opts.ListName });
}

void AddEntry(Add opts)
{
    WordList list = WordList.LoadList(opts.ListName);
    int newWords = 0;
    while (true)
    {
        Console.WriteLine("New word");
        List<string> translations = new List<string>();
        foreach (string language in list.Languages)
        {
            Console.WriteLine($"Write the the word in {language}");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) goto End;
            translations.Add(input);
        }

        newWords++;
        list.Add(translations.ToArray());
    }

    End:
    Console.WriteLine($"You added {newWords} words");
    list.Save();
}

void RemoveWord(Remove opts)
{
    WordList list = WordList.LoadList(opts.ListName);
    int langIndex = GetLanguageIndex(list.Languages, opts.LangName);
    Array.ForEach(opts.Words.ToArray(), word =>
        Console.WriteLine(list.Remove(langIndex, word) ? $"{word} removed" : $"{word} doesn't exist"));
    list.Save();
}

void PrintWords(Words opts)
{
    WordList list = WordList.LoadList(opts.ListName);
    int langIndex = string.IsNullOrWhiteSpace(opts.sortByLanguage)
        ? 0
        : GetLanguageIndex(list.Languages, opts.sortByLanguage);
    Console.WriteLine(list.ToString(langIndex, true));
}

void CountWords(Count opts)
{
    Console.WriteLine(WordList.LoadList(opts.ListName).Count);
}

void PracticeWords(Practice opts)
{
    WordList list = WordList.LoadList(opts.ListName);
    int count = 0, success = 0;
    while (true)
    {
        WordModel word = list.GetWordToPractice();
        string question = word.Translations[word.FromLanguage];
        string answer = word.Translations[word.ToLanguage];
        Console.WriteLine(
            $"Translate this word to {list.Languages[word.ToLanguage]} from {list.Languages[word.FromLanguage]}");
        Console.WriteLine($"the word is {question}");
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) break;
        if (string.Equals(input, answer, StringComparison.OrdinalIgnoreCase)) success++;
        else Console.WriteLine($"Wrong the correct answer is {answer}");
        count++;
    }

    Console.WriteLine($"You practiced {count} with a success rate of {(double)success / count:P1}");
}

int GetLanguageIndex(string[] languages, string langName)
{
    int index = Array.FindIndex(languages, name => string.Equals(name, langName, StringComparison.OrdinalIgnoreCase));
    return index == -1 ? throw new ArgumentException($"the list does not have language {langName}") : index;
}