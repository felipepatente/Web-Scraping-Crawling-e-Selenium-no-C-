using OpenQA.Selenium;
using System;
using System.Reflection;
using System.Threading;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace Bot.Instagram.Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = "felipepatente@yahoo.com.br";
            string password = "46692201";
            
            IWebDriver webDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            
            try
            {
                #region Utilizando XPath para pegar elementos

                //webDriver.Navigate().GoToUrl("https://www.google.com.br/");
                //Thread.Sleep(TimeSpan.FromSeconds(10));

                //webDriver.FindElement(By.XPath("//*[@id='tsf']/div[2]/div[1]/div[1]/div/div[2]/input")).SendKeys("palmeiras tem mundial fifa 306");

                //Thread.Sleep(TimeSpan.FromSeconds(10));
                //webDriver.FindElement(By.XPath("//*[@id='tsf']/div[2]/div[1]/div[3]/center/input[1]")).Click();

                #endregion

                webDriver.Navigate().GoToUrl("https://www.instagram.com/accounts/login/");
                Thread.Sleep(TimeSpan.FromSeconds(10));

                webDriver.FindElement(By.Name("username")).SendKeys(username);
                webDriver.FindElement(By.Name("password")).SendKeys(password);
                webDriver.FindElement(By.TagName("button")).Submit();
                
                Thread.Sleep(TimeSpan.FromSeconds(10));

                webDriver.Navigate().GoToUrl("https://www.instagram.com/ionicclub/");
                
                IWebElement btnSeguir = null;

                try
                {
                    btnSeguir = webDriver.FindElement(By.XPath("//button[contains(text(), 'Seguir')]"));

                    btnSeguir.Click();
                }
                catch (NoSuchElementException ex)
                {
                    Console.WriteLine("Já está seguindo o usuário: " + ex.ToString());
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
            finally
            {
                webDriver.Close();
                webDriver.Dispose();
            }
        }
    }
}
