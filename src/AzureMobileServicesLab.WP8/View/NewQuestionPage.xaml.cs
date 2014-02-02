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
    public partial class NewQuestionPage : PhoneApplicationPage
    {
        public NewQuestionPage()
        {
            InitializeComponent();
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var question = new Question
            {
                Id = Guid.NewGuid().ToString(),
                Text = QuestionTextBox.Text,
                ChoiceA = ChoiceATextBox.Text,
                ChoiceB = ChoiceBTextBox.Text
            };

            await App.MobileService.GetTable<Question>().InsertAsync(question);
            App.RootFrame.GoBack();
        }
    }
}