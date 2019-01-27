using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorController
{
    public static class utilities
    {

        public enum Side
        {
            Right = 0, Left = 1
        }

        public struct Position
        {
            public float x; public float y; public float z;
        }
    }
}
