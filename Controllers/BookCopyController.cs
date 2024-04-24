using FirstApp.Model;
using FirstApp.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCopyController : ControllerBase
    {
        private readonly IBookCopyService _bookCopyService;
        public BookCopyController(IBookCopyService bookCopyService)
        {
            _bookCopyService = bookCopyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookCopy>>> GetAllBookCopy()
        {
            return Ok(await _bookCopyService.GetAll());
        }
        
        [HttpGet("{BookCopyId}")]
        public async Task<ActionResult<BookCopy>> GetBookCopy(int BookCopyId)
        {
            var bookcopy = _bookCopyService.GetById(BookCopyId);
            if (bookcopy == null) { return BadRequest("No encontrado"); }

            return Ok(await bookcopy);
        }

        [HttpPost]
        public async Task<ActionResult<BookCopy>> CreateBookCopy(int BookId, string SerialNumber, string CopyState, string CopySite)
        {
            return Ok(await _bookCopyService.CreateBookCopy(BookId,SerialNumber,CopyState,CopySite));
        }
    }
}
