using System;

public class Watchlist
{
    public string UserId { get; set; }
    public int AnimeId { get; set; }
    public Anime Anime { get; set; }

    public WatchStatus Status { get; set; } = WatchStatus.Planned;
    public int LastEpisodeWatched { get; set; } = 0;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
