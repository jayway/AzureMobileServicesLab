using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using AzureMobileServicesLab.WP8.Model;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace AzureMobileServicesLab.WP8.View
{
    public partial class AnswerQuestionPage : PhoneApplicationPage
    {
        private string _questionId;

        public AnswerQuestionPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var url = e.Uri.OriginalString;
            _questionId = url.Substring(url.IndexOf('?') + 1);

            var question = await App.MobileService.GetTable<Question>().LookupAsync(_questionId);

            QuestionTextBlock.Text = question.Text;
            AnswerAButton.Content = "A: " + question.ChoiceA;
            AnswerBButton.Content = "B: " + question.ChoiceB;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var answer = new Answer()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = App.MobileService.CurrentUser.UserId,
                QuestionId = _questionId,
                Choice = AnswerAButton.IsChecked.Value ? "A" : "B"
            };

            await App.MobileService.GetTable<Answer>().InsertAsync(answer);

            App.RootFrame.GoBack();
        }
    }
}