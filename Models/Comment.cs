using System;

public class Comment
{
    public int Id { get; set; }

    public string UserId { get; set; } // AspNetUsers.Id

    public int AnimeId { get; set; }
    public Anime Anime { get; set; }

    public int? EpisodeId { get; set; }
    public Episode Episode { get; set; }

    public string Body { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
