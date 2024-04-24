using FirstApp.Model;
using FirstApp.Repositories;

namespace FirstApp.Servicios
{
    public interface ILoanService
    {
        Task<List<Loan>> GetAll();
        Task<Loan> GetLoan(int id);
        Task<Loan> CreateLoan(int CopyId, int UserId, DateTime LoanDate, DateTime DueDate, DateTime ReturnDate, string LoanState, string LoanFine);
        Task<Loan> UpdateLoan(int LoanId, int? CopyId = null, int? UserId = null, DateTime? LoanDate = null, DateTime? DueDate = null, DateTime? ReturnDate = null, string? LoanState = null, string? LoanFine = null);
        Task<Loan> DeleteLoan(int LoanId);
    }

    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        public LoanService (ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }
        public async Task<Loan> CreateLoan(int CopyId, int UserId, DateTime LoanDate, DateTime DueDate, DateTime ReturnDate, string LoanState, string LoanFine)
        {
            return await _loanRepository.CreateLoan(CopyId, UserId, LoanDate, DueDate, ReturnDate, LoanState, LoanFine);
        }

        public async Task<Loan> DeleteLoan(int LoanId)
        {
           return await _loanRepository.DeleteLoan(LoanId);
        }

        public async Task<List<Loan>> GetAll()
        {
            return await _loanRepository.GetAll();
        }

        public async Task<Loan> GetLoan(int id)
        {
            return await _loanRepository.GetLoan(id);
        }

        public async Task<Loan> UpdateLoan(int LoanId, int? CopyId = null, int? UserId = null, DateTime? LoanDate = null, DateTime? DueDate=null, DateTime? ReturnDate = null, string? LoanState = null, string? LoanFine = null)
        {
            Loan newLoan = await _loanRepository.GetLoan(LoanId);

            if (newLoan != null)
            {
                if (CopyId != null) { newLoan.CopyId = (int)CopyId; }
                if (UserId != null) { newLoan.UserId = (int)UserId; }
                if (LoanDate != null) { newLoan.DueDate = (DateTime)LoanDate; }
                if (DueDate != null) { newLoan.DueDate = (DateTime)DueDate; }
                if (ReturnDate != null) { newLoan.ReturnDate = (DateTime)ReturnDate; }
                if (LoanState != null) { newLoan.LoanState = LoanState; }
                if (LoanFine != null) { newLoan.LoanFine = LoanFine; }
            }
            else { return null; }

            return await _loanRepository.UpdateLoan(newLoan);
        }
    }
}
