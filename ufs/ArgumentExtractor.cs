using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ufs
{
  class ArgumentExtractor
  {
    public bool TryGetDirectories(string[] args, out Arguments arguments)
    {
      arguments = new Arguments();

      string source = string.Empty;
      string target = string.Empty;
      if (!args.Any())
        return false;
      if (args.Length %2 != 0)
        return false;
      for (var i = 0; i < args.Length; i += 2)
      {        
        if (args[i].Substring(0, 8).ToLower() == "-source:")
          source = args[i].Substring(8);
        if (args[i].Substring(0, 8).ToLower() == "-target:")
          target = args[i].Substring(8);
        if (args[i+1].Substring(0, 8).ToLower() == "-source:")
          source = args[i+1].Substring(8);
        if (args[i+1].Substring(0, 8).ToLower() == "-target:")
          target = args[i+1].Substring(8);
        if ((source != target) && (source != string.Empty) && (target != string.Empty))
          arguments.SourceTargetPairs.Add(new SourceTargetPair {Source = source, Target = target});
        else
          return false;
        source = target = string.Empty;
      }
      return true;
    }
  }
}
