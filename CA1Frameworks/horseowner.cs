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
            while (true)
            {
                Console.WriteLine($"Welcome {UserName}");
                Console.WriteLine("1 Add Horse");
                Console.WriteLine("2 Enter Horse in Race");
                Console.WriteLine("3 View Owned Horses");
                Console.WriteLine("4 Exit");
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
                        return;
                    default:
                        Console.WriteLine("Mistakes have been made try again");
                        break;
                }

                Console.WriteLine();
            }
        }

        private void ViewOwnedHorses()
        {
            throw new NotImplementedException();
        }

        private void EnterHorseInRacePrompt()
        {
            throw new NotImplementedException();
        }

        private void AddNewHorse()
        {
            throw new NotImplementedException();
        }
    }
    }
