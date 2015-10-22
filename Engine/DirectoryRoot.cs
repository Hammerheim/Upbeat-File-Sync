using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upbeat.Backup.Engine
{
  class DirectoryRoot
  {
    public DirectoryRoot(DirectoryInfo root)
    {
      if (root == null)
        throw new ArgumentNullException(nameof(root));
      SetRoot(root);
    }

    void SetRoot(DirectoryInfo root)
    {
      Root = root;
      ShortName = root.Name;
      FullyQualifiedPath = root.FullName;
    }

    public DirectoryInfo Root { get; protected set; }
    public string ShortName { get; protected set; }
    public string FullyQualifiedPath { get; protected set; }
  }
}
