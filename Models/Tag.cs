using System.Collections.Generic;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<AnimeTag> AnimeTags { get; set; } = new List<AnimeTag>();
}
