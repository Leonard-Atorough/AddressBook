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

    }
}
