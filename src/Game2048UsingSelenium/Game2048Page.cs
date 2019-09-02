
using Game2048;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using Shared.Core;

namespace Game2048UsingSelenium
{
    public class Game2048Page
    {
        IWebDriver driver;
        public Game2048Page()
        {
            this.driver = WebDriver.Driver;
            NavigateTo();
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
                var position = tile.GetAttribute("class");
                var classes = position.Split(' ');
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

        public void MoveTo(MovementDirection movement)
        {
            if (movement == MovementDirection.Up)
            {
                driver.FindElement(By.TagName("body")).SendKeys(Keys.ArrowUp);
            }
            else
            if (movement == MovementDirection.Right)
            {
                driver.FindElement(By.TagName("body")).SendKeys(Keys.ArrowRight);
            }
            else
            if (movement == MovementDirection.Down)
            {
                driver.FindElement(By.TagName("body")).SendKeys(Keys.ArrowDown);
            }
            else
            if (movement == MovementDirection.Left)
            {
                driver.FindElement(By.TagName("body")).SendKeys(Keys.ArrowLeft);
            }
        }
    }
}
