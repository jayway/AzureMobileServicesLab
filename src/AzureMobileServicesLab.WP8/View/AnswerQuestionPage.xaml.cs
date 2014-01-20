using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
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

            // TODO: Get question from Question table.
            // var question = ...
            //
            //QuestionTextBlock.Text = question.Text;
            //AnswerAButton.Content = "A: " + question.ChoiceA;
            //AnswerBButton.Content = "B: " + question.ChoiceB;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Insert answer into Answer table

            App.RootFrame.GoBack();
        }

    }
}