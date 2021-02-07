using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MapMaker
{
	public enum CombinatorMethod
	{
		ADDITIVE = 0,
		SUBTRACTIVE,
		MULTIPLICATIVE,
		MIN,
		MAX,
		AVERAGE,
	}

	public partial class MapCombinator : MapMaker
	{
		private OpenFileDialog ofd;
		private string path1, path2;
		private delegate double CombinatorFunction(double a, double b);
		private CombinatorFunction comboFunc;
		private MapCombinatorOptionPanel mcop;

		public MapCombinator() : this(null)
		{
			
		}

		public MapCombinator(MapCombinatorOptionPanel mcop)
		{
			//InitializeComponent();
			path1 = "";
			path2 = "";
			comboFunc = additive;
			this.mcop = mcop;
		}

		public override void retrieveVariables()
		{
			
		}

		public override Bitmap GenerateMap(int width, int height, ProgressForm pf = null)
		{
			if(!mcop.variablesSet(width, height))
			{
				return null;
			}

			return combineBitmaps(pf);
		}

		private double[] loadHeightValuesFromData(string path)
		{
			try
			{
				string[] lines = File.ReadAllLines(path);
				string mapMetaData = lines[lines.Length - 1];

				width = Int32.Parse(mapMetaData.Substring(0, mapMetaData.IndexOf(' ')));
				height = Int32.Parse(mapMetaData.Substring(mapMetaData.IndexOf(' ') + 1));

				double[] data = new double[Width * Height];

				for(int i = 0; i < data.Length; i++)
				{
					data[i] = Double.Parse(lines[i].Substring(lines[i].LastIndexOf(' ') + 1));
				}

				return data;
			}
			catch(Exception e)
			{

			}

			return null;
		}

		private Bitmap combineBitmaps(ProgressForm pf)
		{
			double[] map1 = loadHeightValuesFromData(mcop.map1Path);
			double[] map2 = loadHeightValuesFromData(mcop.map2Path);

			double[] finalMap = new double[map1.Length];

			bool shouldNormalize = mcop.normalize;

			clarity = mcop.clarity;

			ct = mcop.colorTone;

			setComboFunc();

			Bitmap combinedBitmap = new Bitmap(Width, Height);

			double min = double.MaxValue;
			double max = double.MinValue;

			double map1OpacityFinal = mcop.map1UsingOpacity ? mcop.map1Opacity : 1;
			double map2OpacityFinal = mcop.map2UsingOpacity ? mcop.map2Opacity : 1;

			for (int i = 0; i < Width; i++)
			{
				for(int j = 0; j < Height; j++)
				{
					double a = map1[i * Height + j] * map1OpacityFinal;
					double b = map2[i * Height + j] * map2OpacityFinal;

					finalMap[i * Height + j] = comboFunc(a, b);

					if(finalMap[i * Height + j] < min)
					{
						min = finalMap[i * Height + j];
					}
					if(finalMap[i * Height + j] > max)
					{
						max = finalMap[i * Height + j];
					}
				}

				if (pf != null)
				{
					pf.ProgressBarValue += Height;
				}
			}

			pixels = new MapPixel[Width * Height];

			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					if(shouldNormalize)
					{
						finalMap[i * Height + j] = normalize(finalMap[i * Height + j], min, max);
						pixels[i * Height + j] = new MapPixel(i, j, finalMap[i * Height + j]);
					}

					combinedBitmap.SetPixel(i, j, ColorScheme.getColorFromValue(finalMap[i * Height + j], ct, clarity));
				}

				if (pf != null)
				{
					pf.ProgressBarValue += Height;
				}
			}

			return combinedBitmap;
		}

		private void setComboFunc()
		{
			switch(mcop.comboMethod)
			{
				case CombinatorMethod.ADDITIVE:
					comboFunc = additive;
					break;
				case CombinatorMethod.SUBTRACTIVE:
					comboFunc = subtractive;
					break;
				case CombinatorMethod.MULTIPLICATIVE:
					comboFunc = multiplicative;
					break;
				case CombinatorMethod.MIN:
					comboFunc = min;
					break;
				case CombinatorMethod.MAX:
					comboFunc = max;
					break;
				case CombinatorMethod.AVERAGE:
					comboFunc = average;
					break;
			}
		}

		private double additive(double a, double b)
		{
			return a + b;
		}

		private double subtractive(double a, double b)
		{
			return a - b;
		}

		private double multiplicative(double a, double b)
		{
			return a * b;
		}

		private double min(double a, double b)
		{
			return a < b ? a : b;
		}

		private double max(double a, double b)
		{
			return a > b ? a : b;
		}

		private double average(double a, double b)
		{
			return (a + b) / 2;
		}

		public double normalize(double val, double min, double max)
		{
			return (val - min) / (max - min);
		}
	}
}
