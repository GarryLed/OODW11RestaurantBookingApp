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
            DateTime selectedDate = dbShowBookings.SelectedDate.Value;

            if (selectedDate != null) 
            {
                SearchByDate(selectedDate); // calls the search by date method 
            }
        }

        // search database for a booksing on a specified date 
        public void SearchByDate(DateTime selectedDate)
        {
            try
            {
                var query = from b in db.Bookings
                            where b.BookingDate == selectedDate
                            select b;
                var results = query.ToList();

                // check if booking is on the selected date, and update 
                if (results.Count > 0) 
                {
                   // update list box 

                    // count the number of participants 

                    // update bookings 

                    // update abailability 


                }
                else
                {
                    // refresh screen 
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
