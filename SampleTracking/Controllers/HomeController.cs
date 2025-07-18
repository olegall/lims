using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SampleTracking.Models;

namespace SampleTracking.Controllers
{
    public class HomeController : Controller
    {
        ISampleRepository repo;
        public HomeController(ISampleRepository r)
        {
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
        public ActionResult Create(User user)
        {
            repo.Create(user);
            return RedirectToAction("Index");
        }
    }
}
