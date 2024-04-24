using FirstApp.Model;
using FirstApp.Repositories;

namespace FirstApp.Servicios
{
    public interface IGenreService
    {
        Task<List<Genre>> GetAll();
        Task<Genre> GetGenre(int id);
        Task<Genre> CreateGenre(string GenreName, string GenreDescription);
        Task<Genre> UpdateGenre(int GenreId, string? GenreName = null, string? GenreDescription = null);
        Task<Genre> DeleteGenre(int id);
    }
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task<Genre> CreateGenre(string GenreName, string GenreDescription)
        {
            return await _genreRepository.CreateGenre(GenreName, GenreDescription);
        }

        public async Task<Genre> DeleteGenre(int id)
        {
            return await _genreRepository.DeleteGenre(id);
        }

        public async Task<List<Genre>> GetAll()
        {
            return await _genreRepository.GetAll();
        }

        public async Task<Genre> GetGenre(int id)
        {
            return await _genreRepository.GetGenre(id);
        }

        public async Task<Genre> UpdateGenre(int GenreId, string? GenreName = null, string? GenreDescription = null)
        {
            Genre newGenre = await _genreRepository.GetGenre(GenreId);

            if (newGenre != null)
            {
                if (GenreName != null) { newGenre.GenreName = GenreName; }
                if (GenreDescription != null) { newGenre.GenreDescription = GenreDescription; }
            }
            else { return null; }

            return await _genreRepository.UpdateGenre(newGenre);
        }
    }
}
