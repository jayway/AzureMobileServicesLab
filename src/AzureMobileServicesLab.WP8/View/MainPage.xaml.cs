using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using AzureMobileServicesLab.WP8.Model;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AzureMobileServicesLab.WP8.Resources;
using Microsoft.WindowsAzure.MobileServices;

namespace AzureMobileServicesLab.WP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            App.PushChannel.ShellToastNotificationReceived += (sender, args) =>
            {
                var message = new StringBuilder();
                message.AppendLine("Received Toast!");
                foreach (var key in args.Collection.Keys)
                {
                    message.AppendFormat("{0}: {1}\n", key, args.Collection[key]);
                }

                Dispatcher.BeginInvoke(() => MessageBox.Show(message.ToString()));
            };
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
            {
                await App.MobileService.LoginAsync(MobileServiceAuthenticationProvider.MicrosoftAccount);
            }

            await Refresh();
        }

        private async Task Refresh()
        {
            var user = App.MobileService.CurrentUser;
            if (user != null)
            {
                var parameters = new Dictionary<string, string> {{"userId", user.UserId}};
                
                var unanswered = await App.MobileService.InvokeApiAsync<IEnumerable<Question>>("unanswered", HttpMethod.Get, parameters);
                UnansweredQuestionsList.ItemsSource = unanswered.ToList();

                var completed = await App.MobileService.InvokeApiAsync<IEnumerable<Question>>("completed", HttpMethod.Get, parameters);
                CompletedQuestionsList.ItemsSource = completed.ToList();
            }
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