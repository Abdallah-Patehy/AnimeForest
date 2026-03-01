using Anime_Forest.ViewModel;

namespace Anime_Forest.Repository
{
    public interface IUserRepository
    {
        void AddToFav(Favorite favorite);
        void RemoveFromFav(string UserId , int AnimeId);
        void AddToWatchList(Watchlist watchlist);
        void RemoveFromWatchList(string UserId, int AnimeId);
        WatchStatus? GetWatchStatus(string userId, int animeId);
        bool IsFavorite(string userId, int animeId);
        void SaveChanges();

    }
}
