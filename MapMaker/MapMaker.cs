using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapMaker
{
	public enum Biome
	{
		CUSTOM,
		ARCHIPELAGO,
		CONTINENTS,
		PLAINS,
		MOUNTAINS,
		DESERT,
	}

	public partial class MapMaker
	{
		public int clarity = 1;
		public int octaves = 1;
		public int seed = 0, lastSeed = -1;
		public double scale = .15;
		public double persistence = .35;
		public double xOffset = 0, yOffset = 0;
		public double frequency = 1, amplitude = 1;
		public double lacunarity = 2.0;
		public double plainsValue = 1.0;
		public ColorTone ct = ColorTone.DEFAULT;
		public Biome biome = Biome.ARCHIPELAGO;
		public NoiseGenerator ng;
		public delegate double AlterNoise(double noise);
		
		private double midHeight = 0.49;
		private double biomeVar = 1.0;
		private AlterNoise biomeFunction;

		public MapMaker()
		{
			biomeFunction = defaultNoise;
		}

		public Bitmap generateImage(int width, int height, ProgressForm pf = null)
		{
			if (seed < 0)
			{
				seed *= -1;
			}

			Bitmap bm = new Bitmap(width, height);

			Graphics g = Graphics.FromImage(bm);

			g.FillRectangle(Brushes.Black, 0, 0, width, height);

			if (ng == null)
			{
				ng = new ImprovedNoise();
			}

			ng.setSeed(seed);

			if (pf != null)
			{
				pf.ProgressBarMax = width * height * 2;
				pf.ProgressBarValue = 0;
				pf.Visible = true;
			}

			double[,] noiseMap = new double[width, height];
			double max = Double.MinValue;
			double min = Double.MaxValue;

			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					// get the current x and y
					double dx = (double)(i) + xOffset;
					double dy = (double)(j) + yOffset;

					dx *= plainsValue;
					dy *= plainsValue;

					// get the noise value for that x and y
					double noise = ng.octaveNoise(dx * biomeVar, .1996 * biomeVar, dy * biomeVar, octaves, frequency, 
						lacunarity, amplitude, persistence, scale, seed);

					if(noise > max)
					{
						max = noise;
					}
					else if(noise < min)
					{
						min = noise;
					}

					noiseMap[i, j] = noise;
				}

				if (pf != null)
				{
					pf.ProgressBarValue += height;
				}
			}

			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					// normalize the noisemap value
					noiseMap[i, j] = normalize(noiseMap[i, j], min, max);// (noiseMap[i, j] - min) / (max - min);

					// after normalizing the noisemap value, adjust it to fit the biome
					noiseMap[i, j] = biomeFunction(noiseMap[i, j]);

					// set the pixel in the bitmap with the final value
					bm.SetPixel(i, j, ColorScheme.getColorFromValue(noiseMap[i, j], ct, clarity));
				}

				if (pf != null)
				{
					pf.ProgressBarValue += height;
				}
			}

			if (pf != null)
			{
				pf.Visible = false;
			}

			// set the newly created bitmap as the map image
			return bm;
		}

		public void setBiome(Biome b)
		{
			biome = b;

			switch(biome)
			{
				// NOTE: archipelago is currently not used
				case Biome.ARCHIPELAGO:
					biomeFunction = archipelagoNoise;
					break;
				case Biome.CONTINENTS:
					biomeFunction = continentsNoise;
					break;
				case Biome.PLAINS:
					biomeFunction = plainsNoise;
					break;
				case Biome.MOUNTAINS:
					biomeFunction = mountainsNoise;
					break;
				case Biome.DESERT:
					biomeFunction = desertNoise;
					break;
				default: // also Biome.CUSTOM/archipelago
					biomeFunction = defaultNoise;
					break;
			}
		}

		// NOTE: archipelago is currently not used
		public double archipelagoNoise(double noise)
		{
			return noise * 0.75;
		}

		public double continentsNoise(double noise)
		{
			return plainsNoise(noise) * 1.3;
		}

		public double plainsNoise(double noise)
		{
			double delta = midHeight - noise;

			return (noise * 2 + delta) / 2 + .09;
		}

		public double mountainsNoise(double noise)
		{
			return noise * 1.5;
		}

		public double desertNoise(double noise)
		{
			return noise;
		}

		public double defaultNoise(double noise)
		{
			return noise;
		}

		public double normalize(double val, double min, double max)
		{
			return (val - min) / (max - min);
		}

		public void writeToDebugFile(string output)
		{
			System.IO.File.WriteAllText(System.IO.Directory.GetCurrentDirectory() + "/debugFile.log", output);
		}
	}
}
