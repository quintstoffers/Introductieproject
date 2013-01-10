using Introductieproject.Objects;
using Introductieproject.Simulation;
using System.Collections.Generic;
using System;
using Introductieproject.Airplanes;
using System.ComponentModel;

namespace Introductieproject.Airport
{
    public class Airport
    {
        public BindingList<Airplane> airplanes = new BindingList<Airplane>();
        public List<Airplane> airplanesTakenOff = new List<Airplane>();

        public List<Gate> gates = new List<Gate>();
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
                if (!currentAirplane.wasSetup)
                {
                    Console.WriteLine("NOT SETUP");
                    Console.WriteLine("ARRIVE : " + currentAirplane.landingDate);
                    Console.WriteLine("ARRIVE2: " + currentAirplane.actualLandingDate);
                    Console.WriteLine("CURR:   " + TimeKeeper.currentSimTime);
                    if (TimeKeeper.currentSimTime >= currentAirplane.landingDate)
                    {
                        if(currentAirplane.actualLandingDate == null)
                        {
                            if (runways[0].runwayHasAirplane)
                            {
                                // Wacht een extra minuut
                                TimeSpan wait = new TimeSpan(0, 1, 0);
                                currentAirplane.actualLandingDate = TimeKeeper.currentSimTime + wait;
                            }
                        }
                        else if (TimeKeeper.currentSimTime >= currentAirplane.actualLandingDate)   // Vliegtuig is geland, maar nog niet setup
                        {
                            if (runways[0].runwayHasAirplane)
                            {
                                // Wacht een extra 30 seconden.
                                TimeSpan wait = new TimeSpan(0, 1, 0);
                                currentAirplane.actualLandingDate = TimeKeeper.currentSimTime + wait;
                            }
                            else
                            {
                                Console.WriteLine("New airplane landed (" + currentAirplane.Registration + ")");
                                currentAirplane.land();
                            }
                        }
                    }
                    continue;
                }
                else if (currentAirplane.status == Airplane.Status.DOCKING && TimeKeeper.currentSimTime >= currentAirplane.actualDepartureDate) // Als een vliegtuig bij een gate geparkeerd staat en het tijd is om te vertrekken
                {
                    currentAirplane.leaveDock();
                }
                else if (currentAirplane.navigator == null)       // Vliegtuig heeft nog geen navigator gekregen, ofwel net geland, of klaar om te vertrekken
                {
                    if (currentAirplane.status != Airplane.Status.DOCKING)
                    {
                        Console.WriteLine("Found airplane without navigator");
                        Navigator navigator = new Navigator(currentAirplane, ways);
                        currentAirplane.navigator = navigator;
                        runwayTracker = 0;
                    }
                }
                else if (currentAirplane.hasDocked && isOnRunway(currentAirplane)) // Als vliegtuig al bij de gate is geweest, en op de runway staat -> versnellen en opstijgen
                {
                    currentAirplane.accelerate(currentAirplane.takeofSpeed);
                    if (currentAirplane.speed == currentAirplane.takeofSpeed)
                    {
                        currentAirplane.takeOff = true;
                        Runway currentRunway = getAirplanesRunway(currentAirplane);
                        currentRunway.resetNavigators();
                        currentRunway.runwayHasAirplane = false;
                        airplanesTakenOff.Add(currentAirplane);
                        Program.mainForm.Invoke((Action)(() => airplanes.Remove(currentAirplane)));
                        break;
                    }
                }
                else if (currentAirplane.navigator != null)
                {
                    if (currentAirplane.navigator.wayList[0] is Taxiway && currentAirplane.navigator.currentTargetNode == 1 && runwayTracker == 0)
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
            }

            //Console.WriteLine(this.ToString());
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

        public bool isOnRunway(Airplane airplane)
        {
            foreach (Runway runway in this.runways)
            {
                if (runway.navigatorList.Contains(airplane.navigator))
                    return true;
            }
            return false;
        }

        public Runway getAirplanesRunway(Airplane airplane)
        {
            foreach (Runway runway in this.runways)
            {
                if (runway.navigatorList.Contains(airplane.navigator))
                    return runway;
            }
            return null;
        }


        /*
         * Requesters
         */
        public bool requestNavigator(Airplane airplane) // True als vliegtuig een navigator krijgt
        {
            airplane.navigator = new Navigator(airplane, this.ways); // En krijgt hij een nieuwe Navigator, die als het goed is een route uitrekent naar de Runway
            return true;
        }

        /*
         * Permission requesters
         */
        public bool canTakeOff(Airplane airplane)
        {
            return true;
        }
    }
}

