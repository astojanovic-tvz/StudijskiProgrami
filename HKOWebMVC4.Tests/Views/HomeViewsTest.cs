using NUnit.Framework;
using System.Linq;
using HKOWebMVC4.Views;
using RazorGenerator.Testing;
using HtmlAgilityPack;
using OpenQA.Selenium;
using HKOWebMVC4.Controllers;
using HKOWebMVC4.Tests.SelenoPageObjectModels;
using TestStack.Seleno.PageObjects.Actions;

namespace HKOWebMVC4.Tests.Views
{
    [TestFixture]
    public class HomeViewsTest
    {
        [Test]
        public void ShouldRenderHomeAboutView()
        {
            var sut = new _Views_Home_About_cshtml();
            sut.ViewBag.Message = "About test";
            HtmlDocument html = sut.RenderAsHtml();
            var actualViewBag = html.GetElementbyId("viewBagMessage").InnerText;
            Assert.That(actualViewBag, Is.EqualTo("About test"));
        }

        [Test]
        public void GoHomePage()
        {
            var indexPage = HKOWebMVCBrowserHost.Instance.NavigateToInitialPage<HomeController, HomeIndexPage>(x => x.Index());

            var headerText = indexPage.HeaderOne;

            Assert.That(headerText, Is.EqualTo("ASP.NET"));
        }
    }
}
