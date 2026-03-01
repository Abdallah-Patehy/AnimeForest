using Anime_Forest.Models;
using System.Collections.Generic;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Anime> Animes { get; set; } = new List<Anime>();
    public ICollection<AnimeGenre> AnimeGenres { get; set; } = new List<AnimeGenre>();
}