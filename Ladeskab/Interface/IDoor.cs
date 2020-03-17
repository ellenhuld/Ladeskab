﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Interface
{
    public interface IDoor
    {
        void LockDoor();
        void UnlockDoor();
        event DoorOpenEvent();
        event DoorCloseEvent();

    }

}
