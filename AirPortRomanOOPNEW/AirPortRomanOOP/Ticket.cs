using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortRomanOOP
{
    class Ticket
    {        
        private TicketClass classofTicket;
        public TicketClass ClassofTicket {
            get
            {
                return classofTicket;
            }
            set
            {
                classofTicket = value;
            }                
        }

        private TicketCategory ticketCategory;
        public TicketCategory TicketCategory
        {
            get
            {
                return ticketCategory;
            }
            set
            {
                ticketCategory = value;
            }
        }

        private decimal price;
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public Ticket(int classofTicket, int ticketCategory, decimal price)
        {
            this.classofTicket = (TicketClass)classofTicket;
            this.ticketCategory = (TicketCategory)ticketCategory;
            this.price = price;
        }

        public override string ToString()
        {
            return string.Format("The class ticket: {0}, the category {1}, the price:{2:C}", this.classofTicket, 
            this.ticketCategory, this.price);
        }
    }
}
