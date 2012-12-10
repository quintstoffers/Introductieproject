using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Introductieproject.Simulation
{
    class parser
    {
        XmlDocument vliegtuigen = new XmlDocument();
     public  parser()
        {
            vliegtuigen.Load(@"Simulation\vliegtuigen.xml");
        }
       public string getallplanes()
        {
            string planes = null;
            XmlNodeList vliegtuig = vliegtuigen.GetElementsByTagName("plane");
            for (int i = 0; i < vliegtuig.Count; i++)
            {
               planes += (vliegtuig[i].InnerText + Environment.NewLine);
            }
            return planes;
        }
    }
}
