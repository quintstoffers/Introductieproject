using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Introductieproject.Objects;
using System.Reflection;
using System.IO;

namespace Introductieproject.Simulation
{
    class Parser
    {
        XmlDocument database = new XmlDocument();
        List<Airplane> airplanes = new List<Airplane>();
        XmlNodeList planes;
        bool firstupdate = true;
        public Parser()
        {
            try
            {
                database.Load(@"Simulation\Airplanes.xml");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("XML not found");
            }
            planes = database.GetElementsByTagName("plane");
        }

        public string getallplanes()
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
                    airplane.arrivaldate = DateTime.Parse(plane.SelectSingleNode("arrivaldate").InnerText);
                    airplane.carrier = plane.SelectSingleNode("carrier").InnerText;
                    airplane.orgin = plane.SelectSingleNode("origin").InnerText;
                    airplane.depaturedate = DateTime.Parse(plane.SelectSingleNode("depaturedate").InnerText);
                    airplane.destination = plane.SelectSingleNode("destination").InnerText;
                    airplane.type = int.Parse(plane.SelectSingleNode("type").InnerText);
                    airplane.id = int.Parse(plane.SelectSingleNode("ID").InnerText);
                    Console.WriteLine("new Airplane loaded:" + Environment.NewLine + "arrival date:" + airplane.arrivaldate + Environment.NewLine
                        + "carrier:" + airplane.carrier + Environment.NewLine + "origin:" + airplane.orgin + Environment.NewLine + "departure date:"
                        + airplane.depaturedate + Environment.NewLine + "destination:" + airplane.destination
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
                if (airplane.arrivaldate.CompareTo(DateTime.Parse(planes.Item(i).SelectSingleNode("arrivaldate").InnerText)) != 0)
                {
                    Console.Write("airplane" + i.ToString() + "arrivaldate changed");
                    planes.Item(i).SelectSingleNode("arrivaldate").InnerText = airplane.arrivaldate.ToString();
                }
                i++;
            }
            database.Save(@"Simulation\Airplanes.xml");
        }
    }
}