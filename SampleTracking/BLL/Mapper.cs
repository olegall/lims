using SampleTracking.Domain;
using SampleTracking.Models;
using SampleTracking.Interfaces;

namespace SampleTracking.BLL;

public class Mapper : IMapper
{
    public SampleVM Map(Sample sample) => new SampleVM { Code = sample.Code, Name = sample.Name };

    public Sample Map(SampleVM sample) => new Sample { Code = sample.Code, Name = sample.Name };

    public IEnumerable<SampleVM> Map(IEnumerable<Sample> samples)
    {
        foreach (var sample in samples) yield return Map(sample);
    }
}
