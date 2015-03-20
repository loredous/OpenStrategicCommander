using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenStrategicCommander.Forms
{
    public partial class CaptureKey : Form
    {
        public Keys PressedKeys;

        public CaptureKey()
        {
            InitializeComponent();
        }

        private void CaptureKey_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.ControlKey) && (e.KeyCode != Keys.ShiftKey) && (e.KeyCode != Keys.Menu))
            {
                PressedKeys = e.KeyData;
                this.Close();
            }
        }
    }
}
