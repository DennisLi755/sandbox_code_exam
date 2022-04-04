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
            //set up sales and random object
            int sales = 0;
            Random rng = new Random();

            //set up array of movies with random amount of tickets
            Movie[] movies = new Movie[]
            {
                new Movie("The Batman", rng.Next(50, 1000)),
                new Movie("Turning Red", rng.Next(50, 1000)),
                new Movie("The Adam Project", rng.Next(50, 1000)),
                new Movie("Spider-Man: No Way Home", rng.Next(50, 1000)),
                new Movie("The Lost City", rng.Next(50, 1000))
            };
            
            //prompt user and display each movie with the amount of tickets
            Console.WriteLine("Welcome to the movies! We are currently showing each movie with the specified number of tickets left: ");
            foreach (Movie movie in movies) {
                Console.WriteLine(movie.Name + ": " + movie.Tickets);
            }

            Console.WriteLine("\n(To end the day, input 'exit')");

            //set up exit variable to leave game loop
            bool exit = false;

            //application loop
            while (!exit) {
                //set up the current movie for this iteration
                Movie currentMovie = new Movie("", 0);
                //set up variables for the loop
                int tickets;
                bool verify = true;
                
                //prompt user and sanitize user input
                Console.Write("\nWhich movie would you like to see today? ");
                string userInput = Console.ReadLine().Trim().ToLower();
                
                //check if user input is a movie within the array, then set the current movie
                //to that. That also verifies the application to move forward
                foreach (Movie movie in movies) {
                    if (userInput == movie.Name.ToLower()) { 
                        currentMovie = movie;
                        verify = true;
                        break;
                    }
                    else 
                        verify = false;
                }
                //if user inputs "exit" then change exit variable
                if (userInput == "exit")
                    exit = true;

                //if verification is never reached, go back to beginning of loop
                if (!verify) { 
                    Console.WriteLine("That is not a movie we are currently showing.");
                    continue;
                }

                //if the amount of tickets for the current movie is zero, go back to beginning of loop
                if (currentMovie.Tickets == 0) {
                    Console.WriteLine("That movie is sold out on tickets.");
                    continue;
                }

                //ticket value loop
                while (true) {
                    //prompt user
                    Console.Write("How many tickets do you want? ");
                    //try catch block to catch if users do not input a number
                    try {
                        tickets = Convert.ToInt32(Console.ReadLine());
                        //if the value exceeds the amount of tickets, return to beginning of ticket loop
                        if (tickets > currentMovie.Tickets) {
                            Console.WriteLine("That amount exceeds the available number of tickets!");
                            continue;
                        }
                        break;
                    }
                    //catches exception is user does not input a number
                    catch (Exception e) {
                        Console.WriteLine("(That's not a valid number...)");
                        continue;
                    }
                }
                //add the sales and tell the user
                currentMovie.AddSales(tickets);
                Console.WriteLine("There are now " + currentMovie.Tickets + " tickets left for " + currentMovie.Name);
                sales += tickets;
            }

            //print out sales result
            Console.WriteLine("\nSales Results: ");
            foreach (Movie movie in movies) {
                Console.WriteLine(movie.Name + ": " + movie.Sales);
            }
            Console.WriteLine("Total Sales: " + sales);
            Console.WriteLine("Thank you for watching movies with us!");


            Console.ReadLine();
            Console.Clear();
        }
    }
}
