using CommandLine;
using ConsoleApp6.Options;
using Word;

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
    var selectedList = WordList.LoadList(opts.ListName);
    var newWordsCounter = 0;
    while (true)
    {
        Console.WriteLine("New word");
        var translations = new List<string>();
        foreach (var language in selectedList.Languages)
        {
            Console.WriteLine($"Write the the word in {language}");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) goto End;
            translations.Add(input);
        }

        newWordsCounter++;
        selectedList.Add(translations.ToArray());
    }

    End:
    Console.WriteLine($"You added {newWordsCounter} words");
    selectedList.Save();
}

void RemoveWord(Remove opts)
{
    var selectedList = WordList.LoadList(opts.ListName);
    var langIndex = GetLanguageIndex(selectedList.Languages, opts.LangName);
    Array.ForEach(opts.Words.ToArray(), word =>
        Console.WriteLine(selectedList.Remove(langIndex, word) ? $"{word} removed" : $"{word} doesn't exist"));
    selectedList.Save();
}

void PrintWords(Words opts)
{
    var selectedList = WordList.LoadList(opts.ListName);
    var langIndex = string.IsNullOrWhiteSpace(opts.sortByLanguage)
        ? 0
        : GetLanguageIndex(selectedList.Languages, opts.sortByLanguage);
    Console.WriteLine(selectedList.ToString(langIndex, true));
}

void CountWords(Count opts)
{
    Console.WriteLine(WordList.LoadList(opts.ListName).Count);
}

void PracticeWords(Practice opts)
{
    var selectedList = WordList.LoadList(opts.ListName);
    int questionCounter = 0, successCounter = 0;
    while (true)
    {
        var word = selectedList.GetWordToPractice();
        var question = word.Translations[word.FromLanguage];
        var answer = word.Translations[word.ToLanguage];
        Console.WriteLine(
            $"Translate this word to {selectedList.Languages[word.ToLanguage]} from {selectedList.Languages[word.FromLanguage]}");
        Console.WriteLine($"the word is {question}");
        var input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) break;
        if (string.Equals(input, answer, StringComparison.OrdinalIgnoreCase)) successCounter++;
        else Console.WriteLine($"Wrong the correct answer is {answer}");
        questionCounter++;
    }

    Console.WriteLine($"You practiced {questionCounter} with a success rate of {(double)successCounter / questionCounter:P1}");
}

int GetLanguageIndex(string[] languages, string langName)
{
    var index = Array.FindIndex(languages, name => string.Equals(name, langName, StringComparison.OrdinalIgnoreCase));
    return index == -1 ? throw new ArgumentException($"the list does not have language {langName}") : index;
}