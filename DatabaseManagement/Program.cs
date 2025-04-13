using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestaurantBooking; // able to reference RestrauntBooking 

namespace DatabaseManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // new instance of RestaurantData class for db connection 
            RestaurantData db = new RestaurantData();

            // try, catch for when connecting to the database 
            try
            {
                using (db)
                {
                    // creating Customer objects 
                    Customer c1 = new Customer() { Name = "Garry Ledwith", ContactNumber = "086-123-4556" };
                    Customer c2 = new Customer() { Name = "Jimmy Doyle", ContactNumber = "087-323-4321" };
                    Customer c3 = new Customer() { Name = "Ellie Smith", ContactNumber = "086-863-9832" };

                    Console.WriteLine("Created the customers");

                    // adding customer objects to the Customers database 
                    db.Customers.Add(c1);
                    db.Customers.Add(c2);
                    db.Customers.Add(c3);

                    // creating Booking objects 
                    Booking b1 = new Booking() { BookingDate = DateTime.Now, NoOfParticipants = 5, CustomerId = 1};
                    Booking b2 = new Booking() { BookingDate = DateTime.Now, NoOfParticipants = 3, CustomerId = 2};

                    // adding Bookings to the Bookings database 
                    db.Bookings.Add(b1);
                    db.Bookings.Add(b2);

                    // confirmation messages 
                    Console.WriteLine("Added Bookings");
                    

                    // save changes made to database 
                    db.SaveChanges();

                    // confirmation messages 
                    Console.WriteLine("Changes saved");
                    Console.WriteLine("Press enter to continue");
                    Console.WriteLine("");
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Sorry an error occured when connecting to the database: " + ex.Message);
            }
        }
    }
}
