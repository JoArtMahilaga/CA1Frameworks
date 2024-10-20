using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    internal class Race
    {
        public string raceName;
        public DateTime startTime;
        public List<Horse> horses { get; set; }


        public Race(string raceName, DateTime startTime)
        {
            this.raceName = raceName;
            this.startTime = startTime;
            this.horses = new List<Horse>();
        }

        public string RaceName
        {
            get { return raceName; }
            set { raceName = value; }
        }

        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
    }
}