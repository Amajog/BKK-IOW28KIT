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
    public partial class LightCheck : Form
    {

        [DllImport("iowkit", SetLastError = true)]
        public static extern int IowKitOpenDevice();

        [DllImport("iowkit", SetLastError = true)]
        public static extern short IowKitWrite(int iowHandle, int numPipe, ref byte buffer, int length);

        [DllImport("iowkit", SetLastError = true)]
        public static extern short IowKitReadNonBlocking(int iowHandle, int numPipe, ref byte buffer, int length);


        public LightCheck()
        {
            InitializeComponent();
            IowKitOpenDevice();
        }

        // Variablen
        int iowHandle = Form1.iowHandle;
        byte[] Data = new byte[5] { 0, 255, 0, 0, 0 };

        private void cb_LED_P04_CheckedChanged(object sender, EventArgs e)
        {
            int data1Value;
            if (cb_LED_P04.Checked == true)
            {
                pnl_LED_P04.BackColor = Color.Red;
                data1Value = Data[1] & 0xE0;
                Data[1] = Convert.ToByte(data1Value);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
            }
            else
            {
                pnl_LED_P04.BackColor = Color.Black;
                data1Value = Data[1] | 0x10;
                Data[1] = Convert.ToByte(data1Value);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
            }

            // lbl text to tell Data[1] value in hex and dec
            int value = Data[1];                                        // dec
            string valueHEX = value.ToString("X");                      // hex
            lbl_Data1.Text = "DATA[1]= " + valueHEX + "/" + value;      // output
        }

        private void cb_LED_P05_CheckedChanged(object sender, EventArgs e)
        {
            int data1Value;
            if (cb_LED_P05.Checked == true)
            {
                pnl_LED_P05.BackColor = Color.Red;
                data1Value = Data[1] & 0xD0;
                Data[1] = Convert.ToByte(data1Value);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
            }
            else
            {
                pnl_LED_P05.BackColor = Color.Black;
                data1Value = Data[1] | 0x20;
                Data[1] = Convert.ToByte(data1Value);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
            }

            // lbl text to tell Data[1] value in hex and dec
            int value = Data[1];                                        // dec
            string valueHEX = value.ToString("X");                      // hex
            lbl_Data1.Text = "DATA[1]= " + valueHEX + "/" + value;      // output
        }

        private void cb_LED_P06_CheckedChanged(object sender, EventArgs e)
        {
            int data1Value;
            if (cb_LED_P06.Checked == true)
            {
                pnl_LED_P06.BackColor = Color.Red;
                data1Value = Data[1] & 0xB0;
                Data[1] = Convert.ToByte(data1Value);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
            }
            else
            {
                pnl_LED_P06.BackColor = Color.Black;
                data1Value = Data[1] | 0x40;
                Data[1] = Convert.ToByte(data1Value);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
            }

            // lbl text to tell Data[1] value in hex and dec
            int value = Data[1];                                        // dec
            string valueHEX = value.ToString("X");                      // hex
            lbl_Data1.Text = "DATA[1]= " + valueHEX + "/" + value;  // output
        }

        private void cb_LED_P07_CheckedChanged(object sender, EventArgs e)
        {
            int data1Value;
            if (cb_LED_P07.Checked == true)
            {
                pnl_LED_P07.BackColor = Color.Red;
                data1Value = Data[1] & 0x70;
                Data[1] = Convert.ToByte(data1Value);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
            }
            else
            {
                pnl_LED_P07.BackColor = Color.Black;
                data1Value = Data[1] | 0x80;
                Data[1] = Convert.ToByte(data1Value);
                IowKitWrite(iowHandle, 0, ref Data[0], 5);
            }

            // lbl text to tell Data[1] value in hex and dec
            int value = Data[1];                                        // dec
            string valueHEX = value.ToString("X");                      // hex
            lbl_Data1.Text = "DATA[1]= " + valueHEX + "/" + value;  // output
        }

        //LightShow
        byte counter = 3;

        private void btn_Run_Click(object sender, EventArgs e)
        {
            if (!tmr_LightShow.Enabled)
            {
                tmr_LightShow.Enabled = true;
                if (cb_LED_P04.Checked == false && cb_LED_P05.Checked == false && cb_LED_P06.Checked == false && cb_LED_P07.Checked == false)
                {
                    cb_LED_P04.Checked = true;
                    cb_LED_P05.Checked = true;
                    cb_LED_P06.Checked = true;
                    cb_LED_P07.Checked = true;
                }
                EnableCB();
            }
        }

        private void btn_Stop_click(object sender, EventArgs e)
        {
            if (tmr_LightShow.Enabled == true) { EnableCB(); }
            tmr_LightShow.Enabled = false;
            Data[1] = Convert.ToByte(255);
            IowKitWrite(iowHandle, 0, ref Data[0], 5);
        }

        private void EnableCB()
        {
            if (cb_LED_P04.Enabled == true)
            {
                cb_LED_P04.Enabled = false;
                cb_LED_P05.Enabled = false;
                cb_LED_P06.Enabled = false;
                cb_LED_P07.Enabled = false;
            }
            else
            {
                cb_LED_P04.Enabled = true;
                cb_LED_P05.Enabled = true;
                cb_LED_P06.Enabled = true;
                cb_LED_P07.Enabled = true;
            }
        }

        private void tmr_LightShow_Tick(object sender, EventArgs e)
        {
            LightShow();
        }

        private void LightShow()
        {

            if (counter < 3) { counter++; }
            else { counter = 0; }

            switch (counter)
            {
                case 0:
                    if (cb_LED_P04.Checked == false) {
                        LightShow();
                        return;
                    }
                    else { Data[1] = Convert.ToByte(255 - (16)); }
                    break;
                case 1:
                    if (cb_LED_P05.Checked == false)
                    {
                        LightShow();
                        return;
                    }
                    else { Data[1] = Convert.ToByte(255 - (32)); }
                    break;
                case 2:
                    if (cb_LED_P07.Checked == false)
                    {
                        LightShow();
                        return;
                    }
                    else { Data[1] = Convert.ToByte(255 - (128)); }
                    break;
                case 3:
                    if (cb_LED_P06.Checked == false)
                    {
                        LightShow();
                        return;
                    }
                    else { Data[1] = Convert.ToByte(255 - (64)); }
                    break;
            }
            IowKitWrite(iowHandle, 0, ref Data[0], 5);
        }

        private void btn_Run_MouseHover(object sender, EventArgs e)
        {
            tt_explains.Show("tets", btn_Run);
        }
    }
}
