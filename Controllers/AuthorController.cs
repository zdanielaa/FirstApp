using FirstApp.Model;
using FirstApp.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAllAuthor()
        {
            return Ok(await _authorService.GetAll());
        }
        [HttpGet("{AuthorId}")]
        public async Task<ActionResult<Author>> GetAuthor(int AuthorId)
        {
            var author = _authorService.GetById(AuthorId);
            if (author == null) { return BadRequest("Autor no encontrado"); }
            return Ok(await author);
        }

        [HttpPost]
        public async Task<ActionResult<Author>> CreateAuthor(string AuthorFirstName, String AuthorLastName, String Nationality, String Biography, String Photo)
        {
            return Ok(await _authorService.CreateAuthor(AuthorFirstName, AuthorLastName, Nationality, Biography, Photo));
        }
    }
}
