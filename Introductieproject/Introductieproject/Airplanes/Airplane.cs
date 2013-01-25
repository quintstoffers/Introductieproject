using Introductieproject.Airplanes;
using Introductieproject.Airport;
using Introductieproject.Forms;
using Introductieproject.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Introductieproject.Objects
{
    public class Airplane
    {
        public enum Status
        {
            APPROACHING = 0,
            DOCKING,
            WAITING_TAKEOFF,
            TAXIING,
            TAKINGOFF,
            DEPARTED,
            CANCELLED
        }

        // "Vaste" variabelen die per type vliegtuig zullen verschillen (defined in subclasse!)
        public String manufacturerName;     // Maker vliegtuig
        public String typeName;             // Leesbare string voor weergave
        public int taxiSpeed;                // Snelheden in m/s
        public int takeofSpeed;

        // Hier variabelen die per individueel vliegtuig verschillen (defined in XML)
        public String registration;
        public String flight;
        public DateTime landingDate;
        public DateTime arrivalDate;
        public DateTime departureDate;
        public string gate;
        public string carrier;
        public string destination;
        public string origin;

        // Vanaf hier èchte variabelen, per vliegtuig verschillen (defined tijdens aanwezigheid op vliegveld)
        public DateTime actualLandingDate;
        public DateTime actualArrivalDate;
        public DateTime actualDepartureDate;
        public TimeSpan delay;
        public TimeSpan arrivalDifference;
        public TimeSpan landingDifference;
        public int priority;

        public double[] location;           // De huidige locatie van het vliegtuig
        public double speed;                // Snelheid van het vliegtuig
        public double angle;                // hoek van het vliegtuig ten opzichte van noord
        public bool hasDocked = false;      // Houdt bij of een vliegtuig al bij een gate is geweest
        public bool hasCollision = false;   // Houdt bij of er collision is
        public bool isWaiting = false;      // Houdt bij of deze voor de gate wacht
        public bool askAgain = true;        // Houdt bij of er opnieuw gevraagd moet worden voor rescheduling
        private bool standingStill = false;
        public bool cancelled = false;

        public Status status;
        public String statusString
        {
            get
            {
                switch(status)
                {
                    case Status.APPROACHING:
                        return "Approaching";
                    case Status.CANCELLED:
                        return "Cancelled";
                    case Status.DEPARTED:
                        return "Departed";
                    case Status.DOCKING:
                        return "Docking";
                    case Status.TAXIING:
                        return "Taxiing";
                    case Status.TAKINGOFF:
                        return "Taking off";
                    case Status.WAITING_TAKEOFF:
                        return "Waiting for takeoff";
                }
                return "Unknown";
            }
        }

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
                TimeSpan totaldelay = new TimeSpan();
                totaldelay = delay + arrivalDifference + landingDifference;

                return (departureDate + totaldelay).ToString();
            }
        }
        public String Angle
        {
            get
            {
                return Math.Round(angle + 90).ToString();
            }
        }
        public String CurrentDelay
        {
            get
            {
                TimeSpan totaldelay = new TimeSpan();
                totaldelay = delay + arrivalDifference + landingDifference;

                //afronden op seconden.
                TimeSpan roundedDelay = new TimeSpan(totaldelay.Ticks - (totaldelay.Ticks % 10000000));

                return roundedDelay.ToString();
            }
        }

        /*
         * Initialiseer variabelen
         */
        public void setXMLVariables(double[] landingLocation, DateTime landingDate, String gate, DateTime arrivalDate, DateTime departureDate, String registration, String flight, String carrier, String origin, String destination)
        {
            this.registration = registration;
            this.flight = flight;
            this.carrier = carrier;
            this.landingDate = landingDate;
            this.arrivalDate = arrivalDate;
            this.departureDate = departureDate;
            this.location = landingLocation;
            this.gate = gate;

            this.status = Status.APPROACHING;
        }
        public void setStateVariables(double speed, int angle)
        {
            this.speed = 90;
            this.angle = navigator.getAngleToTarget(this.location);
        }

        /*
        * Simuleer een stap van grootte realTime milliseconden
        */
        private Boolean isSimulating = false;
        public void simulate(Airport.Airport airport)
        {
            if (isSimulating)
            {
                return;
            }
            isSimulating = true;

            if (status == Status.CANCELLED)
            {
                //Hij doet niets meer als hij gecancelled is
            }
            else if (status == Status.APPROACHING)       // Vliegtuig is nog niet aangekomen
            {
                if (TimeKeeper.currentSimTime >= this.landingDate)
                {
                    if (this.navigator == null)
                    {
                        requestNavigator(airport);
                    }
                    if (requestWayAccess(airport, this.navigator.currentWay, this.navigator.getTargetNode()))
                    {
                        this.land();
                    }
                }
            }
            else if (status == Status.DEPARTED)
            {
            }
            else if (status == Status.DOCKING)      // Vliegtuig staat bij gate
            {
                if (cancelled)
                    status = Status.CANCELLED;
                if (TimeKeeper.currentSimTime >= actualDepartureDate)
                {
                    leaveDock();
                    requestNavigator(airport);
                }
            }
            else if (status == Status.WAITING_TAKEOFF)    // Vliegtuig wacht voordat hij mag opstijgen
            {
                speed = 0;
                requestTakeOff(airport);
            }
            else if (status == Status.TAKINGOFF)
            {
                double targetAngle = navigator.getAngleToTarget(location);
                if (angle != targetAngle)
                    rotate(targetAngle);
                else if (angle == targetAngle)
                {
                    this.accelerate(takeofSpeed);
                    if (this.speed == takeofSpeed)
                    {
                        takeOff();
                    }
                }
            }
            else if (navigator == null)
            {
                requestNavigator(airport);
            }
            else if (status == Status.TAXIING)
            {
                //status = Status.IDLE;

                Node targetNode = navigator.getTargetNode();

                if (targetNode == null)
                {
                    //wanneer de targetnode null is, betekent het dat de navigator bij zijn eindpunt is aangekomen
                    if (!hasDocked)
                    {
                        dock();
                    }
                }
                else
                {
                    double distanceToTarget = navigator.getDistanceToTargetNode(location);
                    double targetAngle = navigator.getAngleToTarget(location);

                    //maximumsnelheid staat nu vast op 10m/s, dat moet per baan verschillend worden. Snelheid in bochten staat vast op 3m/s
                    taxiSpeed = 20;
                    //if (navigator.getCurrentWay() is Gateway)

                    double cornerSpeed = 3;
                    navigator.location = this.location;

                    //TODO collision test
                    if (distanceToTarget < 20)
                    {
                        if (this.hasDocked && navigator.targetWay is Runway)
                        {
                            requestWayAccess(airport, navigator.targetWay, navigator.getTargetNode());
                            prepareTakeOff();
                        }

                        else if (navigator.hasNextTarget())
                        {

                            if (requestWayAccess(airport, navigator.targetWay, targetNode)) // Toestemming verzoeken voor volgende way
                            {
                                navigator.setNextTarget();
                            }
                            else if (!requestWayAccess(airport, navigator.targetWay, navigator.getTargetNode()) && navigator.getTargetWay() is Gate)
                            {
                                foreach (Airplane dockedPlane in airport.airplanes)
                                {
                                    // Als er al een vliegtuig staat bij de gate waar dit vliegtuig naartoe wilt, en de vertrektijd ligt na de verwachtte aankomst tijd: Open edit scherm voor nieuwe gate.
                                    if (dockedPlane.gate == this.gate && dockedPlane.isOnAirport() && (dockedPlane.status == Status.DOCKING || dockedPlane.status == Status.CANCELLED))
                                    {
                                        if (this.arrivalDate < dockedPlane.actualDepartureDate)
                                        {
                                            this.isWaiting = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                this.accelerate(cornerSpeed);
                                //speed = 0;
                            }
                        }
                    }

                    if (distanceToTarget <= 0.5)
                    {
                        if (this.hasDocked && navigator.targetWay is Runway)
                        {
                            requestWayAccess(airport, navigator.targetWay, navigator.getTargetNode());
                            prepareTakeOff();
                        }
                        
                        if (requestWayAccess(airport, navigator.targetWay, navigator.getTargetNode()) && navigator.currentWay is Gate) // Toestemming verzoeken voor volgende way
                        {
                            if (!hasDocked)
                            {
                                if (Utils.getDistanceBetweenPoints(location,navigator.getFinalNode().location) < 0.5)
                                    dock();
                            }
                        }
                    }

                    if (distanceToTarget <= speed * TimeKeeper.elapsedSimTime.TotalSeconds)
                    {
                        moveBy(distanceToTarget);
                        speed = 0;
                    }

                    if (speed > taxiSpeed)
                    {
                        accelerate(taxiSpeed);
                    }

                    if (angle != targetAngle)  // Vliegtuig staat niet in de goede richting, roteren
                    {
                        rotate(targetAngle);
                    }

                    if (speed < taxiSpeed && distanceToTarget > 50 && angle == targetAngle)
                    {
                        accelerate(taxiSpeed);
                    }
                    else if ((speed > cornerSpeed) || speed < cornerSpeed && distanceToTarget <= 50 && angle == targetAngle && !standingStill && distanceToTarget > 0)
                    {
                        accelerate(cornerSpeed);
                    }
                    else if (navigator.currentWay is Taxiway && airport.collisionDetection(this, navigator.currentWay, navigator.getTargetNode()))
                    {
                        accelerate(0);
                    }

                    else if (angle == targetAngle)  //alleen move als hij in de goede richting staat
                    {
                        move();
                    }
                }
            }
            isSimulating = false;
        }

        public void requestNavigator(Airport.Airport airport)
        {
            airport.requestNavigator(this);
        }
        public void requestTakeOff(Airport.Airport airport)
        {
            if (airport.requestTakeOff(this))
            {
                status = Status.TAKINGOFF;
                navigator.setNextTarget();
            }
        }
        public bool requestWayAccess(Airport.Airport airport, Way targetWay, Node targetNode)
        {
            if (airport.requestWayAccess(this, targetWay, targetNode))
            {
                navigator.permissions[navigator.targetNodeNumber] = Navigator.PermissionStatus.GRANTED;
                navigator.permissionCounter++;
                return true;
            }
            else
            {
                navigator.permissions[navigator.targetNodeNumber] = Navigator.PermissionStatus.REQUESTED;
                navigator.permissionCounter++;
                return false;
            }
        }

        public void land()
        {
            this.setStateVariables(0, 0);
            if (status != Status.CANCELLED)
            {
                this.status = Status.TAXIING;
            }
        }

        /*
         * Wat er moet gebeuren als het vliegtuig bij de gate staat.
        */
        public void dock()
        {
            status = Status.DOCKING;
            isWaiting = false;

            //Check wanneer vliegtuig is aangekomen.
            actualArrivalDate = TimeKeeper.currentSimTime;
            actualLandingDate = this.landingDate;

            //Bereken verschil in verwachte vertrektijd en verwachte aankomst tijd.
            if (landingDate != actualLandingDate)
            {
                if (actualLandingDate > landingDate)
                {
                    landingDifference = actualLandingDate.Subtract(landingDate);
                }
                else
                {
                    landingDifference = new TimeSpan();
                }
            }
            if (actualArrivalDate > arrivalDate)
            {
                arrivalDifference = actualArrivalDate.Subtract(arrivalDate);
            }
            //Vliegtuig is te vroeg/op tijd, dus alles via planning
            else if (actualArrivalDate <= arrivalDate)
            {
                arrivalDifference = new TimeSpan();
            }
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

            //Tel absoluut verschil op bij de echte simulatietijd.
            //Nieuwe vertrektijd is difference + delay + oude vertrektijd.
            actualDepartureDate = departureDate.Add(landingDifference + arrivalDifference + delay); //+ delay

            // Zet hasDocked op true voor de navigator.
            hasDocked = true;
        }

        public void leaveDock()
        {
            status = Status.TAXIING;
        }

        public void prepareTakeOff()
        {
            status = Status.WAITING_TAKEOFF;
        }

        public void takeOff()
        {
            status = Status.DEPARTED;
        }

        public bool isOnAirport()
        {
            if (status == Status.APPROACHING || status == Status.DEPARTED)
            {
                return false;
            }
            else { return true; }
        }

        private void rotate(double targetAngle)
        {
            double rotation = getRotationSpeed(targetAngle, angle) * (TimeKeeper.elapsedSimTime.Ticks / 1000000);           // Rotatie per seconde in graden
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
            if (angle >= 360)
                angle = angle - 360;
        }

        private double getRotationSpeed(double targetAngle, double angle)
        {
            double angleDifference = Math.Abs(angle - targetAngle);
            if (angleDifference > 180)
                angleDifference = 360 - angleDifference;
            if (angleDifference > 10) return 1;
            else return angleDifference / 10;
        }

        public void accelerate(double targetSpeed)
        {
            double acceleration = 5;        // 1 m/s2, acceleratie moet afhankelijk worden van target snelheid en max acceleratie. Eventueel van de weg waarop vliegtuig rijdt.

            if (targetSpeed < speed)
                acceleration = -5; // in het geval dat je moet afremmen
            if (hasCollision == true)
                acceleration = -10;
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

            double averageSpeed = (oldSpeed + speed) / 2;
            double distanceTraveled = TimeKeeper.elapsedSimTime.Seconds * averageSpeed;
            double distanceToTarget = navigator.getDistanceToTargetNode(location);
            if (distanceTraveled <= distanceToTarget)
                moveBy(distanceTraveled);
            else if (distanceTraveled > distanceToTarget)
                moveBy(distanceToTarget);
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
        }

        public override string ToString()
        {
            return "AIRPLANE: " + typeName + ". location=(" + location[0] + ", " + location[1] + "), speed=" + speed + ", angle=" + angle;
        }

    }

}
