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

        public void simulate()
        {
            checkWays();
            //
            //For testing purposes: Als het eerste vliegtuig van de runway is, spawn een tweede vliegtuig
            //Momenteel buggy: Utils.isPointInWay is erg precies. Letterlijk foutmarge van 0 mogelijk momenteel
            if (airplanes.Count == 0)
            {
                int clearRoads = 0;
                foreach (Way w in this.runways)
                {
                    if (!w.hasAirplane)
                        clearRoads++;
                }
                Console.WriteLine("Clear roads: " + clearRoads);
                if (clearRoads == runways.Count)
                {
                    airplanes.Add(createAirplane());
                    Console.WriteLine("Airplane created!");
                }
            }

            foreach (Airplane currentAirplane in airplanes)
            {
                if (currentAirplane.navigator == null)       // Vliegtuig heeft nog geen navigator gekregen, ofwel net geland, of klaar om te vertrekken
                {
                    Console.WriteLine("Found airplane without navigator");
                    Navigator navigator = new Navigator(currentAirplane, ways);
                    currentAirplane.navigator = navigator;
                    Console.WriteLine(airplanes.Count);
                }
            }
        }

        public override string ToString()
        {
            return "AIRPORT: airplanes=" + airplanes.Count;
        }

        static Airplane createAirplane()
        {
            Airplane newAirPlane = new Airplane();
            newAirPlane.initVariables(new double[] { 500, 500 }, 0, 315, new KLM(), 0, 200, 220, 4400);    // Nieuw vliegtuig op einde linker landingsbaan zonder snelheid en richting het noorden gericht
            return newAirPlane;
        }

        public void checkWays()
        {
            //Methode om te kijken of een way bezet is of niet
            //Eerste methode, inefficient maar makkelijk en snel geschreven
            foreach (Way w in this.ways)
            {
                w.airplane = null;
                w.hasAirplane = false;
            }
            foreach (Airplane a in this.airplanes)
            {
                foreach (Way w in this.ways)
                {
                    if (Utils.isPointInWay(a.location, w))
                    {
                        w.navigatorList.Add(a.navigator);
                        w.hasAirplane = true;
                    }
                }
            }
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

