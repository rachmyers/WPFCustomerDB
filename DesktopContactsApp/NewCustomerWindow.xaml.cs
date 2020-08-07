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
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewCustomerWindow : Window
    {
        public NewCustomerWindow()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            
            Customer customer = new Customer()
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneNumberTextBox.Text,
                Address = addressTextBox.Text,
                DateLastTuned = (DateTime)date.SelectedDate,
                NextApptDate = (DateTime)nextDate.SelectedDate,
                NextApptTime = nextTime.Text,
                Notes = notesTextBox.Text
                
                //Id property is set to auto increment, so does not need to be defined here
            }; 

           
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                //create a table and pass in Contact type. If table already exists, this command will be ignored
                connection.CreateTable<Customer>();

                connection.Insert(customer);
                

            }

            //close the window
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            //close the window
            this.Close();
        }

        private void yesRB_Click(object sender, RoutedEventArgs e)
        {
            nextDate.IsEnabled = true;
            nextTime.IsEnabled = true;   
        }

        private void noRB_Click(object sender, RoutedEventArgs e)
        {
            nextDate.IsEnabled = false;
            nextTime.IsEnabled = false;
            
        }
    }
}
