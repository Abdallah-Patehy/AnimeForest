using Microsoft.AspNetCore.Identity;

namespace Anime_Forest.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? AvatarUrl { get; set; }

    }
}
