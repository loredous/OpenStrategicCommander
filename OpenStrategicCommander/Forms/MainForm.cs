using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UsbHid;
using OpenStrategicCommander.Classes.StrategicCommander;
using OpenStrategicCommander.Controls;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OpenStrategicCommander.Forms
{
    public partial class MainForm : Form
    {
        public UsbHidDevice Device;
        SC Commander;
        private BackgroundWorker KeySender = new BackgroundWorker();

        public MainForm()
        {
            InitializeComponent();
        }

        private void UpdateForm()
        {
            short lightson = 0;
            foreach (CmdrButton btn in btnPanel.Controls)
            {
                ThreadSafe(() => btn.Text = btn.TextTemplate.Replace("#", Commander.GetHotkey(Commander.ModifierState, btn.WhichButton).ToString()));
                if (Commander.GetHotkey(Commander.ModifierState, btn.WhichButton) != Keys.None)
                {
                    lightson += (short)btn.LightFeature;
                }
            }
            ThreadSafe(() => radMod1.Checked = ((SC.Modifiers)Commander.ModifierState & SC.Modifiers.Alt1) == SC.Modifiers.Alt1);
            ThreadSafe(() => radMod2.Checked = ((SC.Modifiers)Commander.ModifierState & SC.Modifiers.Alt2) == SC.Modifiers.Alt2);
            ThreadSafe(() => radMod3.Checked = ((SC.Modifiers)Commander.ModifierState & SC.Modifiers.Alt3) == SC.Modifiers.Alt3);
            int sliderval = 1;
            if (((SC.Modifiers)Commander.ModifierState & SC.Modifiers.Switch1) == SC.Modifiers.Switch1)
            {
                sliderval = 1;
            }
            else if (((SC.Modifiers)Commander.ModifierState & SC.Modifiers.Switch2) == SC.Modifiers.Switch2)
            {
                sliderval = 2;
            }
            else if (((SC.Modifiers)Commander.ModifierState & SC.Modifiers.Switch3) == SC.Modifiers.Switch3)
            {
                sliderval = 3;
            }
            ThreadSafe(() => trkSwitch.Value = sliderval);
            ThreadSafe(() => lblSwitchState.Text = string.Format("Switch {0}",sliderval.ToString()));
            Device.SetFeature(1,BitConverter.GetBytes(lightson));
            Commander.LightState = lightson;
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            Commander = new SC();
            KeySender.WorkerSupportsCancellation = true;
            KeySender.DoWork += new DoWorkEventHandler(KeySender_DoWork);
            KeySender.RunWorkerAsync();
            Device = new UsbHidDevice(0x045E, 0x0033);
            Device.OnConnected += DeviceOnConnected;
            Device.OnDisConnected += DeviceOnDisConnected;
            Device.DataReceived += DeviceDataReceived;
            Device.Connect();
            btn1.WhichButton = SC.Buttons.Button1;
            btn1.TextTemplate = "1 (#)";
            btn1.LightFeature = SC.Page1Features.Button1Light;
            btn1.BlinkFeature = SC.Page1Features.Button1Blink;
            btn2.WhichButton = SC.Buttons.Button2;
            btn2.TextTemplate = "2 (#)";
            btn2.LightFeature = SC.Page1Features.Button2Light;
            btn2.BlinkFeature = SC.Page1Features.Button2Blink;
            btn3.WhichButton = SC.Buttons.Button3;
            btn3.TextTemplate = "3 (#)";
            btn3.LightFeature = SC.Page1Features.Button3Light;
            btn3.BlinkFeature = SC.Page1Features.Button3Blink;
            btn4.WhichButton = SC.Buttons.Button4;
            btn4.TextTemplate = "4 (#)";
            btn4.LightFeature = SC.Page1Features.Button4Light;
            btn4.BlinkFeature = SC.Page1Features.Button4Blink;
            btn5.WhichButton = SC.Buttons.Button5;
            btn5.TextTemplate = "5 (#)";
            btn5.LightFeature = SC.Page1Features.Button5Light;
            btn5.BlinkFeature = SC.Page1Features.Button5Blink;
            btn6.WhichButton = SC.Buttons.Button6;
            btn6.TextTemplate = "6 (#)";
            btn6.LightFeature = SC.Page1Features.Button6Light;
            btn6.BlinkFeature = SC.Page1Features.Button6Blink;
            btnPlus.WhichButton = SC.Buttons.ButtonPlus;
            btnPlus.TextTemplate = "+ (#)";
            btnMinus.WhichButton = SC.Buttons.ButtonMinus;
            btnMinus.TextTemplate = "- (#)";
            Device.SetFeature(2, BitConverter.GetBytes((short)SC.Page2Features.GetStatus));
            Commander.PropertyChanged += new PropertyChangedEventHandler(Commander_PropertyChanged);
            
        }

        void KeySender_DoWork(object sender, DoWorkEventArgs e)
        {
            SCState newstate, oldstate = new SCState(0, 0);
            byte button;
            while (true)
            {
                if (Commander.StateQueue.Count > 0)
                {
                    newstate = (SCState)Commander.StateQueue.Dequeue();
                    button = (byte)(newstate.ButtonState ^ oldstate.ButtonState);
                    if (button != 0)
                    {
                        Commander.ButtonChanged((SC.Buttons)button, newstate.ModifierState);
                    }
                    oldstate = newstate;
                }
            }
        }

        void Commander_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "ModifierState":
                    UpdateForm();
                    break;
                default:
                    break;
            }
        }

        private void DeviceDataReceived(byte[] data)
        {
            Commander.ModifierState = data[6];
            Commander.ButtonState = data[5];
            Commander.StateQueue.Enqueue(new SCState(data[5], data[6]));
            Debug.WriteLine(string.Format("Modifiers: {0} Buttons: {1}", Commander.ModifierState.ToString(), Commander.ButtonState.ToString()));
            Debug.WriteLine(string.Format("Queue Size: {0}", Commander.StateQueue.Count.ToString()));
        }

        private void DeviceOnDisConnected()
        {
            ThreadSafe(() => this.Text = "Not Connected");
            if (KeySender.IsBusy)
            {
                KeySender.CancelAsync();
            }

        }

        private void DeviceOnConnected()
        {
            ThreadSafe(() => this.Text = "Connected");
            if (!KeySender.IsBusy)
            {
                KeySender.RunWorkerAsync();
            }
        }

        private void ThreadSafe(MethodInvoker method)
        {
            if (InvokeRequired)
                Invoke(method);
            else
                method();
        }

        private void CmdrBtn_Click(object sender, EventArgs e)
        {
            CaptureKey x = new CaptureKey();
            if ((Commander.LightState & (short)(sender as CmdrButton).LightFeature) == (short)(sender as CmdrButton).LightFeature)
            {
                Device.SetFeature(1, BitConverter.GetBytes(Commander.LightState - (short)(sender as CmdrButton).LightFeature + (short)(sender as CmdrButton).BlinkFeature));
            }
            else
            {
                Device.SetFeature(1, BitConverter.GetBytes(Commander.LightState + (short)(sender as CmdrButton).BlinkFeature));
            }

            x.ShowDialog();
            Commander.AddHotKey((sender as CmdrButton).WhichButton, Commander.ModifierState, x.PressedKeys);
            UpdateForm();
        }

        private void saveLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgLayoutSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Stream LayoutSaver = File.Create(dlgLayoutSave.FileName);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(LayoutSaver, Commander);
                LayoutSaver.Close();
            }

        }

        private void loadLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgLayoutLoad.ShowDialog() == System.Windows.Forms.DialogResult.OK && File.Exists(dlgLayoutLoad.FileName))
            {
                Stream LayoutLoader = File.OpenRead(dlgLayoutLoad.FileName);
                BinaryFormatter deserializer = new BinaryFormatter();
                Commander = (SC)deserializer.Deserialize(LayoutLoader);
                LayoutLoader.Close();
                Commander.PropertyChanged += new PropertyChangedEventHandler(Commander_PropertyChanged);
                UpdateForm();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            KeySender.CancelAsync();
        }
    }
}
