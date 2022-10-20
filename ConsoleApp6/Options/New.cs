using CommandLine;

namespace ConsoleApp6.Options
{
    [Verb("-new", HelpText = "<listname> <language1> <language2> ...")]
    internal class New
    {

        [Value(0, Required = true, HelpText = "<listname>")]
        public string ListName { get; set; }

        [Value(1, Min = 2, Required = true, HelpText = "<language> 2 or more ...")]
        public IEnumerable<string> Languages { get ; set; }
    }
}
