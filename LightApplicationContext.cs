using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using TrayLightControl.Properties;

namespace TrayLightControl {
    public class LightApplicationContext : ApplicationContext {
        private readonly ConfigForm _configForm = new ConfigForm();
        private readonly NotifyIcon _notifyIcon;
        private LightBridge _bridge;

        public static LightApplicationContext CurrentContext { get; private set; }

        public LightApplicationContext() {
            CurrentContext = this;

            // Set up tray icon
            _notifyIcon = new NotifyIcon {
                Icon = Resources.lightbulb,
                Visible = true,
                Text = "Milight Control"
            };

            Reload();

            // If this is the first time, show the configuration window immediately
            if ((bool) Settings.Default["FirstStart"]) {
                _configForm.ShowDialog();

                Settings.Default["FirstStart"] = false;
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// Recreate context menu and reconnect to bridge.
        /// </summary>
        public void Reload() {
            var menuItems = new List<MenuItem>();

            // Add light control menu items
            for (int group = 0; group <= 4; group++) {
                AddLightControlMenuItems(ref menuItems, group);
            }

            // Add miscellaneous items after a separator
            menuItems.Add(new MenuItem("-"));
            menuItems.Add(new MenuItem("Configuration", ShowConfig));
            menuItems.Add(new MenuItem("Exit", Exit));

            _notifyIcon.ContextMenu = new ContextMenu(menuItems.ToArray());

            // Connect to bridge
            _bridge = new LightBridge((string) Settings.Default["BridgeAddress"]);
        }

        /// <summary>
        /// Add the light control menu items for the specified group (can be 0).
        /// </summary>
        /// <param name="menuItems">List of menu items to append to.</param>
        /// <param name="group">Group to create menu items for.</param>
        private void AddLightControlMenuItems(ref List<MenuItem> menuItems, int group) {
            var groupMenuItem = new MenuItem(GetGroupName(group));

            // On/off controls followed by separator for more advanced controls
            groupMenuItem.MenuItems.Add(new MenuItem("On", (sender, args) => _bridge.SetLightState(group, true)));
            groupMenuItem.MenuItems.Add(new MenuItem("Off", (sender, args) => _bridge.SetLightState(group, false)));

            groupMenuItem.MenuItems.Add(new MenuItem("-"));

            // Dimming controls
            var dimMenuItem = new MenuItem("Dim");

            for (int p = 0; p <= 100; p += 20) {
                var ptemp = p;
                dimMenuItem.MenuItems.Add(new MenuItem(p + "%", (sender, args) => _bridge.SetLightBrightness(group, ptemp)));
            }

            groupMenuItem.MenuItems.Add(dimMenuItem);

            // Color controls
            var colorMenuItem = new MenuItem("Color");

            colorMenuItem.MenuItems.Add(new MenuItem("White", (sender, args) => _bridge.SetWhite(group)));
            colorMenuItem.MenuItems.Add(new MenuItem("-"));

            foreach (LightColor color in Enum.GetValues(typeof(LightColor))) {
                var ctemp = color;
                colorMenuItem.MenuItems.Add(new MenuItem(color.ToString(), (sender, args) => _bridge.SetLightColor(group, ctemp)));
            }

            groupMenuItem.MenuItems.Add(colorMenuItem);

            menuItems.Add(groupMenuItem);

            // Add separator between "all lights" group and rest
            if (group == 0) {
                menuItems.Add(new MenuItem("-"));
            }
        }

        /// <summary>
        /// Get the human friendly name of the group with the specified id, where 0 = all lights.
        /// </summary>
        /// <param name="group">Group id.</param>
        /// <returns>Human friendly name of group.</returns>
        private string GetGroupName(int group) {
            Debug.Assert(group >= 0 && group <= 4);

            switch (group) {
                case 0: return "All lights";

                case 1: return (string) Settings.Default["GroupName1"];
                case 2: return (string) Settings.Default["GroupName2"];
                case 3: return (string) Settings.Default["GroupName3"];
                case 4: return (string) Settings.Default["GroupName4"];

                default: return null;
            }
        }

        /// <summary>
        /// Event handler for "Configuration" menu item.
        /// </summary>
        private void ShowConfig(object sender, EventArgs e) {
            if (_configForm.Visible) {
                _configForm.Activate();
            } else {
                _configForm.ShowDialog();
            }
        }

        /// <summary>
        /// Event handler for the "Exit" menu item.
        /// </summary>
        private void Exit(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}