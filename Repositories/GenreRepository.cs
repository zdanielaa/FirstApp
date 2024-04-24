using FirstApp.Context;
using FirstApp.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace FirstApp.Repositories
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetAll();
        Task<Genre> GetGenre(int id);
        Task<Genre> CreateGenre(string GenreName, string GenreDescription);
        Task<Genre> UpdateGenre(Genre genre);
        Task<Genre> DeleteGenre(int id);
    }
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _db;
        public GenreRepository(AppDbContext db) 
        {
            _db = db;
        }

        public async Task<Genre> CreateGenre(string GenreName, string GenreDescription)
        {
            Genre newGenre = new Genre
            {
                GenreName = GenreName,
                GenreDescription = GenreDescription
            };
            await _db.AddAsync(newGenre);
            await _db.SaveChangesAsync();

            return newGenre;
        }

        public async Task<Genre> DeleteGenre(int id)
        {
            Genre genre = await _db.Genres.FirstOrDefaultAsync(U => U.GenreId == id);
            if (genre != null) { _db.Genres.Remove(genre); }


            _db.Genres.Update(genre);
            await _db.SaveChangesAsync();

            return genre;
        }

        public async Task<List<Genre>> GetAll()
        {
            return await _db.Genres.ToListAsync();
        }

        public async Task<Genre> GetGenre(int id)
        {
            return await _db.Genres.Where(U => U.GenreId == id).FirstAsync();
        }

        public async Task<Genre> UpdateGenre(Genre genre)
        {
            _db.Genres.Update(genre);
            await _db.SaveChangesAsync();
            return genre;
        }
    }
}
