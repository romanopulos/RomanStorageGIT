using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortRomanOOP
{
    class Flight :IAirport<Passenger>,IComparable<Flight>
    {
        private DateTime at;
        private struct editInf
        {
            public string   firstname;
            public string lastname ;
            public Sex sex ;
            public DateTime birthday;
            public string nationality;
            public string passport;
            public int identical;
            public Ticket ticket;         
        }

        private List<Ticket> ticketList;
        public List<Ticket> TicketList
        {
            get
            {
                return ticketList;
            }
            set
            {

                ticketList = new List<Ticket>();
            }
        }

        public DateTime At
        {
            get
            {
                return at;
            }
            set
            {
                at = value;
            }
        }

        private int number;
        public int Number
        {
            get
            {
                return number;
            }

        }

        private string city;
        public string City
        {
            get
            {
                return city;
            }
        }

        private Airline airline;
        public Airline Airline
        {
            get
            {
                return airline;
            }
        }

        private string terminalandgate;
        public string Terminalandgate
        {
            get
            {
                return terminalandgate;
            }
            set
            {
                terminalandgate = value;
            }
        }

        private KindOfFlight kind;
        public KindOfFlight Kind
        {
            get
            {
                return kind;
            }
        }

        private FlightStatus status;
        public FlightStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        private Passenger[] customers;
        public Passenger[] Customers
        {
            get
            {
                return customers;
            }
            set
            {
                customers = value;
            }
        }

        public Flight(DateTime at, int number, string city, 
        string terminalandgate, KindOfFlight kind, FlightStatus status, List<Ticket> ticketList,bool isPassengerFill)
        {
            this.at = at;
            this.number = number;
            this.city = city;
            this.terminalandgate = terminalandgate;
            this.kind = kind;
            this.status = status;
            this.ticketList = ticketList;
            //Maximum of passengers
            this.customers = new Passenger[40];
            if (isPassengerFill)
            {
                AddItem();
            }
        }
       
        private editInf ToEditApAssenger(Passenger pass)
        {
            editInf ed;           
            ed = new editInf();
            Console.WriteLine("Enter a firstname of a passenger: {0}", ((pass != null) ?pass.Firstname:String.Empty));
            ed.firstname = Console.ReadLine();
            Console.WriteLine("Enter a lastname of a passenger: {0}", ((pass != null) ? pass.Lastname : String.Empty));
            ed.lastname = Console.ReadLine();
            Console.WriteLine("Enter a sex of passenger:1 - a man, 2 - a woman{0} - ", ((pass != null) ? ((pass.Sex==Sex.Male)?1:2):1));
            ed.sex = (Sex)int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a birthday of a passenger: {0}", ((pass != null) ? pass.Birthday : DateTime.MinValue));
            ed.birthday = InputUtil.TimeEnter();
            Console.WriteLine("Enter a nationaality of a passenger: {0}", ((pass != null) ? pass.Nationality : String.Empty));
            ed.nationality = Console.ReadLine();
            Console.WriteLine("Enter a passport data of a passenger: {0}", ((pass != null) ? pass.Passport : String.Empty));
            ed.passport = Console.ReadLine();
            Console.WriteLine("Enter an identical code of passenger: {0}", ((pass != null) ? pass.Identicalcode.ToString() : String.Empty));
            ed.identical = int.Parse(Console.ReadLine());            
            ed.ticket =(pass!=null)? pass.Tct:new Ticket(1,1,0) ;
            Console.WriteLine("Enter a ticket class: {0}", (pass != null) ? pass.Tct.ClassofTicket:TicketClass.Economy);
            ed.ticket.ClassofTicket = (TicketClass)(int.Parse(Console.ReadLine()));
            Console.WriteLine("Enter a ticket category: {0}", (pass != null) ? pass.Tct.TicketCategory:TicketCategory.CategoryA);
            ed.ticket.TicketCategory = (TicketCategory)(int.Parse(Console.ReadLine()));
            Console.WriteLine("Enter a price: {0}", (pass != null) ? pass.Tct.Price:0);
            ed.ticket.Price = Convert.ToDecimal(Console.ReadLine());          
            return ed;
        }

        public void AddItem()
        {
            editInf ed;                     
            Console.WriteLine("Enter a number of passengers");
            int passnumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < passnumber; i++)
            {
                     ed = ToEditApAssenger(null);
                     this.customers[i] = new Passenger(ed.firstname, ed.lastname, ed.nationality, ed.birthday,
                     ed.passport, ed.identical, ed.sex, ed.ticket);
             }            
        }

        public Passenger EditItem(Passenger editpassenger)
        {
            editInf ed;
            ed = ToEditApAssenger(editpassenger);
            editpassenger.Firstname = ed.firstname;
            editpassenger.Lastname = ed.lastname;
            editpassenger.Passport = ed.passport;
            editpassenger.Sex = ed.sex;
            editpassenger.Nationality = ed.nationality;
            editpassenger.Birthday = ed.birthday;
            editpassenger.Identicalcode = ed.identical;
            editpassenger.Tct = ed.ticket;
            return editpassenger;
        }

        public void DeleteItem(Passenger deletepassenger)
        {
            for (int i = 0; i < this.customers.Length; i++)
            {
                if (this.customers[i] == deletepassenger)
                {
                    this.customers[i] = null;
                }
            }         
        }

        public override string ToString()
        {
            return string.Format("The flight number: {0,5}, the city:{1}, on  {2},  the airline : {3}" +
            "the terminal: {4}, the kind of a flight: {5}, the flightstatus:{6}",
            this.Number, this.City, this.At, this.Airline, this.Terminalandgate, this.Kind, this.Status);
        }

        public int CompareTo(Flight flight)
        {            
            if (flight != null)
                return this.Number.CompareTo(flight.Number);
            else
                throw new NullReferenceException("Imposibble to compare because of null!!!");
        }

        public Passenger PassengerSearch(int choisofanswer, object itemsearch)
        {
            int ch;
            decimal ch2;             
            var @subject = itemsearch as String;
            for (int i = 0; i < this.customers.Length; i++)
            {
                switch (choisofanswer)
                {
                    case 1:
                    default:
                        {                            
                            ch = int.Parse(subject);
                            if (this.customers[i].Identicalcode == ch)
                            {
                                return this.customers[i];
                            }
                            break;
                        }
                    case 2:
                        {
                            subject = subject as String;                            
                            if (this.customers[i]?.Lastname.Trim() == subject.Trim())
                            {
                                return this.customers[i];
                            }
                            break;                           
                        }
                    case 3:
                        {                            
                            if (this.customers[i].Firstname.Trim() == subject.Trim())
                            {
                                return this.customers[i];
                            }
                            break;                            
                        }
                    case 4:
                        {                           
                            if (this.customers[i].Passport.Trim() == subject.Trim())
                            {
                                return this.customers[i];
                            }
                            break;
                        }                   
                }
            }
            return null;
        }       
    }
}
