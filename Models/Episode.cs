using System.Collections.Generic;
using System.Xml.Linq;

public class Episode
{
    public int Id { get; set; }

    public int AnimeId { get; set; }
    public Anime Anime { get; set; }

    public int? SeasonId { get; set; }
    public Season Season { get; set; }

    public int EpisodeNumber { get; set; }
    public string Title { get; set; }

    public string VideoUrl { get; set; }   // رابط الفيديو
    public int Duration { get; set; }      // بالدقائق

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
