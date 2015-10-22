using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upbeat.Backup.Engine
{
  public interface ISource
  {
    void DiscoverFolderTree(DirectoryInfo rootDirectoryInfo, Action<string, int> progressCallback);
  }
}
