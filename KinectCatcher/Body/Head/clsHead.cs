using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectCatcher
{
   public class clsHead
    {
        static utilities.Position HeadPosition = new utilities.Position();
        public utilities.Position Get()
        {
                    return HeadPosition;
        }
        public void Set(utilities.Position position)
        {
            
                    HeadPosition = position;
        }

    }
}
