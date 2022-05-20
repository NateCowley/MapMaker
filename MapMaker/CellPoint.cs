using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
	class CellPoint
	{
		public double x, y, z;

		public CellPoint()
		{

		}

		public CellPoint(double x = 0, double y = 0, double z = 0)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public static double distance(CellPoint p1, CellPoint p2)
		{
			//d = ((x2 - x1)^2 + (y2 - y1)^2 + (z2-z1)^2)^(1/2)
			return Math.Sqrt(Math.Pow((p2.x - p1.x), 2) + Math.Pow((p2.y - p1.y), 2) + Math.Pow((p2.z - p1.z), 2));
		}

		public override string ToString()
		{
			return "X: " + x + ", Y: " + y + ", Z: " + z;
		}
	}
}
