using Microsoft.Data.SqlClient;

namespace KaraokeManagement.DAL;

public static class DatabaseAccess
{
    private const string ConnectionString = @"Data Source=.;Initial Catalog=KaraokeDB;Integrated Security=True;TrustServerCertificate=True";

    public static SqlConnection GetConnection() => new(ConnectionString);
}