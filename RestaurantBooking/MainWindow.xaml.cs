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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RestaurantBooking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RestaurantData db = new RestaurantData(); // create a new instance of the RestaurantData class 
        const int CAPACITY = 40; // capacity of restaurant 
        public MainWindow()
        {
            InitializeComponent();
        }

        // update ui with refreshing screen 
        public void RefreshScreen()
        {
            lbxViewBookings.ItemsSource = null;
            tblkBookings.Text = "0";
            tblkAvailability.Text = "40";

            tbxEnterCustomerName.Text = "Customer Name";
            tbxGetCustomerNo.Text = "Contact Number";
            tbxNoOfCustomers.Text = "Number of Customers";
        }
        // customer search button 
        private void btnSearchCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        // delete button
        private void btnDeleteBooking_Click(object sender, RoutedEventArgs e)
        {

        }

        // shows booking for a selected date 
        private void ViewBooking(object sender, SelectedCellsChangedEventArgs e)
        {
            //DateTime selectedDate = dbShowBookings.SelectedDate.Value;

            //if (selectedDate != null) 
            //{
              //  SearchByDate(selectedDate); // calls the search by date method 
           // }
        }

        // search database for a booksing on a specified date 
        public void SearchByDate(DateTime selectedDate)
        {
            try
            {
                // LINQ for database query 
                var query = from b in db.Bookings
                            where b.BookingDate == selectedDate
                            select b;
                var results = query.ToList();

                // check if booking is on the selected date, and update 
                if (results.Count > 0) 
                {
                   // update list box 
                   lbxViewBookings.ItemsSource = results; // set the list box items to the results from the database query above 

                    // count the number of participants 
                    int totalParticipants = results.Sum(p => p.NoOfParticipants);

                    // update bookings 
                    tblkBookings.Text = totalParticipants.ToString();   

                    // update abailability (total capacity - total participants) 
                    tblkAvailability.Text = (CAPACITY - totalParticipants).ToString();

                }
                else
                {
                    // refresh screen if no result is found 
                    RefreshScreen();
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Sorry, error occured when trying to connect to database" + ex.Message);
            }
            
            
            

        }

        // deletes a booking from database 
        public void DeleteBooking(object sender, RoutedEventArgs e) 
        {
            
        }

       
    }
}
