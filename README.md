Tray Milight Control
====================

**NOTE: This application is currently not compatible with v6 of the WiFi bridge!**

This is a Windows tray application to control RGBW LED lights made by MiLight or
its various rebrands like LimitlessLED. It allows you to turn lights on/off, dim
them and change their colors. Lights can be controlled by group or all at the
same time.

![](http://i.imgur.com/LWECxlG.png)

Installation instructions
-------------------------

Download the executable from the [Releases page](https://github.com/Overv/TrayLightControl/releases) and place it in the following directory:

`C:\Users\YOURUSERNAMEHERE\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup`

After that it should start up when you boot your computer and the icon will show up in the task bar as shown in the screenshot. It may initially be hidden behind the arrow, however. If you don't want to reboot your PC, you can just double click to run the EXE after moving it to the "Startup" directory.

Instructions
------------

When the application is started for the first time it will show a configuration
window where you can set the IP address of the wifi bridge and the names of the
4 groups. Instead of finding and entering the IP manually, you can also have the
application automatically find the UDP broadcast address to reach it.

![](http://i.imgur.com/UStaHrX.png)

Press `Save` to save the settings and close the configuration window. You can
always return to that window using the `Configuration` menu item.

You can now right-click the lamp icon in the tray to control your lights.

Credits
-------

This application uses an icon from the awesome [Silk Icons](http://www.famfamfam.com/lab/icons/silk/)
set created by Mark James.

License
-------

See `LICENSE`.
