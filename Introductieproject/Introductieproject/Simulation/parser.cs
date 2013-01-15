using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Introductieproject.Objects;
using System.Reflection;
using System.IO;
using System.ComponentModel;
using Introductieproject.Airport;

namespace Introductieproject.Simulation
{
    class Parser
    {
        static XmlDocument PlaneDocument = new XmlDocument();
        static XmlDocument AirportDocument = new XmlDocument();
        static XmlNodeList rawPlaneSchedule;

        public static void refreshAirplanes(BindingList<Airplane> loadedAirplanes)
        {
            try
            {
                PlaneDocument.Load(@"Simulation\schedule.xml");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("XML not found");
                return;
            }

            rawPlaneSchedule = PlaneDocument.GetElementsByTagName("plane");
            Assembly assembly = Assembly.Load("Introductieproject");

            int planeCount = rawPlaneSchedule.Count;
            for (int i = 0; i < planeCount; i++)
            {
                XmlNode rawAirplane = rawPlaneSchedule.Item(i);

                XmlAttributeCollection attr = rawAirplane.Attributes;

                String registration = attr["registration"].Value;
                String flight = attr["flight"].Value;
                String type = attr["type"].Value;
                String carrier = attr["carrier"].Value;
                String landingDate = attr["landingDate"].Value;
                String arrivalDate = attr["arrivalDate"].Value;
                String departureDate = attr["departureDate"].Value;
                String origin = attr["origin"].Value;
                String destination = attr["destination"].Value;
                String location = attr["location"].Value;

                DateTime landingDateTime = DateTime.Parse(landingDate);
                DateTime arrivalDateTime = DateTime.Parse(arrivalDate);
                DateTime departureDateTime = DateTime.Parse(departureDate);

                //Split landinglocation string to double[] location.
                string[] coords = location.Split(',');
                double[] landingLocation = new double[2];
                landingLocation[0] = double.Parse(coords[0]);
                landingLocation[1] = double.Parse(coords[1]);

                bool airplaneAlreadyLoaded = false;
                foreach (Airplane currentAirplane in loadedAirplanes)
                {
                    if (currentAirplane.Registration == null)
                    {
                        continue;
                    }
                        if (currentAirplane.Registration.Equals(registration))   // Airplane bestaat al
                        {
                            currentAirplane.flight = flight;
                            currentAirplane.carrier = carrier;
                            currentAirplane.landingDate = landingDateTime;
                            currentAirplane.arrivalDate = arrivalDateTime;
                            currentAirplane.departureDate = departureDateTime;
                            currentAirplane.origin = origin;
                            currentAirplane.destination = destination;

                            airplaneAlreadyLoaded = true;
                            break;
                        }
                }
                if (!airplaneAlreadyLoaded && TimeKeeper.currentSimTime < arrivalDateTime)
                {
                    System.Type objectType = assembly.GetType("Introductieproject.Objects." + type);

                    Airplane newAirplane = (Airplane)Activator.CreateInstance(objectType);
                    newAirplane.setXMLVariables(landingLocation, landingDateTime, arrivalDateTime, departureDateTime, registration, flight, carrier, origin, destination);

                    Program.mainForm.Invoke((Action)(() => loadedAirplanes.Add(newAirplane)));

                    Console.WriteLine("Arrival: " + arrivalDateTime.ToString());
                    Console.WriteLine("XML: new airplane loaded (flight=" + flight + " registration=" + registration + ")");

                }
            }
        }


        public void getWays(List<Node> nodeList, List<Runway> runWayList, List<Taxiway> taxiWayList, List<Gateway> gateWayList, List<Gate> gateList)
        {
            AirportDocument.Load(@"Simulation\airportlayout.xml");
            XmlNodeList xmlNodes = AirportDocument.SelectNodes("//node");
            List<int> directions = new List<int>();
            List<string> names = new List<string>();
            List<Node[]> runwayNodes = getNodeMatch("runway", directions, AirportDocument, nodeList, names);
            int i = 0; 
            foreach (Node[] nodeMatch in runwayNodes)
            {
                Runway runWay = new Runway(nodeMatch[0], nodeMatch[1], directions[i], names[i]);
                runWayList.Add(runWay);
                i++;
            }

            List<Node[]> taxiwayNodes = getNodeMatch("taxiway", directions, AirportDocument, nodeList, names);
            i = 0;
            foreach (Node[] nodeMatch in taxiwayNodes)
            {
                Taxiway taxiWay = new Taxiway(nodeMatch[0], nodeMatch[1], directions[i], names[i]);
                taxiWayList.Add(taxiWay);
                i++;
            }

            List<Node[]> gateNodes = getNodeMatch("gate", directions, AirportDocument, nodeList, names);
            i = 0;
            foreach (Node[] nodeMatch in gateNodes)
            {
                Gate gate = new Gate(nodeMatch[0], nodeMatch[1], directions[i], names[i]);
                gateList.Add(gate);
                i++;
            }

            List<Node[]> gatewayNodes = getNodeMatch("gateway", directions, AirportDocument, nodeList, names);
            i = 0;
            foreach (Node[] nodeMatch in gatewayNodes)
            {
                Gateway gateWay = new Gateway(nodeMatch[0], nodeMatch[1], directions[i], names[i]);
                gateWayList.Add(gateWay);
                i++;
            }
        }
        public List<Node[]> getNodeMatch(string type, List<int> directions, XmlDocument xmlDocument, List<Node> nodeList, List<string> names)
        {
            List<Node[]> NodeMatch = new List<Node[]>();
            XmlNodeList wayNodes = xmlDocument.SelectNodes("//" + type);
            int i = 0;
            directions.Clear();
            names.Clear();
            foreach (XmlNode xmlNode in wayNodes)
            {
                Node[] matches = new Node[2];
                int nodeX1 = int.Parse(xmlNode.Attributes["X1"].Value);
                int nodeX2 = int.Parse(xmlNode.Attributes["X2"].Value);
                int nodeY1 = int.Parse(xmlNode.Attributes["Y1"].Value);
                int nodeY2 = int.Parse(xmlNode.Attributes["Y2"].Value);
                int nodedir = int.Parse(xmlNode.Attributes["dir"].Value);
                string name = xmlNode.Attributes["name"].Value;
                Node firstNode = new Node(nodeX1, nodeY1);
                Node secondNode = new Node(nodeX2, nodeY2);
                if (!listContainsNode(nodeList, firstNode))
                {
                    nodeList.Add(firstNode);
                    matches[0] = firstNode;
                }
                else
                {
                    foreach (Node node in nodeList)
                    {
                        if (firstNode.Equals(node))
                            matches[0] = node;
                    }
                }
                if (!listContainsNode(nodeList, secondNode))
                {
                    nodeList.Add(secondNode);
                    matches[1] = secondNode;
                }
                else
                {
                    foreach (Node node in nodeList)
                    {
                        if (secondNode.Equals(node))
                            matches[1] = node;
                    }

                }
                if (matches.Count() == 2)
                {
                    NodeMatch.Add(matches);
                    directions.Add(nodedir);
                    names.Add(name);
                    i++;
                }
            }

            return NodeMatch;
        }
        public bool listContainsNode(List<Node> nodeList, Node node)
        {

            for (int i = 0; i < nodeList.Count; i++)
            {
                if (nodeList[i].Equals(node))
                    return true;
            }
            return false;
        }
    }
}