using System;
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

        public void init(Airport.Airport airport)
        {
            this.dgvAirplanes.DataSource = airport.airplanes;
        }

        public void update(Airport.Airport airport)
        {
            try
            {
                Airplane currentAirplane = airport.airplanes[currentSelectedRow];

                if (currentAirplane.navigator != null && currentAirplane.navigator.nodes != null)
                {
                    dgvNodes.DataSource = currentAirplane.navigator.nodes;
                    Airport.Node targetNode = currentAirplane.navigator.getTargetNode();
                    for (int i = 0; i < currentAirplane.navigator.nodes.Count; i++)
                    {
                        dgvNodes.Rows[i].Selected = false;
                        if (currentAirplane.navigator.nodes[i].Equals(targetNode))
                        {
                            dgvNodes.Rows[i].Selected = true;
                        }
                    }
                }

                lbSpeed.Text = currentAirplane.speed.ToString();
                label1.Text = Math.Round(currentAirplane.location[0]).ToString();
                label2.Text = Math.Round(currentAirplane.location[1]).ToString();
                label9.Text = Math.Round(currentAirplane.angle).ToString();
            }
            catch (ArgumentOutOfRangeException) { }

        }

        private void dataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            currentSelectedRow = e.RowIndex;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
