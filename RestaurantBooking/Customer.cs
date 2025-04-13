using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBooking
{
    public class Customer
    {
        // properties 

        
        public int CustomerId { get; set; } // customer id 
        public string Name { get; set; } // Customer name 
        public string ContactNumber { get; set; } // Contact number 

        // one to many relationship 
        public virtual List<Booking> Bookings { get; set; }

        // override tostring method 
        public override string ToString()
        {
            return $"{Name}  {ContactNumber}";
        }
    }
}
