using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenStrategicCommander.Classes.StrategicCommander
{   
    [Serializable()]
    class SCButton
    {
        public bool Depressed = false;
        SC.Buttons _Button;
        List<Hotkey> Hotkeys = new List<Hotkey>();

        public SCButton(SC.Buttons Button)
        {
            _Button = Button;
        }

        public void AddHotkey(Keys KeyValue, byte Modifiers)
        {
            RemoveHotkey(Modifiers);
            Hotkeys.Add(new Hotkey(KeyValue,Modifiers));
        }

        public Keys GetHotkey(byte Modifiers)
        {
            Hotkey result = Hotkeys.FirstOrDefault(h => h.Modifiers == Modifiers);
            if (result != null)
            {
                return result.KeyValue;
            }
            else
            {
                return Keys.None;
            }
        }

        public void RemoveHotkey(byte Modifiers)
        {
            Hotkey result = Hotkeys.FirstOrDefault(h => h.Modifiers == Modifiers);
            Hotkeys.Remove(result);
        }

        public SC.Buttons Button
        {
            get { return _Button; }
        }
    }
}
