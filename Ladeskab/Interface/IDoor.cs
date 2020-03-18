using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Interface
{
    public class DoorOpenTagChargedEventArgs : EventArgs
    {
        public bool state { get; set; }
    }


    public interface IDoor
    {
        event EventHandler<DoorOpenTagChargedEventArgs> DoorDataEvent;

        void LockDoor();
        void UnlockDoor();



    }
}


