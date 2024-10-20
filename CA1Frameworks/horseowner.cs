using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    internal class HorseOwner : User
    {
        private List<Horse> ownedHorses;

        public HorseOwner(string userName, string role) : base(userName, role)
        {
            this.ownedHorses = new List<Horse>();
        }

        public void AddHorse(Horse horse)
        {
            ownedHorses.Add(horse);
            Console.WriteLine($"Horse {horse.HorseName} added successfully.");
        }

         public void EnterHorseInRace(Race race)
        {
            Console.WriteLine("Enter the horse ID to enter in the race:");
            int horseID = int.Parse(Console.ReadLine());

            Horse horseToEnter = ownedHorses.Find(h => h.HorseID == horseID);

            if (horseToEnter != null)
            {
                race.AddHorse(horseToEnter);
                Console.WriteLine($"Horse {horseToEnter.HorseName} entered in the race.");
            }
            else
            {
                Console.WriteLine("Horse doesnt exists check the Id again");
            }
        }
    }
}