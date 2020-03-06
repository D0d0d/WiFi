using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NativeWifi;



namespace WiFi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            WlanClient client = new WlanClient();
            foreach (WlanClient.WlanInterface wlanInterface in client.Interfaces )
            {
                Wlan.WlanAvailableNetwork[] wlanBssEntries = wlanInterface.GetAvailableNetworkList(0);
                listNet.Items.Clear();
                foreach (Wlan.WlanAvailableNetwork network in wlanBssEntries)
                {
                    ListViewItem listItemWifi = new ListViewItem();
                    listItemWifi.Text = System.Text.ASCIIEncoding.ASCII.GetString(network.dot11Ssid.SSID).Trim((char)0);
                    listItemWifi.SubItems.Add(network.wlanSignalQuality.ToString() + "%");
                    listItemWifi.SubItems.Add(network.dot11DefaultAuthAlgorithm.ToString().Trim((char)0));
                    listItemWifi.SubItems.Add(network.dot11DefaultCipherAlgorithm.ToString().Trim((char)0));
                    listItemWifi.ImageIndex = 0;
                    listNet.Items.Add(listItemWifi);
                }
            }
        }
    }
}
