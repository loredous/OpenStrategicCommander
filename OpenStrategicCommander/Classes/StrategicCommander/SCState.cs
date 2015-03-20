using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenStrategicCommander.Classes.StrategicCommander
{
    class SCState
    {
        public byte ButtonState;
        public byte ModifierState;

        public SCState(byte btnState, byte modState)
        {
            ButtonState = btnState;
            ModifierState = modState;
        }
    }
}
