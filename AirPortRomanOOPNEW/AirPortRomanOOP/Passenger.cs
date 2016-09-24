using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortRomanOOP
{

    class Passenger:  IComparable<Passenger>
    {
        static int choisofanswer;
        static string @subject;
        public struct PassFlight
        {
            public Airline airline;
            public Flight flight;
            public Passenger passenger;
        }
        public string Firstname
        {
            get; set;
        }
        public string Lastname
        {
            get; set;
        }       
        public string Nationality
        {
            get; set;
        }
        public DateTime Birthday
        {
            get; set;
        }
        public string Passport
        {
            get; set;
        }
        public int Identicalcode
        {
            get; set;
        }        
        public Sex Sex
        {
            get; set;
        }
        public Ticket Tct
        {
            get; set;
        }

        public Passenger()
        {

        }

        public static object getAvalueOfstructure<T>(Airline[] AirlineArray)
        {
            PassFlight? passengertosearch;
            passengertosearch = SearchOfppassengers(AirlineArray);
            if (passengertosearch != null)
            {
                PassFlight tovonv = (PassFlight)passengertosearch;
                dynamic example = default(T);
                if (example == 0)
                    return tovonv;    
                if (tovonv.airline is T)
                    return tovonv.airline;
                else
                    if (tovonv.flight is T)
                    return tovonv.flight;
                else
                    if (tovonv.passenger is T)
                    return tovonv.passenger;               
                return tovonv;
            }
            return null;
        }

        public static PassFlight? SearchOfppassengers(Airline[] AirlineArray)
        {
            PassFlight? pf = new PassFlight();
            Console.WriteLine("Choose a kind of search:1- by number(ID), 2 - by a last name" +
            ",3 - by a name, 4 - by passport");
            choisofanswer = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a criteria of your search");
            @subject = Console.ReadLine();
            for (int i = 0; i < AirlineArray?.Length; i++)
            {
                pf = SubSearch(AirlineArray[i]?.ArrivalList);
                if (pf != null)
                {
                    return pf;
                }
                else
                {
                    pf = SubSearch(AirlineArray[i]?.DepartureFlightlist);
                    if (pf != null)
                    {
                        return pf;
                    }
                }
            }
            return null;
        }

        public static PassFlight? SubSearch(List<Flight> listofflight)
        {
            Passenger passtofind;
            foreach (var item in listofflight)
            {
                if (item is Flight)
                {
                    passtofind = item.PassengerSearch(choisofanswer, @subject);
                    if (passtofind != null)
                    {
                        PassFlight pf = new PassFlight();
                        pf.flight = item;
                        pf.passenger = passtofind;
                        return pf;
                    }
                }
            }
            return null;
        }

        //The implementation of sort by merge
        public static Passenger[] Sortbyage(Passenger[] somearray)
        {
            if (somearray.Length == 1)
                return somearray;
            int halflength = somearray.Length / 2;
            return Unite(Sortbyage(somearray.Take(halflength).ToArray()),
                Sortbyage(somearray.Skip(halflength).ToArray()));
        }

        public static Passenger[] Unite(Passenger[] array1, Passenger[] array2)
        {
            int a = 0, b = 0;
            Passenger[] unitedArray = new Passenger[array1.Length + array2.Length];
            for (int i = 0; i < array1.Length + array2.Length; i++)
            {
                if (b < array2.Length && a < array1.Length)
                    if ((array1[a]?.Birthday.CompareTo(array2[b]?.Birthday) >= 0) && b < array2.Length)
                        unitedArray[i] = array2[b++];
                    else
                        unitedArray[i] = array1[a++];
                else
                    if (b < array2.Length)
                    unitedArray[i] = array2[b++];
                else
                    unitedArray[i] = array1[a++];
            }
            return unitedArray;
        }

        public Passenger(string firstname, string lastname, string nationality,
        DateTime birthday, string passport, int identicalcode, Sex sex, Ticket tct)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Nationality = nationality;
            this.Birthday = birthday;
            this.Passport = passport;
            this.Identicalcode = identicalcode;
            this.Sex = sex;
            this.Tct = tct;
        }
                
        public override string ToString()
        {
            return string.Format("The first name af a passenger {0}, the last name:{1}, the nationality  {2}, the birthday: {3}" +
            "the passport: {4}, the identicalcode: {5}, the sex:{6}",
            this.Firstname, this.Lastname, this.Nationality, this.Birthday, this.Passport, this.Identicalcode, this.Sex);
        }

        public int CompareTo(Passenger customer)
        {
            if (customer != null)
                return this.Identicalcode.CompareTo(customer.Identicalcode);
            else
                throw new NullReferenceException("Imposibble to compare because of null!!!");
        }
    }
}
