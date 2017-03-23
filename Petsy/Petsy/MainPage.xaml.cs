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
        ObservableCollection<Tasks> tasks = new ObservableCollection<Tasks>();
        DBHandler db;

        public MainPage()
        {
            this.InitializeComponent();
            //Gittest

            Application.Current.Resuming += Current_Resuming;
            db = new DBHandler();
            this.NavigationCacheMode = NavigationCacheMode.Required;

            pets = new DBHandler().getAllPets();
            tasks = new DBHandler().getAllTasks();
            

            // Set the cells to the Page's DataContext. All controls on 
            // the page will inherit this.
            history.DataContext = pets;
            test1.ItemsSource = tasks.Where(task => task.t_Completed == "false");
        }

        private void Current_Resuming(object sender, object e)
        {
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

            pets = new DBHandler().getAllPets();
            tasks = new DBHandler().getAllTasks();


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

        private async void history_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (Pets)e.ClickedItem;
            var id = clickedItem.PetID;
            int index = pets.IndexOf(clickedItem);
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
