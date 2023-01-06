using MySql.Data.MySqlClient;

namespace MovieSys.Database;

public class DBConnection
{
    public MySqlConnection Connection { get; set; }

    public DBConnection(string? connectionString)
    {
        Connection = new MySqlConnection(connectionString);
    }

    public void Connect()
    {
        if (Connection != null)
            Connection.Open();
        else
            throw new Exception("MySql Connection is null.");
    }

    public void Close()
    {
        if (Connection != null)
        {
            Connection.Close();
            Connection.Dispose();
        }
        else
            throw new Exception("MySql Connection is null.");
    }
}
