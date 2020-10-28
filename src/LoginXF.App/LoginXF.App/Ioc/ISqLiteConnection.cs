using SQLite;

namespace LoginXF.App.Ioc
{
    public interface ISqLiteConnection
    {
        SQLiteConnection GetConnection();
    }
}
