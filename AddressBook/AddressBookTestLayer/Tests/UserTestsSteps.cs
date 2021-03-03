using System;
using TechTalk.SpecFlow;

namespace AddressBookTestLayer
{
    [Binding]
    public class UserTestsSteps
    {
        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I enter the correct ""(.*)"" and ""(.*)""")]
        public void WhenIEnterTheCorrectAnd(string username, string password)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The account should exist in the database")]
        public void ThenTheAccountShouldExistInTheDatabase()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should get a message saying ""(.*)""")]
        public void ThenIShouldGetAMessageSaying(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [AfterScenario]
        public void Clean
    }
}
