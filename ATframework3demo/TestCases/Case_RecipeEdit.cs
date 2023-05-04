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
            //подготовка тестовых данных
            var recipe = Generator.RandomRecipe();
            var aimRecipe = Generator.RandomRecipe(
                haveImages: false,
                haveCategories: false,
                haveIngredients: false,
                haveSteps: false);

            //авторизация
            mainPage = Header.EnterLoginPage().LogIn(info.PortalAdmin);

            //создание рецепта
            Header.EnterRecipeCreationPage().CreateRecipe(recipe);

            //проверка создался ли рецепт
            if (!Header.IsRecipeInFeed(recipe.Name))
                Log.Error("Рецепт не появился в ленте");
            RecipePage recipePage = mainPage.EnterRecipePage(recipe.Name);

            //считывание данных отображаемых на странице рецепта
            Recipe recipeOnPage = recipePage.GetRecipe();

            //редактирование рецепта
            recipePage.EnterRecipeEditorPage().CreateRecipe(aimRecipe);

            //проверка на то, отображается ли измененный рецепт в ленте
            if (!Header.IsRecipeInFeed(aimRecipe.Name))
                Log.Error("Рецепт не появился в ленте");
            recipePage = mainPage.EnterRecipePage(aimRecipe.Name);
            recipeOnPage = recipePage.GetRecipe();

            //проверка на соответствие отображаемых данных на детальной странице, данным, которые указывали при редактировании
            if (!recipeOnPage.Equals(aimRecipe))
                Log.Error("У измененного рецепта отображаются неверные данные");
        }
    }
}
