﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Ladeskab;
using Ladeskab.Interface;

namespace LadeskabApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Assemble your system here from all the classes
            RFIDReader reader = new RFIDReader();
            Door door = new Door();
            IConsoleWrite iWrite = new ConsoleWrite();
            Display display = new Display(iWrite);
            USBCharger charger = new USBCharger();

            TimeProvider timeprovider = new TimeProvider();
            FileWriter filewriter = new FileWriter();
            LogFile logfile = new LogFile(filewriter, timeprovider);

            ChargeControl chargecontrol = new ChargeControl(charger);
            
            StationControl stationControl = new StationControl(reader, door, display, chargecontrol, logfile);
            

            bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("Indtast E (exit), O (open door), C (close door), R (rfid id), T (mobil tilsluttet), F (mobil fjernet): ");
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
                        System.Console.WriteLine("Mobiltelefon forbundet");
                        charger.SimulateConnected(true);
                        break;
                    case 'F':
                        System.Console.WriteLine("Mobiltelefon ikke forbundet");
                        charger.SimulateConnected(false);
                        break;

                    default:
                        break;
                }

            } while (!finish);

        }

    }
    
}
