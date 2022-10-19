using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.Options
{
    [Verb("-count", HelpText = "<listname>")]
    internal class Count
    {
        [Value(0, Required = true, HelpText = "<listname>")]
        public string ListName { get; set; }
    }
}
