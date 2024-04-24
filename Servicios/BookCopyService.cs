using FirstApp.Model;
using FirstApp.Repositories;


namespace FirstApp.Servicios
{
    public interface IBookCopyService
    {
        Task<List<BookCopy>> GetAll();
        Task<BookCopy> GetById(int id);
        Task<BookCopy> CreateBookCopy(int BookId, string SerialNumber, string CopyState, string CopySite);
        Task<BookCopy> UpdateBookCopy(int BookCopyId, int? BookId = null, string? SerialNumber = null, string? CopyState = null, string? CopySite = null);
        Task<BookCopy> DeleteBookCopy(int id);
    }
    public class BookCopyService : IBookCopyService
    {
        private readonly IBookCopyRepository _bookCopyRepository;
        public BookCopyService(IBookCopyRepository bookCopyRepository)
        {
            _bookCopyRepository = bookCopyRepository;
        }
        public async Task<BookCopy> CreateBookCopy(int BookId, string SerialNumber, string CopyState, string CopySite)
        {
            return await _bookCopyRepository.CreateBookCopy(BookId, SerialNumber, CopyState, CopySite);
        }

        public async Task<BookCopy> DeleteBookCopy(int id)
        {
            return await _bookCopyRepository.DeleteBookCopy(id);
        }

        public async Task<List<BookCopy>> GetAll()
        {
            return await _bookCopyRepository.GetAll();
        }

        public async Task<BookCopy> GetById(int id)
        {
            return await _bookCopyRepository.GetBookCopy(id);
        }

        public async Task<BookCopy> UpdateBookCopy(int BookCopyId, int? BookId = null, string? SerialNumber = null, string? CopyState = null, string? CopySite = null)
        {
            BookCopy newBookCopy = await _bookCopyRepository.GetBookCopy(BookCopyId);

            if (newBookCopy != null)
            {
                if (BookId != null) { newBookCopy.BookId = (int)BookId; }
                if (SerialNumber != null) { newBookCopy.SerialNumber = SerialNumber; }
                if (CopyState != null) { newBookCopy.CopyState = CopyState; }
                if (CopySite != null) { newBookCopy.CopySite = CopySite; }
            }
            else { return null; }

            return await _bookCopyRepository.UpdateBookCopy(newBookCopy);

        }
    }
}
