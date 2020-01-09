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
	public partial class mainWindow : Form
	{
		public int octaves = 1;
		public int clarity = 1;
		public int seed = 0;
		public double frequency = 1, amplitude = 1;
		public double scale = .15;
		public double persistence = .35;
		public double lacunarity = 2.0;
		public double xOffset = 0, yOffset = 0;
		public ColorTone ct = ColorTone.DEFAULT;
		public Biome biome = Biome.CUSTOM;
		public NoiseGenerator ng;
		private ToolStripMenuItem lastSchemeMItem, lastGeneratorMItem, lastBiomeMItem;
		private MapMaker mm = new MapMaker();
		private ProgressForm pf = new ProgressForm();
		
		private int poctaves = 0;
		private int pclarity = 0;
		private int pseed = 0;
		private double pfrequency = 1, pamplitude = 1;
		private double pscale = .15;
		private double ppersistence = .35;
		private double placunarity = 2.0;
		private double pxOffset = 0, pyOffset = 0;
		private ColorTone pct = ColorTone.DEFAULT;
		private Biome pbiome = Biome.CUSTOM;
		private NoiseGenerator png;

		public mainWindow()
		{
			InitializeComponent();

			Random r = new Random();
			seedTB.Text = r.Next().ToString();

			lastSchemeMItem = defaultColorSchemeToolStripMenuItem;
			lastGeneratorMItem = improvedNoiseToolStripMenuItem;
			lastBiomeMItem = customToolStripMenuItem;
			ng = new ImprovedNoise();
		}

		private void generateImage()
		{
			setVariables();

			if (checkVariables())
			{
				return;
			}

			pbiome = biome;
			pseed = seed;
			poctaves = octaves;
			pclarity = clarity;
			placunarity = lacunarity;
			pct = ct;
			pfrequency = frequency;
			pamplitude = amplitude;
			ppersistence = persistence;
			pscale = scale;
			pxOffset = xOffset;
			pyOffset = yOffset;
			png = ng;

			pf.FormBorderStyle = FormBorderStyle.FixedSingle;
			FormWindowState prevfws = pf.WindowState;
			pf.WindowState = FormWindowState.Normal;
			pf.StartPosition = FormStartPosition.Manual;

			Point p = new Point((int)(this.DesktopLocation.X  + this.Width / 2 - pf.Width / 2.5), (int)(this.DesktopLocation.Y  + this.Height / 2 - pf.Height / 3));

			pf.DesktopLocation = p;

			pf.FormBorderStyle = FormBorderStyle.None;

			Bitmap nbm = mm.generateImage(mapImagePB.Width, mapImagePB.Height, pf);

			if(nbm != null)
			{
				mapImagePB.Image = nbm;
			}

			return;
		}

		public void setVariables()
		{
			Int32.TryParse(octaveTB.Text, out octaves);
			Int32.TryParse(seedTB.Text, out seed);
			Int32.TryParse(clarityTB.Text, out clarity);
			Double.TryParse(frequencyTB.Text, out frequency);
			Double.TryParse(xOffsetTB.Text, out xOffset);
			Double.TryParse(yOffsetTB.Text, out yOffset);
			Double.TryParse(persistenceTB.Text, out persistence);
			//Double.TryParse(amplitudeTB.Text, out amplitude);
			Double.TryParse(lacunarityTB.Text, out lacunarity);
			Double.TryParse(scaleTB.Text, out scale);
			scale *= 100;

			if (seed < 0)
			{
				seed *= -1;
			}

			mm.setBiome(biome);
			mm.seed = seed;
			mm.octaves = octaves;
			mm.clarity = clarity;
			mm.lacunarity = lacunarity;
			mm.ct = ct;
			mm.frequency = frequency;
			mm.amplitude = amplitude;
			mm.persistence = persistence;
			mm.scale = scale;
			mm.xOffset = xOffset;
			mm.yOffset = yOffset;
			mm.ng = ng;
		}

		private bool checkVariables()
		{
			return pbiome == biome &&
				pseed == seed &&
				poctaves == octaves &&
				pclarity == clarity &&
				placunarity == lacunarity &&
				pct == ct &&
				pfrequency == frequency &&
				pamplitude == amplitude &&
				ppersistence == persistence &&
				pscale == scale &&
				pxOffset == xOffset &&
				pyOffset == yOffset &&
				png == ng;
		}

		private bool setCheckedColorSchemeItem(ToolStripMenuItem tsmi)
		{
			if (tsmi != lastSchemeMItem)
			{
				lastSchemeMItem.Checked = false;
				lastSchemeMItem = tsmi;
				tsmi.Checked = true;
			}

			return tsmi.Checked;
		}

		private bool setCheckedGeneratorItem(ToolStripMenuItem tsmi)
		{
			if (tsmi != lastGeneratorMItem)
			{
				lastGeneratorMItem.Checked = false;
				lastGeneratorMItem = tsmi;
				tsmi.Checked = true;
			}

			return tsmi.Checked;
		}

		private bool setCheckedBiomeItem(ToolStripMenuItem tsmi)
		{
			if (tsmi != lastBiomeMItem)
			{
				lastBiomeMItem.Checked = false;
				lastBiomeMItem = tsmi;
				tsmi.Checked = true;
			}

			return tsmi.Checked;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			generateImage();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			int zoomFactor = 2;
			if(mapImagePB.Image == null || true)
			{
				return;
			}

			Bitmap oldbm = new Bitmap(mapImagePB.Image);
			Size newSize = new Size((int)(oldbm.Width * zoomFactor), (int)(oldbm.Height * zoomFactor));
			Bitmap newbm = new Bitmap(oldbm, newSize);

			mapImagePB.Image = newbm;
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			Random rand = new Random();
			seedTB.Text = rand.Next().ToString();
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{/*
			double val = (double)scaleTrackBar.Value;
			scale = val;

			scaleLabel.Text = val.ToString();*/
		}

		private void persistenceTrackBar_Scroll(object sender, EventArgs e)
		{/*
			double val = (double)persistenceTrackBar.Value / 100;
			persistence = val;

			persistenceLabel.Text = val.ToString();*/
		}

		private void trackBar1_Scroll_1(object sender, EventArgs e)
		{/*
			int val = clarityTrackBar.Value;
			clarity = val;

			clarityLabel.Text = val.ToString();*/
		}

		private void defaultTopographicalToolStripMenuItem_Click(object sender, EventArgs e)
		{/*
			if (setCheckedMenuItem(defaultTopographicalToolStripMenuItem))
			{
				ct = ColorTone.DEFAULTTOPO;
			}*/
		}

		private void sepiaTopographicalToolStripMenuItem_Click(object sender, EventArgs e)
		{/*
			if (setCheckedMenuItem(sepiaTopographicalToolStripMenuItem))
			{
				ct = ColorTone.SEPIATOPO;
			}*/
		}

		private void improvedNoiseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (setCheckedGeneratorItem(improvedNoiseToolStripMenuItem))
			{
				ng = new ImprovedNoise(seed);
			}
		}

		private void simplexeNoiseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(setCheckedGeneratorItem(simplexNoiseToolStripMenuItem))
			{
				ng = new OpenSimplexNoise(seed);
			}
		}

		private void worleyNoiseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(setCheckedGeneratorItem(worleyNoiseToolStripMenuItem))
			{
				ng = new WorleyNoise();
			}
		}

		private void defaultToolStripMenuItem1_Click(object sender, EventArgs e)
		{/*
			if (setCheckedBiomeItem(defaultBiomeToolStripMenuItem))
			{
				biome = Biome.DEFAULT;
			}*/
		}

		private void archipelagoToolStripMenuItem_Click(object sender, EventArgs e)
		{/*
			if (setCheckedBiomeItem(archipelagoToolStripMenuItem))
			{
				biome = Biome.ARCHIPELAGO;
			}*/
		}

		private void customToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (setCheckedBiomeItem(customToolStripMenuItem))
			{
				biome = Biome.CUSTOM;
			}
		}

		private void plainsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (setCheckedBiomeItem(plainsToolStripMenuItem))
			{
				biome = Biome.PLAINS;
			}
		}

		private void continentsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (setCheckedBiomeItem(continentsToolStripMenuItem))
			{
				biome = Biome.CONTINENTS;
			}
		}

		private void desertToolStripMenuItem_Click(object sender, EventArgs e)
		{/*
			if (setCheckedBiomeItem(desertToolStripMenuItem))
			{
				biome = Biome.DESERT;
			}*/
		}

		private void desertToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			if(setCheckedColorSchemeItem(desertToolStripMenuItem))
			{
				ct = ColorTone.DESERT;
			}
		}

		private void checkEnterDown(object sender, PreviewKeyDownEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				generateImage();
			}
		}

		private void mountainToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (setCheckedBiomeItem(mountainToolStripMenuItem))
			{
				biome = Biome.MOUNTAINS;
			}
		}

		private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(setCheckedColorSchemeItem(defaultColorSchemeToolStripMenuItem))
			{
				ct = ColorTone.DEFAULT;
			}
		}

		private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(setCheckedColorSchemeItem(sepiaToolStripMenuItem))
			{
				ct = ColorTone.SEPIA;
			}
		}

		private void blackAndWhiteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (setCheckedColorSchemeItem(blackAndWhiteToolStripMenuItem))
			{
				ct = ColorTone.BLACKANDWHITE;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Random r = new Random();
			seed = r.Next();
			seedTB.Text = seed.ToString();
			generateImage();
		}
	}
}