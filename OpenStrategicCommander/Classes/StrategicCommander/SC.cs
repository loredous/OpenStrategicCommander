using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;

namespace OpenStrategicCommander.Classes.StrategicCommander
{
    [Serializable()]
    public class SC : INotifyPropertyChanged
    {
        [field:NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;

        public enum Page2Features
        {
            GetStatus = 0x1111
        }

        [Flags]
        public enum Page1Features : short
        {
            NoLights = 0x0000,
            Button1Light = 0x0001,
            Button1Blink = 0x0002,
            Button2Light = 0x0004,
            Button2Blink = 0x0008,
            Button3Light = 0x0010,
            Button3Blink = 0x0020,
            Button4Light = 0x0040,
            Button4Blink = 0x0080,
            Button5Light = 0x0100,
            Button5Blink = 0x0200,
            Button6Light = 0x0400,
            Button6Blink = 0x0800,
            RecButtonLight = 0x1000,
            RecButtonBlink = 0x2000
        }
        

        [Flags]
        public enum Buttons
        {
            Button1 = 1,
            Button2 = 2,
            Button3 = 4,
            Button4 = 8,
            Button5 = 16,
            Button6 = 32,
            ButtonPlus = 64,
            ButtonMinus = 128
        }

        [Flags]
        public enum Modifiers
        {
            Alt1 = 1,
            Alt2 = 2,
            Alt3 = 4,
            Record = 8,
            Switch3 = 16,
            Switch2 = 32,
            Switch1 = 48
        }

        byte _ButtonState;
        byte _ModifierState;
        short _LightState;

        public Queue StateQueue = new Queue();

        public byte ButtonState
        {
            set { _ButtonState = value; }
            get { return _ButtonState; }
        }

        public byte ModifierState
        {
            set
            {_ModifierState = value;
            OnPropertyChanged("ModifierState");
            }
            get { return _ModifierState; }
        }

        public short LightState
        {
            set { _LightState = value; }
            get { return _LightState; }
        }

        SCButton[] SCButtons = new SCButton[8];

        public SC()
        {
            SCButtons[0] = new SCButton(SC.Buttons.Button1);
            SCButtons[1] = new SCButton(SC.Buttons.Button2);
            SCButtons[2] = new SCButton(SC.Buttons.Button3);
            SCButtons[3] = new SCButton(SC.Buttons.Button4);
            SCButtons[4] = new SCButton(SC.Buttons.Button5);
            SCButtons[5] = new SCButton(SC.Buttons.Button6);
            SCButtons[6] = new SCButton(SC.Buttons.ButtonPlus);
            SCButtons[7] = new SCButton(SC.Buttons.ButtonMinus);
        }

        public Keys GetHotkey(byte Modifiers,Buttons Button)
        {
            SCButton x = SCButtons.FirstOrDefault(b => b.Button == Button);
            return x.GetHotkey(Modifiers);
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public void AddHotKey(Buttons Button, byte Modifiers, Keys KeyCode)
        {
            SCButton x = SCButtons.FirstOrDefault(b => b.Button == Button);
            x.AddHotkey(KeyCode, Modifiers);
        }

        public void ButtonChanged(Buttons Button, byte Modifiers)
        {
            foreach(Buttons btn in Enum.GetValues(typeof(Buttons)))
            {
                if ((btn & Button) == btn)
                {
                    SCButton x = SCButtons.FirstOrDefault(b => b.Button == btn);
                    if (x.GetHotkey(Modifiers) != Keys.None && !x.Depressed)
                    {
                        SendKeys.SendWait(KeysToSendKeyString(x.GetHotkey(Modifiers)));
                    }
                    x.Depressed = !x.Depressed;
                }
            }
            
        }

        private string KeysToSendKeyString(Keys key)
        {
            string result = "";
            Keys JustKey = (key & Keys.KeyCode);
            Keys JustMod = (key & Keys.Modifiers);
            switch (JustKey)
            {
                case Keys.A:
                case Keys.B:
                case Keys.C:
                case Keys.D:
                case Keys.E:
                case Keys.F:
                case Keys.G:
                case Keys.H:
                case Keys.I:
                case Keys.J:
                case Keys.K:
                case Keys.L:
                case Keys.M:
                case Keys.N:
                case Keys.O:
                case Keys.P:
                case Keys.Q:
                case Keys.R:
                case Keys.S:
                case Keys.T:
                case Keys.U:
                case Keys.V:
                case Keys.W:
                case Keys.X:
                case Keys.Y:
                case Keys.Z:
                    result = JustKey.ToString();
                    break;
                case Keys.D0:
                case Keys.D1:
                case Keys.D2:
                case Keys.D4:
                case Keys.D5:
                case Keys.D6:
                case Keys.D7:
                case Keys.D8:
                case Keys.D9:
                    result = JustKey.ToString().Remove(0, 1);
                    break;
                case Keys.Delete:
                case Keys.Down:
                case Keys.End:
                case Keys.Enter:
                case Keys.F1:
                case Keys.F10:
                case Keys.F11:
                case Keys.F12:
                case Keys.F13:
                case Keys.F14:
                case Keys.F15:
                case Keys.F16:
                case Keys.F2:
                case Keys.F3:
                case Keys.F4:
                case Keys.F5:
                case Keys.F6:
                case Keys.F7:
                case Keys.F8:
                case Keys.F9:
                case Keys.Home:
                case Keys.Insert:
                case Keys.Left:
                case Keys.NumLock:
                case Keys.Up:
                case Keys.Right:
                case Keys.Tab:
                case Keys.Subtract:
                case Keys.CapsLock:
                    result = "{" + JustKey.ToString().ToUpper() + "}";
                    break;
                case Keys.NumPad0:
                case Keys.NumPad1:
                case Keys.NumPad2:
                case Keys.NumPad3:  
                case Keys.NumPad4:   
                case Keys.NumPad5:
                case Keys.NumPad6:
                case Keys.NumPad7:
                case Keys.NumPad8:
                case Keys.NumPad9:
                    result = JustKey.ToString().Remove(0, 6);
                    break;
                case Keys.OemMinus:
                    result = "-";
                    break;
                case Keys.OemPeriod:
                    result = ".";
                    break;
                case Keys.Oemcomma:
                    result = ",";
                    break;
                case Keys.Oemplus:
                    result = "+";
                    break;
                case Keys.PageDown:
                    result = "{PGDN}";
                    break;
                case Keys.PageUp:
                    result = "{PGUP}";
                    break;
                case Keys.PrintScreen:
                    result = "{PRTSC}";
                    break;
                case Keys.Scroll:
                    result = "{SCROLLLOCK}";
                    break;
                case Keys.Space:
                    result = " ";
                    break;
                case Keys.Back:
                    result = "{BACKSPACE}";
                    break;
            }
            if ((JustMod & Keys.Control) == Keys.Control)
            {
                result = "^(" + result + ")";
            }
            if ((JustMod & Keys.Shift) == Keys.Shift)
            {
                result = "+(" + result + ")";
            }
            if ((JustMod & Keys.Alt) == Keys.Alt)
            {
                result = "%(" + result + ")";
            }
            return result;
        }

    }
}
