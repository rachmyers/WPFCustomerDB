using DesktopContactsApp.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopContactsApp.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {


        public Customer Contact
        {
            get { return (Customer)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Customer), typeof(ContactControl), 
                new PropertyMetadata(new Customer() { Name = "Firstname Last Name", Phone = "(123) 456-7890", 
                    Email = "username@domain.com"}, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl control = d as ContactControl;
           if (control != null)
            {
                control.nameTextBlock.Text = (e.NewValue as Customer).Name;
                control.emailTextBlock.Text = (e.NewValue as Customer).Email;
                control.phoneTextBlock.Text = (e.NewValue as Customer).Phone;
                control.addressTextBlock.Text = (e.NewValue as Customer).Address;
                control.dateTextBlock.Text = "Last Service Date: " + (e.NewValue as Customer).DateLastTuned.ToShortDateString();
                control.nextApptTextBlock.Text = "Next Scheduled Appt: " + (e.NewValue as Customer).NextApptDate.ToShortDateString()
                    + " at " + (e.NewValue as Customer).NextApptTime;
                control.notesTextBlock.Text = "Notes: " + (e.NewValue as Customer).Notes;
            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
