using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortRomanOOP
{
    class Menu
    {
        static Airline chosenLine;
        static Flight flighttosearch;
        public int Choice { get;private set; }       
        private int getMenu()
        {
            Console.Clear();
            Console.WriteLine("1.CHOOSE A CURRENT AIRLINE/ADD A NEW ONE");
            Console.WriteLine("2.EDIT A CURRENT AIRLINE");
            Console.WriteLine("3.DELETE A CURRENT AIRLINE ");
            Console.WriteLine("4.ADD A FLIGHT TO A CURRENT AIRLINE");
            Console.WriteLine("5.EDIT A FLIGHT IN A CURRENT AIRLINE");
            Console.WriteLine("6.DELETE A FLIGHT IN A CURRENT AIRLINE");
            Console.WriteLine("7.PRINT ALL FLIGHTS");
            Console.WriteLine("8.PRINT ALL FLIGHTS OF THE CURRENT AIRLINE");
            Console.WriteLine("9.PRINT ALL PASSENGERS OF SOME FLIGHT");
            Console.WriteLine("10.PRINT ALL PASSENGERS");
            Console.WriteLine("11.ADD A PASSENGER");
            Console.WriteLine("12.EDIT A PASSENGER");
            Console.WriteLine("13.DELETE A PASSENGER");
            Console.WriteLine("14.SEARCH  OF A PASSENGER");
            Console.WriteLine("15.SEARCH BY MINIMUM PRICE");
            Console.WriteLine("16.PRICELIST");
            Console.WriteLine("17.SORT BY DATE");
            Console.WriteLine("18.EXIT A PROJECT");
            int Choice = int.Parse(Console.ReadLine());
            Console.Clear();
            return Choice;
        }

        public void ApplicationAll(Generator gn)
        {
            Passenger.PassFlight? passengertosearch;
            //object infpassenger;
            Loging loger = new Loging();
            loger.StartProgram();
            while (true)
            {
                Choice = getMenu();
                switch (Choice)
                {
                    case 1:
                        {
                            chosenLine = Airline.CheckAirline(gn.AirlineArray);
                            break;
                        }
                    case 2:
                        {
                            Airline.EditAirline(chosenLine);
                            break;
                        }
                    case 3:
                        {
                            Airline.DeleteAirline(chosenLine);
                            break;
                        }
                    case 4:
                        {
                            chosenLine?.AddItem();
                            break;
                        }
                    case 5:
                        {
                            flighttosearch = chosenLine.SearchFlight();
                            if (flighttosearch != null)
                                flighttosearch = chosenLine.EditItem(flighttosearch);
                            break;
                        }
                    case 6:
                        {
                            flighttosearch = chosenLine.SearchFlight();
                            if (flighttosearch != null)
                                chosenLine.DeleteItem(flighttosearch);
                            break;
                        }
                    case 7:
                        {
                            for (int i = 0; i < gn.AirlineArray.Length; i++)
                            {
                                gn.AirlineArray[i]?.PrintAllFlights(gn.AirlineArray[i]?.ArrivalList);
                                gn.AirlineArray[i]?.PrintAllFlights(gn.AirlineArray[i]?.DepartureFlightlist);
                            }
                            Console.ReadLine();
                            break;
                        }
                    case 8:
                        {
                            chosenLine?.PrintAllFlights(chosenLine?.ArrivalList);
                            chosenLine?.PrintAllFlights(chosenLine?.DepartureFlightlist);
                            Console.ReadLine();
                            break;
                        }
                    case 9:
                        {
                            flighttosearch = chosenLine.SearchFlight();
                            for (int i = 0; i < flighttosearch?.Customers?.Length; i++)
                            {
                                Console.WriteLine(flighttosearch?.Customers[i]?.ToString());
                            }
                            Console.ReadLine();
                            break;
                        }
                    case 10:
                        {
                            //Airline
                            for (int i = 0; i < gn.AirlineArray.Length; i++)
                            {
                                //Flights arrive
                                if (gn.AirlineArray[i]?.ArrivalList != null)
                                {
                                    foreach (var item in gn.AirlineArray[i]?.ArrivalList)
                                    {
                                        //Customers
                                        for (int j = 0; j < item.Customers.Length; j++)
                                        {
                                            Console.WriteLine(item.Customers[j]?.ToString());
                                        }
                                    }
                                }
                                //Flights departure
                                if (gn.AirlineArray[i]?.DepartureFlightlist != null)
                                {
                                    foreach (var item in gn.AirlineArray[i]?.DepartureFlightlist)
                                    {
                                        //Customers
                                        for (int j = 0; j < item.Customers.Length; j++)
                                        {
                                            Console.WriteLine(item.Customers[j]?.ToString());
                                        }
                                    }
                                }
                            }
                            Console.ReadLine();
                            break;
                        }
                    case 11:
                        {
                            /*
                             Add a passenger ONLY to a current Airline 
                             */
                            flighttosearch = chosenLine.SearchFlight();
                            flighttosearch?.AddItem();
                            break;
                        }
                    case 12:
                        {                                                      
                            dynamic infpassenger = Passenger.getAvalueOfstructure<int>(gn.AirlineArray);                            
                            if (infpassenger.flight != null)
                            {
                                infpassenger.flight.EditItem(infpassenger.passenger);
                            }
                            break;
                        }
                    case 13:
                        {
                            dynamic infpassenger = Passenger.getAvalueOfstructure<int>(gn.AirlineArray);
                            if (infpassenger.flight != null)
                            {
                                infpassenger.flight.DeleteItem(infpassenger.passenger);
                            }
                            break;
                        }
                    case 14:
                        {
                            Console.Clear();                            
                            var infpassenger = (Passenger)Passenger.getAvalueOfstructure<Passenger>(gn.AirlineArray);
                            if (infpassenger != null)
                            {                               
                                Console.WriteLine("Found a passenger:{0}  {1}", infpassenger.Firstname, infpassenger.Lastname);
                            }
                            Console.ReadLine();
                            break;
                        }
                    case 15:
                        {
                            //MINIMUM PRICE                           
                            Console.WriteLine("ENTER A MINIMUM PRICE TO COMPARE TO");
                            int minimumprice = int.Parse(Console.ReadLine());
                            for (int i = 0; i < gn.AirlineArray?.Length; i++)
                            {
                                if (gn.AirlineArray[i]?.ArrivalList == null)
                                    continue;
                                foreach (var item in gn.AirlineArray[i]?.ArrivalList)
                                {
                                    if (item is Flight)
                                    {
                                        foreach (var item1 in item.TicketList.FindAll(
                                                    (Ticket tc) =>
                                                    {
                                                        return tc.Price < minimumprice;
                                                    }))
                                        {
                                            Console.WriteLine("The number of flight:{0}, the price:{1}", item.Number, item1.Price);
                                        }
                                    }
                                }
                            }
                            Console.WriteLine("Press any key");
                            Console.ReadLine();
                            break;
                        }
                    case 16:
                        {
                            //PRICELIST
                            Console.Clear();
                            Console.WriteLine("PRICELIST OF THE CURRENT LINE OR TOTAL PRICE LIST(1-2)");
                            int choicepricelist = int.Parse(Console.ReadLine());
                            switch (choicepricelist)
                            {
                                case 1:
                                    {
                                        chosenLine.PriceList();
                                        break;
                                    }
                                default:
                                    {
                                        for (int i = 0; i < gn.AirlineArray.Length; i++)
                                        {
                                            gn.AirlineArray[i].PriceList();
                                        }
                                        break;
                                    }
                            }
                            Console.WriteLine("Press any key");
                            Console.ReadLine();
                            break;
                        }
                    //Sort all passengers by date of birth
                    case 17:
                        {
                            for (int i = 0; i < gn.AirlineArray.Length; i++)
                            {
                                if (gn.AirlineArray[i]?.ArrivalList != null)
                                {
                                    foreach (Flight item in gn.AirlineArray[i]?.ArrivalList)
                                    {
                                        //InputUtil.
                                        item.Customers = Passenger.Sortbyage(item?.Customers);
                                        Console.WriteLine("Ok!!");
                                    }
                                }
                                if (gn.AirlineArray[i]?.DepartureFlightlist != null)
                                {
                                    foreach (Flight item in gn.AirlineArray[i]?.DepartureFlightlist)
                                    {
                                        item.Customers = Passenger.Sortbyage(item?.Customers);
                                    }
                                }
                            }
                            break;
                        }
                    case 18:
                        {
                            loger.EndProgram();
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
