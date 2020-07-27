using System;
using System.Collections.Generic;
using System.Text;

namespace MotorsportManagerHelper.src.Models
{
    public class Tyre
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public double CliffPercentage { get; set; }
        public bool Slick { get; set; }
    }
}
