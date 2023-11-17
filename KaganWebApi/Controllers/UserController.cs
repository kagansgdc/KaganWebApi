using KaganWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using KaganWebApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace KaganWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public ActionResult Login([FromBody]User user)
        {
            var token = service.Authenticate(user.Email, user.Password);
            if (token == null)
            {
                return Unauthorized();

            }
            return Ok(new { token, user });
        }
        private readonly UserService service;
        public UserController(UserService _service) {
        service = _service;
       }
        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            return service.GetUsers();
        }
        [HttpGet("{id:length(24)}")]
        public ActionResult<User> GetUser(string id) {
            var user = service.GetUser(id);
            return Json(user);
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            service.Create(user);
            return Json(user);
        }
    }
}
