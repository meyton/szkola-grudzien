using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Szkola.Data
{
    public class LocalDatabase
    {
        readonly SQLiteAsyncConnection database;

        public LocalDatabase(string path)
        {
            database = new SQLiteAsyncConnection(path);
        }
    }
}
