using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace MapMaker
{
	public class WorleyNoise : NoiseGenerator
	{
		private double[] points;

		public double randRange(double min, double max)
		{
			return Math.Floor(new Random().NextDouble() * ((max) - min) + min);
		}

		public override double noise(double x, double y, double z)
		{
			// TODO: make it work
			return -1;
		}

		public override double octaveNoise(double x, double y, double z, int oct, double freq,
			double lac, double amp, double per, double scale, int seed)
		{
			int delta = 100000;

			double dx = delta * x;
			double dy = delta * y;
			double dz = delta * z;

			int ix = (int)(dx);
			int iy = (int)(dy);
			int iz = (int)(dz);

			for (int i = 1; i < 1; i++)
			{
				ix = ix >> i;
				iy = iy >> i;
				iz = iz >> i;
			}

			x = ix / delta;
			y = iy / delta;
			z = iz / delta;

			return base.octaveNoise(x, y, z, oct, freq, lac, amp, per, scale, seed);
		}
	}
}
