using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Hike
{
    [Table("M_Hike_Table")]
    public class Hike
    {
        [PrimaryKey, AutoIncrement]

        public int id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string date { get; set; }
        public string parking { get; set; }
        public string length { get; set; }
        public string level { get; set; }
        public string description { get; set; }
        public Hike(int id, string name, string location, string date, string parking, string length, string level, string description)
        {
            this.id = id;
            this.name = name;
            this.location = location;
            this.date = date;
            this.parking = parking;
            this.length = length;
            this.level = level;
            this.description = description;
        }
        public Hike( string name, string location, string date, string parking, string length, string level, string description)
        {
            this.name = name;
            this.location = location;
            this.date = date;
            this.parking = parking;
            this.length = length;
            this.level = level;
            this.description = description;
        }
        public Hike() { }

    }
}
