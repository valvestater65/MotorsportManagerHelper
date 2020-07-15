using System;
using System.Collections.Generic;
using System.Text;

namespace MotorsportManagerHelper.src.Models
{
    public class Strategy
    {
        public int Stops { get; set; }
        public Driver Driver { get; set; }
        public List<Stint> Stints { get; set; }
    }
}
