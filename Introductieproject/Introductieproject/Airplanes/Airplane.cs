using Introductieproject.Airplanes;
using Introductieproject.Airport;
using Introductieproject.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Objects
{
    class Airplane
    {
        // "Vaste" variabelen die per type zullen verschillen
        public int type;                   // int gedefinieert in enumeratie
        public String manufacturerName;    // Maker vliegtuig
        public String typeName;  // Leesbare string voor weergave
        public DateTime arrivaldate;
        public DateTime depaturedate;
        public string carrier;
        public string destination;
        public string orgin;
        public int maxSpeed;               // Snelheden in m/s
        public int cruisingSpeed;
        public int takeofSpeed;
        public int taxiSpeed;
        public int id;
        public int maxCapacityKg;

        // Vanaf hier èchte variabelen, per vliegtuig verschillend
        public Company company;            // Eigenaar vliegtuig

        public int state;                  // Huidige staat van het vliegtuig
        public int priority;

        public int passengers;             // Aantal passagiers
        public int luggage;                // Aantal stukken baggage
        public double luggageKg;           // Baggage in kilogram

        public Gate assignedGate;           // Gate waar het vliegtuig heen moet

        public double[] location;              // De huidige locatie van het vliegtuig
        public double speed;                // Snelheid van het vliegtuig
        public double angle;                // hoek van het vliegtuig ten opzichte van noord

        public bool hasDocked = false;      // Houdt bij of een vliegtuig al bij een gate is geweest

        public Navigator navigator;                // Object dat aangeeft waar het vliegtuig heen moet

        /*
         * Initialiseer variabelen
         */
        public void initVariables(double[] location, double speed, int angle, Company company, int state, int passengers, int luggage, int luggageKg)
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
                Node targetNode = navigator.getTargetNode();
                double distanceToTarget = navigator.getDistanceToTargetNode(location);
                double targetAngle = navigator.getAngleToTarget(location);

                Console.WriteLine("Airplane target  : " + targetNode.ToString());
                Console.WriteLine("  target distance: " + distanceToTarget);
                Console.WriteLine("     target angle: " + targetAngle);

                //maximumsnelheid staat nu vast op 10m/s, dat moet per baan verschillend worden. Snelheid in bochten staat vast op 3m/s
                double maxSpeed = 10;
                double cornerSpeed = 3;

                if(Utils.getDistanceBetweenPoints(location, targetNode.location) < 50) // In de toekomst is het netter als als navigator dit doet!
                {
                    navigator.setNextTarget();
                    targetNode = navigator.getTargetNode();
                    distanceToTarget = navigator.getDistanceToTargetNode(location);
                }

                /*  else if(location == closeToWayPoint)
                 *      deaccelerate naar bochtsnelheid
                */

                /*  if(! middenOpBaan)
                 *      roteer richting midden van baan (prioriteit over rijden naar target!
                */
                 
                if (angle != targetAngle)  // Vliegtuig staat niet in de goede richting, roteren
                {
                    rotate(targetAngle);
                }

                if (speed < maxSpeed)
                {
                    accelerate(maxSpeed);
                }
                else
                {
                    move();
                }

                Console.WriteLine(this.ToString());
            }
        }

        private void rotate(double targetAngle)
        {
            Console.WriteLine("Airplane currentRot: " + angle + " targetRot: " + targetAngle);
            Console.WriteLine("Ticks:" + TimeKeeper.elapsedSimTime.Ticks);
            double rotation = rotationSpeed(angle, targetAngle) * (TimeKeeper.elapsedSimTime.Ticks / 1000000);           // Rotatie per seconde in graden
            if(targetAngle < angle)
            {
                if (angle - targetAngle > 180) //Als het verschil meer dan 180 is, dan is het korter om de andere kant om te draaien
                {
                    Console.WriteLine("Airplane rotate +");
                    angle += rotation;
                    if (angle > 360)
                        angle = angle - 360;    //Als je een heel rondje hebt gedraaid is het tijd om weer bij 0 te beginnen
                }

                Console.WriteLine("Airplane rotate -");
                angle -= rotation;
                if (angle < targetAngle)
                    angle = targetAngle; //Op het moment dat je je targetAngle voorbij gaat omdat je niet met stappen van 1 gaat, moet je daarvoor compenseren
            }
            else if (targetAngle > angle)
            {
                if (targetAngle - angle > 180)  //Als angle = 10 && targetAngle = 350 bijv, wil je - draaien, niet +
                {
                    Console.WriteLine("Airplane rotate -");
                    angle -= rotation;
                    if (angle < 0)
                        angle = 360 + angle;    //Als je langs de 0 komt, dan ga je van bovenaf naar beneden
                }
                else
                {
                    Console.WriteLine("Airplane rotate +");
                    angle += rotation;
                    if (angle > targetAngle)
                        angle = targetAngle;
                }
            }
            else
            {
                Console.WriteLine("Airplane rotate done");
                angle = targetAngle;
            }
        }

        private double rotationSpeed(double targetAngle, double angle)
        {
            double angleDifference = Math.Abs(angle - targetAngle);
            if (angleDifference > 180)
                angleDifference = 360 - angleDifference;
            double rotation = (180 / angleDifference);
            return rotation;
        }

        private void accelerate(double targetSpeed)
        {
            double acceleration = 1;        // 1 m/s2, acceleratie moet afhankelijk worden van target snelheid en max acceleratie. Eventueel van de weg waarop vliegtuig rijdt.
            double totalAcceleration = acceleration * TimeKeeper.elapsedSimTime.Seconds;

            double oldSpeed = speed;

            speed += acceleration;

            if (speed > targetSpeed)
            {
                speed = targetSpeed;
            }

            Console.WriteLine("Airplane accelerate to " + speed + " m/s");

            double averageSpeed = (oldSpeed + speed) / 2;
            double distanceTraveled = TimeKeeper.elapsedSimTime.Seconds * averageSpeed;
            moveBy(distanceTraveled);
        }

        private void deaccelerate(double targetSpeed)
        {
            double acceleration = -1;       // 1 m/s2, acceleratie moet afhankelijk worden van target snelheid en max acceleratie. Eventueel van de weg waarop vliegtuig rijdt.
            double totalAcceleration = acceleration * TimeKeeper.elapsedSimTime.Seconds;

            double oldSpeed = speed;

            speed += acceleration;

            if (speed < targetSpeed)
            {
                speed = targetSpeed;
            }


            Console.WriteLine("Airplane deaccelerate to " + speed + " m/s");

            double averageSpeed = (oldSpeed + speed) / 2;
            double distanceTraveled = TimeKeeper.elapsedSimTime.Seconds * averageSpeed;
            moveBy(distanceTraveled);
        }

        private void move()
        {
            double movement = TimeKeeper.elapsedSimTime.Seconds * speed;

            moveBy(movement);
        }

        private void moveBy(double movement)
        {
            int movementX = (int) (Math.Cos(angle) * movement);
            int movementY = (int) (Math.Sin(angle) * movement);

            location[0] += movementX;
            location[1] += movementY;

            Console.WriteLine("Airplane moved by: " + movement);
        }

        public override string ToString()
        {
            return "AIRPLANE: " + typeName + ". location=(" + location[0] + ", " + location[1] + "), speed=" + speed + ", angle=" + angle;
        }
    }

}
