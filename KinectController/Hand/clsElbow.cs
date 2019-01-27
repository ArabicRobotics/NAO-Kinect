using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorController
{
    
    public class clsElbow
    {
         utilities.Position RightElbowPosition = new utilities.Position();
         utilities.Position LeftElbowPosition = new utilities.Position();

        public  utilities.Position GetElbow (MotorController.utilities.Side  hand)
        {
            switch (hand)
            {
                case MotorController.utilities.Side .Right:
                    return RightElbowPosition;
                   
                case MotorController.utilities.Side .Left:
                    return LeftElbowPosition;
                default:
                    return new utilities.Position();
                    
            }          
        }
        public void SetElbow(MotorController.utilities.Side  hand , utilities.Position position)
        {
            switch (hand)
            {
                case MotorController.utilities.Side .Right:
                    RightElbowPosition = position;
                    break;
                case MotorController.utilities.Side .Left:
                    LeftElbowPosition = position;
                    break;
            }
        }

    }
}
