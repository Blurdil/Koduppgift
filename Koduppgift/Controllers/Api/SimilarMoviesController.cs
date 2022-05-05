using Koduppgift.Utilis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Koduppgift.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimilarMoviesController : ControllerBase
    {
        private IHttpContextAccessor _contextAccessor;
        public SimilarMoviesController(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public string SimilarMovies(int id)
        {
            var api = new ApiLoad(_contextAccessor);
            return api.GetSimilarMovies(id);
        }
    }
}
