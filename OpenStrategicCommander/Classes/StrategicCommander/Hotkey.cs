using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenStrategicCommander.Classes.StrategicCommander
{
    [Serializable()]
    class Hotkey
    {
        Keys _KeyValue = Keys.None;
        bool _Repeat = false;
        byte _Modifiers = 0;

        public Hotkey(Keys KeyValue, byte Modifiers)
        {
            _KeyValue = KeyValue;
            _Modifiers = Modifiers;
        }

        public void Send()
        {
            SendKeys.SendWait(_KeyValue.ToString());
        }

        public byte Modifiers
        {
            get { return _Modifiers; }
        }

        public Keys KeyValue
        {
            get { return _KeyValue; }
        }
    }
}
