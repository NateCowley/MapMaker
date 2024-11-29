using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
    /// <summary>
    /// Custom Point class used with the QuadTree
    /// </summary>
    public class QuadPoint
    {
        private int x, y;

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public QuadPoint() : this(0, 0)
        {

        }

        public QuadPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
