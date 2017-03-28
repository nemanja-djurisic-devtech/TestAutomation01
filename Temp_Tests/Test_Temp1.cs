using System;
using NUnit.Framework;
using Temp_Init.Base;

namespace Gradwell_Tests_Login.CustomerLogin
{
    [TestFixture("FireFox", "Develop1")]
    [TestFixture("Chrome", "Develop1")]

    public class Test_Login : Initialization
    {
        private string browser;
        private string env;

        public Test_Login(string browser, string env)
        {
            this.browser = browser;
            this.env = env;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //Calls CSV file
            csvData.GetEnvironmentData();
        }

        [SetUp]
        public void SetupTest()
        {
            base.PagesDef(browser);

            base.EnvironmentSetup(env);

            //Login as customer with login details from csv file
            base.GoTo(csvData.envUrl[customer]);
        }

        [Test]
        public void VerifyPage()
        {
            webPage1.VerifyTextField("Google");
        }

        [TearDown]
        public void FinishTest()
        {
            base.CloseBrowser(Driver);
        }
    }
}
