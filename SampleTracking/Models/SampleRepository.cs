using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace SampleTracking.Models
{
    public interface ISampleRepository
    {
        void Create(User user);
        List<User> GetSamples();
    }
    public class SampleRepository : ISampleRepository
    {
        string connectionString = null;
        public SampleRepository(string conn)
        {
            connectionString = conn;
        }
        public List<User> GetSamples()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<User>("SELECT * FROM Users").ToList();
            }
        }

        public void Create(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age)";
                db.Execute(sqlQuery, user);

                // если мы хотим получить id добавленного пользователя
                //var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                //int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                //user.Id = userId.Value;
            }
        }
    }
}