using Introductieproject.Airport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Objects
{
    abstract class Airplane
    {
        // "Vaste" variabelen die per type zullen verschillen
        public int type;                   // int gedefinieert in enumeratie
        public String manufacturerName;    // Maker vliegtuig
        public String typeName;            // Leesbare string voor weergave

        public int maxSpeed;               // Snelheden in m/s
        public int cruisingSpeed;
        public int takeofSpeed;
        public int taxiSpeed;

        public int maxCapacityKg;

        // Vanaf hier èchte variabelen, per vliegtuig verschillend
        public Company company;            // Eigenaar vliegtuig

        public int state;                  // Huidige staat van het vliegtuig
        public int priority;

        public int passengers;             // Aantal passagiers
        public int luggage;                // Aantal stukken baggage
        public double luggageKg;           // Baggage in kilogram

        public int[] currentGoal;           // Punt waar het ding heen wilt
        public Gate assignedGate;           // Gate waar het vliegtuig heen moet

        /*
         * Initialiseer variabelen
         */
        public void initVariables(Company company, int state, int passengers, int luggage, int luggageKg)
        {
            this.company = company;

            this.state = state;

            this.passengers = passengers;
            this.luggage = luggage;
            this.luggageKg = luggageKg;
        }

        /*
        * Simuleer een stap van grootte realTime milliseconden
        */
        public void simulate(int realTime)
        {
            if (currentGoal == null)
            {

            }
            else
            {

            }
        }
    }
}
