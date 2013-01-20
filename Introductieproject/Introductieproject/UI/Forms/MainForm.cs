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

            zoomControl1.zoom += new EventHandler(zoom);
        }

        public void updateUI()  // Update elementen zonder databinding
        {
            airplaneStatsControl.update(airport);

            mapControl.airplanesDirty = true;
            mapControl.update(airport);

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
    }
}

