using Microsoft.AspNetCore.Mvc;
using SampleTracking.Models;

namespace SampleTracking.Controllers
{
    public class HomeController : Controller
    {
        ISampleRepository repo;

        public HomeController(ISampleRepository r)
        {
            new Producer().Send("SampleCreated");
            repo = r;
        }

        public ActionResult Index()
        {
            return View(repo.GetSamples());
        }
 
        public ActionResult Create()
        {
            return View();
        }
 
        [HttpPost]
        public ActionResult Create(Sample sample)
        {
            repo.Create(sample);
            return RedirectToAction("Index");
        }
    }
}
