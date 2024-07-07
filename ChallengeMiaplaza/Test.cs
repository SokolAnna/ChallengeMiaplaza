using ChallengeMiaplaza.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ChallengeMiaplaza
{
    public class Tests
    {
        private IWebDriver _driver;

        public static IEnumerable<ApplicationForm> FillInForm()
        {
            //positive scenario
            yield return new ApplicationForm()
            {
                FistName = "First name",
                LastName = "Last name",
                Email = "test@test.com",
                PhoneNumber = "1234567890",
                AddParent = "No"
            };

            //negative scenario
            yield return new ApplicationForm()
            {
                FistName = "Vorname",
                LastName = "Name",
                Email = "test",
                PhoneNumber = "0",
                AddParent = "Yes"
            };
        }

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://miacademy.co/#/");
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        [TestCaseSource(nameof(FillInForm))]
        public void ParentApplicationFormTest(ApplicationForm applicationForm)
        {
            ParentInfoPage parentInfoPage = new ParentInfoPage(_driver);
            parentInfoPage.GoToParentInfoPage();
            Assert.IsTrue(parentInfoPage.FormParentDisplayed(), "Patent form is not visible");

            parentInfoPage.FillInParentInfo(applicationForm.FistName, applicationForm.LastName, applicationForm.Email, applicationForm.PhoneNumber, applicationForm.AddParent);
            Assert.IsTrue(parentInfoPage.FormStudentDisplayed(), "Student form is not visible");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}