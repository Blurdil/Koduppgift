using System.Collections;
using System.Collections.Generic;

namespace Koduppgift.Utilis
{
    public interface IApiLoad
    {
        public string GetTopRatedMovies(int page);
        public string GetSimilarMovies(int id);
        public string GetComments(int id);
    }
}
