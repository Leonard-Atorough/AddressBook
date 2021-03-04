using BDTest.NUnit;
using System;
using System.Collections.Generic;
using System.Text;
using AddressBookModel;
using System.Linq;
using NUnit.Framework;

namespace AddressBookTest
{
    public abstract class TestBase : NUnitBDTestBase<TestContext>
    {
        public UserSteps UserSteps => new UserSteps(Context);

        [SetUp]
        public void CreateUser()
        {
            using (var db = new AddressBookDataContext())
            {
                User user = new User 
                { 
                    Username = "Bill Wurst", 
                    UserPassword = "Abacus123",
                    Email = "bwurst@gmail.com",
                    PhoneNo = "01234567900"
                };

                db.Users.Add(user);
            }
        }

        [TearDown]
        public void DeleteUser()
        {
            using (var db = new AddressBookDataContext())
            {
                var remove = db.Users.Where(u => u.Username == "Bill Wurst").FirstOrDefault();
                db.Users.Remove(remove);
            }
        }

    }
}
