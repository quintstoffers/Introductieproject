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
        private static MainForm mainform = new MainForm();
        private static Airport.Airport airport;

        static void Main(string[] args)
        {
            Console.WriteLine("Program started");

            airport = createAirport();

            mainform.Show();

            DateTime simStartTime = new DateTime(2013, 1, 1, 21, 59, 50);
            TimeKeeper.initTime(simStartTime);      // TimeKeeper instellen op vaste starttijd
            TimeKeeper.scale = 2;                   // Verhouding tussen real en simtime is 1, dus gelijk.

            Simulation.Simulation.initSimulation(airport);
            Simulation.Simulation.startSimulation();

            Application.Run(mainform);
        }

        static Airport.Airport createAirport()
        {
            airport = new Airport.Airport();

            Node rwLeftNode = new Node(0, 1000);        // Beginpunt runway left
            Node rwRightNode = new Node(1000, 0);       // Eindpunt runway left
            Node txLeftNode = new Node(1000, 2000);     // Beginpunt taxiway naar runway left
            Node centerNode = new Node(2000, 1000);     // Node in het midden van het vliegveld
            Node txRightNode = new Node(3000, 2000);    // Beginpunt taxiway naar runway right
            Node gateStartNode = new Node(2000, 2000);  // Beginpunt gate
            Node gateEndNode = new Node(2000, 2100);    // Eindpunt gate

            Runway rwLeft = new Runway(rwLeftNode, rwRightNode, Way.DIRECTION_STARTTOEND);          // Runway van 100,100 naar 200,000. Richting enkel van 100,100 naar 200,000

            Taxiway txLeftBottom = new Taxiway(txLeftNode, rwLeftNode, Way.DIRECTION_STARTTOEND);   // Taxiway van 100,000 naar 100,100 in die richting. Verbonden met node van rwLeft
            Taxiway txLeftTop = new Taxiway(rwRightNode, centerNode, Way.DIRECTION_STARTTOEND);     // Taxiway vanaf eind runway left naar het midden
            Taxiway txCenterToLeft = new Taxiway(centerNode, txLeftNode, Way.DIRECTION_BOTH);       // Taxiway vanaf midden naar links onder
            Taxiway txCenterToRight = new Taxiway(centerNode, txRightNode, Way.DIRECTION_BOTH);     // Taxiway van midden naar rechts onder

            Gateway gateway1 = new Gateway(gateStartNode, txLeftNode, Way.DIRECTION_BOTH);          // Van gate naar links
            Gateway gateway2 = new Gateway(gateStartNode, txRightNode, Way.DIRECTION_BOTH);         // Van gate naar rechts

            Gate mainGate = new Gate(gateStartNode, gateEndNode, Way.DIRECTION_BOTH);               // Daadwerkelijke gate

            airport.nodes.Add(rwLeftNode);
            airport.nodes.Add(rwRightNode);
            airport.nodes.Add(txLeftNode);
            airport.nodes.Add(centerNode);
            airport.nodes.Add(txRightNode);
            airport.nodes.Add(gateStartNode);
            airport.nodes.Add(gateEndNode);

            airport.gateways.Add(gateway1);
            airport.gateways.Add(gateway2);

            airport.gates.Add(mainGate);

            airport.taxiways.Add(txLeftBottom);
            airport.taxiways.Add(txLeftTop);
            airport.taxiways.Add(txCenterToLeft);
            airport.taxiways.Add(txCenterToRight);

            airport.runways.Add(rwLeft);

            airport.ways.Add(rwLeft);
            airport.ways.Add(txLeftBottom);
            airport.ways.Add(txLeftTop);
            airport.ways.Add(txCenterToLeft);
            airport.ways.Add(txCenterToRight);
            airport.ways.Add(mainGate);
            airport.ways.Add(gateway1);
            airport.ways.Add(gateway2);

            return airport;
        }
    }
}
