using System;

using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.IO.Ports;
using NeuroSky.ThinkGear;
using NeuroSky.ThinkGear.Algorithms;

namespace testprogram {
    class Program {
        static Connector connector;
        static SerialPort port;
        static string inputData = "";

        public static void Main(string[] args) {

            Console.WriteLine("HelloEEG!");

            // Initialize a new Connector and add event handlers

            connector = new Connector();
            connector.DeviceConnected += new EventHandler(OnDeviceConnected);
            connector.DeviceConnectFail += new EventHandler(OnDeviceFail);
            connector.DeviceValidating += new EventHandler(OnDeviceValidating);

            // Scan for devices across COM ports
            // The COM port named will be the first COM port that is checked.
            connector.ConnectScan("COM3");

            // Blink detection needs to be manually turned on
            connector.setBlinkDetectionEnabled(true);
            Thread.Sleep(450000);




            System.Console.WriteLine("Goodbye.");
            connector.Close();
            Environment.Exit(0);
        }


        // Called when a device is connected 

        static void OnDeviceConnected(object sender, EventArgs e) {

            Connector.DeviceEventArgs de = (Connector.DeviceEventArgs)e;

            Console.WriteLine("Device found on: " + de.Device.PortName);

            Console.WriteLine("Connecting to Arduino");

            port = new SerialPort("COM8", 115200, Parity.None, 8, StopBits.One);

            port.Open();

            Thread.Sleep(3000);

            Console.WriteLine("Connected to Arduino");


            de.Device.DataReceived += new EventHandler(OnDataReceived);

        }




        // Called when scanning fails

        static void OnDeviceFail(object sender, EventArgs e) {

            Console.WriteLine("No devices found! :(");

        }



        // Called when each port is being validated

        static void OnDeviceValidating(object sender, EventArgs e) {

            Console.WriteLine("Validating: ");

        }

        // Called when data is received from a device

        static void OnDataReceived(object sender, EventArgs e) {

            //Device d = (Device)sender;

            Device.DataEventArgs de = (Device.DataEventArgs)e;
            DataRow[] tempDataRowArray = de.DataRowArray;

            TGParser tgParser = new TGParser();
            tgParser.Read(de.DataRowArray);

            /* Loops through the newly parsed data of the connected headset*/
            // The comments below indicate and can be used to print out the different data outputs. 

            for (int i = 0; i < tgParser.ParsedData.Length; i++) {

                if (tgParser.ParsedData[i].ContainsKey("Attention"))
                {
                   
                    Console.WriteLine("att Value:" + tgParser.ParsedData[i]["Attention"]);



                    if (tgParser.ParsedData[i]["Attention"] > 60 )
                    {
                        
                        port.WriteLine(1 + ";" + 0 + ";");
                        Console.WriteLine(1);

                    }
                    else
                    {
                        port.WriteLine(0 + ";" + 0 + ";");
                        Console.WriteLine(0);
                    }


                    Thread.Sleep(2000);

                    Console.WriteLine("recieved = " + port.ReadExisting());
                    

                }

            }

        }
        

    }

}
