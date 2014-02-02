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

            var question = await App.MobileService.GetTable<Question>().LookupAsync(questionId);
            QuestionTextBlock.Text = question.Text;
            AnswerATextBlock.Text = question.ChoiceA;
            AnswerBTextBlock.Text = question.ChoiceB;

            var resultTable = App.MobileService.GetTable<Answer>();
            var results = await resultTable.Where(answer => answer.QuestionId == questionId).ToListAsync();

            var answerACount = results.Count(answer => answer.Choice == "A");
            var answerBcount = results.Count(answer => answer.Choice == "B");
            var total = results.Count();
            ResultATextBlock.Text = string.Format("{0:P} ({1} of {2})", answerACount / (total), answerACount, total);
            ResultBTextBlock.Text = string.Format("{0:P} ({1} of {2})", answerBcount / (total), answerBcount, total);
        }

    }
}