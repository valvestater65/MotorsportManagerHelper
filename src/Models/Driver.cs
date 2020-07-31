using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Animation;

namespace MotorsportManagerHelper.src.Models
{
    public class Driver
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double TyreConsumptionFactor { get; set; }
        public DateTime ContractExpiration { get; set; }
        public string TeamRole { get; set; }
        public int Age { get; set; }
        public double RaceFee { get; set; }
        public double ContractCancellationFee { get; set; }
    }
}
