using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    internal class RacecourseManager : User
    {


        public RacecourseManager(string userName, string role) : base(userName, role)
        {
          
        }

        public override void DisplayMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine($"Welcome {UserName}");
                Console.WriteLine("1 Create Race Event");
                Console.WriteLine("2 Add Race to Event");
                Console.WriteLine("3 View Upcoming Events");
                Console.WriteLine("4 Exit");
                Console.Write("Please choose an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateRaceEvent();
                        break;
                    case "2":
                        AddRaceToEvent();
                        break;
                    case "3":
                        ViewUpcomingEvents();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Mistakes were made please try again");
                        break;
                }

                Console.WriteLine();
            }
        }

   private void CreateRaceEvent()
        {
            Console.Write("Enter Event Name: ");
            string eventName = Console.ReadLine();

            Console.Write("Enter Location: ");
            string location = Console.ReadLine();

            Console.Write("Enter Number of Races: ");
            int numberOfRaces = int.Parse(Console.ReadLine());

            RaceEvent raceEvent = new RaceEvent(eventName, location, numberOfRaces);
            addRaceEvent(raceEvent);
            Console.WriteLine("Race event has been successfully made");
        }

        private void AddRaceToEvent()
        {
            if (RaceEvents.Count == 0)
            {
                Console.WriteLine("No events here yet you gotta make one");
                return;
            }

            Console.WriteLine("Select an Event:");
            for (int i = 0; i < RaceEvents.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {RaceEvents[i].EventName}");
            }

            int eventIndex = int.Parse(Console.ReadLine()) - 1;

            if (eventIndex < 0 || eventIndex >= RaceEvents.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            RaceEvent selectedEvent = RaceEvents[eventIndex];

            Console.Write("Enter Race Name):");
            string raceName = Console.ReadLine();
            if (string.IsNullOrEmpty(raceName))
            {
                raceName = $"Race {selectedEvent.Races.Count + 1}";
            }

            Console.Write("Enter Start Time (YYYY-MM-DD / HH:MM): ");
            DateTime startTime = DateTime.Parse(Console.ReadLine());

            Race newRace = new Race(raceName, startTime);
            selectedEvent.AddRace(newRace);
        }

       

        private void ViewUpcomingEvents()
        {
            if (RaceEvents.Count == 0)
            {
                Console.WriteLine("No upcoming events.");
                return;
            }

            foreach (var raceEvent in RaceEvents)
            {
                Console.WriteLine($"Event: {raceEvent.EventName}, Location: {raceEvent.Location}, Races: {raceEvent.NumberOfRaces}");

                foreach (var race in raceEvent.Races)
                {
                    Console.WriteLine($"   - Race: {race.RaceName}, Start Time: {race.StartTime}");

                    foreach (var horse in race.horses)
                    {
                        Console.WriteLine($"     - Horse: {horse.HorseName} (ID: {horse.HorseID})");
                    }
                }
            }
        }
    }
}