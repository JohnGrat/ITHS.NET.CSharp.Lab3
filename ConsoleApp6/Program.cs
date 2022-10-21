using CommandLine;
using Word;
using ConsoleApp6.Options;
using Word.Models;

try
{
    ParserResult<object> result = Parser.Default.ParseArguments<New, Lists, Add, Remove, Count, Words, Practice>(args);
    result.WithParsed<Lists>(o => RunPrintLists());
    result.WithParsed<New>(o => RunNewlist(o));
    result.WithParsed<Add>(o => RunAddEntry(o));
    result.WithParsed<Remove>(o => RunRemoveWord(o));
    result.WithParsed<Count>(o => RunCountWords(o));
    result.WithParsed<Words>(o => RunPrintWords(o));
    result.WithParsed<Practice>(o => RunPraticeWords(o));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

void RunPrintLists() => Array.ForEach(WordList.GetLists(), x => Console.WriteLine(x));

void RunNewlist(New opts)
{
    if (WordList.GetLists().Contains(opts.ListName)) throw new Exception("Listname already in use");
    WordList newList = new WordList(opts.ListName, opts.Languages as string[]);
    newList.Save();
    RunAddEntry(new Add() { ListName = newList.Name });
}

void RunAddEntry(Add opts)
{
    WordList list = WordList.LoadList(opts.ListName);
    int newWords = 0;
    while (true)
    {
        Console.WriteLine("New word");
        List<string> words = new List<string>();
        foreach (string item in list.Languages)
        {
            Console.WriteLine($"Write the the word in {item}");
            string input = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(input)) goto End;
            words.Add(input);
        }
        newWords++;
        list.Add(words.ToArray());
    }
    End:
    Console.WriteLine($"You added {newWords} words");
    list.Save();
}

void RunRemoveWord(Remove opts)
{
    WordList list = WordList.LoadList(opts.ListName);
    int index = Array.FindIndex(list.Languages, (x) => String.Equals(x, opts.LangName, StringComparison.OrdinalIgnoreCase));
    foreach (string word in opts.Words)
    {
        if(!list.Remove(index, word)) Console.WriteLine($"{word} doesnt exist");
    }
    list.Save();
}

void RunPrintWords(Words opts)
{
    WordList list = WordList.LoadList(opts.ListName);
    int langIndex = String.IsNullOrWhiteSpace(opts.sortByLanguage) ? 0 : Array.FindIndex(list.Languages, (x) => String.Equals(x, opts.sortByLanguage, StringComparison.OrdinalIgnoreCase));
    if(langIndex == -1) throw new ArgumentException($"{opts.ListName} does not have language {opts.sortByLanguage}");
    Console.WriteLine(String.Join('\t', list.Languages));
    list.List(langIndex, (x) => Console.WriteLine(String.Join('\t', x)));
}

void RunCountWords(Count opts) => Console.WriteLine(WordList.LoadList(opts.ListName).Count);

void RunPraticeWords(Practice opts)
{
    WordList list = WordList.LoadList(opts.ListName);
    int count = 0, success = 0;
    while (true)
    {
        WordModel word = list.GetWordToPractice();
        string question = word.Translations[word.FromLanguage];
        string answear = word.Translations[word.ToLanguage];
        Console.WriteLine($"Translate this word to {list.Languages[word.ToLanguage]} from {list.Languages[word.FromLanguage]}");
        Console.WriteLine($"the word is {question}");
        string input = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(input)) break;
        if(String.Equals(input, answear, StringComparison.OrdinalIgnoreCase)) success++;
        else Console.WriteLine($"Wrong the correct answear is {answear}");
        count++;
    }
    Console.WriteLine($"You praticed {count} with a successrate of {((double)success / count):P1}");
}
