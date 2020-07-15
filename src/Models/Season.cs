using System;
using System.Collections.Generic;
using System.Text;

namespace MotorsportManagerHelper.src.Models
{
    public class Season
    {
        public string Category { get; set; }
        public List<Race> Races { get; set; }
    }
}
