using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Introductieproject.Simulation;
using Introductieproject.UI;

namespace Introductieproject.Forms
{
    public partial class MainForm : Form
    {
        public Airport.Airport airport;

        public MainForm(Airport.Airport airport)
        {
            this.airport = airport;

            InitializeComponent();
            zoomControl1.zoom += new EventHandler(zoom);
            mapControl.init(airport);
            airplaneStatsControl.init(airport);
            mapControl.MouseDown += new MouseEventHandler(MapControlClick);
            mapControl.MouseMove += new MouseEventHandler(MapControlMouseMove);
            mapControl.MouseUp += new MouseEventHandler(MapControlMouseUp);
        }

        public void updateUI()  // Update elementen zonder databinding
        {
            airplaneStatsControl.update(airport);
            mapControl.update(airport);

            tsSimTime.Text = "Simulated time: " + TimeKeeper.currentSimTime.ToString();
        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Je bent nog bezig met een Simulatie. Weet je zeker dat je wilt afsluiten?", "Waarschuwing", MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Simulation.Simulation.stopSimulation();
            Application.Exit();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Simulation.Simulation.pauseSimulationToggle();
        }

        private void continueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Simulation.Simulation.pauseSimulationToggle();
        }

        private void mapControl_Load(object sender, EventArgs e)
        {

        }
        private void zoom(object sender, EventArgs e)
        {
            mapControl.zoom(zoomControl1.zoomLevel);
        }


        private void MapControlClick(object sender, MouseEventArgs e)
        {
            mapControl.mouseLocation = e.Location;
        }
        private void MapControlMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mapControl.pan(mapControl.mouseLocation, e.Location, airport);
            }
        }
        private void MapControlMouseUp(object sender, MouseEventArgs e)
        {
            mapControl.lastPanlocation = mapControl.mapLocation;
        }

        private void nuScale_ValueChanged(object sender, EventArgs e)
        {
            TimeKeeper.Scale = (double) nuScale.Value;
        }
    }
}

