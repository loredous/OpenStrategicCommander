using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenStrategicCommander.Classes.StrategicCommander;

namespace OpenStrategicCommander.Controls
{
    public partial class CmdrButton : System.Windows.Forms.Button
    {
        public CmdrButton()
        {
            InitializeComponent();
        }
        public SC.Buttons WhichButton;
        public string TextTemplate;
        public SC.Page1Features LightFeature;
        public SC.Page1Features BlinkFeature;

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
