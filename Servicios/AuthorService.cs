using FirstApp.Model;
using FirstApp.Repositories;

namespace FirstApp.Servicios
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAll();
        Task<Author> GetById(int id);
        Task<Author> CreateAuthor(string AuthorFirstName, String AuthorLastName, String Nationality, String Biography, String Photo);
        Task<Author> UpdateAuthor(int AuhotId, String? AuthorFirstName = null, String? AuthorLastName = null, String? Nationality = null, String? Biography = null, String? Photo = null);
        Task<Author> DeleteAuthor(int id);
    }
    public class AuthorService : IAuthorService
    {   
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<Author> CreateAuthor(string AuthorFirstName, string AuthorLastName, string Nationality, string Biography, string Photo)
        {
            return await _authorRepository.CreateAuthor(AuthorFirstName, AuthorLastName, Nationality, Biography, Photo);
        }

        public async Task<Author> DeleteAuthor(int id)
        {
            return await _authorRepository.DeleteAuthor(id);
        }

        public async Task<List<Author>> GetAll()
        {
            return await _authorRepository.GetAll();
        }

        public async Task<Author> GetById(int id)
        {
            return await _authorRepository.Get(id);
        }

        public async Task<Author> UpdateAuthor(int AuhotId, string? AuthorFirstName = null, string? AuthorLastName = null, string? Nationality = null, string? Biography = null, string? Photo = null)
        {
            Author newAuthor = await _authorRepository.Get(AuhotId);

            if (newAuthor != null)
            {
                if (AuthorFirstName != null) { newAuthor.AuthorFirstName = AuthorFirstName; }
                if (AuthorLastName != null) { newAuthor.AuthorLastName = AuthorLastName; }
                if (Nationality != null) { newAuthor.Nationality = Nationality; }
                if (Biography != null) { newAuthor.Biography = Biography; }
                if (Photo != null) { newAuthor.Photo = Photo; }
            }
            else { return null; }

            return await _authorRepository.UpdateAuthor(newAuthor);
        }
    }
}
