using OpenQA.Selenium;

namespace ChallengeMiaplaza.POM
{
    public class ParentInfoPage
    {
        private readonly IWebDriver driver;

        public ParentInfoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement LinkParentInfoPage => driver.FindElement(By.LinkText("Online High School"));
        IWebElement BtnToParentInfoPage => driver.FindElement(By.LinkText("Apply to Our School"));

        IWebElement ApplicationStepParent => driver.FindElement(By.XPath("//b[text() = 'Parent Information']"));
        IWebElement ApplicationStepStudent => driver.FindElement(By.XPath("//b[text() = 'Student Information']"));

        IWebElement TxtFirstName => driver.FindElement(By.XPath("//*[@id=\"Name-li\"]/div[2]/div/span[1]/input"));

        IWebElement TxtLastName => driver.FindElement(By.XPath("//*[@id=\"Name-li\"]/div[2]/div/span[2]/input"));

        IWebElement TxtEmail => driver.FindElement(By.Id("Email-arialabel"));

        IWebElement TxtPhoneNumber => driver.FindElement(By.Id("PhoneNumber"));

        IWebElement DropDownAddParent => driver.FindElement(By.Id("Dropdown-arialabel"));

        IWebElement TxtDate => driver.FindElement(By.Name("Date"));

        IWebElement BtnNext => driver.FindElement(By.XPath("//ul[2]/li/div[1]/div/div/button/em[text()=' Next ']"));
        

        public void GoToParentInfoPage()
        {
            LinkParentInfoPage.ClickElement();
            BtnToParentInfoPage.ClickElement();
        }
        public void FillInParentInfo(string firstName, string lastName, string email, string phoneNumber, string addParent)
        {
            TxtFirstName.EnterText(firstName);
            TxtLastName.EnterText(lastName);
            TxtEmail.EnterText(email);
            TxtPhoneNumber.EnterText(phoneNumber);
            DropDownAddParent.SelectDropDownByText(addParent);
            TxtDate.EnterText(CustomMethods.GetDate());
            BtnNext.ClickElement();
        }

        public bool FormParentDisplayed()
        {
            return ApplicationStepParent.Displayed;
        }

        public bool FormStudentDisplayed()
        {
            return ApplicationStepStudent.Displayed;
        }
    }
}