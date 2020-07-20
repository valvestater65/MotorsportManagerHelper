using System;
using System.Collections.Generic;

namespace MotorsportManagerHelper.src.Models
{
    public class Session
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double AverageLapTime { get; set; }
        public double FuelPerLap { get; set; }
        
        public int Laps { get; set; }

    }
}
