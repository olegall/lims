using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //public class HomeController : Controller
    //{
    //    private readonly ILogger<HomeController> _logger;

    //    public HomeController(ILogger<HomeController> logger)
    //    {
    //        _logger = logger;
    //    }

    //    public IActionResult Index()
    //    {
    //        return View();
    //    }

    //    public IActionResult Privacy()
    //    {
    //        return View();
    //    }

    //    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //    public IActionResult Error()
    //    {
    //        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //    }
    //}

    public class HomeController : Controller
    {
        IUserRepository repo;
        public HomeController(IUserRepository r)
        {
            repo = r;
        }
        public ActionResult Index()
        {
            return View(repo.GetUsers());
        }
 
        public ActionResult Details(int id)
        {
            User user = repo.Get(id);
            if (user != null)
                return View(user);
            return NotFound();
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
 
        public ActionResult Edit(int id)
        {
            User user = repo.Get(id);
            if (user != null)
                return View(user);
            return NotFound();
        }
 
        [HttpPost]
        public ActionResult Edit(User user)
        {
            repo.Update(user);
            return RedirectToAction("Index");
        }
 
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            User user = repo.Get(id);
            if (user != null)
                return View(user);
            return NotFound();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
