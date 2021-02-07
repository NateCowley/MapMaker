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
		ARCHIPELAGO_SUBTRACTIVE,
		ARCHIPELAGO_GRADIENT,
		ARCHIPELAGO_LERP,
		CONTINENTS,
		PLAINS,
		MOUNTAINS,
		DESERT,
		ATOLL,
	}

	public partial class Cartographer : MapMaker
	{
		private double atollRadiusVar = 5.0;
		private double prevAtollRadiusVar = 0.0;

		public Cartographer() : this(null)
		{
			biomeFunction = defaultNoise;
		}

		public Cartographer(CartographerOptionPanel mmop)
		{
			this.cop = mmop;
			biomeFunction = defaultNoise;
		}

		public override Bitmap GenerateMap(int width, int height, ProgressForm pf = null)
		{
			prevWidth = this.Width;
			this.width = width;

			prevHeight = this.Height;
			this.height = height;

			return generateImage(pf);
		}

		public virtual Bitmap generateImage(ProgressForm pf = null)
		{
			if(cop.variablesSet(Width, Height) == true)
			{
				retrieveVariables();
			}
			else
			{
				return prevImage;
			}

			if(isRepeatedSetup())
			{
				return prevImage;
			}
			else if(onlyDifferentColorScheme() && prevImage != null)
			{
				for (int i = 0; i < width; i++)
				{
					for(int j = 0; j < height; j++)
					{
						prevImage.SetPixel(i, j, ColorScheme.getColorFromValue(pixels[i * Height + j].Height, ct, clarity));
					}

					if (pf != null)
					{
						pf.ProgressBarValue += Height;
					}
				}

				return prevImage;
			}

			string[,] nums = new string[Width, Height];

			if (seed < 0)
			{
				seed *= -1;
			}

			Bitmap bm = new Bitmap(Width, Height);

			pixels = new MapPixel[Width * Height];

			Graphics g = Graphics.FromImage(bm);

			g.FillRectangle(Brushes.Black, 0, 0, Width, Height);

			if (ng == null)
			{
				ng = new ImprovedNoise();
			}

			ng.setSeed(seed);

			double[,] noiseMap = new double[Width, Height];
			noiseMax = Double.MinValue;
			noiseMin = Double.MaxValue;

			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					// get the current x and y
					double dx = (double)((i) + xOffset) * .999999999999999;
					double dy = (double)((j) + yOffset) * .999999999999999;

					// original method WORKS FINE
					//double noise = ng.octaveNoise(dx * biomeVar, dy * biomeVar, .1996 * biomeVar, octaves, frequency,
					//	lacunarity, amplitude, persistence, scale, seed);

					double noise = ng.octaveNoise(dx, dy, .1996, octaves, frequency,
						lacunarity, amplitude, persistence, scale, seed);

					noise *= biomeVar;

					if (noise > noiseMax)
					{
						noiseMax = noise;
					}
					if(noise < noiseMin)
					{
						noiseMin = noise;
					}

					noiseMap[i, j] = noise;
				}

				if (pf != null)
				{
					pf.ProgressBarValue += Height;
				}
			}

			heightNums = new string[Width * Height];

			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					// normalize the noisemap value
					noiseMap[i, j] = normalize(noiseMap[i, j], noiseMin, noiseMax);

					// after normalizing the noisemap value, adjust it to fit the biome
					noiseMap[i, j] = biomeFunction(noiseMap[i, j], i, j);

					// set the pixel in the bitmap with the final value
					bm.SetPixel(i, j, ColorScheme.getColorFromValue(noiseMap[i, j], ct, clarity));

					// save the final value of the pixel to print to log later
					heightNums[i * Height + j] += noiseMap[i, j].ToString();

					pixels[i * Height + j] = new MapPixel(i, j, noiseMap[i, j]);
				}

				if (pf != null)
				{
					pf.ProgressBarValue += Height; 
				}
			}

			prevImage = bm;

			// set the newly created bitmap as the map image
			return bm;
		}

		public override void retrieveVariables()
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
			prevMiscGeneratorOptions = this.miscGeneratorOptions;
			prevMiscBiomeOptions = this.miscBiomeOptions;

			setBiome(cop.biome);
			seed = cop.seed;
			octaves = cop.octaves;
			clarity = cop.clarity;
			lacunarity = cop.lacunarity;
			ct = cop.ct;
			frequency = cop.frequency;
			amplitude = cop.amplitude;
			persistence = cop.persistence;
			scale = cop.scale;
			xOffset = cop.xOffset;
			yOffset = cop.yOffset;
			ng = cop.ng;
			miscGeneratorOptions = cop.MiscGeneratorOptions;
			miscBiomeOptions = cop.MiscBiomeOptions;
			ng.setMiscOptions(miscGeneratorOptions);

			if(biome == Biome.ATOLL)
			{
				prevAtollRadiusVar = atollRadiusVar;
				atollRadiusVar = miscBiomeOptions[0];
			}
		}

		public void setBiome(Biome b)
		{
			biome = b;

			switch(biome)
			{
				case Biome.ARCHIPELAGO_SUBTRACTIVE:
					biomeFunction = archipelagoNoiseSubtractive;
					break;
				case Biome.ARCHIPELAGO_GRADIENT:
					biomeFunction = archipelagoNoiseGradient;
					break;
				case Biome.ARCHIPELAGO_LERP:
					biomeFunction = archipelagoNoiseLerp;
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
				case Biome.ATOLL:
					biomeFunction = atollNoise;
					break;
				default: // also Biome.CUSTOM/archipelago
					biomeFunction = defaultNoise;
					break;
			}

			//biomeFunction = testNoise;
		}

		#region BIOME_NOISE_FUNCTIONS

		public double testNoise(double noise, int x, int y)
		{
			// angle between points = arctan y / x
			double centerX = width / 2;
			double centerY = height / 2;

			double atollRadiusX = width / 5;
			double atollRadiusY = height / 5;

			double atollRadius = Math.Sqrt(atollRadiusX * atollRadiusX + atollRadiusY * atollRadiusY);

			double distanceToCenter = Math.Sqrt(Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2));

			double yDistanceToCenter = Math.Sqrt((Math.Pow(y - centerY, 2) * 2));

			double xDistanceToCenter = Math.Sqrt((Math.Pow(x - centerX, 2) * 2));

			double maxDistanceY = centerY / 2;
			double maxDistanceX = centerX / 2;

			if (xDistanceToCenter > maxDistanceX)
			{
				noise -= distanceToCenter * 2;
			}
			else
			{

			}

			if (distanceToCenter < atollRadius)
			{
				return noise * lerp(NORMALIZED_MIN, NORMALIZED_MAX, distanceToCenter / atollRadius);
			}
			else
			{
				double maxDistanceFromCenter = Math.Sqrt(centerX * centerX + centerY * centerY);
				return noise * lerp(NORMALIZED_MAX, NORMALIZED_MIN, (distanceToCenter - atollRadius) / (maxDistanceFromCenter - atollRadius * 1.90));
			}

			// to translate to degrees
			//double radians = Math.Atan2(y - centerY, x - centerX);
			//double angle = (radians * 180 / Math.PI);
		}

		public double atollNoise(double noise, int x, int y)
		{
			// angle between points = arctan y / x
			double centerX = width / 2;
			double centerY = height / 2;

			double rVar = 50 / atollRadiusVar;

			double atollRadiusX = width / rVar;
			double atollRadiusY = height / rVar;

			double atollRadius = Math.Sqrt(atollRadiusX * atollRadiusX + atollRadiusY * atollRadiusY);

			double distanceToCenter = Math.Sqrt(Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2));

			if (distanceToCenter < atollRadius)
			{
				return noise * lerp(NORMALIZED_MIN, NORMALIZED_MAX, distanceToCenter / atollRadius);
			}

			double maxDistanceFromCenter = Math.Sqrt(centerX * centerX + centerY * centerY);

			return noise * lerp(NORMALIZED_MAX, NORMALIZED_MIN, (distanceToCenter - atollRadius) / (maxDistanceFromCenter - atollRadius * 1.90));
		}

		// this is a cheap version, and always gets cut off at min
		public double archipelagoNoiseSubtractive(double noise, int x, int y)
		{
			double centerX = width / 2;
			double centerY = height / 2;

			double distanceToCenter = Math.Sqrt(Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2));

			double maxDistanceFromCenter = Math.Sqrt(centerX * centerX + centerY * centerY);

			double distancePercentage = distanceToCenter / (maxDistanceFromCenter * 1);

			/*
			// ALTERNATE METHOD
			// this section is a morth mathmatically sound version.
			// the method used (in my opinion) creates more interesting formations

			double distancePercentage = distanceToCenter / maxDistanceFromCenter;

			noise -= distancePercentage;

			return noise * (1 - distancePercentage);
			*/

			noise -= distancePercentage;

			if (noise < NORMALIZED_MIN)
			{
				return NORMALIZED_MIN;
			}

			return noise;
		}

		// this is a mathematical gradient formula version
		public double archipelagoNoiseGradient(double noise, int x, int y)
		{
			return noise * (Math.Sin(1 * x / width * Math.PI)) * (Math.Sin(1 * y / height * Math.PI));
		}

		// this one is created by lerping the distancePercentage with the normalized min/max
		public double archipelagoNoiseLerp(double noise, int x, int y)
		{
			// angle between points = arctan y / x
			double centerX = width / 2;
			double centerY = height / 2;

			double distanceToCenter = Math.Sqrt(Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2));

			double maxDistanceFromCenter = Math.Sqrt(centerX * centerX + centerY * centerY);

			double distancePercentage = distanceToCenter / (maxDistanceFromCenter * 1);

			return noise * lerp(NORMALIZED_MAX, NORMALIZED_MIN, distancePercentage);
		}

		public double continentsNoise(double noise, int x, int y)
		{
			return noise;
		}

		public double plainsNoise(double noise, int x, int y)
		{
			double delta = midHeight - noise;

			return (noise * 2 + delta) / 2;
		}

		public double mountainsNoise(double noise, int x, int y)
		{
			return noise * 1.5;
		}

		public double desertNoise(double noise, int x, int y)
		{
			return noise;
		}

		public double defaultNoise(double noise, int x, int y)
		{
			return noise;
		}

		#endregion

		public double normalize(double val, double min, double max)
		{
			return (val - min) / (max - min);
		}

		public double lerp(double val1, double val2, double t)
		{
			return (1 - t) * val1 + t * val2;
		}

		public static void writeToDebugFile(string output)
		{
			string fullPath = System.IO.Directory.GetCurrentDirectory() + "\\debugFile.log";
			try
			{
				if (System.IO.File.Exists(fullPath))
				{
					System.IO.File.Delete(fullPath);
				}

				System.IO.File.Create(fullPath);
				System.IO.File.WriteAllText(fullPath, output);
			}
			catch(Exception e)
			{

			}
		}

		public static void writeToDebugFile(string[] output)
		{
			string res = "";
			//MessageBox.Show("in");
			for(int i = 0; i < output.Length; i++)
			{
				res += output[i];
				res += "\n";
			}
			//MessageBox.Show("here");
			writeToDebugFile(res);
		}

		private bool isRepeatedSetup()
		{
			// if all of the settings are still the same return true
			if(atollRadiusVar != prevAtollRadiusVar && biome == Biome.ATOLL)
			{
				return false;
			}

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
				ng == prevng &&
				miscGeneratorOptions.Length == prevMiscGeneratorOptions.Length
			)
			{
				for(int i = 0; i < prevMiscGeneratorOptions.Length; i++)
				{
					if(prevMiscGeneratorOptions[i] != miscGeneratorOptions[i])
					{
						return false;
					}
				}

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
				miscGeneratorOptions.Length == prevMiscGeneratorOptions.Length &&
				ct != prevct
			)
			{
				for (int i = 0; i < prevMiscGeneratorOptions.Length; i++)
				{
					if (prevMiscGeneratorOptions[i] != miscGeneratorOptions[i])
					{
						return false;
					}
				}

				return true;
			}

			return false;
		}

		public string[] getMapPixelsForSave()
		{
			string[] values = new string[pixels.Length];

			for (int i = 0; i < pixels.Length; i++)
			{
				values[i] = pixels[i].ToString();
			}

			return values;
		}
	}
}

/*

backup of old methods
public void setVariables(Biome biome, ColorTone ct, NoiseGenerator ng, int seed, 
			int octaves, int clarity, double lacunarity, double frequency, double amplitude, 
			double persistence, double scale, double xOffset, double yOffset, double[] miscOptions,
			int width, int height)
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
			prevMiscOptions = this.miscOptions;
			prevWidth = Width;
			prevHeight = Height;

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
			this.miscOptions = miscOptions;
			this.ng.setMiscOptions(miscOptions);
			this.width = width;
			this.height = height;
		}

*/
