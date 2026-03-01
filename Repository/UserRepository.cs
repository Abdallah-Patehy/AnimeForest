using Anime_Forest.Models;
using Anime_Forest.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Anime_Forest.Repository
{
    public class UserRepository : IUserRepository
    {
        AppDbContext context;
        public UserRepository(AppDbContext _context)
        {
            context = _context;
        }

        public void AddToFav(Favorite model)
        {
            context.Favorites.Add(model);
        }
        public void RemoveFromFav(string userId , int animeId)
        {
            var fav = context.Favorites
                .FirstOrDefault(f => f.UserId == userId && f.AnimeId == animeId);

            if (fav != null)
            {
                context.Favorites.Remove(fav);
                context.SaveChanges();
            }
        }
        public bool IsFavorite(string userId, int animeId)
        {
            return context.Favorites
                .Any(f => f.UserId == userId && f.AnimeId == animeId);
        }
        public void AddToWatchList(Watchlist watchlist)
        {
            var userid = watchlist.UserId;
            var animeid = watchlist.AnimeId;
            var find = context.Watchlists
                .FirstOrDefault(f => f.UserId == userid && f.AnimeId == animeid);

            if (find != null)
            {
                find.Status = watchlist.Status;
                find.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                context.Watchlists.Add(watchlist);
            }

        }
        public void RemoveFromWatchList(string userId , int animeId)
        {
            var plan = context.Watchlists
                .FirstOrDefault(f => f.UserId == userId && f.AnimeId == animeId);

            if (plan != null)
            {
                context.Watchlists.Remove(plan);
                context.SaveChanges();
            }
        }
        public WatchStatus? GetWatchStatus(string userId, int animeId)
        {
            return context.Watchlists
                .FirstOrDefault(w => w.UserId == userId && w.AnimeId == animeId)
                ?.Status;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
