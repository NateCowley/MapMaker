using System.Drawing;

namespace MapMaker
{
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

		public void addPoint(int x, int y)
		{
			if (root != null)
			{
				root.addPoint(new QuadPoint(x, y));
			}
		}

		public void drawCells(Graphics g)
        {
			if(root != null)
            {
				root.drawCell(g);
            }
        }

		// Cells are the squares on the grid (of the quadtree). Not to be confused with points, which are individual points/pixels
		private class Cell
		{
			// upper-left hand corner of Cell
			private QuadPoint cellStartPoint;

			/// <summary>
			/// The X coordinate of the upper-left hand corner of the cell
			/// </summary>
			public int X
			{
				get { return cellStartPoint.X; }
			}

			/// <summary>
			/// The Y coordinate of the upper-left hand corner of the cell
			/// </summary>
			public int Y
			{
				get { return cellStartPoint.Y; }
			}

			// dimensions of Cell
			private int width, height;

			/// <summary>
			/// The Width of the cell
			/// </summary>
			public int W
			{
				get { return width; }
			}

			/// <summary>
			/// The Height of the cell
			/// </summary>
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
			private QuadPoint quadPoint;

			/// <summary>
			/// The publicly available QuadPoint that exists within this cell
			/// </summary>
			public QuadPoint CellPoint
			{
				get { return quadPoint; }
			}

			public Cell(int xPos, int yPos, int width, int height)
			{
				cellStartPoint = new QuadPoint(xPos, yPos);
				this.width = width;
				this.height = height;
			}

			public void addPoint(QuadPoint newPoint)
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
				else if (CellPoint != null)
				{
					if(newPoint.X == CellPoint.X && newPoint.Y == CellPoint.Y)
                    {
						return;
                    }

					subdivide();
					addPoint(newPoint);
					QuadPoint temp = quadPoint;
					quadPoint = null;
					addPoint(temp);
				}
				else
				{
					quadPoint = newPoint;
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

			public void drawCell(Graphics g)
            {
				g.DrawRectangle(new Pen(Color.Red), X, Y, width, height);

				if(CellPoint != null)
                {
					g.DrawRectangle(new Pen(Color.Blue), CellPoint.X, CellPoint.Y, 1, 1);
                }

				if(hasChildren)
                {
					nw.drawCell(g);
					ne.drawCell(g);
					se.drawCell(g);
					sw.drawCell(g);
                }
            }
		}
	}
}
