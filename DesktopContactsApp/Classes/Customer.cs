using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopContactsApp.Classes
{
    public class Customer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateLastTuned { get; set; }
        public bool isNextApptSet { get; set; }
        public DateTime NextApptDate { get; set; }
        public string NextApptTime { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Email} - {Phone}";
        }
    }
}
