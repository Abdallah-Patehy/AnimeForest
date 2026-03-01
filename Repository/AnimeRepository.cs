using Anime_Forest.Models;
using Microsoft.EntityFrameworkCore;

namespace Anime_Forest.Repository
{
    public class AnimeRepository : IAnimeRepository
    {
        AppDbContext context;
        public AnimeRepository(AppDbContext _context)
        {
            context = _context;
        }

        public void Add(Anime anime)
        {
            context.Animes.Add(anime);
        }

        public void Update(Anime anime, List<int> selectedGenreIds)
        {
            var existingAnime = context.Animes
                .Include(a => a.AnimeGenres)
                .FirstOrDefault(a => a.Id == anime.Id);

            if (existingAnime == null) return;

            existingAnime.AnimeGenres.Clear();
            context.Entry(existingAnime).CurrentValues.SetValues(anime);
            existingAnime.AnimeGenres = selectedGenreIds
                .Distinct()
                .Select(genreId => new AnimeGenre
                {
                    GenreId = genreId
                })
                .ToList();

            SaveChanges();
        }

        public void Delete(int id)
        {
            var anime = context.Animes.Find(id);
            if (anime != null)
                context.Animes.Remove(anime);
        }

        public void DeleteAll()
        {
            context.Animes.RemoveRange(context.Animes);
        }

        public Anime GetById(int id)
        {
            return context.Animes.Find(id);
        }

        public List<Anime> GetAll()
        {
            return context.Animes
                .AsNoTracking()
                .ToList();
        }

        public List<Anime> GetAnimeWithData()
        {
            return context.Animes
                .AsNoTracking()
                .AsSplitQuery()
                .Include(a => a.Studio)
                .Include(a => a.AnimeGenres).ThenInclude(ag => ag.Genre)
                .Include(a => a.Seasons)
                .Include(a => a.Episodes)
                .Include(a => a.Ratings)
                .Include(a => a.Comments)
                .Include(a => a.AnimeTags).ThenInclude(at => at.Tag)
                .ToList();
        }

        public Anime GetAnimeWithDataById(int id)
        {
            return context.Animes
                .AsNoTracking()
                .AsSplitQuery()
                .Include(a => a.Studio)
                .Include(a => a.AnimeGenres).ThenInclude(ag => ag.Genre)
                .Include(a => a.Seasons).ThenInclude(s => s.Episodes)
                .Include(a => a.Ratings)
                .Include(a => a.Comments)
                .Include(a => a.AnimeTags).ThenInclude(at => at.Tag)
                .FirstOrDefault(a => a.Id == id);
        }

        public List<Anime> Search(string term)
        {
            term = term?.Trim();
            if (string.IsNullOrWhiteSpace(term))
                return new List<Anime>();

            return context.Animes
                .AsNoTracking()
                .Where(a =>
                    a.Title.Contains(term) ||
                    (a.Description != null && a.Description.Contains(term))
                )
                .ToList();
        }

        //public List<Anime> GetByGenre(int genreId)
        //{
        //    return context.Animes
        //        .AsNoTracking()
        //        .Where(a => a.GenreId == genreId)
        //        .ToList();

        //}
        public void IncreaseFav(int animeId)
        {
            var anime =  GetAnimeWithDataById(animeId);
            anime.PopularityScore++;
            context.Update(anime);
            SaveChanges();

        }
        public void DecreaseFav(int animeId)
        {
            var anime = GetAnimeWithDataById(animeId);
            anime.PopularityScore -- ;
            context.Update(anime);
            SaveChanges();

        }

        public double GetPopularity(int animeId)
        {
            var anime = GetAnimeWithDataById(animeId);
            return anime.PopularityScore;
        }
        public List<Anime> GetByStudio(int studioId)
        {
            return context.Animes
                .AsNoTracking()
                .Where(a => a.StudioId == studioId)
                .ToList();
        }

        public List<Anime> GetByStatus(AnimeStatus status)
        {
            return context.Animes
                .AsNoTracking()
                .Where(a => a.Status == status)
                .ToList();
        }

        public double GetAverageRating(int animeId)
        {
            return context.Ratings
                .AsNoTracking()
                .Where(r => r.AnimeId == animeId)
                .Select(r => r.Stars)
                .DefaultIfEmpty(0)
                .Average();
        }

        public void IncreaseViewCount(int animeId)
        {
            context.Animes
                .Where(a => a.Id == animeId)
                .ExecuteUpdate(a => a.SetProperty(x => x.ViewCount, x => x.ViewCount + 1));
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}