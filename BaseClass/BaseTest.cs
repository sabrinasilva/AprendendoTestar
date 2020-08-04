using InvestimentoSicredi.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Serilog;

namespace InvestimentoSicredi.BaseClass
{
    public class BaseTest
    {
        public IWebDriver driver;

        public IniciandoAutomacao formSimulador;
        public WebDriverWait wait;

        [OneTimeSetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized"//, "--headless"
                );
            driver = new ChromeDriver(options);

            wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(30));

            formSimulador = new IniciandoAutomacao(driver,wait);
            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Debug()
              .WriteTo.File(@"..\..\..\Logs\" + this.GetType() + ".log", rollingInterval: RollingInterval.Year)
              .CreateLogger();

            driver.Navigate().GoToUrl("http://www.aprendendotestar.com.br/treinar-automacao.php");
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void Down()
        {
            driver.Quit();
        }
    }
}
