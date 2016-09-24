using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortRomanOOP
{
    class Airline: CommercialOrganisation, IAirport<Flight>, IComparable<Airline>
    {
        public string AirlineName { get; set; }       
        private List<Flight> arrivalFlightlist;        
        public List<Flight> ArrivalList
        {
            get
            {
                return arrivalFlightlist;
            }
            set
            {
                arrivalFlightlist = value;
            }
        }

        private List<Flight> departureFlightlist;
        public List<Flight> DepartureFlightlist
        {
            get
            {
                return departureFlightlist;
            }
            set
            {
                departureFlightlist = value;
            }
        }

        delegate Airline FindAnAirline();
        public static Airline CheckAirline(Airline[] AirlineArray)
        {
            string licensenumber;
            string airlinename;
            int incrementAirlineArray = 4;
            FindAnAirline fn = new FindAnAirline
            (
                () =>
                {
                    Console.WriteLine("Enter an Airline to work with:");
                    string readAirline = Console.ReadLine();
                    for (int i = 0; i < AirlineArray.Length; i++)
                    {
                        if (AirlineArray[i]?.AirlineName != null)
                            if (AirlineArray[i].AirlineName == readAirline)
                            {

                                return AirlineArray[i];
                            }
                    }
                    return null;
                }
            );
            Airline chosenLine = fn();
            if (chosenLine == null)
            {
                Console.WriteLine("The airline you have selected doesn't exist." +
                "Do you wish to fill a new one (Y/N)");
                bool yn = ("Y" == Console.ReadLine() ? true : false);
                if (yn)
                {
                    Console.WriteLine("Enter a name of AirLine");
                    incrementAirlineArray++;
                    try
                    {
                        Console.WriteLine("Enter a license nimber of an airlinecompany");
                        licensenumber = Console.ReadLine();
                        airlinename = Console.ReadLine();
                        AirlineArray[incrementAirlineArray] = new Airline(airlinename, licensenumber,
                        true, InputUtil.TimeEnter());
                        while (true)
                        {
                            Console.WriteLine("To continue filling an information of a current airline press /Y/ or N to stop");
                            string choice = Console.ReadLine();
                            if (choice.ToUpper() != "Y")
                                break;
                            AirlineArray[incrementAirlineArray].AddItem();
                        }
                        chosenLine = AirlineArray[incrementAirlineArray];
                    }
                    catch (IndexOutOfRangeException excep)
                    {
                        Console.WriteLine(excep.Message);
                        return null;
                    }
                }
            }
            return chosenLine;
        }

        public static void EditAirline(Airline company)
        {
            string valuestring;
            DateTime valuedDatetime;
            Console.WriteLine("Enter the new name of Airline:(#) - remain one");
            valuestring = Console.ReadLine();
            company.AirlineName = ((valuestring == "#") ? company.AirlineName : valuestring);
            Console.WriteLine("Enter the new LicenseNumber of Airline:(#) - remain one");
            valuestring = Console.ReadLine();
            company.LicenseNumber = ((valuestring == "#") ? company.LicenseNumber : valuestring);
            Console.WriteLine("Enter the new expiration date of Airline: (#) - remain one");
            valuestring = Console.ReadLine();
            valuedDatetime = ((valuestring == "#") ? company.DateExpired : InputUtil.TimeEnter());
            company.DateExpired = valuedDatetime;            
        }

        public static void DeleteAirline(Airline company)
        {
            company.CancelLicense();
        }

        public Airline(string airlineName, string LicenseNumber, bool IsLicenseValid, 
            DateTime DateExpired) : base(LicenseNumber, IsLicenseValid, DateExpired)
        {
            this.AirlineName = airlineName;            
        }

        public override void GetLicense()
        {
            this.DateExpired = InputUtil.TimeEnter();
            this.IsLicenseValid = true;
        }

        public override void CancelLicense()
        {
            DateTime date1 = new DateTime();
            this.DateExpired = date1;
            this.IsLicenseValid = false;
        }

        public static FlightStatus ChoiceFlightstatus()
        {           
            Console.WriteLine("Enter a status of a flight: 0 - CheckIn, 1 - GateClosed,2 - Arrived, 3 - DepartedAt, 4 - Unknown, 5 - Canceled, 6 - ExpectedAt, 7 - Delayed ");
            int choice = int.Parse(Console.ReadLine());
            
            if ((choice >= 0) && (choice <= Enum.GetValues(typeof(FlightStatus)).Length))
                return (FlightStatus)choice;
            else
                return FlightStatus.Unknown;
        }
        
        public void AddItem()
        {
            byte choiceFlight =0;
            Flight newflight;
            try
            {              
                Console.WriteLine("Enter a kind of flight:1 - arrival; 2 - departure");
                choiceFlight = byte.Parse(Console.ReadLine());
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);                
            }
            if ((choiceFlight<=0)||(choiceFlight>=3))
            {
                Console.WriteLine("You entered a wrong choice!!!");                
            }
            DateTime timeofFlight = InputUtil.TimeEnter();
            Console.WriteLine("Flight number:");
            int ourflightnumber = int.Parse(Console.ReadLine());
            Console.WriteLine("City:");
            string ourflightcity = Console.ReadLine();
            Console.WriteLine("Terminal:");
            string ourflightterminal = Console.ReadLine();            
            KindOfFlight ourflightkind = (KindOfFlight)choiceFlight;
            FlightStatus ourflightstatus = ChoiceFlightstatus();            
            newflight = new Flight(timeofFlight, ourflightnumber, ourflightcity, 
            ourflightterminal, ourflightkind, ourflightstatus, new List<Ticket>(), true);
            AddToArray(ourflightkind, newflight);            
        }

        public Flight EditItem(Flight editflight)
        {
            editflight.At = InputUtil.TimeEnter();
            Console.WriteLine("Terminal:");
            editflight.Terminalandgate = Console.ReadLine();
            editflight.Status = ChoiceFlightstatus();
            return editflight;
        }

        public void DeleteItem(Flight deleteflight)
        {
            deleteflight.Status = FlightStatus.Canceled;
        }

        public void AddToArray(KindOfFlight ourflightkind, Flight newflight)
        {
            if(ourflightkind == KindOfFlight.Arrival)
            {
                this.arrivalFlightlist?.Add(newflight);

            }
            else
            {
                this.departureFlightlist?.Add(newflight);
            }           
        }

        public Flight SearchFlight()
        {
            Console.WriteLine("Enter a number of a flight");
            int flightnumber = int.Parse(Console.ReadLine());
            foreach (var item in arrivalFlightlist)
            {
                if (item.Number == flightnumber)
                    return item;

            }
            foreach (var item in departureFlightlist)
            {
                if (item.Number == flightnumber)
                    return item;
            }
            return null;
        }

        public void PrintAllFlights(List<Flight> FlightList)
        {            
            if (!(FlightList==null))
            foreach (var item in FlightList)
            {
                Console.WriteLine(item.ToString());
                
            }
        }

        public void PriceList()
        {          
            int maxlength = ((this.ArrivalList.Count > this.DepartureFlightlist.Count) ?
                                        this.ArrivalList.Count : this.DepartureFlightlist.Count);
            int controlpointarrive = 0;
            int controlpointdeparture = 0;
            if (this.ArrivalList.Count == maxlength)
            {
                controlpointarrive = maxlength;
                controlpointdeparture = this.DepartureFlightlist.Count;
            }
            else
            {
                controlpointarrive = this.ArrivalList.Count;
                controlpointdeparture = maxlength;
            }
            for (int i = 0; i < maxlength; i++)
            {
                if ((i < controlpointarrive) && (this.ArrivalList.ElementAt(i) != null))
                {
                    foreach (var item in this.ArrivalList.ElementAt(i)?.TicketList)
                    {
                        Console.WriteLine("Airline {0}, fligt № {1}, class {2}, category {3}, price {4}",
                        this.AirlineName, this.ArrivalList.ElementAt(i).Number,
                        item.ClassofTicket, item.TicketCategory, item.Price);
                    }
                }
                if ((i < controlpointdeparture) && (this.DepartureFlightlist.ElementAt(i) != null))
                {
                    foreach (var item in this.DepartureFlightlist.ElementAt(i)?.TicketList)
                    {
                        Console.WriteLine("Airline {0}, fligt № {1}, class {2}, category {3}, price {4}",
                        this.AirlineName, this.DepartureFlightlist.ElementAt(i).Number,
                        item.ClassofTicket, item.TicketCategory, item.Price);
                    }
                }
            }
        }


        public int CompareTo(Airline airline)
        {
             if (airline != null)
                return this.AirlineName.CompareTo(airline.AirlineName);
            else
                throw new NullReferenceException("Imposibble to compare because of null!!!");
        }

        public override string ToString()
        {
            return string.Format("The airline name: {0,15}, the license number:{1}, the license expiration date  {2}," +
            "the license is valid: ", this.AirlineName, this.LicenseNumber, this.DateExpired, this.IsLicenseValid);
        }
    }
}
