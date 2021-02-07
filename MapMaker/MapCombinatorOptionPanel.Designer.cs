namespace MapMaker
{
	partial class MapCombinatorOptionPanel
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
			this.map2OpacityCB = new System.Windows.Forms.CheckBox();
			this.map1OpacityCB = new System.Windows.Forms.CheckBox();
			this.combinatorModeCB = new System.Windows.Forms.ComboBox();
			this.map2OpacityTB = new System.Windows.Forms.TextBox();
			this.map1OpacityTB = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.normalizeCB = new System.Windows.Forms.CheckBox();
			this.map1TB = new System.Windows.Forms.TextBox();
			this.map2TB = new System.Windows.Forms.TextBox();
			this.loadMap2Button = new System.Windows.Forms.Button();
			this.loadMap1Button = new System.Windows.Forms.Button();
			this.colorSchemeCB = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.clarityLabel = new System.Windows.Forms.Label();
			this.clarityTB = new System.Windows.Forms.TextBox();
			this.ofd = new System.Windows.Forms.OpenFileDialog();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// map2OpacityCB
			// 
			this.map2OpacityCB.AutoSize = true;
			this.map2OpacityCB.Checked = true;
			this.map2OpacityCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.map2OpacityCB.Location = new System.Drawing.Point(8, 128);
			this.map2OpacityCB.Name = "map2OpacityCB";
			this.map2OpacityCB.Size = new System.Drawing.Size(133, 17);
			this.map2OpacityCB.TabIndex = 26;
			this.map2OpacityCB.Text = "Apply opacity to map 2";
			this.toolTip1.SetToolTip(this.map2OpacityCB, "Check if you want the opacity value to be applied to the map. If not, it will def" +
        "ault to 100% opacity.");
			this.map2OpacityCB.UseVisualStyleBackColor = true;
			// 
			// map1OpacityCB
			// 
			this.map1OpacityCB.AutoSize = true;
			this.map1OpacityCB.Checked = true;
			this.map1OpacityCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.map1OpacityCB.Location = new System.Drawing.Point(8, 54);
			this.map1OpacityCB.Name = "map1OpacityCB";
			this.map1OpacityCB.Size = new System.Drawing.Size(133, 17);
			this.map1OpacityCB.TabIndex = 25;
			this.map1OpacityCB.Text = "Apply opacity to map 1";
			this.toolTip1.SetToolTip(this.map1OpacityCB, "Check if you want the opacity value to be applied to the map. If not, it will def" +
        "ault to 100% opacity.");
			this.map1OpacityCB.UseVisualStyleBackColor = true;
			// 
			// combinatorModeCB
			// 
			this.combinatorModeCB.FormattingEnabled = true;
			this.combinatorModeCB.Items.AddRange(new object[] {
            "Additive",
            "Subtractive",
            "Multiplicative",
            "Min",
            "Max",
            "Average"});
			this.combinatorModeCB.Location = new System.Drawing.Point(8, 188);
			this.combinatorModeCB.Name = "combinatorModeCB";
			this.combinatorModeCB.Size = new System.Drawing.Size(156, 21);
			this.combinatorModeCB.TabIndex = 24;
			this.toolTip1.SetToolTip(this.combinatorModeCB, "Determines the method used to combine the maps. These can create very different o" +
        "utcomes depending on how they are used.");
			this.combinatorModeCB.SelectedIndexChanged += new System.EventHandler(this.combinatorModeCB_SelectedIndexChanged);
			// 
			// map2OpacityTB
			// 
			this.map2OpacityTB.Location = new System.Drawing.Point(60, 102);
			this.map2OpacityTB.Name = "map2OpacityTB";
			this.map2OpacityTB.Size = new System.Drawing.Size(28, 20);
			this.map2OpacityTB.TabIndex = 23;
			this.map2OpacityTB.Text = "100";
			this.toolTip1.SetToolTip(this.map2OpacityTB, "Set the opacity that will be applied to map 2.");
			// 
			// map1OpacityTB
			// 
			this.map1OpacityTB.Location = new System.Drawing.Point(60, 28);
			this.map1OpacityTB.Name = "map1OpacityTB";
			this.map1OpacityTB.Size = new System.Drawing.Size(28, 20);
			this.map1OpacityTB.TabIndex = 22;
			this.map1OpacityTB.Text = "100";
			this.toolTip1.SetToolTip(this.map1OpacityTB, "Set the opacity that will be applied to map 1.");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 105);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 13);
			this.label2.TabIndex = 21;
			this.label2.Text = "Opacity  %";
			this.toolTip1.SetToolTip(this.label2, "Set the opacity that will be applied to map 2.");
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 20;
			this.label1.Text = "Opacity  %";
			this.toolTip1.SetToolTip(this.label1, "Set the opacity that will be applied to map 1.");
			// 
			// normalizeCB
			// 
			this.normalizeCB.AutoSize = true;
			this.normalizeCB.Checked = true;
			this.normalizeCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.normalizeCB.Location = new System.Drawing.Point(8, 151);
			this.normalizeCB.Name = "normalizeCB";
			this.normalizeCB.Size = new System.Drawing.Size(72, 17);
			this.normalizeCB.TabIndex = 19;
			this.normalizeCB.Text = "Normalize";
			this.toolTip1.SetToolTip(this.normalizeCB, "Check this if you want the values to be normalized. This means that the values wi" +
        "ll be \"recentered\" so that no points are too high or too low.");
			this.normalizeCB.UseVisualStyleBackColor = true;
			// 
			// map1TB
			// 
			this.map1TB.Location = new System.Drawing.Point(84, 5);
			this.map1TB.Name = "map1TB";
			this.map1TB.Size = new System.Drawing.Size(80, 20);
			this.map1TB.TabIndex = 15;
			// 
			// map2TB
			// 
			this.map2TB.Location = new System.Drawing.Point(84, 78);
			this.map2TB.Name = "map2TB";
			this.map2TB.Size = new System.Drawing.Size(80, 20);
			this.map2TB.TabIndex = 16;
			// 
			// loadMap2Button
			// 
			this.loadMap2Button.Location = new System.Drawing.Point(3, 76);
			this.loadMap2Button.Name = "loadMap2Button";
			this.loadMap2Button.Size = new System.Drawing.Size(75, 23);
			this.loadMap2Button.TabIndex = 14;
			this.loadMap2Button.Text = "Load Map 2";
			this.toolTip1.SetToolTip(this.loadMap2Button, "Click to load a preconfigured Map Dat File (mdf).");
			this.loadMap2Button.UseVisualStyleBackColor = true;
			this.loadMap2Button.Click += new System.EventHandler(this.loadMap2Button_Click);
			// 
			// loadMap1Button
			// 
			this.loadMap1Button.Location = new System.Drawing.Point(3, 3);
			this.loadMap1Button.Name = "loadMap1Button";
			this.loadMap1Button.Size = new System.Drawing.Size(75, 23);
			this.loadMap1Button.TabIndex = 13;
			this.loadMap1Button.Text = "Load Map 1";
			this.toolTip1.SetToolTip(this.loadMap1Button, "Click to load a preconfigured Map Dat File (mdf).");
			this.loadMap1Button.UseVisualStyleBackColor = true;
			this.loadMap1Button.Click += new System.EventHandler(this.loadMap1Button_Click);
			// 
			// colorSchemeCB
			// 
			this.colorSchemeCB.FormattingEnabled = true;
			this.colorSchemeCB.Items.AddRange(new object[] {
            "Default",
            "Sepia",
            "Black and White"});
			this.colorSchemeCB.Location = new System.Drawing.Point(9, 227);
			this.colorSchemeCB.Name = "colorSchemeCB";
			this.colorSchemeCB.Size = new System.Drawing.Size(155, 21);
			this.colorSchemeCB.TabIndex = 69;
			this.toolTip1.SetToolTip(this.colorSchemeCB, "Determines how the map will be colored in.");
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 212);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(73, 13);
			this.label3.TabIndex = 68;
			this.label3.Text = "Color Scheme";
			this.toolTip1.SetToolTip(this.label3, "Determines how the map will be colored in.");
			// 
			// clarityLabel
			// 
			this.clarityLabel.AutoSize = true;
			this.clarityLabel.Location = new System.Drawing.Point(7, 251);
			this.clarityLabel.Name = "clarityLabel";
			this.clarityLabel.Size = new System.Drawing.Size(35, 13);
			this.clarityLabel.TabIndex = 71;
			this.clarityLabel.Text = "Clarity";
			this.toolTip1.SetToolTip(this.clarityLabel, "Determines how smooth the height differences are in the map. A higher clarity mea" +
        "ns a more accurate height map.");
			// 
			// clarityTB
			// 
			this.clarityTB.Location = new System.Drawing.Point(8, 267);
			this.clarityTB.Name = "clarityTB";
			this.clarityTB.Size = new System.Drawing.Size(156, 20);
			this.clarityTB.TabIndex = 70;
			this.clarityTB.Text = "1";
			this.toolTip1.SetToolTip(this.clarityTB, "Determines how smooth the height differences are in the map. A higher clarity mea" +
        "ns a more accurate height map.");
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 172);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 13);
			this.label4.TabIndex = 72;
			this.label4.Text = "Combination Method";
			this.toolTip1.SetToolTip(this.label4, "Determines the method used to combine the maps. These can create very different o" +
        "utcomes depending on how they are used.");
			// 
			// MapCombinatorOptionPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.label4);
			this.Controls.Add(this.clarityLabel);
			this.Controls.Add(this.clarityTB);
			this.Controls.Add(this.colorSchemeCB);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.map2OpacityCB);
			this.Controls.Add(this.map1OpacityCB);
			this.Controls.Add(this.combinatorModeCB);
			this.Controls.Add(this.map2OpacityTB);
			this.Controls.Add(this.map1OpacityTB);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.normalizeCB);
			this.Controls.Add(this.map1TB);
			this.Controls.Add(this.map2TB);
			this.Controls.Add(this.loadMap2Button);
			this.Controls.Add(this.loadMap1Button);
			this.Name = "MapCombinatorOptionPanel";
			this.Size = new System.Drawing.Size(200, 441);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox map2OpacityCB;
		private System.Windows.Forms.CheckBox map1OpacityCB;
		private System.Windows.Forms.ComboBox combinatorModeCB;
		private System.Windows.Forms.TextBox map2OpacityTB;
		private System.Windows.Forms.TextBox map1OpacityTB;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox normalizeCB;
		private System.Windows.Forms.TextBox map1TB;
		private System.Windows.Forms.TextBox map2TB;
		private System.Windows.Forms.Button loadMap2Button;
		private System.Windows.Forms.Button loadMap1Button;
		private System.Windows.Forms.ComboBox colorSchemeCB;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label clarityLabel;
		private System.Windows.Forms.TextBox clarityTB;
		private System.Windows.Forms.OpenFileDialog ofd;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label label4;
	}
}
