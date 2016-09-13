using System.Web.Mvc;
using HKOWebMVC4.Controllers;
using NUnit.Framework;
using Moq;
using TestStack.FluentMVCTesting;

namespace HKOWebMVC4.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {

        HomeController controllerSUT = new HomeController();

        [Test]
        public void Index()
        {
            controllerSUT.WithCallTo(h => h.Index()).ShouldRenderDefaultView();
        }

        [Test]
        public void About()
        {
            controllerSUT.WithCallTo(h => h.About()).ShouldRenderDefaultView();
        }

        [Test]
        public void Contact()
        {
            controllerSUT.WithCallTo(h => h.Contact()).ShouldRenderDefaultView();
        }
    }
}
