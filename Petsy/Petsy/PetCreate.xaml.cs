using Petsy.data;
using Petsy.data.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Capture;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Pickers;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.Activation;

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
        CoreApplicationView view;
        String ImagePath;
        Windows.Media.Capture.MediaCapture captureManager;
        public PetCreate()
        {
            this.InitializeComponent();

            view = CoreApplication.GetCurrentView();

            dbHandler = new DBHandler();

            Application.Current.Resuming += Current_Resuming;

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
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            DBHandler handler = new DBHandler();
            pet = new Pets(petName.Text, Convert.ToInt32(petAge.Text), (string)petGender.SelectedItem, Convert.ToInt32(petWeight.Text), petMisc.Text);
            if (ImagePath != string.Empty)
            {
                pet.p_Picture = ImagePath;
            }
            handler.addPet(pet);

            Frame.BackStack.RemoveAt(Frame.BackStack.Count - 1);
            Frame.GoBack();
        }

        int count = 0;
        private async void Take_Picture_Click(object sender, RoutedEventArgs e)
        {
            ImagePath = string.Empty;
            FileOpenPicker filePicker = new FileOpenPicker();
            filePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            filePicker.ViewMode = PickerViewMode.Thumbnail;

            // Filter to include a sample subset of file types
            filePicker.FileTypeFilter.Clear();
            filePicker.FileTypeFilter.Add(".bmp");
            filePicker.FileTypeFilter.Add(".png");
            filePicker.FileTypeFilter.Add(".jpeg");
            filePicker.FileTypeFilter.Add(".jpg");

            filePicker.PickSingleFileAndContinue();

            view.Activated += viewActivated;
        }
        BitmapImage image;
        private async void viewActivated(CoreApplicationView sender, IActivatedEventArgs args1)
        {
            FileOpenPickerContinuationEventArgs args = args1 as FileOpenPickerContinuationEventArgs;

            if (args != null)
            {
                if (args.Files.Count == 0) return;

                view.Activated -= viewActivated;
                StorageFile storageFile = args.Files[0];
                var stream = await storageFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
                var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                await bitmapImage.SetSourceAsync(stream);

                var decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(stream);
                img.Source = bitmapImage;
                ImagePath = storageFile.Path;
            }
        }
    }
}
