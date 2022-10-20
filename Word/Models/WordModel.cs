using System.ComponentModel.DataAnnotations;

namespace Word.Models
{
    public class WordModel
    {
        [Required, MinLength(2)]
        public string[] Translations { get; set; }
        public int FromLanguage { get; }
        public int ToLanguage { get; }

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
    }
}
