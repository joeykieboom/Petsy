using Petsy.data;
using Petsy.data.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Petsy
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<Pets> pets = new ObservableCollection<Pets>();
        ObservableCollection<PetDataTemplate> petsDataTemplate = new ObservableCollection<PetDataTemplate>();
        ObservableCollection<Diaries> diarys = new ObservableCollection<Diaries>();
        ObservableCollection<Tasks> tasks = new ObservableCollection<Tasks>();
        DBHandler db;

        public MainPage()
        {
            this.InitializeComponent();
            
            this.NavigationCacheMode = NavigationCacheMode.Required;
            db = new DBHandler();
            
            pets = db.getAllPets();
            food = db.getAllFood();
            diarys = db.getAllDiaries();

            foreach (var pet in pets)
            {
                PetDataTemplate petItem = new PetDataTemplate();
                petItem.p_Id = pet.PetID;
                petItem.p_Name = pet.p_Name;
                petItem.p_Age = pet.p_Age;

                Regels3 regel3 = db.getRegels3(pet.PetID);
                if (regel3 != null)
                {
                    Tasks task = db.getTask(regel3.TaskID);
                    petItem.t_Id = task.TaskID;
                    petItem.t_Name = task.t_Name;
                }

                petsDataTemplate.Add(petItem);
            }

            pets.CollectionChanged += Pets_CollectionChanged;

            // Set the cells to the Page's DataContext. All controls on 
            // the page will inherit this.
            history.DataContext = petsDataTemplate;
            test1.ItemsSource = tasks.Where(task => task.t_Completed == "false");
            test3.DataContext = diarys;
        }

        private void Pets_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ReinstancePetObject();
        
        }

        public void ReinstancePetObject()
        {
            
        }

        public class PetDataTemplate
        {
            public int p_Id { get; set; }
            public string p_Name { get; set; }
            public int p_Age { get; set; }
            public int t_Id { get; set; }
            public string t_Name { get; set; }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.

            pets = db.getAllPets();
            tasks = db.getAllTasks();


            foreach (var task in tasks)
            {
                if(task.t_Name.Length > 30)
                {
                    string oldName = task.t_Name;
                    string newName = oldName.Remove(27);
                    task.t_Name = newName;
                    task.t_Name += "...";
                } 
                if(task.t_Description.Length > 30)
                {
                    string oldDesc = task.t_Description;
                    string newDesc = oldDesc.Remove(26);
                    task.t_Description = newDesc;
                    task.t_Description += "...";
                }
            }

            history.DataContext = pets;
            test1.ItemsSource = tasks.Where(task => task.t_Completed == "false");
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {

            db.addPet(new Pets("Joey", 12, "male", 200, ""));
            db.addFood(new Food("blabla", "blalbalalb", "kjshadkhasd"));
        }

        private void ParentButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ParentCheck));
        }

        private void history_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (PetDataTemplate)e.ClickedItem;
            var id = clickedItem.p_Id;
            int index = petsDataTemplate.IndexOf(clickedItem);
            
            Frame.Navigate(typeof(PetPage), id);
        }

        private void btn_Complete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Tasks task = button.DataContext as Tasks;
            int index = tasks.IndexOf(task);
            
            string name = task.t_Name;
            int id = task.TaskID;
            db.updateTask("t_Completed", "true", id);

            ObservableCollection<Tasks> tasks1 = new DBHandler().getAllTasks();

            
            Binding binding = new Binding { Source = tasks1.Where(t => t.t_Completed == "false")};
            BindingOperations.SetBinding(test1, Windows.UI.Xaml.Controls.ListView.ItemsSourceProperty, binding);
        }
    }
}
