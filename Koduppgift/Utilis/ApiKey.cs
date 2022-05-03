using Microsoft.AspNetCore.Http;

namespace Koduppgift.Utilis
{
    public class ApiKey
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ApiKey(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }
        public string GetApiKey()
        {
            string cookie = _contextAccessor.HttpContext.Request.Cookies["ApiCookie"];
            return cookie;
        }
    }
}
