using Dapper;
using Microsoft.Data.SqlClient;
using SampleTracking.Domain;
using SampleTracking.Interfaces;

namespace SampleTracking.DAL;

public class SampleRepository : ISampleRepository
{
    private readonly string _connectionString;

    public SampleRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<Sample> GetSamples()
    {
        using var db = new SqlConnection(_connectionString);

        return db.Query<Sample>("SELECT * FROM Samples");
    }
    
    public Sample GetSampleById(int id)
    {
        using var db = new SqlConnection(_connectionString);

        var sample = db.Query<Sample>($"SELECT * FROM Samples WHERE Id = {id}").FirstOrDefault();

        return sample is null ? throw new Exception("Sample not found") : sample;
    }

    public void Create(Sample sample)
    {
        using var db = new SqlConnection(_connectionString);

        var sqlQuery = "INSERT INTO Samples (Name, Code) VALUES(@Name, @Code)";

        db.Execute(sqlQuery, sample);
    }
}