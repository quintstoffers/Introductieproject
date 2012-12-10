using Introductieproject.Objects;
using Introductieproject.Simulation;
using System.Collections.Generic;
using System;

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

        public void Routeplanner(Airplane vliegtuig)
        {
            //Deze methode moet met de locatie van een vliegtuig een route bepalen naar een gate of een runway.
            //Deze route wordt dan opgeslagen en wordt door het vliegtuig stap voor stap gevolgd.
            //Het lijkt mij het handigste om een route een lijst te maken van Gates, Runways, Gateways en Taxiways.
            //Om /1/ lijst te maken van deze dingen, lijkt het mij het verstandigste om al deze classes subklasses te maken van hoofdklasse "Way".
            //Daarna wordt er een algoritme gedraaid dat lijkt op het algoritme in de routeplanner zoals gezien in het vak Imperatief Programmeren.
            //Uiteindelijk wordt de lijst meegegeven aan het vliegtuig. (momenteel nog geen variabele in Airplane, maar hoe anders bijhouden per vliegtuig?)
            //Stap 1: maak Gate, Gateway, Runway en Taxiway subklasses van Way. [Gedaan, kan waarschijnlijk nog netter door gelijksoortige methodes in Way onder te brengen]
            //Stap 2: verzin een routeringsalgoritme, gebruikmakend van een begin-Way en eind-Way [Nog niet gedaan]
            
            //Routeplanner zelf
            //Om aan te roepen, geef een vliegtuig mee. Vliegtuig weet huidige coordinaten
            //Stap 1, waar is het vliegtuig nu?
            Way start = null; //op null gezet omdat de compiler anders klaagt
            int locFound = 0; //Integer. 0 = nee. 1 = runway. 2 = gate.
            foreach (Runway r in this.runways)
                if (LocationCheck(vliegtuig.location, r.startLocation, r.endLocation))
                {
                    start = r; //Het beginpunt opslaan als Way. Aangezien r een verwijzing naar een object is, is start een verwijzing naar hetzelfde object.
                    locFound = 1;
                }
            //als er geen locatie gevonden is, wordt de routeplanner niet aangeroepen bij het landen, maar bij het vertrek. Probeer opnieuw met Gates ipv Runways
            if (locFound == 0)
                foreach (Gate g in this.gates)
                    if (LocationCheck(vliegtuig.location, g.startLocation, g.endLocation))
                    {
                        start = g;
                        locFound = 2;
                    }
            if (locFound > 0) //Om zeker te weten dat een beginlocatie bepaald is
            {
                Way end;
                //Stap 2, waar moet het vliegtuig heen? Zoek een vrije gate als start een runway is, en vice versa
                if (locFound == 1)
                {
                    //Check de gates - open gate. Als geen gates open, zoek 1: dichtstbijzijnde gate of 2: langst bezette gate.
                    //Optie 1 heeft waarschijnlijk iets kleinere kans op file voor 1 gate, vanwege meerdere Runways en vertraging tussen vliegtuigen landen op zelfde Runway.
                    //Optie 2 leidt vrijwel altijd tot alle nieuwe vliegtuigen naar dezelfde gate -> file.
                    int t = 0;
                    foreach (Gate g in this.gates) if (g.airplane == null) t++;
                    if (t == 1)
                    {
                        //1 gate vrij, makkelijkste geval. Deze gate is doel
                        foreach (Gate g in this.gates) if (g.airplane == null) end = g;
                    }
                    else if (t==0)
                    {
                        //geen gates vrij. Ga na welke het dichtste bij is
                        //Dichtste bij kan hemelsbreed zijn of via banen. Voor het gemak nu hemelsbreed
                        double d = 100000; //Groot getal eerst
                        double temp;
                        foreach (Gate g in this.gates)
                        {
                            temp = Distance(start.endLocation, g.startLocation);
                            if (temp < d) d = temp;
                        }
                        foreach (Gate g in this.gates) if (Distance(start.endLocation, g.startLocation) == d) end = g;
                    }
                    else if (t > 1)
                    {
                        //meerdere mogelijkheden. Dichtstbijzijnde open gate. Lijkt erg op t=0, maar met kleine aanpassingen
                        double d = 100000;
                        double temp;
                        foreach (Gate g in this.gates)
                        {
                            temp = Distance(start.endLocation, g.startLocation);
                            if (temp < d && g.airplane == null) d = temp; //Alleen lege gates nagaan
                        }
                        foreach (Gate g in this.gates) if (Distance(start.endLocation, g.startLocation) == d && g.airplane == null) end = g; //&& g.airplane == null is voor het geval dat er 2 gates precies even ver zijn, en er maar 1 open is
                    }
                }
                else if (locFound == 2)
                {
                    //Check de runways - dichtstbijzijnde Runway, want je kunt er van uit gaan dat als hij nu bezet is, hij dat niet meer zal zijn als je aankomt.
                    //Dichtstbijzijnde als in degene die de minste reistijd kost.
                    double d = 100000;
                    double temp;
                    foreach (Runway r in this.runways)
                    {
                        temp = Distance(start.endLocation, r.startLocation);
                        if (temp < d) d = temp;
                    }
                    foreach (Runway r in this.runways) if (Distance(start.endLocation, r.startLocation) == d) end = r; //bij meerdere runways op zelfde afstand schrijft de laatste de vorigen over


                    //Er is een startlocatie en een eindlocatie opgeslagen. Nu tijd om route te vinden ertussen


                }
            }
        }

        public bool LocationCheck(int[] planeLoc, int[] wayLoc1, int[] wayLoc2)
        {
            //Kijk of een vliegtuig zich bevindt tussen twee punten (van een way)
            //http://stackoverflow.com/questions/7050186/find-if-point-lay-on-line-segment
            //(x-x1)/(x2-x1)==(y-y1)/(y2-y1) voor (x,y) op lijn (x1,y1),(x2,y2)
            double xRes = (double)((planeLoc[0] - wayLoc1[0]) / (wayLoc2[0] - wayLoc1[0]));
            double yRes = (double)((planeLoc[1] - wayLoc1[1]) / (wayLoc2[1] - wayLoc1[1]));
            return xRes == yRes;
        }

        public double Distance(int[] point1, int[] point2)
        {
            //berekent afstand tussen twee punten: wortel((x1-x2)^2+(y1-y2)^2)
            return Math.Sqrt((double)((point1[0] - point2[0]) * (point1[0] - point2[0]) + (point1[1] - point2[1]) * (point1[1] - point2[1])));
        }
    }
}
