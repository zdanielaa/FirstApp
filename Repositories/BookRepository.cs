using FirstApp.Context;
using FirstApp.Model;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();
        Task<Book> GetBook(int id);
        Task<Book> CreateBook(String Title, int GenreId, int AuthorId, DateTime DatePublished, string Synopsis, string Cover);
        Task<Book> UpdateBook(Book book);
        Task<Book> DeleteBook(int id);

    }
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _db;
        public BookRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Book> CreateBook(String Title, int GenreId, int AuthorId, DateTime DatePublished, string Synopsis, string Cover)
        {
            Book newBook = new Book
            {
                Title = Title,
                GenreId = GenreId,
                AuthorId = AuthorId,    
                DatePublished = DatePublished,
                Synopsis = Synopsis,
                Cover = Cover
            };

            await _db.Books.AddAsync(newBook);
            await _db.SaveChangesAsync();

            return newBook;
        }

        public async Task<Book> DeleteBook(int id)
        {
            Book book = await _db.Books.FirstOrDefaultAsync(U => U.GenreId == id);
            if (book != null) { _db.Books.Remove(book); }

            _db.Books.Update(book);
            await _db.SaveChangesAsync();

            return book;
        }

        public async Task<List<Book>> GetAll()
        {
            return await _db.Books.ToListAsync();

        }

        public async Task<Book> GetBook(int id)
        {
            return await _db.Books.Where(U => U.BookId == id).FirstAsync();
        }

        public async Task<Book> UpdateBook(Book book)
        {
            _db.Books.Update(book);
            await _db.SaveChangesAsync();
            return book;
        }
    }
}
