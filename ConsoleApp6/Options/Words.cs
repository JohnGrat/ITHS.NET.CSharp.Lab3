using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.Options
{
    [Verb("-words", HelpText = "<listname> <sortByLanguage>")]
    internal class Words
    {
        [Value(0, Required = true, HelpText = "<listname>")]
        public string ListName { get; set; }
        [Value(1, Required = false, HelpText = "<sortByLanguage>")]
        public string sortByLanguage { get; set; } = "";
    }
}
