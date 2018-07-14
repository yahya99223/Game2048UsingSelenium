using Game2048;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Game2048UsingSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueRunning = true;
            //run chrome browser in full screen
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
            //naviagate to the url extracted from response
            Game2048Page gamePage = new Game2048Page(driver);
            while (continueRunning)
            {
                Thread.Sleep(200);
                var board = gamePage.GetBoard();
                DecisionAlgorithm algo = new DecisionAlgorithm();
                AlphaBetaPruningAlgorithm alphaBeta = new AlphaBetaPruningAlgorithm();
                var movement = algo.Decide(board, 2);
                if (movement == DecisionAlgorithm.Movement.Up)
                {
                    driver.FindElement(By.TagName("body")).SendKeys(Keys.ArrowUp);
                }
                else
                if (movement == DecisionAlgorithm.Movement.Right)
                {
                    driver.FindElement(By.TagName("body")).SendKeys(Keys.ArrowRight);
                }
                else
                if (movement == DecisionAlgorithm.Movement.Down)
                {
                    driver.FindElement(By.TagName("body")).SendKeys(Keys.ArrowDown);
                }
                else
                if (movement == DecisionAlgorithm.Movement.Left)
                {
                    driver.FindElement(By.TagName("body")).SendKeys(Keys.ArrowLeft);
                }
                else
                    continueRunning = false;
            }
        }
    }
}
