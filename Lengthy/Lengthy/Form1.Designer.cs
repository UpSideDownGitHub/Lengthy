namespace Lengthy
{
    partial class mainWindow
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
            this.mainCodeEditor = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCompile = new System.Windows.Forms.ToolStripMenuItem();
            this.macrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cConverterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainCodeEditor
            // 
            this.mainCodeEditor.Location = new System.Drawing.Point(12, 27);
            this.mainCodeEditor.Multiline = true;
            this.mainCodeEditor.Name = "mainCodeEditor";
            this.mainCodeEditor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mainCodeEditor.Size = new System.Drawing.Size(776, 411);
            this.mainCodeEditor.TabIndex = 0;
            this.mainCodeEditor.WordWrap = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.runToolStripMenuItem,
            this.macrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNew,
            this.menuOpen,
            this.menuSave,
            this.menuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menuNew
            // 
            this.menuNew.Name = "menuNew";
            this.menuNew.Size = new System.Drawing.Size(224, 26);
            this.menuNew.Text = "New";
            this.menuNew.Click += new System.EventHandler(this.menuNew_Click);
            // 
            // menuOpen
            // 
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(224, 26);
            this.menuOpen.Text = "Open";
            this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
            // 
            // menuSave
            // 
            this.menuSave.Name = "menuSave";
            this.menuSave.Size = new System.Drawing.Size(224, 26);
            this.menuSave.Text = "Save";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(224, 26);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCompile});
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(48, 24);
            this.runToolStripMenuItem.Text = "Run";
            // 
            // menuCompile
            // 
            this.menuCompile.Name = "menuCompile";
            this.menuCompile.Size = new System.Drawing.Size(224, 26);
            this.menuCompile.Text = "Compile";
            this.menuCompile.Click += new System.EventHandler(this.menuCompile_Click);
            // 
            // macrosToolStripMenuItem
            // 
            this.macrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cConverterToolStripMenuItem});
            this.macrosToolStripMenuItem.Name = "macrosToolStripMenuItem";
            this.macrosToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.macrosToolStripMenuItem.Text = "Macros";
            // 
            // cConverterToolStripMenuItem
            // 
            this.cConverterToolStripMenuItem.Name = "cConverterToolStripMenuItem";
            this.cConverterToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cConverterToolStripMenuItem.Text = "C Converter";
            this.cConverterToolStripMenuItem.Click += new System.EventHandler(this.cConverterToolStripMenuItem_Click);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainCodeEditor);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainWindow";
            this.Text = "Lenghty Code";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox mainCodeEditor;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem menuNew;
        private ToolStripMenuItem menuOpen;
        private ToolStripMenuItem menuSave;
        private ToolStripMenuItem menuExit;
        private ToolStripMenuItem runToolStripMenuItem;
        private ToolStripMenuItem menuCompile;
        private ToolStripMenuItem macrosToolStripMenuItem;
        private ToolStripMenuItem cConverterToolStripMenuItem;
    }
}