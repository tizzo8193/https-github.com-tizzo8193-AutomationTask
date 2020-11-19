using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationTask
{
    // Fiddle home page object model
    public class FiddleHomePage
    {
        private IWebDriver driver;
        public static string fiddleHomePageUrl = "https://dotnetfiddle.net/#";

        [FindsBy(How = How.Id, Using = "output")]
        private IWebElement outputPane;

        [FindsBy(How = How.Id, Using = "save-button")]
        private IWebElement saveButton;

        public FiddleHomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public IWebElement GetOutputPane()
        {
            return outputPane;
        }

        public void ClickSaveButton()
        {
            saveButton.Click();
        }

        public IWebElement GetLogoutModalLabel()
        {
            // Wait for modal label to be rendered and clickable.
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement modalLabel = wait.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("login-modal-label")));
            
            return modalLabel;
        }
    }
}
