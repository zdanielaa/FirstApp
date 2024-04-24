using FirstApp.Model;
using FirstApp.Repositories;

namespace FirstApp.Servicios
{
    public interface IBookService
    {
        Task<List<Book>> GetAll();
        Task<Book> GetById(int id);
        Task<Book> CreateBook(String Title, int GenreId, int AuthorId, DateTime DatePublished, string Synopsis, string Cover);
        Task<Book> UpdateBook(int BookId, String? Title =null, int? GenreId = null, int? AuthorId = null, DateTime? DatePublished = null, string? Synopsis = null, string? Cover = null);
        Task<Book> DeleteBook(int id);

    }
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Book> CreateBook(string Title, int GenreId, int AuthorId, DateTime DatePublished, string Synopsis, string Cover)
        {
            return await _bookRepository.CreateBook(Title, GenreId, AuthorId, DatePublished, Synopsis, Cover);
        }

        public async Task<Book> DeleteBook(int id)
        {
            return await _bookRepository.DeleteBook(id);
        }

        public async Task<List<Book>> GetAll()
        {
            return await _bookRepository.GetAll();
        }

        public async Task<Book> GetById(int id)
        {
            return await _bookRepository.GetBook(id);
        }

        public async Task<Book> UpdateBook(int BookId, String? Title = null, int? GenreId = null, int? AuthorId = null, DateTime? DatePublished = null, string? Synopsis = null, string? Cover = null)
        {
            Book newBook = await _bookRepository.GetBook(BookId);

            if (newBook != null)
            {
                if (Title != null) { newBook.Title = Title; }
                if (GenreId != null) { newBook.GenreId = (int)GenreId; }
                if (AuthorId != null) { newBook.AuthorId = (int)AuthorId; }
                if (DatePublished != null) { newBook.DatePublished = (DateTime)DatePublished; }
                if (Synopsis != null) { newBook.Synopsis = Synopsis; }
                if (Cover != null) { newBook.Cover = Cover; }
            }
            else { return null; }

            return await _bookRepository.UpdateBook(newBook);
        }
    }
}
