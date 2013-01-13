using Introductieproject.Airport;
using Introductieproject.Forms;
using Introductieproject.Objects;
using Introductieproject.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Introductieproject
{
    class Program
    {
        public static MainForm mainForm;
        private static Airport.Airport airport;
        

        static void Main(string[] args)
        {
            Console.WriteLine("Program started");
            
            airport = createAirport();

            DateTime simStartTime = new DateTime(2013, 1, 1, 21, 59, 55);
            TimeKeeper.init(simStartTime, true);      // TimeKeeper instellen op vaste starttijd
            TimeKeeper.Scale = 10;                   // Verhouding tussen real en simtime is 1, dus gelijk.

            mainForm = new MainForm(airport);
            mainForm.Show();

            Simulation.Simulation.initSimulation(airport);
            Simulation.Simulation.startSimulation();

            Application.Run(mainForm);
        }

        static Airport.Airport createAirport()
        {
            airport = new Airport.Airport();
            Parser parser = new Parser();
            List<Taxiway> taxiWayList = new List<Taxiway>();
            List<Runway> runWayList = new List<Runway>();
            List<Gateway> gateWayList = new List<Gateway>();
            List<Gate> gateList = new List<Gate>();
            List<Node> nodeList= new List<Node>();
            parser.getWays(nodeList, runWayList, taxiWayList, gateWayList, gateList);

            airport.ways.AddRange(runWayList);
            airport.ways.AddRange(gateList);
            airport.ways.AddRange(gateWayList);
            airport.ways.AddRange(taxiWayList);
            airport.nodes.AddRange(nodeList);
            airport.taxiways.AddRange(taxiWayList);
            airport.runways.AddRange(runWayList);
            airport.gateways.AddRange(gateWayList);
            airport.gates.AddRange(gateList);

            return airport;
        }
    }
}
