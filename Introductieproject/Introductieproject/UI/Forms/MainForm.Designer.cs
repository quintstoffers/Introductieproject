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
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.taxiwaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gatewaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showEfficiencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.combinedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPopupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showFlightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsSimTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsCurrentScale = new System.Windows.Forms.ToolStripStatusLabel();
            this.nuScale = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1845, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planningToolStripMenuItem});
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(109, 24);
            this.optionsToolStripMenuItem1.Text = "Management";
            // 
            // planningToolStripMenuItem
            // 
            this.planningToolStripMenuItem.Name = "planningToolStripMenuItem";
            this.planningToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.planningToolStripMenuItem.Text = "Planning";
            this.planningToolStripMenuItem.Click += new System.EventHandler(this.planningToolStripMenuItem_Click);
            // 
            // simulationToolStripMenuItem
            // 
            this.simulationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pauseToolStripMenuItem});
            this.simulationToolStripMenuItem.Name = "simulationToolStripMenuItem";
            this.simulationToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.simulationToolStripMenuItem.Text = "Simulation";
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // uIToolStripMenuItem
            // 
            this.uIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshIntervalToolStripMenuItem,
            this.mapModeToolStripMenuItem,
            this.showPopupsToolStripMenuItem,
            this.showFlightToolStripMenuItem});
            this.uIToolStripMenuItem.Name = "uIToolStripMenuItem";
            this.uIToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
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
            this.refreshIntervalToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.refreshIntervalToolStripMenuItem.Text = "Refresh interval";
            // 
            // fastestToolStripMenuItem
            // 
            this.fastestToolStripMenuItem.Name = "fastestToolStripMenuItem";
            this.fastestToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.fastestToolStripMenuItem.Text = "Fastest";
            this.fastestToolStripMenuItem.Click += new System.EventHandler(this.fastestToolStripMenuItem_Click);
            // 
            // fastToolStripMenuItem
            // 
            this.fastToolStripMenuItem.Checked = true;
            this.fastToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fastToolStripMenuItem.Name = "fastToolStripMenuItem";
            this.fastToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.fastToolStripMenuItem.Text = "Fast";
            this.fastToolStripMenuItem.Click += new System.EventHandler(this.fastToolStripMenuItem_Click);
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // slowToolStripMenuItem
            // 
            this.slowToolStripMenuItem.Name = "slowToolStripMenuItem";
            this.slowToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.slowToolStripMenuItem.Text = "Slow";
            this.slowToolStripMenuItem.Click += new System.EventHandler(this.slowToolStripMenuItem_Click);
            // 
            // slowestToolStripMenuItem
            // 
            this.slowestToolStripMenuItem.Name = "slowestToolStripMenuItem";
            this.slowestToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
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
            this.mapModeToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
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
            this.waysToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.waysToolStripMenuItem.Text = "Ways";
            // 
            // runwaysToolStripMenuItem
            // 
            this.runwaysToolStripMenuItem.Checked = true;
            this.runwaysToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.runwaysToolStripMenuItem.Name = "runwaysToolStripMenuItem";
            this.runwaysToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.runwaysToolStripMenuItem.Text = "Runways";
            this.runwaysToolStripMenuItem.Click += new System.EventHandler(this.runwaysToolStripMenuItem_Click);
            // 
            // taxiwaysToolStripMenuItem
            // 
            this.taxiwaysToolStripMenuItem.Checked = true;
            this.taxiwaysToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.taxiwaysToolStripMenuItem.Name = "taxiwaysToolStripMenuItem";
            this.taxiwaysToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.taxiwaysToolStripMenuItem.Text = "Taxiways";
            this.taxiwaysToolStripMenuItem.Click += new System.EventHandler(this.taxiwaysToolStripMenuItem_Click);
            // 
            // gatewaysToolStripMenuItem
            // 
            this.gatewaysToolStripMenuItem.Checked = true;
            this.gatewaysToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gatewaysToolStripMenuItem.Name = "gatewaysToolStripMenuItem";
            this.gatewaysToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.gatewaysToolStripMenuItem.Text = "Gateways";
            this.gatewaysToolStripMenuItem.Click += new System.EventHandler(this.gatewaysToolStripMenuItem_Click);
            // 
            // gatesToolStripMenuItem
            // 
            this.gatesToolStripMenuItem.Checked = true;
            this.gatesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gatesToolStripMenuItem.Name = "gatesToolStripMenuItem";
            this.gatesToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.gatesToolStripMenuItem.Text = "Gates";
            this.gatesToolStripMenuItem.Click += new System.EventHandler(this.gatesToolStripMenuItem_Click);
            // 
            // showEfficiencyToolStripMenuItem
            // 
            this.showEfficiencyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.offToolStripMenuItem,
            this.onToolStripMenuItem,
            this.combinedToolStripMenuItem});
            this.showEfficiencyToolStripMenuItem.Name = "showEfficiencyToolStripMenuItem";
            this.showEfficiencyToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.showEfficiencyToolStripMenuItem.Text = "Efficiency";
            // 
            // offToolStripMenuItem
            // 
            this.offToolStripMenuItem.Name = "offToolStripMenuItem";
            this.offToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.offToolStripMenuItem.Text = "Off";
            this.offToolStripMenuItem.Click += new System.EventHandler(this.offToolStripMenuItem_Click);
            // 
            // onToolStripMenuItem
            // 
            this.onToolStripMenuItem.Name = "onToolStripMenuItem";
            this.onToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.onToolStripMenuItem.Text = "On";
            this.onToolStripMenuItem.Click += new System.EventHandler(this.onToolStripMenuItem_Click);
            // 
            // combinedToolStripMenuItem
            // 
            this.combinedToolStripMenuItem.Checked = true;
            this.combinedToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.combinedToolStripMenuItem.Name = "combinedToolStripMenuItem";
            this.combinedToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.combinedToolStripMenuItem.Text = "Combined";
            this.combinedToolStripMenuItem.Click += new System.EventHandler(this.combinedToolStripMenuItem_Click);
            // 
            // showLabelsToolStripMenuItem
            // 
            this.showLabelsToolStripMenuItem.Checked = true;
            this.showLabelsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showLabelsToolStripMenuItem.Name = "showLabelsToolStripMenuItem";
            this.showLabelsToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.showLabelsToolStripMenuItem.Text = "Labels";
            this.showLabelsToolStripMenuItem.Click += new System.EventHandler(this.showLabelsToolStripMenuItem_Click);
            // 
            // showPopupsToolStripMenuItem
            // 
            this.showPopupsToolStripMenuItem.Checked = true;
            this.showPopupsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPopupsToolStripMenuItem.Name = "showPopupsToolStripMenuItem";
            this.showPopupsToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.showPopupsToolStripMenuItem.Text = "Show popups";
            this.showPopupsToolStripMenuItem.Click += new System.EventHandler(this.showPopupsToolStripMenuItem_Click);
            // 
            // showFlightToolStripMenuItem
            // 
            this.showFlightToolStripMenuItem.Name = "showFlightToolStripMenuItem";
            this.showFlightToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.showFlightToolStripMenuItem.Text = "Show flight number";
            this.showFlightToolStripMenuItem.Click += new System.EventHandler(this.showFlightToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSimTime,
            this.tsCurrentScale});
            this.statusStrip1.Location = new System.Drawing.Point(0, 733);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1845, 25);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsSimTime
            // 
            this.tsSimTime.Name = "tsSimTime";
            this.tsSimTime.Size = new System.Drawing.Size(117, 20);
            this.tsSimTime.Text = "Simulation Time";
            this.tsSimTime.Click += new System.EventHandler(this.tsSimTime_Click);
            // 
            // tsCurrentScale
            // 
            this.tsCurrentScale.Name = "tsCurrentScale";
            this.tsCurrentScale.Size = new System.Drawing.Size(94, 20);
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
            this.nuScale.Location = new System.Drawing.Point(693, 736);
            this.nuScale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.nuScale.Size = new System.Drawing.Size(63, 22);
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
            this.label1.Location = new System.Drawing.Point(592, 737);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Target scale";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mapControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.airplaneStatsControl);
            this.splitContainer1.Size = new System.Drawing.Size(1816, 702);
            this.splitContainer1.SplitterDistance = 993;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 10;
            // 
            // mapControl
            // 
            this.mapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mapControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mapControl.Location = new System.Drawing.Point(0, 0);
            this.mapControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.mapControl.Name = "mapControl";
            this.mapControl.Size = new System.Drawing.Size(993, 702);
            this.mapControl.TabIndex = 0;
            // 
            // airplaneStatsControl
            // 
            this.airplaneStatsControl.AutoSize = true;
            this.airplaneStatsControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.airplaneStatsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.airplaneStatsControl.Location = new System.Drawing.Point(0, 0);
            this.airplaneStatsControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.airplaneStatsControl.Name = "airplaneStatsControl";
            this.airplaneStatsControl.Size = new System.Drawing.Size(818, 702);
            this.airplaneStatsControl.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1845, 758);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nuScale);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem offToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem combinedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onToolStripMenuItem;
    }
}