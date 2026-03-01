using Anime_Forest.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
public class Anime
{
    public int Id { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public int EpisodeCount { get; set; }
    public int? ReleaseYear { get; set; }
    public AnimeStatus Status { get; set; } = AnimeStatus.Ongoing;

    public long ViewCount { get; set; } = 0;
    public double PopularityScore { get; set; } = 0;

    // FK
    //public int GenreId { get; set; }
    //[ValidateNever]
    //public Genre Genre { get; set; }

    public int StudioId { get; set; }
    [ValidateNever]
    public Studio Studio { get; set; }

    // Navigation
    public ICollection<Season> Seasons { get; set; } = new List<Season>();
    public ICollection<Episode> Episodes { get; set; } = new List<Episode>();

    public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    public ICollection<Watchlist> Watchlists { get; set; } = new List<Watchlist>();

    public ICollection<AnimeGenre> AnimeGenres { get; set; } = new List<AnimeGenre>();
    public ICollection<AnimeTag> AnimeTags { get; set; } = new List<AnimeTag>();
}