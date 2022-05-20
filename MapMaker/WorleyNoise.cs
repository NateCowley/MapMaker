using System;
using System.Collections.Generic;
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
}
