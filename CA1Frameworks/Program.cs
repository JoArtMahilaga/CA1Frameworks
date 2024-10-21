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

            Console.WriteLine("Welcome to the Race Event Management System");
            Console.WriteLine("Select your role:");

            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {users[i].Role} - {users[i].UserName}");
            }

            Console.Write("Choose an option 1-3:");
            int choice = int.Parse(Console.ReadLine());

            if (choice >= 1 && choice <= users.Count)
            {
                users[choice - 1].DisplayMenu();
            }
            else
            {
                Console.WriteLine("Error you will now be exiting the application");
            }
        }
    }
}