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
        public IList<Way> waypoints;        // De lijst met toekomstige waypoints voor het vliegtuig
        private int currentWayPont = 0;     // Huidige waypoint

        public Navigator(Airplane airplane, List<Way> ways, List<Gate> gates, List<Runway> runways)
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
                    int t = 0;
                    foreach (Gate g in gates) if (g.airplane == null) t++;
                    if (t == 1)
                    {
                        //1 gate vrij, makkelijkste geval. Deze gate is doel
                        foreach (Gate g in gates) if (g.airplane == null) endWay = g;
                    }
                    else if (t == 0)
                    {
                        //geen gates vrij. Ga na welke het dichtste bij is
                        //Dichtste bij kan hemelsbreed zijn of via banen. Voor het gemak nu hemelsbreed
                        double d = 100000; //Groot getal eerst
                        double temp;
                        foreach (Gate g in gates)
                        {
                            temp = Utils.getDistanceBetweenPoints(startWay.nodeConnections[1].location, g.nodeConnections[0].location);
                            if (temp < d)
                            {
                                d = temp;
                            }
                        }
                        foreach (Gate g in gates)
                        {
                            if (Utils.getDistanceBetweenPoints(startWay.nodeConnections[1].location, g.nodeConnections[0].location) == d) endWay = g;
                        }
                    }
                    else if (t > 1)
                    {
                        //meerdere mogelijkheden. Dichtstbijzijnde open gate. Lijkt erg op t=0, maar met kleine aanpassingen
                        double d = 100000;
                        double temp;
                        foreach (Gate g in gates)
                        {
                            temp = Utils.getDistanceBetweenPoints(startWay.nodeConnections[1].location, g.nodeConnections[0].location);
                            if (temp < d && g.airplane == null) d = temp; //Alleen lege gates nagaan
                        }
                        foreach (Gate g in gates) if (Utils.getDistanceBetweenPoints(airplane.location, g.nodeConnections[0].location) == d
                            && g.airplane == null) endWay = g; //&& g.airplane == null is voor het geval dat er 2 gates precies even ver zijn, en er maar 1 open is
                    }
                }
                else if (airplane.hasDocked)
                {
                    //Check de runways - dichtstbijzijnde Runway, want je kunt er van uit gaan dat als hij nu bezet is, hij dat niet meer zal zijn als je aankomt.
                    //Dichtstbijzijnde als in degene die de minste reistijd kost.
                    double d = 100000;
                    double temp;
                    foreach (Runway r in runways)
                    {
                        temp = Utils.getDistanceBetweenPoints(airplane.location, r.nodeConnections[0].location); //Berekent afstand hemelsbreed tussen vliegtuig en begin runway
                        if (temp < d) d = temp;
                    }
                }
                Node startNode = findStartNode(startWay, airplane);
                Node endNode = endWay.nodeConnections[0]; //De endNode is de beginNode van een Way want: vliegtuig moet naar begin runway of gate
                Route bestRoute = findRoute(startNode, endNode);
                waypoints = convertNodesToWaypoints(bestRoute.RouteList()); // Geef de lijst met Ways door aan het vliegtuig. (Hier gekozen voor lijst van Ways, lijkt handiger ivm toestemming)

                Console.WriteLine("Created new list of waypoints");
                foreach (Way way in waypoints)
                {
                    Console.WriteLine(way.ToString());
                }
                Console.WriteLine("End of waypoints");
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
                IList<Way> connections;
                connections = route.local.connections;
                foreach (Way connection in connections)
                {
                    if (!route.hasNode(endNode) && (bestRoute == null || route.length + connection.length <= bestRoute.length))
                    {
                        Node connectedNode = route.local.getConnectedNode(connection);
                        Route newRoute = new Route(connectedNode, route, connection.length);
                        routes.Push(newRoute);                                              //Zet nieuwe Route op stack met Node andere kant connection
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
