using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    internal class RaceEvent : Event
    {
        public int NumberOfRaces { get; set; }
        public List<Race> Races { get; set; }

        public RaceEvent(string eventName, string location, int numberOfRaces) : base(eventName, location)
        {
            this.NumberOfRaces = numberOfRaces;
            Races = new List<Race>();
        }


        
        public void AddRace(Race race)
        {
            if (Races.Count < NumberOfRaces)
            {
                Races.Add(race);
                Console.WriteLine($"Race '{race.RaceName}' added successfully.");
            }
            else
            {
                Console.WriteLine("Cap has been reach you cant add anymore");
            }
        }
    }
}