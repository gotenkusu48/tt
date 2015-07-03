
using SQLite.Net;
using System.IO;

namespace MasterDetailApp.Models
{
    static class ConnectionProvider
    {
        static ConnectionProvider()
        {
            using (var conn = GetConnection())
            {
                conn.CreateTable<Person>();
            }
        }

        public static SQLiteConnection GetConnection()
        {
            var databasePath = Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), 
                "database.db3");

            return new SQLiteConnection(
                new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(),
                databasePath);
        }
    }
}