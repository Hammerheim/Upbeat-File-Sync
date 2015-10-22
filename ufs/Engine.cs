using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ufs
{
  class Engine
  {
    public void Run(string source, string target)
    {
      Console.WriteLine($"Source: {source}");
      Console.WriteLine($"Target: {target}");
      Console.WriteLine("Running with no limitations on resources...");
      RecurseCopy(source, target);
    }

    private void RecurseCopy(string source, string target)
    {
      Thread.Sleep(100);
      Console.WriteLine(source);
      var sourceInfo = new DirectoryInfo(source);
      var targetInfo = new DirectoryInfo(target);

      if (!sourceInfo.Exists)
        throw new DirectoryNotFoundException(source);
      if (!targetInfo.Exists)
        targetInfo.Create();

      foreach (var file in sourceInfo.GetFiles())
      {
        if (!TryCopyFile(file, targetInfo))
          Console.WriteLine($"Filed to copy {file.FullName} to {targetInfo.FullName}");
        else
        {
          Console.Write(".");
        }
        Thread.Yield();
      }
      Console.WriteLine();

      foreach (var subDirectory in sourceInfo.GetDirectories())
      {
        RecurseCopy(subDirectory.FullName, Combine(targetInfo, subDirectory.Name));
      }

    }

    private bool TryCopyFile(FileInfo sourceFileInfo, DirectoryInfo targetDirectory)
    {
      var targetFileInfo = new FileInfo(Combine(targetDirectory, sourceFileInfo.Name));
      if (!targetFileInfo.Exists)
      {
        try
        {
          sourceFileInfo.CopyTo(targetFileInfo.FullName, true);
        }
        catch (Exception)
        {
          return false;
        }
      }

      if (targetFileInfo.Exists)
      {
        if (targetFileInfo.LastWriteTimeUtc < sourceFileInfo.LastWriteTimeUtc)
        {
          try
          {
            sourceFileInfo.CopyTo(targetFileInfo.FullName, true);
            Console.Write(".");
          }
          catch (Exception)
          {
            return false;
          }
        }
      }
      return true;
    }

    private string Combine(DirectoryInfo targetInfo, string name)
    {
      return Path.Combine(targetInfo.FullName, name);
    }
  }
}
