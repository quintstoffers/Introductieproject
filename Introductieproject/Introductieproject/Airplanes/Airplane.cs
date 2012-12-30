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
        // "Vaste" variabelen die per type vliegtuig zullen verschillen (defined in subclasse!)
        public String manufacturerName;     // Maker vliegtuig
        public String typeName;             // Leesbare string voor weergave
        public int maxSpeed;                // Snelheden in m/s
        public int cruisingSpeed;
        public int takeofSpeed;
        public int taxiSpeed;

        // Hier variabelen die per individueel vliegtuig verschillen (defined in XML)
        public String registration;
        public String flight;
        public DateTime arrivalDate;
        public DateTime departureDate;
        public string carrier;
        public string destination;
        public string origin;

        // Vanaf hier èchte variabelen, per vliegtuig verschillen (defined tijdens aanwezigheid op vliegveld)
        public Boolean wasSetup = false;    // op true zodra onderstaande variabelen gedefinieerd zijn
        public DateTime actualArrivalDate;
        public DateTime actualDepartureDate;
        public int priority;

        public int passengers;              // Aantal passagiers
        public int luggage;                 // Aantal stukken baggage
        public double luggageKg;            // Baggage in kilogram

        public double[] location;           // De huidige locatie van het vliegtuig
        public double speed;                // Snelheid van het vliegtuig
        public double angle;                // hoek van het vliegtuig ten opzichte van noord
        public bool atGate;


        public bool hasDocked = false;      // Houdt bij of een vliegtuig al bij een gate is geweest

        public Navigator navigator;                // Object dat aangeeft waar het vliegtuig heen moet

        public double distanceToTarget;
        /*
         * Initialiseer variabelen
         */
        public void setXMLVariables(DateTime arrivalDate, DateTime departureDate, String registration, String flight, String carrier, String origin, String destination)
        {
            this.registration = registration;
            this.flight = flight;
            this.carrier = carrier;
            this.arrivalDate = arrivalDate;
            this.departureDate = departureDate;
        }
        public void setStateVariables(double[] location, double speed, int angle, int passengers, int luggage, int luggageKg)
        {
            this.location = location;
            this.speed = speed;
            this.passengers = passengers;
            this.luggage = luggage;
            this.luggageKg = luggageKg;
            this.wasSetup = true;
        }

        public void Dock()
        {
            atGate = true;
            
            //TODO: Vliegtuig krijgt geen arrival/departuredate mee.
            //For testing purpose: zelf instellen

            arrivalDate = new DateTime(2012, 12, 28, 16, 00, 00, 00);
            departureDate = new DateTime(2012, 12, 28, 16, 00, 30, 00);

            actualArrivalDate = TimeKeeper.currentSimTime;

            //Check wanneer vliegtuig is aangekomen.
            Console.WriteLine("SIMARRIVALTIME: " + actualArrivalDate);
            Console.WriteLine("ARRIVALDATE: " + arrivalDate);

            //Bereken verschil in verwachte vertrektijd en verwachte aankomst tijd.
            TimeSpan difference = new TimeSpan();
            if (actualArrivalDate >= arrivalDate)
            {
                difference = actualArrivalDate.Subtract(arrivalDate);
            }
            else if (actualArrivalDate < arrivalDate)
            {
                difference = arrivalDate.Subtract(actualArrivalDate);
            }
            Console.WriteLine("DIFFERENCE: " + difference);

            // Random delay van 0-100. 
            TimeSpan delay = new TimeSpan();
            Random random = new Random();
            int cases = random.Next(0, 100);

            // 1% kans op 5 uur delay
            if (cases <= 1)
            {
                delay = new TimeSpan(5, 0, 0);
            }

            // 2% kans op 2 uur delay
            else if (cases < 1 && cases <= 3)
            {
                delay = new TimeSpan(2, 0, 0);
            }

            // 2% kans op 1 uur delay
            else if (cases > 3 && cases <= 5)
            {
                delay = new TimeSpan(1, 0, 0);
            }

            // 5% kans op 30 minuten delay
            else if (cases > 5 && cases <= 10)
            {
                delay = new TimeSpan(0, 30, 0);
            }

            //10% kans op 10 minuten delay
            else if (cases > 10 && cases <= 20)
            {
                delay = new TimeSpan(0, 10, 0);
            }

            //10% kans op 5 minuten delay
            else if (cases > 20 && cases <= 30)
            {
                delay = new TimeSpan(0, 5, 0);
            }

            else if (cases > 30)
            {
                // Geen delay
            }
            Console.WriteLine("DELAY: " + delay);


            //Tel absoluut verschil op bij de echte simulatietijd.
            //Nieuwe vertrektijd is difference + oude vertrektijd.
            Console.WriteLine("DEPARTUREDATE: " + departureDate);
            actualDepartureDate = departureDate.Add(difference + delay);
            Console.WriteLine("actualDepartureDate: " + actualDepartureDate);

            //navigator = null;
            hasDocked = true;

            /*  Zolang de benodigde tijd voor het vliegtuig nog niet is verstreken, blijft deze in een loop.
             *  TODO: Niet pauzeerbaar tijdens de loop. 
             *  Timekeeper update niet tijdens loop. Moet handmatig worden ingevoerd.
             */
        }

        /*
        * Simuleer een stap van grootte realTime milliseconden
        */
        public void simulate()
        {
            // vliegtuig hoort geen navigator te hebben: bij gate.
            if (atGate)
                {
                    //Vliegtuig vertrek als de newactualDepartureDate gelijk is aan de currentSimTime.
                    if (TimeKeeper.currentSimTime >= actualDepartureDate)
                    {
                        atGate = false;  //Vliegtuig moet weer naar Runway
                        navigator = null;
                    }
                    // geef nieuwe navigator aan vliegtuig.
                }
            else if (navigator == null)
            {
                // of vliegtuig heeft nog geen route gekregen
            }
            else
            {
                Node targetNode = navigator.getTargetNode();
                if (targetNode == null)
                {
                    //wanneer de targetnode null is, betekent het dat de navigator bij zijn eindpunt is aangekomen
                    this.Dock();
                }
                else
                {
                    distanceToTarget = navigator.getDistanceToTargetNode(location);
                    navigator.distanceToTarget = this.distanceToTarget;
                    double targetAngle = navigator.getAngleToTarget(location);

                    Console.WriteLine("Airplane target  : " + targetNode.ToString());
                    Console.WriteLine("  target distance: " + distanceToTarget);
                    Console.WriteLine("     target angle: " + targetAngle);

                    //maximumsnelheid staat nu vast op 10m/s, dat moet per baan verschillend worden. Snelheid in bochten staat vast op 3m/s
                    double maxSpeed = 50;
                    double cornerSpeed = 1;
                    navigator.location = this.location;

                    if (navigator.collisionDetection() == true)
                    {
                        if (distanceToTarget < 0.5)
                        {
                            if (navigator.hasPermission() == true)
                            {
                                navigator.setNextTarget();
                                targetNode = navigator.getTargetNode();
                                if (targetNode == null)
                                {
                                    //wanneer de targetnode null is, betekent het dat de navigator bij zijn eindpunt is aangekomen
                                    hasDocked = true;

                                }
                                if (navigator != null)
                                    distanceToTarget = navigator.getDistanceToTargetNode(location);
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
            double acceleration = 5;        // 1 m/s2, acceleratie moet afhankelijk worden van target snelheid en max acceleratie. Eventueel van de weg waarop vliegtuig rijdt.
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
