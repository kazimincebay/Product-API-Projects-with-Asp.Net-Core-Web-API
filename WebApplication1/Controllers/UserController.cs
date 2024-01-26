using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DomainModels;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;

        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string username,string password)
        {
            var user = await userRepository.LoginAsync(username,password);

            if (user != null)
            {
                HttpContext.Session.SetString("username", username);
                return Ok("Giriş İşlemi Başarılı");
            }


            return NotFound();
        }
        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> LogoutAsync ()
        {
           HttpContext.Session.Clear();
           return Ok("Çıkış İşlemi Başarılı");
        }
    }



                 
        
    }

