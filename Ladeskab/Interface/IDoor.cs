using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Interface
{
    public class DoorOpenChangedEventArgs : EventArgs
    {
        public bool _openstate { get; set; }
    }

    public class DoorCloseChangedEventArgs:EventArgs
    {
        public bool _closestate { get; set; }
    }

    public interface IDoor
    {
        event EventHandler<DoorOpenChangedEventArgs> DoorOpenEvent;

        event EventHandler<DoorCloseChangedEventArgs> DoorCloseEvent;

        string LockDoor();
        string UnlockDoor();
        void DoorOpen();
        void DoorClose();
    }
}


