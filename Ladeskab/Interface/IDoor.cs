using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Interface
{
    public class DoorOpenChangedEventArgs : EventArgs
    {
        public bool _state { get; set; }
    }


    public interface IDoor
    {
        event EventHandler<DoorOpenChangedEventArgs> DoorDataEvent;

        void LockDoor(bool State);
        void UnlockDoor();
    }
}


