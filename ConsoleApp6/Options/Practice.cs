using CommandLine;

namespace ConsoleApp6.Options;

[Verb("-practice", HelpText = "<listname>")]
internal class Practice
{
    [Value(0, Required = true, HelpText = "<listname>")]
    public string ListName { get; set; }
}