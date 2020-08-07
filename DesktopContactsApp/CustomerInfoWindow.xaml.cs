using DesktopContactsApp.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class CustomerInfoWindow : Window
    {
        Customer customer;
        public CustomerInfoWindow(Customer customer)
        {
            InitializeComponent();

            this.customer = customer;
            nameTextBox.Text = customer.Name;
            phoneNumberTextBox.Text = customer.Phone;
            emailTextBox.Text = customer.Email;
            addressTextBox.Text = customer.Address;
            date.SelectedDate = customer.DateLastTuned;
            nextDate.SelectedDate = Convert.ToDateTime(customer.NextApptDate);
            nextTime.Text = customer.NextApptTime;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            customer.Name = nameTextBox.Text;
            customer.Phone = phoneNumberTextBox.Text;
            customer.Email = emailTextBox.Text;
            customer.Address = addressTextBox.Text;
            customer.DateLastTuned = (DateTime)date.SelectedDate;
            customer.NextApptDate = (DateTime)nextDate.SelectedDate;
            customer.NextApptTime = nextTime.Text;


            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Customer>();
                connection.Update(customer);
            }

            Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            

            if((MessageBox.Show("Are you sure you wish to delete this customer from the database?",
                "Delete Confirmation", MessageBoxButton.YesNo)) == MessageBoxResult.Yes)
            {
                using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                {
                    connection.CreateTable<Customer>();
                    connection.Delete(customer);
                }
            }

            

            Close();
        }

        private void yesRB_Click(object sender, RoutedEventArgs e)
        {
            nextDate.IsEnabled = true;

        }

        private void noRB_Click(object sender, RoutedEventArgs e)
        {
            nextDate.IsEnabled = false;
            nextTime.IsEnabled = false;
        }
    }
}
