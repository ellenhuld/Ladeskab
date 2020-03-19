using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab;

namespace LadeskabApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Assemble your system here from all the classes
            
            
            
            

            bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("Indtast E, O, C, R: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'E':
                        finish = true;
                        break;

                    case 'O':
                        Door.DoorOpen();
                        break;

                    case 'C':
                        Door.DoorClose();
                        break;

                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();

                        int id = Convert.ToInt32(idString);
                        RFIDReader.OnRfidRead(id);
                        break;

                    default:
                        break;
                }

            } while (!finish);

        }

    }
    
}
