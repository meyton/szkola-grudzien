using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Szkola.Data.Entities
{
    public class Subject : ISqliteModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
