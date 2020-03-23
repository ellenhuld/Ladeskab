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
        private string _message;
        public Display(string input)
        {
            _message = input;
        }

        public string GetMessage()
        {
            return _message;
        }

        public void DisplayMessage()
        {
            Console.WriteLine(_message);
        }
    }
}
