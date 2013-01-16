using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Introductieproject.Simulation;

namespace Introductieproject.UI.Dialogs
{
    
    public partial class NewPLane : Form
    {
        Parser parser = new Parser();
        Introductieproject.Objects.Airplane airplane;
        Introductieproject.Airport.Airport airport;
        public NewPLane(Introductieproject.Objects.Airplane airplane, Introductieproject.Airport.Airport airport)
        {
            InitializeComponent();
            this.airplane = airplane;
            this.airport = airport;
            loadRunways();
        }
        private void loadRunways()
        {
            foreach (Introductieproject.Airport.Runway runway in airport.runways)
            {
                runwaybox.Items.Add(runway);
            }
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
            airplane.typeName = type.Text;
            this.Close();
            //airplane.location[0] = runwaybox.SelectedValue;
            //airplane.location[1] = double.Parse(location2.Text);
            
           
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

        }
    }
}
