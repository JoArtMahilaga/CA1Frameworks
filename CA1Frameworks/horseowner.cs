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


        public override void DisplayMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine($"Welcome {UserName}");
                Console.WriteLine("1 Add Horse");
                Console.WriteLine("2 Enter Horse in Race");
                Console.WriteLine("3 View Owned Horses");
                Console.WriteLine("4 Upload Horses To Races");
                Console.WriteLine("5 Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddNewHorse();
                        break;
                    case "2":
                        EnterHorseInRacePrompt();
                        break;
                    case "3":
                        ViewOwnedHorses();
                        break;
                    case "4":
                        UploadHorsesToRace();
                        break;
                    case "5":
                        exit=true;
                        break;
                    default:
                        Console.WriteLine("Mistakes have been made try again");
                        break;
                }

                Console.WriteLine();
            }
        }

        private void AddNewHorse()
        {
            Console.Write("Enter Horse Name: ");
            string name = Console.ReadLine();

            if (ownedHorses.Any(h => h.HorseName.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("A horse with this name already exists enter another different name.");
                return;
            }

            Console.Write("Enter Date of Birth (YYYY-MM-DD): ");
            string dob = Console.ReadLine();

            Console.Write("Enter Horse ID: ");
            int id;

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("error put another horse id.");
                    Console.Write("Enter Horse ID: ");
                    
                }

                if (ownedHorses.Any(h => h.HorseID == id))
                {
                    Console.WriteLine("a horse with this ID already exists choose another one.");
                    Console.Write("Enter Horse ID: ");
                }
                else
                {
                    break;
                }
            }

            Horse newHorse = new Horse(name, dob, id);
            AddHorse(newHorse);
        }

         private void UploadHorsesToRace()
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


        private void EnterHorseInRacePrompt()
        {
            if (RaceEvents.Count == 0)
            {
                Console.WriteLine("No race events available.");
                return;
            }

            Console.WriteLine("Available Race Events:");
            for (int i = 0; i < RaceEvents.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {RaceEvents[i].EventName} at {RaceEvents[i].Location}");
            }

            Console.Write("Select an event by number: ");
            int eventIndex = int.Parse(Console.ReadLine()) - 1;

            if (eventIndex < 0 || eventIndex >= RaceEvents.Count)
            {
                Console.WriteLine("Invalid selection. Please try again.");
                return;
            }

            RaceEvent selectedEvent = RaceEvents[eventIndex];

            Console.WriteLine($"Races for {selectedEvent.EventName}:");
            for (int i = 0; i < selectedEvent.Races.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {selectedEvent.Races[i].RaceName} - Start Time: {selectedEvent.Races[i].StartTime}");
            }

            Console.Write("Select a race by number: ");
            int raceIndex = int.Parse(Console.ReadLine()) - 1;

            if (raceIndex < 0 || raceIndex >= selectedEvent.Races.Count)
            {
                Console.WriteLine("Invalid selection. Please try again.");
                return;
            }

            Race selectedRace = selectedEvent.Races[raceIndex];

            Console.Write("Enter the Horse ID to enter in the race: ");
            int horseID = int.Parse(Console.ReadLine());

            Horse horseToEnter = ownedHorses.Find(h => h.HorseID == horseID);

            if (horseToEnter != null)
            {
                selectedRace.AddHorse(horseToEnter);
                Console.WriteLine($"Horse '{horseToEnter.HorseName}' entered in '{selectedRace.RaceName}' successfully.");
            }
            else
            {
                Console.WriteLine("Horse does not exist. Please check the ID and try again.");
            }
        }

        private void ViewOwnedHorses()
        {
            if (ownedHorses.Count == 0)
            {
                Console.WriteLine("No horses owned.");
                return;
            }

            Console.WriteLine("Owned Horses:");
            foreach (var horse in ownedHorses)
            {
                Console.WriteLine($"- {horse.HorseName} (ID: {horse.HorseID})");
            }
        }

        
    }
}