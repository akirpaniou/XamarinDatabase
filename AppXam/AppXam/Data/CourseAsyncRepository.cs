using AppXam.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppXam.Data
{
    public class CourseAsyncRepository
    {
        SQLiteAsyncConnection database;
        public CourseAsyncRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
        }
        public async Task CreateTable()
        {
            await database.CreateTableAsync<Course>();
        }
        public async Task<List<Course>> GetItemsAsync()
        {
            return await database.Table<Course>().ToListAsync();
        }
        public async Task<int> DeleteItemAsync(Course item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> SaveItemAsync(Course item)
        {
            if(item.Id != 0)
            {
                await database.UpdateAsync(item);
                return item.Id;
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }
    }
}
