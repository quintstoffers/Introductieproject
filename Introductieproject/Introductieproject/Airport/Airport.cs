using Introductieproject.Objects;
using Introductieproject.Simulation;
using System.Collections.Generic;

namespace Introductieproject.Airport
{
    class Airport
    {
        public List<Airplane> airplanes = new List<Airplane>();
        private List<Airplane> knownAirplanes = new List<Airplane>();
        public List<Gate> gates = new List<Gate>();
        public List<Runway> runways = new List<Runway>();
        public List<Taxiway> taxiways = new List<Taxiway>();
        public List<Gateway> gateways = new List<Gateway>();
        public List<Building> buildings = new List<Building>();

        public Airport()
        {
        }

        public void Routeplanner()
        {
            //Deze methode moet met de locatie van een vliegtuig een route bepalen naar een gate of een runway.
            //Deze route wordt dan opgeslagen en wordt door het vliegtuig stap voor stap gevolgd.
            //Het lijkt mij het handigste om een route een lijst te maken van Gates, Runways, Gateways en Taxiways.
            //Om /1/ lijst te maken van deze dingen, lijkt het mij het verstandigste om al deze classes subklasses te maken van hoofdklasse "Way".
            //Daarna wordt er een algoritme gedraaid dat lijkt op het algoritme in de routeplanner zoals gezien in het vak Imperatief Programmeren.
            //Uiteindelijk wordt de lijst meegegeven aan het vliegtuig. Het vliegtuig gaat ofwel naar het volgende punt op de lijst of verwijdert de plekken die hij al heeft gehad.
            //Stap 1: maak Gate, Gateway, Runway en Taxiway subklasses van Way. [Gedaan, kan waarschijnlijk nog netter door gelijksoortige methodes in Way onder te brengen]
            //Stap 2: verzin een routeringsalgoritme, gebruikmakend van een begin-Way en eind-Way [Nog niet gedaan]
        }
    }
}
