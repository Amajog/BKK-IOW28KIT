using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace IOW28KIT
{
    public partial class Form1 : Form
    {
        int selectedDevice = 1;


        [DllImport("iowkit", SetLastError = true)]
        public static extern int IowKitOpenDevice();

        [DllImport("iowkit", SetLastError = true)]
        public static extern int IowKitCloseDevice(int iowHandle);
        
        [DllImport("iowkit", SetLastError = true)]
        public static extern int IowKitGetNumDevs();
        
        [DllImport("iowkit", SetLastError = true)]
        public static extern int IowKitGetDeviceHandle(int numDevice);
        
        [DllImport("iowkit", SetLastError = true)]
        public static extern int IowKitGetProductId(int iowHandle);


        public Form1()
        {
            InitializeComponent();
            // IOW seutup
            IowKitOpenDevice();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // show IOW count
            int numOfDevices = IowKitGetNumDevs();
            cb_IowSelector.Text = "Anzahl IOW: " + Convert.ToString(numOfDevices) + " (selected: 1)";

            for (int i = 1; i <= numOfDevices; i++)
            {
                cb_IowSelector.Items.Add(i);
            }
        }


        // 1.6
        public static int iowHandle;

        private void cb_IowSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            // select device
            selectedDevice = cb_IowSelector.SelectedIndex + 1;
        }

        private void btn_requestIowStatus_Click(object sender, EventArgs e)
        {
            // 1.6
            int iowHandle = IowKitGetDeviceHandle(selectedDevice);
            // 1.7
            int iowId = IowKitGetProductId((int)iowHandle);

            lbl_HandleOfIow.Text = "Seriennummer IOW:" + Convert.ToString(iowHandle);

            // display IOW count and type
            if (iowId == 5380)
            {                
                lbl_DeviceId.Text = "IOW-Id: " + iowId + ", Es handelt Sich um einen 'IOW 28'";
            }
            else if (iowId == 5377)
            {
                lbl_DeviceId.Text = "IOW-Id: " + iowId + ", Es handelt Sich um einen 'IOW 24'";
            }
            else if (iowId == 5376)
            {
                lbl_DeviceId.Text = "IOW-Id: " + iowId + ", Es handelt Sich um einen 'IOW 40'";
            }
            else if (iowId == 5379)
            {
                lbl_DeviceId.Text = "IOW-Id: " + iowId + ", Es handelt Sich um einen 'IOW 56'";
            }
            else
            {
                lbl_DeviceId.Text = "IOW-Id: " + iowId + ", Es handelt Sich um einen (unbekannten) :IOW:";
            }
        }

        // 1.8
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            int numOfDevices = IowKitGetNumDevs();

            for (int i = 1; i <= numOfDevices; i++)
            {
                int iowHandle = IowKitGetDeviceHandle(i);
                IowKitCloseDevice(iowHandle);
            }
        }

        private void btn_switchToVisualizer_Click(object sender, EventArgs e)
        {
            iowHandle = IowKitGetDeviceHandle(selectedDevice);
            Visualizer Visualizer = new Visualizer();
            Visualizer.Show();
        }
        private void btn_switchToLightCheck_Click(object sender, EventArgs e)
        {
            iowHandle = IowKitGetDeviceHandle(selectedDevice);
            LightCheck LightCheck = new LightCheck();
            LightCheck.Show();
        }

        private void cb_IowSelector_MouseHover(object sender, EventArgs e)
        {
            tt_explain.Show("select connected device", cb_IowSelector);
        }

        private void btn_switchToVisualizer_MouseHover(object sender, EventArgs e)
        {
            tt_explain.Show("open button and light visualizer", btn_switchToVisualizer);
        }

        private void btn_requestIowStatus_MouseHover(object sender, EventArgs e)
        {
            tt_explain.Show("request device information", btn_requestIowStatus);
        }

    }
}
