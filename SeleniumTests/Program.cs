using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions.Internal;
using SeleniumTests;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Remote;

namespace SeleniumTests
{
    class Program
    {
        static void Main(string[] args)
        {
            #region SeleniumServer
            // nova naredba na lokalnom Selenium Serveru - prvo instalacija - seleniumHQ - download Selenium Server
            // lokacija proizvoljna - pokrenut u cmd-u
            // da bi to bilo moguće, java mora biti instalirana i konfigurirana (nije bilo potrebno konfigurirati kod mene)
            DesiredCapabilities capabilities = DesiredCapabilities.Firefox();
            capabilities.SetCapability("firefox_binary", @"F:\Programi\Mozilla\firefox.exe"); // ovo je umjesto onog kompliciranog pokretanja preko cmd-a
            //IWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), new DesiredCapabilities("firefox", "46.0.1,firefox_binary=F:\\Programi\\Mozilla\\firefox.exe", new Platform(PlatformType.Windows)));
            IWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capabilities);
            //java - jar "selenium-server-standalone-2.2.0.jar" - Dwebdriver.firefox.bin = "F:\Programi\Mozilla\firefox.exe"
            // ovom naredbom se kaže gdje se nalazi program koji se pokreće (IE, Chrome... )

            // java -jar selenium-server-standalone-2.53.0.jar -role node -browser browserName=firefox,version=46.0.1,firefox_binary=F:\Programi\Mozilla\firefox.exe -hub http://localhost:4444/grid/register -port 5558

            // grid and node registration: 
            // https://github.com/SeleniumHQ/selenium/wiki // Cijeli wiki, s linkovima na svugdje
            //http://www.software-testing-tutorials-automation.com/2016/04/running-multiple-nodes-of-selenium-grid.html
            //http://www.software-testing-tutorials-automation.com/2016/04/running-multiple-nodes-of-selenium-grid.html

            #endregion


            #region SeleniumLocal
            //IWebDriver driver = new FirefoxDriver();
            /* Start the driver without any parameter and it will throw and error, showing you from where
             * you can download the driver. */
            // var driver = new InternetExplorerDriver(@"F:\Dokumenti\Edukacija\Selenium Testing\Drivers\");

            //var searchbox = driver.FindElement(By.Id("lst-ib"), 2); // ovo poziva Extension(WebDriverExtensions klasa)
            //searchbox.SendKeys("pluralsite");

            //var imageLink = driver.FindElements(By.ClassName("q"), 2)[0];
            //var image = driver.FindElement(By.XPath("")); // Firebug -> inspect element with firebug -> RMB on element -> copy XPath!!
            //imageLink.Click();

            // implicit wait - overall wait, researches DOM every 500ms -> overhead
            // driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            // explicit wait - on request - WebDriverExtensions klasa pokazuje
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //wait.Until(d => { return driver.FindElement(By.Id("lst-ib"), 2); });
            #endregion

            driver.Url = "http://www.google.com";
        }
    }
}