using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interface;

namespace Ladeskab
{
    public class ConsoleWrite : IConsoleWrite
    {
        public void WriteLine(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}
