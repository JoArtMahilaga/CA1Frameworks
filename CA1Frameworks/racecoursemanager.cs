using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    internal class RacecourseManager : User
    {
        private List<RaceEvent> raceEvents;

        public RacecourseManager(string userName, string role) : base(userName, role)
        {
            this.raceEvents = new List<RaceEvent>();
        }
    }
}