namespace MapMaker
{
    partial class ColorSchemeMaker
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveSchemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveSchemeAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadSchemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.colorSchemeRangePB = new System.Windows.Forms.PictureBox();
			this.sampleMapPB = new System.Windows.Forms.PictureBox();
			this.colorRangePanelArrayPanel = new System.Windows.Forms.Panel();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.colorSchemeRangePB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sampleMapPB)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(943, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSchemeToolStripMenuItem,
            this.saveSchemeAsToolStripMenuItem,
            this.loadSchemeToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// saveSchemeToolStripMenuItem
			// 
			this.saveSchemeToolStripMenuItem.Name = "saveSchemeToolStripMenuItem";
			this.saveSchemeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.saveSchemeToolStripMenuItem.Text = "Save Scheme";
			this.saveSchemeToolStripMenuItem.Click += new System.EventHandler(this.saveSchemeToolStripMenuItem_Click);
			// 
			// saveSchemeAsToolStripMenuItem
			// 
			this.saveSchemeAsToolStripMenuItem.Name = "saveSchemeAsToolStripMenuItem";
			this.saveSchemeAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.saveSchemeAsToolStripMenuItem.Text = "Save Scheme As";
			this.saveSchemeAsToolStripMenuItem.Click += new System.EventHandler(this.saveSchemeAsToolStripMenuItem_Click);
			// 
			// loadSchemeToolStripMenuItem
			// 
			this.loadSchemeToolStripMenuItem.Name = "loadSchemeToolStripMenuItem";
			this.loadSchemeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.loadSchemeToolStripMenuItem.Text = "Load Scheme";
			this.loadSchemeToolStripMenuItem.Click += new System.EventHandler(this.loadSchemeToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// colorSchemeRangePB
			// 
			this.colorSchemeRangePB.Location = new System.Drawing.Point(451, 27);
			this.colorSchemeRangePB.Name = "colorSchemeRangePB";
			this.colorSchemeRangePB.Size = new System.Drawing.Size(480, 50);
			this.colorSchemeRangePB.TabIndex = 1;
			this.colorSchemeRangePB.TabStop = false;
			// 
			// sampleMapPB
			// 
			this.sampleMapPB.Location = new System.Drawing.Point(451, 83);
			this.sampleMapPB.Name = "sampleMapPB";
			this.sampleMapPB.Size = new System.Drawing.Size(480, 480);
			this.sampleMapPB.TabIndex = 2;
			this.sampleMapPB.TabStop = false;
			// 
			// colorRangePanelArrayPanel
			// 
			this.colorRangePanelArrayPanel.Location = new System.Drawing.Point(12, 27);
			this.colorRangePanelArrayPanel.Name = "colorRangePanelArrayPanel";
			this.colorRangePanelArrayPanel.Size = new System.Drawing.Size(433, 536);
			this.colorRangePanelArrayPanel.TabIndex = 3;
			// 
			// ColorSchemeMaker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(943, 574);
			this.Controls.Add(this.colorRangePanelArrayPanel);
			this.Controls.Add(this.sampleMapPB);
			this.Controls.Add(this.colorSchemeRangePB);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "ColorSchemeMaker";
			this.Text = "ColorSchemeMaker";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.colorSchemeRangePB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sampleMapPB)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveSchemeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveSchemeAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadSchemeToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.PictureBox colorSchemeRangePB;
		private System.Windows.Forms.PictureBox sampleMapPB;
		private System.Windows.Forms.Panel colorRangePanelArrayPanel;
	}
}