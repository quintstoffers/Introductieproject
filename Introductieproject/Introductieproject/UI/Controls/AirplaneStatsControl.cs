﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Introductieproject.Objects;

namespace Introductieproject.UI.Controls
{
    public partial class AirplaneStatsControl : UserControl
    {
        int currentSelectedRow = 0;

        public AirplaneStatsControl()
        {
            InitializeComponent(); 
        }

        public void setDataBinding(BindingList<Airplane> airplanes)
        {
            dataGrid.DataSource = airplanes;
        }

        public void updateAirplaneStats(BindingList<Airplane> airplanes)
        {
            try
            {
                Airplane currentAirplane = airplanes[currentSelectedRow];

                if (currentAirplane.navigator != null && currentAirplane.navigator.nodepoints != null)
                {
                    dgvNodes.DataSource = currentAirplane.navigator.nodepoints;
                }

                lbSpeed.Text = currentAirplane.speed.ToString();
                lbLocation.Text = currentAirplane.location[0] + ", " + currentAirplane.location[1];
            }
            catch (Exception) { }
        }

        private void dataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            currentSelectedRow = e.RowIndex;
        }
    }
}
