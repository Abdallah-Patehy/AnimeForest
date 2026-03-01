using System;

public class Favorite
{
    public string UserId { get; set; }
    public int AnimeId { get; set; }
    public Anime Anime { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
