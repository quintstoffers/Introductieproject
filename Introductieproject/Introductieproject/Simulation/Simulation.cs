using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
namespace Introductieproject.Simulation
{
    class Simulation
       
    {
        bool simrunning;    //of de simulatie draait of niet(bijv. pauze of gestopt)
        int updateinterval = 1; //update interval van simulatie in sec.
        Stopwatch rekentijd = new Stopwatch();
        Stopwatch simulatieklok = new Stopwatch();
        Thread simulatietijd;
        int aantalstappen = -60; //snelheid waarmee de simulatie draait, realtime = 1 stap per keer. Dit is anders dan de update snelheid!
       TimeKeeper timekeeper = new TimeKeeper();
        DateTime laatstetijd;
        public Simulation()
        {
            simulatietijd = new Thread(simtijd); 

          startsimulatie(); 
           

        }
      void startsimulatie()
      {
          simulatieklok.Start();
          simrunning = true;
          simulatietijd.Start();
          laatstetijd = DateTime.Now;
      }
      void stopsimulatie()
      {
          simulatieklok.Stop();
          simrunning = false;
          simulatietijd.Suspend();
      }
      void wijzigsnelheid(int versnelling)
      {
          laatstetijd = timekeeper.simtijd(simulatieklok.Elapsed, laatstetijd, aantalstappen); //slaat de tijd voor de wijziging van snelheid op
          aantalstappen = versnelling;
      }

    
      void simtijd()
      {
          while (simrunning == true)
          {

              rekentijd.Restart();
              updatesimulatie(aantalstappen);
              laatstetijd =(timekeeper.simtijd(simulatieklok.Elapsed, laatstetijd, aantalstappen));
              Thread.Sleep(TimeSpan.FromMilliseconds(updateinterval * 1000)-rekentijd.Elapsed);
              
          }
         
      }

      void updatesimulatie(int aantalstappen)
      {
          //hierkomen de .simulate methodes
      }
    }
}
