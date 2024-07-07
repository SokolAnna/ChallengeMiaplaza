using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ChallengeMiaplaza
{
    public static class CustomMethods
    {
        public static void ClickElement(this IWebElement locator)
        {
            locator.Click();
        }

        public static void EnterText(this IWebElement locator, string text)
        {
            locator.Clear();
            locator.SendKeys(text);
        }

        public static void SelectDropDownByText(this IWebElement locator, string text)
        {
            var selectElement = new SelectElement(locator);
            selectElement.SelectByText(text);
        }

        public static string GetDate()
        {
            var currentDate = DateTime.Now;
            var date = currentDate.AddDays(14).ToString("dd-MMM-yyyy");
            return date;
        }
    }
}