using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
	class Vector3
	{
		double x, y, z;

		private double[] arr = new double[3];

		public double this[int index]
		{
			get
			{
				return arr[index];
			}

			set
			{
				arr[index] = value;
			}
		}

		public Vector3(double x, double y, double z)
		{
			this.x = x;
			this.y = y;
			this.z = z;

			arr[0] = x;
			arr[1] = y;
			arr[2] = z;
		}
	}
}
