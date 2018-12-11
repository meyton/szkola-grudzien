using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szkola.Data.Entities;

namespace Szkola.Data
{
    public class LocalDatabase
    {
        public readonly SQLiteAsyncConnection Database;

        public LocalDatabase(string path)
        {
            Database = new SQLiteAsyncConnection(path);
            
            Database.CreateTableAsync<Student>().Wait();
            Database.CreateTableAsync<Subject>().Wait();
            Database.CreateTableAsync<Grade>().Wait();
        }

        public async Task<List<T>> GetItems<T>() where T : class, new()
        {
            // unit of work
            var items = await Database.Table<T>().ToListAsync();
            return items;
        }

        public async Task<T> GetItemByID<T>(int id) where T : class, ISqliteModel, new() 
        {
            var item = await Database.Table<T>().Where(x => x.ID == id).FirstOrDefaultAsync();
            return item;
        }

        public async Task<int> SaveItem<T>(T item)
        {
            var result = await Database.UpdateAsync(item);

            if (result == 0)
                result = await Database.InsertAsync(item);

            return result;
        }

        public async Task<int> InsertAll<T>(IEnumerable<T> items)
        {
            return await Database.InsertAllAsync(items);
        }

        public async Task<int> UpdateAll<T>(IEnumerable<T> items)
        {
            return await Database.UpdateAllAsync(items);
        }

        public async Task<int> DeleteItem<T>(T item)
        {
            return await Database.DeleteAsync(item);
        }
    }
}
