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
        private bool _lockState;
        public event EventHandler<DoorOpenChangedEventArgs> DoorOpenEvent;
        public event EventHandler<DoorCloseChangedEventArgs> DoorCloseEvent;


        public void LockDoor()
        {
            _lockState = true;
        }

        public void UnlockDoor()
        {
            _lockState = false;
        }
        

        public void DoorOpen()
        {
            DoorOpenChanged(new DoorOpenChangedEventArgs { _openstate = true });
        }

        public void DoorClose()
        {
            DoorCloseChanged(new DoorCloseChangedEventArgs { _closestate = true });
        }
        protected virtual void DoorOpenChanged(DoorOpenChangedEventArgs e)
        {
            DoorOpenEvent?.Invoke(this, e);
        }
        protected virtual void DoorCloseChanged(DoorCloseChangedEventArgs e)
        {
            DoorCloseEvent?.Invoke(this, e);
        }
    }

}
