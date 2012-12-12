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

        public List<Gate> gates = new List<Gate>();
        public List<Runway> runways = new List<Runway>();
        public List<Taxiway> taxiways = new List<Taxiway>();
        public List<Gateway> gateways = new List<Gateway>();

        public List<Building> buildings = new List<Building>();

        public List<Way> ways = new List<Way>();
        public List<Node> nodes = new List<Node>();

        public Airport()
        {
            Console.WriteLine("Creating airport");
        }

        public void simulate(double elapsedMillis)
        {
            foreach (Airplane currentAirplane in airplanes)
            {
                if (currentAirplane.navigator == null)       // Vliegtuig heeft nog geen navigator gekregen, ofwel net geland, of klaar om te vertrekken
                {
                    Console.WriteLine("Found airplane without navigator");
                    Navigator navigator = new Navigator(currentAirplane, ways, gates, runways);
                    currentAirplane.navigator = navigator;
                }
            }
        }
    }
}

