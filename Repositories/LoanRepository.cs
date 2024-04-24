using FirstApp.Context;
using FirstApp.Model;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Repositories
{   
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAll();
        Task<Loan> GetLoan(int id);
        Task<Loan> CreateLoan(int CopyId, int UserId, DateTime LoanDate, DateTime DueDate, DateTime ReturnDate, string LoanState, string LoanFine);
        Task<Loan> UpdateLoan(Loan loan);
        Task<Loan> DeleteLoan(int id);

    }
    public class LoanRepository : ILoanRepository
    {
        private readonly AppDbContext _db;
        public LoanRepository(AppDbContext db) 
        {
            _db = db;
        }
        public async Task<Loan> CreateLoan(int CopyId, int UserId, DateTime LoanDate, DateTime DueDate, DateTime ReturnDate, string LoanState, string LoanFine)
        {
            Loan newLoan = new Loan
            {
                CopyId = CopyId,
                UserId = UserId,
                LoanDate = LoanDate,
                DueDate = DueDate,
                ReturnDate = ReturnDate,
                LoanState = LoanState,
                LoanFine = LoanFine
            };
            await _db.Loans.AddAsync(newLoan);
            await _db.SaveChangesAsync();
            return newLoan;

        }

        public async Task<Loan> DeleteLoan(int id)
        {
            Loan loan = await _db.Loans.FirstOrDefaultAsync(U => U.LoanId == id);
            if (loan != null) { _db.Loans.Remove(loan); }

            _db.Loans.Update(loan);
            await _db.SaveChangesAsync();

            return loan;
        }

        public async Task<List<Loan>> GetAll()
        {
            return await _db.Loans.ToListAsync();
        }

        public Task<Loan> GetLoan(int id)
        {
            return _db.Loans.Where(U => U.LoanId == id).FirstAsync();
        }

        public async Task<Loan> UpdateLoan(Loan loan)
        {
            _db.Loans.Update(loan);
            await _db.SaveChangesAsync();
            return loan;
        }
    }
}
