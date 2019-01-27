using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectCatcher.Hand
{
     public class clsWrist
    {
        static utilities.Position RightWristPosition = new utilities.Position();
        static utilities.Position LeftWristPosition = new utilities.Position();
        public  utilities.Position Get(KinectCatcher.utilities.Side wrist)
        {
            switch (wrist)
            {
                case KinectCatcher.utilities.Side.Right:
                    return RightWristPosition;

                case KinectCatcher.utilities.Side.Left:
                    return LeftWristPosition;
                default:
                    return new utilities.Position();
            }
        
        }

        public void Set(KinectCatcher.utilities.Side hand, utilities.Position position)
        {
            switch (hand)
            {
                case KinectCatcher.utilities.Side.Right:
                    RightWristPosition = position;
                    break;
                case KinectCatcher.utilities.Side.Left:
                    LeftWristPosition = position;
                    break;
            }
        }


    }
}
