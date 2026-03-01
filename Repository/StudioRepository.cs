using Anime_Forest.Models;

namespace Anime_Forest.Repository
{
    public class StudioRepository : IStudioRepository
    {
        AppDbContext context;
        public StudioRepository(AppDbContext _context)
        {
            context = _context;
        }

        public void AddStudio(Studio studio)
        {
            context.Studios.Add(studio);
        }

        public void DeleteStudio(int id)
        {
            context.Studios.Remove(GetStudioById(id));
        }

        public List<Studio> GetAll()
        {
            return context.Studios.ToList();
        }

        public Studio GetStudioById(int id)
        {
            return context.Studios.FirstOrDefault(s => s.Id == id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Update(Studio studio)
        {
            context.Studios.Update(studio);
        }
    }
}
