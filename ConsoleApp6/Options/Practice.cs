using CommandLine;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.Options
{
    [Verb("-practice", HelpText = "<listname>")]
    internal class Practice
    {
      [Value(0, Required = true, HelpText = "<listname>")]
      public string ListName { get; set; }
    }
}
