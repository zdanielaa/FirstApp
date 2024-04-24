using FirstApp.Model;
using FirstApp.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUser()
        {
            return Ok(await _userService.GetAll());
        }
        [HttpGet("{UserId}")]
        public async Task<ActionResult<User>> GetUsuario(int UserId)
        {
            var user = _userService.Get(UserId);
            if (user == null) { return BadRequest("Usuario no encontrado"); }

            return Ok(await user);
        }
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(string FirstName, String LastName, String UserName, String Password, String Email, String ProfilePhoto, String UserType)
        {
            return Ok(await _userService.CreateUser(FirstName, LastName, UserName, Password, Email, ProfilePhoto, UserType));   
        }

        /*[HttpPut("{UserId}")]
        public async Task<ActionResult<User>> UpdateUser(int UserId, String? FirstName = null, String? LastName = null, String? Password = null, String? Email = null, String? ProfilePhoto = null, String? UserType = null)
        {
            User upUser = await _userRepositry.Get(UserId);
        }*/
    }
}
