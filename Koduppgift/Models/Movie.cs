using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System.Collections.Generic;

namespace Koduppgift.Models
{
    public class Movie
    {
        public int id { get; set; }
        public string poster_path { get; set; }
        public string title { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public string overview { get; set; }

    }

    public class MovieList
    {
        public int page { get; set; }
        public List<Movie> results { get; set; }
    }

    public class MovieTransform
    {
        public string JsonToMovies(string o)
        {
            var movies = JsonConvert.DeserializeObject<MovieList>(o);
            return JsonConvert.SerializeObject(movies);
        }
    }
}
