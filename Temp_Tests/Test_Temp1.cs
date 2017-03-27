using System;
using NUnit.Framework;
using Temp_Init.Base;

namespace Gradwell_Tests_Login.CustomerLogin
{
    [TestFixture("FireFox", "type1", "Develop1")]
    //[TestFixture("FireFox", "type1", "Develop2")]
    [TestFixture("Chrome", "type2", "Develop1")]
    //[TestFixture("Chrome", "type1", "Develop2")]
    //[TestFixture("Chrome", "type1", "Staging")]
    //[TestFixture("FireFox", "type1", "Staging")]

    public class Test_Login : Initialization
    {
        private string browser;
        private string backend;
        private string env;

        public Test_Login(string browser, string backend, string env)
        {
            this.browser = browser;
            this.backend = backend;
            this.env = env;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //Calls CSV file
            csvData.GetEnvironmentData();
        }

        public void BackendSetup(string backendName)
        {
            switch (backendName)
            {
                case "type1":
                    //Set column to 'type1'
                    //dataBase.DB_Query("UPDATE bata_base.table_name SET column_name = 'type1' WHERE account_number = '" + csvData.envAccountNumber[customer] + ";");
                    break;

                case "type2":
                    //Set column to 'type2'
                    //dataBase.DB_Query("UPDATE bata_base.table_name SET column_name = 'type2' WHERE account_number = '" + csvData.envAccountNumber[customer] + ";");
                    break;
            }
        }

        [SetUp]
        public void SetupTest()
        {
            base.PagesDef(browser);

            this.BackendSetup(backend);

            base.EnvironmentSetup(env);

            //Login as customer with login details from csv file
            base.GoTo(csvData.envUrl[customer]);
            //commonElements.LoginAsCustomer(csvData.envUserName[customer], csvData.envPassword[customer]);
            //commonElements.VerifyHeader(csvData.envFirstName[customer]);
        }

        //[Test]
        //public void Test_PopulateData()
        //{
        //    //Creates random string of 8 characters
        //    var random01 = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);

        //    //Open Edit Customer - with variable Xpath
        //    webPage1.OpenEditCustomerAddress(csvData.envAccountNumber[customer]);

        //    //Populate customer's address
        //    webPage1.PopulateAddress("United Kingdom", csvData.envCity[customer], csvData.envAddress[customer]);

        //    //Enter random string
        //    webPage1.PopulateField("Text_" + random01);

        //    //Set Switch to a certain value
        //    webPage1.SetSwitch("Yes");

        //    //Action while condition
        //    webPage1.DeleteAllCustomers("There is no Customers");

        //    //Get value from a certain field in Data Base
        //    dataBase.DB_Query_GetValue("SELECT * FROM data_base.table_name WHERE account_number = '" + csvData.envAccountNumber[customer] + "';", "column_name");

        //    //Compare values from Data Base and field
        //    commonElements.CompareValues(dataBase.columnValue, webPage1.amountString);

        //    //Verify calculation
        //    webPage1.VerifyCalculation();
        //    //Verify calculation with parameters
        //    webPage1.VerifyCalculationParameters(webPage1.amountDecimal, webPage1.amount1Decimal, webPage1.amount2Decimal);

        //    //Verify page Url
        //    commonElements.VerifyPageUrl("http://test.develop.com/");
        //    //Verify page Url from CSV file
        //    commonElements.VerifyPageUrl(csvData.envUrl[customer]);

        //    //Get part of Url
        //    commonElements.GetUrl("http://test.develop.com/id=", string.Empty);
        //    //Compare part of Url with csv data
        //    commonElements.CompareValues(csvData.envAccountNumber[customer], commonElements.url);
        //}

        [Test]
        public void VerifyPage()
        {
            webPage1.VerifyTextField("Google");
            //Testing git
            //Testing git2
        }

        [TearDown]
        public void FinishTest()
        {
            base.CloseBrowser(Driver);
        }
    }
}
