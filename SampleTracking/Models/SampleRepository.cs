using Dapper;
using Microsoft.Data.SqlClient;
using SampleTracking.Interfaces;

namespace SampleTracking.Models;

public class SampleRepository : ISampleRepository
{
    private readonly string _connectionString;

    public SampleRepository(string conn)
    {
        _connectionString = conn;
    }

    public IEnumerable<Sample> GetSamples()
    {
        using (var db = new SqlConnection(_connectionString))
        {
            return db.Query<Sample>("SELECT * FROM Samples");
        }
    }
    
    public Sample GetSampleById(int id)
    {
        using (var db = new SqlConnection(_connectionString))
        {
            var sample = db.Query<Sample>($"SELECT * FROM Samples WHERE Id = {id}").FirstOrDefault();
            
            if (sample is null) throw new Exception();
            
            return sample;
        }
    }

    public void Create(Sample sample)
    {
        using (var db = new SqlConnection(_connectionString))
        {
            var sqlQuery = "INSERT INTO Samples (Name, Code) VALUES(@Name, @Code)";

            db.Execute(sqlQuery, sample);
        }
    }
}