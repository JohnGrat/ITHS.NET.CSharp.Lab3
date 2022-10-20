using CommandLine;

namespace ConsoleApp6.Options
{
    [Verb("-count", HelpText = "<listname>")]
    internal class Count
    {
        [Value(0, Required = true, HelpText = "<listname>")]
        public string ListName { get; set; }
    }
}
