using Introductieproject.Simulation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Introductieproject.UI.Forms
{
    public partial class DatePickerForm : Form
    {
        public DatePickerForm()
        {
            InitializeComponent();

            dateTimePicker.Value = TimeKeeper.currentSimTime;
            dateTimePicker.MinDate = TimeKeeper.currentSimTime;

            nmTargetLeap.Value = (Decimal) TimeKeeper.targetLeapScale;
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            TimeKeeper.targetLeapScale = (double) nmTargetLeap.Value;
            Simulation.Simulation.leapTo(dateTimePicker.Value);
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
