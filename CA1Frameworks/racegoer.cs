using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    internal class RaceGoer : User
    {
        public RaceGoer(string userName, string role) : base(userName, role)
        {
        }

        public override void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine($"Welcome {UserName}");
                Console.WriteLine("1 View Upcoming Events");
                Console.WriteLine("2 Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewUpcomingEvents();
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("Mistakes has been made please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
             private void ViewUpcomingEvents()
        {
     
            Console.WriteLine("Enter logic to view upcoming events.");
        }
        }
    }

