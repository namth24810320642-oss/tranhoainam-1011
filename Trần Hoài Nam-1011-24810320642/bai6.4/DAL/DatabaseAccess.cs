using System.Data.SqlClient;

namespace GarageManagement.DAL
{
    public class DatabaseAccess
    {
        private static string connectionString = @"Data Source=.;Initial Catalog=GarageDB;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}