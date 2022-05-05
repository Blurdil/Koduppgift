using Koduppgift.Utilis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Koduppgift.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private IHttpContextAccessor _contextAccessor;
        public CommentsController(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public string Comments(int id)
        {
            var api = new ApiLoad(_contextAccessor);
            return api.GetComments(id);
        }
    }
}
