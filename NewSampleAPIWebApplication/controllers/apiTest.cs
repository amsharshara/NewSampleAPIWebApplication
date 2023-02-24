using Microsoft.AspNetCore.Mvc;

namespace WebApplication16.Pages
{
    [ApiController]
    [Route("apple")]
    public class apiTest : Controller
    {
        [HttpGet("testget")]
        public async Task<IResult> testget()
        {
            return Results.Json($"a:{2}");
        }
    }
}
