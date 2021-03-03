using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Add

namespace AddressBookTestLayer
{
    UserManager userManager = new UserManager();
    [Binding]
    public class TestBed
    {
        [BeforeScenario("Login")]
        public void CreateUser()
        {
            
        }
    }
}
