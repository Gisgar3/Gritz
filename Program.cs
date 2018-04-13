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


namespace Gritz
{
    class Program
    {   

        public static string comPort = "";
        public static void resetMainScreen() {
            // Used to clear the screen and return to the main menu for the application
            Console.WriteLine("\n*** Press any key to return to start screen.");
            Console.ReadKey();
            Console.Clear();
            Main();
        }

        public static void Main()
        {
            var commands = new Commands();
            Ping ping = new Ping();
            Console.WriteLine("*** Copyright (c) Gavin Isgar 2018\n\n*** Please type in a command:");
            var com = Console.ReadLine(); 
            
                if (commands.commands.Contains(com)) {
                    if (com == "localnettest") {
                        Console.WriteLine("\n*** Please input an I.P or web address:");
                        var ip = Console.ReadLine();
                    try {
                        PingReply reply = ping.Send(ip);
                        if (reply.Status.ToString() == "Success") {
                            Console.WriteLine("\n*** " + ip + " connectivity is normal.");
                            resetMainScreen();
                        }
                        else {
                            Console.WriteLine("\n**PROBLEM** Connectivity is abnormal; received " + reply.Status.ToString());
                            resetMainScreen();
                        }
                    }
                    catch(Exception) {
                        Console.WriteLine("\n**ERROR** An exception was caught during the process. Stopping request.");
                        resetMainScreen();
                    }
                    }

                    if (com == "localhardstats") {
                        Console.Clear();
                        try {
                            // HARDWARE
                            using (var searcher = new ManagementObjectSearcher("SELECT * FROM WIN32_BASEBOARD")) {
                                var BASEBOARD = searcher.Get().Cast<ManagementBaseObject>().ToArray();
                                var num = 0;
                                foreach (var type in BASEBOARD) {
                                    Console.WriteLine("\n----------Motherboard {0}----------", num++);
                                    Console.WriteLine("\n*** Manufacturer: {0}", type.GetPropertyValue("Manufacturer").ToString());
                                    Console.WriteLine("\n*** Name: {0}", type.GetPropertyValue("Name").ToString());
                                    Console.WriteLine("\n*** Description: {0}", type.GetPropertyValue("Description").ToString());
                                    Console.WriteLine("\n*** Serial Number: {0}", type.GetPropertyValue("SerialNumber").ToString());
                                    Console.WriteLine("\n*** Product: {0}", type.GetPropertyValue("Product").ToString());
                                }
                            }
                            using (var searcher = new ManagementObjectSearcher("SELECT * FROM CIM_CHIP")) {
                                var CHIP = searcher.Get().Cast<ManagementBaseObject>().ToArray();
                                var num = 0;
                                foreach (var type in CHIP) {
                                    Console.WriteLine("\n----------Chip {0}----------", num++);
                                    Console.WriteLine("\n*** Manufacturer: {0}", type.GetPropertyValue("Manufacturer").ToString());
                                    Console.WriteLine("\n*** Name: {0}", type.GetPropertyValue("Name").ToString());
                                    Console.WriteLine("\n*** Description: {0}", type.GetPropertyValue("Description").ToString());
                                    Console.WriteLine("\n*** Serial Number: {0}", type.GetPropertyValue("SerialNumber").ToString());
                                }
                            }
                            using (var searcher = new ManagementObjectSearcher("SELECT * FROM WIN32_FAN")) {
                                var FAN = searcher.Get().Cast<ManagementBaseObject>().ToArray();
                                var num = 0;
                                foreach (var type in FAN) {
                                    Console.WriteLine("\n----------Fan {0}----------", num++);
                                    Console.WriteLine("\n*** Name: {0}", type.GetPropertyValue("Name").ToString());
                                    Console.WriteLine("\n*** Description: {0}", type.GetPropertyValue("Description").ToString());
                                    Console.WriteLine("\n*** System Name: {0}", type.GetPropertyValue("SystemName").ToString());
                                    Console.WriteLine("\n*** Device ID: {0}", type.GetPropertyValue("DeviceID").ToString());
                                    Console.WriteLine("\n*** Availability: {0}", ComponentStatuses.Availability.ElementAt(Convert.ToInt32(type.GetPropertyValue("Availability"))));
                                    Console.WriteLine("\n*** Config Code: {0}", ComponentStatuses.ConfigManagerErrorCode.ElementAt(Convert.ToInt32(type.GetPropertyValue("ConfigManagerErrorCode"))));
                                }
                            }
                            using (var searcher = new ManagementObjectSearcher("SELECT * FROM WIN32_KEYBOARD")) {
                                var KEYBOARD = searcher.Get().Cast<ManagementBaseObject>().ToArray();
                                var num = 0;
                                foreach (var type in KEYBOARD) {
                                    Console.WriteLine("\n----------Keyboard {0}----------", num++);
                                    Console.WriteLine("\n*** Name: {0}", type.GetPropertyValue("Name").ToString());
                                    Console.WriteLine("\n*** Description: {0}", type.GetPropertyValue("Description").ToString());
                                    Console.WriteLine("\n*** Layout: {0}", type.GetPropertyValue("Layout").ToString());
                                    Console.WriteLine("\n*** System Name: {0}", type.GetPropertyValue("SystemName").ToString());
                                    Console.WriteLine("\n*** Device ID: {0}", type.GetPropertyValue("DeviceID").ToString());
                                    Console.WriteLine("\n*** PnP Device ID: {0}", type.GetPropertyValue("PNPDeviceID").ToString());
                                    Console.WriteLine("\n*** Availability: {0}", ComponentStatuses.Availability.ElementAt(Convert.ToInt32(type.GetPropertyValue("Availability"))));
                                    Console.WriteLine("\n*** Config Code: {0}", ComponentStatuses.ConfigManagerErrorCode.ElementAt(Convert.ToInt32(type.GetPropertyValue("ConfigManagerErrorCode"))));
                                }
                            }
                            using (var searcher = new ManagementObjectSearcher("SELECT * FROM WIN32_POINTINGDEVICE")) {
                                var POINTINGDEVICE = searcher.Get().Cast<ManagementBaseObject>().ToArray();
                                var num = 0;
                                foreach (var type in POINTINGDEVICE) {
                                    Console.WriteLine("\n----------Mouse {0}----------", num++);
                                    Console.WriteLine("\n*** Manufacturer: {0}", type.GetPropertyValue("Manufacturer").ToString());
                                    Console.WriteLine("\n*** Name: {0}", type.GetPropertyValue("Name").ToString());
                                    Console.WriteLine("\n*** Description: {0}", type.GetPropertyValue("Description").ToString());
                                    Console.WriteLine("\n*** System Name: {0}", type.GetPropertyValue("SystemName").ToString());
                                    Console.WriteLine("\n*** Device ID: {0}", type.GetPropertyValue("DeviceID").ToString());
                                    Console.WriteLine("\n*** PnP Device ID: {0}", type.GetPropertyValue("PNPDeviceID").ToString());
                                    Console.WriteLine("\n*** Availability: {0}", ComponentStatuses.Availability.ElementAt(Convert.ToInt32(type.GetPropertyValue("Availability"))));
                                    Console.WriteLine("\n*** Config Code: {0}", ComponentStatuses.ConfigManagerErrorCode.ElementAt(Convert.ToInt32(type.GetPropertyValue("ConfigManagerErrorCode"))));
                                }
                            }
                            using (var searcher = new ManagementObjectSearcher("SELECT * FROM WIN32_DESKTOPMONITOR")) {
                                var DESKTOPMONITOR = searcher.Get().Cast<ManagementBaseObject>().ToArray();
                                var num = 0;
                                foreach (var type in DESKTOPMONITOR) {
                                    Console.WriteLine("\n----------Monitor {0}----------", num++);
                                    Console.WriteLine("\n*** Manufacturer: {0}", type.GetPropertyValue("MonitorManufacturer").ToString());
                                    Console.WriteLine("\n*** Name: {0}", type.GetPropertyValue("Name").ToString());
                                    Console.WriteLine("\n*** Description: {0}", type.GetPropertyValue("Description").ToString());
                                    Console.WriteLine("\n*** Type: {0}", type.GetPropertyValue("MonitorType").ToString());
                                    Console.WriteLine("\n*** System Name: {0}", type.GetPropertyValue("SystemName").ToString());
                                    Console.WriteLine("\n*** Device ID: {0}", type.GetPropertyValue("DeviceID").ToString());
                                    Console.WriteLine("\n*** PnP Device ID: {0}", type.GetPropertyValue("PNPDeviceID").ToString());
                                    Console.WriteLine("\n*** Availability: {0}", ComponentStatuses.Availability.ElementAt(Convert.ToInt32(type.GetPropertyValue("Availability"))));   
                                }
                            }
                            Console.WriteLine("\n----------------------------------------");
                            resetMainScreen();
                        }
                        catch (Exception) {
                            Console.WriteLine("\n**ERROR** An exception was caught during the process. Stopping request.");
                            resetMainScreen();
                        }
                    }

                    if (com == "localsoftstats") {
                        Console.Clear();
                        using (var searcher = new ManagementObjectSearcher("SELECT * FROM WIN32_BIOS")) {
                                var BIOS = searcher.Get().Cast<ManagementBaseObject>().ToArray();
                                var num = 0;
                                foreach (var type in BIOS) {
                                    Console.WriteLine("\n----------BIOS {0}----------", num++);
                                    Console.WriteLine("\n*** Manufacturer: {0}", type.GetPropertyValue("Manufacturer").ToString());
                                    Console.WriteLine("\n*** Name: {0}", type.GetPropertyValue("Name").ToString());
                                    Console.WriteLine("\n*** Description: {0}", type.GetPropertyValue("Description").ToString());
                                    Console.WriteLine("\n*** Version: {0}", type.GetPropertyValue("Version").ToString());
                                    Console.WriteLine("\n*** Serial Number: {0}", type.GetPropertyValue("SerialNumber").ToString());
                                }
                            }
                            using (var searcher = new ManagementObjectSearcher("SELECT * FROM WIN32_OPERATINGSYSTEM")) {
                                var OPERATINGSYSTEM = searcher.Get().Cast<ManagementBaseObject>().ToArray();
                                var num = 0;
                                foreach (var type in OPERATINGSYSTEM) {
                                    Console.WriteLine("\n----------OPERATING SYSTEM {0}----------", num++);
                                    Console.WriteLine("\n*** Manufacturer: {0}", type.GetPropertyValue("Manufacturer").ToString());
                                    Console.WriteLine("\n*** Name: {0}", type.GetPropertyValue("Name").ToString());
                                    Console.WriteLine("\n*** Description: {0}", type.GetPropertyValue("Description").ToString());
                                    Console.WriteLine("\n*** Version: {0}", type.GetPropertyValue("Version").ToString());
                                    Console.WriteLine("\n*** Build Number: {0}", type.GetPropertyValue("BuildNumber").ToString());
                                    Console.WriteLine("\n*** Serial Number: {0}", type.GetPropertyValue("SerialNumber").ToString());
                                    Console.WriteLine("\n*** Build Type: {0}", type.GetPropertyValue("BuildType").ToString());
                                    Console.WriteLine("\n*** System Drive: {0}", type.GetPropertyValue("SystemDrive").ToString());
                                    Console.WriteLine("\n*** OS Architecture: {0}", type.GetPropertyValue("OSArchitecture").ToString());
                                    Console.WriteLine("\n*** OS Type: {0}", type.GetPropertyValue("OSType").ToString());
                                    Console.WriteLine("\n*** Organization: {0}", type.GetPropertyValue("Organization").ToString());
                                }
                            }
                    }

                    if (com == "comactivecheck") {
                        var ports = SerialPort.GetPortNames();
                        foreach (string port in ports) {
                            Console.WriteLine("\n*** Visible Port: {0}", port);
                            resetMainScreen();
                        }
                    }

                    if (com == "comtest") {
                        if (comPort == "") {
                            Console.WriteLine("\n**PROBLEM** No communication port has been set.");
                            resetMainScreen();
                        }
                        else {
                            try {
                                using (var sp = new System.IO.Ports.SerialPort(comPort, 115200, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One)) {
                                // Raspberry Pi Program must contain code to connect to COM as well
                                sp.Open();
                                sp.WriteLine("\n*** Communication test from Administrative diagnostic computer.");
                                Console.WriteLine("\n**MESSAGE** From Client: {0}", sp.ReadLine());
                                sp.Close();
                                resetMainScreen();
                            }
                        }
                        catch (Exception) {
                            Console.WriteLine("\n**ERROR** An exception was caught during the process. Stopping request.");
                            resetMainScreen();
                        }
                        }
                    }

                    if (com == "comset") {
                        Console.WriteLine("\n*** Type in the name of the port needed for communication:");
                        var portname = Console.ReadLine();
                        try {
                            comPort = portname;
                            Console.WriteLine("\n*** The communication port has been set to '{0}'.", comPort);
                            resetMainScreen();
                        }
                        catch (Exception) {
                            Console.WriteLine("\n**ERROR** An exception was caught during the process. Stopping request.");
                            resetMainScreen();
                        }
                    }

                    
                }
                else {
                    Console.WriteLine("\n**ERROR** '{0}' is not a valid command.", com);
                    resetMainScreen();
                }

            }
        }

    class Commands {
        public string[] commands = new string[] {"localnettest", "localhardstats", "localsoftstats", "comactivecheck", "comtest", "comset"};
    }

}
