using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RestaurantBooking
{
    /// <summary>
    /// Restaurant Data Class which uses DbContext to connect to a database 
    /// 
    /// </summary>
    public class RestaurantData : DbContext 
    {
        // constructor 
        public RestaurantData() : base("RestaurantData_OOD2024Exam_GL") { } // Name of the database 
        public DbSet<Booking> Bookings { get; set;} // creates a Bookings table in the database 
        public DbSet<Customer> Customers { get; set;}  // creates a Customer table in the database 
    }
}
