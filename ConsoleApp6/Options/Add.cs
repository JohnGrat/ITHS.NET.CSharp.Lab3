using CommandLine.Text;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.Options
{
    [Verb("-add", HelpText = "<listname>")]
    internal class Add
    {
        [Value(0, Required = true, HelpText = "-add <listname>")]
        public string ListName { get; set; }
    }
}
