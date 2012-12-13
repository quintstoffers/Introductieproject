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
        UI.Controls.timecontrol tijdcontrol = new UI.Controls.timecontrol();

        public MainForm()
        {
            InitializeComponent();
            this.Controls.Add(tijdcontrol);


        }

        private void MainForm_Load(object sender, EventArgs e)
        {

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
            Simulation.Simulation.pauseSimulation = true;
            Application.Exit();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Simulation.Simulation.runSimulation = false;
        }

        private void continueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Simulation.Simulation.pauseSimulation = false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
