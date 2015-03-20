namespace OpenStrategicCommander.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trkSwitch = new System.Windows.Forms.TrackBar();
            this.lblSwitchState = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnPanel = new System.Windows.Forms.Panel();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgLayoutSave = new System.Windows.Forms.SaveFileDialog();
            this.dlgLayoutLoad = new System.Windows.Forms.OpenFileDialog();
            this.radMod1 = new System.Windows.Forms.RadioButton();
            this.radMod2 = new System.Windows.Forms.RadioButton();
            this.radMod3 = new System.Windows.Forms.RadioButton();
            this.btn1 = new OpenStrategicCommander.Controls.CmdrButton();
            this.btn4 = new OpenStrategicCommander.Controls.CmdrButton();
            this.btn2 = new OpenStrategicCommander.Controls.CmdrButton();
            this.btn5 = new OpenStrategicCommander.Controls.CmdrButton();
            this.btn3 = new OpenStrategicCommander.Controls.CmdrButton();
            this.btnPlus = new OpenStrategicCommander.Controls.CmdrButton();
            this.btn6 = new OpenStrategicCommander.Controls.CmdrButton();
            this.btnMinus = new OpenStrategicCommander.Controls.CmdrButton();
            ((System.ComponentModel.ISupportInitialize)(this.trkSwitch)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.btnPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // trkSwitch
            // 
            this.trkSwitch.Location = new System.Drawing.Point(313, 97);
            this.trkSwitch.Maximum = 3;
            this.trkSwitch.Minimum = 1;
            this.trkSwitch.Name = "trkSwitch";
            this.trkSwitch.Size = new System.Drawing.Size(80, 45);
            this.trkSwitch.TabIndex = 2;
            this.trkSwitch.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkSwitch.Value = 1;
            // 
            // lblSwitchState
            // 
            this.lblSwitchState.Location = new System.Drawing.Point(313, 128);
            this.lblSwitchState.Name = "lblSwitchState";
            this.lblSwitchState.Size = new System.Drawing.Size(80, 17);
            this.lblSwitchState.TabIndex = 3;
            this.lblSwitchState.Text = "Switch 1";
            this.lblSwitchState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(529, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnPanel
            // 
            this.btnPanel.Controls.Add(this.btn1);
            this.btnPanel.Controls.Add(this.btn4);
            this.btnPanel.Controls.Add(this.btn2);
            this.btnPanel.Controls.Add(this.btn5);
            this.btnPanel.Controls.Add(this.btn3);
            this.btnPanel.Controls.Add(this.btnPlus);
            this.btnPanel.Controls.Add(this.btn6);
            this.btnPanel.Controls.Add(this.btnMinus);
            this.btnPanel.Location = new System.Drawing.Point(12, 27);
            this.btnPanel.Name = "btnPanel";
            this.btnPanel.Size = new System.Drawing.Size(295, 120);
            this.btnPanel.TabIndex = 6;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLayoutToolStripMenuItem,
            this.loadLayoutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveLayoutToolStripMenuItem
            // 
            this.saveLayoutToolStripMenuItem.Name = "saveLayoutToolStripMenuItem";
            this.saveLayoutToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.saveLayoutToolStripMenuItem.Text = "Save Layout";
            this.saveLayoutToolStripMenuItem.Click += new System.EventHandler(this.saveLayoutToolStripMenuItem_Click);
            // 
            // loadLayoutToolStripMenuItem
            // 
            this.loadLayoutToolStripMenuItem.Name = "loadLayoutToolStripMenuItem";
            this.loadLayoutToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.loadLayoutToolStripMenuItem.Text = "Load Layout";
            this.loadLayoutToolStripMenuItem.Click += new System.EventHandler(this.loadLayoutToolStripMenuItem_Click);
            // 
            // dlgLayoutSave
            // 
            this.dlgLayoutSave.DefaultExt = "osc";
            this.dlgLayoutSave.Filter = "OSC Layouts|*.osc|All Files|*.*";
            this.dlgLayoutSave.Title = "Save Layout";
            // 
            // dlgLayoutLoad
            // 
            this.dlgLayoutLoad.DefaultExt = "osc";
            this.dlgLayoutLoad.Filter = "OSC Layouts|*.osc|All Files|*.*";
            this.dlgLayoutLoad.Title = "Load Layout";
            // 
            // radMod1
            // 
            this.radMod1.AutoCheck = false;
            this.radMod1.AutoSize = true;
            this.radMod1.Location = new System.Drawing.Point(316, 27);
            this.radMod1.Name = "radMod1";
            this.radMod1.Size = new System.Drawing.Size(71, 17);
            this.radMod1.TabIndex = 7;
            this.radMod1.TabStop = true;
            this.radMod1.Text = "Modifier 1";
            this.radMod1.UseVisualStyleBackColor = true;
            // 
            // radMod2
            // 
            this.radMod2.AutoCheck = false;
            this.radMod2.AutoSize = true;
            this.radMod2.Location = new System.Drawing.Point(316, 46);
            this.radMod2.Name = "radMod2";
            this.radMod2.Size = new System.Drawing.Size(71, 17);
            this.radMod2.TabIndex = 7;
            this.radMod2.TabStop = true;
            this.radMod2.Text = "Modifier 2";
            this.radMod2.UseVisualStyleBackColor = true;
            // 
            // radMod3
            // 
            this.radMod3.AutoCheck = false;
            this.radMod3.AutoSize = true;
            this.radMod3.Location = new System.Drawing.Point(316, 65);
            this.radMod3.Name = "radMod3";
            this.radMod3.Size = new System.Drawing.Size(71, 17);
            this.radMod3.TabIndex = 7;
            this.radMod3.TabStop = true;
            this.radMod3.Text = "Modifier 3";
            this.radMod3.UseVisualStyleBackColor = true;
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(0, -1);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(69, 56);
            this.btn1.TabIndex = 5;
            this.btn1.Text = "1 ()";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.CmdrBtn_Click);
            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(0, 61);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(69, 56);
            this.btn4.TabIndex = 0;
            this.btn4.Tag = "4 (#)";
            this.btn4.Text = "4 ()";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.CmdrBtn_Click);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(75, -1);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(69, 56);
            this.btn2.TabIndex = 0;
            this.btn2.Tag = "2 (#)";
            this.btn2.Text = "2 ()";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.CmdrBtn_Click);
            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(75, 61);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(69, 56);
            this.btn5.TabIndex = 0;
            this.btn5.Tag = "5 (#)";
            this.btn5.Text = "5 ()";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.CmdrBtn_Click);
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(150, -1);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(69, 56);
            this.btn3.TabIndex = 0;
            this.btn3.Tag = "3 (#)";
            this.btn3.Text = "3 ()";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.CmdrBtn_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Location = new System.Drawing.Point(225, -1);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(69, 56);
            this.btnPlus.TabIndex = 0;
            this.btnPlus.Tag = "+ (#)";
            this.btnPlus.Text = "+ ()";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.CmdrBtn_Click);
            // 
            // btn6
            // 
            this.btn6.Location = new System.Drawing.Point(150, 61);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(69, 56);
            this.btn6.TabIndex = 0;
            this.btn6.Tag = "6 (#)";
            this.btn6.Text = "6 ()";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.CmdrBtn_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Location = new System.Drawing.Point(225, 61);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(69, 56);
            this.btnMinus.TabIndex = 0;
            this.btnMinus.Tag = "- (#)";
            this.btnMinus.Text = "- ()";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.CmdrBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 153);
            this.Controls.Add(this.radMod1);
            this.Controls.Add(this.radMod3);
            this.Controls.Add(this.radMod2);
            this.Controls.Add(this.btnPanel);
            this.Controls.Add(this.lblSwitchState);
            this.Controls.Add(this.trkSwitch);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.trkSwitch)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.btnPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trkSwitch;
        private System.Windows.Forms.Label lblSwitchState;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private Controls.CmdrButton btn1;
        private System.Windows.Forms.Panel btnPanel;
        private Controls.CmdrButton btn2;
        private Controls.CmdrButton btn3;
        private Controls.CmdrButton btn4;
        private Controls.CmdrButton btn5;
        private Controls.CmdrButton btn6;
        private Controls.CmdrButton btnPlus;
        private Controls.CmdrButton btnMinus;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLayoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadLayoutToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog dlgLayoutSave;
        private System.Windows.Forms.OpenFileDialog dlgLayoutLoad;
        private System.Windows.Forms.RadioButton radMod1;
        private System.Windows.Forms.RadioButton radMod2;
        private System.Windows.Forms.RadioButton radMod3;
    }
}