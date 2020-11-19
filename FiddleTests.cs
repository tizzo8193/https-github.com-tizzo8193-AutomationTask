using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System;

namespace AutomationTask
{
    [TestClass]
    public class FiddleTests
    {
        private IWebDriver Driver;

        [TestInitialize]
        public void TestInitialize()
        {
            Driver = new ChromeDriver();
            // Be sloppy for demo and just wait a long time for elements to load.
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);

            Driver.Navigate().GoToUrl(FiddleHomePage.fiddleHomePageUrl);
            Assert.IsTrue(Driver.Url.Contains("dotnetfiddle.net/#"), "Failed to login.");
        }

        [TestMethod]
        public void ValidateOutputPaneText()
        {
            var fiddleHomePage = new FiddleHomePage(Driver);

            // Set up: Get the output pane.
            IWebElement outputPane = fiddleHomePage.GetOutputPane();

            // Validate: output pane contains "Hello World."
            var outputPaneText = outputPane.Text;
            Assert.IsTrue(outputPaneText == "Hello World");
        }

        [TestMethod]
        public void ValidateLoginPageOnSave()
        {
            var fiddleHomePage = new FiddleHomePage(Driver);

            // Set up: Click the save button.
            fiddleHomePage.ClickSaveButton();

            // Validate: Login dialog exists and contains label text: "Log in."
            var loginModal = fiddleHomePage.GetLogoutModalLabel();
            Assert.IsTrue(loginModal.Text == "Log in");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (Driver != null)
            {
                Driver.Dispose();
            }
        }
    }
}
