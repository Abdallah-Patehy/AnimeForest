using Anime_Forest.Models;
using Anime_Forest.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace Anime_Forest.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        IProfileRepository ProfileRepository;
        IAnimeRepository AnimeRepository;
        IStudioRepository StudioRepository;
        IGenreRepository GenerRepository;

        public ProfileController(IStudioRepository studioRepository, IGenreRepository generRepository,UserManager<ApplicationUser> userManager, IProfileRepository profileRepository, IAnimeRepository animeRepository)
        {
            ProfileRepository = profileRepository;
            StudioRepository = studioRepository;
            GenerRepository = generRepository;
            AnimeRepository = animeRepository;
            this.userManager = userManager;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FavAnimes()
        {
            var Id = userManager.GetUserId(User);
            var animes = ProfileRepository.GetFavAnimes(Id);
            ViewData["studioslist"] = StudioRepository.GetAll();
            ViewData["genereslist"] = GenerRepository.GetAll();
            return View("FavAnimes", animes);
        }


        public IActionResult Planned()
        {
            var Id = userManager.GetUserId(User);
            var animes = ProfileRepository.GetPlanned(Id);
            ViewData["studioslist"] = StudioRepository.GetAll();
            ViewData["genereslist"] = GenerRepository.GetAll();
            return View("Planned", animes);
        }
        public IActionResult Watching()
        {
            var Id = userManager.GetUserId(User);
            var animes = ProfileRepository.GetWatching(Id);
            ViewData["studioslist"] = StudioRepository.GetAll();
            ViewData["genereslist"] = GenerRepository.GetAll();
            return View("Watching", animes);
        }
        public IActionResult Completed()
        {
            var Id = userManager.GetUserId(User);
            var animes = ProfileRepository.GetCompleted(Id);
            ViewData["studioslist"] = StudioRepository.GetAll();
            ViewData["genereslist"] = GenerRepository.GetAll();
            return View("Completed", animes);
        }
        public IActionResult Dropped()
        {
            var Id = userManager.GetUserId(User);
            var animes = ProfileRepository.GetDropped(Id);
            ViewData["studioslist"] = StudioRepository.GetAll();
            ViewData["genereslist"] = GenerRepository.GetAll();
            return View("Dropped", animes);
        }
    }
}
