namespace MapMaker
{
	partial class PrimaryScreen
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrimaryScreen));
			this.mapImagePB = new System.Windows.Forms.PictureBox();
			this.generateButton = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveMapAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.loadSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createMapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.combineMapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printBitmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printThirdValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.cartographerOptionPanel = new CartographerOptionPanel();
			this.mapCombinatorOptionPanel = new MapCombinatorOptionPanel();
			((System.ComponentModel.ISupportInitialize)(this.mapImagePB)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mapImagePB
			// 
			this.mapImagePB.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.mapImagePB.Location = new System.Drawing.Point(220, 33);
			this.mapImagePB.Name = "mapImagePB";
			this.mapImagePB.Size = new System.Drawing.Size(480, 480);
			this.mapImagePB.TabIndex = 0;
			this.mapImagePB.TabStop = false;
			this.mapImagePB.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// generateButton
			// 
			this.generateButton.Location = new System.Drawing.Point(11, 485);
			this.generateButton.Name = "generateButton";
			this.generateButton.Size = new System.Drawing.Size(200, 28);
			this.generateButton.TabIndex = 2;
			this.generateButton.Text = "Generate";
			this.generateButton.UseVisualStyleBackColor = true;
			this.generateButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mapToolStripMenuItem,
            this.debugToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(711, 24);
			this.menuStrip1.TabIndex = 19;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.saveMapToolStripMenuItem,
            this.saveMapAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.loadSettingsToolStripMenuItem,
            this.loadMapToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.saveToolStripMenuItem.Text = "Save Settings";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.saveAsToolStripMenuItem.Text = "Save Settings As...";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// saveMapToolStripMenuItem
			// 
			this.saveMapToolStripMenuItem.Name = "saveMapToolStripMenuItem";
			this.saveMapToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.saveMapToolStripMenuItem.Text = "Save Map";
			this.saveMapToolStripMenuItem.Click += new System.EventHandler(this.saveMapToolStripMenuItem_Click);
			// 
			// saveMapAsToolStripMenuItem
			// 
			this.saveMapAsToolStripMenuItem.Name = "saveMapAsToolStripMenuItem";
			this.saveMapAsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.saveMapAsToolStripMenuItem.Text = "Save Map As...";
			this.saveMapAsToolStripMenuItem.Click += new System.EventHandler(this.saveMapAsToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
			// 
			// loadSettingsToolStripMenuItem
			// 
			this.loadSettingsToolStripMenuItem.Name = "loadSettingsToolStripMenuItem";
			this.loadSettingsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.loadSettingsToolStripMenuItem.Text = "Load Settings";
			this.loadSettingsToolStripMenuItem.Click += new System.EventHandler(this.loadSettingsToolStripMenuItem_Click);
			// 
			// loadMapToolStripMenuItem
			// 
			this.loadMapToolStripMenuItem.Name = "loadMapToolStripMenuItem";
			this.loadMapToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.loadMapToolStripMenuItem.Text = "Load Map";
			this.loadMapToolStripMenuItem.Click += new System.EventHandler(this.loadMapToolStripMenuItem_Click);
			// 
			// mapToolStripMenuItem
			// 
			this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createMapsToolStripMenuItem,
            this.combineMapsToolStripMenuItem});
			this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
			this.mapToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.mapToolStripMenuItem.Text = "Map";
			// 
			// createMapsToolStripMenuItem
			// 
			this.createMapsToolStripMenuItem.Name = "createMapsToolStripMenuItem";
			this.createMapsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.createMapsToolStripMenuItem.Text = "Create Maps";
			this.createMapsToolStripMenuItem.Click += new System.EventHandler(this.createMapsToolStripMenuItem_Click);
			// 
			// combineMapsToolStripMenuItem
			// 
			this.combineMapsToolStripMenuItem.Name = "combineMapsToolStripMenuItem";
			this.combineMapsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.combineMapsToolStripMenuItem.Text = "Combine Maps";
			this.combineMapsToolStripMenuItem.Click += new System.EventHandler(this.combineMapsToolStripMenuItem_Click);
			// 
			// debugToolStripMenuItem
			// 
			this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printBitmapToolStripMenuItem,
            this.printThirdValueToolStripMenuItem});
			this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
			this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
			this.debugToolStripMenuItem.Text = "Debug";
			// 
			// printBitmapToolStripMenuItem
			// 
			this.printBitmapToolStripMenuItem.Name = "printBitmapToolStripMenuItem";
			this.printBitmapToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.printBitmapToolStripMenuItem.Text = "Print Bitmap";
			this.printBitmapToolStripMenuItem.Click += new System.EventHandler(this.printBitmapToolStripMenuItem_Click);
			// 
			// printThirdValueToolStripMenuItem
			// 
			this.printThirdValueToolStripMenuItem.Name = "printThirdValueToolStripMenuItem";
			this.printThirdValueToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.printThirdValueToolStripMenuItem.Text = "Print Third Value";
			this.printThirdValueToolStripMenuItem.Click += new System.EventHandler(this.printThirdValueToolStripMenuItem_Click);
			// 
			// cartographerOptionPanel
			// 
			this.cartographerOptionPanel.AutoScroll = true;
			this.cartographerOptionPanel.Location = new System.Drawing.Point(11, 27);
			this.cartographerOptionPanel.Name = "cartographerOptionPanel";
			this.cartographerOptionPanel.Size = new System.Drawing.Size(200, 452);
			this.cartographerOptionPanel.TabIndex = 39;
			// 
			// mapCombinatorOptionPanel
			// 
			this.mapCombinatorOptionPanel.AutoScroll = true;
			this.mapCombinatorOptionPanel.Location = new System.Drawing.Point(11, 27);
			this.mapCombinatorOptionPanel.Name = "mapCombinatorOptionPanel";
			this.mapCombinatorOptionPanel.Size = new System.Drawing.Size(200, 452);
			this.mapCombinatorOptionPanel.TabIndex = 40;
			// 
			// PrimaryScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(711, 525);
			this.Controls.Add(this.mapCombinatorOptionPanel);
			this.Controls.Add(this.cartographerOptionPanel);
			this.Controls.Add(this.generateButton);
			this.Controls.Add(this.mapImagePB);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "PrimaryScreen";
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
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveMapToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveMapAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem combineMapsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem printBitmapToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem printThirdValueToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem loadSettingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadMapToolStripMenuItem;
		private CartographerOptionPanel cartographerOptionPanel;
		private System.Windows.Forms.ToolStripMenuItem createMapsToolStripMenuItem;
		private MapCombinatorOptionPanel mapCombinatorOptionPanel;
	}
}

