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
        public static ObservableCollection<Medicine> medicineItems { get; set; }
        public static ObservableCollection<Diaries> diaryItems { get; set; }
        public static ObservableCollection<SecurityQuestions> questionItems { get; set; }
        public static ObservableCollection<Regels1> regel1Items { get; set; }
        public static ObservableCollection<Regels2> regel2Items { get; set; }
        public static ObservableCollection<Regels3> regel3Items { get; set; }
        public static ObservableCollection<Regels4> regel4Items { get; set; }

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
                        dbConn.CreateTable<Medicine>();
                        dbConn.CreateTable<Diaries>();
                        dbConn.CreateTable<Tasks>();
                        dbConn.CreateTable<Regels1>();
                        dbConn.CreateTable<Regels2>();
                        dbConn.CreateTable<Regels3>();
                        dbConn.CreateTable<Regels4>();
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

        //Medicine
        public Medicine getMedicine(int medicineID)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingMedicine = dbConn.Query<Medicine>("select * from Medicine where MedicineID = " + medicineID).FirstOrDefault();
                return existingMedicine;
            }
        }
        public ObservableCollection<Medicine> getAllMedicine()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                List<Medicine> myCollection = dbConn.Table<Medicine>().ToList<Medicine>();
                medicineItems = new ObservableCollection<Medicine>(myCollection);
                return medicineItems;
            }
        }
        public void addMedicine(Medicine medicine)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(medicine);
                    if (medicineItems != null)
                    {
                        medicineItems.Add(medicine);
                    }
                    else
                    {
                        medicineItems = new ObservableCollection<Medicine>();
                        medicineItems.Add(medicine);
                    }
                });
            }
        }

        //Diaries
        public Diaries getDiary(int diaryID)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingDiary = dbConn.Query<Diaries>("select * from Diaries where DiaryID = " + diaryID).FirstOrDefault();
                return existingDiary;
            }
        }
        public ObservableCollection<Diaries> getAllDiaries()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                List<Diaries> myCollection = dbConn.Table<Diaries>().ToList<Diaries>();
                diaryItems = new ObservableCollection<Diaries>(myCollection);
                return diaryItems;
            }
        }
        public void addDiary(Diaries diary)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(diary);
                    if (diaryItems != null)
                    {
                        diaryItems.Add(diary);
                    }
                    else
                    {
                        diaryItems = new ObservableCollection<Diaries>();
                        diaryItems.Add(diary);
                    }
                });
            }
        }

        //SecurityQuestions
        public SecurityQuestions getSecurityQuestion(int questionID)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingQuestion = dbConn.Query<SecurityQuestions>("select * from SecurityQuestions where QuestionID = " + questionID).FirstOrDefault();
                return existingQuestion;
            }
        }
        public ObservableCollection<SecurityQuestions> getAllSecurityQuestions()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                List<SecurityQuestions> myCollection = dbConn.Table<SecurityQuestions>().ToList<SecurityQuestions>();
                questionItems = new ObservableCollection<SecurityQuestions>(myCollection);
                return questionItems;
            }
        }
        public void addSecurityQuestions(SecurityQuestions question)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(question);
                    if (questionItems != null)
                    {
                        questionItems.Add(question);
                    }
                    else
                    {
                        questionItems = new ObservableCollection<SecurityQuestions>();
                        questionItems.Add(question);
                    }
                });
            }
        }

        //Regels1
        public void addRegel1(Regels1 regel1)
        {
            using(var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(regel1);
                    if (regel1Items != null)
                    {
                        regel1Items.Add(regel1);
                    }
                    else
                    {
                        regel1Items = new ObservableCollection<Regels1>();
                        regel1Items.Add(regel1);
                    }
                });
            }
        }
        //Regels2
        public void addRegel2(Regels2 regel2)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(regel2);
                    if (regel2Items != null)
                    {
                        regel2Items.Add(regel2);
                    }
                    else
                    {
                        regel2Items = new ObservableCollection<Regels2>();
                        regel2Items.Add(regel2);
                    }
                });
            }
        }
        //Regels3
        public void addRegel3(Regels3 regel3)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(regel3);
                    if (regel3Items != null)
                    {
                        regel3Items.Add(regel3);
                    }
                    else
                    {
                        regel3Items = new ObservableCollection<Regels3>();
                        regel3Items.Add(regel3);
                    }
                });
            }
        }

        //Regels4
        public void addRegel4(Regels4 regel4)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(regel4);
                    if (regel4Items != null)
                    {
                        regel4Items.Add(regel4);
                    }
                    else
                    {
                        regel4Items = new ObservableCollection<Regels4>();
                        regel4Items.Add(regel4);
                    }
                });
            }
        }

    }
}
