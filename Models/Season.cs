using System.Collections.Generic;

public class Season
{
    public int Id { get; set; }

    public int AnimeId { get; set; }
    public Anime Anime { get; set; }

    public int SeasonNumber { get; set; }
    public string Title { get; set; }
    public int? ReleaseYear { get; set; }
    public string PosterUrl { get; set; }

    public ICollection<Episode> Episodes { get; set; } = new List<Episode>();
}
