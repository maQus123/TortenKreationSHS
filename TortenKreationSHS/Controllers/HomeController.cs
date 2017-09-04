namespace TortenKreationSHS.Controllers {

    using Microsoft.AspNetCore.Mvc;
    using TortenKreationSHS.Models;
    using TortenKreationSHS.Repositories;

    public class HomeController : Controller {

        private readonly ICakeRepository cakeRepository;
        private readonly IVisitRepository visitRepository;

        public HomeController(ICakeRepository cakeRepository, IVisitRepository visitRepository) {
            this.cakeRepository = cakeRepository;
            this.visitRepository = visitRepository;
        }

        [HttpGet]
        public IActionResult Index() {
            this.TrackVisit();
            return View();
        }

        [HttpGet]
        public IActionResult CakeList() {
            this.TrackVisit();
            var cakes = this.cakeRepository.GetAll();
            this.TrackVisit();
            return View(cakes);
        }

        [HttpGet]
        public IActionResult CakeDetail(string slug) {
            var cake = this.cakeRepository.GetBySlug(slug);
            this.TrackVisit();
            if (null != cake) {
                return View(cake);
            } else {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult AboutMe() {
            this.TrackVisit();
            return View();
        }

        private void TrackVisit() {
            var visit = new Visit();
            visit.Ip = this.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            visit.UserAgent = this.Request.Headers["User-Agent"].ToString();
            visit.VisitedSite = this.Request.HttpContext.Request.Path;
            this.visitRepository.AddVisit(visit);
            return;
        }

    }

}
