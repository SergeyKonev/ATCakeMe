using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using OpenQA.Selenium;
using ATframework3demo.Utils;

namespace ATframework3demo.TestCases
{
    public class Case_RecipeEdit : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Редактирование рецепта", (mainPage, info) => RecipeEdit(mainPage, info)));
            return caseCollection;
        }

        /// <summary>
        /// Кейс создания и редактирования рецепта
        /// </summary>
        /// <param name="mainPage"></param>
        /// <param name="info"></param>
        void RecipeEdit(MainPage mainPage, PortalInfo info)
        {
            // Подготовка тестовых данных
            var recipe = Generator.RandomRecipe();
            var aimRecipe = Generator.RandomRecipe(
                haveImages: false,
                haveCategories: false,
                haveIngredients: false,
                haveSteps: false);

            // Авторизация
            mainPage = Header.EnterLoginPage().LogIn(info.PortalAdmin);

            // Создание рецепта
            Header.EnterRecipeCreationPage().CreateRecipe(recipe);

            // Переход в каталог рецептов
            Header.EnterMainPage();

            // Проверка создался ли рецепт
            if (!Header.IsRecipeInFeed(recipe.Name))
            {
                Log.Error("Рецепт не появился в ленте");
                return;
            }

            // Переход на страницу рецепта
            RecipePage recipePage = mainPage.EnterRecipePage(recipe.Name);

            // Считывание данных отображаемых на странице рецепта
            Recipe recipeOnPage = recipePage.GetRecipe();

            //Редактирование рецепта
            recipePage.EnterRecipeEditorPage().CreateRecipe(aimRecipe);

            // Переход в каталог рецептов
            Header.EnterMainPage();

            // Проверка на то, отображается ли измененный рецепт в ленте
            if (!Header.IsRecipeInFeed(aimRecipe.Name))
            {
                Log.Error("Рецепт не появился в ленте");
                return;
            }
            
            // Переход на страницу рецепта
            recipePage = mainPage.EnterRecipePage(aimRecipe.Name);

            // Считывание информации о рецепте
            recipeOnPage = recipePage.GetRecipe();

            // Проверка на соответствие отображаемых данных на детальной странице, данным, которые указывали при редактировании
            if (!recipeOnPage.Equals(aimRecipe))
                Log.Error("У измененного рецепта отображаются неверные данные");
        }
    }
}
