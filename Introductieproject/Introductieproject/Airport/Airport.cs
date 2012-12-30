using Introductieproject.Objects;
using Introductieproject.Simulation;
using System.Collections.Generic;
using System;
using Introductieproject.Airplanes;

namespace Introductieproject.Airport
{
    class Airport
    {
        public List<Airplane> airplanes = new List<Airplane>();

        public List<Gate> gates = new List<Gate>();             // DEZE LIJSTEN MOETEN WORDEN VERVANGEN DOOR "ways"
        public List<Runway> runways = new List<Runway>();
        public List<Taxiway> taxiways = new List<Taxiway>();
        public List<Gateway> gateways = new List<Gateway>();

        public List<Way> ways = new List<Way>();
        public List<Node> nodes = new List<Node>();

        public Airport()
        {
            Console.WriteLine("Creating airport");
        }

        private int runwayTracker;

        public void simulate()
        {
            foreach (Airplane currentAirplane in airplanes)
            {
                if (currentAirplane.navigator == null && runways[0].runwayHasAirplane == false)       // Vliegtuig heeft nog geen navigator gekregen, ofwel net geland, of klaar om te vertrekken
                {
                        runways[0].runwayHasAirplane = true;
                        Console.WriteLine("Found airplane without navigator");
                        Navigator navigator = new Navigator(currentAirplane, ways);
                        currentAirplane.navigator = navigator;
                        Console.WriteLine(airplanes.Count);
                        runwayTracker = 0;
                }
                else if (currentAirplane.navigator.wayList[0] is Taxiway && currentAirplane.navigator.currentTargetNode == 1 && runwayTracker == 0)
                {
                    runways[0].runwayHasAirplane = false;
                    runwayTracker = 1;
                    Console.WriteLine("RUNWAYTEST!");
                }
                else if (currentAirplane.navigator.wayList[0] is Gate && runwayTracker == 0)
                {
                    runways[0].runwayHasAirplane = false;
                    runwayTracker = 1;
                    Console.WriteLine("RUNWAYTEST!");
                }
            }

            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return "AIRPORT: airplanes=" + airplanes.Count;
        }

        public bool isBetweenNodes(Way way, Node node1, Node node2)
        {
            //Als node 1 en 2 de way bevatten, dan is way een verbinding tussen de twee nodes
            if (node1.checkConnection(way) && node2.checkConnection(way))
                return true;
            return false;
        }
    }
}

