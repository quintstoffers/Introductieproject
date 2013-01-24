using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Introductieproject.Objects;
using Introductieproject.Airplanes;

namespace Introductieproject.UI.Controls
{
    public partial class AirplaneStatsControl : UserControl
    {
        private Airport.Airport airport;
        public static int currentSelectedRow = 0;

        public AirplaneStatsControl()
        {
            InitializeComponent(); 
        }

        public void init(Airport.Airport airport)
        {
            this.airport = airport;
        }

        public void update(Airport.Airport airport)
        {
            if (airport.airplanes.Count != dgvAirplanes.Rows.Count)
            {
                dgvAirplanes.Rows.Clear();
                dgvAirplanes.Rows.Add(airport.airplanes.Count);
            }
            for(int i = 0; i < airport.airplanes.Count; i++)
            {
                if (i == currentSelectedRow)
                {
                    dgvAirplanes.Rows[i].Selected = true;
                }
                Airplane currentAirplane = airport.airplanes[i];
                string[] columnValues = new string[]{currentAirplane.statusString, currentAirplane.Registration,
                                                     currentAirplane.PlannedArrival, currentAirplane.PlannedDeparture, currentAirplane.CurrentDelay};
                dgvAirplanes.Rows[i].SetValues(columnValues);
                dgvAirplanes.Rows[i].HeaderCell.Value = currentAirplane.flight;
                TimeSpan totalDelay = new TimeSpan();
                totalDelay = currentAirplane.delay + currentAirplane.arrivalDifference + currentAirplane.landingDifference;
                if (totalDelay.Ticks != 0)
                {
                    dgvAirplanes.Rows[i].Cells[4].Style.ForeColor = Color.Red;
                }
            }

            try
            {
                Airplane currentAirplane = airport.airplanes[currentSelectedRow];
                Navigator navi = currentAirplane.navigator;

                if (navi != null && navi.nodes != null)
                {

                    if (navi.wayList.Count != dgvNodes.Rows.Count)
                    {
                        dgvNodes.Rows.Clear();
                        dgvNodes.Rows.Add(navi.wayList.Count);
                    }

                    string completion = "100";
                    for (int i = 0; i < navi.wayPoints.Count; i++)
                    {
                        Airport.Way currentWay = navi.wayPoints[i];

                        if (currentWay.Equals(navi.currentWay))
                        {
                            dgvNodes.Rows[i].Selected = true;
                        }

                        String loc1 = currentWay.nodeConnections[0].location[0] + "," + currentWay.nodeConnections[0].location[1];
                        String loc2 = currentWay.nodeConnections[1].location[0] + "," + currentWay.nodeConnections[1].location[1];

                        string[] columnValues = new string[]{currentWay.name, "No",
                                                         completion, loc1, loc2};

                        dgvNodes.Rows[i].SetValues(columnValues);

                    }
                }
                else
                {
                    dgvNodes.Rows.Clear();
                }

                lbSpeed.Text = currentAirplane.speed.ToString();
                lbLocX.Text = Math.Round(currentAirplane.location[0]).ToString();
                lbLocY.Text = Math.Round(currentAirplane.location[1]).ToString();
                lbStatus.Text = currentAirplane.statusString;
                lbGate.Text = "Gate " + currentAirplane.gate;
                lbFlight.Text = currentAirplane.Flight;

                pnAirplane.Invalidate();
            }
            catch (ArgumentOutOfRangeException) { }

        }

        private void dataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            currentSelectedRow = e.RowIndex;
            update(airport);
        }

        private void pnAirplane_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Airplane currentAirplane = airport.airplanes[currentSelectedRow];

                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                SizeF textSize = e.Graphics.MeasureString(currentAirplane.Angle, SystemFonts.DefaultFont);
                int textWidth = (int) textSize.Width;
                int textHeight = (int) textSize.Height;


                e.Graphics.TranslateTransform(pnAirplane.Width / 2, pnAirplane.Height / 2);

                e.Graphics.DrawString(currentAirplane.Angle, SystemFonts.DefaultFont, Brushes.Black, 0 - (textWidth / 2), 0 - (textHeight / 2));


                e.Graphics.RotateTransform((float)(currentAirplane.angle + 270));
                e.Graphics.DrawEllipse(Pens.Black, -15, -15, 30, 30);
                e.Graphics.DrawLine(Pens.Black, 0, 15, 0, 60);
                e.Graphics.DrawLine(Pens.Black, 0, 60, 6, 56);
                e.Graphics.DrawLine(Pens.Black, 0, 60, -6, 56);
            }
            catch (Exception) { }
        }
    }
}
