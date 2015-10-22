using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ufs
{
  class Arguments
  {
    public Arguments()
    {
      SourceTargetPairs = new List<SourceTargetPair>();
    }
    public List<SourceTargetPair> SourceTargetPairs { get; set; }
  }
}
