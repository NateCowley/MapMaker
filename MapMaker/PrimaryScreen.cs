using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapMaker
{
	public partial class PrimaryScreen : Form
	{
		public int octaves = 1;
		public int clarity = 1;
		public int seed = 0, lastSeed = -1;
		public double frequency = 1, amplitude = 1;
		public double scale = .15;
		public double persistence = .35;
		public double lacunarity = 2.0;
		public double xOffset = 0, yOffset = 0;
		public ColorTone ct = ColorTone.DEFAULT;
		public Biome biome = Biome.CUSTOM;
		public NoiseGenerator ng;
		private ToolStripMenuItem lastSchemeMItem, lastGeneratorMItem, lastBiomeMItem;
		private Cartographer c = new Cartographer();
		private MapCombinator mc = new MapCombinator();
		private CartographerOptionPanel cop;
		private MapCombinatorOptionPanel mcop;
		private ProgressForm pf = new ProgressForm();
		private bool usingWorleyNoise = false;
		private bool isGeneratingMap = false;

		private SaveFileDialog sfd;
		private OpenFileDialog ofd;

		private int width = 0;
		private int height = 0;

		private OptionPanel op;
		private MapMaker mm;

		public PrimaryScreen()
		{
			InitializeComponent();

			ng = new OpenSimplexNoise();

			c = new Cartographer(cartographerOptionPanel);
			mc = new MapCombinator(mapCombinatorOptionPanel);

			cop = cartographerOptionPanel;
			mcop = mapCombinatorOptionPanel;

			mcop.setVisibility(false);

			setMapMaker(c, cop);

			createSFD();
		}

		private void generateImage()
		{
			isGeneratingMap = true;

			//cartographerOptionPanel.ng = ng;
			//cartographerOptionPanel.biome = biome;
			//cartographerOptionPanel.ct = ct;

			pf.FormBorderStyle = FormBorderStyle.FixedSingle;
			FormWindowState prevfws = pf.WindowState;
			pf.WindowState = FormWindowState.Normal;
			pf.StartPosition = FormStartPosition.Manual;

			Point p = new Point((int)(this.DesktopLocation.X  + this.Width / 2 - pf.Width / 2.5), (int)(this.DesktopLocation.Y  + this.Height / 2 - pf.Height / 3));

			pf.DesktopLocation = p;

			pf.FormBorderStyle = FormBorderStyle.None;

			if (pf != null)
			{
				pf.ProgressBarMax = mapImagePB.Width * mapImagePB.Height * 2;
				pf.ProgressBarValue = 0;
				pf.Visible = true;
			}

			//Bitmap nbm = c.generateImage(pf);
			Bitmap nbm = mm.GenerateMap(mapImagePB.Width, mapImagePB.Height, pf);

			if (pf != null)
			{
				pf.Visible = false;
			}

			isGeneratingMap = false;

			if(nbm != null)
			{
				mapImagePB.Image = nbm;
			}

			return;
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

			cartographerOptionPanel.setWorleyEnabled(usingWorleyNoise);

			//numPointsLabel.Visible = usingWorleyNoise;
			//numPointsTB.Visible = usingWorleyNoise;

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
			if(isGeneratingMap)
			{
				return;
			}

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
			//seedTB.Text = rand.Next().ToString();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			notAvailable();
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			notAvailable();
		}

		private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
		{
			notAvailable();
		}

		private void saveMapAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			saveAs();
		}

		private void setMapMaker(MapMaker nextMM, OptionPanel nextOP)
		{
			if(nextMM == mm && nextOP == op)
			{
				return;
			}

			if(mm == null || op == null)
			{
				mm = nextMM;
				op = nextOP;
				return;
			}

			op.setVisibility(false);

			mm = nextMM;
			op = nextOP;

			op.setVisibility(true);
		}

		private void notAvailable()
		{
			MessageBox.Show("Functionality not available yet");
		}

		private void combineMapsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			setMapMaker(mc, mcop);
		}

		private void printBitmapToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string path = Directory.GetCurrentDirectory();

			try
			{
				File.WriteAllLines(path + "\\debug.log", c.HeightNums);
			}
			catch(Exception ex)
			{

			}
		}

		private void printThirdValueToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(c.HeightNums[3]);
		}

		private void loadSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			notAvailable();
		}

		private void loadMapToolStripMenuItem_Click(object sender, EventArgs e)
		{
			notAvailable();
		}

		private void createMapsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			setMapMaker(c, cop);
		}

		private void generateRandom_Click(object sender, EventArgs e)
		{
			if (isGeneratingMap)
			{
				return;
			}

			cartographerOptionPanel.setSeed(new Random().Next());
			//seedTB.Text = seed.ToString();
			generateImage();
		}

		private void createSFD()
		{
			sfd = new SaveFileDialog();

			sfd.Filter = "PNG files (*.png)|*.png|Map Data Files (*.mdf)|*.mdf";

			sfd.RestoreDirectory = true;
		}

		private void saveAs()
		{
			if(mapImagePB.Image != null)
			{
				if(sfd == null)
				{
					createSFD();
				}

				if(sfd.ShowDialog() == DialogResult.OK)
				{
					string path = sfd.FileName;

					try
					{
						switch (sfd.FilterIndex)
						{
							case 1: // PNG
								mapImagePB.Image.Save(path);
								break;
							case 2: // MDF
								File.WriteAllLines(path, c.getMapPixelsForSave());
								File.AppendAllText(path, mapImagePB.Width.ToString() + " " + mapImagePB.Height);
								break;
						}
					}
					catch(Exception e)
					{

					}
				}
			}
		}

		private void createOFD()
		{
			ofd = new OpenFileDialog();

			ofd.Filter = "PNG files (*.png)|*.png|Map Data Files (*.mdf)|*.mdf";

			ofd.RestoreDirectory = true;
		}

		private void loadFile()
		{

		}
	}
}

/*
		public PrimaryScreen()
		{
			InitializeComponent();

			lastSchemeMItem = defaultColorSchemeToolStripMenuItem;
			lastGeneratorMItem = simplexNoiseToolStripMenuItem;
			lastBiomeMItem = customToolStripMenuItem;
			ng = new OpenSimplexNoise();

			c = new Cartographer(cartographerOptionPanel, mapImagePB);

			createSFD();
		}

		private bool setCheckedGeneratorItem(ToolStripMenuItem tsmi)
		{
			if (tsmi != lastGeneratorMItem)
			{
				lastGeneratorMItem.Checked = false;
				lastGeneratorMItem = tsmi;
				tsmi.Checked = true;
			}

			usingWorleyNoise = (tsmi.Text == myWorleyNoiseToolStripMenuItem.Text);
			cartographerOptionPanel.setWorleyEnabled(usingWorleyNoise);

			//numPointsLabel.Visible = usingWorleyNoise;
			//numPointsTB.Visible = usingWorleyNoise;

			return tsmi.Checked;
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

		private void myWorleyNoiseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (setCheckedGeneratorItem(myWorleyNoiseToolStripMenuItem))
			{
				ng = new WorleyNoise();
			}
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
		{
			if (setCheckedBiomeItem(desertToolStripMenuItem))
			{
				biome = Biome.DESERT;
			}
		}

		private void mountainToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (setCheckedBiomeItem(mountainToolStripMenuItem))
			{
				biome = Biome.MOUNTAINS;
			}
		}

		private void archipelagoToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			
			if (setCheckedBiomeItem(archipelagoToolStripMenuItem))
			{
				biome = Biome.ARCHIPELAGO_SUBTRACTIVE;
			}
			
		}

		private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (setCheckedColorSchemeItem(defaultColorSchemeToolStripMenuItem))
			{
				ct = ColorTone.DEFAULT;
			}
		}
		
			private void subtractiveArchipelagoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (setCheckedBiomeItem(subtractiveArchipelagoToolStripMenuItem))
			{
				biome = Biome.ARCHIPELAGO_SUBTRACTIVE;
			}
		}

		private void gradientArchipelagoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (setCheckedBiomeItem(gradientArchipelagoToolStripMenuItem))
			{
				biome = Biome.ARCHIPELAGO_GRADIENT;
			}
		}

		private void lerpArchipelagoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (setCheckedBiomeItem(lerpArchipelagoToolStripMenuItem))
			{
				biome = Biome.ARCHIPELAGO_LERP;
			}
		}

		private void atollToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (setCheckedBiomeItem(atollToolStripMenuItem))
			{
				biome = Biome.ATOLL;
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

		private void trackBar1_Scroll(object sender, EventArgs e)
		{/*
			double val = (double)scaleTrackBar.Value;
			scale = val;

			scaleLabel.Text = val.ToString();
		}

		private void persistenceTrackBar_Scroll(object sender, EventArgs e)
		{/*
			double val = (double)persistenceTrackBar.Value / 100;
			persistence = val;

			persistenceLabel.Text = val.ToString();
		}

		private void trackBar1_Scroll_1(object sender, EventArgs e)
		{/*
			int val = clarityTrackBar.Value;
			clarity = val;

			clarityLabel.Text = val.ToString();
		}

		private void defaultTopographicalToolStripMenuItem_Click(object sender, EventArgs e)
		{/*
			if (setCheckedMenuItem(defaultTopographicalToolStripMenuItem))
			{
				ct = ColorTone.DEFAULTTOPO;
			}
		}

		private void sepiaTopographicalToolStripMenuItem_Click(object sender, EventArgs e)
		{/*
			if (setCheckedMenuItem(sepiaTopographicalToolStripMenuItem))
			{
				ct = ColorTone.SEPIATOPO;
			}
		}

		private void defaultToolStripMenuItem1_Click(object sender, EventArgs e)
		{/*
			if (setCheckedBiomeItem(defaultBiomeToolStripMenuItem))
			{
				biome = Biome.DEFAULT;
			}
		}

		private void archipelagoToolStripMenuItem_Click(object sender, EventArgs e)
		{/*
			if (setCheckedBiomeItem(archipelagoToolStripMenuItem))
			{
				biome = Biome.ARCHIPELAGO;
			}
		}

		public bool setVariables()
		{
			bool[] res = new bool[9];
			//res[0] = Int32.TryParse(octaveTB.Text, out octaves);
			//res[1] = Int32.TryParse(seedTB.Text, out seed);
			//res[2] = Int32.TryParse(clarityTB.Text, out clarity);
			//res[3] = Double.TryParse(frequencyTB.Text, out frequency);
			//res[4] = Double.TryParse(xOffsetTB.Text, out xOffset);
			//res[5] = Double.TryParse(yOffsetTB.Text, out yOffset);
			//res[6] = Double.TryParse(persistenceTB.Text, out persistence);
			//Double.TryParse(amplitudeTB.Text, out amplitude);
			//res[7] = Double.TryParse(lacunarityTB.Text, out lacunarity);
			//res[8] = Double.TryParse(scaleTB.Text, out scale);
			scale *= 100;

			double[] miscOptions = new double[0];

			if(usingWorleyNoise)
			{
				miscOptions = new double[3];
				miscOptions[0] = mapImagePB.Width;
				miscOptions[1] = mapImagePB.Height;

				int numPoints = 0;
				//Int32.TryParse(numPointsTB.Text, out numPoints);

				if(numPoints <= 0)
				{
					MessageBox.Show("The number of points for Worley noise must be greater than 0");
					return false;
				}

				miscOptions[2] = numPoints;
			}

			//c.setVariables(biome, ct, ng, seed, octaves, clarity, lacunarity, frequency, amplitude,
				//persistence, scale, xOffset, yOffset, miscOptions, mapImagePB.Width, mapImagePB.Height);

			return (res[0] && res[1] && res[2] && res[3] && res[4] && res[5] && res[6] && res[7] && res[8]);
		}
*/
