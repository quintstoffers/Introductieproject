using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Introductieproject.UI.Dialogs;
using Introductieproject.Objects;
using Introductieproject.Simulation;
namespace Introductieproject.Forms
{
    public partial class ScheduleForm : Form
    {
        Airplane airplane = new Airplane();
        Parser parser = new Parser();
        Airport.Airport airport;
        string itemselected;
        public ScheduleForm(Airport.Airport airport)
        {
            this.airport = airport;
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(ScheduleForm_FormClosing);
            listView1.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(selectionChange);
            loadPLanes();
        }
        public void loadPLanes()
        {
            listView1.Items.Clear();
            foreach (Introductieproject.Objects.Airplane airplane in airport.airplanes)
            {
                ListViewItem plane = new ListViewItem(airplane.registration);
                plane.SubItems.Add(airplane.flight);
                plane.SubItems.Add(airplane.typeName);
                plane.SubItems.Add(airplane.carrier);
                plane.SubItems.Add(airplane.origin);
                plane.SubItems.Add(airplane.destination);
                plane.SubItems.Add(airplane.arrivalDate.ToString());
                plane.SubItems.Add(airplane.departureDate.ToString());
                listView1.Items.Add(plane);
                if ((int)(airplane.status) == 7)
                {
                    plane.Checked = true;
                    plane.ForeColor = Color.Red;
                }
            }
            
        }
        public void addplane()
        {
            
            NewPLane newPlane = new NewPLane(airplane, airport);
            newPlane.button1.Click += button1_Click;
            newPlane.ShowDialog(this);
            Parser.refreshAirplanes(airport.airplanes);
            loadPLanes();
        }

        void button1_Click(object sender, EventArgs e)
        {
            parser.writePLane(airplane);
            
            
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void addFlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addplane();
        }
        private void ScheduleForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
        private void newPLaneClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("nog niet geimplementeerd");
            //foreach (Airplane plane in airport.airplanes)
            //{


            //    if (plane.registration == itemselected)
            //    {
            //        plane.status = Airplane.Status.CANCELLED;
            //        loadPLanes();
            //        break;
            //    }

            //}
        }
        private void selectionChange(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            itemselected = e.Item.Text;
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadPLanes();
        }
    }
}
