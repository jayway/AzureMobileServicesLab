AzureMobileServicesLab
======================

Lab exploring the functionality of Windows Azure Mobile Services

Mission Goal
============

Create a fully funtional Survey-app where users can create and answer simple questions using Windows Azure Mobile Services as back-end.

Requirements
------------
 * Users must be authenticated
 * Users must be able to create a question with two answers, A or B. Example "What color do you like more? A:Blue, B:Yellow"
 * Users must be able to answer a question with either A or B.
 * A user may not answer the same question more than once.
 * Users must be able to see the result of any question. Result example: A: 25%, B: 75%
 * A toast message should be sent to all user when a new question is created.

Instructions
============

Step 1: Cloning the code
------------------------
Clone the Git repository and verify you can build the AzureMobileServicesLab solution with Visual Studio 2013.
The code is sprinkled with "TODO" comments. This is where you should write code to make the app work.

Step 2: Set up you Windows Azure Mobile Service
-----------------------------------------------
Log in to Windows Azure (https://manage.windowsazure.com) and create a new Mobile Service. You can use the existing database "wamslab_db".

Step 3: Implement the app
-------------------------
Suggested work plan:
 1. Create the database tables Answer, Question and Registration in Azure
 2. Add the NuGet package "WindowsAzure.MobileServices" to your solution and initialize the MobileServiceClient in App.xaml.cs
 3. Implement the NewQuestionPage and verify you can insert data into you service
 4. Set up 'identity' in Azure, then implement login
 5. Implement AnswerQuestionPage, MainPage and ResultPage
 6. Add push notification to you app