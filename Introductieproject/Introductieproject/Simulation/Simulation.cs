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
        DateTime huidigetijd;
        Forms.MainForm mainform = new Forms.MainForm();
        public Simulation()
        {
            simulatietijd = new Thread(simtijd);
            mainform.Show();
          startsimulatie(); 
           

        }
      void startsimulatie()
      {
          simulatieklok.Start();
          simrunning = true;
          simulatietijd.Start();
          huidigetijd = DateTime.Now;
      }
      void stopsimulatie()
      {
          simulatieklok.Stop();
          simrunning = false;
          simulatietijd.Suspend();
      }

    
      void simtijd()
      {
          while (simrunning == true)
          {
              rekentijd.Restart();
              huidigetijd = huidigetijd.AddSeconds(aantalstappen);
              Console.WriteLine(huidigetijd);
              Thread.Sleep(updateinterval * 1000);
          }
         
      }

      void updatesimulatie(int aantalstappen)
      {
          //hierkomen de .simulate methodes
      }
    }
}
