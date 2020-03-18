using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interface;

namespace Ladeskab
{
    public class Door:IDoor
    {
        private bool State;
        public event EventHandler<DoorOpenChangedEventArgs> DoorDataEvent;


        public void LockDoor(bool state)
        {
            LockDoorChanged(new DoorOpenChangedEventArgs { _state = state });
            State = state;
        }

        public void UnlockDoor()
        {

        }
        protected virtual void LockDoorChanged(DoorOpenChangedEventArgs e)
        {
            DoorDataEvent?.Invoke(this, e);
        }
    }

}
