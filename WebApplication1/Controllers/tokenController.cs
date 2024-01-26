using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Token;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tokenController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult getToken()
        {   
            return Created("", new buildToken().createToken());
            
        }
    }
}
