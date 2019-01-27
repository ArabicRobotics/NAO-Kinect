using MotorController.Hand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorController
{
    public class clsKinectArgs :EventArgs
    {

        public clsKinectArgs(Microsoft.Kinect.BodyFrameArrivedEventArgs args, string data, DateTime timeOccured, string comments = "No Comments")
        {
            msg = data;
            _date = timeOccured;
            _comments = comments;
        }
        //Hand
        /// <summary>
        /// 
        /// </summary>
        private clsHand _hand;
        /// <summary>
        /// 
        /// </summary>
        private clsElbow _elbow;
        private clsShoulder _shoulder;
        private clsWrist _wrist;
        public clsWrist wrist
        {
            get
            {
                return _wrist;
            }
            set { _wrist = value; }
        }

        public clsElbow elbow
        {
            get
            {
                return _elbow;
            }
            set { _elbow= value; }
        }

        public clsHand hand
        {
            get {                 
                return _hand; }
            set { _hand = value; }
        }

        public clsShoulder shoulder
        {

            get { return _shoulder; }
            set { _shoulder = value; }
        }

        private string msg;
        public string Message
        {
            get { return msg; }
            set { msg = value; }
        }


        //private  Microsoft.Kinect.BodyFrameArrivedEventArgs _kinectArgs;
        //public Microsoft.Kinect.BodyFrameArrivedEventArgs kinectArgs
        //{
        //    get { return _kinectArgs; }
        //    set { _kinectArgs = value; }
        //}
        

        private string _comments;
        public string Comments
        {
            get {               
                return _comments; }
            set { _comments = value; }
        }
        private DateTime _date;
        public DateTime date {            
            get
            {return _date;}
            set 
            { _date = value; }
        }
        }

}