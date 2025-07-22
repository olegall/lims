using MessageBroker.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SampleTracking.Interfaces;
using SampleTracking.Models;

namespace SampleTracking.Controllers;

public class SampleController : Controller
{
    private readonly ISampleRepository _sampleRepository;
    private readonly IProducer _producer;

    public SampleController(ISampleRepository sampleRepository, IProducer producer)
    {
        _sampleRepository = sampleRepository;
        _producer = producer;
    }

    [HttpGet]
    [Route("/samples")]
    public ActionResult Index()
    {
        return View(_sampleRepository.GetSamples());
    }

    [HttpGet]
    [Route("/samples/{id}")]
    public ActionResult Index(int id)
    {
        var sample = _sampleRepository.GetSampleById(id);

        return Ok();
    }

    public ActionResult ShowCreate()
    {
        return View();
    }

    [HttpPost]
    [Route("/samples")]
    public ActionResult Create(Sample sample)
    {
        _sampleRepository.Create(sample);

        _producer.SendToSamples("SampleCreated");

        return RedirectToAction("Index");
    }
}
