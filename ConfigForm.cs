using System;
using System.Net.Sockets;
using System.Windows.Forms;
using TrayLightControl.Properties;

namespace TrayLightControl {
    public partial class ConfigForm : Form {
        public ConfigForm() {
            InitializeComponent();

            textIP.Text = (string) Settings.Default["BridgeAddress"];
            textGroup1.Text = (string) Settings.Default["GroupName1"];
            textGroup2.Text = (string) Settings.Default["GroupName2"];
            textGroup3.Text = (string) Settings.Default["GroupName3"];
            textGroup4.Text = (string) Settings.Default["GroupName4"];
        }

        /// <summary>
        /// Event handler for automatic IP find button.
        /// </summary>
        private void buttonIPFind_Click(object sender, EventArgs e) {
            textIP.Text = LightBridge.GetBroadcastAddress().ToString();
        }

        /// <summary>
        /// Event handler for "Save" button.
        /// </summary>
        private void buttonSave_Click(object sender, EventArgs e) {
            // Check if entered IP address is correct
            try {
                new UdpClient(textIP.Text, 8899);
            } catch (Exception) {
                MessageBox.Show("Invalid bridge IP address!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if group names are all non-empty
            if (textGroup1.Text.Trim().Length == 0 ||
                textGroup2.Text.Trim().Length == 0 ||
                textGroup3.Text.Trim().Length == 0 ||
                textGroup4.Text.Trim().Length == 0) {

                MessageBox.Show("Invalid group name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Store settings
            Settings.Default["BridgeAddress"] = textIP.Text;

            Settings.Default["GroupName1"] = textGroup1.Text;
            Settings.Default["GroupName2"] = textGroup2.Text;
            Settings.Default["GroupName3"] = textGroup3.Text;
            Settings.Default["GroupName4"] = textGroup4.Text;

            Settings.Default.Save();

            // Apply settings
            LightApplicationContext.CurrentContext.Reload();

            Close();
        }
    }
}
