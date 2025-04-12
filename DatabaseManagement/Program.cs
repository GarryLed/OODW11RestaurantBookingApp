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

            try
            {
                using (db)
                {
                    Customer c1 = new Customer() { Name = "Garry Ledwith", ContactNumber = "086-123-4556" };
                    Customer c2 = new Customer() { Name = "Jimmy Doyle", ContactNumber = "087-323-4321" };
                    Customer c3 = new Customer() { Name = "Ellie Smith", ContactNumber = "086-863-9832" };

                    Console.WriteLine("Created the customers");

                    db.Customers.Add(c1);
                    db.Customers.Add(c2);
                    db.Customers.Add(c3);
                }
            }
            catch (Exception ex) 
            {
            
            }
        }
    }
}
