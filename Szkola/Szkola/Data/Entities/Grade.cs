using System;
using System.Collections.Generic;
using System.Text;

namespace Szkola.Data.Entities
{
    public class Grade : ISqliteModel
    {
        [SQLite.AutoIncrement, SQLite.PrimaryKey]
        public int ID { get; set; }
        public int Value { get; set; }
        public int SubjectID { get; set; }
        public int StudentID { get; set; }
    }
}
