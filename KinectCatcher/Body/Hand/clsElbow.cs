using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectCatcher
{
    
    public class clsElbow
    {
         utilities.Position RightElbowPosition = new utilities.Position();
         utilities.Position LeftElbowPosition = new utilities.Position();

        public  utilities.Position Get(KinectCatcher.utilities.Side  hand)
        {
            switch (hand)
            {
                case KinectCatcher.utilities.Side .Right:
                    return RightElbowPosition;
                   
                case KinectCatcher.utilities.Side .Left:
                    return LeftElbowPosition;
                default:
                    return new utilities.Position();
                    
            }          
        }
        public void Set(KinectCatcher.utilities.Side  hand , utilities.Position position)
        {
            switch (hand)
            {
                case KinectCatcher.utilities.Side .Right:
                    RightElbowPosition = position;
                    break;
                case KinectCatcher.utilities.Side .Left:
                    LeftElbowPosition = position;
                    break;
            }
        }

    }
}
