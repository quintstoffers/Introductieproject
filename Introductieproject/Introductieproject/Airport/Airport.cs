using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Introductieproject.Simulation;

namespace Introductieproject.Airport
{
    class Airport
    {
        public List<Airplane> airplanes = new List<Airplane>();
        private List<Airplane> knownAirplanes = new List<Airplane>();
        public List<Gate> gates = new List<Gate>();
        public List<Runway> runways = new List<Runway>();
        public List<Taxiway> taxiways = new List<Taxiway>();
        public List<Gateway> gateways = new List<Gateway>();
        public List<Building> buildings = new List<Building>();

        Planner planner;

        public Airport(Planner planner)
        {
            this.planner = planner;
        }
    }
}
