using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using OpenQA.Selenium.DevTools.V108.DOM;
using OpenQA.Selenium.DevTools.V108.Profiler;

namespace ATframework3demo.PageObjects
{
    public class MainPage
    {
        /// <summary>
        /// Открытие профиля автора из карточки рецепта
        /// </summary>
        /// <param name="recipeName">Название рецепта, на страницу автора которого нужно перейти</param>
        /// <returns></returns>
        public ProfilePage OpenRecipeAuthorPage(string recipeName)
        {
            new WebItem($"//a[contains(text(),\"{recipeName}\")]//ancestor::div[@class=\"card card-list\"]//footer//a",
                    $"Кнопка перехода на автора рецепта с названием {recipeName}")
                .Click();
            return new ProfilePage();
        }
        
        /// <summary>
        /// Перейти на детальную страницу рецепта
        /// </summary>
        /// <param name="recipeName">Название рецепта</param>
        /// <returns></returns>
        public RecipePage EnterRecipePage(String recipeName)
        {
            new WebItem($"//a[contains(text(), \"{recipeName}\")]", "Карточка с рецептом").Click();
            return new RecipePage();
        }

        /// <summary>
        /// Поставить лайк на рецепт
        /// </summary>
        /// <param name="recipe">Данные о рецепте</param>
        public void LikeRecipe(Recipe recipe)
        {
            new WebItem($"//button[contains(@id,\"like-btn-\") and ./parent::div[child::a[contains(text(), \"{recipe.Name}\")]]]", "Кнопка лайка").Click();
        }

        /// <summary>
        /// Стоит ли лайк на рецепте
        /// </summary>
        /// <param name="recipe">Данные о рецепте</param>
        /// <returns></returns>
        public bool HasLike(Recipe recipe)
        {
            return new WebItem($"//button[contains(@id,\"like-btn-\") and  @class=\"like like-active\"  and ./parent::div[child::a[contains(text(), \"{recipe.Name}\")]]]", "Кнопка лайка").WaitElementDisplayed();
        }
    }
}
