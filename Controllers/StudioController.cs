using Anime_Forest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Anime_Forest.Controllers
{
    public class StudioController : Controller
    {
        IStudioRepository StudioRepository;
        public StudioController(IStudioRepository studioRepository)
        {
            StudioRepository = studioRepository;
        }

        public IActionResult ShowAll()
        {
            List<Studio> studios =  StudioRepository.GetAll();
            return View("ShowAll",studios);
        }

        [HttpGet]
        public IActionResult AddNew()
        {
            return View("AddNew");
        }

        [HttpPost]
        public IActionResult Save(Studio studio)
        {
            if (ModelState.IsValid == true)
            {
                StudioRepository.AddStudio(studio);
                StudioRepository.SaveChanges();
                return RedirectToAction("ShowAll");
            }
            else
            {
                return View("AddNew", studio);
            }
        }
        public IActionResult Edit(int id) 
        {
            var studio = StudioRepository.GetStudioById(id);
            return View("Edit", studio);
        }
         [HttpPost]
         public IActionResult SaveEdit(Studio studio, int id)
         {
            if(ModelState.IsValid)
            {
                Studio EditStudio = StudioRepository.GetStudioById(id);
                EditStudio.Name = studio.Name;
                StudioRepository.Update(EditStudio);
                StudioRepository.SaveChanges();
                return RedirectToAction("ShowAll");
            }
            else
            {
                return View("Edit", studio);
            }
        }


    }
}
