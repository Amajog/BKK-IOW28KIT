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


        //
        // switch
        //

        private void hSB_switch_ValueChanged(object sender, EventArgs e)
        {
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

            // lbl text to tell Data[1] value in hex and dec
            int value = Data[1];                                        // dec
            string valueHEX = value.ToString("X");                      // hex
            lbl_valueData.Text = "DATA[1]= " + valueHEX + "/" + value;  // output

            // preparing color change
            int[] panelselect;

            // select active sceme
            switch(value)
            {
                case 255:
                    panelselect = new int[0] {};
                    ColorPanel(panelselect);
                    break;

                case 254:
                    panelselect = new int[1] { 0 };
                    ColorPanel(panelselect);
                    RevalueData(16);
                    break;
                case 253:
                    panelselect = new int[1] { 1 };
                    ColorPanel(panelselect);
                    RevalueData(32);
                    break;
                case 251:
                    panelselect = new int[1] { 2 };
                    ColorPanel(panelselect);
                    RevalueData(64);
                    break;
                case 247:
                    panelselect = new int[1] { 3 };
                    ColorPanel(panelselect);
                    RevalueData(128);
                    break;
                case 252:
                    panelselect = new int[2] { 0, 1 };
                    ColorPanel(panelselect);
                    RevalueData(16 + 32);
                    break;
                case 250:
                    panelselect = new int[2] { 0, 2 };
                    ColorPanel(panelselect);
                    RevalueData(16 + 64);
                    break;
                case 246:
                    panelselect = new int[2] { 0, 3 };
                    ColorPanel(panelselect);
                    RevalueData(16 + 128);
                    break;
                case 249:
                    panelselect = new int[2] { 1, 2 };
                    ColorPanel(panelselect);
                    RevalueData(32 + 64);
                    break;
                case 245:
                    panelselect = new int[2] { 1, 3 };
                    ColorPanel(panelselect);
                    RevalueData(32 + 128);
                    break;
                case 243:
                    panelselect = new int[2] { 2, 3 };
                    ColorPanel(panelselect);
                    RevalueData(64 + 128);
                    break;
                case 248:
                    panelselect = new int[3] { 0, 1, 2 };
                    ColorPanel(panelselect);
                    RevalueData(16 + 32 + 64);
                    break;
                case 244:
                    panelselect = new int[3] { 0, 1, 3 };
                    ColorPanel(panelselect);
                    RevalueData(16 + 32 + 128);
                    break;
                case 242:
                    panelselect = new int[3] { 0, 2, 3 };
                    ColorPanel(panelselect);
                    RevalueData(16 + 64 + 128);
                    break;
                case 241:
                    panelselect = new int[3] { 1, 2, 3 };
                    ColorPanel(panelselect);
                    RevalueData(32 + 64 + 128);
                    break;
                case 240:
                    panelselect = new int[4] { 0, 1, 2, 3 };
                    ColorPanel(panelselect);
                    RevalueData(16 + 32 + 64 + 128);
                    break;
                default:
                    Data[1] = Convert.ToByte(255);
                    break;
            }
            IowKitWrite(iowHandle, 0, ref Data[0], 5);
        }

        // change panel color
        private void ColorPanel(int[] panelselect)
        {
            Panel[] Pnlnum = new Panel[] { 
                pnl_btnCheckP00, 
                pnl_btnCheckP01, 
                pnl_btnCheckP02, 
                pnl_btnCheckP03,
                pnl_lightCheckP04,
                pnl_lightCheckP05,
                pnl_lightCheckP06,
                pnl_lightCheckP07
            };

            foreach (Panel p in Pnlnum)
            {
                p.BackColor = Color.Black;
            }
            foreach (int i in panelselect)
            {
                Pnlnum[i].BackColor = Color.Red;
                Pnlnum[i + 4].BackColor = Color.Red;
            }
        }

        private void RevalueData(int x)
        {
                Data[1] = Convert.ToByte(Data[1] - x);
        }


        //
        // light program
        //

        bool p07 = false;
        bool p04 = false;
        bool p05 = false;
        bool p06 = false;

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

        private void lbl_clickLight_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(500);
            Data[1] = Convert.ToByte(255 - (128));
            IowKitWrite(iowHandle, 0, ref Data[0], 5);

            for (int i = 0; i < 5; i++)
            {
                Data[1] = Convert.ToByte(255);

                System.Threading.Thread.Sleep(500);
                Data[1] = Convert.ToByte(255 - (16 + 128));
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                System.Threading.Thread.Sleep(500);
                Data[1] = Convert.ToByte(255 - (64 + 32));
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                System.Threading.Thread.Sleep(500);
                Data[1] = Convert.ToByte(255 - (16 + 128));
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                System.Threading.Thread.Sleep(500);
                Data[1] = Convert.ToByte(255 - (16 + 32 + 128));
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                System.Threading.Thread.Sleep(500);
                Data[1] = Convert.ToByte(255 - (16 + 32 + 64 + 128));
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                System.Threading.Thread.Sleep(250);
                Data[1] = Convert.ToByte(255 - (16 + 32 + 64 + 128));
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                System.Threading.Thread.Sleep(250);
                Data[1] = Convert.ToByte(255 - (16 + 32 + 64 + 128));
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                System.Threading.Thread.Sleep(250);
                Data[1] = Convert.ToByte(255 - (16 + 32 + 64 + 128));
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                System.Threading.Thread.Sleep(250);
                Data[1] = Convert.ToByte(255 - (16 + 32));
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                System.Threading.Thread.Sleep(250);
                Data[1] = Convert.ToByte(255);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                System.Threading.Thread.Sleep(250);
                Data[1] = Convert.ToByte(255 - (16 + 32));
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                Data[1] = Convert.ToByte(255);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                System.Threading.Thread.Sleep(250);
                Data[1] = Convert.ToByte(255 - (16 + 32));
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                Data[1] = Convert.ToByte(255);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                System.Threading.Thread.Sleep(250);
                Data[1] = Convert.ToByte(255 - (16 + 32));
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                Data[1] = Convert.ToByte(255);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                System.Threading.Thread.Sleep(250);
                Data[1] = Convert.ToByte(255 - (16 + 32));
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                System.Threading.Thread.Sleep(250);
                Data[1] = Convert.ToByte(255 - (64 + 128));
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                Data[1] = Convert.ToByte(255);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                System.Threading.Thread.Sleep(250);
                Data[1] = Convert.ToByte(255 - (16 + 32));
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                System.Threading.Thread.Sleep(250);
                Data[1] = Convert.ToByte(255 - (64 + 128));
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                Data[1] = Convert.ToByte(255);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                System.Threading.Thread.Sleep(250);
                Data[1] = Convert.ToByte(255 - (16 + 32));
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                System.Threading.Thread.Sleep(250);
                Data[1] = Convert.ToByte(255 - (64 + 128));
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                Data[1] = Convert.ToByte(255);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                System.Threading.Thread.Sleep(250);
                Data[1] = Convert.ToByte(255 - (16 + 32));
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                System.Threading.Thread.Sleep(250);
                Data[1] = Convert.ToByte(255 - (64 + 128));
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
                Data[1] = Convert.ToByte(255);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
            }
        }

        private void hSB_switch_MouseHover(object sender, EventArgs e)
        {
            tt_explains.Show("change between button and light visualizer", hSB_switch);
        }

        private void lbl_clickLight_MouseHover(object sender, EventArgs e)
        {
            tt_explains.Show("click me 🤫", lbl_clickLight);
        }

        private void lbl_lightvisualizer_MouseHover(object sender, EventArgs e)
        {
            tt_explains.Show("click on black panel to light the LED", lbl_lightvisualizer);
        }
    }
}
