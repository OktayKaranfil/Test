using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://www.n11.com";  
            System.Console.WriteLine("Şuan açık olan link " + driver.Title);
            IWebElement btnLoginPage = driver.FindElement(By.XPath(".//*[@class='btnSignIn']"));
            btnLoginPage.Click();
            //burada sayfayı yüklenmesi birşeyler denemek gerekecek
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            //aşağıdaki gibi hesap oluşturdum giriş yapabilmesi için ama beceremedi firefox 
            IWebElement inputEmail = driver.FindElement(By.XPath(".//*[@id='email']"));
            inputEmail.SendKeys("deneme.15.04.2017@gmail.com");
            IWebElement inputPassword = driver.FindElement(By.XPath(".//*[@id='password']"));
            inputPassword.SendKeys("123123Aa");
            //burada login olmakta sıkıntı yaşıyorum 
            IWebElement btnLogin = driver.FindElement(By.XPath(".//*[@id='loginButton']"));
            btnLogin.Click();
            btnLogin.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));

            IWebElement inputSearch = driver.FindElement(By.XPath(".//*[@id='searchData']"));
            inputSearch.SendKeys("samsung");
            IWebElement btnSearch = driver.FindElement(By.XPath(".//*[@class='searchBtn']"));
            btnSearch.Click();

            IWebElement inputResult = driver.FindElement(By.XPath(".//*[@id='itemCount']"));

            IWebElement btnPopup = driver.FindElement(By.XPath(".//*[@class='fancybox-item fancybox-close']"));
            btnPopup.Click();
            if (inputResult.ToString().ToUpper().Contains("SAMSUNG"))
            {

                System.Console.WriteLine(inputResult.ToString());
                IWebElement footerPage = driver.FindElement(By.XPath(".//*[@href='" + driver.Url+ "&pg=2']"));
                footerPage.Click();

            };
            //   
            //driver.Close();
            
        }
    }
}
