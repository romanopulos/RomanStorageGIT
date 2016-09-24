using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortRomanOOP
{
    class Generator
    {   
        private static Generator sample;
        private Flight flighttoadd;
        private Flight flighttosearch;
        public Airline[] AirlineArray { get; set; }              

        private  Generator()
        {
            AirlineArray = new Airline[10];
        }

        public static  Generator getSingleExample()
        {
            if (sample == null)
            {
                sample = new Generator();

            }
            return sample;
        }

        public void InitialDataGenerator()
        {
            AirlineArray[0] = new Airline("AirFrance", "A45678", true, new DateTime(2028, 3, 15));
            flighttoadd = new Flight(new DateTime(2016, 09, 24), 183, "Paris", "8", KindOfFlight.Arrival,
            FlightStatus.CheckIn, new List<Ticket>(), false);
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryA, 1200.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryB, 1050.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryC, 900.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryA, 850.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryB, 700.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryC, 550.00m));
            flighttoadd.Customers = new Passenger[40];
            flighttoadd.Customers[0] = new Passenger("Oleg", "Vasin", "russian", new DateTime(1970, 8, 18), "MF946941", 653656565, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryB && x.ClassofTicket == TicketClass.Business))));
            flighttoadd.Customers[1] = new Passenger("Anna", "Mohnach", "ukrainian", new DateTime(1988, 9, 11), "MK172693", 568345671, Sex.Female,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryA && x.ClassofTicket == TicketClass.Economy))));
            flighttoadd.Customers[2] = new Passenger("Salam", "Abdelkadir", "arab", new DateTime(1987, 11, 23), "YE689856", 183873891, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryC && x.ClassofTicket == TicketClass.Business))));
            flighttoadd.Customers[3] = new Passenger("Sirik", "Sergei", "jew", new DateTime(1975, 8, 18), "MP894512", 825433489, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryC && x.ClassofTicket == TicketClass.Economy))));
            AirlineArray[0].ArrivalList = new List<Flight>();
            AirlineArray[0].DepartureFlightlist = new List<Flight>();
            AirlineArray[0].AddToArray(KindOfFlight.Arrival, flighttoadd);
            flighttoadd = new Flight(new DateTime(2016, 09, 07), 211, "London", "21", KindOfFlight.Departure,
            FlightStatus.CheckIn, new List<Ticket>(), false);
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryA, 1240.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryB, 1050.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryC, 950.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryA, 820.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryB, 600.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryC, 350.00m));
            flighttoadd.Customers = new Passenger[40];
            flighttoadd.Customers[0] = new Passenger("Pablo", "Alonso", "spain", new DateTime(), "uT782768", 451798061, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryA && x.ClassofTicket == TicketClass.Business))));
            flighttoadd.Customers[1] = new Passenger("Roman", "Zelensky", "ukrainian", new DateTime(), "MK885561", 917623019, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryB && x.ClassofTicket == TicketClass.Economy))));
            flighttoadd.Customers[2] = new Passenger("Oleg", "Shliahtin", "ukrainian", new DateTime(), "MK096714567", 861245013, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryB && x.ClassofTicket == TicketClass.Economy))));
            flighttoadd.Customers[3] = new Passenger("Bubu", "Camara", "african", new DateTime(), "ZX735612", 984503781, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryC && x.ClassofTicket == TicketClass.Economy))));
            AirlineArray[0].AddToArray(KindOfFlight.Departure, flighttoadd);
            flighttoadd = new Flight(new DateTime(2016, 10, 01), 132, "Nashville", "14", KindOfFlight.Departure,
            FlightStatus.CheckIn, new List<Ticket>(), false);
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryA, 1880.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryB, 1500.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryC, 1350.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryA, 900.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryB, 700.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryC, 550.00m));
            flighttoadd.Customers = new Passenger[40];
            flighttoadd.Customers[0] = new Passenger("Karina", "Shilova", "ukrainian", new DateTime(), "MK156789", 614581904, Sex.Female,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryB && x.ClassofTicket == TicketClass.Economy))));
            flighttoadd.Customers[1] = new Passenger("Yuriy", "Pavlenko", "ukrainian", new DateTime(), "MK451245", 498123087, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryC && x.ClassofTicket == TicketClass.Economy))));
            flighttoadd.Customers[2] = new Passenger("Us", "Pavel", "ukrainian", new DateTime(), "MK290190", 124518901, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryC && x.ClassofTicket == TicketClass.Economy))));
            flighttoadd.Customers[3] = new Passenger("Us", "Natalia", "ukrainian", new DateTime(), "MK497712", 498123087, Sex.Female,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryC && x.ClassofTicket == TicketClass.Economy))));
            AirlineArray[0].AddToArray(KindOfFlight.Departure, flighttoadd);
            flighttoadd = new Flight(new DateTime(2016, 11, 26), 120, "Montreal", "7", KindOfFlight.Arrival,
            FlightStatus.Delayed, new List<Ticket>(), false);
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryA, 1740.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryB, 1500.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryC, 1200.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryA, 850.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryB, 700.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryC, 400.00m));
            flighttoadd.Customers = new Passenger[40];
            flighttoadd.Customers[0] = new Passenger("Mario", "Balotelli", "italian", new DateTime(), "CY561823", 501756891, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryA && x.ClassofTicket == TicketClass.Business))));
            flighttoadd.Customers[1] = new Passenger("Fedor", "Zinchenko", "belorussian", new DateTime(), "MK667712", 981234561, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryC && x.ClassofTicket == TicketClass.Economy))));
            flighttoadd.Customers[2] = new Passenger("Yuriy", "Scherbak", "greek", new DateTime(), "MK615478", 990145679, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryA && x.ClassofTicket == TicketClass.Economy))));
            AirlineArray[0].AddToArray(KindOfFlight.Arrival, flighttoadd);
            flighttoadd = new Flight(new DateTime(2016, 10, 01), 177, "Sydney", "7", KindOfFlight.Departure, FlightStatus.Delayed, new List<Ticket>(), false);
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryA, 2450.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryB, 2200.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Business, (int)TicketCategory.CategoryC, 2000.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryA, 1650.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryB, 1300.00m));
            flighttoadd.TicketList.Add(new Ticket((int)TicketClass.Economy, (int)TicketCategory.CategoryC, 850.00m));
            flighttoadd.Customers = new Passenger[40];
            flighttoadd.Customers[0] = new Passenger("Vitaliy", "Bolshak", "portugal", new DateTime(), "FF567890", 322554354, Sex.Male,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryA && x.ClassofTicket == TicketClass.Economy))));
            flighttoadd.Customers[1] = new Passenger("Ekaterina", "Golshtein", "german", new DateTime(), "MK780544", 836256813, Sex.Female,
            flighttoadd.TicketList.Find((x => (x.TicketCategory == TicketCategory.CategoryB && x.ClassofTicket == TicketClass.Economy))));
            AirlineArray[0].AddToArray(KindOfFlight.Departure, flighttoadd);
            AirlineArray[1] = new Airline("Luftganza", "B45678", true, new DateTime(2024, 7, 25));
            AirlineArray[2] = new Airline("Aerosweet", "B47326", true, new DateTime(2020, 11, 1));
            AirlineArray[3] = new Airline("FlyEmirates", "B67890", true, new DateTime(2038, 4, 9));
            AirlineArray[4] = new Airline("RoyalLines", "Y45678", true, new DateTime(2028, 6, 8));
        }
    }
}
