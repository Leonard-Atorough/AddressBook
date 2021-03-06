using System;
using System.Linq;
using AddressBookModel;
using BDTest.Attributes;
using NUnit.Framework;

namespace AddressBookTest
{
    public class UserSteps
    {
        protected readonly TestContext _testContext;
        public User User { get; set; }
        public string response;

        public UserSteps(TestContext testContext)
        {
            _testContext = testContext;
        }

        public void CorrectCredentials(User user)
        {
            using (var db = new AddressBookDataContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void CredentialsEntered(string username, string password)
        {
            response = _testContext.User.Login(username, password);
        }

        public void SelectedUserIsCorrect(string user)
        {
            Assert.That(_testContext.User.SelectedUser.Username, Is.EqualTo(user));
        }

        public void SuccessMessageDisplayed()
        {
            Assert.That(response, Is.EqualTo("Successful login").IgnoreCase);
        }

        public void UserIsDeleted()
        {
            using (var db = new AddressBookDataContext())
            {
                var remove = db.Users.Where(u => u.Username == "Bill Wurst").FirstOrDefault();
                db.Users.Remove(remove);
                db.SaveChanges();
            }
        }

        internal void SelectedUserIsNull()
        {
            Assert.That(_testContext.User.SelectedUser, Is.Null);
        }
    }
}
