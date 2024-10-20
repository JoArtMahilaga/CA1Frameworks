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
            while (true)
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
                        return;
                    default:
                        Console.WriteLine("Mistakes were made please try again");
                        break;
                }

                Console.WriteLine();
            }
        }

        private void ViewUpcomingEvents()
        {
            throw new NotImplementedException();
        }

        private void UploadHorsesToRace()
        {
            throw new NotImplementedException();
        }

        private void AddRaceToEvent()
        {
            throw new NotImplementedException();
        }

        private void CreateRaceEvent()
        {
            throw new NotImplementedException();
        }
    }
    }