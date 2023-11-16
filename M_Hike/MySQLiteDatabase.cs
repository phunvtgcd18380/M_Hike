using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Hike
{
    class MySQLiteDatabase
    {
        private SQLiteConnection _db;
        public const string DB_FILENAME = "MyDB.db3";
        public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        string dbPath = "";

        public const string HIKE_TABLE = "M_Hike_Table";

        public const string ID_COL = "ID";
        public const string NAME_COL  = "Name";
        public const string LOCATION_COL  = "Location";
        public const string DATE_COL  = "Date";
        public const string PARKING_COL  = "Parking";
        public const string LENGTH_COL  = "Length";
        public const string LEVEL_COL  = "Level";
        public const string DESCRIPTION_COL  = "Description";

        public MySQLiteDatabase()
        {
            init();
        }

        public void init()
        {
            dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, DB_FILENAME);
            _db = new SQLiteConnection(dbPath);
            _db.CreateTable<Hike>();
        }

        public int insertData(Hike hike)
        {
            return _db.Insert(hike);
        }
        public ObservableCollection<Hike> loadData()
        {
            return (new ObservableCollection<Hike>(_db.Table<Hike>().ToList()));
        }
        public Hike loadDataById(int id)
        {
            return _db.Table<Hike>().Where(i => i.id == id).FirstOrDefault();
        }
        public void DeleteData(Hike hike)
        {
            _db.Delete(loadDataById(hike.id));
        }
    }
}
