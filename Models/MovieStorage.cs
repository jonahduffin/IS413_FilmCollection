using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace joel_hilton_film_collection.Models
{
    public static class MovieStorage
    {
        private static List<MovieSubmissionResponse> movies = new List<MovieSubmissionResponse>();

        public static IEnumerable<MovieSubmissionResponse> Movies => movies;

        public static void AddMovie(MovieSubmissionResponse newMovie)
        {
            movies.Add(newMovie);
        }
    }
}
