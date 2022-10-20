using CommandLine;

namespace ConsoleApp6.Options
{
    [Verb("-remove", HelpText = "<listname> <language> <word1> <word2> ...")]
    internal class Remove
    {
        [Value(0, Required = true, HelpText = "<listname>")]
        public string ListName { get; set; }
        [Value(1, Required = true, HelpText = "<language>")]
        public string LangName { get; set; }
        [Value(2, Min = 1, Required = true, HelpText = "<word> 1 or more ...")]
        public IEnumerable<string> Words { get; set; }
    }
}
