using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Game2048UsingSelenium
{
    public static class WebDriver
    {
        public static IWebDriver Driver { get; set; }

        static WebDriver()
        {
            //run chrome browser in full screen
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
        }
    }
}
