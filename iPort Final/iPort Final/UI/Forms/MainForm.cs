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
using Introductieproject.UI.Forms;
using Introductieproject.UI.Controls;

namespace Introductieproject.Forms
{
    public partial class MainForm : Form
    {
        public Airport.Airport airport;

        public MainForm(Airport.Airport airport)
        {
            this.airport = airport;

            InitializeComponent();

            mapControl.init(airport);
            airplaneStatsControl.init(airport);

            nuScale.Value = (Decimal) TimeKeeper.targetScale;
        }

        public void updateUI()
        {
            airplaneStatsControl.update(airport);

            MapControl.airplanesDirty = true;
            if (MapControl.showEfficiency > -1)
            {
                MapControl.airportDirty = true;
            }
            mapControl.update();

            tsSimTime.Text = "Simulated time: " + TimeKeeper.currentSimTime.ToString();
            tsCurrentScale.Text = "Current scale: " + TimeKeeper.currentScale.ToString();
        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Je bent nog bezig met een Simulatie. Weet je zeker dat je wilt afsluiten?", "Waarschuwing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
            if (pauseToolStripMenuItem.Text.Equals("Pause"))
            {
                pauseToolStripMenuItem.Text = "Continue";
            }
            else
            {
                pauseToolStripMenuItem.Text = "Pause";
            }
        }

        private void nuScale_ValueChanged(object sender, EventArgs e)
        {
            TimeKeeper.targetScale = (double)nuScale.Value;
        }

        private void tsSimTime_Click(object sender, EventArgs e)
        {
            Simulation.Simulation.pauseSimulationToggle();

            DatePickerForm datePickerForm = new DatePickerForm();
            datePickerForm.FormClosed += datePickerForm_FormClosed;
            datePickerForm.ShowDialog();
        }
        private void datePickerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Simulation.Simulation.pauseSimulationToggle();
        }

        private void planningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Simulation.Simulation.pauseSimulationToggle();
            ScheduleForm scheduleForm = new ScheduleForm(airport);
            scheduleForm.loadPLanes();
            scheduleForm.Show();
        }

        private void fastestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Simulation.Simulation.uiUpdateInterval = 100;
            fastestToolStripMenuItem.Checked = true;
            fastToolStripMenuItem.Checked = false;
            normalToolStripMenuItem.Checked = false;
            slowToolStripMenuItem.Checked = false;
            slowestToolStripMenuItem.Checked = false;
        }

        private void fastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Simulation.Simulation.uiUpdateInterval = 500;
            fastestToolStripMenuItem.Checked = false;
            fastToolStripMenuItem.Checked = true;
            normalToolStripMenuItem.Checked = false;
            slowToolStripMenuItem.Checked = false;
            slowestToolStripMenuItem.Checked = false;
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Simulation.Simulation.uiUpdateInterval = 1000;
            fastestToolStripMenuItem.Checked = false;
            fastToolStripMenuItem.Checked = false;
            normalToolStripMenuItem.Checked = true;
            slowToolStripMenuItem.Checked = false;
            slowestToolStripMenuItem.Checked = false;
        }

        private void slowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Simulation.Simulation.uiUpdateInterval = 2000;
            fastestToolStripMenuItem.Checked = false;
            fastToolStripMenuItem.Checked = false;
            normalToolStripMenuItem.Checked = false;
            slowToolStripMenuItem.Checked = true;
            slowestToolStripMenuItem.Checked = false;
        }

        private void slowestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Simulation.Simulation.uiUpdateInterval = 4000;
            fastestToolStripMenuItem.Checked = false;
            fastToolStripMenuItem.Checked = false;
            normalToolStripMenuItem.Checked = false;
            slowToolStripMenuItem.Checked = false;
            slowestToolStripMenuItem.Checked = true;
        }

        private void showPopupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Simulation.Simulation.popup = !Simulation.Simulation.popup;
            showPopupsToolStripMenuItem.Checked = !Simulation.Simulation.popup;
        }

        private void showFlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapControl.alwaysShowFlight = !MapControl.alwaysShowFlight;
            showFlightToolStripMenuItem.Checked = MapControl.alwaysShowFlight;
            MapControl.airplanesDirty = true;
            mapControl.update();
        }

        private void showLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapControl.showLabels = !MapControl.showLabels;
            showLabelsToolStripMenuItem.Checked = MapControl.showLabels;
            MapControl.airportDirty = true;
            mapControl.update();
        }

        private void runwaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapControl.showRunways = !MapControl.showRunways;
            runwaysToolStripMenuItem.Checked = MapControl.showRunways;
            MapControl.airportDirty = true;
            mapControl.update();
        }

        private void taxiwaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapControl.showTaxiways = !MapControl.showTaxiways;
            taxiwaysToolStripMenuItem.Checked = MapControl.showTaxiways;
            MapControl.airportDirty = true;
            mapControl.update();
        }

        private void gatewaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapControl.showGateways = !MapControl.showGateways;
            gatewaysToolStripMenuItem.Checked = MapControl.showGateways;
            MapControl.airportDirty = true;
            mapControl.update();
        }

        private void gatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapControl.showGates = !MapControl.showGates;
            gatesToolStripMenuItem.Checked = MapControl.showGates;
            MapControl.airportDirty = true;
            mapControl.update();
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapControl.showEfficiency = -1;
            offToolStripMenuItem.Checked = true;
            onToolStripMenuItem.Checked = false;
            combinedToolStripMenuItem.Checked = false;
            MapControl.airportDirty = true;
            mapControl.update();
        }

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapControl.showEfficiency = 0;
            offToolStripMenuItem.Checked = false;
            onToolStripMenuItem.Checked = true;
            combinedToolStripMenuItem.Checked = false;
            MapControl.airportDirty = true;
            mapControl.update();
        }

        private void combinedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapControl.showEfficiency = 1;
            offToolStripMenuItem.Checked = false;
            onToolStripMenuItem.Checked = false;
            combinedToolStripMenuItem.Checked = true;
            MapControl.airportDirty = true;
            mapControl.update();
        }
    }
}

