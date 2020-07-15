using System;
using System.Collections.Generic;
using System.Text;

namespace MotorsportManagerHelper.src.Models
{
    public class Race
    {
        public Guid Id { get; set; }
        public DateTime RaceDate { get; set; }
        public Track Track { get; set; }
        public List<Session> Sessions { get; set; }
    }
}
