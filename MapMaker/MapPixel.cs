using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
	public class MapPixel
	{
		#region MEMBERS
		private int posX, posY;
		public double baseHeight, heightOffset;

		public int X { get { return posX; } }
		public int Y { get { return posY; } }
		#endregion MEMBERS

		#region PROPERTIES
		public double Height { get { return baseHeight + heightOffset; } }
		#endregion PROPERTIES

		#region CONSTRUCTORS
		public MapPixel() : this(0, 0, 0.0, 0.0) { }

		public MapPixel(int x, int y) : this(x, y, 0.0, 0.0) { }

		public MapPixel(int x, int y, double height) : this(x, y, height, 0.0) { }

		public MapPixel(int x, int y, double height, double heightOffset)
		{
			posX = x;
			posY = y;
			baseHeight = height;
			this.heightOffset = heightOffset;
		}
		#endregion CONSTRUCTORS

		public override string ToString()
		{
			return posX.ToString() + " " + posY.ToString() + " " + baseHeight.ToString();
		}
	}
}
