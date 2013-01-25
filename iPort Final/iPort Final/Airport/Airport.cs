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
        public List<Airplane> airplanes = new List<Airplane>();

        public List<Way> ways = new List<Way>();
        public List<Node> nodes = new List<Node>();

        public void simulate()
        {
            foreach (Airplane currentAirplane in airplanes)
            {
                if (currentAirplane.status == Airplane.Status.APPROACHING)
                {
                }
                else if (currentAirplane.status == Airplane.Status.TAXIING)
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
                }
                else if (currentAirplane.navigator == null)
                {
                    if (currentAirplane.status != Airplane.Status.DOCKING)
                    {
                        Navigator navigator = new Navigator(currentAirplane, ways, this);
                        currentAirplane.navigator = navigator;
                    }
                }
                if (currentAirplane.isOnAirport()) // Het updaten van de tijd dat een weg bezet is
                {
                    currentAirplane.navigator.currentWay.updateOccupancy(TimeKeeper.elapsedSimTime.Ticks);
                }
            }
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
            if (way != null)
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
                    {
                        return true;
                    }
                    if (currentAirplaneList.Count == 1)
                        if (currentAirplaneList[0].navigator.getDistanceToTargetNode(currentAirplaneList[0].location) < 700)
                            return true;                                    // Ruw, maar het werkt net zoals hiervoor
                    if (currentAirplaneList.Count == 2)
                        if (Math.Max(currentAirplaneList[0].navigator.getDistanceToTargetNode(currentAirplaneList[0].location), currentAirplaneList[0].navigator.getDistanceToTargetNode(currentAirplaneList[0].location)) < 700)
                            return true;
                    return false;
                }
                else if (!(way is Gate))
                {
                    if (!(way is Runway))
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
                    }
                    else if (way is Runway)
                    {
                        if (currentAirplaneList.Count == 0)
                            return true;
                        return false;
                    }
                }

                else if (way is Gate)
                {
                    if (currentAirplaneList.Count == 0)
                        return true;
                }

                return false;
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

        public List<Airplane> planesOnWayInDirection(Way targetway, Node startnode, Airplane source)
        {
            //Maakt een lijst aan met alle vliegtuigen die op een bepaalde weg gaan rijden, en waarbij ze in de richting rijden van startnode > andere node
            List<Airplane> returnlist = new List<Airplane>();

            foreach (Airplane airplane in airplanes)
            {
                if (source != airplane && airplane.navigator != null)
                {
                    if (airplane.navigator.hasWay(targetway))
                    {
                        Node othernode;
                        if (targetway.nodeConnections[0] == startnode)
                            othernode = targetway.nodeConnections[1];
                        else othernode = targetway.nodeConnections[0];
                        if (airplane.navigator.nodes.IndexOf(startnode) < airplane.navigator.nodes.IndexOf(othernode))
                            returnlist.Add(airplane);
                    }
                }
            }

            return returnlist;
        }

        public double getAirportOccupancy()
        {
            // Returnt de gemiddelde occupancy van alle wegen
            double occupancy = 0;
            foreach (Way way in ways)
                occupancy += way.Occupancy;
            return occupancy / ways.Count;
        }
    }
}

