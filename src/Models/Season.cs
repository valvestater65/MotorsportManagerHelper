using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MotorsportManagerHelper.src.Models
{
    public class Season
    {
        public string Category { get; set; }
        public ObservableCollection<Race> Races { get; set; }
        public ObservableCollection<Driver> Drivers { get; set; }
        public Car Car { get; set; }
    }
}
