using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorController.Hand
{
   public class clsShoulder
    {

        static utilities.Position RightShoulderPosition = new utilities.Position();
        static utilities.Position LeftShoulderPosition = new utilities.Position();
        public utilities.Position GetShoulder(MotorController.utilities.Side Shoulder)
        {
            switch (Shoulder)
            {
                case MotorController.utilities.Side.Right:
                    return RightShoulderPosition;

                case MotorController.utilities.Side.Left:
                    return LeftShoulderPosition;
                default:
                    return new utilities.Position();
            }

        }

        public void SetShoulder(MotorController.utilities.Side hand, utilities.Position position)
        {
            switch (hand)
            {
                case MotorController.utilities.Side.Right:
                    RightShoulderPosition = position;
                    break;
                case MotorController.utilities.Side.Left:
                    LeftShoulderPosition = position;
                    break;
            }
        }



    }
}
