using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Introductieproject.Simulation;

namespace Introductieproject.Forms
{
    public partial class MainForm : Form
    {
        public Airport.Airport airport;

        public MainForm(Airport.Airport airport)
        {
            this.airport = airport;

            InitializeComponent();

            airplaneStatsControl.setDataBinding(airport.airplanes);
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
