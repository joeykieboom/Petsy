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
        Windows.Media.Capture.MediaCapture captureManager;
        public PetCreate()
        {
            this.InitializeComponent();

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
            handler.addPet(pet);

            Frame.BackStack.RemoveAt(Frame.BackStack.Count - 1);
            Frame.GoBack();
        }

        int count = 0;

        private async void Take_Picture_Click(object sender, RoutedEventArgs e)
        {

            if (count == 0)
            {
                captureManager = new MediaCapture();    //Define MediaCapture object  
                await captureManager.InitializeAsync();   //Start preiving on CaptureElement  
                await captureManager.StartPreviewAsync();

                count++;
            }
            else {

                //Create JPEG image Encoding format for storing image in JPEG type  
                ImageEncodingProperties imgFormat = ImageEncodingProperties.CreateJpeg();
                // create storage file in local app storage  
                StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("Photo.jpg", CreationCollisionOption.ReplaceExisting);
                // take photo and store it on file location.  
                await captureManager.CapturePhotoToStorageFileAsync(imgFormat, file);
                //// create storage file in Picture Library  
                //StorageFile file = await KnownFolders.PicturesLibrary.CreateFileAsync("Photo.jpg",CreationCollisionOption.GenerateUniqueName);  
                // Get photo as a BitmapImage using storage file path.  
                BitmapImage bmpImage = new BitmapImage(new Uri(file.Path));
                // show captured image on Image UIElement.  
                imagepreview.Source = bmpImage;
            }
        }
    }
}
