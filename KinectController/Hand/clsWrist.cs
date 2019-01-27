using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorController.Hand
{
     public class clsWrist
    {

        static utilities.Position RightWristPosition = new utilities.Position();
        static utilities.Position LeftWristPosition = new utilities.Position();
        public  utilities.Position GetWrist(MotorController.utilities.Side wrist)
        {
            switch (wrist)
            {
                case MotorController.utilities.Side.Right:
                    return RightWristPosition;

                case MotorController.utilities.Side.Left:
                    return LeftWristPosition;
                default:
                    return new utilities.Position();
            }
        
        }

        public void SetWrist(MotorController.utilities.Side hand, utilities.Position position)
        {
            switch (hand)
            {
                case MotorController.utilities.Side.Right:
                    RightWristPosition = position;
                    break;
                case MotorController.utilities.Side.Left:
                    LeftWristPosition = position;
                    break;
            }
        }


    }
}
