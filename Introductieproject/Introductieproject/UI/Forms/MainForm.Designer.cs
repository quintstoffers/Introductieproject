namespace Introductieproject.Forms
{
    partial class MainForm
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
        public void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.airplaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.continueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.airplaneStatsControl = new Introductieproject.UI.Controls.AirplaneStatsControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.optionsToolStripMenuItem1,
            this.simulationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1370, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.airplaneToolStripMenuItem});
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem1.Text = "Options";
            // 
            // airplaneToolStripMenuItem
            // 
            this.airplaneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.planningToolStripMenuItem});
            this.airplaneToolStripMenuItem.Name = "airplaneToolStripMenuItem";
            this.airplaneToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.airplaneToolStripMenuItem.Text = "Airplane";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // planningToolStripMenuItem
            // 
            this.planningToolStripMenuItem.Name = "planningToolStripMenuItem";
            this.planningToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.planningToolStripMenuItem.Text = "Planning";
            // 
            // simulationToolStripMenuItem
            // 
            this.simulationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.continueToolStripMenuItem1,
            this.pauseToolStripMenuItem,
            this.editToolStripMenuItem});
            this.simulationToolStripMenuItem.Name = "simulationToolStripMenuItem";
            this.simulationToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.simulationToolStripMenuItem.Text = "Simulation";
            // 
            // continueToolStripMenuItem1
            // 
            this.continueToolStripMenuItem1.Name = "continueToolStripMenuItem1";
            this.continueToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.continueToolStripMenuItem1.Text = "Continue";
            this.continueToolStripMenuItem1.Click += new System.EventHandler(this.continueToolStripMenuItem1_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 347);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer1.Panel1.Controls.Add(this.airplaneStatsControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer1.Size = new System.Drawing.Size(1370, 269);
            this.splitContainer1.SplitterDistance = 455;
            this.splitContainer1.TabIndex = 3;
            // 
            // airplaneStatsControl
            // 
            this.airplaneStatsControl.AutoSize = true;
            this.airplaneStatsControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.airplaneStatsControl.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.airplaneStatsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.airplaneStatsControl.Location = new System.Drawing.Point(0, 0);
            this.airplaneStatsControl.Name = "airplaneStatsControl";
            this.airplaneStatsControl.Size = new System.Drawing.Size(455, 269);
            this.airplaneStatsControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 616);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Airport Simulator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem simulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem continueToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem airplaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planningToolStripMenuItem;
        private UI.Controls.AirplaneStatsControl airplaneStatsControl;
    }
}