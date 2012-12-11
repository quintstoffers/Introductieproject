using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Introductieproject.Simulation
{
    class Parser
    {
        XmlDocument database = new XmlDocument();
        public  Parser()
        {
            database.Load(@"Simulation\vliegtuigen.xml");
        }
        
        public string getallplanes()
        {
            string planes = null;
            XmlNodeList plane = database.GetElementsByTagName("plane");
            for (int i = 0; i < plane.Count; i++)
            {
               planes += (plane[i].InnerText + Environment.NewLine);
            }
            return planes;
        }

        public string getcarrier(int id)
        {
           string planes = null;
           XmlNodeList plane = database.GetElementsByTagName("plane");
           //plane[0].

           return planes;
        }
       
    }
}
