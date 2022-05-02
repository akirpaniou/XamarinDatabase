using AppXam.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppXam.Data
{
    public class CourseRepository
    {
        public SQLiteConnection database;
        public CourseRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Course>();
        }
        public IEnumerable<Course> GetItems()
        {
            return database.Table<Course>().ToList();
        }
        public Course GetItem(int id)
        {
            return database.Get<Course>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Course>(id);
        }
        public int SaveItem(Course item)
        {
            if(item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
