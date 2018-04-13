/* 

MIT License

Copyright (c) 2018 Gavin Isgar

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/

using System;
using System.IO;
using System.Resources;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Linq;
using System.ComponentModel;
using System.IO.Ports;
using System.Data;
using System.ComponentModel.Design;
using System.Globalization;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace Gritz {
    class ComponentStatuses {
        public static string[] Availability = new string[] {
            // Starts at Code 1
            "null",
            "Other",
            "Unknown",
            "Running/Full Power",
            "Warning",
            "In Test",
            "Not Applicable",
            "Power Off",
            "Off Line",
            "Off Duty",
            "Degraded",
            "Not Installed",
            "Install Error",
            "Power Save - Unknown",
            "Power Save - Lower Power Mode",
            "Power Save - Standby",
            "Power Cycle",
            "Power Save - Warning",
            "Paused",
            "Not Ready",
            "Not Configured",
            "Quiesced"
        };

        public static string[] ConfigManagerErrorCode = new string[] {
            // Starts at Code 0
            "The device is working properly.",
            "This device is not configured correctly.",
            "Windows cannot load the driver for this device.",
            "This device is not working properly. One of its drivers or your registry might be corrupted.",
            "The driver for this device needs a resource that Windows cannot manage.",
            "The boot configuration for this device conflicts with other devices.",
            "Cannot filter.",
            "The driver loader for the device is missing.",
            "This device is not working properly because the controlling firmware is reporting the resources for the device incorrectly.",
            "This device cannot start.",
            "This device failed.",
            "This device cannot find enough free resources that it can use.",
            "Windows cannot verify this device's resources.",
            "This device cannot work properly until you restart your computer.",
            "This device is not working properly because there is probably a re-enumeration problem.",
            "Windows cannot identify all the resources this device uses.",
            "This device is asking for an unknown resource type.",
            "Reinstall the drivers for this device.",
            "Failure using the VxD loader.",
            "Your registry might be corrupted.",
            "System failure. Try changing the driver for this device. If that does not work, see your hardware documentation. Windows is removing this device.",
            "This device is disabled.",
            "System failure. Try changing the driver for this device. If that doesn't work, see your hardware documentation.",
            "This device is not present, is not working properly, or does not have all its drivers installed.",
            "Windows is still setting up this device.",
            "Windows is still setting up this device.",
            "This device does not have valid log configuration.",
            "The drivers for this device are not installed.",
            "This device is disabled because the firmware of the device did not give it the required resources.",
            "This device is using an Interrupt Request (IRQ) resource that another device is using.",
            "This device is not working properly because Windows cannot load the drivers required for this device."
        };

        public static string[] Capabilities = new string[] {
            // Starts at Code 0
            "Unknown",
            "Other",
            "Sequential Access",
            "Random Access",
            "Supports Writing",
            "Encryption",
            "Compression",
            "Supports Removeable Media",
            "Manual Cleaning",
            "Automatic Cleaning",
            "SMART Notification",
            "Supports Dual-Sided Media",
            "Predismount Eject Not Required"
        };
    }
}


