using BDTest.NUnit;
using BDTest.Test;
using NUnit.Framework;
using AddressBookModel;
using System;

namespace AddressBookTest
{
    public class UserTest : TestBase
    {

        [Test]
        public void LoginTest()
        {
            Given(() => UserSteps.CorrectCredentials())
                .When(() => UserSteps.CredentialsEntered())
                .Then(() => UserSteps.SelectedUserIsCorrect())
                .And(() => UserSteps.SuccessMessageDisplayed())
                .BDTest();
        }

    }
}
