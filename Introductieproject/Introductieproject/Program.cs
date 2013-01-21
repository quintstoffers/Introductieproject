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

        static void Main(string[] args)
        {
            Console.WriteLine("Program Started");
            
            Airport.Airport airport = createAirport();

            TimeKeeper.targetScale = 10;                    // Verhouding tussen real en simtime is 1, dus gelijk.
            DateTime simStartTime = new DateTime(2013, 1, 1, 22, 00, 00);
            TimeKeeper.init(simStartTime, true);            // TimeKeeper instellen op vaste starttijd

            mainForm = new MainForm(airport);
            mainForm.Show();

            Simulation.Simulation.initSimulation(airport, true);
            Simulation.Simulation.startSimulation();

            Application.Run(mainForm);
        }

        static Airport.Airport createAirport()
        {
            Airport.Airport airport = new Airport.Airport();

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

            return airport;
        }
    }
}
