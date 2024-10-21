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

        public override void DisplayMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine($"Welcome {UserName}");
                Console.WriteLine("1 Create Race Event");
                Console.WriteLine("2 Add Race to Event");
                Console.WriteLine("3 Deploy Horses to Race");
                Console.WriteLine("4 View Upcoming Events");
                Console.WriteLine("5 Exit");
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
                        UploadHorsesToRace();
                        break;
                    case "4":
                        ViewUpcomingEvents();
                        break;
                    case "5":
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
            raceEvents.Add(raceEvent);
            Console.WriteLine("Race event has been successfully made");
        }

        private void AddRaceToEvent()
        {
            if (raceEvents.Count == 0)
            {
                Console.WriteLine("No events here yet you gotta make one");
                return;
            }

            Console.WriteLine("Select an Event:");
            for (int i = 0; i < raceEvents.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {raceEvents[i].EventName}");
            }

            int eventIndex = int.Parse(Console.ReadLine()) - 1;

            if (eventIndex < 0 || eventIndex >= raceEvents.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            RaceEvent selectedEvent = raceEvents[eventIndex];

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

        private void UploadHorsesToRace()
        {
            if (raceEvents.Count == 0)
            {
                Console.WriteLine("No events here yet you gotta make one");
                return;
            }

            Console.WriteLine("Select an Event:");
            for (int i = 0; i < raceEvents.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {raceEvents[i].EventName}");
            }

            int eventIndex = int.Parse(Console.ReadLine()) - 1;

            if (eventIndex < 0 || eventIndex >= raceEvents.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            RaceEvent selectedEvent = raceEvents[eventIndex];

            if (selectedEvent.Races.Count == 0)
            {
                Console.WriteLine("No races here yet you gotta make one");
                return;
            }

            Console.WriteLine("Select a Race:");
            for (int i = 0; i < selectedEvent.Races.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {selectedEvent.Races[i].RaceName}");
            }

            int raceIndex = int.Parse(Console.ReadLine()) - 1;

            if (raceIndex < 0 || raceIndex >= selectedEvent.Races.Count)
            {
                Console.WriteLine("Error invalid selection.");
                return;
            }

            Race selectedRace = selectedEvent.Races[raceIndex];


            while (true)
            {
                Console.Write("Enter Horse Name or type when youre finished: ");
                string horseName = Console.ReadLine();

                if (horseName.ToLower() == "exit")
                    break;

                Console.Write("Enter Horse ID ");
                int horseID = int.Parse(Console.ReadLine());

                Console.Write("Enter DoB (YYYY-MM-DD): ");
                String dob =Console.ReadLine();

                Horse newHorse = new Horse(horseName, dob, horseID);
                selectedRace.AddHorse(newHorse);
                Console.WriteLine($"Horse '{horseName}' added to the race.");
            }
        }

        private void ViewUpcomingEvents()
        {
            if (raceEvents.Count == 0)
            {
                Console.WriteLine("No upcoming events.");
                return;
            }

            foreach (var raceEvent in raceEvents)
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