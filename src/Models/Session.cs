using System;
using System.Collections.Generic;
using System.Text;

namespace MotorsportManagerHelper.src.Models
{
    public class Session
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double AverageLapTime { get; set; }
    }
}
