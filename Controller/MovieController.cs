using MovieClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMoviesUsingList.Controller
{
    internal class MovieController
    {
        private static int maxMovies = 5;
        public MovieController()
        {
            MainMenu();
        }
        private static void MainMenu()
        {
            

            Console.WriteLine("This is Simple Movies App You can store upto 5 Movies");
            
            while (true)
            {
                new MovieManager();
                Console.WriteLine($"Menu :-\nMovie Status : {MovieManager.GetMovieCount}/{maxMovies}\n1.Display All \n2.Display By Year " +
                    $"\n3.Add Movies \n" + "4.Remove movie \n5.Clear All \n6.Exit");
                int response = Convert.ToInt32(Console.ReadLine());
                switch (response)
                {
                    case 1:
                        
                        DisplayMovie();
                        break;

                    case 2:
                        DisplayByYear();

                        break;

                    case 3:
                        AddMovie();
                        break;

                    case 4:
                        RemoveMovie();
                        break;

                    case 5:
                        ClearAll();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                };
            }
        }

        private static void ClearAll()
        {
            try
            {
                MovieManager.ClearAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void DisplayMovie()
        {
            try
            {

                List<Movie> movies = MovieManager.DisplayMovie();
                foreach (Movie movie in movies)
                {
                    if (movie != null)
                        Console.WriteLine(MovieManager.MovieInformation(movie));
                    else
                        break;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        public static void AddMovie()
        {
            try
            {
                MovieManager.CheckMovieCount();
                Console.Write("Enter Movie Name : ");
                string movieName = Console.ReadLine();
                Console.WriteLine("Enter Movie ID : ");
                int movieId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Genre : ");
                string movieGenre = Console.ReadLine();
                Console.WriteLine("Year : ");
                int movieYear = Convert.ToInt32(Console.ReadLine());

                MovieManager.AddMovies(movieName, movieId, movieGenre, movieYear);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        public static void DisplayByYear()
        {
            try
            {
                Console.WriteLine("Enter Year");
                int response = Convert.ToInt32(Console.ReadLine());

                List<Movie> findMovie = MovieManager.FindMoviesByYear(response);

                foreach (Movie movie in findMovie)
                {
                    Console.WriteLine(MovieManager.MovieInformation(movie));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void RemoveMovie()
        {
            try
            {
                Console.WriteLine("Enter Movie Name : ");
                string response = Console.ReadLine();
                MovieManager.RemoveMovie(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

    }
}
