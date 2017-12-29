using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace AspNetCore.ClaimsValueProvider.Tests.Server
{
    [Route("api/[controller]"), Authorize]
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult GetClaim([FromClaim("testClaim")] string claimValue) => Ok(claimValue);
    }
}
