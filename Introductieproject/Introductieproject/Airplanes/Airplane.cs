using Introductieproject.Airplanes;
using Introductieproject.Airport;
using Introductieproject.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Objects
{
    public class Airplane
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
        public TimeSpan delay;
        public TimeSpan difference;
        public int priority;

        public int passengers;              // Aantal passagiers
        public int luggage;                 // Aantal stukken baggage
        public double luggageKg;            // Baggage in kilogram

        public double[] location;           // De huidige locatie van het vliegtuig
        public double speed;                // Snelheid van het vliegtuig
        public double angle;                // hoek van het vliegtuig ten opzichte van noord
        public bool atGate;
        public bool hasDocked = false;      // Houdt bij of een vliegtuig al bij een gate is geweest

        public Navigator navigator;         // Object dat aangeeft waar het vliegtuig heen moet

        // Getters voor UI
        public String Flight
        {
            get
            {
                return flight;
            }
        }
        public String Registration
        {
            get
            {
                return registration;
            }
        }
        public String PlannedArrival
        {
            get
            {
                return arrivalDate.ToString();
            }
        }
        public String PlannedDeparture
        {
            get
            {
                return departureDate.ToString();
            }
        }
        public String CurrentDelay
        {
            get
            {
                TimeSpan totaldelay = new TimeSpan();
                totaldelay = delay + difference;

                //afronden op seconden.
                TimeSpan roundeddelay = new TimeSpan(totaldelay.Ticks - (totaldelay.Ticks % 100000));

                return roundeddelay.ToString();
            }
        }

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
                    this.dock();
                }
                else
                {
                    double distanceToTarget = navigator.getDistanceToTargetNode(location);
                    navigator.distanceToTarget = distanceToTarget;
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

        /*
         * Wat er moet gebeuren als het vliegtuig bij de gate staat.
        */
        public void dock()
        {
            atGate = true;

            //Check wanneer vliegtuig is aangekomen.
            actualArrivalDate = TimeKeeper.currentSimTime;

            Console.WriteLine("SIMARRIVALTIME: " + actualArrivalDate);
            Console.WriteLine("ARRIVALDATE: " + arrivalDate);

            //Bereken verschil in verwachte vertrektijd en verwachte aankomst tijd.
            if (actualArrivalDate > arrivalDate)
            {
                difference = actualArrivalDate.Subtract(arrivalDate);
            }
            //Vliegtuig is te vroeg/op tijd, dus alles via planning
            else if (actualArrivalDate <= arrivalDate)
            {
                difference = new TimeSpan();
            }
            Console.WriteLine("DIFFERENCE: " + difference);

            // Random delay van 0-100.
            // Statistieken van http://www.flightstats.com/go/FlightRating/flightRatingByRoute.do
            // Meeste vliegtuigmaatschappijen zitten 4% veel te laat; ~3% te laat; ~10% iets te laat; ~80% op tijd.
            delay = new TimeSpan();
            Random random = new Random();
            int cases = random.Next(1, 100);

            // 4% kans op 5 uur delay
            if (cases <= 4)
            {
                delay = new TimeSpan(5, 0, 0);
            }

            // 3% kans op 2 uur delay
            else if (cases < 4 && cases <= 7)
            {
                delay = new TimeSpan(2, 0, 0);
            }

            // 2% kans op 45 minuten delay
            else if (cases > 7 && cases <= 9)
            {
                delay = new TimeSpan(0, 45, 0);
            }

            // 5% kans op 30 minuten delay
            else if (cases > 9 && cases <= 14)
            {
                delay = new TimeSpan(0, 30, 0);
            }

            //3% kans op 15 minuten delay
            else if (cases > 14 && cases <= 17)
            {
                delay = new TimeSpan(0, 15, 0);
            }

            else
            {
                // Geen delay
            }

            Console.WriteLine("DELAY: " + delay);


            //Tel absoluut verschil op bij de echte simulatietijd.
            //Nieuwe vertrektijd is difference + delay + oude vertrektijd.
            Console.WriteLine("DEPARTUREDATE: " + departureDate);
            actualDepartureDate = departureDate.Add(difference + delay);
            Console.WriteLine("actualDepartureDate: " + actualDepartureDate);

            // Zet hasDocked op true voor de navigator.
            hasDocked = true;
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


            // Hier kan eventueel ook nog wel ergens de landing/takeoff snelheid bij komen?

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
