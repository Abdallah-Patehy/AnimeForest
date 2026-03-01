namespace Anime_Forest.Repository
{
    public interface IGenreRepository
    {
        public void AddGenre(Genre genre);
        public void UpdateGenre(Genre genre);
        public void DeleteGenre(int id);
        public Genre GetGenreById(int id);
        public List<Genre> GetAll();
        void SaveChanges();


    }
}
