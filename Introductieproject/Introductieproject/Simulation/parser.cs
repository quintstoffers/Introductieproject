using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Introductieproject.Objects;

namespace Introductieproject.Simulation
{
    class Parser
    {
        XmlDocument database = new XmlDocument();
        Airplane airplane;
        List<Airplane> airplanes = new List<Airplane>();
        public Parser()
        {
            database.Load(@"Simulation\vliegtuigen.xml");
        }

        public string getallplanes()
        {
            string planes = null;
           XmlNodeList planename = database.SelectNodes("//data/planes/plane/number/text()");
            for (int i = 0; i < planename.Count; i++)
            {
                if (i != planename.Count -1)
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

        public void update()
    {
        XmlNodeList planes = database.GetElementsByTagName("plane");
        int amount = planes.Count;
        for (int i = 0; i < amount; i++)
        {
            
            int amountvar = planes.Item(i).ChildNodes.Count;
            for (int x = 0; x < amountvar; x++)
            {
                airplanes.Add(airplane);
                string variable = (planes.Item(i).ChildNodes.Item(x).Name);
                string value = (planes.Item(i).ChildNodes.Item(x).InnerText);
                Console.WriteLine(variable + value);
            }
        }

    }

    }
}