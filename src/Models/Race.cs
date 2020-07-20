using System;
using System.Collections.Generic;
using System.Text;

namespace MotorsportManagerHelper.src.Models
{
    public class Race
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime RaceDate { get; set; }
        public Track Track { get; set; }
        public int RaceLaps { get; set; }
        public List<Session> Sessions { get; set; }
        public List<Compound> Compounds { get; set; }
    }
}
