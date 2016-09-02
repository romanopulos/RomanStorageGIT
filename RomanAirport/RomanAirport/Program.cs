using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace RomanAirport
{   
    public enum KindOfFlight
    {
        Arrival,
        Departure
    }

    public enum FlightStatus
    {
        CheckIn,
        GateClosed,
        Arrived,
        DepartedAt,
        Unknown,
        Canceled,
        ExpectedAt,
        Delayed
    }

    //The structure of a search result
     struct SearcResult
    {
        public Flight SomeFlight;
        public KindOfFlight kindoflight;
        public int someindex;
        public SearcResult(Flight SomeFlight, KindOfFlight kindoflight, int someindex)
        {
            this.SomeFlight = SomeFlight;
            this.kindoflight = kindoflight;
            this.someindex = someindex;
        }
    }

    //Status of a flight
     struct Flight
    {
        public DateTime at;
        public int number;
        public string city;
        public string airline;
        public int terminal;
        public KindOfFlight kind;
        public FlightStatus status;
        public override string ToString()
        {
            
            return string.Format("The flight number: {0,5}, the city:{1}, on  {2},  the airline : {3}"+ 
            "the terminal: {4}, the kind of a flight: {5}, the flightstatus:{6}",
            this.number, this.city,this.at,this.airline, this.terminal, this.kind, this.status );
        }
    }    

    class Program
    {
        static string emergencyinfo;
        static Flight[] arrivals;
        static Flight[] departures;
        static int choice = 0;        
        static int x = 0;
        static int y = 0;
        static  SearcResult somef;

        public static void PauseProg()
        {
            
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
        }

        //Enter a date with time
        public static DateTime TimeEnter()
        {
            Console.WriteLine("Enter a year:");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a month(1-12):");
            int montrh = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a day(1-30):");
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter an hour(0-23):");
            int hour = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter an minute(0-59):");
            int minute = int.Parse(Console.ReadLine());
            DateTime timedata = new DateTime(year, montrh, day, hour, minute, 0);
            return timedata;

        }

        public static KindOfFlight Choice()
        {
            Console.WriteLine("Enter a kind of flight:1-arrival, 2 -departure");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
                return KindOfFlight.Departure;
            else
                return KindOfFlight.Arrival;
        }

        public static FlightStatus ChoiceFlightstatus()
        {
            Console.WriteLine("Enter a status of a flight: 0 - CheckIn, 1 - GateClosed,2 - Arrived, 3 - DepartedAt, 4 - Unknown, 5 - Canceled, 6 - ExpectedAt, 7 - Delayed ");
            int choice = int.Parse(Console.ReadLine());
            if ((choice >=0) && (choice <= 7))
                return (FlightStatus)choice;
            else
                return FlightStatus.Unknown;
        }

        public static void SearchByCityAndCloseTime(string city, DateTime searchdate = default(DateTime))
        {
            int maxlength = (arrivals.Length > departures.Length) ? arrivals.Length: departures.Length;
            for (int i = 0; i < maxlength; i++)
            {
                if ((searchdate == default(DateTime)) && (city.Length>0))
                {
                    if (arrivals[i].city == city)
                        Console.WriteLine(arrivals[i].ToString());
                    if (departures[i].city == city)
                        Console.WriteLine(departures[i].ToString());

                }
                else
                {
                    if  ((arrivals[i].at.CompareTo(searchdate) ==1) && (arrivals[i].at.CompareTo(searchdate.AddMinutes(-60)) ==-1))
                    {
                        Console.WriteLine(arrivals[i].ToString());
                    }

                    if ((departures[i].at.CompareTo(searchdate) == 1) && (departures[i].at.CompareTo(searchdate.AddMinutes(-60)) == -1))
                    {
                        Console.WriteLine(departures[i].ToString());
                    }
                }
            }
        }

        public static SearcResult? SearchByNumberOrArrivalTime(int flightnumner, KindOfFlight kind, DateTime searchdate = default(DateTime))
        {
            if (kind == KindOfFlight.Arrival)
            {
                for (int i = 0; i<arrivals.Length; i++)
                {
                     if (((arrivals[i].number == flightnumner) && (flightnumner != 0)) || ((arrivals[i].at.CompareTo(searchdate) == 0) && (flightnumner == 0)))
                    {                       
                        SearcResult? fs = new SearcResult(arrivals[i], KindOfFlight.Arrival,i);                    
                        return fs;

                    }
                }
            }
            else
            {
                for (int j = 0; j<departures.Length; j++)
                {
                    if (((departures[j].number == flightnumner) && (flightnumner != 0)) || ((departures[j].at.CompareTo(searchdate)==0) &&(flightnumner== 0)))
                    {
                        // return arrivals[j];
                        SearcResult? fs = new SearcResult(departures[j], KindOfFlight.Departure, j);
                        return fs;
                    }

                }
            }
            return null;
        }

        public static void SortArray(ref Flight[] flights)
        {
            for (int i = 0; i < flights.Length; i++)
            {
                for (int j = 0; j < flights.Length; j++)
                {
                    Flight temp = flights[i];
                    if (flights[j].at.CompareTo(flights[i].at)==1)
                    {
                        flights[i] = flights[j];
                        flights[j]=temp;
                    }
                }
            }
        }

        public static bool IsNymberUnique(int flightnumner, KindOfFlight kind)
        {          
            if (SearchByNumberOrArrivalTime(flightnumner, kind).HasValue )
                return false;
            else
                return true;
        }

        public static void FillStructure(KindOfFlight kind, out Flight ourflight )
        {
            ourflight = new Flight();            
            ourflight.at = TimeEnter();
            Console.WriteLine("Air line:");
            ourflight.airline = Console.ReadLine();
            Console.WriteLine("Flight number:");
            ourflight.number = int.Parse( Console.ReadLine());
            Console.WriteLine("City:");
            ourflight.city = Console.ReadLine();
            Console.WriteLine("Terminal:");
            ourflight.terminal = int.Parse(Console.ReadLine());
            //by a parameter
            ourflight.kind = kind;
            ourflight.status = ChoiceFlightstatus();
            bool numberunique = IsNymberUnique(ourflight.number, ourflight.kind);
            if (!numberunique)
            {
                Console.WriteLine("Not a unique number!!!");
                return;
            }
            if (ourflight.kind == KindOfFlight.Arrival)
            {                
                arrivals[x] = ourflight;
                x++;
            }
            else
            {
                departures[y] = ourflight;
                y++;
            }
        }

        public static void EditStructure(KindOfFlight kind, int number)
        {
            SearcResult? somef1 = SearchByNumberOrArrivalTime(number, kind);
            if (somef1.HasValue)
                somef = (SearcResult)somef1;
            else
                return;
            Console.WriteLine("Current city is: {0}", somef.SomeFlight.city);
            Console.WriteLine("New city is:");
            somef.SomeFlight.city = Console.ReadLine();
            Console.WriteLine("Current airline is: {0}", somef.SomeFlight.airline);
            Console.WriteLine("New airline is:");
            somef.SomeFlight.city = Console.ReadLine();
            Console.WriteLine("Current terminal is: {0}", somef.SomeFlight.terminal);
            Console.WriteLine("New terminal is:");
            somef.SomeFlight.terminal = int.Parse( Console.ReadLine());
            if (kind == KindOfFlight.Arrival)
            {
                arrivals[somef.someindex] = somef.SomeFlight;

            }
            else
            {
                departures[somef.someindex] = somef.SomeFlight;
            }
        }

        public static void DeleteStructure(KindOfFlight kind, int number)
        {
            SearcResult? somef1 = SearchByNumberOrArrivalTime(number, kind);
            if (somef1.HasValue)
                somef = (SearcResult)somef1;
            else
                return;
            somef.SomeFlight.status = FlightStatus.Canceled;
            Console.WriteLine("The flight № {0} is canceled", somef.SomeFlight.number);
            if (kind == KindOfFlight.Arrival)
            {
                arrivals[somef.someindex] = somef.SomeFlight;

            }
            else
            {
                departures[somef.someindex] = somef.SomeFlight;
            }
        }

        static void Main(string[] args)
        {            
            int numberX;           
            //10 flights totally
            arrivals = new Flight[10];
            departures = new Flight[10];
            //Enter the test data
            //Arrival 1
            Flight ourflightstart1 = new Flight();
            ourflightstart1.at = DateTime.Now.AddHours(6);
            ourflightstart1.airline = "Aerosweet";
            ourflightstart1.number = 784;
            ourflightstart1.city = "Istanbul";
            ourflightstart1.terminal = 8;
            ourflightstart1.kind = KindOfFlight.Arrival;
            ourflightstart1.status = FlightStatus.Delayed;
            arrivals[x] = ourflightstart1;
            x++;
            //Departure 1
            Flight ourflightstart2 = new Flight();
            ourflightstart2.at = DateTime.Now.AddHours(3);
            ourflightstart2.airline = "FlyEmirates";
            ourflightstart2.number = 611;
            ourflightstart2.city = "Madrid";
            ourflightstart2.terminal = 6;
            ourflightstart2.kind = KindOfFlight.Departure;
            ourflightstart2.status = FlightStatus.GateClosed;
            departures[y] = ourflightstart2;
            y++;
            //Arrival 2
            Flight ourflightstart3 = new Flight();
            ourflightstart3.at = DateTime.Now.AddHours(2);
            ourflightstart3.airline = "AirFrance";
            ourflightstart3.number = 529;
            ourflightstart3.city = "new York";
            ourflightstart3.terminal = 3;
            ourflightstart3.kind = KindOfFlight.Arrival;
            ourflightstart3.status = FlightStatus.CheckIn;
            arrivals[x] = ourflightstart3;
            x++;
            //Departure 2
            Flight ourflightstart4 = new Flight();
            ourflightstart4.at = DateTime.Now.AddHours(1);
            ourflightstart4.airline = "LuftGanza";
            ourflightstart4.number = 481;
            ourflightstart4.city = "Montreal";
            ourflightstart4.terminal = 2;
            ourflightstart4.kind = KindOfFlight.Departure;
            ourflightstart4.status = FlightStatus.CheckIn;
            departures[y] = ourflightstart4;
            y++;
            Console.WriteLine("Enter the emergency information"+
            "on all flights in this airport");
            emergencyinfo = Console.ReadLine();
            PauseProg();
            somef = new SearcResult();           
            while (true)
            {
                Console.WriteLine("1.Add an arrival flight");
                Console.WriteLine("2.Edit an arrival  flight");
                Console.WriteLine("3.Delete an arrival  flight");
                Console.WriteLine("4.Add a departure flight");
                Console.WriteLine("5.Edit a departure  flight");
                Console.WriteLine("6.Delete a departure  flight");
                Console.WriteLine("7.PRINT");
                Console.WriteLine("8.SEARCH BY A NUMBER");
                Console.WriteLine("9.SEARCH  by time of arrival");
                Console.WriteLine("10.SEARCH by a city ");
                Console.WriteLine("11.SEARCH all the flights in this hour");
                Console.WriteLine("12.OUTPUT EMERGENCY INFO");
                Console.WriteLine("13.SORT BY DATE");
                Console.WriteLine("14.EXIT A PROJECT");
                choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        {
                            Flight ourflight;
                            FillStructure(KindOfFlight.Arrival, out  ourflight);
                            PauseProg();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Arrival Flight number to edit:");
                            numberX = int.Parse(Console.ReadLine());
                            EditStructure(KindOfFlight.Arrival, numberX);
                            PauseProg();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Arrival Flight number to delete:");
                            numberX = int.Parse(Console.ReadLine());
                            DeleteStructure(KindOfFlight.Arrival, numberX);
                            PauseProg();
                            break;
                        }
                    case 4:
                        {
                            Flight ourflight;
                            FillStructure(KindOfFlight.Departure, out ourflight);
                            PauseProg();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Departure Flight number to edit:");
                            numberX = int.Parse(Console.ReadLine());
                            EditStructure(KindOfFlight.Departure, numberX);
                            PauseProg();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Departure Flight number to delete:");
                            numberX = int.Parse(Console.ReadLine());
                            DeleteStructure(KindOfFlight.Departure, numberX);
                            PauseProg();
                            break;
                        }
                    case 7:
                        {
                            for (int i = 0; i < arrivals.Length; i++)
                            {
                                /*Check an empy date
                                in an array   */
                                if (DateTime.MinValue == arrivals[i].at)
                                    continue;
                                Console.WriteLine(arrivals[i].ToString());
                                Console.WriteLine("");
                            }

                            for (int i = 0; i < departures.Length; i++)
                            {
                                if (DateTime.MinValue == departures[i].at)
                                    continue;
                                Console.WriteLine(departures[i].ToString());
                            }
                            PauseProg();
                            break;
                        }
                    case 8:
                        {
                            //Search by a number
                            Console.WriteLine("Enter a number to search");
                            numberX = int.Parse(Console.ReadLine());
                            SearcResult? somef1 = SearchByNumberOrArrivalTime(numberX, KindOfFlight.Arrival);
                            if (somef1.HasValue)
                            {
                                somef = (SearcResult)somef1;
                                Console.WriteLine(somef.SomeFlight.ToString());
                            }
                            else
                            {                                
                                somef1 = SearchByNumberOrArrivalTime(numberX, KindOfFlight.Departure);
                                if (somef1.HasValue)
                                {
                                    somef = (SearcResult)somef1;
                                    Console.WriteLine(somef.SomeFlight.ToString());
                                }
                            }
                            PauseProg();
                            break;
                        }
                    case 9:
                        {
                            //Search by time of arrival
                            DateTime searchtime = TimeEnter();
                            SearcResult? somef2 = SearchByNumberOrArrivalTime(0, KindOfFlight.Arrival, searchtime);
                            if (somef2.HasValue)
                            {
                                somef = (SearcResult)somef2;
                                Console.WriteLine(somef.SomeFlight.ToString());
                                PauseProg();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Nothing to write!!!");
                                PauseProg();
                                break;
                            }                            
                        }
                    case 10:
                        {
                                Console.WriteLine("Enter The City:");
                                string searchcity = Console.ReadLine();
                                SearchByCityAndCloseTime(searchcity);
                                PauseProg();
                                break;
                        }
                        //Search by a city                       
                    case 11:
                        {
                                //Search all the flights in this hour
                                DateTime nowtime = DateTime.Now.AddHours(1);
                                SearchByCityAndCloseTime("", nowtime);
                                PauseProg();
                                break;
                        }
                    case 12:
                        {
                                //Output emergency info
                                Console.WriteLine("Attention!!!See the emergency INFO!!!");
                                Console.WriteLine("-------------------------------------");
                                Console.WriteLine(emergencyinfo);
                                PauseProg();
                                break;
                        }
                    case 13:
                        {
                                SortArray(ref arrivals);
                                SortArray(ref departures);
                                break;
                        }
                    case 14:
                        {
                            return;
                        }
                    default:
                        {
                                Console.WriteLine("A wrong choice!!!Repeat");
                                break;
                        }
                }              
            }
        }
    }
}
