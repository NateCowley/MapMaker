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
		public int seed = 0;
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

		// these are save variables used to keep us from completely
		// regenerating the map if we're just doing a recolor
		private double[] prevPoints;
		private Bitmap prevImage;

		private int prevWidth = 0, prevHeight = 0;
		public int prevClarity = -1;
		public int prevOctaves = -1;
		public int prevSeed = -1;
		public double prevScale = -.15;
		public double prevPersistence = -.35;
		public double prevXOffset = 0, prevYOffset = 0;
		public double prevFrequency = -1, prevAmplitude = -1;
		public double prevLacunarity = -2.0;
		public double prevPlainsValue = -1.0;
		public ColorTone prevct = ColorTone.BLACKANDWHITE;
		public Biome prevBiome = Biome.ARCHIPELAGO;
		public NoiseGenerator prevng;

		private double midHeight = 0.49;
		private double biomeVar = 1.0;
		private AlterNoise biomeFunction;

		public MapMaker()
		{
			biomeFunction = defaultNoise;
		}

		public Bitmap generateImage(int width, int height, ProgressForm pf = null)
		{
			if(isRepeatedSetup())
			{
				return prevImage;
			}
			else if(onlyDifferentColorScheme() && prevImage != null)
			{
				if (pf != null)
				{
					pf.ProgressBarMax = width * height;
					pf.ProgressBarValue = 0;
					pf.Visible = true;
				}

				for (int i = 0; i < width; i++)
				{
					for(int j = 0; j < height; j++)
					{
						prevImage.SetPixel(i, j, ColorScheme.getColorFromValue(prevPoints[i * height + j], ct, clarity));
					}

					if (pf != null)
					{
						pf.ProgressBarValue += height;
					}
				}

				if(pf != null)
				{
					pf.Visible = false;
				}

				return prevImage;
			}

			string[,] nums = new string[width, height];

			if (seed < 0)
			{
				seed *= -1;
			}

			Bitmap bm = new Bitmap(width, height);

			prevPoints = new double[width * height];

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
					noiseMap[i, j] = normalize(noiseMap[i, j], min, max);

					// after normalizing the noisemap value, adjust it to fit the biome
					noiseMap[i, j] = biomeFunction(noiseMap[i, j]);

					// set the pixel in the bitmap with the final value
					bm.SetPixel(i, j, ColorScheme.getColorFromValue(noiseMap[i, j], ct, clarity));

					// save the final value of the pixel to print to log later
					nums[i, j] = noiseMap[i, j].ToString();

					prevPoints[i * height + j] = noiseMap[i, j];
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

			string[] finalNums = new string[width * height];

			for(int i = 0; i < width; i++)
			{
				for(int j = 0; j < height; j++)
				{
					prevPoints[i * height + j] = noiseMap[i, j];
					finalNums[i * height + j] = nums[i, j];
				}
			}

			//writeToDebugFile(finalNums);

			prevImage = bm;

			// set the newly created bitmap as the map image
			return bm;
		}

		public void setVariables(Biome biome, ColorTone ct, NoiseGenerator ng, int seed, 
			int octaves, int clarity, double lacunarity, double frequency, double amplitude, 
			double persistence, double scale, double xOffset, double yOffset)
		{
			if (seed < 0)
			{
				seed *= -1;
			}

			prevBiome = this.biome;
			prevSeed = this.seed;
			prevOctaves = this.octaves;
			prevClarity = this.clarity;
			prevLacunarity = this.lacunarity;
			prevct = this.ct;
			prevFrequency = this.frequency;
			prevAmplitude = this.amplitude;
			prevPersistence = this.persistence;
			prevScale = this.scale;
			prevXOffset = this.xOffset;
			prevYOffset = this.yOffset;
			prevng = this.ng;

			this.setBiome(biome);
			this.seed = seed;
			this.octaves = octaves;
			this.clarity = clarity;
			this.lacunarity = lacunarity;
			this.ct = ct;
			this.frequency = frequency;
			this.amplitude = amplitude;
			this.persistence = persistence;
			this.scale = scale;
			this.xOffset = xOffset;
			this.yOffset = yOffset;
			this.ng = ng;
		}

		public void setBiome(Biome b)
		{
			biome = b;

			switch(biome)
			{
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

		#region BIOME_NOISE_FUNCTIONS
		public double archipelagoNoise(double noise)
		{
			return noise * 0.75;
		}

		public double continentsNoise(double noise)
		{
			return noise;
		}

		public double plainsNoise(double noise)
		{
			double delta = midHeight - noise;

			return (noise * 2 + delta) / 2;
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
		#endregion

		public double normalize(double val, double min, double max)
		{
			return (val - min) / (max - min);
		}

		public void writeToDebugFile(string output)
		{
			string fullPath = System.IO.Directory.GetCurrentDirectory() + "\\debugFile.log";

			if (System.IO.File.Exists(fullPath))
			{
				System.IO.File.Delete(fullPath);
			}

			System.IO.File.Create(fullPath);
			System.IO.File.WriteAllText(fullPath, output);
		}

		public void writeToDebugFile(string[] output)
		{
			string res = "";
			MessageBox.Show("in");
			for(int i = 0; i < output.Length; i++)
			{
				res += output[i];
				res += "\n";
			}
			MessageBox.Show("here");
			writeToDebugFile(res);
		}

		private bool isRepeatedSetup()
		{
			// if all of the settings are still the same return true
			if
			(
				biome == prevBiome && 
				seed == prevSeed &&
				octaves == prevOctaves &&
				clarity == prevClarity &&
				lacunarity == prevLacunarity &&
				ct == prevct &&
				frequency == prevFrequency &&
				amplitude == prevAmplitude &&
				persistence == prevPersistence &&
				scale == prevScale &&
				xOffset == prevXOffset &&
				yOffset == prevYOffset &&
				ng == prevng
			)
			{
				return true;
			}

			return false;
		}

		private bool onlyDifferentColorScheme()
		{
			if
			(
				biome == prevBiome &&
				seed == prevSeed &&
				octaves == prevOctaves &&
				clarity == prevClarity &&
				lacunarity == prevLacunarity &&
				frequency == prevFrequency &&
				amplitude == prevAmplitude &&
				persistence == prevPersistence &&
				scale == prevScale &&
				xOffset == prevXOffset &&
				yOffset == prevYOffset &&
				ng == prevng && 
				ct != prevct
			)
			{
				return true;
			}

			return false;
		}
	}
}
