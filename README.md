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
Description: Unofficial .NET wrapper library for "qi Framework", the messaging library created by Aldebaran Robotics



## Hardware Needed 
1. Kinect (V2 Recommended ) 
2. Windows Computer with USB3 Port
3. NAOqi Robot / Virtual Robot (Choregraphe )




## Scenario 

1. Capture Joints Data 
2. Display joints data into Windows form Application 
3. Convert and send movements to Windows Application 
4. Send Movements to NAOqi Robot 
5. Apply Movements on physical Robot example (NAO Robot) Version 4/5
5. Send Back Robot Moves (FW)
6. Display NAOqi Robot Camera in Windows Application. (FW)


#### ---------     Main Steps     ----------

### 1- Go way

A. Kinect Catcher: Catch Kinect Joints and face rotation

![example output](https://github.com/ArabicRobotics/NAO-Kinect/blob/master/tumblr_o5aco3jmvd1qza1qzo1_540.gif?raw=true)


B. Main application: Main control and switcher.

![example output](https://github.com/ArabicRobotics/NAO-Kinect/blob/master/KinectValues.png?raw=true)




#### Excecution Way using
##### A- Get position 
##### B- Move NAO to the current Values

## Using NAO.NET...( Using .NET to control NAOqi Robots)
![example output](https://github.com/ArabicRobotics/NAO-Kinect/blob/master/{8D430CE4-CCCA-4B67-AF45-5A7E8BEBDA84}.jpg?raw=true)

#### Execution Result Image : 
![example output](https://github.com/ArabicRobotics/NAO-Kinect/blob/master/NAO.NETDemo.png?raw=true)

#### URL Execution Example :
https://www.youtube.com/watch?v=oOyy-2XyT-c

#### Documentation : 
https://www.arabicrobotics.com/wp/


### 2- Back way

Back values to Controller Windows Application 
Return current video position to Windows Application.
![example output](https://github.com/ArabicRobotics/NAO-Kinect/blob/master/Kinect-Robot.png?raw=true)


##### Resources:

* Baku.libqiDotNet: 
https://github.com/malaybaku/BakuLibQiDotNet
