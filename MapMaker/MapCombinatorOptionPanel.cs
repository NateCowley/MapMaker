using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MapMaker
{
	public partial class MapCombinatorOptionPanel : UserControl, OptionPanel
	{
		private string filePath1, filePath2;

		public bool map1UsingOpacity
		{
			get { return map1OpacityCB.Checked; }
		}

		public bool map2UsingOpacity
		{
			get { return map2OpacityCB.Checked; }
		}

		public bool normalize
		{
			get { return normalizeCB.Checked; }
		}

		public CombinatorMethod comboMethod
		{
			get { return (CombinatorMethod)combinatorModeCB.SelectedIndex; }
		}

		public int clarity
		{
			get
			{
				int c = 1;

				if(Int32.TryParse(clarityTB.Text, out c))
				{
					return c;
				}

				return 1;
			}
		}

		public double map1Opacity
		{
			get
			{
				double tempOpacity = 1.0;

				if(Double.TryParse(map1OpacityTB.Text, out tempOpacity))
				{
					return tempOpacity / 100;
				}

				MessageBox.Show("Opacity must be a valid number between 0 and 100");

				return 1;
			}
		}

		public double map2Opacity
		{
			get
			{
				double tempOpacity = 1.0;

				if (Double.TryParse(map2OpacityTB.Text, out tempOpacity))
				{
					return tempOpacity / 100;
				}

				MessageBox.Show("Opacity must be a valid number between 0 and 100");

				return 1.0;
			}
		}

		public ColorTone colorTone
		{
			get 
			{
				switch(colorSchemeCB.SelectedIndex)
				{
					case 0:
						return ColorTone.DEFAULT;
					case 1:
						return ColorTone.SEPIA;
					case 2:
						return ColorTone.BLACKANDWHITE;
					default:
						return ColorTone.DEFAULT;
				}
			}
		}

		public string map1Path
		{
			get { return filePath1; }
		}

		public string map2Path
		{
			get { return filePath2; }
		}

		public MapCombinatorOptionPanel()
		{
			InitializeComponent();

			combinatorModeCB.MouseWheel += new MouseEventHandler(this.mouseWheelDisabled);

			combinatorModeCB.SelectedIndex = 0;
			colorSchemeCB.SelectedIndex = 0;
		}

		private void combinatorModeCB_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void mouseWheelDisabled(object sender, EventArgs e)
		{
			((HandledMouseEventArgs)e).Handled = true;
		}

		public bool variablesSet(int width, int height)
		{
			if(map1Path == "" || map1Path == map2Path || map2Path == "")
			{
				MessageBox.Show("Please enter a path for both maps to be combined.");
				return false;
			}

			try
			{
				string m1Lines = File.ReadLines(map1Path).Last();
				string m2Lines = File.ReadAllLines(map2Path).Last();

				int width1 = Int32.Parse(m1Lines.Substring(0, m1Lines.IndexOf(' ')));
				int height1 = Int32.Parse(m1Lines.Substring(m1Lines.IndexOf(' ') + 1));

				int width2 = Int32.Parse(m2Lines.Substring(0, m2Lines.IndexOf(' ')));
				int height2 = Int32.Parse(m2Lines.Substring(m2Lines.IndexOf(' ') + 1));

				if(width1 != width2 && height1 != height2)
				{
					MessageBox.Show("The maps must have the same dimensions.");
				}
			}
			catch (Exception ex)
			{

			}

			return true;
		}

		public void setVisibility(bool visible)
		{
			this.Visible = visible;
		}

		private void loadMap1Button_Click(object sender, EventArgs e)
		{
			filePath1 = loadFile();
			map1TB.Text = filePath1;
			map1TB.SelectionStart = map1TB.Text.Length;
			map1TB.SelectionLength = 0;
		}

		private void loadMap2Button_Click(object sender, EventArgs e)
		{
			filePath2 = loadFile();
			map2TB.Text = filePath2;
			map2TB.SelectionStart = map2TB.Text.Length;
			map2TB.SelectionLength = 0;
		}

		private string loadFile()
		{
			if (ofd == null)
			{
				createOFD();
			}

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				return ofd.FileName;
			}

			return "";
		}

		private void createOFD()
		{
			ofd = new OpenFileDialog();

			ofd.Filter = "Map Data Files (*.mdf)|*.mdf";

			ofd.RestoreDirectory = true;
		}
	}
}