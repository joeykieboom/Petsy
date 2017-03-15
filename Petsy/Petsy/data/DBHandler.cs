using Petsy.data.models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petsy.data
{
    class DBHandler
    {
        public static ObservableCollection<Pets> petItems { get; set; }
        public static ObservableCollection<Food> foodItems { get; set; }
        public static ObservableCollection<Tasks> taskItems { get; set; }

        SQLiteConnection dbConn;

        public async Task<bool> onCreate(string DB_PATH)
        {
            try
            {
                if (!CheckFileExists(DB_PATH).Result)
                {
                    using (dbConn = new SQLiteConnection(DB_PATH))
                    {
                        dbConn.CreateTable<Pets>();
                        dbConn.CreateTable<Food>();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Pets
        public Pets getPet(int petID)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingPet = dbConn.Query<Pets>("select * from Pets where PetID = " + petID).FirstOrDefault();
                return existingPet;
            }
        }
        public ObservableCollection<Pets> getAllPets()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                List<Pets> myCollection = dbConn.Table<Pets>().ToList <Pets>();
                petItems = new ObservableCollection<Pets>(myCollection);
                return petItems;
            }
        }
        public void addPet(Pets pet)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(pet);
                    if (petItems != null) 
                    {
                        petItems.Add(pet);
                    }
                    else
                    {
                        petItems = new ObservableCollection<Pets>();
                        petItems.Add(pet);
                    }
                });
            }
        }

        //Food
        public Food getFood(int foodID)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingFood = dbConn.Query<Food>("select * from Food where FoodID = " + foodID).FirstOrDefault();
                return existingFood;
            }
        }
        public ObservableCollection<Food> getAllFood()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                List<Food> myCollection = dbConn.Table<Food>().ToList<Food>();
                foodItems = new ObservableCollection<Food>(myCollection);
                return foodItems;
            }
        }
        public void addFood(Food food)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(food);
                    if (foodItems != null)
                    {
                        foodItems.Add(food);
                    }
                    else
                    {
                        foodItems = new ObservableCollection<Food>();
                        foodItems.Add(food);
                    }
                });
            }
        }

        //Tasks
        public Food getTask(int taskID)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingTask = dbConn.Query<Food>("select * from Tasks where TaskID = " + taskID).FirstOrDefault();
                return existingTask;
            }
        }
        public ObservableCollection<Tasks> getAllTasks()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                List<Tasks> myCollection = dbConn.Table<Tasks>().ToList<Tasks>();
                taskItems = new ObservableCollection<Tasks>(myCollection);
                return taskItems;
            }
        }
        public void addTask(Tasks task)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(task);
                    if (taskItems != null)
                    {
                        taskItems.Add(task);
                    }
                    else
                    {
                        taskItems = new ObservableCollection<Tasks>();
                        taskItems.Add(task);
                    }
                });
            }
        }

        //
    }
}
