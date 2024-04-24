using FirstApp.Context;
using FirstApp.Model;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Repositories
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAll();
        Task<Author> Get(int id);
        Task<Author> CreateAuthor(String AuthorFirstName, String AuthorLastName, String Nationality, String Biography, String Photo);
        Task<Author> UpdateAuthor(Author author);
        Task<Author> DeleteAuthor(int id);
    }
       

    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _db;
        public AuthorRepository(AppDbContext db)
        {
            _db= db;
        }

        public async Task<Author> CreateAuthor(string AuthorFirstName, string AuthorLastName, string Nationality, string Biography, string Photo)
        {
            Author newAuthor = new Author
            {
                AuthorFirstName = AuthorFirstName,
                AuthorLastName = AuthorLastName,
                Nationality = Nationality,
                Biography = Biography,
                Photo = Photo
            };
            await _db.Authors.AddAsync(newAuthor);
            await _db.SaveChangesAsync();

            return newAuthor;
        }

        public async Task<Author> DeleteAuthor(int id)
        {
            Author author = await _db.Authors.FirstOrDefaultAsync(U => U.AuthorId == id);
            if (author != null) { _db.Authors.Remove(author); }

            _db.Authors.Update(author);
            await _db.SaveChangesAsync();

            return author;
        }

        public async Task<Author> Get(int id)
        {
            return await _db.Authors.Where(U => U.AuthorId == id).FirstAsync();
        }

        public async Task<List<Author>> GetAll()
        {
            return await _db.Authors.ToListAsync();
        }

        public async Task<Author> UpdateAuthor(Author author)
        {
            _db.Authors.Update(author);
            await _db.SaveChangesAsync();
            return author;
        }
    }
}
