namespace Anime_Forest.Repository
{
    public interface IStudioRepository
    {
        void AddStudio(Studio studio);
        void Update(Studio studio);
        void DeleteStudio(int id);
        Studio GetStudioById(int id);
        List<Studio> GetAll();
        void SaveChanges();
    }
}
