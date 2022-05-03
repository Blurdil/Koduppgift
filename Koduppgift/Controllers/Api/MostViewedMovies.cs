using Koduppgift.Utilis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public bool GetMovies()
        {
            var apikey = GetApiKey();
            return true;
        }

        private string GetApiKey()
        {
            var api = new ApiKey(_contextAccessor);
            return api.GetApiKey();
        }
    }
}
