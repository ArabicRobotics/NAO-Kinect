using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectCatcher
{
   public class clsNeck
    {
        static utilities.Position neckPosition = new utilities.Position();
        public utilities.Position Get()
        {
                    return neckPosition;
        }
        public void Set(utilities.Position position)
        {
            
                    neckPosition = position;
        }

    }
}
