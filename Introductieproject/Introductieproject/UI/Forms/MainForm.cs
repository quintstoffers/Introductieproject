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
        UI.Controls.tijdcontrol tijdcontrol = new UI.Controls.tijdcontrol();
        Simulation.Simulation simulatie = new Simulation.Simulation();
        public MainForm()
        {
            InitializeComponent();
            this.Controls.Add(tijdcontrol);
            

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
