using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Interface
{
    public interface ILogfile
    {
        //void LogDoorLocked(int id);
        //void LogDoorUnlocked(int id);
        void LogMessage(string message);
    }
}
