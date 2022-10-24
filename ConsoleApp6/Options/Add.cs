using CommandLine;

namespace ConsoleApp6.Options;

[Verb("-add", HelpText = "<listname>")]
internal class Add
{
    [Value(0, Required = true, HelpText = "-add <listname>")]
    public string ListName { get; set; }
}