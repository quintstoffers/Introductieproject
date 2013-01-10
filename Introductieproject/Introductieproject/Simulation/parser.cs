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
                String arrivalDate = attr["arrivalDate"].Value;
                String departureDate = attr["departureDate"].Value;
                String origin = attr["origin"].Value;
                String destination = attr["destination"].Value;

                DateTime arrivalDateTime = DateTime.Parse(arrivalDate);
                DateTime departureDateTime = DateTime.Parse(departureDate);

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
                    newAirplane.setXMLVariables(arrivalDateTime, departureDateTime, registration, flight, carrier, origin, destination);

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
            int i = 0; //Een maal getNodeMatch ophalen.
            foreach (Node[] nodeMatch in getNodeMatch("runway", directions, AirportDocument, nodeList))
            {
                
                Runway runWay = new Runway(nodeMatch[0], nodeMatch[1], directions[i]);
                runWayList.Add(runWay);
                i++;

            }
            i = 0;
            foreach (Node[] nodeMatch in getNodeMatch("taxiway", directions, AirportDocument, nodeList))
            {
                Taxiway taxiWay = new Taxiway(nodeMatch[0], nodeMatch[1], directions[i]);
                taxiWayList.Add(taxiWay);
                i++;
            }
            i = 0;
            foreach (Node[] nodeMatch in getNodeMatch("gate", directions, AirportDocument, nodeList))
            {
                Gate gate = new Gate(nodeMatch[0], nodeMatch[1], directions[i]);
                gateList.Add(gate);
                i++;
            }
            i = 0;
            foreach (Node[] nodeMatch in getNodeMatch("gateway", directions, AirportDocument, nodeList))
            {
                Gateway gateWay = new Gateway(nodeMatch[0], nodeMatch[1], directions[i]);
                gateWayList.Add(gateWay);
                i++;
            }
        }
        public List<Node[]> getNodeMatch(string type, List<int> directions, XmlDocument xmlDocument, List<Node> nodeList)
        {
            List<Node[]> NodeMatch = new List<Node[]>();
            XmlNodeList wayNodes = xmlDocument.SelectNodes("//" + type);
            int i = 0;
            directions.Clear();
            foreach (XmlNode xmlNode in wayNodes)
            {
                Node[] matches = new Node[2];
                int nodeX1 = int.Parse(xmlNode.Attributes["X1"].Value);
                int nodeX2 = int.Parse(xmlNode.Attributes["X2"].Value);
                int nodeY1 = int.Parse(xmlNode.Attributes["Y1"].Value);
                int nodeY2 = int.Parse(xmlNode.Attributes["Y2"].Value);
                int nodedir = int.Parse(xmlNode.Attributes["dir"].Value);
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