using FirstApp.Model;
using FirstApp.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBook()
        {
            return Ok(await _bookService.GetAll());
        }
        [HttpGet("{BookId}")]
        public async Task<ActionResult<Book>> GetBook(int BookId)
        {
            var book = _bookService.GetById(BookId);
            if (book == null) { return BadRequest("Libro no encontrado"); }

            return Ok(await book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(String Title, int GenreId, int AuthorId, DateTime DatePublished, string Synopsis, string Cover)
        {
            return Ok(await _bookService.CreateBook(Title, GenreId, AuthorId, DatePublished, Synopsis, Cover));
        }
    }
}
