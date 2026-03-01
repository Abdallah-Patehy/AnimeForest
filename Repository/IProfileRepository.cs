namespace Anime_Forest.Repository
{
    public interface IProfileRepository
    {
        List<Anime> GetFavAnimes(string userId);

        public List<Anime> GetPlanned(string Id);
        public List<Anime> GetWatching(string Id);
        public List<Anime> GetCompleted(string userid);
        public List<Anime> GetDropped(string Id);

    }
}
