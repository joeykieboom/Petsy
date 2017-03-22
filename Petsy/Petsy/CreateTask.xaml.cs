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
    public sealed partial class CreateTask : Page
    {
        DBHandler dbHandler;
        ObservableCollection<Pets> pets;
        ObservableCollection<Tasks> tasks;

        public CreateTask()
        {
            this.InitializeComponent();
            dbHandler = new DBHandler();
            pets = dbHandler.getAllPets();
            foreach (var pet in pets)
                taskPet.Items.Add(pet.p_Name);


            List<string> interval = new List<string>();
            interval.Add("3 Dagen");
            interval.Add("1 Week");
            interval.Add("1 Maand");

            for (int i = 0; i < interval.Count; i++)
                taskInterval.Items.Add(interval[i]);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void taskCreate_Click(object sender, RoutedEventArgs e)
        {
            string name = taskName.Text;
            DateTime startingDate = new DateTime(taskDate.Date.Year, taskDate.Date.Month, taskDate.Date.Day, taskTime.Time.Hours, taskTime.Time.Minutes, taskTime.Time.Seconds);
            string desc = TaskDesc.Text;
            string interval = taskInterval.SelectedValue.ToString();
            bool completed = false;
            Tasks task = new Tasks(name, startingDate, desc, interval, completed);
            dbHandler.addTask(task);

            int petID = 0;
            foreach (var pet in pets)
                if (pet.p_Name == taskPet.SelectedValue)
                    petID = pet.PetID;

            Regels3 koppel = new Regels3(petID, task.TaskID);
        }
    }
}
