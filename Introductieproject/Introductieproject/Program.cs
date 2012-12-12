using Introductieproject.Forms;
using Introductieproject.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Introductieproject
{
    class Program
    {
        private static MainForm mainform = new MainForm();
        private static Airport.Airport airport;

        static void Main(string[] args)
        {
            Console.WriteLine("Program started");

            airport = new Airport.Airport();

            Simulation.Simulation simulation = new Simulation.Simulation(airport);

            mainform.Show();

        }
    }
}
