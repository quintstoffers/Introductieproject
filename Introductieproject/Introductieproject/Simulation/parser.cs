using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Introductieproject.Objects;
using System.Reflection;

namespace Introductieproject.Simulation
{
    class Parser
    {
        XmlDocument database = new XmlDocument();
        BO_747 B747 = new BO_747();
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
        switch (planes.Item(0).SelectSingleNode("type").InnerText)
        {
            case "747": Console.WriteLine(747);
                fill747();
                break;
            default: Console.WriteLine("unknown planetype");
                break;

            

        }
    }
        private void fill747()
        {
             XmlNodeList planes = database.GetElementsByTagName("plane");
             Type type = typeof(BO_747);
             FieldInfo variable = type.GetField("taxiSpeed");
             variable.SetValue(B747, 3);
             Console.WriteLine(variable.GetValue(B747).ToString());
             foreach (XmlNode plane in planes)
             {

             }
        }

    }
}