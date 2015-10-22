using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upbeat.Backup.Engine
{
  class FileSystemDiscovery : IFileSystemDiscovery
  {
    public async Task<DirectoryRoot> Discover(DirectoryInfo root, Action<string, int> progressCallback)
    {
      
    }
  }
}
