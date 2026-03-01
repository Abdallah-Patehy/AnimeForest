using Anime_Forest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Anime_Forest.Controllers
{
    public class GenreController : Controller
    {
        IGenreRepository GenerRepository; 
        public GenreController(IGenreRepository generRepository)
        {
            GenerRepository = generRepository;
        }
        public IActionResult ShowAll()
        {
            List<Genre> genres = GenerRepository.GetAll();
            return View("ShowAll", genres);
        }
        [HttpGet]
        public IActionResult AddNew()
        {
            return View("AddNew");
        }
        [HttpPost]
        public IActionResult Save(Genre genre)
        {
            if (ModelState.IsValid == true)
            {
                GenerRepository.AddGenre(genre);
                GenerRepository.SaveChanges();
                return RedirectToAction("ShowAll");
            }
            else
            {
                return View("AddNew", genre);
            }
        }
            public IActionResult Edit(int id)
            {
                var genre = GenerRepository.GetGenreById(id);
                return View("Edit", genre);
            }
            [HttpPost]
            public IActionResult SaveEdit(Genre genre, int id)
            {
                if(ModelState.IsValid)
                {
                    Genre EditGenre = GenerRepository.GetGenreById(id);
                    EditGenre.Name = genre.Name;
                    GenerRepository.UpdateGenre(EditGenre);
                    GenerRepository.SaveChanges();
                    return RedirectToAction("ShowAll");
                }
                else
                {
                    return View("Edit", genre);
                }
        }
    }
}
