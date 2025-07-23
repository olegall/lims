using SampleTracking.Domain;
using SampleTracking.Models;

namespace SampleTracking.Interfaces;

public interface IMapper
{
    public SampleVM Map(Sample sample);

    public Sample Map(SampleVM sample);

    public IEnumerable<SampleVM> Map(IEnumerable<Sample> samples);
}
