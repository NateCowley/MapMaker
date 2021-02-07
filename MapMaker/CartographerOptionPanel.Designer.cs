namespace MapMaker
{
	partial class CartographerOptionPanel
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.numPointsLabel = new System.Windows.Forms.Label();
			this.numPointsTB = new System.Windows.Forms.TextBox();
			this.lacunarityLabel = new System.Windows.Forms.Label();
			this.lacunarityTB = new System.Windows.Forms.TextBox();
			this.clarityLabel = new System.Windows.Forms.Label();
			this.clarityTB = new System.Windows.Forms.TextBox();
			this.scaleLabel = new System.Windows.Forms.Label();
			this.scaleTB = new System.Windows.Forms.TextBox();
			this.persistenceLabel = new System.Windows.Forms.Label();
			this.persistenceTB = new System.Windows.Forms.TextBox();
			this.seedLabel = new System.Windows.Forms.Label();
			this.yOffsetLabel = new System.Windows.Forms.Label();
			this.yOffsetTB = new System.Windows.Forms.TextBox();
			this.xOffsetLabel = new System.Windows.Forms.Label();
			this.xOffsetTB = new System.Windows.Forms.TextBox();
			this.seedTB = new System.Windows.Forms.TextBox();
			this.frequencyLabel = new System.Windows.Forms.Label();
			this.frequencyTB = new System.Windows.Forms.TextBox();
			this.octaveLabel = new System.Windows.Forms.Label();
			this.octaveTB = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.generatorTypeCB = new System.Windows.Forms.ComboBox();
			this.colorSchemeCB = new System.Windows.Forms.ComboBox();
			this.biomeCB = new System.Windows.Forms.ComboBox();
			this.archipelagoMethodCB = new System.Windows.Forms.ComboBox();
			this.archipelagoMethodLabel = new System.Windows.Forms.Label();
			this.atollRadiusLabel = new System.Windows.Forms.Label();
			this.atollRadiusTB = new System.Windows.Forms.TextBox();
			this.genRandSeedCB = new System.Windows.Forms.CheckBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// numPointsLabel
			// 
			this.numPointsLabel.AutoSize = true;
			this.numPointsLabel.Location = new System.Drawing.Point(1, 510);
			this.numPointsLabel.Name = "numPointsLabel";
			this.numPointsLabel.Size = new System.Drawing.Size(88, 13);
			this.numPointsLabel.TabIndex = 60;
			this.numPointsLabel.Text = "Number of Points";
			this.toolTip1.SetToolTip(this.numPointsLabel, "Determines the number of cells that will appear on the map.");
			// 
			// numPointsTB
			// 
			this.numPointsTB.Location = new System.Drawing.Point(4, 529);
			this.numPointsTB.Name = "numPointsTB";
			this.numPointsTB.Size = new System.Drawing.Size(160, 20);
			this.numPointsTB.TabIndex = 59;
			this.numPointsTB.Text = "9";
			this.toolTip1.SetToolTip(this.numPointsTB, "Determines the number of cells that will appear on the map.");
			// 
			// lacunarityLabel
			// 
			this.lacunarityLabel.AutoSize = true;
			this.lacunarityLabel.Location = new System.Drawing.Point(1, 215);
			this.lacunarityLabel.Name = "lacunarityLabel";
			this.lacunarityLabel.Size = new System.Drawing.Size(56, 13);
			this.lacunarityLabel.TabIndex = 58;
			this.lacunarityLabel.Text = "Lacunarity";
			this.toolTip1.SetToolTip(this.lacunarityLabel, "Lacunarity determines how much detail is added or removed at each octave (adjusts" +
		" frequency).");
			// 
			// lacunarityTB
			// 
			this.lacunarityTB.Location = new System.Drawing.Point(3, 234);
			this.lacunarityTB.Name = "lacunarityTB";
			this.lacunarityTB.Size = new System.Drawing.Size(161, 20);
			this.lacunarityTB.TabIndex = 57;
			this.lacunarityTB.Text = "2.0";
			this.toolTip1.SetToolTip(this.lacunarityTB, "Lacunarity determines how much detail is added or removed at each octave (adjusts" +
		" frequency).");
			// 
			// clarityLabel
			// 
			this.clarityLabel.AutoSize = true;
			this.clarityLabel.Location = new System.Drawing.Point(1, 343);
			this.clarityLabel.Name = "clarityLabel";
			this.clarityLabel.Size = new System.Drawing.Size(35, 13);
			this.clarityLabel.TabIndex = 56;
			this.clarityLabel.Text = "Clarity";
			this.toolTip1.SetToolTip(this.clarityLabel, "Clarity is the amount of times the color scheme is subdivided. A clarity of 1 mea" +
		"ns there is no subdivision. Higher clarity makes for smoother colors between hei" +
		"ght levels.");
			// 
			// clarityTB
			// 
			this.clarityTB.Location = new System.Drawing.Point(4, 360);
			this.clarityTB.Name = "clarityTB";
			this.clarityTB.Size = new System.Drawing.Size(160, 20);
			this.clarityTB.TabIndex = 55;
			this.clarityTB.Text = "1";
			this.toolTip1.SetToolTip(this.clarityTB, "Clarity is the amount of times the color scheme is subdivided. A clarity of 1 mea" +
		"ns there is no subdivision. Higher clarity makes for smoother colors between hei" +
		"ght levels.");
			// 
			// scaleLabel
			// 
			this.scaleLabel.AutoSize = true;
			this.scaleLabel.Location = new System.Drawing.Point(1, 301);
			this.scaleLabel.Name = "scaleLabel";
			this.scaleLabel.Size = new System.Drawing.Size(34, 13);
			this.scaleLabel.TabIndex = 54;
			this.scaleLabel.Text = "Scale";
			this.toolTip1.SetToolTip(this.scaleLabel, "Determines the scale of the map. A lower scale means a more \"zoomed out\" image.");
			// 
			// scaleTB
			// 
			this.scaleTB.Location = new System.Drawing.Point(4, 318);
			this.scaleTB.Name = "scaleTB";
			this.scaleTB.Size = new System.Drawing.Size(160, 20);
			this.scaleTB.TabIndex = 53;
			this.scaleTB.Text = "25";
			this.toolTip1.SetToolTip(this.scaleTB, "Determines the scale of the map. A lower scale means a more \"zoomed out\" image.");
			// 
			// persistenceLabel
			// 
			this.persistenceLabel.AutoSize = true;
			this.persistenceLabel.Location = new System.Drawing.Point(1, 257);
			this.persistenceLabel.Name = "persistenceLabel";
			this.persistenceLabel.Size = new System.Drawing.Size(62, 13);
			this.persistenceLabel.TabIndex = 52;
			this.persistenceLabel.Text = "Persistence";
			this.toolTip1.SetToolTip(this.persistenceLabel, "Persistence determines how much each octave contributes to the overall shape.");
			// 
			// persistenceTB
			// 
			this.persistenceTB.Location = new System.Drawing.Point(4, 276);
			this.persistenceTB.Name = "persistenceTB";
			this.persistenceTB.Size = new System.Drawing.Size(160, 20);
			this.persistenceTB.TabIndex = 51;
			this.persistenceTB.Text = "0.35";
			this.toolTip1.SetToolTip(this.persistenceTB, "Persistence determines how much each octave contributes to the overall shape.");
			// 
			// seedLabel
			// 
			this.seedLabel.AutoSize = true;
			this.seedLabel.Location = new System.Drawing.Point(1, 385);
			this.seedLabel.Name = "seedLabel";
			this.seedLabel.Size = new System.Drawing.Size(32, 13);
			this.seedLabel.TabIndex = 45;
			this.seedLabel.Text = "Seed";
			this.toolTip1.SetToolTip(this.seedLabel, "Determines the pattern of the map.");
			// 
			// yOffsetLabel
			// 
			this.yOffsetLabel.AutoSize = true;
			this.yOffsetLabel.Location = new System.Drawing.Point(1, 469);
			this.yOffsetLabel.Name = "yOffsetLabel";
			this.yOffsetLabel.Size = new System.Drawing.Size(45, 13);
			this.yOffsetLabel.TabIndex = 50;
			this.yOffsetLabel.Text = "Y Offset";
			this.toolTip1.SetToolTip(this.yOffsetLabel, "Used to move up/down on the map.");
			// 
			// yOffsetTB
			// 
			this.yOffsetTB.Location = new System.Drawing.Point(4, 486);
			this.yOffsetTB.Name = "yOffsetTB";
			this.yOffsetTB.Size = new System.Drawing.Size(160, 20);
			this.yOffsetTB.TabIndex = 49;
			this.yOffsetTB.Text = "0";
			this.toolTip1.SetToolTip(this.yOffsetTB, "Used to move up/down on the map.");
			// 
			// xOffsetLabel
			// 
			this.xOffsetLabel.AutoSize = true;
			this.xOffsetLabel.Location = new System.Drawing.Point(1, 427);
			this.xOffsetLabel.Name = "xOffsetLabel";
			this.xOffsetLabel.Size = new System.Drawing.Size(45, 13);
			this.xOffsetLabel.TabIndex = 48;
			this.xOffsetLabel.Text = "X Offset";
			this.toolTip1.SetToolTip(this.xOffsetLabel, "Used to move left/right on the map.");
			// 
			// xOffsetTB
			// 
			this.xOffsetTB.Location = new System.Drawing.Point(4, 444);
			this.xOffsetTB.Name = "xOffsetTB";
			this.xOffsetTB.Size = new System.Drawing.Size(160, 20);
			this.xOffsetTB.TabIndex = 47;
			this.xOffsetTB.Text = "0";
			this.toolTip1.SetToolTip(this.xOffsetTB, "Used to move left/right on the map.");
			// 
			// seedTB
			// 
			this.seedTB.Location = new System.Drawing.Point(4, 402);
			this.seedTB.Name = "seedTB";
			this.seedTB.Size = new System.Drawing.Size(160, 20);
			this.seedTB.TabIndex = 44;
			this.toolTip1.SetToolTip(this.seedTB, "Determines the pattern of the map.");
			// 
			// frequencyLabel
			// 
			this.frequencyLabel.AutoSize = true;
			this.frequencyLabel.Location = new System.Drawing.Point(1, 173);
			this.frequencyLabel.Name = "frequencyLabel";
			this.frequencyLabel.Size = new System.Drawing.Size(57, 13);
			this.frequencyLabel.TabIndex = 43;
			this.frequencyLabel.Text = "Frequency";
			this.toolTip1.SetToolTip(this.frequencyLabel, "Frequency determines the number of small details on the map. Increasing the frequ" +
		"ency increases the amount and decreases the size of details.");
			// 
			// frequencyTB
			// 
			this.frequencyTB.Location = new System.Drawing.Point(4, 192);
			this.frequencyTB.Name = "frequencyTB";
			this.frequencyTB.Size = new System.Drawing.Size(160, 20);
			this.frequencyTB.TabIndex = 42;
			this.frequencyTB.Text = "32";
			this.toolTip1.SetToolTip(this.frequencyTB, "Frequency determines the number of small details on the map. Increasing the frequ" +
		"ency increases the amount and decreases the size of details.");
			// 
			// octaveLabel
			// 
			this.octaveLabel.AutoSize = true;
			this.octaveLabel.Location = new System.Drawing.Point(1, 133);
			this.octaveLabel.Name = "octaveLabel";
			this.octaveLabel.Size = new System.Drawing.Size(47, 13);
			this.octaveLabel.TabIndex = 41;
			this.octaveLabel.Text = "Octaves";
			this.toolTip1.SetToolTip(this.octaveLabel, "Octaves determine the largescale amount of details on the map. The higher the oct" +
		"ave count, the more the details there will be.");
			// 
			// octaveTB
			// 
			this.octaveTB.Location = new System.Drawing.Point(4, 150);
			this.octaveTB.Name = "octaveTB";
			this.octaveTB.Size = new System.Drawing.Size(160, 20);
			this.octaveTB.TabIndex = 40;
			this.octaveTB.Text = "4";
			this.toolTip1.SetToolTip(this.octaveTB, "Octaves determine the largescale amount of details on the map. The higher the oct" +
		"ave count, the more the details there will be.");
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(1, 89);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 13);
			this.label1.TabIndex = 66;
			this.label1.Text = "Color Scheme";
			this.toolTip1.SetToolTip(this.label1, "The color scheme helps provide context to the generated maps.");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(1, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 13);
			this.label2.TabIndex = 64;
			this.label2.Text = "Biome";
			this.toolTip1.SetToolTip(this.label2, "The biome will adjust the final outcome of the map. Certain biomes will disable m" +
		"ap continuity.");
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(1, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(81, 13);
			this.label3.TabIndex = 62;
			this.label3.Text = "Generator Type";
			this.toolTip1.SetToolTip(this.label3, "The generator that will handle the underlying details behind the map.");
			// 
			// generatorTypeCB
			// 
			this.generatorTypeCB.FormattingEnabled = true;
			this.generatorTypeCB.Items.AddRange(new object[] {
			"Simplex Noise",
			"Improved Noise",
			"Worley Noise"});
			this.generatorTypeCB.Location = new System.Drawing.Point(4, 19);
			this.generatorTypeCB.Name = "generatorTypeCB";
			this.generatorTypeCB.Size = new System.Drawing.Size(160, 21);
			this.generatorTypeCB.TabIndex = 67;
			this.toolTip1.SetToolTip(this.generatorTypeCB, "The generator that will handle the underlying details behind the map.");
			this.generatorTypeCB.SelectedIndexChanged += new System.EventHandler(this.generatorTypeCB_SelectedIndexChanged);
			// 
			// colorSchemeCB
			// 
			this.colorSchemeCB.FormattingEnabled = true;
			this.colorSchemeCB.Items.AddRange(new object[] {
			"Default",
			"Sepia",
			"Black and White"});
			this.colorSchemeCB.Location = new System.Drawing.Point(3, 105);
			this.colorSchemeCB.Name = "colorSchemeCB";
			this.colorSchemeCB.Size = new System.Drawing.Size(160, 21);
			this.colorSchemeCB.TabIndex = 67;
			this.toolTip1.SetToolTip(this.colorSchemeCB, "The color scheme helps provide context to the generated maps.");
			this.colorSchemeCB.SelectedIndexChanged += new System.EventHandler(this.colorSchemeCB_SelectedIndexChanged);
			// 
			// biomeCB
			// 
			this.biomeCB.FormattingEnabled = true;
			this.biomeCB.Items.AddRange(new object[] {
			"Continents",
			"Plains",
			"Mountains",
			"Desert",
			"Archipelago",
			"Atoll"});
			this.biomeCB.Location = new System.Drawing.Point(4, 62);
			this.biomeCB.Name = "biomeCB";
			this.biomeCB.Size = new System.Drawing.Size(160, 21);
			this.biomeCB.TabIndex = 67;
			this.toolTip1.SetToolTip(this.biomeCB, "The biome will adjust the final outcome of the map. Certain biomes will disable m" +
		"ap continuity.");
			this.biomeCB.SelectedIndexChanged += new System.EventHandler(this.biomeCB_SelectedIndexChanged);
			// 
			// archipelagoMethodCB
			// 
			this.archipelagoMethodCB.FormattingEnabled = true;
			this.archipelagoMethodCB.Items.AddRange(new object[] {
			"Subtractive",
			"Gradient",
			"Linear Interpolation"});
			this.archipelagoMethodCB.Location = new System.Drawing.Point(4, 568);
			this.archipelagoMethodCB.Name = "archipelagoMethodCB";
			this.archipelagoMethodCB.Size = new System.Drawing.Size(160, 21);
			this.archipelagoMethodCB.TabIndex = 69;
			this.toolTip1.SetToolTip(this.archipelagoMethodCB, "Determines the method used to create an archipelago.");
			this.archipelagoMethodCB.SelectedIndexChanged += new System.EventHandler(this.archipelagoMethodCB_SelectedIndexChanged);
			// 
			// archipelagoMethodLabel
			// 
			this.archipelagoMethodLabel.AutoSize = true;
			this.archipelagoMethodLabel.Location = new System.Drawing.Point(3, 552);
			this.archipelagoMethodLabel.Name = "archipelagoMethodLabel";
			this.archipelagoMethodLabel.Size = new System.Drawing.Size(102, 13);
			this.archipelagoMethodLabel.TabIndex = 68;
			this.archipelagoMethodLabel.Text = "Archipelago Method";
			this.toolTip1.SetToolTip(this.archipelagoMethodLabel, "Determines the method used to create an archipelago.");
			// 
			// atollRadiusLabel
			// 
			this.atollRadiusLabel.AutoSize = true;
			this.atollRadiusLabel.Location = new System.Drawing.Point(3, 592);
			this.atollRadiusLabel.Name = "atollRadiusLabel";
			this.atollRadiusLabel.Size = new System.Drawing.Size(63, 13);
			this.atollRadiusLabel.TabIndex = 71;
			this.atollRadiusLabel.Text = "Atoll Radius";
			this.toolTip1.SetToolTip(this.atollRadiusLabel, "Determines how far out from the center of the map the center of the atoll will be" +
		".");
			// 
			// atollRadiusTB
			// 
			this.atollRadiusTB.Location = new System.Drawing.Point(4, 608);
			this.atollRadiusTB.Name = "atollRadiusTB";
			this.atollRadiusTB.Size = new System.Drawing.Size(160, 20);
			this.atollRadiusTB.TabIndex = 70;
			this.atollRadiusTB.Text = "5";
			this.toolTip1.SetToolTip(this.atollRadiusTB, "Determines how far out from the center of the map the center of the atoll will be" +
		".");
			// 
			// genRandSeedCB
			// 
			this.genRandSeedCB.AutoSize = true;
			this.genRandSeedCB.Location = new System.Drawing.Point(6, 634);
			this.genRandSeedCB.Name = "genRandSeedCB";
			this.genRandSeedCB.Size = new System.Drawing.Size(134, 17);
			this.genRandSeedCB.TabIndex = 72;
			this.genRandSeedCB.Text = "Generate random seed";
			this.toolTip1.SetToolTip(this.genRandSeedCB, "When selected, it automatically generates a new seed when you press \"Generate map" +
		"\"");
			this.genRandSeedCB.UseVisualStyleBackColor = true;
			// 
			// CartographerOptionPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.genRandSeedCB);
			this.Controls.Add(this.atollRadiusLabel);
			this.Controls.Add(this.atollRadiusTB);
			this.Controls.Add(this.archipelagoMethodCB);
			this.Controls.Add(this.archipelagoMethodLabel);
			this.Controls.Add(this.biomeCB);
			this.Controls.Add(this.colorSchemeCB);
			this.Controls.Add(this.generatorTypeCB);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.numPointsLabel);
			this.Controls.Add(this.numPointsTB);
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
			this.Controls.Add(this.seedTB);
			this.Controls.Add(this.frequencyLabel);
			this.Controls.Add(this.frequencyTB);
			this.Controls.Add(this.octaveLabel);
			this.Controls.Add(this.octaveTB);
			this.Name = "CartographerOptionPanel";
			this.Size = new System.Drawing.Size(193, 725);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label numPointsLabel;
		private System.Windows.Forms.TextBox numPointsTB;
		private System.Windows.Forms.Label lacunarityLabel;
		private System.Windows.Forms.TextBox lacunarityTB;
		private System.Windows.Forms.Label clarityLabel;
		private System.Windows.Forms.TextBox clarityTB;
		private System.Windows.Forms.Label scaleLabel;
		private System.Windows.Forms.TextBox scaleTB;
		private System.Windows.Forms.Label persistenceLabel;
		private System.Windows.Forms.TextBox persistenceTB;
		private System.Windows.Forms.Label seedLabel;
		private System.Windows.Forms.Label yOffsetLabel;
		private System.Windows.Forms.TextBox yOffsetTB;
		private System.Windows.Forms.Label xOffsetLabel;
		private System.Windows.Forms.TextBox xOffsetTB;
		private System.Windows.Forms.TextBox seedTB;
		private System.Windows.Forms.Label frequencyLabel;
		private System.Windows.Forms.TextBox frequencyTB;
		private System.Windows.Forms.Label octaveLabel;
		private System.Windows.Forms.TextBox octaveTB;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox generatorTypeCB;
		private System.Windows.Forms.ComboBox colorSchemeCB;
		private System.Windows.Forms.ComboBox biomeCB;
		private System.Windows.Forms.ComboBox archipelagoMethodCB;
		private System.Windows.Forms.Label archipelagoMethodLabel;
		private System.Windows.Forms.Label atollRadiusLabel;
		private System.Windows.Forms.TextBox atollRadiusTB;
		private System.Windows.Forms.CheckBox genRandSeedCB;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}
