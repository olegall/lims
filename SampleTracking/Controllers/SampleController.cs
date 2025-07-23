using MessageBroker.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SampleTracking.Interfaces;
using SampleTracking.Models;

namespace SampleTracking.Controllers;

public class SampleController : Controller
{
    private readonly ISampleRepository _sampleRepository;
    private readonly IProducer _producer;
    private readonly IMapper _mapper;

    public SampleController(ISampleRepository sampleRepository, IProducer producer, IMapper mapper)
    {
        _sampleRepository = sampleRepository;
        _producer = producer;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("/samples")]
    public ActionResult Index()
    {
        var samplesVm = _mapper.Map(_sampleRepository.GetSamples());
        return View(samplesVm);
    }

    [HttpGet]
    [Route("/samples/{id}")]
    public ActionResult Index(int id)
    {
        var sample = _sampleRepository.GetSampleById(id);
        var sampleVM = _mapper.Map(sample);

        return Ok();
    }

    public ActionResult ShowCreate()
    {
        return View();
    }

    [HttpPost]
    [Route("/samples")]
    public ActionResult Create(SampleVM sampleVM)
    {
        var sample = _mapper.Map(sampleVM);
        _sampleRepository.Create(sample);

        _producer.SendToSamples("SampleCreated");

        return RedirectToAction("Index");
    }
}
