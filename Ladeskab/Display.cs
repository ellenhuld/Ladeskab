using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interface;

namespace Ladeskab
{
    public class Display:IDisplay
    {

        private IConsoleWrite _write;

        //property injection
        public Display(IConsoleWrite write)
        {
            _write = write;
        }

        public void DisplayMessage(string input)
        {
            _write.WriteLine(input);
        }
    }
}
