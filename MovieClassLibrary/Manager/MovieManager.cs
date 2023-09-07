using MovieClassLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClassLibrary
{
    public class MovieManager
    {
        private static int maxMovies = 5;
        static string filePath = @"D:\Swabhav_Csharp\Project SimpleMoviesApp\SimpleMoviesUsingList\MovieInformation.txt";
        static List<Movie> movies = new List<Movie>();

        public static List<Movie> GetMovie { get { return movies; } }
        public static int GetMovieCount
        {
            get
            {
                if (movies != null)
                {
                    return movies.Count;
                }
                return 0;

            }
        }

        public MovieManager()
        {
            movies = DataSerializerDeserializer.BinaryDeserialize(filePath);
        }


        public static void AddMovies(string movieName, int movieID, string movieGenre, int movieYear)
        {
            Movie newMovie = new Movie(movieName, movieID, movieGenre, movieYear);
            movies.Add(newMovie);
            DataSerializerDeserializer.BinarySerializer(movies, filePath);
        }
        public static void RemoveMovie(string response)
        {
            if (GetMovieCount == 0)
            {
                throw new MovieErrorStore("There are no movies to Remove ");

            }
            Movie findMovie = movies.Find(Movie => Movie.MovieName == response);

            if (findMovie != null)
            {
                movies.Remove(findMovie);
                DataSerializerDeserializer.BinarySerializer(movies, filePath);
            }
            else
                throw new MovieErrorStore("There are no movies as " + response);



        }
        public static List<Movie> DisplayMovie()
        {
            if (GetMovieCount == 0)
            {
                throw new MovieErrorStore("There are no movies to Display ");

            }
            else
            {
                return movies;
            }
        }

        public static void ClearAll()
        {
            if (GetMovieCount == 0)
            {
                throw new MovieErrorStore("No movies to clear");
            }
            else
            {
                movies.RemoveRange(0, GetMovieCount);
                DataSerializerDeserializer.BinarySerializer(movies, filePath);
            }

        }

        public static string MovieInformation(Movie movie)
        {
            return $"Movie Name : {movie.MovieName}\n" +
                $"Movie ID : {movie.MovieId}\n" +
                $"Genre : {movie.MovieGenre}\n" +
                $"Year : {movie.MovieYear}\n" +
                $"-----------------------------------";
        }
        public static List<Movie> FindMoviesByYear(int response)
        {
            if (GetMovieCount == 0)
            {
                throw new MovieErrorStore("There are no movies to Find ");

            }
            List<Movie> foundMovies = movies.FindAll(Movie => Movie.MovieYear == response);
            if (foundMovies.Count == 0)
            {
                throw new MovieErrorStore("There are no movies for year : " + response);
            }
            return foundMovies;
        }
        public static void CheckMovieCount()
        {
            if (GetMovieCount == maxMovies)
            {
                throw new MovieErrorStore("There are alredy 5 Movies in List");
            }
        }
    }
}
