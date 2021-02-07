using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapMaker
{
	/// <summary>
	/// An implementation of Worley noise using a regular grid
	/// </summary>
	class WorleyNoise : NoiseGenerator
	{
		//1240 510
		public int mapWidth = 620, mapHeight = 506;
		public int numPoints = 9;
		public List<CellPoint> points;

		public WorleyNoise()
		{
			distributeCellPoints();
		}

		public override double noise(double x, double y = 0.0427, double z = 0.1996)
		{
			double[] distances = new double[numPoints];

			CellPoint p = new CellPoint(x, y, z);

			for(int i = 0; i < numPoints; i++)
			{
				distances[i] = CellPoint.distance(p, points[i]);
			}

			Array.Sort(distances);

			int n = 0;

			return distances[n];
		}

		public override double octaveNoise(double x, double y, double z, int oct, double freq, double lac, double amp, double per, double scale, int seed)
		{
			return noise(x, y, z);
		}

		public override void setMiscOptions(double[] options)
		{
			if(options.Length < 1)
			{
				MessageBox.Show("Error: options not provided for worley noise");
				return;
			}

			mapWidth = (int)options[0];
			mapHeight = (int)options[1];
			numPoints = (int)options[2];
		}

		public void distributeCellPoints()
		{
			points = new List<CellPoint>();

			Random rand = new Random();

			NoiseGenerator osn = new ImprovedNoise();

			osn.setSeed(seed);

			string str = "";
			//MessageBox.Show(numPoints.ToString());
			
			for(int i = 0; i < numPoints; i++)
			{
				double xPos = (seed * 42069.5 / 1996) * (i + 9);
				double yPos = (seed * 42069.5 / 1996) * (i + 9);
				double zPos = (seed * 42069.5 / 1996) * (i + 9);

				uint ux = (uint)xPos;
				uint uy = (uint)yPos;
				uint uz = (uint)zPos;

				ux = ux & 0xFFc;
				uy = uy & 0xFFa;
				uz = uz & 0xFFc;

				xPos = ux * 10000 / 9.3;
				yPos = uy * 10000 / 9.3;
				zPos = uz * 10000 / 9.3;

				xPos = (osn.octaveNoise((xPos), .1996, yPos, 1, 16, 2.0, .35, 33, 1, seed) * 1000000);
				yPos = (osn.octaveNoise((yPos), .1996, xPos, 1, 16, 2.0, .35, 33, 1, seed) * 1000000);
				zPos = (osn.octaveNoise((xPos), (yPos), .1996, 8, 16, 2.0, .35, 33, 1, seed) * 1000000);

				str += "prep: " + (new CellPoint((double)xPos, (double)yPos)).ToString() + "\n";

				int x = ((int)(xPos)) % mapWidth;
				int y = ((int)(yPos)) % mapHeight;
				int z = (int)(zPos);
				
				str += "pre: " + (new CellPoint((double)x, (double)y)).ToString() + "\n";
				
				if (x < 0)
				{
					x *= -1;
					x %= mapWidth;
				}

				if(y < 0)
				{
					y *= -1;
					y %= mapHeight;
				}

				str += (new CellPoint((double)x, (double)y)).ToString() + "\n";

				points.Add(new CellPoint((double)x, (double)y));
			}

			//MessageBox.Show(str);
		}

		public override void setSeed(int seed = -1)
		{
			base.setSeed(seed);

			distributeCellPoints();
		}
	}

	class CellPoint
	{
		public double x, y, z;

		public CellPoint()
		{

		}

		public CellPoint(double x = 0, double y = 0, double z = 0)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public static double distance(CellPoint p1, CellPoint p2)
		{
			//d = ((x2 - x1)^2 + (y2 - y1)^2 + (z2-z1)^2)^(1/2)
			return Math.Sqrt(Math.Pow((p2.x - p1.x), 2) + Math.Pow((p2.y - p1.y), 2) + Math.Pow((p2.z - p1.z), 2));
		}

		public override string ToString()
		{
			return "X: " + x + ", Y: " + y + ", Z: " + z;
		}
	}

	class QuadTree
	{
		public static readonly int MAX_CELL_POINT_COUNT = 1;

		private Cell root;

		public QuadTree()
		{

		}

		public QuadTree(int mapWidth, int mapHeight)
		{
			root = new Cell(0, 0, mapWidth, mapHeight);
		}

		public void addPoint(Point newPoint)
		{
			if (root != null)
			{
				root.addPoint(newPoint);
			}
		}

		private class Cell
		{
			// upper-left hand corner of Cell
			private Point cellStartPoint;

			public int X
			{
				get { return cellStartPoint.X; }
			}

			public int Y
			{
				get { return cellStartPoint.Y; }
			}

			// dimensions of Cell
			private int width, height;

			public int W
			{
				get { return width; }
			}

			public int H
			{
				get { return height; }
			}

			// Cell children
			// Northwest Cell child
			private Cell nw;
			// Northeast Cell child
			private Cell ne;
			// Southeast Cell child
			private Cell se;
			// Southwest Cell child
			private Cell sw;

			// bool indicating Cell has children
			// we could sit here and ask if all children are null, but
			// the children are all made at the same time, so we only 
			// really need to check if the first one has been made
			public bool hasChildren
			{
				get { return (nw != null); }
			}

			// location of cellular noise point contained in cell
			private Point point;

			public Point NoisePoint
			{
				get { return point; }
			}

			public Cell(int xPos, int yPos, int width, int height)
			{
				cellStartPoint = new Point(xPos, yPos);
				this.width = width;
				this.height = height;
			}

			public void addPoint(Point newPoint)
			{
				if (hasChildren)
				{
					int px = newPoint.X;
					int py = newPoint.Y;

					// local variables used to simplify child cell dimension declarations
					int westWidth = W;
					int northHeight = H;

					// set width of western cells based on parent's width
					if (westWidth % 2 != 0)
					{
						westWidth = W / 2 + 1;
					}
					else
					{
						westWidth /= 2;
					}

					// set height of northern cells based on parent's height
					if (northHeight % 2 != 0)
					{
						northHeight = H / 2 + 1;
					}
					else
					{
						northHeight /= 2;
					}

					// if newPoint.x is less than the midway point of this cell, 
					// it must be in the Western cells (wagon trails)
					// else, it's in the Eastern cells (no elbow room)
					if (px < X + westWidth)
					{
						// find north vs south
						// if newPoint.y is less than the midway point of this cell,
						// it must be in the Northern cells (darn yankee)
						// else, it's in the Southern cells (dadgum!)
						if (py < Y + northHeight)
						{
							nw.addPoint(newPoint);
						}
						else
						{
							sw.addPoint(newPoint);
						}
					}
					else
					{
						// find north vs south
						// if newPoint.y is less than the midway point of this cell,
						// it must be in the Northern cells (darn yankee)
						// else, it's in the Southern cells (dadgum!)
						if (py < Y + northHeight)
						{
							ne.addPoint(newPoint);
						}
						else
						{
							se.addPoint(newPoint);
						}
					}

					// find which child it goes in
					// se.addPoint(newPoint);
				}
				else if (NoisePoint != null)
				{
					subdivide();
					addPoint(newPoint);
				}
				else
				{
					point = newPoint;
				}
			}

			public void subdivide()
			{
				// double check we're not overwriting existing children
				if (hasChildren)
				{
					return;
				}

				// if the width of the parent cell is odd, do the following dimension changes for child cells:
				// 1. set all Western cells' widths to half the parent's width + 1
				// if the height of the parent cell is odd, do the following dimension changes for child cells:
				// 1. set all Northern cells' heights to half the parent's width + 1
				// example: 
				// parent cell's dimensions: 99W 67H
				// NW: 50W 34H
				// NE: 49W 34H
				// SE: 49W 33H
				// SW: 50W 33H

				// local variables used to simplify child cell dimension declarations
				int westWidth = W;
				int northHeight = H;

				// set width of western cells based on parent's width
				if (westWidth % 2 != 0)
				{
					westWidth = W / 2 + 1;
				}
				else
				{
					westWidth /= 2;
				}

				// set height of northern cells based on parent's height
				if (northHeight % 2 != 0)
				{
					northHeight = H / 2 + 1;
				}
				else
				{
					northHeight /= 2;
				}

				nw = new Cell(X, Y, westWidth, northHeight);

				ne = new Cell(X + W / 2, Y, W / 2, northHeight);

				se = new Cell(X + W / 2, Y + H / 2, W / 2, H / 2);

				sw = new Cell(X, Y + H / 2, westWidth, H / 2);
			}
		}
	}
}
