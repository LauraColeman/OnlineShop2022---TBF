using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace AuthenticationTests
{
    public class LogInTests
    {
        IWebDriver driver = new ChromeDriver("C:\\Users\\Laura\\Documents");


        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://onlineshoptest.azurewebsites.net");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void LogIn()
        {

            driver.Navigate().GoToUrl("https://onlineshoptest.azurewebsites.net");
            IWebElement loginInput = driver.FindElement(By.Id("username"));
            loginInput.SendKeys("admin@admin.com");
            IWebElement passInput = driver.FindElement(By.Id("password"));
            passInput.SendKeys("Admin123!");
            loginInput.SendKeys(Keys.Return);
            //click browse button

            

        }


        //Called after each test is run.
        [TearDown]
        public void End()
        {
            driver.Close();

        }


        [Test]
        public void RegisterButtonOnHomePage()
        {
            driver.FindElement(By.Id("register")).Click();
            Thread.Sleep(5000);
        }



        [Test]
        public void RegisterNewUser()
        {
            driver.Navigate().GoToUrl("https://onlineshoptest.azurewebsites.net/Identity/Account/Register?returnUrl=%2F");


            IWebElement fnameInput = driver.FindElement(By.Id("fname"));
            fnameInput.SendKeys("Test");
            IWebElement snameInput = driver.FindElement(By.Id("sname"));
            snameInput.SendKeys("Test");
            IWebElement emailInput = driver.FindElement(By.Id("email"));
            emailInput.SendKeys("admin@admin.com");
            IWebElement passInput = driver.FindElement(By.Id("password"));
            passInput.SendKeys("Admin123!");
            IWebElement passwInput = driver.FindElement(By.Id("confirmPass"));
            passInput.SendKeys("Admin123!");
            IWebElement confirmReg = driver.FindElement(By.Id("confirmReg"));
            confirmReg.SendKeys(Keys.Return);

        }
        





    }
}