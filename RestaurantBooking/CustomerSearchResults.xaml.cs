using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace RestaurantBooking
{
    /// <summary>
    /// Interaction logic for CustomerServiceWindow.xaml
    /// </summary>
    public partial class CustomerSearchResults : Window
    {
      
        
        RestaurantData db = new RestaurantData(); // create a new instance of the RestaurantData class 

        // properties 
        private string _customerName, _contactNumber;
        private int _customerId, _numberOfCustomers;
        private DateTime _bookingDate; 
      

        public CustomerSearchResults()
        {
            InitializeComponent();
        }

        

        public CustomerSearchResults(string name, string contactNumber, DateTime bookingDate, int numberOfParticipants) : this()
        {
            _customerName = name;
            _contactNumber = contactNumber;
            _bookingDate = bookingDate;
            _numberOfCustomers = numberOfParticipants;

            // search customers table for existing name 
            var query = from c in db.Customers
                        where c.Name.Contains(name)
                        select c;

            var results = query.ToList();  

            if (results.Count > 0) 
            {
                lbxCustomers.ItemsSource = results;
            }

            // add details to list box for display 
            tbxName.Text = name;
            tbxNumber.Text = contactNumber;
            tblkDateOfBooking.Text = $"{bookingDate.ToShortDateString()}";
            tblkNoOfCustomers.Text = $"{numberOfParticipants.ToString()}";
            
        }


        private void btnCreateBooking_Click(object sender, RoutedEventArgs e)
        {
            if (_customerId == 0)
            {
                Customer customer = new Customer() { Name = tbxName.Text, ContactNumber = tbxNumber.Text };

                // add new customer to database 
                db.Customers.Add(customer);
                db.SaveChanges();
                _customerId = customer.CustomerId; 

            }

            // save booking 
            Booking booking = new Booking()
            {
                BookingDate = _bookingDate,
                NoOfParticipants = _numberOfCustomers,
                CustomerId = _customerId

            };

            // add the booking to the database 
            db.Bookings.Add(booking);
            db.SaveChanges();

            MessageBox.Show("Booking was created");
        }
    }
}
