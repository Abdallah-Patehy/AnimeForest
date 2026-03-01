using Anime_Forest.Models;
using Anime_Forest.Repository;
using Anime_Forest.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Anime_Forest.Controllers
{
    public class AnimeController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        IAnimeRepository AnimeRepository;
        IStudioRepository StudioRepository;
        IGenreRepository GenerRepository;
        IUserRepository UserRepository;
        public AnimeController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IUserRepository userRepository, IAnimeRepository animeRepository, IStudioRepository studioRepository, IGenreRepository generRepository)
        {
            AnimeRepository = animeRepository;
            StudioRepository = studioRepository;
            GenerRepository = generRepository;
            UserRepository = userRepository;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            List<Anime> animes = AnimeRepository.GetAnimeWithData();
            return View(animes);
        }
        public IActionResult Animes()
        {
            List<Anime> animes = AnimeRepository.GetAnimeWithData();
            return View("Animes", animes);
        }
        public IActionResult AnimeDetails(int id)
        {
            var anime = AnimeRepository.GetAnimeWithDataById(id);

            if (User.Identity.IsAuthenticated)
            {
                var userId = userManager.GetUserId(User);

                ViewBag.UserWatchStatus = UserRepository.GetWatchStatus(userId, id);
                ViewBag.IsFavorite = UserRepository.IsFavorite(userId, id);
            }

            return View("AnimeDetails", anime);
        }
        [HttpGet]
        public IActionResult AddAnime()
        {
            ViewData["studioslist"] = StudioRepository.GetAll();
            ViewData["genereslist"] = GenerRepository.GetAll();
            return View("AddAnime");
        }
        [HttpPost]
        [HttpPost]
        public IActionResult Save(Anime anime, List<int> selectedGenreIds, IFormFile ImageFile)
        {
            ViewData["studioslist"] = StudioRepository.GetAll();
            ViewData["genereslist"] = GenerRepository.GetAll();

            if (ImageFile != null && ImageFile.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }
                anime.ImageUrl = fileName;
            }

            if (selectedGenreIds == null || !selectedGenreIds.Any())
            {
                ModelState.AddModelError("GenreId", "Please select at least one genre.");
            }
            else
            {
                anime.AnimeGenres = selectedGenreIds
                    .Distinct()
                    .Select(genreId => new AnimeGenre { GenreId = genreId })
                    .ToList();
            }

            if (ModelState.IsValid)
            {
                AnimeRepository.Add(anime);
                AnimeRepository.SaveChanges();
                return RedirectToAction("Animes");
            }

            return View("AddAnime", anime);
        }
        public IActionResult Edit(int Id)
        {
            var anime = AnimeRepository.GetAnimeWithDataById(Id);
            ViewData["studioslist"] = StudioRepository.GetAll();
            ViewData["genereslist"] = GenerRepository.GetAll();
            return View("Edit", anime);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit(Anime anime, List<int> selectedGenreIds, IFormFile ImageFile)
        {
            if (ImageFile != null && ImageFile.Length > 0)
            {
                // احذف الصورة القديمة
                var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", anime.ImageUrl ?? "");
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }

                // ارفع الصورة الجديدة
                var fileName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
                var newPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using (var stream = new FileStream(newPath, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }
                anime.ImageUrl = fileName;
            }

            AnimeRepository.Update(anime, selectedGenreIds);
            AnimeRepository.SaveChanges();
            return RedirectToAction("Animes");
        }
        public IActionResult Delete(int Id)
        {
            AnimeRepository.Delete(Id);
            AnimeRepository.SaveChanges();
            return RedirectToAction("Animes");
        }
        [HttpPost]
        public async Task<IActionResult> AddToFav(Favorite favorite)
        {

            favorite.UserId = userManager.GetUserId(User);
            UserRepository.AddToFav(favorite);
            AnimeRepository.IncreaseFav(favorite.AnimeId);
            UserRepository.SaveChanges();
            return RedirectToAction($"AnimeDetails", "Anime", new { id = favorite.AnimeId });
        }
        [HttpPost]
        public IActionResult DeleteFromFav(int animeId)
        {
            var userId = userManager.GetUserId(User);
            UserRepository.RemoveFromFav(userId, animeId);
            AnimeRepository.DecreaseFav(animeId);
            return RedirectToAction($"AnimeDetails", "Anime", new { id = animeId });
        }



        [HttpPost]
        public async Task<IActionResult> AddToWatchList(Watchlist watchlist)
        {
            watchlist.UserId = userManager.GetUserId(User);
            UserRepository.AddToWatchList(watchlist);
            UserRepository.SaveChanges();
            return RedirectToAction($"AnimeDetails", "Anime", new { id = watchlist.AnimeId });
        }
        [HttpPost]
        public IActionResult RemoveFromWatchList(int animeId)
        {
            var userId = userManager.GetUserId(User);
            UserRepository.RemoveFromWatchList(userId, animeId);
            return RedirectToAction($"AnimeDetails", "Anime", new { id = animeId });
        }

    }



}