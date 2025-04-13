using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBooking
{
    public class Booking
    {
        // properties 
        public int BookingId { get; set; } // booking id 
        public DateTime BookingDate { get; set; } // booking date 
        public int NoOfParticipants { get; set; } // number of participants 

        // foreign key and relationship 
        public int CustomerId { get; set; } // foreign key for customer table 
        public virtual Customer Customer { get; set; }

        // override string method 
        public override string ToString()
        {
            return $" {BookingDate.ToShortDateString()} {Customer.Name}, Party of {NoOfParticipants}";
        }
    }
}
