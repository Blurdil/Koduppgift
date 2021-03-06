using Koduppgift.Models;
using Koduppgift.Utilis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Koduppgift.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MostViewedMovies : ControllerBase
    {
        private IHttpContextAccessor _contextAccessor;
        public MostViewedMovies(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public string GetMovies()
        {
            var api = new ApiLoad(_contextAccessor);
            return api.GetTopRatedMovies(1);
          
        }
    }
}
