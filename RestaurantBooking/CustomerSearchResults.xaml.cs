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
        public CustomerSearchResults(string name, string contactNumber, DateTime bookingDate, int numberOfParticipants)
        {
            InitializeComponent();

            // Display the values in your UI
            tbxName.Text = name;
            tbxNumber.Text = contactNumber;
            tblkDateOfBooking.Text = bookingDate.ToShortDateString();
            tblkNoOfCustomers.Text = numberOfParticipants.ToString();
        }


        private void btnCreateBooking_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new RestaurantData())
            {
                var newCustomer = new Customer()
                {

                    Name = tbxName.Text, // customer name 
                    ContactNumber = tbxNumber.Text // customer contact number 
                };

                db.Customers.Add(newCustomer); // add a new customer to database 
                db.SaveChanges(); // save the changes 

                // update the ui 
            }
        }
    }
}
