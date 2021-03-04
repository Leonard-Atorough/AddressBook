using System;
using System.Collections.Generic;
using System.Text;
using AddressBookBusinessLayer;

namespace AddressBookTest
{
    public class TestContext
    {
        public UserManager User { get; } = new UserManager();
    }
}
