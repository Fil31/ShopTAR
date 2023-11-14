using Microsoft.AspNetCore.Mvc;
using Shop.ApplicationServices.Services;
using Shop.Models;

namespace Shop.Controllers
{
    public class ChuckNorrisController : Controller
    {
        private readonly IChuckNorrisService _chuckNorrisService;

        public ChuckNorrisController(IChuckNorrisService chuckNorrisService)
        {
            _chuckNorrisService = chuckNorrisService;
        }

        public async Task<IActionResult> Joke()
        {
            var jokeDto = await _chuckNorrisService.GetRandomJokeAsync();
            var viewModel = new ChuckNorrisJokeViewModel
            {
                Joke = jokeDto.Value
            };

            return View(viewModel);
        }
    }
}
