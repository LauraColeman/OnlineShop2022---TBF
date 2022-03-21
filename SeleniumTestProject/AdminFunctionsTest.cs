using com.sun.org.apache.xalan.@internal.xsltc;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace SeleniumTestProject
{
    public class AdminFunctionsTest
    {
        IWebDriver driver = new ChromeDriver("C:\\Users\\Laura\\Documents");

        [OneTimeSetUp]
        public void Setup()
        {
            //run chrome in background.


            driver.Navigate().GoToUrl("https://onlineshoptest.azurewebsites.net");
            driver.Manage().Window.Maximize();

            //login
            IWebElement loginInput = driver.FindElement(By.Id("username"));
            loginInput.SendKeys("admin@admin.com");
            IWebElement passInput = driver.FindElement(By.Id("password"));
            passInput.SendKeys("Admin123!");
            loginInput.SendKeys(Keys.Return);
        }

        [TearDown]
        public void End()
        {
            driver.Close();

        }


        [Test]

        public void DeleteUserSuccess()
        {
            //click admin menu
            driver.FindElement(By.XPath("//html/body/header/nav/div/div/ul/li[3]")).Click();
            //click user management
            driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[4]/ul/li[1]/a")).Click();
            //click delete user
            driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[2]/td[6]/a")).Click();
          


        }



        [Test]

        public void ManageRolesSuccess()
        {
            //click admin menu
            driver.FindElement(By.XPath("//html/body/header/nav/div/div/ul/li[3]")).Click();
            //click user management
            driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[3]/ul/li[1]/a")).Click();
            //click manage roles
            driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[2]/td[5]/a")).Click();
            //tick admin box.
            driver.FindElement(By.XPath("//*[@id='z0__IsInRole']")).Click();
            //click update
            driver.FindElement(By.XPath("/html/body/div/main/form/div/div[3]/button")).Click();

            End();

        }

        [Test]

        public void AddRolesSuccess()
        {
            //click admin menu
            driver.FindElement(By.XPath("//html/body/header/nav/div/div/ul/li[3]")).Click();
            //click role management
            driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[3]/ul/li[2]/a")).Click();
            //click add roles
            driver.FindElement(By.XPath("/html/body/div/main/form/div/span/button")).Click();
            //fill add role box
            IWebElement roleInput = driver.FindElement(By.Name("roleName"));
            roleInput.SendKeys("Test");
            Thread.Sleep(2000);
            //click Add new Role
            driver.FindElement(By.XPath("/html/body/div/main/form/div/span/button")).Click();

           // End();

        }

        [Test]

        public void DeleteRoleSuccess()
        {
            //click admin menu
            driver.FindElement(By.XPath("//html/body/header/nav/div/div/ul/li[3]")).Click();
            //click role management
            driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[3]/ul/li[2]/a")).Click();
            //click delete role for Test.
            driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[4]/td[3]/a")).Click();

            Thread.Sleep(2000);

        }

    }
}
