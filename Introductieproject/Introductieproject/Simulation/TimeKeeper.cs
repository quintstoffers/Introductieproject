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
        public DateTime simtijd(TimeSpan simulatietijd, DateTime opgeslagentijd, int versnelling)
        {
            double verstrekentijd = simulatietijd.TotalSeconds * versnelling;
            return opgeslagentijd.AddSeconds(verstrekentijd);
            

            
        }
        

       

    }
}
