using NeuroSky.ThinkGear;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HelloEEG
{
    public partial class Form1 : Form
    {
        static Connector connector;
        static byte poorSig;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
        Console.WriteLine("HelloEEG!");

            // Initialize a new Connector and add event handlers

            connector = new Connector();
            connector.DeviceConnected += new EventHandler(OnDeviceConnected);
            connector.DeviceConnectFail += new EventHandler(OnDeviceFail);
            connector.DeviceValidating += new EventHandler(OnDeviceValidating);

            // Scan for devices across COM ports
            // The COM port named will be the first COM port that is checked.
            connector.ConnectScan("COM40");

            // Blink detection needs to be manually turned on
            connector.setBlinkDetectionEnabled(true);
            Thread.Sleep(450000);




            System.Console.WriteLine("Goodbye.");
            connector.Close();
            Environment.Exit(0);

    }


    // Called when a device is connected 

    static void OnDeviceConnected(object sender, EventArgs e)
        {

            Connector.DeviceEventArgs de = (Connector.DeviceEventArgs)e;

            Console.WriteLine("Device found on: " + de.Device.PortName);
            de.Device.DataReceived += new EventHandler(OnDataReceived);

        }




        // Called when scanning fails

        static void OnDeviceFail(object sender, EventArgs e)
        {

            Console.WriteLine("No devices found! :(");

        }



        // Called when each port is being validated

        static void OnDeviceValidating(object sender, EventArgs e)
        {

            Console.WriteLine("Validating: ");

        }

        // Called when data is received from a device

        static void OnDataReceived(object sender, EventArgs e)
        {

            /* Cast the event sender as a Device object, and e as the Device's DataEventArgs */
            Device d = (Device)sender;
            Device.DataEventArgs de = (Device.DataEventArgs)e;

            /* Create a TGParser to parse the Device's DataRowArray[] */
            TGParser tgParser = new TGParser();
            tgParser.Read(de.DataRowArray);

            /* Loop through parsed data TGParser for its parsed data... */
            for (int i = 0; i < tgParser.ParsedData.Length; i++)
            {

                // See the Data Types documentation for valid keys such
                // as "Raw", "PoorSignal", "Attention", etc.

                if (tgParser.ParsedData[i].ContainsKey("Raw"))
                {
                    Console.WriteLine("Raw Value:" + tgParser.ParsedData[i]["Raw"]);
                }

                if (tgParser.ParsedData[i].ContainsKey("PoorSignal"))
                {
                    Console.WriteLine("PQ Value:" + tgParser.ParsedData[i]["PoorSignal"]);
                }

                if (tgParser.ParsedData[i].ContainsKey("Attention"))
                {
                    Console.WriteLine("Att Value:" + tgParser.ParsedData[i]["Attention"]);
                }

                if (tgParser.ParsedData[i].ContainsKey("Meditation"))
                {
                    Console.WriteLine("Med Value:" + tgParser.ParsedData[i]["Meditation"]);
                }


            }
        }

    }
}

