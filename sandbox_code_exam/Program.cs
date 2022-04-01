using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox_code_exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int sales = 0;
            Random rng = new Random();
            string[] movies = {"The Batman", "Turning Red", "The Adam Project", "Spider-Man: No Way Home", "The Lost City"};
            Dictionary<string, int> screenings = new Dictionary<string, int>();
            foreach (string movie in movies) {
                screenings.Add(movie, rng.Next(50, 1000));
            }
            Console.WriteLine("Welcome to the movies! We are currently showing each movie with the specified number of tickets left: ");
            foreach (KeyValuePair<string, int> entry in screenings) {
                Console.WriteLine(entry.Key + ": " + entry.Value);
            }

            Console.WriteLine("\n(To move back a step in the application, input 'back')\n(To end the day, input 'exit')");

            bool exit = false;

            while (!exit) {
                int tickets;
                bool verify = true;
                Console.Write("\nWhich movie would you like to see today? ");
                string userInput = Console.ReadLine().Trim().ToLower();
                foreach (KeyValuePair<string, int> entry in screenings) {
                    if (userInput == entry.Key.ToLower()) { 
                        userInput = entry.Key;
                        verify = true;
                        break;
                    }
                    else 
                        verify = false;
                }
                if (!verify) { 
                    Console.WriteLine("That is not a movie we are currently showing.");
                    continue;
                }
                if (screenings[userInput] == 0) {
                    Console.WriteLine("That movie is sold out on tickets.");
                    continue;
                }
                while (true) {
                    Console.Write("How many tickets do you want? ");
                    try {
                        tickets = Convert.ToInt32(Console.ReadLine());
                        if (tickets > screenings[userInput]) {
                            Console.WriteLine("That amount exceeds the available number of tickets!");
                            continue;
                        }
                        break;
                    }
                    catch (Exception e) {
                        Console.WriteLine("(That's not a valid number...)");
                        continue;
                    }
                }
                screenings[userInput] -= tickets;
                Console.WriteLine("There are now " + screenings[userInput] + " tickets left for " + userInput);
                sales += tickets;
            }


            Console.ReadLine();
            Console.Clear();
        }
    }
}
