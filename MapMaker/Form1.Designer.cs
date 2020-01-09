namespace MapMaker
{
	partial class mainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWindow));
			this.mapImagePB = new System.Windows.Forms.PictureBox();
			this.generateButton = new System.Windows.Forms.Button();
			this.octaveTB = new System.Windows.Forms.TextBox();
			this.octaveLabel = new System.Windows.Forms.Label();
			this.frequencyLabel = new System.Windows.Forms.Label();
			this.frequencyTB = new System.Windows.Forms.TextBox();
			this.seedLabel = new System.Windows.Forms.Label();
			this.seedTB = new System.Windows.Forms.TextBox();
			this.generateRandomSeedButton = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveMapAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.colorSchemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.defaultColorSchemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sepiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.blackAndWhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.noiseGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.improvedNoiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.simplexNoiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.worleyNoiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.biomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.continentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.plainsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mountainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.xOffsetLabel = new System.Windows.Forms.Label();
			this.xOffsetTB = new System.Windows.Forms.TextBox();
			this.yOffsetLabel = new System.Windows.Forms.Label();
			this.yOffsetTB = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.persistenceLabel = new System.Windows.Forms.Label();
			this.persistenceTB = new System.Windows.Forms.TextBox();
			this.scaleLabel = new System.Windows.Forms.Label();
			this.scaleTB = new System.Windows.Forms.TextBox();
			this.clarityLabel = new System.Windows.Forms.Label();
			this.clarityTB = new System.Windows.Forms.TextBox();
			this.lacunarityLabel = new System.Windows.Forms.Label();
			this.lacunarityTB = new System.Windows.Forms.TextBox();
			this.desertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.mapImagePB)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mapImagePB
			// 
			this.mapImagePB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mapImagePB.Location = new System.Drawing.Point(305, 33);
			this.mapImagePB.Margin = new System.Windows.Forms.Padding(4);
			this.mapImagePB.Name = "mapImagePB";
			this.mapImagePB.Size = new System.Drawing.Size(827, 619);
			this.mapImagePB.TabIndex = 0;
			this.mapImagePB.TabStop = false;
			this.mapImagePB.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// generateButton
			// 
			this.generateButton.Location = new System.Drawing.Point(15, 576);
			this.generateButton.Margin = new System.Windows.Forms.Padding(4);
			this.generateButton.Name = "generateButton";
			this.generateButton.Size = new System.Drawing.Size(281, 34);
			this.generateButton.TabIndex = 2;
			this.generateButton.Text = "Generate";
			this.generateButton.UseVisualStyleBackColor = true;
			this.generateButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// octaveTB
			// 
			this.octaveTB.Location = new System.Drawing.Point(15, 57);
			this.octaveTB.Margin = new System.Windows.Forms.Padding(4);
			this.octaveTB.Name = "octaveTB";
			this.octaveTB.Size = new System.Drawing.Size(280, 22);
			this.octaveTB.TabIndex = 3;
			this.octaveTB.Text = "8";
			this.toolTip1.SetToolTip(this.octaveTB, resources.GetString("octaveTB.ToolTip"));
			this.octaveTB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.checkEnterDown);
			// 
			// octaveLabel
			// 
			this.octaveLabel.AutoSize = true;
			this.octaveLabel.Location = new System.Drawing.Point(16, 33);
			this.octaveLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.octaveLabel.Name = "octaveLabel";
			this.octaveLabel.Size = new System.Drawing.Size(60, 17);
			this.octaveLabel.TabIndex = 4;
			this.octaveLabel.Text = "Octaves";
			this.toolTip1.SetToolTip(this.octaveLabel, resources.GetString("octaveLabel.ToolTip"));
			// 
			// frequencyLabel
			// 
			this.frequencyLabel.AutoSize = true;
			this.frequencyLabel.Location = new System.Drawing.Point(16, 85);
			this.frequencyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.frequencyLabel.Name = "frequencyLabel";
			this.frequencyLabel.Size = new System.Drawing.Size(75, 17);
			this.frequencyLabel.TabIndex = 6;
			this.frequencyLabel.Text = "Frequency";
			this.toolTip1.SetToolTip(this.frequencyLabel, "Frequency determines how many changes occur across \r\nthe map. Higher values incre" +
        "ase the number of changes.\r\n\r\nThe typical range for frequency is 1 to 16.\r\n");
			// 
			// frequencyTB
			// 
			this.frequencyTB.Location = new System.Drawing.Point(15, 108);
			this.frequencyTB.Margin = new System.Windows.Forms.Padding(4);
			this.frequencyTB.Name = "frequencyTB";
			this.frequencyTB.Size = new System.Drawing.Size(280, 22);
			this.frequencyTB.TabIndex = 5;
			this.frequencyTB.Text = "16";
			this.toolTip1.SetToolTip(this.frequencyTB, "Frequency determines how many changes occur across \r\nthe map. Higher values incre" +
        "ase the number of changes.\r\n\r\nThe typical range for frequency is 1 to 16.\r\n");
			this.frequencyTB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.checkEnterDown);
			// 
			// seedLabel
			// 
			this.seedLabel.AutoSize = true;
			this.seedLabel.Location = new System.Drawing.Point(16, 343);
			this.seedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.seedLabel.Name = "seedLabel";
			this.seedLabel.Size = new System.Drawing.Size(41, 17);
			this.seedLabel.TabIndex = 10;
			this.seedLabel.Text = "Seed";
			// 
			// seedTB
			// 
			this.seedTB.Location = new System.Drawing.Point(15, 367);
			this.seedTB.Margin = new System.Windows.Forms.Padding(4);
			this.seedTB.Name = "seedTB";
			this.seedTB.Size = new System.Drawing.Size(280, 22);
			this.seedTB.TabIndex = 9;
			this.seedTB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.checkEnterDown);
			// 
			// generateRandomSeedButton
			// 
			this.generateRandomSeedButton.Location = new System.Drawing.Point(15, 618);
			this.generateRandomSeedButton.Margin = new System.Windows.Forms.Padding(4);
			this.generateRandomSeedButton.Name = "generateRandomSeedButton";
			this.generateRandomSeedButton.Size = new System.Drawing.Size(281, 34);
			this.generateRandomSeedButton.TabIndex = 15;
			this.generateRandomSeedButton.Text = "Generate (Random Seed)";
			this.generateRandomSeedButton.UseVisualStyleBackColor = true;
			this.generateRandomSeedButton.Click += new System.EventHandler(this.button3_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.colorSchemeToolStripMenuItem,
            this.noiseGeneratorToolStripMenuItem,
            this.biomeToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(1148, 28);
			this.menuStrip1.TabIndex = 19;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.saveMapToolStripMenuItem,
            this.saveMapAsToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
			this.saveToolStripMenuItem.Text = "Save Settings";
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
			this.saveAsToolStripMenuItem.Text = "Save Settings As...";
			// 
			// saveMapToolStripMenuItem
			// 
			this.saveMapToolStripMenuItem.Name = "saveMapToolStripMenuItem";
			this.saveMapToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
			this.saveMapToolStripMenuItem.Text = "Save Map";
			// 
			// saveMapAsToolStripMenuItem
			// 
			this.saveMapAsToolStripMenuItem.Name = "saveMapAsToolStripMenuItem";
			this.saveMapAsToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
			this.saveMapAsToolStripMenuItem.Text = "Save Map As...";
			// 
			// colorSchemeToolStripMenuItem
			// 
			this.colorSchemeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultColorSchemeToolStripMenuItem,
            this.sepiaToolStripMenuItem,
            this.blackAndWhiteToolStripMenuItem,
            this.desertToolStripMenuItem});
			this.colorSchemeToolStripMenuItem.Name = "colorSchemeToolStripMenuItem";
			this.colorSchemeToolStripMenuItem.Size = new System.Drawing.Size(113, 24);
			this.colorSchemeToolStripMenuItem.Text = "Color Scheme";
			// 
			// defaultColorSchemeToolStripMenuItem
			// 
			this.defaultColorSchemeToolStripMenuItem.Checked = true;
			this.defaultColorSchemeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.defaultColorSchemeToolStripMenuItem.Name = "defaultColorSchemeToolStripMenuItem";
			this.defaultColorSchemeToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
			this.defaultColorSchemeToolStripMenuItem.Text = "Default";
			this.defaultColorSchemeToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
			// 
			// sepiaToolStripMenuItem
			// 
			this.sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
			this.sepiaToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
			this.sepiaToolStripMenuItem.Text = "Sepia";
			this.sepiaToolStripMenuItem.Click += new System.EventHandler(this.sepiaToolStripMenuItem_Click);
			// 
			// blackAndWhiteToolStripMenuItem
			// 
			this.blackAndWhiteToolStripMenuItem.Name = "blackAndWhiteToolStripMenuItem";
			this.blackAndWhiteToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
			this.blackAndWhiteToolStripMenuItem.Text = "Black and White";
			this.blackAndWhiteToolStripMenuItem.Click += new System.EventHandler(this.blackAndWhiteToolStripMenuItem_Click);
			// 
			// noiseGeneratorToolStripMenuItem
			// 
			this.noiseGeneratorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.improvedNoiseToolStripMenuItem,
            this.simplexNoiseToolStripMenuItem,
            this.worleyNoiseToolStripMenuItem});
			this.noiseGeneratorToolStripMenuItem.Name = "noiseGeneratorToolStripMenuItem";
			this.noiseGeneratorToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
			this.noiseGeneratorToolStripMenuItem.Text = "Noise Generator";
			// 
			// improvedNoiseToolStripMenuItem
			// 
			this.improvedNoiseToolStripMenuItem.Checked = true;
			this.improvedNoiseToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.improvedNoiseToolStripMenuItem.Name = "improvedNoiseToolStripMenuItem";
			this.improvedNoiseToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
			this.improvedNoiseToolStripMenuItem.Text = "Improved Noise";
			this.improvedNoiseToolStripMenuItem.Click += new System.EventHandler(this.improvedNoiseToolStripMenuItem_Click);
			// 
			// simplexNoiseToolStripMenuItem
			// 
			this.simplexNoiseToolStripMenuItem.Name = "simplexNoiseToolStripMenuItem";
			this.simplexNoiseToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
			this.simplexNoiseToolStripMenuItem.Text = "Simplex Noise";
			this.simplexNoiseToolStripMenuItem.Click += new System.EventHandler(this.simplexeNoiseToolStripMenuItem_Click);
			// 
			// worleyNoiseToolStripMenuItem
			// 
			this.worleyNoiseToolStripMenuItem.Name = "worleyNoiseToolStripMenuItem";
			this.worleyNoiseToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
			this.worleyNoiseToolStripMenuItem.Text = "Worley Noise";
			this.worleyNoiseToolStripMenuItem.Click += new System.EventHandler(this.worleyNoiseToolStripMenuItem_Click);
			// 
			// biomeToolStripMenuItem
			// 
			this.biomeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customToolStripMenuItem,
            this.continentsToolStripMenuItem,
            this.plainsToolStripMenuItem,
            this.mountainToolStripMenuItem});
			this.biomeToolStripMenuItem.Name = "biomeToolStripMenuItem";
			this.biomeToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
			this.biomeToolStripMenuItem.Text = "Biome";
			// 
			// customToolStripMenuItem
			// 
			this.customToolStripMenuItem.Checked = true;
			this.customToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.customToolStripMenuItem.Name = "customToolStripMenuItem";
			this.customToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
			this.customToolStripMenuItem.Text = "Default";
			this.customToolStripMenuItem.Click += new System.EventHandler(this.customToolStripMenuItem_Click);
			// 
			// continentsToolStripMenuItem
			// 
			this.continentsToolStripMenuItem.Name = "continentsToolStripMenuItem";
			this.continentsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
			this.continentsToolStripMenuItem.Text = "Continents";
			this.continentsToolStripMenuItem.Click += new System.EventHandler(this.continentsToolStripMenuItem_Click);
			// 
			// plainsToolStripMenuItem
			// 
			this.plainsToolStripMenuItem.Name = "plainsToolStripMenuItem";
			this.plainsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
			this.plainsToolStripMenuItem.Text = "Plains";
			this.plainsToolStripMenuItem.Click += new System.EventHandler(this.plainsToolStripMenuItem_Click);
			// 
			// mountainToolStripMenuItem
			// 
			this.mountainToolStripMenuItem.Name = "mountainToolStripMenuItem";
			this.mountainToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
			this.mountainToolStripMenuItem.Text = "Mountains";
			this.mountainToolStripMenuItem.Click += new System.EventHandler(this.mountainToolStripMenuItem_Click);
			// 
			// xOffsetLabel
			// 
			this.xOffsetLabel.AutoSize = true;
			this.xOffsetLabel.Location = new System.Drawing.Point(16, 395);
			this.xOffsetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.xOffsetLabel.Name = "xOffsetLabel";
			this.xOffsetLabel.Size = new System.Drawing.Size(59, 17);
			this.xOffsetLabel.TabIndex = 21;
			this.xOffsetLabel.Text = "X Offset";
			// 
			// xOffsetTB
			// 
			this.xOffsetTB.Location = new System.Drawing.Point(15, 418);
			this.xOffsetTB.Margin = new System.Windows.Forms.Padding(4);
			this.xOffsetTB.Name = "xOffsetTB";
			this.xOffsetTB.Size = new System.Drawing.Size(280, 22);
			this.xOffsetTB.TabIndex = 20;
			this.xOffsetTB.Text = "0";
			this.xOffsetTB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.checkEnterDown);
			// 
			// yOffsetLabel
			// 
			this.yOffsetLabel.AutoSize = true;
			this.yOffsetLabel.Location = new System.Drawing.Point(16, 447);
			this.yOffsetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.yOffsetLabel.Name = "yOffsetLabel";
			this.yOffsetLabel.Size = new System.Drawing.Size(59, 17);
			this.yOffsetLabel.TabIndex = 23;
			this.yOffsetLabel.Text = "Y Offset";
			// 
			// yOffsetTB
			// 
			this.yOffsetTB.Location = new System.Drawing.Point(15, 470);
			this.yOffsetTB.Margin = new System.Windows.Forms.Padding(4);
			this.yOffsetTB.Name = "yOffsetTB";
			this.yOffsetTB.Size = new System.Drawing.Size(280, 22);
			this.yOffsetTB.TabIndex = 22;
			this.yOffsetTB.Text = "0";
			this.yOffsetTB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.checkEnterDown);
			// 
			// persistenceLabel
			// 
			this.persistenceLabel.AutoSize = true;
			this.persistenceLabel.Location = new System.Drawing.Point(16, 188);
			this.persistenceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.persistenceLabel.Name = "persistenceLabel";
			this.persistenceLabel.Size = new System.Drawing.Size(82, 17);
			this.persistenceLabel.TabIndex = 30;
			this.persistenceLabel.Text = "Persistence";
			this.toolTip1.SetToolTip(this.persistenceLabel, "how much the small features affect the map\r\n\r\nThe typical range for octaves is 1 " +
        "to 8.");
			// 
			// persistenceTB
			// 
			this.persistenceTB.Location = new System.Drawing.Point(15, 212);
			this.persistenceTB.Margin = new System.Windows.Forms.Padding(4);
			this.persistenceTB.Name = "persistenceTB";
			this.persistenceTB.Size = new System.Drawing.Size(280, 22);
			this.persistenceTB.TabIndex = 29;
			this.persistenceTB.Text = "0.35";
			this.toolTip1.SetToolTip(this.persistenceTB, "how much the small features affect the map\r\n\r\nThe typical range for octaves is 1 " +
        "to 8.");
			this.persistenceTB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.checkEnterDown);
			// 
			// scaleLabel
			// 
			this.scaleLabel.AutoSize = true;
			this.scaleLabel.Location = new System.Drawing.Point(16, 240);
			this.scaleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.scaleLabel.Name = "scaleLabel";
			this.scaleLabel.Size = new System.Drawing.Size(43, 17);
			this.scaleLabel.TabIndex = 32;
			this.scaleLabel.Text = "Scale";
			this.toolTip1.SetToolTip(this.scaleLabel, "Scale measures the size of the map drawn from the \r\ntop-left corner. It\'s essenti" +
        "ally the zoom factor. Think of \r\nthe scale as magnification percent.\r\n\r\nThe typi" +
        "cal range for scale is 1 to 100.");
			// 
			// scaleTB
			// 
			this.scaleTB.Location = new System.Drawing.Point(15, 263);
			this.scaleTB.Margin = new System.Windows.Forms.Padding(4);
			this.scaleTB.Name = "scaleTB";
			this.scaleTB.Size = new System.Drawing.Size(280, 22);
			this.scaleTB.TabIndex = 31;
			this.scaleTB.Text = "33";
			this.toolTip1.SetToolTip(this.scaleTB, "Scale measures the size of the map drawn from the \r\ntop-left corner. It\'s essenti" +
        "ally the zoom factor. Think of \r\nthe scale as magnification percent.\r\n\r\nThe typi" +
        "cal range for scale is 1 to 100.");
			this.scaleTB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.checkEnterDown);
			// 
			// clarityLabel
			// 
			this.clarityLabel.AutoSize = true;
			this.clarityLabel.Location = new System.Drawing.Point(16, 292);
			this.clarityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.clarityLabel.Name = "clarityLabel";
			this.clarityLabel.Size = new System.Drawing.Size(47, 17);
			this.clarityLabel.TabIndex = 34;
			this.clarityLabel.Text = "Clarity";
			this.toolTip1.SetToolTip(this.clarityLabel, resources.GetString("clarityLabel.ToolTip"));
			// 
			// clarityTB
			// 
			this.clarityTB.Location = new System.Drawing.Point(15, 315);
			this.clarityTB.Margin = new System.Windows.Forms.Padding(4);
			this.clarityTB.Name = "clarityTB";
			this.clarityTB.Size = new System.Drawing.Size(280, 22);
			this.clarityTB.TabIndex = 33;
			this.clarityTB.Text = "1";
			this.toolTip1.SetToolTip(this.clarityTB, resources.GetString("clarityTB.ToolTip"));
			this.clarityTB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.checkEnterDown);
			// 
			// lacunarityLabel
			// 
			this.lacunarityLabel.AutoSize = true;
			this.lacunarityLabel.Location = new System.Drawing.Point(16, 137);
			this.lacunarityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lacunarityLabel.Name = "lacunarityLabel";
			this.lacunarityLabel.Size = new System.Drawing.Size(74, 17);
			this.lacunarityLabel.TabIndex = 36;
			this.lacunarityLabel.Text = "Lacunarity";
			this.toolTip1.SetToolTip(this.lacunarityLabel, "increases num small features\r\n\r\nThe typical range for octaves is 1 to 8.");
			// 
			// lacunarityTB
			// 
			this.lacunarityTB.Location = new System.Drawing.Point(15, 160);
			this.lacunarityTB.Margin = new System.Windows.Forms.Padding(4);
			this.lacunarityTB.Name = "lacunarityTB";
			this.lacunarityTB.Size = new System.Drawing.Size(280, 22);
			this.lacunarityTB.TabIndex = 35;
			this.lacunarityTB.Text = "2.0";
			this.toolTip1.SetToolTip(this.lacunarityTB, "increases num small features\r\n\r\nThe typical range for octaves is 1 to 8.");
			this.lacunarityTB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.checkEnterDown);
			// 
			// desertToolStripMenuItem
			// 
			this.desertToolStripMenuItem.Name = "desertToolStripMenuItem";
			this.desertToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
			this.desertToolStripMenuItem.Text = "Desert";
			this.desertToolStripMenuItem.Click += new System.EventHandler(this.desertToolStripMenuItem_Click_1);
			// 
			// mainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1148, 667);
			this.Controls.Add(this.lacunarityLabel);
			this.Controls.Add(this.lacunarityTB);
			this.Controls.Add(this.clarityLabel);
			this.Controls.Add(this.clarityTB);
			this.Controls.Add(this.scaleLabel);
			this.Controls.Add(this.scaleTB);
			this.Controls.Add(this.persistenceLabel);
			this.Controls.Add(this.persistenceTB);
			this.Controls.Add(this.seedLabel);
			this.Controls.Add(this.yOffsetLabel);
			this.Controls.Add(this.yOffsetTB);
			this.Controls.Add(this.xOffsetLabel);
			this.Controls.Add(this.xOffsetTB);
			this.Controls.Add(this.generateRandomSeedButton);
			this.Controls.Add(this.seedTB);
			this.Controls.Add(this.frequencyLabel);
			this.Controls.Add(this.frequencyTB);
			this.Controls.Add(this.octaveLabel);
			this.Controls.Add(this.octaveTB);
			this.Controls.Add(this.generateButton);
			this.Controls.Add(this.mapImagePB);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "mainWindow";
			this.Text = "MapMaker";
			((System.ComponentModel.ISupportInitialize)(this.mapImagePB)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox mapImagePB;
		private System.Windows.Forms.Button generateButton;
		private System.Windows.Forms.TextBox octaveTB;
		private System.Windows.Forms.Label octaveLabel;
		private System.Windows.Forms.Label frequencyLabel;
		private System.Windows.Forms.TextBox frequencyTB;
		private System.Windows.Forms.Label seedLabel;
		private System.Windows.Forms.TextBox seedTB;
		private System.Windows.Forms.Button generateRandomSeedButton;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem colorSchemeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem defaultColorSchemeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sepiaToolStripMenuItem;
		private System.Windows.Forms.Label xOffsetLabel;
		private System.Windows.Forms.TextBox xOffsetTB;
		private System.Windows.Forms.Label yOffsetLabel;
		private System.Windows.Forms.TextBox yOffsetTB;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveMapToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveMapAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem noiseGeneratorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem improvedNoiseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem simplexNoiseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem worleyNoiseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem biomeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem plainsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mountainToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem blackAndWhiteToolStripMenuItem;
		private System.Windows.Forms.Label persistenceLabel;
		private System.Windows.Forms.TextBox persistenceTB;
		private System.Windows.Forms.Label scaleLabel;
		private System.Windows.Forms.TextBox scaleTB;
		private System.Windows.Forms.Label clarityLabel;
		private System.Windows.Forms.TextBox clarityTB;
		private System.Windows.Forms.ToolStripMenuItem continentsToolStripMenuItem;
		private System.Windows.Forms.Label lacunarityLabel;
		private System.Windows.Forms.TextBox lacunarityTB;
		private System.Windows.Forms.ToolStripMenuItem desertToolStripMenuItem;
	}
}

