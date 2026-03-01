using Anime_Forest.Repository;
using Anime_Forest.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Anime_Forest.Controllers
{
    public class UserController : Controller
    {
        IUserRepository UserRepository; 
        public UserController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddToFav(Favorite favorite)
        {
            UserRepository.AddToFav(favorite);
            return RedirectToAction("Anime", "AnimeDetails");
        }
    }
}
