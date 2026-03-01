
using Anime_Forest.Models;

namespace Anime_Forest.Repository
{
    public class GenreRepository : IGenreRepository
    {
        AppDbContext context;
        public GenreRepository(AppDbContext _context)
        {
            context = _context;
        }
        public void AddGenre(Genre genre)
        {
            context.Genres.Add(genre);
        }

        public void DeleteGenre(int id)
        {
            context.Genres.Remove(GetGenreById(id));
        }

        public List<Genre> GetAll()
        {
            return context.Genres.ToList();
        }

        public Genre GetGenreById(int id)
        {
            return context.Genres.FirstOrDefault(g => g.Id == id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void UpdateGenre(Genre genre)
        {
            context.Genres.Update(genre);
        }
    }
}
