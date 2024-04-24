using FirstApp.Model;
using FirstApp.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genre>>> GetAllGenre()
        {
            return Ok(await _genreService.GetAll());
        }

        [HttpGet("{GenreId}")]
        public async Task<ActionResult<Genre>> GetAllGenre(int GenreId)
        {
            var genre = _genreService.GetGenre(GenreId);
            if (genre == null) { return BadRequest("Genero no encontrado"); }

            return Ok(await genre);
        }

        [HttpPost]
        public async Task<ActionResult<Genre>> CreateGenre(string GenreName, string GenreDescription)
        {
            return Ok(await _genreService.CreateGenre(GenreName, GenreDescription));
        }
    }
}
