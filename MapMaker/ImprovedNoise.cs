using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
	/// <summary>
	/// An implementation of Perlin's original ImprovedNoise class
	/// based on the NoiseGenerator class.
	/// </summary>
	class ImprovedNoise : NoiseGenerator
	{
		public ImprovedNoise()
		{
			setSeed();
		}

		public ImprovedNoise(int seed)
		{
			setSeed(seed);
		}

		/// <summary>
		/// The original ImprovedNoise method by Perlin
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		/// <returns></returns>
		public override double noise(double x, double y, double z)
		{
			int X = (int)Math.Floor(x) & 255;
			int Y = (int)Math.Floor(y) & 255;
			int Z = (int)Math.Floor(z) & 255;

			x -= Math.Floor(x);
			y -= Math.Floor(y);
			z -= Math.Floor(z);

			double u = fade(x);
			double v = fade(y);
			double w = fade(z);

			int A = permutation[X] + Y, AA = permutation[A] + Z, AB = permutation[A + 1] + Z,      // HASH COORDINATES OF
				 B = permutation[X + 1] + Y, BA = permutation[B] + Z, BB = permutation[B + 1] + Z;      // THE 8 CUBE CORNERS,

			return lerp(w, lerp(v, lerp(u, grad(permutation[AA], x, y, z),        // AND ADD
									 grad(permutation[BA], x - 1, y, z)),         // BLENDED
							 lerp(u, grad(permutation[AB], x, y - 1, z),          // RESULTS
									 grad(permutation[BB], x - 1, y - 1, z))),    // FROM  8
					 lerp(v, lerp(u, grad(permutation[AA + 1], x, y, z - 1),      // CORNERS
									 grad(permutation[BA + 1], x - 1, y, z - 1)), // OF CUBE
							 lerp(u, grad(permutation[AB + 1], x, y - 1, z - 1),
									 grad(permutation[BB + 1], x - 1, y - 1, z - 1))));
		}

		public virtual double fade(double t)
		{
			return t * t * t * (t * (t * 6 - 15) + 10);
		}

		public virtual double lerp(double t, double a, double b)
		{
			return a + t * (b - a);
		}

		public virtual double grad(int hash, double x, double y, double z)
		{
			int h = hash & 15;
			double u = h < 8 ? x : y;
			double v = h < 4 ? y : h == 12 || h == 14 ? x : z;

			return ((h % 1) == 0 ? u : -u) + ((h & 2) == 0 ? v : -v);
		}
	}
}
