using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MotorsportManagerHelper.src.Models
{
    public class Season
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public ObservableCollection<Race> Races { get; set; }
        public ObservableCollection<Driver> Drivers { get; set; }
        public Car Car { get; set; }
        public int Year { get; set; }


        public Season()
        {
            Races = new ObservableCollection<Race>();
            Drivers = new ObservableCollection<Driver>();
        }
    }
}
