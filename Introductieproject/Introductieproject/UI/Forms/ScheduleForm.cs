﻿using System;
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
        Airplane selectedAirplane;

        public ScheduleForm(Airport.Airport airport)
        {
            this.airport = airport;
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(ScheduleForm_FormClosing);
            listView1.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(selectionChange);
            loadPLanes();
            listView1.Items[0].Selected = true;
        }
        public void loadPLanes()
        {
            listView1.Items.Clear();
            foreach (Airplane airplane in airport.airplanes)
            {
                ListViewItem plane = new ListViewItem(airplane.registration);
                plane.SubItems.Add(airplane.flight);
                plane.SubItems.Add(airplane.typeName);
                plane.SubItems.Add(airplane.carrier);
                plane.SubItems.Add(airplane.origin);
                plane.SubItems.Add(airplane.destination);
                plane.SubItems.Add(airplane.arrivalDate.ToString());
                plane.SubItems.Add(airplane.departureDate.ToString());
                plane.SubItems.Add(airplane.gate);
                plane.SubItems.Add(airplane.status.ToString());
                listView1.Items.Add(plane);
                if (airplane.status == Airplane.Status.CANCELLED)
                {
                    plane.Checked = true;
                    plane.ForeColor = Color.Red;
                }
            }

        }
        public void addplane()
        {
            NewPlane newPlane = new NewPlane(airplane, airport);
            newPlane.button1.Click += button1_Click;
            newPlane.ShowDialog(this);
            Parser.refreshAirplanes(airport.airplanes);
            loadPLanes();
        }

        public void editplane()
        {
            EditPlane editPlane = new EditPlane(selectedAirplane, airport);
            loadPLanes();
            listView1.Items[1].Selected = true;
            listView1.Select();
            editPlane.ShowDialog(this);
            editPlane.button1.Click += reschedule;
            Parser.refreshAirplanes(airport.airplanes);
        }

        void button1_Click(object sender, EventArgs e)
        {
            parser.writePLane(airplane);
        }

        void reschedule(object sender, EventArgs e)
        {
            Parser.refreshAirplanes(airport.airplanes);
            selectedAirplane.requestNavigator(airport);
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
            airplane.askAgain = false;
            this.Hide();
            e.Cancel = true;
            Simulation.Simulation.pauseSimulationToggle();
        }
        private void newPLaneClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("nog niet geimplementeerd");
            selectedAirplane.status = Airplane.Status.CANCELLED;
            loadPLanes();
            
        }
        private void selectionChange(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            string registration = e.Item.Text;
            foreach (Airplane ap in airport.airplanes)
            {
                if (ap.Registration == registration)
                {
                    selectedAirplane = ap;
                }
            }
        }


        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadPLanes();
        }

        private void editFlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editplane();
        }
    }
}