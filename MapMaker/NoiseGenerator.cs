using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
	/// <summary>
	/// This abstract class contains the basics to create other 
	/// noise generators with different algorithms
	/// </summary>
	public abstract class NoiseGenerator
	{
		protected int[] permutation = getPermutation();
		protected int octaves = 4;
		protected double frequency = 16, amplitude = .125;
		protected double persistence = .25;
		protected int seed;

		/// <summary>
		/// Perlin's default permutation array
		/// </summary>
		protected static readonly int[] basePermutationP =
		{
			151,160,137,91,90,15,131,13,201,95,96,53,194,233,
			7,225,140,36,103,30,69,142,8,99,37,240,21,10,23,190,
			6,148,247,120,234,75,0,26,197,62,94,252,219,203,117,
			35,11,32,57,177,33,88,237,149,56,87,174,20,125,136,
			171,168, 68,175,74,165,71,134,139,48,27,166,77,146,
			158,231,83,111,229,122,60,211,133,230,220,105,92,41,
			55,46,245,40,244,102,143,54, 65,25,63,161, 1,216,80,
			73,209,76,132,187,208, 89,18,169,200,196,135,130,116,
			188,159,86,164,100,109,198,173,186, 3,64,52,217,226,
			250,124,123,5,202,38,147,118,126,255,82,85,212,207,
			206,59,227,47,16,58,17,182,189,28,42,223,183,170,
			213,119,248,152, 2,44,154,163, 70,221,153,101,155,167,
			43,172,9,129,22,39,253, 19,98,108,110,79,113,224,232,
			178,185, 112,104,218,246,97,228,251,34,242,193,238,
			210,144,12,191,179,162,241, 81,51,145,235,249,14,239,
			107,49,192,214, 31,181,199,106,157,184, 84,204,176,115,
			121,50,45,127, 4,150,254,138,236,205,93,222,114,67,29,
			24,72,243,141,128,195,78,66,215,61,156,180
		};

		public NoiseGenerator()
		{

		}

		protected static int[] getPermutation()
		{
			int[] p = new int[512];

			for (int i = 0; i < 256; i++)
			{
				p[i] = basePermutationP[i];
				p[i + 256] = basePermutationP[i];
			}

			return p;
		}

		/// <summary>
		/// Randomizes the permutation array used by various noise functions.
		/// For when you want just a bit more randomization.
		/// </summary>
		public virtual void randomizePermutation()
		{
			int[] p = new int[512];

			List<int> prevNums = new List<int>();
			Random r = new Random();

			for(int i = 0; i < 256; i++)
			{
				int next = r.Next(0, 256);

				while(prevNums.Contains(next))
				{
					next = r.Next(0, 256);
				}

				p[i] = p[i + 256] = next;
				prevNums.Add(next);
			}

			permutation = p;
		}

		public virtual void setSeed(int seed = -1)
		{
			Random r = new Random();

			if(seed < 0)
			{
				seed = new Random().Next();
				return;
			}

			this.seed = seed;
		}
		
		public abstract double noise(double x, double y = .0427, double z = .1996);

		public virtual double octaveNoise(double x, double y, double z, int oct, double freq, 
			double lac, double amp, double per, double scale, int seed)
		{
			double noiseHeight = 0;

			for (int i = 0; i < oct; i++)
			{
				double dx = x / scale * freq + seed;
				double dy = y / scale * freq + seed;
				double dz = z / scale * freq + seed;

				double noise = this.noise(dx, dy, dz) * 2 - 1;

				noiseHeight += noise * amp;
				amp *= per;
				freq *= lac;
			}

			return noiseHeight;
		}
	}

	// Things to remember when working on this:
	// AMPLITUDE deals with the y axis, it pairs with persistence (amplitude = persistence ^ octave)
	// FREQUENCY deals with the x axis, it pairs with lacunarity (frequency = lacunarity ^ octave), a higher frequency should lead to larger changes in height
	// LACUNARITY controls increase in frequency of octaves
	// PERSISTENCE controls decrease in amplitude of octaves

	//BACKUP, OLD CODE 19/12/19
	/*
	 * public abstract class NoiseGenerator
	{
		protected int[] permutation = getPermutation();
		protected int octaves = 4;
		protected double frequency = 16, amplitude = .125;
		protected double persistence = .25;
		protected int seed;

		/// <summary>
		/// Perlin's default permutation array
		/// </summary>
		protected static readonly int[] basePermutationP =
		{
			151,160,137,91,90,15,131,13,201,95,96,53,194,233,
			7,225,140,36,103,30,69,142,8,99,37,240,21,10,23,190,
			6,148,247,120,234,75,0,26,197,62,94,252,219,203,117,
			35,11,32,57,177,33,88,237,149,56,87,174,20,125,136,
			171,168, 68,175,74,165,71,134,139,48,27,166,77,146,
			158,231,83,111,229,122,60,211,133,230,220,105,92,41,
			55,46,245,40,244,102,143,54, 65,25,63,161, 1,216,80,
			73,209,76,132,187,208, 89,18,169,200,196,135,130,116,
			188,159,86,164,100,109,198,173,186, 3,64,52,217,226,
			250,124,123,5,202,38,147,118,126,255,82,85,212,207,
			206,59,227,47,16,58,17,182,189,28,42,223,183,170,
			213,119,248,152, 2,44,154,163, 70,221,153,101,155,167,
			43,172,9,129,22,39,253, 19,98,108,110,79,113,224,232,
			178,185, 112,104,218,246,97,228,251,34,242,193,238,
			210,144,12,191,179,162,241, 81,51,145,235,249,14,239,
			107,49,192,214, 31,181,199,106,157,184, 84,204,176,115,
			121,50,45,127, 4,150,254,138,236,205,93,222,114,67,29,
			24,72,243,141,128,195,78,66,215,61,156,180
		};

		public NoiseGenerator()
		{

		}

		protected static int[] getPermutation()
		{
			int[] p = new int[512];

			for (int i = 0; i < 256; i++)
			{
				p[i] = basePermutationP[i];
				p[i + 256] = basePermutationP[i];
			}

			return p;
		}

		/// <summary>
		/// Randomizes the permutation array used by various noise functions.
		/// For when you want just a bit more randomization.
		/// </summary>
		public virtual void randomizePermutation()
		{
			int[] p = new int[512];

			List<int> prevNums = new List<int>();
			Random r = new Random();

			for(int i = 0; i < 256; i++)
			{
				int next = r.Next(0, 256);

				while(prevNums.Contains(next))
				{
					next = r.Next(0, 256);
				}

				p[i] = p[i + 256] = next;
				prevNums.Add(next);
			}

			permutation = p;
		}

		public virtual void setSeed(int seed = -1)
		{
			Random r = new Random();

			if(seed < 0)
			{
				seed = new Random().Next();
				return;
			}

			this.seed = seed;
		}
		
		public abstract double noise(double x, double y, double z);

		public virtual double octaveNoise(double x, double y, double z, double freq, double amp, double per, int oct, int seed = 0, double lac = 3)
		{
			double total = 0;
			double maxValue = 0;

			for (int i = 0; i < oct; i++)
			{
				double dx = x * freq;
				double dy = y * freq;
				double dz = z * freq;

				total += noise(dx, dy, dz) * amp;

				maxValue += amp;
				amp *= per;
				freq *= lac;
			}

			return total / maxValue;
		}

		public virtual double octaveNoise(double x, double y, double z)
		{
			return octaveNoise(x, y, z, frequency, amplitude, persistence, octaves);
		}

		public virtual double octaveNoise(double x, double y, double z, int seed)
		{
			return octaveNoise(x, y, z, frequency, amplitude, persistence, octaves, seed);
		}
	}
	 * */
}