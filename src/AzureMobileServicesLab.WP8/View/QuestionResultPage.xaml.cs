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
    public partial class QuestionResultPage : PhoneApplicationPage
    {
        public QuestionResultPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var url = e.Uri.OriginalString;
            var questionId = url.Substring(url.IndexOf('?') + 1);

            // TODO: Get question from Question table
            //var question = ...
            //QuestionTextBlock.Text = question.Text;
            //AnswerATextBlock.Text = question.ChoiceA;
            //AnswerBTextBlock.Text = question.ChoiceB;

            // TODO: Get answers from Answer table and count number of As and B:s
            // ...
            //
            // ResultATextBlock.Text = string.Format("{0:P} ({1} of {2})", answerACount / (total), answerACount, total);
            // ResultBTextBlock.Text = string.Format("{0:P} ({1} of {2})", answerBcount / (total), answerBcount, total);
        }

    }
}