namespace Project
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.tsmFindPath = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDisplayGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.setRowsAndColsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbRows = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbCols = new System.Windows.Forms.ToolStripTextBox();
            this.tsmReset = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSetPercentage = new System.Windows.Forms.ToolStripMenuItem();
            this.cbPercentage = new System.Windows.Forms.ToolStripComboBox();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFindPath,
            this.tsmDisplayGrid,
            this.setRowsAndColsToolStripMenuItem,
            this.tsmReset,
            this.tsmSetPercentage});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(699, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // tsmFindPath
            // 
            this.tsmFindPath.Name = "tsmFindPath";
            this.tsmFindPath.Size = new System.Drawing.Size(69, 20);
            this.tsmFindPath.Text = "Find path";
            this.tsmFindPath.Click += new System.EventHandler(this.tsmFindPath_Click);
            // 
            // tsmDisplayGrid
            // 
            this.tsmDisplayGrid.Name = "tsmDisplayGrid";
            this.tsmDisplayGrid.Size = new System.Drawing.Size(81, 20);
            this.tsmDisplayGrid.Text = "Display grid";
            this.tsmDisplayGrid.Click += new System.EventHandler(this.tsmDisplayGrid_Click);
            // 
            // setRowsAndColsToolStripMenuItem
            // 
            this.setRowsAndColsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.setRowsAndColsToolStripMenuItem.Name = "setRowsAndColsToolStripMenuItem";
            this.setRowsAndColsToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.setRowsAndColsToolStripMenuItem.Text = "Set rows and cols";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbRows});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem1.Text = "Rows";
            // 
            // tbRows
            // 
            this.tbRows.Name = "tbRows";
            this.tbRows.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbCols});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem2.Text = "Cols";
            // 
            // tbCols
            // 
            this.tbCols.Name = "tbCols";
            this.tbCols.Size = new System.Drawing.Size(100, 23);
            // 
            // tsmReset
            // 
            this.tsmReset.Name = "tsmReset";
            this.tsmReset.Size = new System.Drawing.Size(47, 20);
            this.tsmReset.Text = "Reset";
            this.tsmReset.Click += new System.EventHandler(this.tsmReset_Click);
            // 
            // tsmSetPercentage
            // 
            this.tsmSetPercentage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbPercentage});
            this.tsmSetPercentage.Name = "tsmSetPercentage";
            this.tsmSetPercentage.Size = new System.Drawing.Size(144, 20);
            this.tsmSetPercentage.Text = "Set obstacle percentage";
            // 
            // cbPercentage
            // 
            this.cbPercentage.Items.AddRange(new object[] {
            "0",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.cbPercentage.Name = "cbPercentage";
            this.cbPercentage.Size = new System.Drawing.Size(121, 23);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(699, 736);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "MainForm";
            this.Text = "A star";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem dsfdsfToolStripMenuItem;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem tsmFindPath;
        private ToolStripMenuItem setRowsAndColsToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripTextBox tbRows;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripTextBox tbCols;
        private ToolStripMenuItem tsmReset;
        private ToolStripMenuItem tsmDisplayGrid;
        private ToolStripMenuItem tsmSetPercentage;
        private ToolStripComboBox cbPercentage;
    }
}