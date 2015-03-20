using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UsbHid;
using UsbHid.USB.Classes;
using UsbHid.USB.Structures;
using UsbHid.USB.Classes.Messaging;
using OpenStrategicCommander.Classes.StrategicCommander;
using OpenStrategicCommander.Classes;

namespace OpenStrategicCommander
{
    public partial class TestForm : Form
    {
        public UsbHidDevice Device;
        byte[] oldState, newState;

        public TestForm()
        {
            InitializeComponent();
        }

        private void Form2Load(object sender, EventArgs e)
        {
            Device = new UsbHidDevice(0x045E, 0x0033);
            Device.OnConnected += DeviceOnConnected;
            Device.OnDisConnected += DeviceOnDisConnected;
            Device.DataReceived += DeviceDataReceived;
            Device.Connect();
        }

        private void DeviceDataReceived(byte[] data)
        {
            AppendText(ByteArrayToString(data));
            oldState = newState;
            newState = data;
        }

        private void AppendText(string p)
        {
            ThreadSafe(() => textBox1.AppendText(p + Environment.NewLine));
        }

        private void DeviceOnDisConnected()
        {
            ThreadSafe(() => this.Text = "Not Connected");

        }

        private void DeviceOnConnected()
        {
            ThreadSafe(() => this.Text = "Connected");
        }

        private void ThreadSafe(MethodInvoker method)
        {
            if (InvokeRequired)
                Invoke(method);
            else
                method();
        }


        private static string ByteArrayToString(ICollection<byte> input)
        {
            var result = string.Empty;

            if (input != null && input.Count > 0)
            {
                var isFirst = true;
                foreach (var b in input)
                {
                    result += isFirst ? string.Empty : ",";
                    result += b.ToString();
                    isFirst = false;
                }
            }
            return result;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            AppendText(e.KeyData.ToString());
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KeySend.SendKey(Keys.A);
        }
    }
}
