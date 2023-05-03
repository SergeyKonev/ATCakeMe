using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using OpenQA.Selenium;
using ATframework3demo.Utils;

namespace ATframework3demo.TestCases
{
    public class Case_RecipeCreation : CaseCollectionBuilder
    {
        
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Добавление рецепта", (mainPage, info) => RecipeCreation(mainPage, info)));
            caseCollection.Add(new TestCase("Удаление рецепта", (mainPage, info) => RecipeDeletion(mainPage, info)));
            return caseCollection;
        }


        void RecipeCreation(MainPage mainPage, PortalInfo info)
        {
            Header.EnterLoginPage().LogIn(info.PortalAdmin);
            Recipe recipe = Generator.RandomRecipe();
            Header.EnterRecipeCreationPage().CreateRecipe(recipe);
            if (!Header.IsRecipeInFeed(recipe.Name))
                Log.Error("Рецепт не появился в ленте");
        }


        void RecipeDeletion(MainPage mainPage, PortalInfo info)
        {
            var user = Generator.RandomUser();
            Header.EnterRegisterPage().RegisterNewUser(user).LogIn(user);
            Recipe recipe = Generator.RandomRecipe();
            Header.EnterRecipeCreationPage().CreateRecipe(recipe);
            Header.EnterProfile().DeleteRecipe(recipe.Name);
            if (Header.IsRecipeInFeed(recipe.Name))
                Log.Error("Рецепт до сих пор отображается в ленте");
        }
    }
}