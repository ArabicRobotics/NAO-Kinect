using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace MotorController
{
  public  class clsHand
    {     
        public static bool datachanged = false;
      public static int lastFrameNumber = 0;
        public DateTime framedateTime;
      public int  frameCount ;
      public enum HandState {
          closed, Opened, Lasso,Unknown,NotTracked
      }
       public HandState LeftState = HandState.Unknown;
        public HandState RightState = HandState.Unknown;
        public  MotorController.utilities.Position RightHandPosition = new utilities.Position();        
      public MotorController.utilities.Position  LeftHandPosition = new utilities.Position();     
        public  void SetHandPosition(MotorController.utilities.Side hand, MotorController.utilities.Position Position)
        {              
            switch (hand)
            {
                case MotorController.utilities.Side.Right:
                    RightHandPosition = Position;
                    break;
                case MotorController.utilities.Side.Left:
                    LeftHandPosition = Position;
                    break;
            }    
        }

        public clsHand()
        {
            frameCount = lastFrameNumber + 1;
            lastFrameNumber = frameCount;
        }


        public  void SetHandPosition(MotorController.utilities.Side hand, float X, float Y, float Z)
       {
          
           switch (hand)
           {
               case MotorController.utilities.Side.Right:
                   RightHandPosition.x =X ;
                   RightHandPosition.y = Y;
                   RightHandPosition.z = Z;
                   break;
               case MotorController.utilities.Side.Left:
                   LeftHandPosition.x =X ;
                   LeftHandPosition.y = Y;
                   LeftHandPosition.z = Z;
                   break;
           }
       }
        public  MotorController.utilities.Position GetHandPosition(MotorController.utilities.Side hand)
        {
            MotorController.utilities.Position position = new utilities.Position();
            switch (hand)
            {
                case MotorController.utilities.Side.Right:
                    position = RightHandPosition;
                   return position;
                case MotorController.utilities.Side.Left:
                   position = LeftHandPosition;
                     return position;  
                default:
                     return new utilities.Position();

            }
        
        }
      public void  SetHandState(utilities.Side side,Microsoft.Kinect.HandState state)
      {
          switch (side)
          {
              case utilities.Side.Right:


          switch (state)
          {
              case Microsoft.Kinect.HandState.Closed:
                  RightState = HandState.closed;
                  break;
              case Microsoft.Kinect.HandState.Lasso:
                  RightState = HandState.Lasso;
                  break;
              case Microsoft.Kinect.HandState.NotTracked:
                  RightState = HandState.NotTracked;
                  break;
              case Microsoft.Kinect.HandState.Open:
                  RightState = HandState.Opened;
                  break;
              case Microsoft.Kinect.HandState.Unknown:
                  RightState = HandState.Unknown;
                  break;
              default:
                  break;
          }

                  break;
              case utilities.Side.Left:
                  switch (state)
                  {
                      case Microsoft.Kinect.HandState.Closed:
                          LeftState = HandState.closed;
                          break;
                      case Microsoft.Kinect.HandState.Lasso:
                          LeftState = HandState.Lasso;
                          break;
                      case Microsoft.Kinect.HandState.NotTracked:
                          LeftState = HandState.NotTracked;
                          break;
                      case Microsoft.Kinect.HandState.Open:
                          LeftState = HandState.Opened;
                          break;
                      case Microsoft.Kinect.HandState.Unknown:
                          LeftState = HandState.Unknown;
                          break;
                      default:
                          break;
                  }



                  break;
          }
      
      }
    }

}
