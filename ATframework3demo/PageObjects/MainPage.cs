using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using OpenQA.Selenium.DevTools.V108.DOM;
using OpenQA.Selenium.DevTools.V108.Profiler;

namespace ATframework3demo.PageObjects
{
    public class MainPage
    {
        public ProfilePage openRecipeAuthorPage(string recipeName)
        {
            new WebItem($"//a[contains(text(),\"{recipeName}\")]//ancestor::div[@class=\"card card-list\"]//footer//a",
                    $"Кнопка перехода на автора рецепта с названием {recipeName}")
                .Click();
            return new ProfilePage();
        }
    }
}
