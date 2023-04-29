using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using OpenQA.Selenium;

namespace ATframework3demo.TestCases
{
    public class Case_RecipeCreation : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Добавление рецепта", (mainPage, info) => SendToAllByDefault(mainPage, info)));
            return caseCollection;
        }


        void SendToAllByDefault(MainPage mainPage, PortalInfo info)
        {
            //RecipeCreationPage recipeCreationPage = mainPage.EnterLoginPage().LogIn(info).EnterRecipeCreationPage();
        }
    }
}