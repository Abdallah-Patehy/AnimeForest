using System.Collections.Generic;
using Anime_Forest.Models;
public class Studio
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Anime> Animes { get; set; } = new List<Anime>();
}
