namespace ChordQuality.controls
{
    partial class MainMenuControl
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
            if(disposing && (components != null))
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuOpenItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSaveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.fileMenuInfoItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fileMenuPrintPreviewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuPrintItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuMidiToTextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fileMenuExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markersMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.markersMenuAddMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.markersMenuRemoveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisMenuFindBestTuningItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisMenuExportAnalysisItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.markersMenu,
            this.analysisMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(168, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "mainMenu";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuOpenItem,
            this.fileMenuSaveItem,
            this.toolStripSeparator3,
            this.fileMenuInfoItem,
            this.toolStripSeparator2,
            this.fileMenuPrintPreviewItem,
            this.fileMenuPrintItem,
            this.fileMenuMidiToTextItem,
            this.toolStripSeparator1,
            this.fileMenuExitItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // fileMenuOpenItem
            // 
            this.fileMenuOpenItem.Name = "fileMenuOpenItem";
            this.fileMenuOpenItem.Size = new System.Drawing.Size(143, 22);
            this.fileMenuOpenItem.Text = "Open";
            this.fileMenuOpenItem.Click += new System.EventHandler(this.fileMenuOpenItem_Click);
            // 
            // fileMenuSaveItem
            // 
            this.fileMenuSaveItem.Enabled = false;
            this.fileMenuSaveItem.Name = "fileMenuSaveItem";
            this.fileMenuSaveItem.Size = new System.Drawing.Size(143, 22);
            this.fileMenuSaveItem.Text = "Save";
            this.fileMenuSaveItem.Click += new System.EventHandler(this.fileMenuSaveItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(140, 6);
            // 
            // fileMenuInfoItem
            // 
            this.fileMenuInfoItem.Enabled = false;
            this.fileMenuInfoItem.Name = "fileMenuInfoItem";
            this.fileMenuInfoItem.Size = new System.Drawing.Size(143, 22);
            this.fileMenuInfoItem.Text = "Info";
            this.fileMenuInfoItem.Click += new System.EventHandler(this.fileMenuInfoItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(140, 6);
            // 
            // fileMenuPrintPreviewItem
            // 
            this.fileMenuPrintPreviewItem.Enabled = false;
            this.fileMenuPrintPreviewItem.Name = "fileMenuPrintPreviewItem";
            this.fileMenuPrintPreviewItem.Size = new System.Drawing.Size(143, 22);
            this.fileMenuPrintPreviewItem.Text = "Print Preview";
            this.fileMenuPrintPreviewItem.Click += new System.EventHandler(this.fileMenuPrintPreviewItem_Click);
            // 
            // fileMenuPrintItem
            // 
            this.fileMenuPrintItem.Enabled = false;
            this.fileMenuPrintItem.Name = "fileMenuPrintItem";
            this.fileMenuPrintItem.Size = new System.Drawing.Size(143, 22);
            this.fileMenuPrintItem.Text = "Print";
            this.fileMenuPrintItem.Click += new System.EventHandler(this.fileMenuPrintItem_Click);
            // 
            // fileMenuMidiToTextItem
            // 
            this.fileMenuMidiToTextItem.Enabled = false;
            this.fileMenuMidiToTextItem.Name = "fileMenuMidiToTextItem";
            this.fileMenuMidiToTextItem.Size = new System.Drawing.Size(143, 22);
            this.fileMenuMidiToTextItem.Text = "MIDI to Text";
            this.fileMenuMidiToTextItem.Click += new System.EventHandler(this.fileMenuMidiToTextItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // fileMenuExitItem
            // 
            this.fileMenuExitItem.Name = "fileMenuExitItem";
            this.fileMenuExitItem.Size = new System.Drawing.Size(143, 22);
            this.fileMenuExitItem.Text = "Exit";
            this.fileMenuExitItem.Click += new System.EventHandler(this.fileMenuExitItem_Click);
            // 
            // markersMenu
            // 
            this.markersMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markersMenuAddMenu,
            this.markersMenuRemoveMenu});
            this.markersMenu.Enabled = false;
            this.markersMenu.Name = "markersMenu";
            this.markersMenu.Size = new System.Drawing.Size(61, 20);
            this.markersMenu.Text = "Markers";
            // 
            // markersMenuAddMenu
            // 
            this.markersMenuAddMenu.Name = "markersMenuAddMenu";
            this.markersMenuAddMenu.Size = new System.Drawing.Size(117, 22);
            this.markersMenuAddMenu.Text = "Add";
            // 
            // markersMenuRemoveMenu
            // 
            this.markersMenuRemoveMenu.Name = "markersMenuRemoveMenu";
            this.markersMenuRemoveMenu.Size = new System.Drawing.Size(117, 22);
            this.markersMenuRemoveMenu.Text = "Remove";
            // 
            // analysisMenu
            // 
            this.analysisMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analysisMenuFindBestTuningItem,
            this.analysisMenuExportAnalysisItem});
            this.analysisMenu.Enabled = false;
            this.analysisMenu.Name = "analysisMenu";
            this.analysisMenu.Size = new System.Drawing.Size(62, 20);
            this.analysisMenu.Text = "Analysis";
            // 
            // analysisMenuFindBestTuningItem
            // 
            this.analysisMenuFindBestTuningItem.Name = "analysisMenuFindBestTuningItem";
            this.analysisMenuFindBestTuningItem.Size = new System.Drawing.Size(163, 22);
            this.analysisMenuFindBestTuningItem.Text = "Find Best Tuning";
            this.analysisMenuFindBestTuningItem.Click += new System.EventHandler(this.analysisMenuFindBestTuningItem_Click);
            // 
            // analysisMenuExportAnalysisItem
            // 
            this.analysisMenuExportAnalysisItem.Name = "analysisMenuExportAnalysisItem";
            this.analysisMenuExportAnalysisItem.Size = new System.Drawing.Size(163, 22);
            this.analysisMenuExportAnalysisItem.Text = "Export Analysis";
            this.analysisMenuExportAnalysisItem.Click += new System.EventHandler(this.analysisMenuExportAnalysisItem_Click);
            // 
            // MainMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.MainMenu);
            this.Name = "MainMenuControl";
            this.Size = new System.Drawing.Size(168, 24);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem markersMenu;
        private System.Windows.Forms.ToolStripMenuItem analysisMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenuOpenItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenuSaveItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenuPrintPreviewItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenuPrintItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem fileMenuMidiToTextItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuExitItem;
        private System.Windows.Forms.ToolStripMenuItem markersMenuAddMenu;
        private System.Windows.Forms.ToolStripMenuItem markersMenuRemoveMenu;
        private System.Windows.Forms.ToolStripMenuItem analysisMenuFindBestTuningItem;
        private System.Windows.Forms.ToolStripMenuItem analysisMenuExportAnalysisItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem fileMenuInfoItem;
    }
}
