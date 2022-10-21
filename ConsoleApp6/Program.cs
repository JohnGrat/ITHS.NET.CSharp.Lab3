using CommandLine;
using Word;
using ConsoleApp6.Options;
using Word.Models;
using System.Collections.Generic;

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
    if (WordList.GetLists().Contains(opts.ListName, StringComparer.OrdinalIgnoreCase)) throw new Exception("Listname already in use");
    new WordList(opts.ListName, opts.Languages as string[]).Save();
    RunAddEntry(new Add() { ListName = opts.ListName });
}

void RunAddEntry(Add opts)
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
            if (String.IsNullOrWhiteSpace(input)) goto End;
            translations.Add(input);
        }
        newWords++;
        list.Add(translations.ToArray());
    }
    End:
    Console.WriteLine($"You added {newWords} words");
    list.Save();
}

void RunRemoveWord(Remove opts)
{
    WordList list = WordList.LoadList(opts.ListName);
    int langIndex = GetLanguageIndex(list.Languages, opts.LangName);
    foreach (string word in opts.Words)
    {
        if(!list.Remove(langIndex, word)) Console.WriteLine($"{word} doesnt exist");
    }
    list.Save();
}

void RunPrintWords(Words opts)
{
    WordList list = WordList.LoadList(opts.ListName);
    int langIndex = String.IsNullOrWhiteSpace(opts.sortByLanguage) ? 0 : GetLanguageIndex(list.Languages, opts.sortByLanguage);
    Console.WriteLine(list.ToString('\t', langIndex));
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

int GetLanguageIndex(string[] languages, string langName)
{
    int index = Array.FindIndex(languages, (name) => String.Equals(name, langName, StringComparison.OrdinalIgnoreCase));
    return index == -1 ? throw new ArgumentException($"the list does not have language {langName}") : index;
}