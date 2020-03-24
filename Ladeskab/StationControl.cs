using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interface;

namespace Ladeskab
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        public int _oldId { set; get; }

        private IReader _reader { get; set; }
        private IDoor _door { get; set; }
        private IDisplay _display { get; set; }
        //private ICharge _charge { get; set; }
        private IChargeControl _chargeControl { get; set; }
        private ILogfile _logFile { get; set; }

        //public bool door { get; set; }

        private string logFile = "logfile.txt"; // Navnet på systemets log-fil

        // Her mangler constructor
        public StationControl(IReader reader, IDoor door, IDisplay display, IChargeControl chargecontrol, ILogfile logfile)
        {
            _reader = reader;
            _door = door;
            _display = display;
            _chargeControl = chargecontrol;
            _logFile = logfile;

            _door.DoorOpenEvent += HandleDoorOpenEvent;
            _door.DoorCloseEvent += HandleDoorCloseEvent;
            _reader.TagDataEvent += HandleRfidDetected;
        }

        private void HandleDoorCloseEvent(object sender, DoorCloseChangedEventArgs e)
        {
            DoorClose();
        }

        private void HandleDoorOpenEvent(object sender, DoorOpenChangedEventArgs e)
        {
            DoorOpen();
        }

        private void HandleRfidDetected(object sender, ReadtagChangedEventArgs e)
        {
            RfidDetected(e.Tag);
        }

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        private void RfidDetected(int id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_chargeControl.IsConnected()==true)
                    {
                        _door.LockDoor();
                        _display.DisplayMessage("Døren er låst");
                        _chargeControl.Regulate();
                        _oldId = id;
                        _logFile.LogMessage("Skab låst med RFID: "+id+"");
                        _display.DisplayMessage("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        _display.DisplayMessage("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (CheckId(_oldId, id))
                    {
                        _chargeControl.Regulate();
                        _door.UnlockDoor();
                        _display.DisplayMessage("Døren er låst op");
                        _logFile.LogMessage("Skab låst op med RFID: " + id + "");
                        _display.DisplayMessage("Tag din telefon ud af skabet og luk døren");
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        _display.DisplayMessage("Forkert RFID tag");
                    }

                    break;
            }
        }

        private bool CheckId(int oldId, int id)
        {
            return oldId == id;
        }

        // Her mangler de andre trigger handlere
        private void DoorClose()
        {
            switch (_state)
            {
                case LadeskabState.DoorOpen:
                    //door = e._closestate;
                    _state = LadeskabState.Available;
                    _display.DisplayMessage("Indlæs RFID");
                    break;

                case LadeskabState.Available:
                case LadeskabState.Locked:
                    // Ignore
                    break;
            }
        }

        private void DoorOpen()
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    //door = e._openstate;
                    _state = LadeskabState.DoorOpen;
                    _display.DisplayMessage("Tilslut telefon");
                    break;

                case LadeskabState.Locked:
                case LadeskabState.DoorOpen:
                    // Ignore
                    break;
            }
        }
    }
}

