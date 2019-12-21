# ArduMind
A Simple to use template for creating your own Mind controlled Arduino projects with C# and the Neurosky EEG Headset

[![Demo](https://img.youtube.com/vi/kbzIDT0Aby8/0.jpg)](https://www.youtube.com/watch?v=kbzIDT0Aby8)

# Moodlight Example
The Moodlight app uses a arduino with a RGB led to show the current meditation value of the user. The meditation value changes when the user becomes more stressed. This app converts the meditation value between 0 and 100 to a rg value for the RGB Led. The RGB led will be green when the user is unstressed an will turn less green and more red when the user becomes more stressed. In the middle the color will be yellow.

To run the Moodlight example make sure to change the "COM8" value here  
```csharp
port = new SerialPort("COM8", 115200, Parity.None, 8, StopBits.One); To the rigt value of 
```
to the right COM value of your Arduino. Check Device manager if you are not sure which Comport to use.

Do the same for the Mindwave headset Comport here
```csharp
connector.ConnectScan("COM3");
```
Also upload the Moodlight.ino code to the Arduino and enjoy!

### Common problem running the moodlight app
Because the MindWave uses the same CH340G serial chip as cheap arduino clones use there is a issue with the drivers. becuase of this issue you cant upload code to your arduino with the Arduino IDE. A workaround is to remove the Mindwave driver and install the original CH340G driver. Then upload to the Arduino. After that remove the CH340G driver and reinstall the Mindwave driver. Now you can run the app with both the arduino and the mindwave adapter connected to the computer. They work fine together you only cant upload code to the Arduino. 


# Short instrutions

* 1 install the driver located in the Drivers folder
* 2 run the thinkGearConnetor appliation from the thinkGearConnetor folder
* 3 Download the mindwave files from here (direct link) http://download.neurosky.com/updates/mindwave/education/1.1.28.0/MindWave.zip
* 4 unzip the downloaded file
* 5 plug in the mindwave headset
* 6 run the installer located in the downloaded Mindwave.zip file
* 7 Open the example from "ThinkGearSDKfor.NET\SampleProjects\HelloEEG" in visual studio
* 8 Run the project and enjoy!

# common problems
### Cant connect neurosky with thinkgear connector:

Try this:
http://support.neurosky.com/kb/mindwave/cant-find-mindwave-or-cant-connect-mindwave-to-application
