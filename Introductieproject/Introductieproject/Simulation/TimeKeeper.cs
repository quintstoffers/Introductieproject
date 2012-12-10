using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Introductieproject.Simulation
{
    
    class TimeKeeper
    {
        public DateTime simtijd(TimeSpan simulatietijd, DateTime starttijd, int versnelling)
        {
            double verstrekentijd = simulatietijd.TotalSeconds * versnelling;
           return  starttijd.AddSeconds(verstrekentijd);
            

            
        }
        

       

    }
}
