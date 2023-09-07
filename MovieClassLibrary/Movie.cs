using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClassLibrary
{
    [Serializable]
    public class Movie
    {
        public string MovieName { get; set; }
        public string MovieGenre { get; set; }
        public int MovieId { get; set; }
        public int MovieYear { get; set; }

        public Movie(string movieName, int movieId, string movieGenre, int movieYear)
        {
            MovieName = movieName;
            MovieGenre = movieGenre;
            MovieId = movieId;
            MovieYear = movieYear;

        }
    }
}
