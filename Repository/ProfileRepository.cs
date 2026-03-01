
using Anime_Forest.Models;
using Microsoft.EntityFrameworkCore;

namespace Anime_Forest.Repository
{
    public class ProfileRepository : IProfileRepository
    {

        AppDbContext context;
        public ProfileRepository(AppDbContext _context)
        {
            context = _context;
        }

        List<Anime> IProfileRepository.GetFavAnimes(string userId)
        {
            List<Anime> animes = context.Favorites
                    .Where(i => i.UserId == userId)
                    .Include(i => i.Anime)
                    .Include(i => i.Anime.AnimeGenres).ThenInclude(ag => ag.Genre)
                    .Select(i => i.Anime)
                    .ToList();
            return animes;
        }

        List<Anime> IProfileRepository.GetCompleted(string userid)
        {
            return context.Watchlists
                .Where(w => w.UserId == userid && w.Status == WatchStatus.Completed)
                .Include(i => i.Anime)
                .Include(i => i.Anime.AnimeGenres).ThenInclude(ag => ag.Genre)
                .Select(i => i.Anime)
                .ToList();
        }

        List<Anime> IProfileRepository.GetDropped(string userid)
        {
            return context.Watchlists
                .Where(w => w.UserId == userid && w.Status == WatchStatus.Dropped)
                .Include(i => i.Anime)
                .Include(i => i.Anime.AnimeGenres).ThenInclude(ag => ag.Genre)
                .Select(i => i.Anime)
                .ToList();
        }

        List<Anime> IProfileRepository.GetPlanned(string userid)
        {
            return context.Watchlists
                .Where(w => w.UserId == userid && w.Status == WatchStatus.Planned)
                .Include(i => i.Anime)
                .Include(i => i.Anime.AnimeGenres).ThenInclude(ag => ag.Genre)
                .Select(i => i.Anime)
                .ToList();
        }

        List<Anime> IProfileRepository.GetWatching(string userid)
        {
            return context.Watchlists
                .Where(w => w.UserId == userid && w.Status == WatchStatus.Watching)
                .Include(i => i.Anime)
                .Include(i => i.Anime.AnimeGenres).ThenInclude(ag => ag.Genre)
                .Select(i => i.Anime)
                .ToList();
        }
    }
}
