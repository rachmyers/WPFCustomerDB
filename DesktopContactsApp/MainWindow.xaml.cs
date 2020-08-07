using DesktopContactsApp.Classes;
using SQLite;
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

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Customer> contacts;
        public MainWindow()
        {
            InitializeComponent();

            contacts = new List<Customer>();

            ReadDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewCustomerWindow newCustomerWindow = new NewCustomerWindow();
            newCustomerWindow.ShowDialog();

            ReadDatabase();
        }

        void ReadDatabase()
        {
            List<Customer> contacts;
            using(SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Customer>();

                //Get query and return a list of type Customer
                contacts = (conn.Table<Customer>().ToList()).OrderBy(c => c.Name).ToList();
            }

            if (contacts != null)
            {              
                contactsListView.ItemsSource = contacts;
            }
        }


        private void contactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer selectedContact = (Customer)contactsListView.SelectedItem;

            if(selectedContact != null)
            {
                CustomerInfoWindow customerInfoWindow = new CustomerInfoWindow(selectedContact);
                customerInfoWindow.ShowDialog();
            }
        }
    }
}
