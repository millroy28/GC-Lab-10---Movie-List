using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace GC_Lab_10_Movie_List
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Create and populate a list of movies
            List<Movie> catalog = new List<Movie>();
            catalog = PopulateMovieList(catalog);
            int categories = 4;
            string[] categoryNames = { "Sci-Fi", "Horror", "Animated", "Drama" };

            bool runAgain = true;
            do
            {
                // Prompts User for Category to search:
                int userSelection = GetCategory(categoryNames, categories) - 1;
                Console.WriteLine("You selected " + categoryNames[userSelection]);
                Console.WriteLine();

                // Displays List of Movies in that category
                Console.WriteLine("We have the following movies available in that category:");
                Console.WriteLine();
                List<string> sortedMovies = SelectMoviesByCat(catalog, categoryNames[userSelection]);
                DisplayMovieList(sortedMovies);
                Console.WriteLine();

                // Prompts user to continue or end.
                runAgain = GetYesOrNo("Would you like to look up another category? y/n: ");

            } while (runAgain);

            

        }

        public static void DisplayMovieList(List<string> movieList)
        {   //takes in a List of string that is a list of movie titles
            //sorts the list alphabeically
            //prints each movie on a new line, indented by a tab

            movieList.Sort();
            foreach (string movie in movieList)
            {
                Console.WriteLine($"\t" + movie);
            }    
        }
        public static List<string> SelectMoviesByCat(List<Movie> films, string category)
        {   //takes in a list of Movie and a string containing desired category
            //iterates through Movie list and adds Titles of the desired category to the a new List of strings

            List<string> selectedFilms = new List<string>();

            foreach(Movie film in films)
            {
                if(film.Category == category)
                {
                    selectedFilms.Add(film.Title);
                }
            }

            return selectedFilms;
        }
        public static int GetCategory(string[] catList, int catQuant)
        {   //Displays categories to the user, prompts user for desired category

            Console.WriteLine("Please select a category to see a list of movies available. Categories are:");
            Console.WriteLine();
            for( int i = 1; i <= catQuant; i++)
            {
                Console.WriteLine(i + ": " + catList[i-1]);
            }
            Console.WriteLine();
            int selection = GetUserInt("Please enter the number of your selection:", 1, 4);
            return selection;
        }
        public static List<Movie> PopulateMovieList(List<Movie> movies)
        {   //populates List<Movie> with movies and category pairs            
            movies.Add(new Movie("Wing Commander VII", "Sci-Fi"));
            movies.Add(new Movie("Where Once She Went While Weaving West", "Drama"));
            movies.Add(new Movie("Whispers on the Wings of the Angels", "Drama"));
            movies.Add(new Movie("Stabby Party II", "Horror"));
            movies.Add(new Movie("Dimpleswitch Junction", "Animated"));
            movies.Add(new Movie("Smidgen the Pidgeon goes to Newark", "Animated"));
            movies.Add(new Movie("Real to Reel", "Drama"));
            movies.Add(new Movie("Stabby Party IV: The After Party", "Horror"));
            movies.Add(new Movie("Twice upon a Time", "Drama"));
            movies.Add(new Movie("Race Condition", "Sci-Fi"));
            movies.Add(new Movie("Robot Ruckus", "Sci-Fi"));
            movies.Add(new Movie("Boo: Clowns!", "Horror"));
            movies.Add(new Movie("Limp Bizkit: Life Behind the Red Cap", "Horror"));
            movies.Add(new Movie("Smidgen the Pidgeon's Zoo Adventure: Livin' with the Gibbeons", "Animated"));
            movies.Add(new Movie("Insane Space Clown Posse", "Sci-Fi"));
            
            return movies;
        }

        public static bool GetYesOrNo(string prompt)
        {  //Prompts user for y/n; returns true for y and false for n
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine().ToLower();

                if (input == "y")
                    return true;
                else if (input == "n")
                    return false;
                else
                    Console.WriteLine("I'm sorry, I didn't get that.");
            }
        }

        public static int GetUserInt(string prompt, int lowerBound, int upperBound)
        {   //Prompts user for an int between two values, validates, returns
            while (true)
            {
                try
                {
                    Console.WriteLine(prompt);
                    int userNum = int.Parse(Console.ReadLine());
                    if (userNum >= lowerBound && userNum <= upperBound)
                    {
                        return userNum;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Input out of bounds. A whole number between {lowerBound} and {upperBound} is required: ");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    Console.WriteLine("I'm sorry, your input wasn't an integer.");
                }
                catch (Exception)
                {
                    Console.WriteLine();
                    Console.WriteLine("I'm sorry, your input wasn't valid.");
                }

            }

        }          
    }
}
