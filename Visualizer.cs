using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOW28KIT
{
    public partial class Visualizer : Form
    {
        [DllImport("iowkit", SetLastError = true)]
        public static extern int IowKitOpenDevice();

        [DllImport("iowkit", SetLastError = true)]
        public static extern short IowKitWrite(int iowHandle, int numPipe, ref byte buffer, int length);

        [DllImport("iowkit", SetLastError = true)]
        public static extern short IowKitReadNonBlocking(int iowHandle, int numPipe, ref byte buffer, int length);

        public Visualizer()
        {
            InitializeComponent();
            IowKitOpenDevice();
        }

        // Variablen
        int iowHandle = Form1.iowHandle;
        byte[] Data = new byte[5] { 0, 255, 0, 0, 0 };
        bool lightSwitch = false;

        private void Visualizer_Load(object sender, EventArgs e)
        {
            IowKitWrite(iowHandle, 0, ref Data[0], 5);
            Clock();
        }

        // check which program should run
        private void Clock()
        {
            if (hSB_switch.Value == 1)
            {
                lightSwitch = false;
                
                timer_checkBTNdelay.Enabled = true;
                timer_checkBTNdelay.Tick += new EventHandler(RunCheck);

            }
            else
            {
                timer_checkBTNdelay.Enabled = false;

                lightSwitch = true;
            }
        }

        //
        // button program
        //

        private void RunCheck(object sender, EventArgs e)
        {
            IowKitReadNonBlocking(iowHandle, 0, ref Data[0], 5);

            // declaring variables and text values
            int value = Data[1];
            string valueHEX = value.ToString("X");
            lbl_valueData.Text = "DATA[1]= " + valueHEX + "/" + value;
            int[] panelselect;

            // select active sceme
            switch(Data[1])
            {
                case 255:
                    panelselect = new int[0] {};
                    ColorPanel(panelselect);
                    break;
                case 254:
                    panelselect = new int[1] { 0 };
                    ColorPanel(panelselect);
                    break;
                case 253:
                    panelselect = new int[1] { 1 };
                    ColorPanel(panelselect);
                    break;
                case 251:
                    panelselect = new int[1] { 2 };
                    ColorPanel(panelselect);
                    break;
                case 247:
                    panelselect = new int[1] { 3 };
                    ColorPanel(panelselect);
                    break;
                case 252:
                    panelselect = new int[2] { 0, 1 };
                    ColorPanel(panelselect);
                    break;
                case 250:
                    panelselect = new int[2] { 0, 2 };
                    ColorPanel(panelselect);
                    break;
                case 246:
                    panelselect = new int[2] { 0, 3 };
                    ColorPanel(panelselect);
                    break;
                case 249:
                    panelselect = new int[2] { 1, 2 };
                    ColorPanel(panelselect);
                    break;
                case 245:
                    panelselect = new int[2] { 1, 3 };
                    ColorPanel(panelselect);
                    break;
                case 243:
                    panelselect = new int[2] { 2, 3 };
                    ColorPanel(panelselect);
                    break;
                case 248:
                    panelselect = new int[3] { 0, 1, 2 };
                    ColorPanel(panelselect);
                    break;
                case 244:
                    panelselect = new int[3] { 0, 1, 3 };
                    ColorPanel(panelselect);
                    break;
                case 242:
                    panelselect = new int[3] { 0, 2, 3 };
                    ColorPanel(panelselect);
                    break;
                case 241:
                    panelselect = new int[3] { 1, 2, 3 };
                    ColorPanel(panelselect);
                    break;
                case 240:
                    panelselect = new int[4] { 0, 1, 2, 3 };
                    ColorPanel(panelselect);
                    break;
            }
        }

        // change panel color
        private void ColorPanel(int[] panelselect)
        {
            Panel[] Pnlnum = new Panel[] { 
                pnl_btnCheckP00, 
                pnl_btnCheckP01, 
                pnl_btnCheckP02, 
                pnl_btnCheckP03
            };

            foreach (Panel p in Pnlnum)
            {
                p.BackColor = Color.Black;
            }
            foreach (int i in panelselect)
            {
                Pnlnum[i].BackColor = Color.Red;
            }
        }

        //
        // light program
        //

        bool p04 = false;
        bool p05 = false;
        bool p06 = false;
        bool p07 = false;

        private void hSB_switch_ValueChanged(object sender, EventArgs e)
        {
            Clock();
        }

        private void pnl_lightCheckP04_Click(object sender, EventArgs e)
        {
            if(!lightSwitch) return;


            if (!p04)
            {
                Data[1] = Convert.ToByte(Data[1] - 16);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                pnl_lightCheckP04.BackColor = Color.Red;
                p04 = true;
            }
            else if (p04)
            {
                Data[1] = Convert.ToByte(Data[1] + 16);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                pnl_lightCheckP04.BackColor = Color.Black;
                p04 = false;
            }
        }

        private void pnl_lightCheckP05_Click(object sender, EventArgs e)
        {
            if (!lightSwitch) return;


            if (!p05)
            {
                Data[1] = Convert.ToByte(Data[1] - 32);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                pnl_lightCheckP05.BackColor = Color.Red;
                p05 = true;
            }
            else if (p05)
            {
                Data[1] = Convert.ToByte(Data[1] +32);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                pnl_lightCheckP05.BackColor = Color.Black;
                p05 = false;
            }
        }

        private void pnl_lightCheckP06_Click(object sender, EventArgs e)
        {
            if (!lightSwitch) return;


            if (!p06)
            {
                Data[1] = Convert.ToByte(Data[1] - 64);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                pnl_lightCheckP06.BackColor = Color.Red;
                p06 = true;
            }
            else if (p06)
            {
                Data[1] = Convert.ToByte(Data[1] + 64);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                pnl_lightCheckP06.BackColor = Color.Black;
                p06 = false;
            }
        }

        private void pnl_lightCheckP07_Click(object sender, EventArgs e)
        {
            if (!lightSwitch) return;


            if (!p07)
            {
                Data[1] = Convert.ToByte(Data[1] - 128);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                pnl_lightCheckP07.BackColor = Color.Red;
                p07 = true;
            }
            else if (p07)
            {
                Data[1] = Convert.ToByte(Data[1] + 128);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                pnl_lightCheckP07.BackColor = Color.Black;
                p07 = false;
            }
        }

        private void Visualizer_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer_checkBTNdelay.Enabled = false;
        }
    }
}
