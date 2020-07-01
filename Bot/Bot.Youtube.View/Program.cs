using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Bot.Youtube.View
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver webDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            try
            {
                Console.WriteLine("Acessando o video");
                webDriver.Navigate().GoToUrl("https://www.youtube.com/watch?v=r0A4-82uujg&list=PLDcxAw7lE_46q-Tqi0ePPAVJmJ6oJvkm1");
                Thread.Sleep(TimeSpan.FromSeconds(10));                
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
