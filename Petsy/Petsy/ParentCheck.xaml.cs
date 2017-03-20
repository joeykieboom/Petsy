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
    /// 

    public sealed partial class ParentCheck : Page
    {

        DBHandler db;
        SecurityQuestions question;
        public ParentCheck()
        {
            this.InitializeComponent();
            db = new DBHandler();
            NewQuestion();
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }


        void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame != null && rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
                e.Handled = true;
            }

        }

        private void NewQuestion()
        {
            ObservableCollection<SecurityQuestions> questions = db.getAllSecurityQuestions();
            int amount = questions.Count;
            Random rdn = new Random();
            int rdnNum = rdn.Next(0, amount);
            question = questions[rdnNum];



            texblock_Question.Text = question.q_Question;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string anwser = "false";
            string trueAnwser = question.q_Answer;

            if (trueAnwser == anwser)
            {
                Frame.Navigate(typeof(PetCreate));
            }
            else
            {
                NewQuestion();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string anwser = "true";
            string trueAnwser = question.q_Answer;

            if (trueAnwser == anwser)
            {
                Frame.Navigate(typeof(PetCreate));
            }
            else
            {
                NewQuestion();
            }
        }
    }
}
