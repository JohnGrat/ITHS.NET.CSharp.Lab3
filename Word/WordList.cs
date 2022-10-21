﻿using Microsoft.VisualBasic.FileIO;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Word.Models;

namespace Word
{
    public class WordList
    {
        private static string _filePath { get; }
        private static string GetFilePath(string name) => _filePath + "\\" + name + ".dat";

        public string Name { get; }
        public string[] Languages { get; }
        private List<WordModel> _words { get; }

        public event Action<int>? SaveSuccess;

        public string ToString(char delimiter, int sortByIndex = 0)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Join(delimiter, Languages).ToUpper());
            List(sortByIndex, (translations => sb.AppendLine(String.Join(delimiter, translations))));
            return sb.ToString().Trim();
        }
        
        public WordList(string name, List<string[]> words, params string[] languages)
        {
            if ((languages.Distinct(StringComparer.OrdinalIgnoreCase).Count() < languages.Length))
                throw new Exception("list cant have two of the same language"); 
            Name = name;
            Languages = languages;
            _words = words.Select(translations => new WordModel(translations)).ToList();
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
            string[] translationsTrimed = translations.Select(word => word.Trim()).ToArray();
            _words.Add(new WordModel(translationsTrimed));
        }

        public bool Remove(int translation, string name)
        {
            int toBeDeleted = _words.RemoveAll(word => String.Equals(word.Translations[translation], name, StringComparison.OrdinalIgnoreCase));
            return toBeDeleted > 0 ? true : false;
        }

        public int Count => _words.Count();

        public void ClearWords() => _words.Clear();

        public void List(int sortByTranslation, Action<string[]> showTranslations)
        {
            CultureInfo culture = _words.Any(word => word.Translations.Any(word => new Regex(@"[äåöÄÅÖ]").IsMatch(word))) ? new CultureInfo("sv-SE") : CultureInfo.CurrentCulture;
            List<WordModel> SortedList = _words.OrderBy(word => word.Translations[sortByTranslation], StringComparer.Create(culture, false)).ToList();
            foreach (WordModel word in SortedList) showTranslations?.Invoke(word.Translations);
        }

        public WordModel GetWordToPractice()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(_words.Count);
            int[] randomIndex = _words[randomNumber].Translations.Select((word, index) => index).OrderBy(index => rnd.Next()).Take(2).ToArray();
            return new WordModel(randomIndex[0], randomIndex[1], _words[randomNumber].Translations);
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
                    fields.Add(parser.ReadFields()!.Where(field => !String.IsNullOrWhiteSpace(field)).ToArray());
                }
                return new WordList(fileName, fields.Skip(1).ToList(), fields.First());
            }
        }
    }
}
