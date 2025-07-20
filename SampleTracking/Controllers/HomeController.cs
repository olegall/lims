using MessageBroker.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SampleTracking.Models;

namespace SampleTracking.Controllers;

public class HomeController : Controller
{
    private readonly ISampleRepository _sampleRepository;
    private readonly IProducer _producer;

    public HomeController(ISampleRepository sampleRepository, IProducer producer)
    {
        _sampleRepository = sampleRepository;
        _producer = producer;
    }

    public ActionResult Index()
    {
        return View(_sampleRepository.GetSamples());
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Sample sample)
    {
        _sampleRepository.Create(sample);
        _producer.SendToSamples("SampleCreated");
        return RedirectToAction("Index");
    }
}
