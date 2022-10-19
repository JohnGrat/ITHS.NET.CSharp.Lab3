

using CommandLine.Text;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Word;
using ConsoleApp6.Options;
using System.Diagnostics.Metrics;
using Word.Model;

try
{
    ParserResult<object> result = Parser.Default.ParseArguments<New, Lists, Add, Remove, Count, Words, Practice>(args);
    result.MapResult(
      (Lists opts) => RunPrintLists(),
      (New opts) => RunNewlist(opts),
      (Add opts) => RunAddEntry(opts),
      (Remove opts) => RunRemoveWord(opts),
      (Count opts) => RunCountWords(opts),
      (Words opts) => RunPrintWords(opts),
      (Practice opts) => RunPraticeWords(opts),
      errs => 1);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

int RunPrintLists()
{
    foreach (var item in WordList.GetLists()) Console.WriteLine(item);
    return 0;
}

int RunNewlist(New opts)
{
    if (WordList.GetLists().Contains(opts.ListName)) throw new Exception("Listname already in use");
    WordList newList = new WordList(opts.ListName, opts.Languages.ToArray());
    newList.Save();
    RunAddEntry(new Add() { ListName = newList.Name });
    return 0;
}

int RunAddEntry(Add opts)
{
    WordList list = WordList.LoadList(opts.ListName);
    int count = 0;
    while (true)
    {
        Console.WriteLine("New word");
        List<string> words = new List<string>();
        foreach (var item in list.Languages)
        {
            Console.WriteLine($"Write the the word in {item}");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) goto End;
            words.Add(input);
        }
        list.Add(words.ToArray());
        count++;
    }
    End:
    Console.WriteLine($"You added {count} words");
    list.Save();
    return 0;
}

int RunRemoveWord(Remove opts)
{
    WordList list = WordList.LoadList(opts.ListName);
    int index = Array.IndexOf(list.Languages, opts.LangName);
    foreach (var word in opts.Words)
    {
        if(!list.Remove(index, word)) Console.WriteLine($"{word} doesnt exist");
    }
    list.Save();
    return 0;
}

int RunPrintWords(Words opts)
{
    WordList list = WordList.LoadList(opts.ListName);
    if (!string.IsNullOrEmpty(opts.sortByLanguage))
    {
        if (!list.Languages.Contains(opts.sortByLanguage)) throw new ArgumentException($"{opts.ListName} does not have language {opts.sortByLanguage}");
        int index = Array.IndexOf(list.Languages, opts.sortByLanguage);
        Console.WriteLine(String.Join('\t', list.Languages));
        list.List(index, (x) => Console.WriteLine(String.Join('\t', x)));
    }
    else
        Console.WriteLine(list.ToString('\t'));
    return 0;
}

int RunCountWords(Count opts)
{
    WordList list = WordList.LoadList(opts.ListName);
    Console.WriteLine(list.Count);
    return 0;
}

int RunPraticeWords(Practice opts)
{
    WordList list = WordList.LoadList(opts.ListName);
    int count = 0, success = 0;
    while (true)
    {
        WordModel word = list.GetWordToPractice();
        string question = word.Translations[word.FromLanguage];
        string answear = word.Translations[word.ToLanguage];
        Console.WriteLine($"Translate this word to {list.Languages[word.FromLanguage]} to {list.Languages[word.ToLanguage]}");
        Console.WriteLine($"the word is {question}");
        string input = Console.ReadLine();
        if (string.IsNullOrEmpty(input)) goto End;
        if (input == answear) success++;
        else Console.WriteLine($"Wrong the correct answear is {answear}");
        count++;
    }
    End:
    Console.WriteLine($"You praticed {count} with a successrate of {((double)success / count):P1}");
    return 0;
}
