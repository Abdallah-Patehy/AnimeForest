using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Anime_Forest.ViewModel
{
    public class AddToFavViewModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string AnimeId { get; set; }
    }
}
