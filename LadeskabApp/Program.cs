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
            RFIDReader reader = new RFIDReader();
            Door door = new Door();
            Display display = new Display();
            USBCharger charger = new USBCharger();

            ChargeControl chargecontrol = new ChargeControl(charger);
            
            StationControl stationControl = new StationControl(reader, door, display, chargecontrol);
            

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
                        door.DoorOpen();
                        break;

                    case 'C':
                        door.DoorClose();
                        break;

                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();

                        int id = Convert.ToInt32(idString);
                        reader.Readtag(id);
                        break;
                    case 'T':
                        System.Console.WriteLine("Forbundet");
                        charger.Connected = true;
                        break;
                    case 'F':
                        System.Console.WriteLine("Ikke forbundet");
                        charger.Connected = false;
                        break;

                    default:
                        break;
                }

            } while (!finish);

        }

    }
    
}
