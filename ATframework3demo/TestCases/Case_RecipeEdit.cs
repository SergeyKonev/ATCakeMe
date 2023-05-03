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


        void RecipeEdit(MainPage mainPage, PortalInfo info)
        {
            mainPage = Header.EnterLoginPage().LogIn(info.PortalAdmin);


            //создание рецепта
            var recipe = Generator.RandomRecipe();
            Header.EnterRecipeCreationPage().CreateRecipe(recipe);

            var aimRecipe = Generator.RandomRecipe(
                haveImages: false,
                haveCategories: false,
                haveIngredients: false,
                haveSteps: false);

            if (!Header.IsRecipeInFeed(recipe.Name))
                Log.Error("Рецепт не появился в ленте");
            
            RecipePage recipePage = mainPage.EnterRecipePage(recipe.Name);
            Recipe recipeOnPage = recipePage.GetRecipe();

            recipePage.EnterRecipeEditorPage().CreateRecipe(aimRecipe);

            if (!Header.IsRecipeInFeed(aimRecipe.Name))
                Log.Error("Рецепт не появился в ленте");
            recipePage = mainPage.EnterRecipePage(aimRecipe.Name);
            recipeOnPage = recipePage.GetRecipe();

            if (!recipeOnPage.Equals(aimRecipe))
                Log.Error("У измененного рецепта отображаются неверные данные");
        }
    }
}
