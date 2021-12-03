using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
	public abstract class MapMaker
	{
		#region MEMBERS
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
		public Biome biome = Biome.ARCHIPELAGO_SUBTRACTIVE;
		public NoiseGenerator ng;
		public double[] miscGeneratorOptions;
		public double[] miscBiomeOptions;
		protected double width;
		protected double height;
		protected delegate double AlterNoise(double noise, int x, int y);
		public double mapHeight;

		// these are save variables used to keep us from completely
		// regenerating the map if we're just doing a recolor
		protected Bitmap prevImage;

		protected int prevWidth = 0, prevHeight = 0;
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
		public Biome prevBiome = Biome.ARCHIPELAGO_SUBTRACTIVE;
		public NoiseGenerator prevng;
		public double[] prevMiscGeneratorOptions;
		public double[] prevMiscBiomeOptions;
		public double prevMapHeight;

		protected double midHeight = 0.49;
		protected double biomeVar = 1.0;
		protected AlterNoise biomeFunction;

		protected string[] heightNums;
		
		protected static MapPixel[] pixels;
		
		protected static double noiseMin = Double.MaxValue;
		protected static double noiseMax = Double.MinValue;
		
		protected CartographerOptionPanel cop;

		#region STATICMEMBERS
		/// <summary>
		/// The lowest value possible once normalized
		/// </summary>
		public static readonly double NORMALIZED_MIN = 0.0;
		/// <summary>
		/// The heighest value possible once normalized
		/// </summary>
		public static readonly double NORMALIZED_MAX = 1.0;

		/// <summary>
		/// The highest point on Earth (Everest's peak), used as the maximum height on the map
		/// </summary>
		protected static readonly double MAX_MAP_HEIGHT_REAL = 29032;

		/// <summary>
		/// The lowest point on Earth (Mariana Trench), used as the maximum depth on the map
		/// </summary>
		protected static readonly double MAX_MAP_DEPTH_REAL = -36037;

		/// <summary>
		/// A value representing 12 vertical inches in the real world, on the normalized map
		/// </summary>
		protected static readonly double NORMALIZED_MAP_FOOT_REAL = -1 / (MAX_MAP_DEPTH_REAL - MAX_MAP_HEIGHT_REAL);

		/// <summary>
		/// The highest point on a fantasy world
		/// </summary>
		protected static readonly double MAX_MAP_HEIGHT_FANTASY = 100000;

		/// <summary>
		/// The lowest point on a fantasy world
		/// </summary>
		protected static readonly double MAX_MAP_DEPTH_FANTASY = -100000;

		/// <summary>
		/// A value representing 12 vertical inches in a fantasy world, on the normalized map
		/// </summary>
		public static readonly double NORMALIZED_MAP_FOOT_FANTASY = .000005;
		#endregion STATICMEMBERS
		#endregion MEMBERS

		#region PROPERTIES
		public string[] HeightNums
		{
			get
			{
				if (heightNums.Length < 1)
				{
					return new string[0];
				}

				return heightNums;
			}
		}

		/// <summary>
		/// The width is actually stored as a double for quicker calculations, but sometimes we need to use 
		/// it as an int.<para>This was the quickest way to solve that issue</para>
		/// </summary>
		public int Width
		{
			get { return (int)width; }
		}

		/// <summary>
		/// The height is actually stored as a double for quicker calculations, but sometimes we need to use 
		/// it as an int.<para>This was the quickest way to solve that issue</para>
		/// </summary>
		public int Height
		{
			get { return (int)height; }
		}
		#endregion PROPERTIES

		public abstract Bitmap GenerateMap(int width, int height, ProgressForm pf = null);

		public abstract void retrieveVariables();
	}
}
