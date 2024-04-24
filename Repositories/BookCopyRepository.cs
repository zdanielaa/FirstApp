using FirstApp.Context;
using FirstApp.Model;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Repositories
{
    public interface IBookCopyRepository
    {
        Task<List<BookCopy>> GetAll();
        Task<BookCopy> GetBookCopy(int id);
        Task<BookCopy> CreateBookCopy(int BookId, string SerialNumber, string CopyState, string CopySite);
        Task<BookCopy> UpdateBookCopy(BookCopy bookcopy);
        Task<BookCopy> DeleteBookCopy(int id);

    }
    public class BookCopyRepository : IBookCopyRepository
    {
        private readonly AppDbContext _db;
        public BookCopyRepository(AppDbContext db) 
        {
            _db = db;
        }
        public async Task<BookCopy> CreateBookCopy(int BookId, string SerialNumber, string CopyState, string CopySite)
        {
            BookCopy newBookCopy = new BookCopy
            {
                BookId = BookId,
                SerialNumber = SerialNumber,
                CopyState = CopyState,
                CopySite = CopySite
            };
            await _db.AddAsync(newBookCopy);
            await _db.SaveChangesAsync();

            return newBookCopy;
        }

        public async Task<BookCopy> DeleteBookCopy(int id)
        {
            BookCopy bookCopy = await _db.BooksCopy.FirstOrDefaultAsync(U => U.BookCopyId == id);
            if (bookCopy != null) { _db.BooksCopy.Remove(bookCopy); }

            _db.BooksCopy.Update(bookCopy);
            await _db.SaveChangesAsync();
            return bookCopy;
        }

        public async Task<List<BookCopy>> GetAll()
        {
            return await _db.BooksCopy.ToListAsync();
        }

        public async Task<BookCopy> GetBookCopy(int id)
        {
            return await _db.BooksCopy.Where(U => U.BookCopyId == id).FirstAsync();
        }

        public async Task<BookCopy> UpdateBookCopy(BookCopy bookcopy)
        {
            _db.BooksCopy.Update(bookcopy);
            await _db.SaveChangesAsync();
            return bookcopy;
        }
    }
}
