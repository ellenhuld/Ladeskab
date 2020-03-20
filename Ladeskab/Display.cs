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
        public void DisplayMessage(string input)
        {
            Console.WriteLine(input);
        }
    }
}
