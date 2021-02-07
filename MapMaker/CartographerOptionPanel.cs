using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapMaker
{
	public partial class CartographerOptionPanel : UserControl, OptionPanel
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
		public Biome biome = Biome.CONTINENTS;
		public NoiseGenerator ng;
		private double[] miscGeneratorOptions;
		private double[] miscBiomeOptions;
		public int width;
		public int height;

		public bool usingWorleyNoise = false;
		public bool usingArchipelago = false;
		public bool usingAtoll = false;

		public bool generateRandomSeed
		{
			get { return genRandSeedCB.Checked; }
		}

		public double[] MiscGeneratorOptions
		{
			get { return miscGeneratorOptions; }
		}

		public double[] MiscBiomeOptions
		{
			get { return miscBiomeOptions; }
		}

		public CartographerOptionPanel()
		{
			InitializeComponent();

			this.generatorTypeCB.MouseWheel += new MouseEventHandler(this.mouseWheelDisabled);
			this.biomeCB.MouseWheel += new MouseEventHandler(this.mouseWheelDisabled);
			this.colorSchemeCB.MouseWheel += new MouseEventHandler(this.mouseWheelDisabled);
			this.archipelagoMethodCB.MouseWheel += new MouseEventHandler(this.mouseWheelDisabled);

			Random r = new Random();
			seedTB.Text = r.Next().ToString();

			generatorTypeCB.SelectedIndex = 0;
			biomeCB.SelectedIndex = 0;
			colorSchemeCB.SelectedIndex = 0;
			archipelagoMethodCB.SelectedIndex = 0;

			setNoiseGenerator(generatorTypeCB.SelectedIndex);
			setColorScheme(colorSchemeCB.SelectedIndex);
			setArchipelagoMethod(archipelagoMethodCB.SelectedIndex);

			setBiome(biomeCB.SelectedIndex);

			setWorleyEnabled(false);
			setArchipelagoMethodEnabled(false);
			setAtollEnabled(false);
		}

		private void generatorTypeCB_SelectedIndexChanged(object sender, EventArgs e)
		{
			setNoiseGenerator(generatorTypeCB.SelectedIndex);
		}

		private void biomeCB_SelectedIndexChanged(object sender, EventArgs e)
		{
			setBiome(biomeCB.SelectedIndex);
		}

		private void colorSchemeCB_SelectedIndexChanged(object sender, EventArgs e)
		{
			setColorScheme(colorSchemeCB.SelectedIndex);
		}

		private void archipelagoMethodCB_SelectedIndexChanged(object sender, EventArgs e)
		{
			setArchipelagoMethod(archipelagoMethodCB.SelectedIndex);
		}

		private void mouseWheelDisabled(object sender, EventArgs e)
		{
			((HandledMouseEventArgs)e).Handled = true;
		}

		private void setNoiseGenerator(int num)
		{
			setWorleyEnabled(false);

			switch(num)
			{
				case 0: // simplex noise
					ng = new OpenSimplexNoise();
					break;
				case 1: // improved noise
					ng = new ImprovedNoise();
					break;
				case 2: // worley noise
					ng = new WorleyNoise();
					setWorleyEnabled(true);
					break;
			}
		}

		private void setBiome(int num)
		{
			setArchipelagoMethodEnabled(false);
			setAtollEnabled(false);

			switch(num)
			{
				case 0: // continents
					biome = Biome.CONTINENTS;
					break;
				case 1: // plains
					biome = Biome.PLAINS;
					break;
				case 2: // mountains
					biome = Biome.MOUNTAINS;
					break;
				case 3: // desert
					biome = Biome.DESERT;
					break;
				case 4: // archipelago
					biome = Biome.ARCHIPELAGO_SUBTRACTIVE;
					setArchipelagoMethodEnabled(true);
					break;
				case 5: // atoll
					biome = Biome.ATOLL;
					setAtollEnabled(true);
					break;
			}
		}

		private void setArchipelagoMethod(int num)
		{
			switch (num)
			{
				case 0: // subtractive
					biome = Biome.ARCHIPELAGO_SUBTRACTIVE;
					break;
				case 1: // gradient
					biome = Biome.ARCHIPELAGO_GRADIENT;
					break;
				case 2: // linear interpolation
					biome = Biome.ARCHIPELAGO_LERP;
					break;
			}
		}

		private void setColorScheme(int num)
		{
			switch(num)
			{
				case 0: // default
					ct = ColorTone.DEFAULT;
					break;
				case 1: // sepia
					ct = ColorTone.SEPIA;
					break;
				case 2: // black and white
					ct = ColorTone.BLACKANDWHITE;
					break;
			}
		}

		public bool variablesSet(int width, int height)
		{
			this.width = width;
			this.height = height;

			if(generateRandomSeed == true)
			{
				seedTB.Text = new Random().Next().ToString();
			}

			bool[] res = new bool[9];
			res[0] = Int32.TryParse(octaveTB.Text, out octaves);
			res[1] = Int32.TryParse(seedTB.Text, out seed);
			res[2] = Int32.TryParse(clarityTB.Text, out clarity);
			res[3] = Double.TryParse(frequencyTB.Text, out frequency);
			res[4] = Double.TryParse(xOffsetTB.Text, out xOffset);
			res[5] = Double.TryParse(yOffsetTB.Text, out yOffset);
			res[6] = Double.TryParse(persistenceTB.Text, out persistence);
			res[7] = Double.TryParse(lacunarityTB.Text, out lacunarity);
			res[8] = Double.TryParse(scaleTB.Text, out scale);
			scale *= 100;

			miscGeneratorOptions = new double[1];
			miscGeneratorOptions[0] = 0.0;

			miscBiomeOptions = new double[1];
			MiscGeneratorOptions[0] = 0.0;

			if (usingWorleyNoise)
			{
				miscGeneratorOptions = new double[(int)GeneratorMiscOptions.WORLEY];

				int numPoints = 0;
				Int32.TryParse(numPointsTB.Text, out numPoints);

				if (numPoints <= 0)
				{
					MessageBox.Show("The number of points for Worley noise must be a valid number greater than 0");
					return false;
				}

				miscGeneratorOptions[0] = width;
				miscGeneratorOptions[1] = height;
				miscGeneratorOptions[2] = numPoints;
			}

			if(usingArchipelago)
			{

			}

			if(usingAtoll)
			{
				miscBiomeOptions = new double[(int)BiomeMiscOptions.ATOLL];

				double r = 0;
				Double.TryParse(atollRadiusTB.Text, out r);

				if (r <= 0.0)
				{
					MessageBox.Show("The atoll radius must be a valid number greater than 0");
					return false;
				}

				miscBiomeOptions[0] = r;
			}

			return (res[0] && res[1] && res[2] && res[3] && res[4] && res[5] && res[6] && res[7] && res[8]);
		}

		public void setWorleyEnabled(bool val)
		{
			usingWorleyNoise = val;
			numPointsLabel.Enabled = val;
			numPointsTB.Enabled = val;
		}

		public void setArchipelagoMethodEnabled(bool val)
		{
			usingArchipelago = val;
			archipelagoMethodLabel.Enabled = val;
			archipelagoMethodCB.Enabled = val;
		}

		public void setAtollEnabled(bool val)
		{
			usingAtoll = val;
			atollRadiusLabel.Enabled = val;
			atollRadiusTB.Enabled = val;
		}

		public void setSeed(int seed)
		{
			this.seed = seed;
			seedTB.Text = seed.ToString();
			ng.setSeed(seed);
		}

		public void setVisibility(bool visible)
		{
			this.Visible = visible;
		}
	}
}
