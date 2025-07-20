using Microsoft.AspNetCore.Mvc;

namespace SampleTracking.Controllers;

public class HomeController : Controller
{
    public ActionResult Index()
    {
        return RedirectToAction("Index", "Sample");
    }
}
