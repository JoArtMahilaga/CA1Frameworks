using System;
using System.Collections.Generic;

namespace CA1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>
            {
                new RacecourseManager("Manager1", "Racecourse Manager"),
                new HorseOwner("Owner1", "Horse Owner"),
                new RaceGoer("Goer1", "Race Goer")
            };

            
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Welcome to the Race Event Management System");
                Console.WriteLine("Select your role:");

                for (int i = 0; i < users.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {users[i].Role} - {users[i].UserName}");
                }
                Console.WriteLine("Choose an option 1-4:");
                Console.WriteLine("Press 4 to exit");
                int choice = int.Parse(Console.ReadLine());

                if (choice >= 1 && choice <= users.Count)
                {
                    users[choice - 1].DisplayMenu();
                }
                else if (choice == 4)
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Error please enter the right option");
                }
            }
            
        }
    }
}