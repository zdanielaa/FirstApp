using FirstApp.Model;
using FirstApp.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;
        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Loan>>> GetAllLoan()
        {
            return Ok(await _loanService.GetAll());
        }

        [HttpPost("{LoanId}")]
        public async Task<ActionResult<Loan>> GetLoan(int LoanId)
        {
            var loan = _loanService.GetLoan(LoanId);
            if (loan == null) { return BadRequest("Prestamo no encontrado"); }
            return Ok(await loan);
        }

        [HttpPost]
        public async Task<ActionResult<Loan>> CreateLoan(int CopyId, int UserId, DateTime LoanDate, DateTime DueDate, DateTime ReturnDate, string LoanState, string LoanFine)
        {
            return Ok(await _loanService.CreateLoan(CopyId, UserId, LoanDate, DueDate, ReturnDate, LoanState, LoanFine));
        }
    }
}
