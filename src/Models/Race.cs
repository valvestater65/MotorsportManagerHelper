using System;
using System.Collections.Generic;
using System.Text;

namespace MotorsportManagerHelper.src.Models
{
    public class Race
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Track Track { get; set; }
        public int RaceLaps { get; set; }
        public List<Session> Sessions { get; set; }
        public List<Compound> Compounds { get; set; }

        public Race()
        {
            Sessions = new List<Session>();
            Compounds = new List<Compound>();
        }
    }
}
