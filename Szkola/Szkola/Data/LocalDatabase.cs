using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Szkola.Data.Entities;

namespace Szkola.Data
{
    public class LocalDatabase
    {
        readonly SQLiteAsyncConnection database;

        public LocalDatabase(string path)
        {
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<Student>().Wait();
            database.CreateTableAsync<Subject>().Wait();
            database.CreateTableAsync<Grade>().Wait();
        }

        public async Task<List<T>> GetItems<T>() where T : class, new()
        {
            // unit of work
            var items = await database.Table<T>().ToListAsync();
            return items;
        }

        public async Task<T> GetItemByID<T>(int id) where T : class, ISqliteModel, new() 
        {
            var item = await database.Table<T>().Where(x => x.ID == id).FirstOrDefaultAsync();
            return item;
        }

        public async Task<int> SaveItem<T>(T item)
        {
            var result = await database.UpdateAsync(item);

            if (result == 0)
                result = await database.InsertAsync(item);

            return result;
        }

        public async Task<int> InsertAll<T>(IEnumerable<T> items)
        {
            return await database.InsertAllAsync(items);
        }

        public async Task<int> UpdateAll<T>(IEnumerable<T> items)
        {
            return await database.UpdateAllAsync(items);
        }

        public async Task<int> DeleteItem<T>(T item)
        {
            return await database.DeleteAsync(item);
        }
    }
}
