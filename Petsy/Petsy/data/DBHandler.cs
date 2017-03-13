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

        public Pets getPet(int petId)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingconact = dbConn.Query<Pets>("select * from Pets where p_Id =" + petId).FirstOrDefault();
                return existingconact;
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
    }
}
