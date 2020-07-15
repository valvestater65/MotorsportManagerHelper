using System;
using System.Collections.Generic;
using System.Text;

namespace MotorsportManagerHelper.src.Models
{
    public class Stint
    {
        public Guid Id  { get; set; }
        public int Laps { get; set; }
        public Compound Tyre { get; set; }
        public double Fuel { get; set; }
        public double PitTime { get; set; }
    }
}
