﻿using Microsoft.VisualBasic.FileIO;
using System.Text;
using Word.Models;

namespace Word
{
    public class WordList
    {
        private static string _filePath { get; }
        private static string GetFilePath(string name) => _filePath + "\\" + name + ".dat";

        public string Name { get; }
        public string[] Languages { get; }
        private List<WordModel> Words { get; }

        public event Action<int>? SaveSuccess;

        public string ToString(char Delimiter)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Join(Delimiter, Languages));
            foreach (WordModel item in Words)
            {
                sb.AppendLine(String.Join(Delimiter, item.Translations));
            }
            return sb.ToString().Trim();
        }
        
        public WordList(string name, List<string[]> words, params string[] languages)
        {
            if (!(languages.Distinct().Count() == languages.Length))
                throw new Exception("list cant have two of the same language");

            Name = name;
            Languages = languages;
            Words = words.OrderBy(x => x.First()).Select(x => new WordModel(x)).ToList();
        }

        public WordList(string name, params string[] languages) : this(name, new List<string[]>(), languages)
        {
        }

        static WordList()
        {
            string local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string folderName = "Word";
            _filePath = Path.Combine(local, folderName);
            if(!Directory.Exists(_filePath)) Directory.CreateDirectory(_filePath);
        }

        public static string[] GetLists() => Directory.EnumerateFiles(_filePath, "*.dat").Select(f => Path.GetFileNameWithoutExtension(f)).ToArray();

        public static WordList LoadList(string name) => File.Exists(GetFilePath(name)) ? ParseFile(name) : throw new Exception("List does not exist");

        public void Save()
        {
            File.WriteAllText(GetFilePath(Name), ToString(';'));
            SaveSuccess?.Invoke(Count);
        }

        public void Add(params string[] translations)
        {
            if (Languages!.Count() != translations.Count()) new ArgumentException("Missing translations");
            string[] translationsTrimed = translations.Select(x => x.Trim()).ToArray();
            Words.Add(new WordModel(translationsTrimed));
        }

        public bool Remove(int translation, string word)
        {
            int toBeDeleted = Words.RemoveAll(x => x.Translations[translation] == word);
            return toBeDeleted > 0 ? true : false;
        }

        public int Count => Words.Count();

        public void ClearWords() => Words.Clear();

        public void List(int sortByTranslation, Action<string[]> showTranslations)
        {
            List<WordModel> SortedList = Words.OrderBy(x => x.Translations[sortByTranslation]).ToList();
            foreach (WordModel item in SortedList) showTranslations?.Invoke(item.Translations);
        }

        public WordModel GetWordToPractice()
        {
            Random rnd = new Random();
            int r = rnd.Next(Words.Count);
            int[] a = Words[r].Translations.Select((x, index) => index ).OrderBy(i => rnd.Next()).Take(2).ToArray();
            return new WordModel(a[0], a[1], Words[r].Translations);
        }

        public static void DeleteList(string name) => File.Delete(GetFilePath(name));

        private static WordList ParseFile(string fileName)
        {
            using (TextFieldParser parser = new TextFieldParser(GetFilePath(fileName)))
            {
                List<string[]> fields = new List<string[]>();
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    fields.Add(parser.ReadFields().Where(x => !String.IsNullOrWhiteSpace(x)).ToArray());
                }
                return new WordList(fileName, fields.Skip(1).ToList(), fields.First());
            }
        }
    }
}
