using Petsy.data;
using Petsy.data.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Petsy
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DiaryCreate : Page
    {
        DBHandler dbHandler;
        ObservableCollection<Pets> pets;
        public DiaryCreate()
        {
            this.InitializeComponent();

            HardwareButtons.BackPressed += HardwareButtons_BackPressed;

            dbHandler = new DBHandler();
            pets = dbHandler.getAllPets();

            if (pets.Count > 0)
            {
                foreach (var pet in pets)
                    petCombo.Items.Add(pet.p_Name);
            }
            else
            {
                petCombo.PlaceholderText = "Je hebt nog geen huisdieren!";
            }
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame != null && rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Diaries diarie = new Diaries();
            diarie.d_OneLiner = oneLineCombo.SelectedItem.ToString();
            diarie.d_Location = whereText.Text;
            diarie.d_Time = whenText.Text;
            diarie.d_MiscInfo = miscInfoText.Text;

            dbHandler.addDiary(diarie);

            Frame.GoBack();
        }

        private void pet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedPet = petCombo.SelectedItem.ToString();

            List<String> oneLiners = new List<string>();
            oneLiners.Add(selectedPet + " eten gegeven");
            oneLiners.Add(selectedPet + " uitgelaten");
            oneLiners.Add(selectedPet + " zijn hok verschoond");
            oneLiners.Add(selectedPet + " gewassen");

            foreach (var oneliner in oneLiners)
                oneLineCombo.Items.Add(oneliner);
        }

        private void oneLineCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
