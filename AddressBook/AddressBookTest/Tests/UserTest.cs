using BDTest.NUnit;
using BDTest.Test;
using NUnit.Framework;
using AddressBookModel;
using System;
using System.Linq;

namespace AddressBookTest
{
    public class UserTest : TestBase
    {
        User User = new User
                {
                    Username = "Bill Wurst",
                    UserPassword = "Abacus123",
                    Email = "bwurst@gmail.com",
                    PhoneNo = "01234567900"
                };


        [Test]
        public void LoginTest()
        {
            Given(() => UserSteps.CorrectCredentials(User))
                .When(() => UserSteps.CredentialsEntered("Bill Wurst", "Abacus123"))
                .Then(() => UserSteps.SelectedUserIsCorrect(User.Username))
                // .And(() => UserSteps.SuccessMessageDisplayed())
                .And(() => UserSteps.UserIsDeleted())
                .BDTest();
        }

        [Test]
        public void FailedLoginTest_InvalidUsername()
        {
            Given(() => UserSteps.CorrectCredentials(User))
                .When(() => UserSteps.CredentialsEntered("Bill Burst", "Abacus"))
                .Then(() => UserSteps.SelectedUserIsNull())
                // .And(() => UserSteps.SuccessMessageDisplayed())
                .And(() => UserSteps.UserIsDeleted())
                .BDTest();
        }

    }
}
