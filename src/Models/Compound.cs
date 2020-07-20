using System;
using System.Collections.Generic;
using System.Text;

namespace MotorsportManagerHelper.src.Models
{
    public class Compound
    {
        public string Name { get; set; }
        public int MinLaps { get; set; }
        public int MaxLaps { get; set; }
        public double Durability { get; set; }
        public string Thumbnail { get; set; }
    }
}
