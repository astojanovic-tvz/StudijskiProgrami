using TestStack.Seleno.PageObjects;
using OpenQA.Selenium;

namespace HKOWebMVC4.Tests.SelenoPageObjectModels
{
    public class HomeIndexPage : Page<HKO_WEB>
    {
        public string HeaderOne
        {
            get
            {
                return Find.Element(By.TagName("h1")).Text;
            }
        }

        public HomeIndexPage EnterValue(string value)
        {
            Find.Element(By.Id("ElementId")).SendKeys("Sent value");

            return this;
        }
        /**
         * Primjer kako poslati vrijednost prema viewu
         */
        public T NavigateTo<T>() where T : UiComponent, new()
        {
            return Navigate.To<T>(By.Id("ElementId"));
        }
        /**
         * Primjer kako proslijediti model prema viewu na click
         */
        public T NavigateTo<T>(HKO_WEB model) where T : UiComponent, new()
        {
            Input.Model(model);

            return Navigate.To<T>(By.Id("ElementId"));
        }
    }
}
