using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upbeat.Backup.Engine
{
  public interface ITarget
  {
    void BuildFolderTree(ISource source);
  }
}
