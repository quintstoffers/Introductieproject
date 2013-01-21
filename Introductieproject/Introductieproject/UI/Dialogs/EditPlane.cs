using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Introductieproject.Simulation;
using Introductieproject.Airport;
using Introductieproject.Objects;
using Introductieproject.Forms;

namespace Introductieproject.UI.Dialogs
{
    public partial class EditPlane : Form
    {
        Parser parser = new Parser();
        Airplane airplane;
        Introductieproject.Airport.Airport airport;
        ScheduleForm sch;

        public EditPlane(Introductieproject.Objects.Airplane airplane, Introductieproject.Airport.Airport airport, ScheduleForm sch)
        {
            InitializeComponent();
            this.airplane = airplane;
            this.airport = airport;
            this.sch = sch;
            loadGates();
            loadAirplane();
        }

        private void loadGates()
        {
            foreach(Way way in airport.ways)
            {
                if(way is Gate)
                {
                    gateBox.Items.Add(way.name);
                    gateBox.Sorted = true;
                }
            }
            gateBox.SelectedItem = gateBox.Items[0];

            foreach (Airplane ap in airport.airplanes)
            {
                if (ap.status == Airplane.Status.DOCKING)
                {
                    gateBox.Items.Remove(ap.gate);
                }
            }
        }

        private void loadAirplane()
        {
            try
            {
                registration.Text = airplane.registration;
                carrier.Text = airplane.carrier;
                flight.Text = airplane.Flight;
                origin.Text = airplane.origin;
                destination.Text = airplane.destination;
            }
            catch (NullReferenceException) 
            {
                DialogResult diag = MessageBox.Show("Selecteer a.u.b. een vliegtuig");
                this.Close();
            }
        }

        private void gateBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            airplane.registration = registration.Text;
            airplane.carrier = carrier.Text;
            airplane.flight = flight.Text;
            airplane.origin = origin.Text;
            airplane.destination = destination.Text;
            airplane.departureDate = departuredate.Value;
            airplane.gate = gateBox.SelectedItem.ToString();
            airplane.requestNavigator(airport);
            sch.loadPLanes();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
