using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MotorsportManagerHelper.src.Models
{
    public class DriverStints
    {
        public Driver Driver { get; set; }
        public ObservableCollection<Stint> Stints { get; set; }
    }
}
