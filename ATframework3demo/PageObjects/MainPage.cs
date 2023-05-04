using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using OpenQA.Selenium.DevTools.V108.DOM;
using OpenQA.Selenium.DevTools.V108.Profiler;

namespace ATframework3demo.PageObjects
{
    public class MainPage
    {
        public ProfilePage OpenRecipeAuthorPage(string recipeName)
        {
            new WebItem($"//a[contains(text(),\"{recipeName}\")]//ancestor::div[@class=\"card card-list\"]//footer//a",
                    $"Кнопка перехода на автора рецепта с названием {recipeName}")
                .Click();
            return new ProfilePage();
        }
        public RecipePage EnterRecipePage(String recipeName)
        {
            new WebItem($"//a[contains(text(), \"{recipeName}\")]", "Карточка с рецептом").Click();
            return new RecipePage();
        }

        public void LikeRecipe(Recipe recipe)
        {
            new WebItem($"//button[contains(@id,\"like-btn-\") and ./parent::div[child::a[contains(text(), \"{recipe.Name}\")]]]", "Кнопка лайка").Click();
        }

        public bool HasLike(Recipe recipe)
        {
            return new WebItem($"//button[contains(@id,\"like-btn-\") and  @class=\"like like-active\"  and ./parent::div[child::a[contains(text(), \"{recipe.Name}\")]]]", "Кнопка лайка").WaitElementDisplayed();
        }
    }
}
