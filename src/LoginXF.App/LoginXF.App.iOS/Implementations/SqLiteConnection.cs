using System;
using System.IO;
using LoginXF.App.Ioc;
using LoginXF.App.iOS.Implementations;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(SqLiteConnection))]
namespace LoginXF.App.iOS.Implementations
{
    public class SqLiteConnection : ISqLiteConnection
    {
        public SQLiteConnection GetConnection()
        {
            try
            {
                var folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                return new SQLiteConnection(Path.Combine(Path.Combine(folder, "..", "Library"), "persons.db3"));
            }
            catch
            {
                return null;
            }
        }
    }
}