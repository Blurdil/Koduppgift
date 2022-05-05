using Koduppgift.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections;
using System.Net.Http;
using System.Threading.Tasks;

namespace Koduppgift.Utilis
{
    public class ApiLoad : IApiLoad
    {
        private IHttpContextAccessor _httpContextAccessor;
        private const string ApiUrl = "https://api.themoviedb.org/3/";
        private const string Language = "en-US";

        public ApiLoad(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetApiKey()
        {
            string cookie = _httpContextAccessor.HttpContext?.Request.Cookies["ApiCookie"];
            //for testing.
            if (cookie == null)
            {
                return "53b0ae237ef3db33940b83560728cae4";
            }
            return cookie;
        }

        private string _apiKey { get { return GetApiKey(); } }

        public string GetTopRatedMovies(int page) 
        {
            string urlQuery = "movie/top_rated";
            string url = buildUrl(urlQuery, _apiKey, page);
            var response =  getResponse(url);
            string responseString =  response.Result.ToString();
            var jsonResponse = new MovieTransform().JsonToMovies(responseString);   
            return jsonResponse; 
        }

        public string GetSimilarMovies(int id)
        {
            ////movie/{movie_id}/similar
            string urlQuery = "movie/" + id + "/similar";
            string url = buildUrl(urlQuery, _apiKey);
            var response = getResponse(url);
            var responseString = response.Result.ToString();
            var jsonResponse = new MovieTransform().JsonToMovies(responseString);
            return jsonResponse;
        }

        public string GetComments(int id)
        {
            ////movie/{movie_id}/reviews
            var urlQuery = "movie/" + id + "/reviews";
            var url = buildUrl(urlQuery, _apiKey);
            var response = getResponse(url); 
            var responseString = response.Result.ToString();
            var jsonResponse = new CommentsTransform().JsonToComments(responseString);
            return jsonResponse;
        }

        private async Task<string> getResponse(string url)
        {
            string movies = "";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                 movies = await response.Content.ReadAsStringAsync();
            }
            return movies;

        }

        private string buildUrl(string query, string ApiKey, int page = 0)
        {
            string url = ApiUrl + query + "?api_key="  + ApiKey + "&" + Language;
            if(page > 0)
            {
                url += "&" + page;
            }
            return url;
        }
    }
}
