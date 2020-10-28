using System;
using System.IO;
using LoginXF.App.Droid.Implementations;
using LoginXF.App.Ioc;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqLiteConnection))]
namespace LoginXF.App.Droid.Implementations
{
    public class SqLiteConnection : ISqLiteConnection
    {
        public SQLiteConnection GetConnection()
        {
            try
            {
                SQLitePCL.Batteries.Init();
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "persons.db3");
                return new SQLiteConnection(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}