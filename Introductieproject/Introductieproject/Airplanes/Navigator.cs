﻿using Introductieproject.Airport;
using Introductieproject.Objects;
using Introductieproject.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Airplanes
{
    public class Navigator
    {
        public IList<Node> nodes;      // De lijst met toekomstige nodepoints voor het vliegtuig
        public IList<Way> wayPoints;        // De lijst met toekomstige waypoints voor het vliegtuig
        public IList<Way> wayList = new List<Way>();
        public int targetNodeNumber = 0;

        public Way currentWay;
        public Way targetWay;

        public double[] location;
        
        public Navigator(Airplane airplane, List<Way> ways, Airport.Airport airport)
        {
            newRoute(airplane, ways, airport);
        }

        public void newRoute(Airplane airplane, List<Way> ways, Airport.Airport airport)
        {
            /*
            Routeplanner zelf
            Om aan te roepen, geef een vliegtuig mee. Vliegtuig weet huidige coordinaten
            Stap 1, waar is het vliegtuig nu?
            */
            Way startWay = null;
            foreach (Way w in ways)
            {
                if (Utils.isPointInWay(airplane.location, w))
                {
                    //Kijkt of het vliegtuig zich op een weg bevindt en als dat zo is zet de startWay als die weg
                    startWay = w;
                    break;
                }
            }
            if (startWay == null)
                startWay = Utils.getClosestWay(airplane.location, ways);

            if (startWay != null) //Om zeker te weten dat een beginlocatie bepaald is
            {
                Way endWay = null;
                //Stap 2, waar moet het vliegtuig heen? Zoek een vrije gate als start een runway is, en vice versa
                
                if (!airplane.hasDocked)
                {

                    //Utils.getClosestWay(airplane.location, airplane.gate);

                       //Check de gates - open gate. Als geen gates open, zoek 1: dichtstbijzijnde gate of 2: langst bezette gate.
                       //Optie 1 heeft waarschijnlijk iets kleinere kans op file voor 1 gate, vanwege meerdere Runways en vertraging tussen vliegtuigen landen op zelfde Runway.
                       //Optie 2 leidt vrijwel altijd tot alle nieuwe vliegtuigen naar dezelfde gate -> file.
                       //IList<Gate> availableGates = new List<Gate>();
                       //IList<Gate> occupiedGates = new List<Gate>();
                       //IList<Gate> reservedGates = new List<Gate>();
                       //occupiedGates = airport.occupiedGates();
                       foreach (Way w in ways)
                       {
                           if (w is Gate)
                           {
                               if (w.name == airplane.gate)
                               {
                                   endWay = (Gate)w;
                                   break;
                               }
                               //if (newGate.isReserved)
                               //{
                               //    reservedGates.Add(newGate);
                               //}
                               //else if (!occupiedGates.Contains(newGate))
                               //{
                               //    availableGates.Add(newGate);
                               //}
                           }
                       }
                /*       if (availableGates.Count == 1)
                       {
                           //1 gate vrij, makkelijkste geval. Deze gate is doel
                           endWay = availableGates[0];
                           endWay.addReservation(this);
                       }
                       else if (availableGates.Count == 0)
                       {
                           //Geen gates vrij, occupiedGates heeft voorrang, dan reservedGates
                           if (occupiedGates.Count > 0)
                           {
                               if (occupiedGates.Count == 1)
                               {
                                   endWay = occupiedGates[0];
                                   endWay.addReservation(this);
                               }
                               else
                               {
                                   IList<Way> occupiedWays = new List<Way>();
                                   foreach (Gate g in occupiedGates)
                                   {
                                       occupiedWays.Add(g);
                                   }
                                   endWay = Utils.getClosestWay(airplane.location, occupiedWays);
                                   endWay.addReservation(this);
                               }
                           }
                           else if (reservedGates.Count > 0)
                           {
                               if (reservedGates.Count == 1)
                               {
                                   endWay = reservedGates[0];
                                   endWay.addReservation(this);
                               }
                               else
                               {
                                   IList<Way> reservedWays = new List<Way>();
                                   foreach (Gate g in reservedGates)
                                   {
                                       reservedWays.Add(g);
                                   }
                                   endWay = Utils.getClosestWay(airplane.location, reservedWays);
                                   endWay.addReservation(this);
                               }
                           }
                       }
                       else if (availableGates.Count > 1)
                       {
                           IList<Way> availableWays = new List<Way>();
                           foreach (Gate g in availableGates)
                           {
                               availableWays.Add(g);
                           }
                           endWay = Utils.getClosestWay(airplane.location, availableWays);
                           endWay.addReservation(this);
                       }*/
                } 
                else if (airplane.hasDocked)
                {
                    IList<Way> runways = new List<Way>();
                    foreach(Way w in ways)
                    {
                        if(w is Runway)
                            runways.Add(w);
                    }
                    endWay = Utils.getClosestWay(airplane.location, runways);
                }
                Node startNode = findStartNode(startWay, airplane);
                Node endNode = endWay.nodeConnections[1]; //De endNode is de beginNode van een Way want: vliegtuig moet naar begin runway of gate
                Route bestRoute = findRoute(startNode, endNode, airplane, airport);
                this.nodes = bestRoute.RouteList();
                wayPoints = convertNodesToWaypoints(bestRoute.RouteList()); // Geef de lijst met Ways door aan het vliegtuig. (Hier gekozen voor lijst van Ways, lijkt handiger ivm toestemming)

                // Ways initten
                currentWay = startWay;
                getTargetWay();
            }
        }

        public Route findRoute(Node startNode, Node endNode, Airplane airplane, Airport.Airport airport)
        {
            /*
             * Deze methode maakt een stapel aan met routes. Het pakt de bovenste route van deze stapel. Route heeft Node, vorige Route en lengte.
             * Zolang routes op stapel, blijf draaien. Voor iedere route check Node. Is Node endNode? Ja + lengte < kortste Route dan nieuwe kortste Route.
             * Anders kijk Ways bij Node. Als Node = Endnote of lengte Route > lengte beste Route niet opnieuw pushen. 
             * Anders nieuwe Route maken met Node andere kant van Way. Resultaat is kortste Route van beginNode naar endNode.
            */

            foreach (Way w in airport.ways)
                w.weightedLength = w.length;
            
            Stack<Route> routes = new Stack<Route>();
            Route bestRoute = null;
            routes.Push(new Route(startNode, null, 0));
            while (routes.Count > 0)
            {
                Route route = routes.Pop();
                if (route.hasNode(endNode))
                {
                    if (bestRoute == null || route.length < bestRoute.length)
                    {
                        bestRoute = route;
                    }
                }
                IList<Way> connections = route.local.connections;
                foreach (Way connection in connections)
                {
                    if (!route.hasNode(endNode))
                    {
                        if (route.local.isDirectionAllowed(connection))
                        {
                            //Schat tijd tot aankomst bij way
                            //DateTime estimatedArrival = TimeKeeper.currentSimTime;
                            //estimatedArrival.AddSeconds(route.length / 20); // t = s / v : schat de tijd van aankomst op connection
                            ////Vergelijk met andere vliegtuigen
                            //List<Airplane> airplanesOnWay = airport.planesOnWayInDirection(connection, route.local, airplane);
                            //foreach (Airplane ap in airplanesOnWay)
                            //{
                            //    DateTime[] timeframe = ap.navigator.estimatedArrivalTime(connection);
                            //    if (timeframe[0] <= estimatedArrival && estimatedArrival <= timeframe[1])
                            //        connection.weightedLength *= 5;
                            //}
                            //double length = connection.weightedLength;
                            if (bestRoute == null || route.length /*+ length */ <= bestRoute.length)
                            {
                                Node connectedNode = route.local.getConnectedNode(connection);

                                if (!route.hasNode(connectedNode))
                                {
                                    Route newRoute = new Route(connectedNode, route, connection.weightedLength);
                                    routes.Push(newRoute);                                              //Zet nieuwe Route op stack met Node andere kant connection
                                }
                            }
                            connection.weightedLength = connection.length;
                        }
                    }
                }
            }

            return bestRoute;
        }

        public DateTime[] estimatedArrivalTime(Way targetway)
        {
            //Deze methode maakt een schatting van 2 tijden: 1 = aankomsttijd op een Way, 2 = vertrektijd van Way
            //Schatting wordt gedaan op basis van een gemiddelde snelheid van 20 = Airplane.maxSpeed

            double distanceTotal = 0; //Het bepalen van de nog af te leggen afstand
            int current = wayPoints.IndexOf(currentWay); //De huidige weg
            if (current < 0)
                current = 0;
            int max = wayPoints.IndexOf(targetway); //De doelweg
            if (max < 0)
                max = 0;
            for (int t = 0; t < wayPoints.Count; t++)
            {
                if (t >= current && t < max)
                    distanceTotal += wayPoints[t].length;
            }

            double speed = 20; //Gemiddelde snelheid (echte snelheid zal iets lager liggen door het draaien)

            double timeElapsing = distanceTotal / speed; //Geschatte tijd tot aankomst
            double timeTravelling = targetway.length / speed; //Geschatte tijd dat het duurt om de weg over te rijden
            DateTime arrivalTime = TimeKeeper.currentSimTime;
            arrivalTime.AddSeconds(timeElapsing); //Huidige tijd + reistijd
            DateTime leavingTime = arrivalTime;
            leavingTime.AddSeconds(timeTravelling); //Arriveertijd + tijd over weg
            DateTime[] times = { arrivalTime, leavingTime };
            return times;
        }

        private Node findStartNode(Way w, Airplane a)
        {
            if (w.direction == 1) return w.nodeConnections[1]; //Als richting 1, dan de Node waar de baan eindigt is beginpunt
            if (w.direction == -1) return w.nodeConnections[0]; //Andersom voor richting -1
            if (w.direction == 0)                               //Dichtstbijzijnde op dubbelbaansweg
            {
                double d = 1000000; double temp;
                foreach (Node n in w.nodeConnections)
                {
                    temp = Utils.getDistanceBetweenPoints(a.location, n.location);
                    if (temp < d) d = temp;
                }
                foreach (Node n in w.nodeConnections) if (Utils.getDistanceBetweenPoints(a.location, n.location) == d) return n;
            }
            return null;
        }

        private IList<Way> convertNodesToWaypoints(IList<Node> nodeList)
        {
            //Deze methode neemt een lijst met nodes en construeert daaruit een lijst met de ways die deze nodes verbinden
            for (int t = 0; t < nodeList.Count - 1; t++)
            {
                foreach (Way w in nodeList[t].connections)
                {
                    if (w.nodeConnections.Contains(nodeList[t + 1]))
                    {
                        if (w.nodeConnections[0] == nodeList[t] && w.nodeConnections[1] == nodeList[t + 1] && w.direction == 1)
                        {
                            wayList.Add(w);
                        }
                        if (w.nodeConnections[0] == nodeList[t + 1] && w.nodeConnections[1] == nodeList[t] && w.direction == -1)
                        {
                            wayList.Add(w);
                        }
                        if (w.direction == 0)
                        {
                            wayList.Add(w);
                        }
                    }
                }
            }
            return wayList;
        }

        public Node getTargetNode()
        {
            if (nodes.Count != targetNodeNumber)
            {
                return nodes[targetNodeNumber];
            }
            else
            {
                return null;
            }
        }

        public double getDistanceToTargetNode(double[] location)
        {
            return Utils.getDistanceBetweenPoints(location, nodes[targetNodeNumber].location);
        }


        public Boolean hasNextTarget()
        {
            if (targetNodeNumber + 1 >= nodes.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void setNextTarget()
        {
            targetNodeNumber++;

            getCurrentWay();
            getTargetWay();
        }
        public void getCurrentWay()
        {
            if (targetNodeNumber == 0 || targetNodeNumber >= nodes.Count)  // als 0, dan staat de huidige weg al goed vanuit newRoute()
            {
                return;
            }

            Node targetNode = nodes[targetNodeNumber];
            Node previousNode = nodes[targetNodeNumber - 1]; ;

            foreach (Way targetConnectedWay in targetNode.connections)
            {
                foreach (Way previousConnectedWay in previousNode.connections)
                {
                    if (targetConnectedWay.Equals(previousConnectedWay))
                    {
                        currentWay = targetConnectedWay;
                        return;
                    }
                }
            }
        }
        public Way getTargetWay()
        {
            if (targetNodeNumber >= nodes.Count - 1)   // Targetway is de huidige weg
            {
                return currentWay;
            }

            Node targetNode = nodes[targetNodeNumber];
            Node nextTargetNode = nodes[targetNodeNumber + 1]; ;

            foreach (Way targetConnectedWay in targetNode.connections)
            {
                foreach (Way previousConnectedWay in nextTargetNode.connections)
                {
                    if (targetConnectedWay.Equals(previousConnectedWay))
                    {
                        targetWay = targetConnectedWay;
                        return targetWay;
                    }
                }
            }
            return targetWay;
        }


        /*public bool hasPermission()
        {
            //Indien trackWay gelijk is aan grootte van wayList, dan moet hij weer op 0 en kan je sowieso true returnen, want hij is bij de gate.

            if (trackWay == wayList.Count)
            {
                trackWay = 0;
                return true;
            }
            else if (wayList[trackWay] is Runway)
            {
                if (runWays[0].runwayHasAirplane == false)
                {
                    Console.WriteLine("TOESTEMMING VOOR RUNWAY!");
                    trackWay++;
                    return true;
                }
                else
                {                   
                    Console.WriteLine("GEEN TOESTEMMING VOOR RUNWAY!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("WAYLIST 0:" + wayList[0].hasAirplane);
                Console.WriteLine("WAYLIST 1:" + wayList[1].hasAirplane);
                Console.WriteLine("WAYLIST 2:" + wayList[2].hasAirplane);
                Console.WriteLine("WAYLIST 3:" + wayList[3].hasAirplane);
                //Indien de huidige way al een airplane heeft, controleer dan op mogelijkheden
                if (wayList[trackWay].hasAirplane == true)
                {
                    //Indien trackWay geen 0 is, ga dan bekijken of voor de volgende weg met direction 0 er mogelijkheden bestaan
                    if (trackWay != 0)
                    {
                        if (wayList[trackWay].direction == 0)
                        {
                            //Indien de navigatorList voor de volgende weg 1 navigator bevat, controleer dan of die nodepoints gelijk zijn aan je huidige nodepoints, want dan is hij in andere richting
                            if (wayList[trackWay].navigatorList.Count == 1)
                            {
                                if (nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] == nodepoints[wayList[trackWay].navigatorList[0].currentTargetNode])
                                {
                                    trackWay++;
                                    return true;
                                }
                            }
                            //Indien de navigatorList voor de volgende weg 2 navigators bevat
                            if (wayList[trackWay].navigatorList.Count == 2)
                            {
                                //Controleer eerst of die nodepoints van de eerste in de lijst gelijk zijn aan je huidige nodepoints, want dan is hij in andere richting
                                if (nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] == nodepoints[wayList[trackWay].navigatorList[0].currentTargetNode])
                                {
                                    //Check daarna of de nodepoints van de 2e uit de lijst gelijk zijn, want dan beide in andere richting dus kan je erop
                                    if (nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] == nodepoints[wayList[trackWay].navigatorList[1].currentTargetNode])
                                    {
                                        trackWay++;
                                        return true;
                                    }
                                    //Indien dit niet het geval is, bekijk dan of de distanceToTarget kleiner dan 700 is, in dit geval is het veilig om te gaan rijden
                                    else if (nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] != nodepoints[wayList[trackWay].navigatorList[1].currentTargetNode])
                                    {
                                        if (wayList[trackWay].navigatorList[1].distanceToTarget < 700) // <---
                                        {
                                            trackWay++;
                                            return true;
                                        }
                                    }
                                }
                                //Controleer of de nodepoints van de tweede in de lijst gelijk zijn aan je huidge positie, want dan is hij in andere richting
                                else if (nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] == nodepoints[wayList[trackWay].navigatorList[1].currentTargetNode])
                                {
                                    //Check daarna of de nodepoints van de 1e uit de lijst gelijk zijn, want dan beide in andere richting dus kan je erop
                                    if (nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] == nodepoints[wayList[trackWay].navigatorList[0].currentTargetNode])
                                    {
                                        trackWay++;
                                        return true;
                                    }
                                    //Indien dit niet het geval is, bekijk dan of de distanceToTarget kleiner dan 700 is, in dit geval is het veilig om te gaan rijden
                                    else if (nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] != nodepoints[wayList[trackWay].navigatorList[0].currentTargetNode])
                                    {
                                        if (wayList[trackWay].navigatorList[0].distanceToTarget < 700) // <---
                                        {
                                            trackWay++;
                                            return true;
                                        }
                                    }
                                }
                            }
                            //Zojuist bedacht dat dit helemaal niet meer nodig is, aangezien we maximaal 3 airplanes op een way willen en als er al 3 zijn, mag je toch niet meer.
                            //Ik laat hem maar wel staan voor als we het in de toekomst misschien veranderen
                           
                            if (wayList[trackWay].navigatorList.Count == 3)
                            {
                                if (nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] == nodepoints[wayList[trackWay].navigatorList[0].currentTargetNode])
                                {
                                    if (nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] == nodepoints[wayList[trackWay].navigatorList[1].currentTargetNode] && nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] == nodepoints[wayList[trackWay].navigatorList[2].currentTargetNode])
                                    {
                                        trackWay++;
                                        return true;
                                    }
                                    if (nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] == nodepoints[wayList[trackWay].navigatorList[1].currentTargetNode] && nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] != nodepoints[wayList[trackWay].navigatorList[2].currentTargetNode])
                                    {
                                        if (wayList[trackWay].navigatorList[2].distanceToTarget < 700) // <---
                                        {
                                            trackWay++;
                                            return true;
                                        }
                                    }
                                    if (nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] != nodepoints[wayList[trackWay].navigatorList[1].currentTargetNode] && nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] == nodepoints[wayList[trackWay].navigatorList[2].currentTargetNode])
                                    {
                                        if (wayList[trackWay].navigatorList[1].distanceToTarget < 700) // <---
                                        {
                                            trackWay++;
                                            return true;
                                        }
                                    }
                                }
                                else if (nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] == nodepoints[wayList[trackWay].navigatorList[1].currentTargetNode])
                                {
                                    if (nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] == nodepoints[wayList[trackWay].navigatorList[0].currentTargetNode] && nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] == nodepoints[wayList[trackWay].navigatorList[2].currentTargetNode])
                                    {
                                        trackWay++;
                                        return true;
                                    }
                                    if (nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] == nodepoints[wayList[trackWay].navigatorList[0].currentTargetNode] && nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] != nodepoints[wayList[trackWay].navigatorList[2].currentTargetNode])
                                    {
                                        if (wayList[trackWay].navigatorList[2].distanceToTarget < 700) // <---
                                        {
                                            trackWay++;
                                            return true;
                                        }
                                    }
                                    if (nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] != nodepoints[wayList[trackWay].navigatorList[0].currentTargetNode] && nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] == nodepoints[wayList[trackWay].navigatorList[2].currentTargetNode])
                                    {
                                        if (wayList[trackWay].navigatorList[0].distanceToTarget < 700) // <---
                                        {
                                            trackWay++;
                                            return true;
                                        }
                                    }
                                }
                                else if (nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] == nodepoints[wayList[trackWay].navigatorList[2].currentTargetNode])
                                {
                                    if (nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] == nodepoints[wayList[trackWay].navigatorList[0].currentTargetNode] && nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] == nodepoints[wayList[trackWay].navigatorList[1].currentTargetNode])
                                    {
                                        trackWay++;
                                        return true;
                                    }
                                    if (nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] == nodepoints[wayList[trackWay].navigatorList[0].currentTargetNode] && nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] != nodepoints[wayList[trackWay].navigatorList[1].currentTargetNode])
                                    {
                                        if (wayList[trackWay].navigatorList[1].distanceToTarget < 700) // <---
                                        {
                                            trackWay++;
                                            return true;
                                        }
                                    }
                                    if (nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] != nodepoints[wayList[trackWay].navigatorList[0].currentTargetNode] && nodepoints[wayList[trackWay - 1].navigatorList[0].currentTargetNode] == nodepoints[wayList[trackWay].navigatorList[1].currentTargetNode])
                                    {
                                        if (wayList[trackWay].navigatorList[0].distanceToTarget < 700)
                                        {
                                            trackWay++;
                                            return true;
                                        }
                                    }
                                }
                            }
                            
                        }
                    }
                    //Controleer of de list kleiner is dan 3 want dan mag er nog een nieuwe navigator bij
                    else if (wayList[trackWay].navigatorList.Count < 3)
                    {
                        //Indien de list 1 groot is, controleer dan of de eerste uit die lijst distanceToTarget kleiner dan 700 heeft, dan is het veilig
                        if (wayList[trackWay].navigatorList.Count == 1)
                        {
                            if (wayList[trackWay].navigatorList[0].distanceToTarget < 700)
                                trackWay++;
                            return true;
                        }
                        //Indien de list 2 groot is, controleer dan of de tweede uit die lijst distanceToTarget kleiner dan 700 heeft
                        //De 2e heeft namelijk ook al gecontroleerd bij de eerste en dus weet je dan dat het veilig is
                        if (wayList[trackWay].navigatorList.Count == 2)
                            if (wayList[trackWay].navigatorList[1].distanceToTarget < 700)
                                trackWay++;
                        return true;
                    }
                    //Als geen van deze allen mogelijk zijn, return dan false en ga net zo lang door met de while loop tot je wel mag
                    return false;
                }
                //Indien er geen airplane op de weg is, mag je sowieso
                else
                {
                    Console.WriteLine("ER IS GEEN VLIEGTUIG!");
                    trackWay++;

                    Console.WriteLine("TRACKWAY" + trackWay);
                    return true;
                }
            }
        }*/

        //True betekend geen collision, false betekend wel collision
        /*public bool collisionDetection()
        {
            if (trackWay != 0)
            {
                Console.WriteLine("TEST VOOR COLLISION");
                //Indien een way is een gate, dan heeft het geen zin
                if (wayList[trackWay - 1] is Gate)
                {
                    Console.WriteLine("GATE");
                    return true;
                }
                else
                {
                    //Indien er 1 vliegtuig op de way is kan er geen collision zijn
                    if (wayList[trackWay - 1].navigatorList.Count == 1)
                    {
                        Console.WriteLine("GEEN COLLISION");
                        return true;
                    }
                    //Indien er 2 vliegtuigen op de way zijn, check of de laatste niet binnen 150 meter van de eerste is, want dan geen collision
                    if (wayList[trackWay - 1].navigatorList.Count == 2)
                    {
                        if (wayList[trackWay - 1].navigatorList[1].distanceToTarget - wayList[trackWay - 1].navigatorList[0].distanceToTarget > 150)
                        {
                            Console.WriteLine("GEEN COLLISION");
                            return true;
                        }
                    }
                    //Indien er 3 vliegtuigen op de way zijn, check of de 3e niet binnen 150 meter dan de 2e is en de 2e niet binnen 150 meter van de 1e, want dan geen collision
                    if (wayList[trackWay - 1].navigatorList.Count == 3)
                    {
                        if ((wayList[trackWay - 1].navigatorList[2].distanceToTarget - wayList[trackWay - 1].navigatorList[1].distanceToTarget > 150) && (wayList[trackWay - 1].navigatorList[1].distanceToTarget - wayList[trackWay - 1].navigatorList[0].distanceToTarget > 150))
                        {
                            Console.WriteLine("GEEN COLLISION");
                            return true;
                        }
                    }
                }
                //Als dit niet zo is dan is er collision
                Console.WriteLine("COLLISION");
                return false;
            }
            //Indien trackway = 0, return dan true want dat is gate of runway en bij gate is het niet nodig en bij runway wordt het door ons zelf gedaan
            return true;
        }*/

        public double getAngleToTarget(double[] location)
        {
            return Utils.getAngleBetweenPoints(location, nodes[targetNodeNumber].location);
        }

        public bool hasWay(Way way)
        {
            //Methode om te kijken of een navigator een weg nog niet heeft afgelegd
            if (wayPoints.Contains(way))
            {
                int target = wayPoints.IndexOf(currentWay);
                for (int t = 0; t < wayPoints.Count; t++)
                {
                    if (t >= target)
                        if (wayPoints[t] == way)
                            return true;
                }
            }
            return false;
        }
    }
}
