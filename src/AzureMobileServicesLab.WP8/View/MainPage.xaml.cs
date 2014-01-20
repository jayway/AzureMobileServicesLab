using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using AzureMobileServicesLab.WP8.Model;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AzureMobileServicesLab.WP8.Resources;

namespace AzureMobileServicesLab.WP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // TODO: Add handler for toast notification
            // App.PushChannel.ShellToastNotificationReceived += ...
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
            {
                // TODO: Implement login
                // http://www.windowsazure.com/en-us/documentation/articles/mobile-services-windows-phone-get-started-users/?fb=sv-se
            }

            await Refresh();
        }

        private async Task Refresh()
        {
            // TODO: Get unanswered questions and add them to UnansweredQuestionsList

            // TODO: Get answered questions and add them to AnsweredQuestionsList
        }

        private void NewQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            App.RootFrame.Navigate(new Uri("/View/NewQuestionPage.xaml", UriKind.Relative));
        }

        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            await Refresh();
        }

        private void UnansweredQuestionsList_Tap(object sender, GestureEventArgs e)
        {
            var selectedQuestion = UnansweredQuestionsList.SelectedItem as Question;
            if (selectedQuestion != null)
            {
                App.RootFrame.Navigate(new Uri("/View/AnswerQuestionPage.xaml?" + selectedQuestion.Id, UriKind.Relative));
            }
        }

        private void CompletedQuestionsList_Tap(object sender, GestureEventArgs e)
        {
            var selectedQuestion = CompletedQuestionsList.SelectedItem as Question;
            if (selectedQuestion != null)
            {
                App.RootFrame.Navigate(new Uri("/View/QuestionResultPage.xaml?" + selectedQuestion.Id, UriKind.Relative));
            }
        }
    }
}