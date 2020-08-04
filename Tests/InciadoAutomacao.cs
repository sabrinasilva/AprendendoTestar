using NUnit.Framework;
using InvestimentoSicredi.BaseClass;
using System;
using Serilog;
using OpenQA.Selenium;

namespace InvestimentoSicredi.Tests
{
    [TestFixture]

    public class InciadoAutomacao : BaseTest
    {

        [Test]
        [OrderAttribute(1)]
        public void ValidarValorIncial()
        {
            try
            {
                Assert.AreEqual("", formSimulador.PegarValorCampoUsuario());
                Assert.AreEqual("", formSimulador.PegarValorCampoSenha());
                Assert.AreEqual("", formSimulador.PegarValorCampoNome());
            }
            catch (InvalidCastException e)
            {
                Log.Error(e.Message);
            }
        }


        [Test]
        [OrderAttribute(2)]
        public void ValidarMsgCampoEmBranco()
        {
            try
            {
                formSimulador.CliqueBotaoEnviar();
                formSimulador.InformarUsuario("user");
                formSimulador.CliqueBotaoEnviar();
                formSimulador.InformarSenha("123");
                formSimulador.CliqueBotaoEnviar();
                Assert.AreEqual("Existem campos em branco.", formSimulador.RetornarMsgCampoBranco());
    
            }
            catch (InvalidCastException e)
            {
                Log.Error(e.Message);
            }
        }


        [Test]
        [OrderAttribute(3)]
        public void EnviarDados()
        {
            try
            {
                formSimulador.InformarUsuario("user");
                formSimulador.InformarSenha("123");
                formSimulador.InformarNome("Nome Usuario");
                formSimulador.CliqueBotaoEnviar();

                Assert.AreEqual("user", formSimulador.RetornarUsuarioEnviado());
                Assert.AreEqual("123", formSimulador.RetornarSenhaEnviada());
                Assert.AreEqual("Nome Usuario", formSimulador.RetornarNomeEnviado());

            }
            catch (InvalidCastException e)
            {
                Log.Error(e.Message);
            }
        }


    }
}