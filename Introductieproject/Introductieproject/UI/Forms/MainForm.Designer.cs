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
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.planningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.continueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshIntervalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fastestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slowestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runwaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showEfficiencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPopupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showFlightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsSimTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsCurrentScale = new System.Windows.Forms.ToolStripStatusLabel();
            this.nuScale = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.taxiwaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gatewaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapControl = new Introductieproject.UI.Controls.MapControl();
            this.airplaneStatsControl = new Introductieproject.UI.Controls.AirplaneStatsControl();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem1,
            this.simulationToolStripMenuItem,
            this.uIToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1362, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planningToolStripMenuItem});
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(90, 20);
            this.optionsToolStripMenuItem1.Text = "Management";
            // 
            // planningToolStripMenuItem
            // 
            this.planningToolStripMenuItem.Name = "planningToolStripMenuItem";
            this.planningToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.planningToolStripMenuItem.Text = "Planning";
            this.planningToolStripMenuItem.Click += new System.EventHandler(this.planningToolStripMenuItem_Click);
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
            // uIToolStripMenuItem
            // 
            this.uIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshIntervalToolStripMenuItem,
            this.mapModeToolStripMenuItem,
            this.showPopupsToolStripMenuItem,
            this.showFlightToolStripMenuItem});
            this.uIToolStripMenuItem.Name = "uIToolStripMenuItem";
            this.uIToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.uIToolStripMenuItem.Text = "Interface";
            // 
            // refreshIntervalToolStripMenuItem
            // 
            this.refreshIntervalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fastestToolStripMenuItem,
            this.fastToolStripMenuItem,
            this.normalToolStripMenuItem,
            this.slowToolStripMenuItem,
            this.slowestToolStripMenuItem});
            this.refreshIntervalToolStripMenuItem.Name = "refreshIntervalToolStripMenuItem";
            this.refreshIntervalToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.refreshIntervalToolStripMenuItem.Text = "Refresh interval";
            // 
            // fastestToolStripMenuItem
            // 
            this.fastestToolStripMenuItem.Name = "fastestToolStripMenuItem";
            this.fastestToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fastestToolStripMenuItem.Text = "Fastest";
            this.fastestToolStripMenuItem.Click += new System.EventHandler(this.fastestToolStripMenuItem_Click);
            // 
            // fastToolStripMenuItem
            // 
            this.fastToolStripMenuItem.Checked = true;
            this.fastToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fastToolStripMenuItem.Name = "fastToolStripMenuItem";
            this.fastToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fastToolStripMenuItem.Text = "Fast";
            this.fastToolStripMenuItem.Click += new System.EventHandler(this.fastToolStripMenuItem_Click);
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // slowToolStripMenuItem
            // 
            this.slowToolStripMenuItem.Name = "slowToolStripMenuItem";
            this.slowToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.slowToolStripMenuItem.Text = "Slow";
            this.slowToolStripMenuItem.Click += new System.EventHandler(this.slowToolStripMenuItem_Click);
            // 
            // slowestToolStripMenuItem
            // 
            this.slowestToolStripMenuItem.Name = "slowestToolStripMenuItem";
            this.slowestToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.slowestToolStripMenuItem.Text = "Slowest";
            this.slowestToolStripMenuItem.Click += new System.EventHandler(this.slowestToolStripMenuItem_Click);
            // 
            // mapModeToolStripMenuItem
            // 
            this.mapModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.waysToolStripMenuItem,
            this.showEfficiencyToolStripMenuItem,
            this.showLabelsToolStripMenuItem});
            this.mapModeToolStripMenuItem.Name = "mapModeToolStripMenuItem";
            this.mapModeToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.mapModeToolStripMenuItem.Text = "Map";
            // 
            // waysToolStripMenuItem
            // 
            this.waysToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runwaysToolStripMenuItem,
            this.taxiwaysToolStripMenuItem,
            this.gatewaysToolStripMenuItem,
            this.gatesToolStripMenuItem});
            this.waysToolStripMenuItem.Name = "waysToolStripMenuItem";
            this.waysToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.waysToolStripMenuItem.Text = "Ways";
            // 
            // runwaysToolStripMenuItem
            // 
            this.runwaysToolStripMenuItem.Checked = true;
            this.runwaysToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.runwaysToolStripMenuItem.Name = "runwaysToolStripMenuItem";
            this.runwaysToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.runwaysToolStripMenuItem.Text = "Runways";
            this.runwaysToolStripMenuItem.Click += new System.EventHandler(this.runwaysToolStripMenuItem_Click);
            // 
            // showEfficiencyToolStripMenuItem
            // 
            this.showEfficiencyToolStripMenuItem.Checked = true;
            this.showEfficiencyToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showEfficiencyToolStripMenuItem.Name = "showEfficiencyToolStripMenuItem";
            this.showEfficiencyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showEfficiencyToolStripMenuItem.Text = "Efficiency";
            // 
            // showLabelsToolStripMenuItem
            // 
            this.showLabelsToolStripMenuItem.Checked = true;
            this.showLabelsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showLabelsToolStripMenuItem.Name = "showLabelsToolStripMenuItem";
            this.showLabelsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showLabelsToolStripMenuItem.Text = "Labels";
            this.showLabelsToolStripMenuItem.Click += new System.EventHandler(this.showLabelsToolStripMenuItem_Click);
            // 
            // showPopupsToolStripMenuItem
            // 
            this.showPopupsToolStripMenuItem.Checked = true;
            this.showPopupsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPopupsToolStripMenuItem.Name = "showPopupsToolStripMenuItem";
            this.showPopupsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.showPopupsToolStripMenuItem.Text = "Show popups";
            this.showPopupsToolStripMenuItem.Click += new System.EventHandler(this.showPopupsToolStripMenuItem_Click);
            // 
            // showFlightToolStripMenuItem
            // 
            this.showFlightToolStripMenuItem.Name = "showFlightToolStripMenuItem";
            this.showFlightToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.showFlightToolStripMenuItem.Text = "Show flight number";
            this.showFlightToolStripMenuItem.Click += new System.EventHandler(this.showFlightToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSimTime,
            this.tsCurrentScale});
            this.statusStrip1.Location = new System.Drawing.Point(0, 594);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1362, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsSimTime
            // 
            this.tsSimTime.Name = "tsSimTime";
            this.tsSimTime.Size = new System.Drawing.Size(94, 17);
            this.tsSimTime.Text = "Simulation Time";
            this.tsSimTime.Click += new System.EventHandler(this.tsSimTime_Click);
            // 
            // tsCurrentScale
            // 
            this.tsCurrentScale.Name = "tsCurrentScale";
            this.tsCurrentScale.Size = new System.Drawing.Size(76, 17);
            this.tsCurrentScale.Text = "Current scale";
            // 
            // nuScale
            // 
            this.nuScale.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.nuScale.DecimalPlaces = 1;
            this.nuScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nuScale.Location = new System.Drawing.Point(509, 598);
            this.nuScale.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nuScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nuScale.Name = "nuScale";
            this.nuScale.Size = new System.Drawing.Size(47, 20);
            this.nuScale.TabIndex = 7;
            this.nuScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nuScale.ValueChanged += new System.EventHandler(this.nuScale_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(433, 599);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Target scale";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mapControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.airplaneStatsControl);
            this.splitContainer1.Size = new System.Drawing.Size(1362, 570);
            this.splitContainer1.SplitterDistance = 454;
            this.splitContainer1.TabIndex = 10;
            // 
            // taxiwaysToolStripMenuItem
            // 
            this.taxiwaysToolStripMenuItem.Checked = true;
            this.taxiwaysToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.taxiwaysToolStripMenuItem.Name = "taxiwaysToolStripMenuItem";
            this.taxiwaysToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.taxiwaysToolStripMenuItem.Text = "Taxiways";
            this.taxiwaysToolStripMenuItem.Click += new System.EventHandler(this.taxiwaysToolStripMenuItem_Click);
            // 
            // gatewaysToolStripMenuItem
            // 
            this.gatewaysToolStripMenuItem.Checked = true;
            this.gatewaysToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gatewaysToolStripMenuItem.Name = "gatewaysToolStripMenuItem";
            this.gatewaysToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gatewaysToolStripMenuItem.Text = "Gateways";
            this.gatewaysToolStripMenuItem.Click += new System.EventHandler(this.gatewaysToolStripMenuItem_Click);
            // 
            // gatesToolStripMenuItem
            // 
            this.gatesToolStripMenuItem.Checked = true;
            this.gatesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gatesToolStripMenuItem.Name = "gatesToolStripMenuItem";
            this.gatesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gatesToolStripMenuItem.Text = "Gates";
            this.gatesToolStripMenuItem.Click += new System.EventHandler(this.gatesToolStripMenuItem_Click);
            // 
            // mapControl
            // 
            this.mapControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl.Location = new System.Drawing.Point(0, 0);
            this.mapControl.Name = "mapControl";
            this.mapControl.Size = new System.Drawing.Size(454, 570);
            this.mapControl.TabIndex = 0;
            // 
            // airplaneStatsControl
            // 
            this.airplaneStatsControl.AutoSize = true;
            this.airplaneStatsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.airplaneStatsControl.Location = new System.Drawing.Point(0, 0);
            this.airplaneStatsControl.Name = "airplaneStatsControl";
            this.airplaneStatsControl.Size = new System.Drawing.Size(904, 570);
            this.airplaneStatsControl.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 616);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nuScale);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Airport Simulator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuScale)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem simulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem continueToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsSimTime;
        private System.Windows.Forms.NumericUpDown nuScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel tsCurrentScale;
        private UI.Controls.AirplaneStatsControl airplaneStatsControl;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private UI.Controls.MapControl mapControl;
        private System.Windows.Forms.ToolStripMenuItem uIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshIntervalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fastestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slowestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPopupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showFlightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem waysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runwaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showEfficiencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLabelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taxiwaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gatewaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gatesToolStripMenuItem;
    }
}