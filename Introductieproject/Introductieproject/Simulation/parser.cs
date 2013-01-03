using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Introductieproject.Objects;
using System.Reflection;
using System.IO;
using System.ComponentModel;

namespace Introductieproject.Simulation
{
    class Parser
    {
        static XmlDocument xmlDocument = new XmlDocument();
        static XmlNodeList rawPlaneSchedule;

        public static void refreshAirplanes(BindingList<Airplane> loadedAirplanes)
        {
            try
            {
                xmlDocument.Load(@"Simulation\schedule.xml");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("XML not found");
                return;
            }

            rawPlaneSchedule = xmlDocument.GetElementsByTagName("plane");
            Assembly assembly = Assembly.Load("Introductieproject");

            int planeCount = rawPlaneSchedule.Count;
            for (int i = 0; i < planeCount; i++)
            {
                XmlNode rawAirplane = rawPlaneSchedule.Item(i);

                XmlAttributeCollection attr = rawAirplane.Attributes;
                
                String registration =   attr["registration"].Value;
                String flight =         attr["flight"].Value;
                String type =           attr["type"].Value;
                String carrier =        attr["carrier"].Value;
                String arrivalDate =    attr["arrivalDate"].Value;
                String departureDate =  attr["departureDate"].Value;
                String origin =         attr["origin"].Value;
                String destination =    attr["destination"].Value;

                DateTime arrivalDateTime = DateTime.Parse(arrivalDate);
                DateTime departureDateTime = DateTime.Parse(departureDate);

                bool airplaneAlreadyLoaded = false;
                foreach(Airplane currentAirplane in loadedAirplanes)
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
                if (!airplaneAlreadyLoaded)
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

        /*public string getallplanes()
        {
            string planes = null;
            XmlNodeList planename = database.SelectNodes("//data/planes/plane/number/text()");
            for (int i = 0; i < planename.Count; i++)
            {
                if (i != planename.Count - 1)
                {
                    planes += (planename[i].InnerText + Environment.NewLine);
                }
                else
                {
                    planes += (planename[i].InnerText);
                }
            }
            return planes;
        }

        public void updateAirplanelist()
        {
            if (firstupdate == false)
            {
                saveairplane();
            }
            airplanes.Clear();
            foreach (XmlElement plane in planes)
            {
                Console.WriteLine(planes.Count + " Airplanes in xml");
                try
                {
                    Airplane airplane = new Airplane();
                    airplane.arrivalDate = DateTime.Parse(plane.SelectSingleNode("arrivaldate").InnerText);
                    airplane.carrier = plane.SelectSingleNode("carrier").InnerText;
                    airplane.orgin = plane.SelectSingleNode("origin").InnerText;
                    airplane.depatureDate = DateTime.Parse(plane.SelectSingleNode("depaturedate").InnerText);
                    airplane.destination = plane.SelectSingleNode("destination").InnerText;
                    airplane.type = int.Parse(plane.SelectSingleNode("type").InnerText);
                    airplane.id = int.Parse(plane.SelectSingleNode("ID").InnerText);
                    Console.WriteLine("new Airplane loaded:" + Environment.NewLine + "arrival date:" + airplane.arrivalDate + Environment.NewLine
                        + "carrier:" + airplane.carrier + Environment.NewLine + "origin:" + airplane.orgin + Environment.NewLine + "departure date:"
                        + airplane.depatureDate + Environment.NewLine + "destination:" + airplane.destination
                        + Environment.NewLine + "type:" + airplane.type + Environment.NewLine + "ID:" + airplane.id);
                    airplanes.Add(airplane);
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("error loading Airplanes, please check Airplanes.XML");
                }
                catch (FormatException)
                {
                    Console.WriteLine("error loading Airplanes, please check Airplanes.XML");
                }
            }
            Console.WriteLine(airplanes.Count + " Airplanes loaded");
            firstupdate = false;
        }

        public void saveairplane()
        {
            int i = 0;
            foreach (Airplane airplane in airplanes)
            {
                if (airplane.arrivalDate.CompareTo(DateTime.Parse(planes.Item(i).SelectSingleNode("arrivaldate").InnerText)) != 0)
                {
                    Console.Write("airplane" + i.ToString() + "arrivaldate changed");
                    planes.Item(i).SelectSingleNode("arrivaldate").InnerText = airplane.arrivalDate.ToString();
                }
                i++;
            }
            database.Save(@"Simulation\Airplanes.xml");
        }*/
    }
}