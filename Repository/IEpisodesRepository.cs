namespace Anime_Forest.Repository
{
    public interface IEpisodesRepository
    {
        void AddEpisode(Episode episode);
        void UpdateEpisode(Episode episode);
        void DeleteEpisode(int id);
        Episode GetEpisodeById(int id);
            List<Episode> GetAllEpisodes();
            List<Episode> GetEpisodesBySeasonId(int seasonId);
                void SaveChanges();

    }
}
