using Microsoft.Kinect;
using MotorController.Hand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorController
{
public  class Globals
    {
    public string txtRitght;
    public string txtLeft;
    //////////////////////////////////// My Body Classes
    clsHand hand;
    clsShoulder shoulder;
    clsWrist wrist;
    clsElbow elbow;

    //public System.IO.Ports.SerialDataReceivedEventHandler DataRecieved;
    public event EventHandler<clsKinectArgs> KinectDataReceived;

        /// <summary>
        /// Radius of drawn hand circles
        /// </summary>
        private const double HandSize = 30;

        /// <summary>
        /// Thickness of drawn joint lines
        /// </summary>
        private const double JointThickness = 3;

        /// <summary>
        /// Thickness of clip edge rectangles
        /// </summary>
        private const double ClipBoundsThickness = 10;

        /// <summary>
        /// Constant for clamping Z values of camera space points from being negative
        /// </summary>
        private const float InferredZPositionClamp = 0.1f;
        /// <summary>
        /// Active Kinect sensor
        /// </summary>
       private KinectSensor kinectSensor = null;

        /// <summary>
        /// Coordinate mapper to map one type of point to another
        /// </summary>
        private CoordinateMapper coordinateMapper = null;

        /// <summary>
        /// Reader for body frames
        /// </summary>
        private BodyFrameReader bodyFrameReader = null;

        /// <summary>
        /// Array for the bodies
        /// </summary>
        private Body[] bodies = null;

        /// <summary>
        /// definition of bones
        /// </summary>
        private List<Tuple<JointType, JointType>> bones;

        /// <summary>
        /// Width of display (depth space)
        /// </summary>
        private int displayWidth;

        /// <summary>
        /// Height of display (depth space)
        /// </summary>
        private int displayHeight;     

        /// <summary>
        /// Current status text to display
        /// </summary>
        public string statusText = null;


    /// <summary>
    /// 
    /// </summary>
        public void initilize()
        {

            #region HandsInitit
            ////////////// HAND 
            hand = new clsHand();
            elbow = new clsElbow();
            shoulder = new clsShoulder();
            wrist = new clsWrist();
            //////////////
            #endregion
            this.kinectSensor = KinectSensor.GetDefault();

            // get the coordinate mapper
            this.coordinateMapper = this.kinectSensor.CoordinateMapper;

            // get the depth (display) extents
            FrameDescription frameDescription = this.kinectSensor.DepthFrameSource.FrameDescription;

            // get size of joint space
            this.displayWidth = frameDescription.Width;
            this.displayHeight = frameDescription.Height;

            // open the reader for the body frames
            this.bodyFrameReader = this.kinectSensor.BodyFrameSource.OpenReader();

            // a bone defined as a line between two joints
            this.bones = new List<Tuple<JointType, JointType>>();

            // Torso
            this.bones.Add(new Tuple<JointType, JointType>(JointType.Head, JointType.Neck));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.Neck, JointType.SpineShoulder));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineShoulder, JointType.SpineMid));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineMid, JointType.SpineBase));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineShoulder, JointType.ShoulderRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineShoulder, JointType.ShoulderLeft));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.HipRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.HipLeft));

            // Right Arm
            this.bones.Add(new Tuple<JointType, JointType>(JointType.ShoulderRight, JointType.ElbowRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.ElbowRight, JointType.WristRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.WristRight, JointType.HandRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.HandRight, JointType.HandTipRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.WristRight, JointType.ThumbRight));

            // Left Arm
            this.bones.Add(new Tuple<JointType, JointType>(JointType.ShoulderLeft, JointType.ElbowLeft));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.ElbowLeft, JointType.WristLeft));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.WristLeft, JointType.HandLeft));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.HandLeft, JointType.HandTipLeft));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.WristLeft, JointType.ThumbLeft));

            // Right Leg
            this.bones.Add(new Tuple<JointType, JointType>(JointType.HipRight, JointType.KneeRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.KneeRight, JointType.AnkleRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.AnkleRight, JointType.FootRight));

            // Left Leg
            this.bones.Add(new Tuple<JointType, JointType>(JointType.HipLeft, JointType.KneeLeft));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.KneeLeft, JointType.AnkleLeft));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.AnkleLeft, JointType.FootLeft));



            // set IsAvailableChanged event notifier
            this.kinectSensor.IsAvailableChanged += kinectSensor_IsAvailableChanged;            
            // open the sensor
            this.kinectSensor.Open();

            // set the status text
            statusText = this.kinectSensor.IsAvailable ? "Available"
                                                            : "Not Available";                       
            this.bodyFrameReader.FrameArrived += this.Reader_FrameArrived;            
        }


        void kinectSensor_IsAvailableChanged(object sender, IsAvailableChangedEventArgs e)
        {
            try
            {
                this.statusText = this.kinectSensor.IsAvailable.ToString();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            

        }
        public void Disconnect()
        {

            if (this.bodyFrameReader != null)
            {
                // BodyFrameReader is IDisposable
                this.bodyFrameReader.Dispose();
                this.bodyFrameReader = null;
            }
            if (this.kinectSensor != null)
            {
                this.kinectSensor.Close();
                this.kinectSensor = null;
            }
        }
    

        #region Frame Data
        
         /// <summary>
        /// Handles the body frame data arriving from the sensor
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Reader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            bool dataReceived = false;
            
            using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
            {
                if (bodyFrame != null)
                {
                    if (this.bodies == null)
                    {
                        this.bodies = new Body[bodyFrame.BodyCount];
                    }

                    // The first time GetAndRefreshBodyData is called, Kinect will allocate each Body in the array.
                    // As long as those body objects are not disposed and not set to null in the array,
                    // those body objects will be re-used.
                    bodyFrame.GetAndRefreshBodyData(this.bodies);
                    dataReceived = true;
                }
            }

            if (dataReceived)
            {
                foreach (Body body in this.bodies)
                {

                    if (body.IsTracked)
                    {

                        IReadOnlyDictionary<JointType, Joint> joints = body.Joints;

                        foreach (JointType jointType in joints.Keys)
                        {
                            // sometimes the depth(Z) of an inferred joint may show as negative
                            // clamp down to 0.1f to prevent coordinatemapper from returning (-Infinity, -Infinity)
                            CameraSpacePoint position = joints[jointType].Position;
                            if (position.Z < 0)
                            {
                                position.Z = InferredZPositionClamp;
                            }
                        }
                        SetBodyFrameValues(body);

                        string data = "";
                        OnKinectDataReceived(new clsKinectArgs  (e, data, DateTime.Now));
                    }
                }
            }
        } 
        #endregion


    /// <summary>
    /// get the fram body status and set my classes data from body parameter
    /// </summary>
    /// <param name="body">Body to get values from and fill the classes data </param>
        void SetBodyFrameValues(Body body)
        { 
        #region Right and left

                        #region elbow
                        utilities.Position elbowPosition = new utilities.Position();
                        elbowPosition.x = body.Joints[JointType.ElbowRight].Position.X;
                        elbowPosition.y = body.Joints[JointType.ElbowRight].Position.Y;
                        elbowPosition.z = body.Joints[JointType.ElbowRight].Position.Z;
                        elbow.SetElbow(utilities.Side.Right, elbowPosition);
                        ////left Elbow
                        elbowPosition.x = body.Joints[JointType.ElbowLeft].Position.X;
                        elbowPosition.y = body.Joints[JointType.ElbowLeft].Position.Y;
                        elbowPosition.z = body.Joints[JointType.ElbowLeft].Position.Z;
                        elbow.SetElbow(utilities.Side.Left, elbowPosition);
                        #endregion // elbow


                        #region Wrist
                        utilities.Position wristPosition = new utilities.Position();
                        wristPosition.x = body.Joints[JointType.WristRight].Position.X;
                        wristPosition.y = body.Joints[JointType.WristRight].Position.Y;
                        wristPosition.z = body.Joints[JointType.WristRight].Position.Z;
                        wrist.SetWrist(utilities.Side.Right, wristPosition);
                        ////left Wrist 
                        wristPosition.x = body.Joints[JointType.WristLeft].Position.X;
                        wristPosition.y = body.Joints[JointType.WristLeft].Position.Y;
                        wristPosition.z = body.Joints[JointType.WristLeft].Position.Z;
                        wrist.SetWrist(utilities.Side.Left, wristPosition);
                        #endregion // Wrist

                        #region Shoulder
                        /// Right Shoulder
                        utilities.Position shoulderPosition = new utilities.Position();
                        shoulderPosition.x = body.Joints[JointType.ShoulderRight].Position.X;
                        shoulderPosition.y = body.Joints[JointType.ShoulderRight].Position.Y;
                        shoulderPosition.z = body.Joints[JointType.ShoulderRight].Position.Z;
                        shoulder.SetShoulder(utilities.Side.Right, shoulderPosition);
                        ////left Shoulder 
                        shoulderPosition.x = body.Joints[JointType.ShoulderLeft].Position.X;
                        shoulderPosition.y = body.Joints[JointType.ShoulderLeft].Position.Y;
                        shoulderPosition.z = body.Joints[JointType.ShoulderLeft].Position.Z;
                        shoulder.SetShoulder(utilities.Side.Left, shoulderPosition);
                        #endregion // Wrist


                        #region HandsPositions  
                        clsHand.datachanged = true;
                        /// Right Hand
                        ///                         
                        MotorController.utilities.Position handPosition = new utilities.Position();
                        handPosition.x = body.Joints[JointType.HandRight].Position.X;
                        handPosition.y = body.Joints[JointType.HandRight].Position.Y;
                        handPosition.z = body.Joints[JointType.HandRight].Position.Z;
                        hand.SetHandPosition(MotorController.utilities.Side .Right,handPosition);
                        hand.SetHandState(utilities.Side.Right, body.HandRightState);

                        // left Hand
                        handPosition.x = body.Joints[JointType.HandLeft].Position.X;
                        handPosition.y = body.Joints[JointType.HandLeft].Position.Y;
                        handPosition.z = body.Joints[JointType.HandLeft].Position.Z;
                        hand.SetHandPosition(MotorController.utilities.Side .Left,handPosition);
                        hand.SetHandState(utilities.Side.Left, body.HandLeftState);

            
                        //End of setting Hands                        
                        // Debug
                        this.txtRitght = body.Joints[JointType.HandRight].Position.X.ToString();
                        this.txtLeft = body.Joints[JointType.HandLeft].Position.X.ToString();

#endregion //Hands positions
#endregion // Right and left
        }
        #region events
    /// <summary>
    /// this event fired for every frame got from the Kinect.
    /// </summary>
    /// <param name="e"> frame data , date, update body classes data.</param>
        protected virtual void OnKinectDataReceived(clsKinectArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler<clsKinectArgs> handler = KinectDataReceived;
            // Event will be null if there are no subscribers
            if (handler != null)
            {
                //Set classs hand that data changed so we can use this by timmer,...
                clsHand.datachanged = true;
                // Update hand data catched by event after occured.
                e.hand = hand;
                e.shoulder = shoulder;
                e.elbow = elbow;
                e.wrist = wrist;
                e.date = DateTime.Now;
                handler(this, e);
            }
        }
        #endregion
    }
}
