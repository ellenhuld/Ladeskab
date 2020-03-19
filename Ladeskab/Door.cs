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
        public event EventHandler<DoorOpenChangedEventArgs> DoorOpenEvent;
        public event EventHandler<DoorCloseChangedEventArgs> DoorCloseEvent;


        public void LockDoor(bool state)
        {
            LockDoorChanged(new DoorOpenChangedEventArgs { _openstate = state });
            State = state;
        }

        public void UnlockDoor(bool state)
        {
            UnlockDoorChanged(new DoorCloseChangedEventArgs { _closestate = state });
            State = state;
        }
        protected virtual void LockDoorChanged(DoorOpenChangedEventArgs e)
        {
            DoorOpenEvent?.Invoke(this, e);
        }
        protected virtual void UnlockDoorChanged(DoorCloseChangedEventArgs e)
        {
            DoorCloseEvent?.Invoke(this, e);
        }
    }

}
