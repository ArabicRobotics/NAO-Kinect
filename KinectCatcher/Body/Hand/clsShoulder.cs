using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectCatcher.Hand
{
   public class clsShoulder
    {

        static utilities.Position RightShoulderPosition = new utilities.Position();
        static utilities.Position LeftShoulderPosition = new utilities.Position();
        static utilities.Position CenterShoulderPosition = new utilities.Position();
        public utilities.Position Get(KinectCatcher.utilities.Side Shoulder)
        {
            switch (Shoulder)
            {
                case KinectCatcher.utilities.Side.Right:
                    return RightShoulderPosition;

                case KinectCatcher.utilities.Side.Left:
                    return LeftShoulderPosition;
                case utilities.Side.Center:
                    return CenterShoulderPosition;
                default:
                    return new utilities.Position();
            }
        }
    
        public void Set(KinectCatcher.utilities.Side hand, utilities.Position position)
        {
            switch (hand)
            {
                case KinectCatcher.utilities.Side.Right:
                    RightShoulderPosition = position;
                    break;
                case KinectCatcher.utilities.Side.Left:
                    LeftShoulderPosition = position;
                    break;
                case utilities.Side.Center:
                    CenterShoulderPosition = position;
                    break;
            }
        }



    }
}
