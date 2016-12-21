﻿using System;
using TechTalk.SpecFlow;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace SampleSpecFlowProject.stepDefinitions
{
    [Binding]
    public class CardValidationSteps
    {
        AndroidApp app;


        [BeforeScenario]
        public void SetUp()
        {

            app = ConfigureApp.Android
                .ApkFile("d:/com.xamarin.example.creditcardvalidator.apk")
                .StartApp();
        }

        [Given(@"I open application")]
        public void GivenIOpenApplication()
        {
           app.WaitForElement(c => c.Marked("action_bar_title").Text("Enter Credit Card Number"));
        }


        [When(@"I enter credit card number ""(.*)""")]
        public void GivenIEnterCreditCardNumber(string creditCardNumber)
        {
            app.EnterText(c => c.Marked("creditCardNumberText"), creditCardNumber);
            app.Tap(c => c.Marked("validateButton"));
        }
        [Then(@"I can see validation failure")]
        public void ThenICanSeeValidationFailure()
        {
            app.WaitForElement(c => c.Marked("errorMessagesText").Text("Credit card number is too short."));
        }

    }
}
