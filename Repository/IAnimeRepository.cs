using System.Collections.Generic;
using Anime_Forest.Models;

namespace Anime_Forest.Repository
{
    public interface IAnimeRepository
    {
        // ---------- CRUD ----------
        void Add(Anime anime);
        void Update(Anime anime , List<int> selectedGenreIds);
        void Delete(int id);
        void DeleteAll();

        Anime GetById(int id);
        List<Anime> GetAll();

        // ---------- Eager Loading ----------
        List<Anime> GetAnimeWithData();
        Anime GetAnimeWithDataById(int id);

        // ---------- Search & Filter ----------
        List<Anime> Search(string term);
        //List<Anime> GetByGenre(int genreId);
        List<Anime> GetByStudio(int studioId);
        List<Anime> GetByStatus(AnimeStatus status);

        // ---------- Popularity ----------
        void IncreaseFav(int animeId);
        void DecreaseFav(int animeId);
        double GetPopularity(int animeId);
        void IncreaseViewCount(int animeId);
        double GetAverageRating(int animeId);


        // ---------- Save ----------
        void SaveChanges();
    }
}
