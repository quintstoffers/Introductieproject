using Introductieproject.Airplanes;
using Introductieproject.Airport;
using Introductieproject.Simulation;
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
        public DateTime arrivaldate;
        public DateTime depaturedate;
        public string destination;
        public string orgin;
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

        public Gate assignedGate;           // Gate waar het vliegtuig heen moet

        public int[] location;              // De huidige locatie van het vliegtuig
        public double speed;                // Snelheid van het vliegtuig
        public int angle;                   // hoek van het vliegtuig ten opzichte van noord

        public bool hasDocked = false;      // Houdt bij of een vliegtuig al bij een gate is geweest

        public Navigator navigator;                // Object dat aangeeft waar het vliegtuig heen moet

        /*
         * Initialiseer variabelen
         */
        public void initVariables(int[] location, double speed, int angle, Company company, int state, int passengers, int luggage, int luggageKg)
        {
            this.location = location;
            this.speed = speed;
            this.company = company;
            this.state = state;
            this.passengers = passengers;
            this.luggage = luggage;
            this.luggageKg = luggageKg;
        }

        /*
        * Simuleer een stap van grootte realTime milliseconden
        */
        public void simulate()
        {
            if (navigator == null)
            {
                // vliegtuig heeft nog geen route gekregen
            }
            else
            {
                //maximumsnelheid staat nu vast op 10m/s, dat moet per baan verschillend worden. Snelheid in bochten staat vast op 3m/s
                double maxSpeed = 10;
                double cornerSpeed = 3;
                /*
                 * if(location is binnen 20m? van waypoint && !angle == angleNaarVolgendeWaypoint)
                 *      roteer in richting van nieuwe angle
                */

                /*  else if(location == closeToWayPoint)
                 *      deaccelerate naar bochtsnelheid
                */

                if(speed < maxSpeed)
                {
                    accelerate(maxSpeed);
                }                
            }
        }

        private void rotate(int targetAngle)
        {

        }

        private void accelerate(double targetSpeed)
        {

        }

        private void deaccelerate(double targetSpeed)
        {

        }

        private void move()
        {
            double movement = TimeKeeper.elapsedSimTime.Seconds * speed;

            int movementX = (int) (Math.Cos(angle) * movement);
            int movementY = (int) (Math.Sin(angle) * movement);
            
        }

        public override string ToString()
        {
            return "AIRPLANE: " + typeName + ". location=(" + location[0] + ", " + location[1] + "), speed=" + speed;
        }
    }

}
