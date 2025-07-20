using SampleTracking.Models;

namespace SampleTracking.Interfaces;

public interface ISampleRepository
{
    void Create(Sample sample);

    List<Sample> GetSamples();

    Sample GetSampleById(int id);
}
