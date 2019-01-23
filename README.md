![example output](https://github.com/ArabicRobotics/NAO-Kinect/blob/master/logo3.png?raw=true)

# NAO-Kinect

Control NAO using Kinect Device ( using NAO.net, Windows Application and Kinect DLL)

![example output](https://github.com/ArabicRobotics/NAO-Kinect/blob/master/NAOKinectFlow.png?raw=true)

## Projects
1. Main
* Type: Windows Application 
* Rule: User Interface.
* Description: Project which Display Kinect Joints values and Robot data. and interact with user actions.

2. dllKinect
* Type: Windows DLL 
* Rule: Kinect - Windows Interface
* Description: Project which catch Required Events and live data values  from Kinect.

3. DllNAO.netV2
* Type: Windows DLL
* Rule: NAOqi - Windows Interface
* Description: Control NAOqi-Based Robots using C#, it is Improvement for original NAO.NET project listed down.

4. Baku.libqiDotNet:
* Type: Windows DLL
* Rule: dotnet NAoqi Interface.
* Description: Unofficial .NET wrapper library for "qi Framework", the messaging library created by Aldebaran Robotics

### Prerequisites: 

#### Hardware Needed 
1. Kinect (V2 Recommended ) https://developer.microsoft.com/en-us/windows/kinect
2. Windows Computer with USB3 Port
3. NAOqi Robot ( optional ) : https://www.softbankrobotics.com/emea/en

#### Software : 
* Kinect SDK : https://download.microsoft.com/download/F/2/D/F2D1012E-3BC6-49C5-B8B3-5ACFF58AF7B8/KinectSDK-v2.0_1409-Setup.exe

* NAOqi SDK : "pynaoqi-2.1.4.13.win32.exe" (Recommended version )

 Download Page : 

* Choregraphe : "choregraphe-suite-2.1.4.13-win32-setup.exe"( Recommended version )

Download Page :  https://www.arabicrobotics.com/wp/?page_id=912


* NAOqi SDK Documetation :https://www.arabicrobotics.com/Aldebaran/aldeb-doc-2.5.7.1/




## Scenario 
1. Capture Joints Data 
2. Display joints data into Windows form Application 
3. Convert and send movements to Windows Application 
4. Send Movements to NAOqi Robot 
5. Apply Movements on physical Robot example (NAO Robot) Version 4/5
5. Send Back Robot Moves (FW)
6. Display NAOqi Robot Camera in Windows Application. (FW)


####   ---------     Main  Steps     ----------

### 1- Catch Joints..

A. Kinect Catcher: Catch Kinect Joints and face rotation

![example output](https://github.com/ArabicRobotics/NAO-Kinect/blob/master/tumblr_o5aco3jmvd1qza1qzo1_540.gif?raw=true)


B. Main application: Main control and switcher.

![example output](https://github.com/ArabicRobotics/NAO-Kinect/blob/master/KinectValues.png?raw=true)




#### Excecution way using
##### A- Get position 
##### B- Move NAO to the current values


### 2- Display Robot and Human Moves.

Back values to Controller Windows Application 
Return current video position to Windows Application.
![example output](https://github.com/ArabicRobotics/NAO-Kinect/blob/master/Kinect-Robot.png?raw=true)






###### Related projects:
* NAO.NET V1
https://github.com/ArabicRobotics/Python-Execution-dotnet-Wrapper

-----------------------------------------------------------------------
# Details and contact.
# ArabicRobotics.com http://www.ArabicRobotics.com

