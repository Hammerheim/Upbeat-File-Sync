using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ufs
{
  class Program
  {
    static void Main(string[] args)
    {
      Arguments arguments;
      var argumentExtractor = new ArgumentExtractor();
      if (argumentExtractor.TryGetDirectories(args, out arguments))
      {
        var engine = new Engine();
        Console.WriteLine("Running...");
        foreach (var pair in arguments.SourceTargetPairs)
          engine.Run(pair.Source, pair.Target);
      }
    }
  }
}
