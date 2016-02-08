using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;

namespace TrayLightControl {
    /// <summary>
    /// Manager class for wifi bridge and controlling lights through it.
    /// </summary>
    public class LightBridge {
        private readonly UdpClient _client;

        /// <summary>
        /// Amount of times to send each command (for reliability).
        /// </summary>
        public int Retries { get; set; }

        /// <summary>
        /// Delay between each command in milliseconds.
        /// </summary>
        public int Delay { get; set; }

        /// <summary>
        /// Create a wifi bridge connection.
        /// </summary>
        /// <param name="ip">IP address of wifi bridge or broadcast address.</param>
        /// <param name="port">Port of wifi bridge.</param>
        /// <param name="retries">Amount of times to send each command.</param>
        /// <param name="delay">Delay between each command.</param>
        public LightBridge(string ip, int port = 8899, int retries = 3, int delay = 33) {
            _client = new UdpClient(ip, port);

            Delay = delay;
            Retries = retries;
        }

        /// <summary>
        /// Turn a group of lights on or off.
        /// </summary>
        /// <param name="group">Group id.</param>
        /// <param name="on">On state.</param>
        public void SetLightState(int group, bool on) {
            Debug.Assert(group >= 0 && group <= 4);

            byte groupCommand;

            if (group == 0) {
                groupCommand = 0x42;
            } else {
                groupCommand = (byte) (0x43 + group * 2);
            }

            if (!on) {
                if (group == 0) {
                    groupCommand--;
                } else {
                    groupCommand++;
                }
            }

            SendCommand(new byte[] { groupCommand, 0x00 });
        }

        /// <summary>
        /// Change the brightness of a group of lights.
        /// </summary>
        /// <remarks>
        /// This will automatically turn on the group of lights.
        /// </remarks>
        /// <param name="group">Group id.</param>
        /// <param name="brightness">Brightness percentage.</param>
        public void SetLightBrightness(int group, int brightness) {
            Debug.Assert(brightness >= 0 && brightness <= 100);

            SetLightState(group, true);

            // Minimum brightness is 2
            var rawBrightness = (byte) Math.Max(2, brightness / 100.0 * 0x1B);

            SendCommand(new byte[] { 0x4E, rawBrightness });
        }

        /// <summary>
        /// Change the color of a group of lights.
        /// </summary>
        /// <remarks>
        /// This will automatically turn on the group of lights.
        /// </remarks>
        /// <param name="group">Group id.</param>
        /// <param name="color">Color.</param>
        public void SetLightColor(int group, LightColor color) {
            SetLightState(group, true);
            SendCommand(new byte[] { 0x40, (byte) color });
        }

        /// <summary>
        /// Change the color of a group of lights to white.
        /// </summary>
        /// <remarks>
        /// This will automatically turn on the group of lights.
        /// </remarks>
        /// <param name="group">Group id.</param>
        public void SetWhite(int group) {
            SetLightState(group, true);

            byte groupCommand;

            if (group == 0) {
                groupCommand = 0xC2;
            } else {
                groupCommand = (byte) (0xC3 + group * 2);
            }

            SendCommand(new byte[] { groupCommand, 0x00 });
        }

        /// <summary>
        /// Close the connection with the bridge.
        /// </summary>
        public void Close() {
            _client.Close();
        }

        /// <summary>
        /// Send a 2-byte command to the bridge with retries.
        /// </summary>
        /// <param name="command">2-byte command to send.</param>
        private void SendCommand(byte[] command) {
            Debug.Assert(command.Length == 2);

            // Construct packet from command
            Array.Resize(ref command, command.Length + 1);
            command[command.Length - 1] = 0x55;

            // Send multiple times for extra reliability
            for (int i = 0; i < 3; i++) {
                _client.Send(command, command.Length);

                // Give bridge some time to handle messages
                Thread.Sleep(Delay);
            }
        }

        /// <summary>
        /// Get the UDP broadcast address for the local client.
        /// </summary>
        /// <returns>UDP broadcast address.</returns>
        public static IPAddress GetBroadcastAddress() {
            var adapter = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault();

            foreach (var address in adapter.GetIPProperties().UnicastAddresses) {
                if (address.Address.AddressFamily == AddressFamily.InterNetwork) {
                    var addr = address.Address.GetAddressBytes();
                    var mask = address.IPv4Mask.GetAddressBytes();

                    for (int i = 0; i < 4; i++) {
                        if (mask[i] != 255) {
                            addr[i] = 255;
                        }
                    }

                    return new IPAddress(addr);
                }
            }

            return new IPAddress(0);
        }
    }
}
