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

		private static readonly double SQRT_2 = 1.4142135623730950488;

		private static readonly double SQRT_3 = 1.7320508075688772935;

		private short distanceMethod = 0;

		public double randRange(double min, double max)
		{
			return Math.Floor(new Random().NextDouble() * ((max) - min) + min);
		}

		public override double noise(double x, double y, double z)
		{
			int xInt = (x > .0 ? (int)x : (int)x - 1);

			int yInt = (y > .0 ? (int)y : (int)y - 1);

			int zInt = (z > .0 ? (int)z : (int)z - 1);

			double minDist = 32000000.0;

			double xCandidate = 0;

			double yCandidate = 0;

			double zCandidate = 0;

			Random rand = new Random((int)seed);

			for (int zCur = zInt - 2; zCur <= zInt + 2; zCur++)
			{
				for (int yCur = yInt - 2; yCur <= yInt + 2; yCur++)
				{
					for (int xCur = xInt - 2; xCur <= xInt + 2; xCur++)
					{
						double xPos = xCur + valueNoise3D(xCur, yCur, zCur, seed);

						double yPos = yCur + valueNoise3D(xCur, yCur, zCur, rand.Next());

						double zPos = zCur + valueNoise3D(xCur, yCur, zCur, rand.Next());

						double xDist = xPos - x;

						double yDist = yPos - y;

						double zDist = zPos - z;

						double dist = xDist * xDist + yDist * yDist + zDist * zDist;

						if (dist < minDist)
						{
							minDist = dist;

							xCandidate = xPos;

							yCandidate = yPos;

							zCandidate = zPos;
						}
					}
				}
			}

			double xDistFinal = xCandidate - x;

			double yDistFinal = yCandidate - y;

			double zDistFinal = zCandidate - z;

			return getDistance(xDistFinal, yDistFinal, zDistFinal);
		}

		public override double octaveNoise(double x, double y, double z, int oct, double freq,
			double lac, double amp, double per, double scale, int seed)
		{
			double noiseHeight = 0;

			for (int i = 0; i < oct; i++)
			{
				double dx = x / scale * freq + seed;
				double dy = y / scale * freq + seed;
				double dz = z / scale * freq + seed;

				double noise = this.noise(dx, dy, dz);// * 2 - 1;

				noiseHeight += noise * amp;
				amp *= per;
				freq *= lac;
			}

			return noiseHeight;
		}

		private double getDistance(double xDist, double zDist)
		{
			switch (distanceMethod)
			{
				case 0:
					return Math.Sqrt(xDist * xDist + zDist * zDist) / SQRT_2;
				case 1:
					return xDist + zDist;
				case 2:
					return Math.Pow(Math.E, Math.Sqrt(xDist * xDist + zDist * zDist) / SQRT_2) / Math.E;
				default:
					return 1.0;
			}
		}

		private double getDistance(double xDist, double yDist, double zDist)
		{
			switch (distanceMethod)
			{
				case 0:
					return Math.Sqrt(xDist * xDist + yDist * yDist + zDist * zDist) / SQRT_3;
				case 1:
					return xDist + yDist + zDist;
				default:
					return 1.0;
			}
		}

		public short getDistanceMethod()
		{
			return distanceMethod;
		}

		public void setDistanceMethod(short distanceMethod)
		{
			this.distanceMethod = distanceMethod;
		}

		public static double valueNoise2D(int x, int z, long seed)
		{
			long n = (1619 * x + 6971 * z + 1013 * seed) & 0x7fffffff;

			n = (n >> 13) ^ n;

			return 1.0 - ((double)((n * (n * n * 60493 + 19990303) + 1376312589) & 0x7fffffff) / 1073741824.0);
		}

		public static double valueNoise3D(int x, int y, int z, long seed)
		{
			long n = (1619 * x + 31337 * y + 6971 * z + 1013 * seed) & 0x7fffffff;

			n = (n >> 13) ^ n;

			return 1.0 - ((double)((n * (n * n * 60493 + 19990303) + 1376312589) & 0x7fffffff) / 1073741824.0);
		}
	}

	public class VoronoiGenerator
	{
		private static readonly double SQRT_2 = 1.4142135623730950488;

		private static readonly double SQRT_3 = 1.7320508075688772935;

		private long seed;

		private short distanceMethod;

		public VoronoiGenerator(long seed, short distanceMethod /*TODO: int octaves*/)
		{
			this.seed = seed;
			this.distanceMethod = distanceMethod;
		}

		private double getDistance(double xDist, double zDist)
		{
			switch (distanceMethod)
			{
				case 0:
					return Math.Sqrt(xDist * xDist + zDist * zDist) / SQRT_2;
				case 1:
					return xDist + zDist;
				case 2:
					return Math.Pow(Math.E, Math.Sqrt(xDist * xDist + zDist * zDist) / SQRT_2) / Math.E;
				default:
					return 1.0;
			}
		}

		private double getDistance(double xDist, double yDist, double zDist)
		{
			switch (distanceMethod)
			{
				case 0:
					return Math.Sqrt(xDist * xDist + yDist * yDist + zDist * zDist) / SQRT_3;
				case 1:
					return xDist + yDist + zDist;
				default:
					return 1.0;
			}
		}

		public short getDistanceMethod()
		{
			return distanceMethod;
		}

		public long getSeed()
		{
			return seed;
		}

		public double noise(double x, double z, double frequency)
		{
			x *= frequency;

			z *= frequency;

			int xInt = (x > .0 ? (int)x : (int)x - 1);

			int zInt = (z > .0 ? (int)z : (int)z - 1);

			double minDist = 32000000.0;

			double xCandidate = 0;

			double zCandidate = 0;

			for (int zCur = zInt - 2; zCur <= zInt + 2; zCur++)
			{
				for (int xCur = xInt - 2; xCur <= xInt + 2; xCur++)
				{
					double xPos = xCur + valueNoise2D(xCur, zCur, seed);

					double zPos = zCur + valueNoise2D(xCur, zCur, new Random((int)seed).Next());

					double xDist = xPos - x;

					double zDist = zPos - z;

					double dist = xDist * xDist + zDist * zDist;

					if (dist < minDist)
					{
						minDist = dist;
						xCandidate = xPos;
						zCandidate = zPos;
					}
				}
			}

			double xDistFinal = xCandidate - x;

			double zDistFinal = zCandidate - z;

			return getDistance(xDistFinal, zDistFinal);
		}

		public double noise(double x, double y, double z, double frequency)
		{
			x *= frequency;

			y *= frequency;

			z *= frequency;

			int xInt = (x > .0 ? (int)x : (int)x - 1);

			int yInt = (y > .0 ? (int)y : (int)y - 1);

			int zInt = (z > .0 ? (int)z : (int)z - 1);

			double minDist = 32000000.0;

			double xCandidate = 0;

			double yCandidate = 0;

			double zCandidate = 0;

			Random rand = new Random((int)seed);

			for (int zCur = zInt - 2; zCur <= zInt + 2; zCur++)
			{
				for (int yCur = yInt - 2; yCur <= yInt + 2; yCur++)
				{
					for (int xCur = xInt - 2; xCur <= xInt + 2; xCur++)
					{
						double xPos = xCur + valueNoise3D(xCur, yCur, zCur, seed);

						double yPos = yCur + valueNoise3D(xCur, yCur, zCur, rand.Next());

						double zPos = zCur + valueNoise3D(xCur, yCur, zCur, rand.Next());

						double xDist = xPos - x;

						double yDist = yPos - y;

						double zDist = zPos - z;

						double dist = xDist * xDist + yDist * yDist + zDist * zDist;

						if (dist < minDist)
						{

							minDist = dist;

							xCandidate = xPos;

							yCandidate = yPos;

							zCandidate = zPos;

						}

					}

				}

			}

			double xDistFinal = xCandidate - x;

			double yDistFinal = yCandidate - y;

			double zDistFinal = zCandidate - z;

			return getDistance(xDistFinal, yDistFinal, zDistFinal);
		}

		public void setDistanceMethod(short distanceMethod)
		{
			this.distanceMethod = distanceMethod;
		}

		public void setSeed(long seed)
		{
			this.seed = seed;
		}

		public static double valueNoise2D(int x, int z, long seed)
		{
			long n = (1619 * x + 6971 * z + 1013 * seed) & 0x7fffffff;

			n = (n >> 13) ^ n;

			return 1.0 - ((double)((n * (n * n * 60493 + 19990303) + 1376312589) & 0x7fffffff) / 1073741824.0);
		}

		public static double valueNoise3D(int x, int y, int z, long seed)
		{
			long n = (1619 * x + 31337 * y + 6971 * z + 1013 * seed) & 0x7fffffff;

			n = (n >> 13) ^ n;

			return 1.0 - ((double)((n * (n * n * 60493 + 19990303) + 1376312589) & 0x7fffffff) / 1073741824.0);
		}
	}
}
