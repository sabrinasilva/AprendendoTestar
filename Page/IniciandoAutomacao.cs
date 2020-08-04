using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Serilog;
using InvestimentoSicredi.BaseClass;

namespace InvestimentoSicredi.Page
{
    public class IniciandoAutomacao : BaseTest
    {

        public IniciandoAutomacao(IWebDriver driver, WebDriverWait wait) 
        {
            this.driver = driver;
            this.wait = wait;

        }

        #region Elementos
        By inputUsuario = By.Name("form_usuario");
        By inputSenha = By.Name("form_senha");
        By inputNome = By.Name("form_nome");
        By buttonEnviar = By.CssSelector("input.btn.btn-info");
        By msgPreencherCampo = By.ClassName("focus-visible");
        By msgErroCampoBranco = By.CssSelector("body > section > section.wrapper > div > form > table > tbody > tr:nth-child(7) > td");
        By nomeEnviado = By.CssSelector("body > section > section.wrapper > div > table > tbody > tr:nth-child(2) > td:nth-child(2)");
        By usuarioEnviado = By.CssSelector("body > section > section.wrapper > div > table > tbody > tr:nth-child(2) > td:nth-child(3)");
        By senhaEnviado = By.CssSelector("body > section > section.wrapper > div > table > tbody > tr:nth-child(2) > td:nth-child(4)");

        #endregion
 
        public void InformarUsuario(string usuario)
        {

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(inputUsuario)).SendKeys(usuario);
            Log.Information("Informado usuario", usuario);
        }
 
        public void InformarSenha(string senha)
        {

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(inputSenha)).SendKeys(senha);
            Log.Information("Informado senha:" + senha);
        }

        public void InformarNome(string nome)
        {

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(inputNome)).SendKeys(nome);
            Log.Information("Clique informar nome");
            Log.Information("Informado nome:" + nome);

        }

        public void CliqueBotaoEnviar()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(buttonEnviar)).Click();
            Log.Information("Recebido clique no botão enviar");

        }

        public string PegarValorCampoUsuario()
        {

            string value = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(inputUsuario)).GetAttribute("value");
            return value;
        }
        public string PegarValorCampoSenha()
        {
           
            string value = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(inputSenha)).GetAttribute("value");
            return value;

        }
        
        public string PegarValorCampoNome()
        {
           
            string value = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(inputNome)).GetAttribute("value");
            return value;

        }
        public string RetornarMsgCampoObrigatorio()
        {
            string value = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(msgPreencherCampo)).GetAttribute("value");
            return value;
        }
        public string RetornarMsgCampoBranco()
        {
            string value = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(msgErroCampoBranco)).Text;
            return value;
        }
        
        public string RetornarNomeEnviado()
        {
            string value = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(nomeEnviado)).Text;
            Log.Information("Nome exibido:" + value);

            return value;
        }
        public string RetornarSenhaEnviada()
        {
            string value = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(senhaEnviado)).Text;
            Log.Information("Senha exibida:" + value);

            return value;
        }
        
        public string RetornarUsuarioEnviado()
        {
            string value = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(usuarioEnviado)).Text;
            Log.Information("Usuario exibido:" + value);

            return value;
        }

        


    }
}
