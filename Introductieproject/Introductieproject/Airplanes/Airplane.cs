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

        public double distanceToTarget;
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
                if (targetNode == null)
                {
                    //wanneer de targetnode null is, betekent het dat de navigator bij zijn eindpunt is aangekomen
                    hasDocked = true;
                    navigator = null;
                }
                else
                {
                    distanceToTarget = navigator.getDistanceToTargetNode(location);
                    double targetAngle = navigator.getAngleToTarget(location);

                    Console.WriteLine("Airplane target  : " + targetNode.ToString());
                    Console.WriteLine("  target distance: " + distanceToTarget);
                    Console.WriteLine("     target angle: " + targetAngle);

                    //maximumsnelheid staat nu vast op 10m/s, dat moet per baan verschillend worden. Snelheid in bochten staat vast op 3m/s
                    double maxSpeed = 10;
                    double cornerSpeed = 1;

                    if (distanceToTarget < 0.5)
                    {
                        while (true)
                        {
                            if (navigator.hasPermission() == true)
                            {
                                navigator.setNextTarget();
                                targetNode = navigator.getTargetNode();
                                if (targetNode == null)
                                {
                                    //wanneer de targetnode null is, betekent het dat de navigator bij zijn eindpunt is aangekomen
                                    hasDocked = true;
                                    navigator = null;
                                }
                                if (navigator != null)
                                    distanceToTarget = navigator.getDistanceToTargetNode(location);
                                break;
                            }
                        }
                    }
                    if (navigator != null)
                    {
                        if (distanceToTarget < speed)
                        {
                            moveBy(distanceToTarget);
                            speed = 0;
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

                        if (speed < maxSpeed && distanceToTarget > 50 && angle == targetAngle)
                        {
                            accelerate(maxSpeed);
                        }

                        else if (speed > cornerSpeed && distanceToTarget <= 50 && angle == targetAngle)
                        {
                            accelerate(cornerSpeed);
                        }
                        //alleen move als hij niet heeft versneld of afgeremd
                        else if (angle == targetAngle)
                        {
                            move();
                        }

                        Console.WriteLine(this.ToString());
                        Console.WriteLine("");
                    }
                }
            }
        }

        private void rotate(double targetAngle)
        {
            //Console.WriteLine("Airplane currentRot: " + angle + " targetRot: " + targetAngle);
            double rotation = rotationSpeed(targetAngle, angle) * (TimeKeeper.elapsedSimTime.Ticks / 1000000);           // Rotatie per seconde in graden
            if (targetAngle < angle)
            {
                if (angle - targetAngle > 180) //Als het verschil meer dan 180 is, dan is het korter om de andere kant om te draaien
                {
                    angle += rotation;
                }
                else if (angle - targetAngle <= 180)
                {
                    if (angle - targetAngle < rotation)
                    {
                        angle -= angle - targetAngle;
                    }
                    else
                    {
                        angle -= rotation;
                    }
                }
            }
            else if (targetAngle > angle)
            {
                if (targetAngle - angle > 180)  //Als angle = 10 && targetAngle = 350 bijv, wil je - draaien, niet +
                {
                    angle -= rotation;
                }
                else if (targetAngle - angle <= 180)
                {
                    if (targetAngle - angle < rotation)
                    {
                        angle += targetAngle - angle;
                    }
                    else
                    {
                        angle += rotation;
                    }
                }
            }
            else
            {
                angle = targetAngle;
            }
            if (angle < 0)
                angle = 360 + angle;    //Als je langs de 0 komt, dan ga je van bovenaf naar beneden
            if (angle > 360)
                angle = angle - 360;
        }

        private double rotationSpeed(double targetAngle, double angle)
        {
            double angleDifference = Math.Abs(angle - targetAngle);
            if (angleDifference > 180)
                angleDifference = 360 - angleDifference;
            if (angleDifference > 10) return 1;
            else return angleDifference / 10;
        }

        private void accelerate(double targetSpeed)
        {
            double acceleration = 1;        // 1 m/s2, acceleratie moet afhankelijk worden van target snelheid en max acceleratie. Eventueel van de weg waarop vliegtuig rijdt.
            if (targetSpeed < speed) 
                acceleration = -1; // in het geval dat je moet afremmen
            double totalAcceleration = acceleration * TimeKeeper.elapsedSimTime.Seconds;

            double oldSpeed = speed;

            speed += acceleration;

            if (speed > targetSpeed && oldSpeed < targetSpeed)
            {
                //Als je overversneld hebt
                speed = targetSpeed;
            }
            else if (speed < targetSpeed && oldSpeed > targetSpeed)
            {
                //Als je te veel hebt afgeremd
                speed = targetSpeed;
            }

            Console.WriteLine("Airplane accelerate to " + speed + " m/s");

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
            double movementX = Math.Cos(angle * (Math.PI / 180)) * movement;
            double movementY = Math.Sin(angle * (Math.PI / 180)) * movement;

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
