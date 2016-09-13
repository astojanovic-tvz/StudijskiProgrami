using NUnit.Framework;
using HtmlAgilityPack;
using RazorGenerator.Testing;
using ASP;

namespace HKOWebMVC4.Tests.Views
{
    [TestFixture]
    class StudentiViewsTest
    {
        [Test]
        public void ShouldRenderStudentiStudentiKompetencijeView()
        {
            var sut = new _Views_HKOWebViews_Studenti_StudentiKompetencije_cshtml();
            var model = new HKOPodaci().KolegijKompetencije("128193");

            HtmlDocument html = sut.RenderAsHtml(model);

            var renderedElement = html.GetElementbyId("studentKompetencije").InnerHtml;

            Assert.That(renderedElement.Contains("Kompetencija"));

        }
    }
}
