using CarInfo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarInfo.Controllers
{
    public class SeedDbController : Controller
    {
        private ISeedService seedService;
        public SeedDbController(ISeedService service)
        {
            this.seedService = service;
        }
        public IActionResult Seed() 
        { 
            seedService.Seed();

            return View();
        }
    }
}
