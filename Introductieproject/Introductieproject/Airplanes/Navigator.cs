using Introductieproject.Airport;
using Introductieproject.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Airplanes
{
    class Navigator
    {
        private Route route;                // Kale route
        public IList<Node> nodepoints;      // De lijst met toekomstige nodepoints voor het vliegtuig
        public IList<Way> waypoints;        // De lijst met toekomstige waypoints voor het vliegtuig
        private int currentWayPont = 0;     // Huidige waypoint

        public Navigator(Airplane airplane, List<Way> ways)
        {
            Console.WriteLine("Creating new navigator");
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
            if (startWay != null) //Om zeker te weten dat een beginlocatie bepaald is
            {
                Way endWay = null;
                //Stap 2, waar moet het vliegtuig heen? Zoek een vrije gate als start een runway is, en vice versa
                if (!airplane.hasDocked)
                {
                    //Check de gates - open gate. Als geen gates open, zoek 1: dichtstbijzijnde gate of 2: langst bezette gate.
                    //Optie 1 heeft waarschijnlijk iets kleinere kans op file voor 1 gate, vanwege meerdere Runways en vertraging tussen vliegtuigen landen op zelfde Runway.
                    //Optie 2 leidt vrijwel altijd tot alle nieuwe vliegtuigen naar dezelfde gate -> file.
                    IList<Gate> availableGates = new List<Gate>();
                    IList<Gate> occupiedGates = new List<Gate>();
                    IList<Gate> reservedGates = new List<Gate>();
                    foreach (Way w in ways)
                    {
                        if (w is Gate)
                        {
                            Gate newGate = (Gate)w;
                            if (newGate.isReserved)
                            {
                                reservedGates.Add(newGate);
                            }
                            else if (newGate.airplane != null)
                            {
                                occupiedGates.Add(newGate);
                            }
                            else
                            {
                                availableGates.Add(newGate);
                            }
                        }
                    }
                    if (availableGates.Count == 1)
                    {
                        //1 gate vrij, makkelijkste geval. Deze gate is doel
                        endWay = availableGates[0];
                    }
                    else if (availableGates.Count == 0)
                    {
                        //Geen gates vrij, occupiedGates heeft voorrang, dan reservedGates
                        if (occupiedGates.Count > 0)
                        {
                            if (occupiedGates.Count == 1)
                                endWay = occupiedGates[0];
                            else
                            {
                                IList<Way> occupiedWays = (IList<Way>)occupiedGates;
                                endWay = Utils.getClosestWay(airplane.location, occupiedWays);
                            }
                        }
                        else if (reservedGates.Count > 0)
                        {
                            if (reservedGates.Count == 1)
                                endWay = reservedGates[0];
                            else
                            {
                                IList<Way> reservedWays = (IList<Way>)reservedGates;
                                endWay = Utils.getClosestWay(airplane.location, reservedWays);
                            }
                        }
                    }
                    else if (availableGates.Count > 1)
                    {
                        IList<Way> availableWays = (IList<Way>)availableGates;
                        endWay = Utils.getClosestWay(airplane.location, availableWays);
                    }
                }
                else if (airplane.hasDocked)
                {
                    IList<Way> runWays = new List<Way>();
                    foreach(Way w in ways)
                    {
                        if(w is Runway)
                            runWays.Add(w);
                    }
                    endWay = Utils.getClosestWay(airplane.location, runWays);
                }
                Node startNode = findStartNode(startWay, airplane);
                Node endNode = endWay.nodeConnections[0]; //De endNode is de beginNode van een Way want: vliegtuig moet naar begin runway of gate
                Route bestRoute = findRoute(startNode, endNode);
                this.nodepoints = bestRoute.RouteList();
                Console.WriteLine("Created list of Nodes");
                foreach (Node node in nodepoints)
                {
                    Console.WriteLine(node.ToString());
                }
                waypoints = convertNodesToWaypoints(bestRoute.RouteList()); // Geef de lijst met Ways door aan het vliegtuig. (Hier gekozen voor lijst van Ways, lijkt handiger ivm toestemming)

                Console.WriteLine("Created new list of waypoints");
                /*foreach (Way way in waypoints)
                {
                    Console.WriteLine(way.ToString());
                }
                Console.WriteLine("End of waypoints");
                */
            }
        }

        public Route findRoute(Node startNode, Node endNode)
        {
            /*
             * Deze methode maakt een stapel aan met routes. Het pakt de bovenste route van deze stapel. Route heeft Node, vorige Route en lengte.
             * Zolang routes op stapel, blijf draaien. Voor iedere route check Node. Is Node endNode? Ja + lengte < kortste Route dan nieuwe kortste Route.
             * Anders kijk Ways bij Node. Als Node = Endnote of lengte Route > lengte beste Route niet opnieuw pushen. 
             * Anders nieuwe Route maken met Node andere kant van Way. Resultaat is kortste Route van beginNode naar endNode.
            */
            Console.WriteLine("Finding route to " + endNode.ToString());
            Console.WriteLine("            from " + startNode.ToString());

            Stack<Route> routes = new Stack<Route>();
            Route bestRoute = null;
            routes.Push(new Route(startNode, null, 0));
            while (routes.Count > 0)
            {
                Console.WriteLine("Check route");
                Route route = routes.Pop();
                if (route.hasNode(endNode))
                {
                    Console.WriteLine("Route has endnode");
                    if (bestRoute == null || route.length < bestRoute.length)
                    {
                        Console.WriteLine("New bestroute assigned");
                        bestRoute = route;
                    }
                }
                IList<Way> connections = route.local.connections;
                foreach (Way connection in connections)
                {
                    Console.WriteLine("Checking connection: " + connection.ToString());
                    if (!route.hasNode(endNode) && (bestRoute == null || route.length + connection.length <= bestRoute.length))
                    {
                        if (route.local.isDirectionAllowed(connection))
                        {
                            Node connectedNode = route.local.getConnectedNode(connection);
                            Route newRoute = new Route(connectedNode, route, connection.length);
                            routes.Push(newRoute);                                              //Zet nieuwe Route op stack met Node andere kant connection
                        }
                    }
                }
            }

            return bestRoute;
        }

        private Node findStartNode(Way w, Airplane a)
        {
            if (w.direction == 1) return w.nodeConnections[0]; //Als richting 1, dan de Node waar de baan eindigt is beginpunt
            if (w.direction == -1) return w.nodeConnections[1]; //Andersom voor richting -1
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
            IList<Way> wayList = new List<Way>();
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



        public Way getCurrentWayPoint()
        {
            return waypoints[currentWayPont];
        }
        public Way getNextWayPoint()
        {
            currentWayPont++;
            return waypoints[currentWayPont];
        }
        public Way getPreviousWayPoint()
        {
            currentWayPont--;
            return waypoints[currentWayPont];
        }
    }
}
