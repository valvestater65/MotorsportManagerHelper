using System;
using System.Collections.Generic;
using System.Text;

namespace MotorsportManagerHelper.src.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double FuelConsumptionFactor { get; set; }
        public double TyreDecayFactor { get; set; }
    }
}
