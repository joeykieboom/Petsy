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
    public sealed partial class PetCreate : Page
    {
        DBHandler dbHandler;
        Pets pet;
        public PetCreate()
        {
            this.InitializeComponent();

            dbHandler = new DBHandler();

            InputScope scope1 = new InputScope();
            InputScopeName name1 = new InputScopeName();
            name1.NameValue = InputScopeNameValue.Number;
            scope1.Names.Add(name1);

            InputScope scope2 = new InputScope();
            InputScopeName name2 = new InputScopeName();

            name2.NameValue = InputScopeNameValue.Number;
            scope2.Names.Add(name2);

            petAge.InputScope = scope1;
            petWeight.InputScope = scope2;

            List<string> genders = new List<string>();
            genders.Add("Mannelijk");
            genders.Add("Vrouwelijk");
            genders.Add("Apache");
            genders.Add("Onbekend");

            for (int i = 0; i < genders.Count; i++)
                petGender.Items.Add(genders[i]);

            List<string> types = new List<string>();
            types.Add("Hond");
            types.Add("Kat");
            types.Add("Schildpad");
            types.Add("Vogel");

            for (int i = 0; i < types.Count; i++)
                petType.Items.Add(types[i]);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            pet = new Pets(petName.Text, Convert.ToInt32(petAge.Text), petGender.SelectedItem.ToString(), Convert.ToInt32(petWeight.Text), petMisc.Text);
        }
    }
}
