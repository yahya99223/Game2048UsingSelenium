
using Game2048;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace Game2048UsingSelenium
{
   public class Game2048Page
    {
        IWebDriver driver;
        public Game2048Page(IWebDriver driver)
        {
            this.driver = driver;
            NavigateTo();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.ClassName("tile"))));
        }
        public void NavigateTo()
        {
            driver.Navigate().GoToUrl("https://gabrielecirulli.github.io/2048/");
        }
        public Board GetBoard()
        {
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
            return board;
        }
    }
}
