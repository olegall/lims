using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace SampleTracking.Models
{
    public interface ISampleRepository
    {
        void Create(Sample sample);
        List<Sample> GetSamples();
    }
    public class SampleRepository : ISampleRepository
    {
        string connectionString = null;
        public SampleRepository(string conn)
        {
            connectionString = conn;
        }
        public List<Sample> GetSamples()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Sample>("SELECT * FROM Samples").ToList();
            }
        }

        public void Create(Sample sample)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Samples (Name, No_) VALUES(@Name, @No_)";
                db.Execute(sqlQuery, sample);

                // если мы хотим получить id добавленного пользователя
                //var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                //int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                //user.Id = userId.Value;
            }
        }
    }
}