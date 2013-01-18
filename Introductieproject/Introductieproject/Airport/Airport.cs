﻿using Introductieproject.Objects;
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

        public void simulate()
        {
            foreach (Airplane currentAirplane in airplanes)
            {
                if (currentAirplane.status == Airplane.Status.APPROACHING)
                {
                    if (TimeKeeper.currentSimTime >= currentAirplane.landingDate)
                    {
                        /*
                        //TODO runway bezet ja of nee
                        if (currentAirplane.actualLandingDate == null)
                        {

                            if (!requestWayAccess(currentAirplane, currentAirplane.navigator.targetWay))
                            {
                                // Wacht een extra minuut
                                TimeSpan wait = new TimeSpan(0, 1, 0);
                                currentAirplane.actualLandingDate = TimeKeeper.currentSimTime + wait;
                            }
                        }
                        else if (TimeKeeper.currentSimTime >= currentAirplane.actualLandingDate)   // Vliegtuig is geland, maar nog niet setup
                        {
                            if (!requestWayAccess(currentAirplane, currentAirplane.navigator.targetWay))
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
                        }*/
                        if (currentAirplane.navigator == null)
                            currentAirplane.navigator = new Navigator(currentAirplane, this.ways, this);
                        if (requestWayAccess(currentAirplane, currentAirplane.navigator.currentWay, currentAirplane.navigator.getTargetNode()))
                        {
                            currentAirplane.land();
                        }
                    }
                    continue;
                }
                else if (currentAirplane.status == Airplane.Status.IDLE)
                {
                }
                else if (currentAirplane.status == Airplane.Status.DOCKING)
                {
                }
                else if (currentAirplane.status == Airplane.Status.WAITING_TAKEOFF)
                {
                }
                else if (currentAirplane.status == Airplane.Status.TAKINGOFF)
                {
                }
                else if (currentAirplane.status == Airplane.Status.DEPARTED)
                {
                    continue;   // Vliegtuig is vertrokken, niet voor ons van toepassing
                }
                else if (currentAirplane.navigator == null)
                {
                    if (currentAirplane.status != Airplane.Status.DOCKING)
                    {
                        Console.WriteLine("Found airplane without navigator");
                        Navigator navigator = new Navigator(currentAirplane, ways, this);
                        currentAirplane.navigator = navigator;
                    }
                }
                /*else if (currentAirplane.hasDocked && isOnRunway(currentAirplane)) // Als vliegtuig al bij de gate is geweest, en op de runway staat -> versnellen en opstijgen
                {
                    currentAirplane.accelerate(currentAirplane.takeofSpeed);
                    if (currentAirplane.speed == currentAirplane.takeofSpeed)
                    {
                        currentAirplane
                        Runway currentRunway = getAirplanesRunway(currentAirplane);
                        //currentRunway.resetNavigators();
                       // currentRunway.runwayHasAirplane = false;
                        airplanesTakenOff.Add(currentAirplane);
                        Program.mainForm.Invoke((Action)(() => airplanes.Remove(currentAirplane)));
                        break;
                    }
                }*/
                else if (currentAirplane.navigator != null)
                {
                    /*if (currentAirplane.navigator.wayList[0] is Taxiway && currentAirplane.navigator.targetNodeNumber == 1 && runwayTracker == 0)
                    {
                        Console.WriteLine("RUNWAYTEST!");
                    }
                    else if (currentAirplane.navigator.wayList[0] is Gate && runwayTracker == 0)
                    {
                        Console.WriteLine("RUNWAYTEST!");
                    }*/
                }
            }

            //Console.WriteLine(this.ToString());
        }

        public static bool isBetweenNodes(Way way, Node node1, Node node2)
        {
            //Als node 1 en 2 de way bevatten, dan is way een verbinding tussen de twee nodes
            if (node1.checkConnection(way) && node2.checkConnection(way))
            {
                return true;
            }
            return false;
        }

        /*
         * Resource requesters
         */
        public bool requestNavigator(Airplane airplane) // True als vliegtuig een navigator krijgt
        {
            airplane.navigator = new Navigator(airplane, this.ways, this); // En krijgt hij een nieuwe Navigator, die als het goed is een route uitrekent naar de Runway
            return true;
        }

        //Collision Detection
        //True = collision, false = geen collision
        public bool collisionDetection(Airplane airplane, Way way, Node targetNode)
        {
            foreach (Airplane collisionAirplane in airplanes)
            {
                collisionAirplane.hasCollision = false;
                if (!collisionAirplane.Equals(airplane) && collisionAirplane.isOnAirport()) // Eigen vliegtuig niet meerekenen & vliegtuig moet in bereik van Airport zijn.
                {
                    if (collisionAirplane.navigator.currentWay.Equals(way))   // Een ander vliegtuig rijdt op dit moment op de weg
                    {
                        if (collisionAirplane.navigator.currentWay.direction == 0)
                        {
                            if (targetNode == collisionAirplane.navigator.getTargetNode())
                            {
                                if (airplane.navigator.getDistanceToTargetNode(airplane.location) > collisionAirplane.navigator.getDistanceToTargetNode(collisionAirplane.location) && airplane.navigator.getDistanceToTargetNode(airplane.location) - collisionAirplane.navigator.getDistanceToTargetNode(collisionAirplane.location) < 150)
                                {
                                    airplane.hasCollision = true;
                                    Console.WriteLine("COLLISION");
                                    return true;
                                }
                            }
                        }
                        if (collisionAirplane.navigator.currentWay.direction != 0)
                        {
                            if (airplane.navigator.getDistanceToTargetNode(airplane.location) > collisionAirplane.navigator.getDistanceToTargetNode(collisionAirplane.location) && airplane.navigator.getDistanceToTargetNode(airplane.location) - collisionAirplane.navigator.getDistanceToTargetNode(collisionAirplane.location) < 150)
                            {
                                airplane.hasCollision = true;
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }



        /*
         * Permission requesters
         */
        public bool requestWayAccess(Airplane airplane, Way way, Node targetNode)
        {
            List<Airplane> currentAirplaneList = new List<Airplane>();
            foreach (Airplane currentAirplane in airplanes)                 // Alle vliegtuigen bekijken
            {
                if (!currentAirplane.Equals(airplane) && currentAirplane.isOnAirport()) // Eigen vliegtuig niet meerekenen & vliegtuig moet in bereik van Airport zijn.
                {
                        if (currentAirplane.navigator.currentWay.Equals(way))   // Een ander vliegtuig rijdt op dit moment op de weg
                        {
                            currentAirplaneList.Add(currentAirplane);
                        }
                }
            }
            
            if (way.direction != 0)
            {
                if (currentAirplaneList.Count == 0)
                    return true;
                if (currentAirplaneList.Count == 1)
                    if (currentAirplaneList[0].navigator.getDistanceToTargetNode(currentAirplaneList[0].location) < 700)
                        return true;                                    // Ruw, maar het werkt net zoals hiervoor
                if (currentAirplaneList.Count == 2)
                    if (Math.Max(currentAirplaneList[0].navigator.getDistanceToTargetNode(currentAirplaneList[0].location), currentAirplaneList[0].navigator.getDistanceToTargetNode(currentAirplaneList[0].location)) < 700)
                        return true;
                return false;
            }
            else
            {
                List<Airplane> sameNodeList = new List<Airplane>();
                foreach (Airplane currentAirplaneListAirplane in currentAirplaneList)
                {
                    if (currentAirplaneListAirplane.navigator.getTargetNode() != targetNode)
                        sameNodeList.Add(currentAirplaneListAirplane);
                }

                if (sameNodeList.Count == 0)
                    return true;
                if (sameNodeList.Count == 1)
                    if (sameNodeList[0].navigator.getDistanceToTargetNode(sameNodeList[0].location) < 700)
                        return true;
                if (sameNodeList.Count == 2)
                    if (Math.Max(sameNodeList[0].navigator.getDistanceToTargetNode(sameNodeList[0].location), sameNodeList[1].navigator.getDistanceToTargetNode(sameNodeList[1].location)) < 700)
                        return true;

                /*
                if (currentAirplaneList.Count == 0)
                    return true;
                if (currentAirplaneList.Count == 1)
                {
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode())
                    {
                        if (currentAirplaneList[0].navigator.getDistanceToTargetNode(currentAirplaneList[0].location) < 700)
                            return true;
                    }
                    else
                    {
                        return true;
                    }
                }
                if (currentAirplaneList.Count == 2)
                {
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode())
                    {
                        if (Math.Max(currentAirplaneList[0].navigator.getDistanceToTargetNode(currentAirplaneList[0].location), currentAirplaneList[1].navigator.getDistanceToTargetNode(currentAirplaneList[1].location)) < 700)
                            return true;
                    }
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode())
                    {
                        if (currentAirplaneList[1].navigator.getDistanceToTargetNode(currentAirplaneList[1].location) < 700)
                            return true;
                    }
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode())
                    {
                        if (currentAirplaneList[0].navigator.getDistanceToTargetNode(currentAirplaneList[0].location) < 700)
                            return true;
                    }
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode())
                    {
                        return true;
                    }
                }
                if (currentAirplaneList.Count == 3)
                {
                    
                    // 1 2 3 up
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode() && targetNode != currentAirplaneList[2].navigator.getTargetNode())
                    {
                        return false;
                    }
                    
                    // 1 2 up 3 down
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode() && targetNode == currentAirplaneList[2].navigator.getTargetNode())
                    {
                        if (Math.Max(currentAirplaneList[0].navigator.getDistanceToTargetNode(currentAirplaneList[0].location), currentAirplaneList[1].navigator.getDistanceToTargetNode(currentAirplaneList[1].location)) < 700)
                            return true;
                    }
                    // 1 3 up 2 down
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode() && targetNode != currentAirplaneList[2].navigator.getTargetNode())
                    {
                        if (Math.Max(currentAirplaneList[0].navigator.getDistanceToTargetNode(currentAirplaneList[0].location), currentAirplaneList[2].navigator.getDistanceToTargetNode(currentAirplaneList[2].location)) < 700)
                            return true;
                    }
                    //1 up 2 3 down
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode() && targetNode == currentAirplaneList[2].navigator.getTargetNode())
                    {
                        if (currentAirplaneList[0].navigator.getDistanceToTargetNode(currentAirplaneList[0].location) < 700)
                            return true;
                    }
                    //1 2 3 down
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode() && targetNode == currentAirplaneList[2].navigator.getTargetNode())
                    {
                        return true;
                    }
                    //1 2 down 3 up
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode() && targetNode != currentAirplaneList[2].navigator.getTargetNode())
                    {
                        if (currentAirplaneList[2].navigator.getDistanceToTargetNode(currentAirplaneList[2].location) < 700)
                            return true;
                    }
                    //1 3 down 2 up
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode() && targetNode == currentAirplaneList[2].navigator.getTargetNode())
                    {
                        if (currentAirplaneList[1].navigator.getDistanceToTargetNode(currentAirplaneList[1].location) < 700)
                            return true;
                    }
                    //1 down 2 3 up
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode() && targetNode != currentAirplaneList[2].navigator.getTargetNode())
                    {
                        if (Math.Max(currentAirplaneList[1].navigator.getDistanceToTargetNode(currentAirplaneList[1].location), currentAirplaneList[2].navigator.getDistanceToTargetNode(currentAirplaneList[2].location)) < 700)
                            return true;
                    }
                }
                if (currentAirplaneList.Count == 4)
                {
                    
                    //1 2 3 up 4 down
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode() && targetNode != currentAirplaneList[2].navigator.getTargetNode() && targetNode == currentAirplaneList[3].navigator.getTargetNode())
                    {
                        return false;
                    }
                    //1 2 4 up 3 down
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode() && targetNode == currentAirplaneList[2].navigator.getTargetNode() && targetNode != currentAirplaneList[3].navigator.getTargetNode())
                    {
                        return false;
                    }
                    //1 3 4 up 2 down
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode() && targetNode != currentAirplaneList[2].navigator.getTargetNode() && targetNode != currentAirplaneList[3].navigator.getTargetNode())
                    {
                        return false;
                    }
                    //2 3 4 up 1 down
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode() && targetNode != currentAirplaneList[2].navigator.getTargetNode() && targetNode != currentAirplaneList[3].navigator.getTargetNode())
                    {
                        return false;
                    }
                    
                    //1 2 up 3 4 down
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode() && targetNode == currentAirplaneList[2].navigator.getTargetNode() && targetNode == currentAirplaneList[3].navigator.getTargetNode())
                    {
                        if (Math.Max(currentAirplaneList[0].navigator.getDistanceToTargetNode(currentAirplaneList[0].location), currentAirplaneList[1].navigator.getDistanceToTargetNode(currentAirplaneList[1].location)) < 700)
                            return true;
                    }
                    //1 3 up 2 4 down
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode() && targetNode != currentAirplaneList[2].navigator.getTargetNode() && targetNode == currentAirplaneList[3].navigator.getTargetNode())
                    {
                        if (Math.Max(currentAirplaneList[0].navigator.getDistanceToTargetNode(currentAirplaneList[0].location), currentAirplaneList[2].navigator.getDistanceToTargetNode(currentAirplaneList[2].location)) < 700)
                            return true;
                    }
                    //1 4 up 2 3 down
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode() && targetNode == currentAirplaneList[2].navigator.getTargetNode() && targetNode != currentAirplaneList[3].navigator.getTargetNode())
                    {
                        if (Math.Max(currentAirplaneList[0].navigator.getDistanceToTargetNode(currentAirplaneList[0].location), currentAirplaneList[3].navigator.getDistanceToTargetNode(currentAirplaneList[3].location)) < 700)
                            return true;
                    }
                    //2 3 up 1 4 down
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode() && targetNode != currentAirplaneList[2].navigator.getTargetNode() && targetNode == currentAirplaneList[3].navigator.getTargetNode())
                    {
                        if (Math.Max(currentAirplaneList[1].navigator.getDistanceToTargetNode(currentAirplaneList[1].location), currentAirplaneList[2].navigator.getDistanceToTargetNode(currentAirplaneList[2].location)) < 700)
                            return true;
                    }
                    //2 4 up 1 3 down
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode() && targetNode == currentAirplaneList[2].navigator.getTargetNode() && targetNode != currentAirplaneList[3].navigator.getTargetNode())
                    {
                        if (Math.Max(currentAirplaneList[1].navigator.getDistanceToTargetNode(currentAirplaneList[1].location), currentAirplaneList[3].navigator.getDistanceToTargetNode(currentAirplaneList[3].location)) < 700)
                            return true;
                    }
                    //3 4 up 1 2 down
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode() && targetNode != currentAirplaneList[2].navigator.getTargetNode() && targetNode != currentAirplaneList[3].navigator.getTargetNode())
                    {
                        if (Math.Max(currentAirplaneList[2].navigator.getDistanceToTargetNode(currentAirplaneList[2].location), currentAirplaneList[3].navigator.getDistanceToTargetNode(currentAirplaneList[3].location)) < 700)
                            return true;
                    }
                    //4 up 1 2 3 down
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode() && targetNode == currentAirplaneList[2].navigator.getTargetNode() && targetNode != currentAirplaneList[3].navigator.getTargetNode())
                    {
                        if (currentAirplaneList[3].navigator.getDistanceToTargetNode(currentAirplaneList[3].location) < 700)
                            return true;
                    }
                    //3 up 1 2 4 down
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode() && targetNode != currentAirplaneList[2].navigator.getTargetNode() && targetNode == currentAirplaneList[3].navigator.getTargetNode())
                    {
                        if (currentAirplaneList[2].navigator.getDistanceToTargetNode(currentAirplaneList[2].location) < 700)
                            return true;
                    }
                    //2 up 1 3 4 down
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode() && targetNode == currentAirplaneList[2].navigator.getTargetNode() && targetNode == currentAirplaneList[3].navigator.getTargetNode())
                    {
                        if (currentAirplaneList[1].navigator.getDistanceToTargetNode(currentAirplaneList[1].location) < 700)
                            return true;
                    }
                    //1 up 2 3 4 down
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode() && targetNode == currentAirplaneList[2].navigator.getTargetNode() && targetNode == currentAirplaneList[3].navigator.getTargetNode())
                    {
                        if (currentAirplaneList[0].navigator.getDistanceToTargetNode(currentAirplaneList[0].location) < 700)
                            return true;
                    }
                }
                if (currentAirplaneList.Count == 5)
                {
                    
                    //1 2 3 up 4 5 down
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode() && targetNode != currentAirplaneList[2].navigator.getTargetNode() && targetNode == currentAirplaneList[3].navigator.getTargetNode() && targetNode == currentAirplaneList[4].navigator.getTargetNode())
                    {
                        return false;
                    }
                    //1 3 4 up 2 5 down
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode() && targetNode != currentAirplaneList[2].navigator.getTargetNode() && targetNode != currentAirplaneList[3].navigator.getTargetNode() && targetNode == currentAirplaneList[4].navigator.getTargetNode())
                    {
                        return false;
                    }
                    //1 4 5 up 2 3 down
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode() && targetNode == currentAirplaneList[2].navigator.getTargetNode() && targetNode != currentAirplaneList[3].navigator.getTargetNode() && targetNode != currentAirplaneList[4].navigator.getTargetNode())
                    {
                        return false;
                    }
                    //2 3 4 up 1 5 down
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode() && targetNode != currentAirplaneList[2].navigator.getTargetNode() && targetNode != currentAirplaneList[3].navigator.getTargetNode() && targetNode == currentAirplaneList[4].navigator.getTargetNode())
                    {
                        return false;
                    }
                    //3 4 5 up 1 2 down
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode() && targetNode != currentAirplaneList[2].navigator.getTargetNode() && targetNode != currentAirplaneList[3].navigator.getTargetNode() && targetNode != currentAirplaneList[4].navigator.getTargetNode())
                    {
                        return false;
                    }
                    //2 4 5 up 1 3 down
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode() && targetNode == currentAirplaneList[2].navigator.getTargetNode() && targetNode != currentAirplaneList[3].navigator.getTargetNode() && targetNode != currentAirplaneList[4].navigator.getTargetNode())
                    {
                        return false;
                    }
                    //1 2 5 up 3 4 down
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode() && targetNode == currentAirplaneList[2].navigator.getTargetNode() && targetNode == currentAirplaneList[3].navigator.getTargetNode() && targetNode != currentAirplaneList[4].navigator.getTargetNode())
                    {
                        return false;
                    }
                    //2 3 5 up 1 4 down
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode() && targetNode != currentAirplaneList[2].navigator.getTargetNode() && targetNode == currentAirplaneList[3].navigator.getTargetNode() && targetNode != currentAirplaneList[4].navigator.getTargetNode())
                    {
                        return false;
                    }
                    //1 3 5 up 2 4 down
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode() && targetNode != currentAirplaneList[2].navigator.getTargetNode() && targetNode == currentAirplaneList[3].navigator.getTargetNode() && targetNode != currentAirplaneList[4].navigator.getTargetNode())
                    {
                        return false;
                    }
                    //1 2 4 up 3 5 down
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode() && targetNode == currentAirplaneList[2].navigator.getTargetNode() && targetNode != currentAirplaneList[3].navigator.getTargetNode() && targetNode == currentAirplaneList[4].navigator.getTargetNode())
                    {
                        return false;
                    }
                    
                    //4 5 up 1 2 3 down
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode() && targetNode == currentAirplaneList[2].navigator.getTargetNode() && targetNode != currentAirplaneList[3].navigator.getTargetNode() && targetNode != currentAirplaneList[4].navigator.getTargetNode())
                    {
                        if (Math.Max(currentAirplaneList[3].navigator.getDistanceToTargetNode(currentAirplaneList[3].location), currentAirplaneList[4].navigator.getDistanceToTargetNode(currentAirplaneList[4].location)) < 700)
                            return true;
                    }
                    //2 5 up 1 3 4 down
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode() && targetNode == currentAirplaneList[2].navigator.getTargetNode() && targetNode == currentAirplaneList[3].navigator.getTargetNode() && targetNode != currentAirplaneList[4].navigator.getTargetNode())
                    {
                        if (Math.Max(currentAirplaneList[1].navigator.getDistanceToTargetNode(currentAirplaneList[1].location), currentAirplaneList[4].navigator.getDistanceToTargetNode(currentAirplaneList[4].location)) < 700)
                            return true;
                    }
                    //2 3 up 1 4 5 down
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode() && targetNode != currentAirplaneList[2].navigator.getTargetNode() && targetNode == currentAirplaneList[3].navigator.getTargetNode() && targetNode == currentAirplaneList[4].navigator.getTargetNode())
                    {
                        if (Math.Max(currentAirplaneList[1].navigator.getDistanceToTargetNode(currentAirplaneList[1].location), currentAirplaneList[2].navigator.getDistanceToTargetNode(currentAirplaneList[2].location)) < 700)
                            return true;
                    }
                    //1 5 up 2 3 4 down
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode() && targetNode == currentAirplaneList[2].navigator.getTargetNode() && targetNode == currentAirplaneList[3].navigator.getTargetNode() && targetNode != currentAirplaneList[4].navigator.getTargetNode())
                    {
                        if (Math.Max(currentAirplaneList[0].navigator.getDistanceToTargetNode(currentAirplaneList[0].location), currentAirplaneList[4].navigator.getDistanceToTargetNode(currentAirplaneList[4].location)) < 700)
                            return true;
                    }
                    //1 2 up 3 4 5 down
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode() && targetNode == currentAirplaneList[2].navigator.getTargetNode() && targetNode == currentAirplaneList[3].navigator.getTargetNode() && targetNode == currentAirplaneList[4].navigator.getTargetNode())
                    {
                        if (Math.Max(currentAirplaneList[0].navigator.getDistanceToTargetNode(currentAirplaneList[0].location), currentAirplaneList[1].navigator.getDistanceToTargetNode(currentAirplaneList[1].location)) < 700)
                            return true;
                    }
                    //1 3 up 2 4 5 down
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode() && targetNode != currentAirplaneList[2].navigator.getTargetNode() && targetNode == currentAirplaneList[3].navigator.getTargetNode() && targetNode == currentAirplaneList[4].navigator.getTargetNode())
                    {
                        if (Math.Max(currentAirplaneList[0].navigator.getDistanceToTargetNode(currentAirplaneList[0].location), currentAirplaneList[2].navigator.getDistanceToTargetNode(currentAirplaneList[2].location)) < 700)
                            return true;
                    }
                    //3 4 up 1 2 5 down
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode() && targetNode != currentAirplaneList[2].navigator.getTargetNode() && targetNode != currentAirplaneList[3].navigator.getTargetNode() && targetNode == currentAirplaneList[4].navigator.getTargetNode())
                    {
                        if (Math.Max(currentAirplaneList[2].navigator.getDistanceToTargetNode(currentAirplaneList[2].location), currentAirplaneList[3].navigator.getDistanceToTargetNode(currentAirplaneList[3].location)) < 700)
                            return true;
                    }
                    //1 4 up 2 3 5 down
                    if (targetNode != currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode() && targetNode == currentAirplaneList[2].navigator.getTargetNode() && targetNode != currentAirplaneList[3].navigator.getTargetNode() && targetNode == currentAirplaneList[4].navigator.getTargetNode())
                    {
                        if (Math.Max(currentAirplaneList[0].navigator.getDistanceToTargetNode(currentAirplaneList[0].location), currentAirplaneList[3].navigator.getDistanceToTargetNode(currentAirplaneList[3].location)) < 700)
                            return true;
                    }
                    //2 4 up 1 3 5 down
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode != currentAirplaneList[1].navigator.getTargetNode() && targetNode == currentAirplaneList[2].navigator.getTargetNode() && targetNode != currentAirplaneList[3].navigator.getTargetNode() && targetNode == currentAirplaneList[4].navigator.getTargetNode())
                    {
                        if (Math.Max(currentAirplaneList[1].navigator.getDistanceToTargetNode(currentAirplaneList[1].location), currentAirplaneList[3].navigator.getDistanceToTargetNode(currentAirplaneList[3].location)) < 700)
                            return true;
                    }
                    //3 5 up 1 2 4 down
                    if (targetNode == currentAirplaneList[0].navigator.getTargetNode() && targetNode == currentAirplaneList[1].navigator.getTargetNode() && targetNode != currentAirplaneList[2].navigator.getTargetNode() && targetNode == currentAirplaneList[3].navigator.getTargetNode() && targetNode != currentAirplaneList[4].navigator.getTargetNode())
                    {
                        if (Math.Max(currentAirplaneList[2].navigator.getDistanceToTargetNode(currentAirplaneList[2].location), currentAirplaneList[4].navigator.getDistanceToTargetNode(currentAirplaneList[4].location)) < 700)
                            return true;
                    }
                }
            */
            }  
        
            return false;
        }

        public bool requestTakeOff(Airplane airplane)
        {
            return true;
        }
        public List<Gate> occupiedGates()
        {
            List<Gate> occupiedGates = new List<Gate>();
            foreach (Airplane airplane in this.airplanes)
            {
                if (airplane.isOnAirport())
                    if (airplane.navigator.currentWay is Gate)
                        occupiedGates.Add((Gate)airplane.navigator.currentWay);
            }
            return occupiedGates;
        }
    }
}

