namespace TortenKreationSHS.Controllers {

    using Microsoft.AspNetCore.Mvc;
    using TortenKreationSHS.Repositories;

    public class HomeController : Controller {

        private readonly ICakeRepository cakeRepository;

        public HomeController(ICakeRepository cakeRepository) {
            this.cakeRepository = cakeRepository;
        }

        [HttpGet]
        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public IActionResult CakeList() {
            var cakes = this.cakeRepository.GetAll();
            return View(cakes);
        }

        [HttpGet]
        public IActionResult CakeDetail(string slug) {
            var cake = this.cakeRepository.GetBySlug(slug);
            if (null != cake) {
                return View(cake);
            } else {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult AboutMe() {
            return View();
        }

    }

}