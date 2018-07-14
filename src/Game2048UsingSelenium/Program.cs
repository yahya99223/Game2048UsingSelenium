using Game2048;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            driver.Navigate().GoToUrl("https://gabrielecirulli.github.io/2048/");
            while (continueRunning)
            {
                Thread.Sleep(200);
                //wait until username textbox is viewed
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.ClassName("tile"))));

                var tiles = driver.FindElements(By.ClassName("tile"));
                var board = new Board();
                foreach (var tile in tiles)
                {
                    var postition = tile.GetAttribute("class");
                    var classes = postition.Split(' ');
                    int x = 0, y = 0, val = 0;
                    foreach (var className in classes)
                    {
                        if (className.Contains("position"))
                        {
                            var parts = className.Split('-');
                            x = int.Parse(parts[3]);
                            y = int.Parse(parts[2]);
                        }
                        else
                             if (className.Any(char.IsDigit))
                        {
                            var parts = className.Split('-');
                            val = int.Parse(parts[1]);
                        }
                    }
                    board.Cells[x - 1, y - 1] = val;
                }
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
