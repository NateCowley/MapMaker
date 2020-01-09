using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MapMaker
{
	public enum ColorTone
	{
		DEFAULT,
		SEPIA,
		DEFAULTTOPO,
		SEPIATOPO,
		BLACKANDWHITE,
		DESERT,
	}

	public struct ColorValue
	{
		public double valueLimit;
		public Color color;

		public ColorValue(double valueLimit, Color color)
		{
			this.valueLimit = valueLimit;
			this.color = color;
		}

		public string ToString()
		{
			return "valueLimit: " + valueLimit.ToString() + ", color: " + color.ToString();
		}
	}

	// this class holds all of the color schemes
	public static class ColorScheme
	{
		private static ColorValue[] currentRange = defaultRange;
		private static ColorValue[] currentRangeBuilt = currentRange;

		// this is the basic gradient clarity value. It is used to measure the 
		// clarity of topographical levels. The higher the value, the smoother 
		// the transitions will be between map colors.
		private static int gradClar = 1;

		public static ColorValue[] defaultRange =
		{
			new ColorValue(.09, Color.FromArgb(000, 000, 128)), // deeps
			new ColorValue(.21, Color.FromArgb(000, 000, 191)), // mid
			new ColorValue(.39, Color.FromArgb(000, 000, 255)), // shallows
			new ColorValue(.45, Color.FromArgb(000, 128, 255)), // shore
			new ColorValue(.51, Color.FromArgb(255, 255, 153)), // sand
			new ColorValue(.69, Color.FromArgb(032, 160, 000)), // grass
			new ColorValue(.79, Color.FromArgb(153, 102, 051)), // dirt
			new ColorValue(.89, Color.FromArgb(128, 128, 128)), // rock
			new ColorValue(.99, Color.FromArgb(255, 255, 255))  // snow
		};

		public static ColorValue[] sepiaDefaultRange =
		{
			new ColorValue(.570, Color.FromArgb(208, 150, 092)), // water
			new ColorValue(.590, Color.FromArgb(128, 069, 029)), // shoreline
			new ColorValue(.620, Color.FromArgb(233, 193, 132)), // land
		};

		public static ColorValue[] blackAndWhiteRange =
		{
			new ColorValue(.001, Color.FromArgb(000, 000, 000)), // deep water
			new ColorValue(.250, Color.FromArgb(043, 043, 043)), // water
			new ColorValue(.400, Color.FromArgb(079, 079, 079)), // water
			new ColorValue(.500, Color.FromArgb(128, 128, 128)), // shoreline
			new ColorValue(.600, Color.FromArgb(166, 166, 166)), // land
			new ColorValue(.750, Color.FromArgb(209, 209, 209)), // deeper land
			new ColorValue(.999, Color.FromArgb(255, 255, 255))  // deeper land
		};

		// any row with "+" at the end is simply a darker version
		public static ColorValue[] desertRange = 
		{
			new ColorValue(.090, Color.FromArgb(000, 000, 255)), // water
			new ColorValue(.210, Color.FromArgb(000, 128, 255)), // shallow water
			new ColorValue(.390, Color.FromArgb(255, 255, 153)), // shoreline
			new ColorValue(.450, Color.FromArgb(232, 232, 139)), // light sand
			new ColorValue(.510, Color.FromArgb(232, 203, 139)), // light sand +
			new ColorValue(.690, Color.FromArgb(212, 176, 119)), // sand
			new ColorValue(.790, Color.FromArgb(181, 142, 080)), // sand +
			new ColorValue(.890, Color.FromArgb(150, 112, 050)), // 
			new ColorValue(.990, Color.FromArgb(084, 062, 027))  // snow
		};

		public static Color getColorFromValue(double value, ColorTone ct, int gradientClarity)
		{
			ColorValue[] scheme = defaultRange;

			switch (ct)
			{
				case ColorTone.DEFAULT:
					scheme = defaultRange;
					break;
				case ColorTone.DEFAULTTOPO:
					//scheme = defaultTopoRange;
					break;
				case ColorTone.SEPIA:
					scheme = sepiaDefaultRange;
					break;
				case ColorTone.SEPIATOPO:
					//scheme = sepiaTopoRange;
					break;
				case ColorTone.BLACKANDWHITE:
					scheme = blackAndWhiteRange;
					break;
				case ColorTone.DESERT:
					scheme = desertRange;
					break;
			}

			scheme = buildRange(scheme, gradientClarity);

			for (int i = 0; i < scheme.Length; i++)
			{
				if (value < scheme[i].valueLimit)
				{
					return scheme[i].color;
				}
			}

			return scheme[scheme.Length - 1].color;
		}

		public static ColorValue[] buildRange(ColorValue[] range, int gradientClarity)
		{
			// if the values being passed in are the same as the current settings, 
			// return the previously built range
			if (range == currentRange && gradClar == gradientClarity)
			{
				return currentRangeBuilt;
			}

			gradClar = gradientClarity;

			// if the value of gradientClarity was less than or equal to 0, 
			// return the original range
			if (gradClar < 1)
			{
				currentRangeBuilt = range;
				return range;
			}

			// if all else fails, build a new range
			currentRange = range;
			gradClar = gradientClarity;

			ColorValue[] newRange = new ColorValue[(range.Length - 1) * (gradClar - 1) + range.Length];

			for (int i = 0; i < range.Length - 1; i++)
			{
				newRange[i * gradClar] = range[i];

				double br, bg, bb, dr, dg, db, bv, dv;

				// set the base value for the colors
				br = range[i].color.R;
				bg = range[i].color.G;
				bb = range[i].color.B;

				// set the delta values for the colors
				dr = (range[i + 1].color.R - br) / gradClar;
				dg = (range[i + 1].color.G - bg) / gradClar;
				db = (range[i + 1].color.B - bb) / gradClar;

				// set the base value for the color valueLimit
				bv = range[i].valueLimit;

				// set the delta value for the color valueLimit
				dv = (range[i + 1].valueLimit - range[i].valueLimit) / (double)gradClar;

				for (int j = 1; j < gradClar; j++)
				{
					newRange[i * gradClar + j] = new ColorValue(bv + dv * j, Color.FromArgb(255, ((int)(br + dr * j)), (int)(bg + dg * j), (int)(bb + db * j)));
				}
			}

			newRange[newRange.Length - 1] = range[range.Length - 1];

			currentRangeBuilt = newRange;

			return currentRangeBuilt;
		}
	}
}