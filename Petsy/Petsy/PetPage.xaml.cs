using Petsy.data;
using Petsy.data.models;
using System;
using System.Collections.Generic;
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
    public sealed partial class PetPage : Page
    {

        Pets pet;

        public PetPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string id = e.Parameter.ToString();

            DBHandler db = new DBHandler();
            this.pet = db.getPet(Convert.ToInt32(id));

            updatePetInfo();
        }

        private void updatePetInfo()
        {
            petName.Text = pet.p_Name;
            petAge.Text = Convert.ToString(pet.p_Age);
            petGender.Text = pet.p_Gender;
            petWeight.Text = Convert.ToString(pet.p_Weight);
        }
    }
}
