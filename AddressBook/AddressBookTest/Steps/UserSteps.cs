using System;
using BDTest.Attributes;
using NUnit.Framework;

namespace AddressBookTest
{
    public class UserSteps
    {
        protected readonly TestContext _testContext;
        public string Username { get; internal set; }
        public string Password { get; internal set; }
        public string response { get; set; }

        public UserSteps(TestContext testContext)
        {
            _testContext = testContext;
        }

        public void CorrectCredentials()
        {
            Username = "Bill Wurst";
            Password = "Abacus123";
        }

        public void CredentialsEntered()
        {
            response = _testContext.User.Login(Username, Password);
        }

        public void SelectedUserIsCorrect()
        {
            Assert.That(_testContext.User.SelectedUser.Username, Is.EqualTo(Username));
        }

        public void SuccessMessageDisplayed()
        {
            Assert.That(response, Is.EqualTo("Successful login").IgnoreCase);
        }
    }
}
