using System;

public class Rating
{
    public int Id { get; set; }

    public string UserId { get; set; } // AspNetUsers.Id
    public int AnimeId { get; set; }
    public Anime Anime { get; set; }

    public int Stars { get; set; } // 1..10
    public string Review { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
