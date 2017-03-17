using Petsy.data;
using Petsy.data.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
        ObservableCollection<Food> food = new ObservableCollection<Food>();
        DBHandler db;

        public MainPage()
        {
            this.InitializeComponent();
            //Gittest


            db = new DBHandler();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            pets = new DBHandler().getAllPets();
            food = new DBHandler().getAllFood();

            // Set the cells to the Page's DataContext. All controls on 
            // the page will inherit this.
            history.DataContext = pets;
<<<<<<< HEAD

=======
            test1.DataContext = food;
>>>>>>> 71bb774dd9b40a70fa91cde71eca5e556b215c6f
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
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {

            db.addPet(new Pets("Joey", 12, "male", 200, ""));
<<<<<<< HEAD
            db.addFood(new Food("blabla", "blalbalalb", "kjshadkhasd"));
        }

        private void ParentButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void history_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (Pets)e.ClickedItem;
            var id = clickedItem.PetID;
            int index = pets.IndexOf(clickedItem);
=======

            db.addFood(new Food(textbotx.Text, textbotx1.Text, textbotx2.Text));
            
>>>>>>> 71bb774dd9b40a70fa91cde71eca5e556b215c6f
        }
    }
}
