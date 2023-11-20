using Microsoft.AspNetCore.Mvc;
using Shop.ApplicationServices.Services;
using Shop.Core.Dto.ChuckNorrisDtos;
using Shop.Core.ServiceInterface;
using Shop.Models;
using Shop.Models.ChuckNorris;


namespace Shop.Controllers

{
    public class ChuckNorrisController : Controller
    {
        private readonly IChuckNorrisServices _chuckNorrisServices;

        public ChuckNorrisController(IChuckNorrisServices chuckNorrisServices)
        {
            _chuckNorrisServices = chuckNorrisServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchChuckNorrisJokes(ChuckNorrisViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Joke", "ChuckNorris");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Joke()
        {
            ChuckNorrisResultDto dto = new();

            _chuckNorrisServices.ChuckNorrisResult(dto);
            ChuckNorrisViewModel vm = new();

            vm.Categories = dto.Categories;
            vm.CreatedAt = dto.CreatedAt;
            vm.IconUrl = dto.IconUrl;
            vm.Id = dto.Id;
            vm.UpdatedAt = dto.UpdatedAt;
            vm.Url = dto.Url;
            vm.Value = dto.Value;

            return View(vm);
        }
    }
}