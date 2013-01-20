using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Introductieproject.Simulation;
using Introductieproject.Forms;

namespace Introductieproject.UI.Dialogs
{

    public partial class NewPlane : Form
    {
        Parser parser = new Parser();
        Introductieproject.Objects.Airplane airplane;
        Introductieproject.Airport.Airport airport;
        Airport.Runway selectedRunway;
        Airport.Gate selectedGate;
        ScheduleForm sch;

        public NewPlane(Introductieproject.Objects.Airplane airplane, Introductieproject.Airport.Airport airport, ScheduleForm sch)
        {
            InitializeComponent();
            this.airplane = airplane;
            this.airport = airport;
            this.sch = sch;
            loadRunways();
            loadGates();
            loadTypes();
            arrivaldate.CustomFormat = "dd/MM/yyyy HH:mm";
            departuredate.CustomFormat = "dd/MM/yyyy HH:mm";
            landing.CustomFormat = "dd/MM/yyyy HH:mm";
        }
        private void loadRunways()
        {
            foreach (Introductieproject.Airport.Runway runway in airport.runways)
            {
                runwaybox.Items.Add(runway.name);
                runwaybox.SelectedItem = runwaybox.Items[0];
            }
        }
        private void loadGates()
        {
            foreach (Introductieproject.Airport.Gate gate in airport.gates)
            {
                gateBox.Items.Add(gate.name);
                gateBox.SelectedItem = gateBox.Items[0];
            }
        }
        private void loadTypes()
        {
            typeBox.Items.Add("BO_747");
            typeBox.SelectedItem = typeBox.Items[0];
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            airplane.registration = registration.Text;
            airplane.carrier = carrier.Text;
            airplane.flight = flight.Text;
            airplane.origin = origin.Text;
            airplane.destination = destination.Text;
            airplane.departureDate = departuredate.Value;
            airplane.arrivalDate = arrivaldate.Value;
            airplane.landingDate = landing.Value;
            airplane.typeName = typeBox.SelectedItem.ToString();
            airplane.location = selectedRunway.nodeConnections[0].location;
            airplane.gate = selectedGate.ToString();
            sch.loadPLanes();
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void carrier_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Introductieproject.Airport.Runway runway in airport.runways)
            {
                if (runway.name == runwaybox.SelectedItem.ToString())
                    selectedRunway = runway;
            }
        }

        private void gateBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Introductieproject.Airport.Gate gate in airport.gates)
            {
                if (gate.name == gateBox.SelectedItem.ToString())
                    selectedGate = gate;
            }
        }

        private void typeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void arrivaldate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void departuredate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void landing_ValueChanged(object sender, EventArgs e)
        {

        }

        private void landingdate_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}