using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upbeat.Backup.Engine
{
  class Source : ISource
  {
    private IFileSystemDiscovery fileSystemDiscovery;
    private DirectoryRoot root;

    public Source()
    {
      fileSystemDiscovery = new FileSystemDiscovery();
    }
    public async void DiscoverFolderTree(DirectoryInfo rootDirectoryInfo, Action<string, int> progressCallback)
    {
      root = await fileSystemDiscovery.Discover(rootDirectoryInfo, progressCallback);
    }
  }
}
