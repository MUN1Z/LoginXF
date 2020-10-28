using LoginXF.App.Ioc;
using LoginXF.App.UWP.Implementations;
using SQLite;
using System;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqLiteConnection))]
namespace LoginXF.App.UWP.Implementations
{
    public class SqLiteConnection : ISqLiteConnection
    {
        public SQLiteConnection GetConnection()
        {
            try
            {
                SQLitePCL.Batteries.Init();
                return new SQLiteConnection(Path.Combine(ApplicationData.Current.LocalFolder.Path, "persons.db3"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
