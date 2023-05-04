using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using ATframework3demo.Utils;
using OpenQA.Selenium.DevTools.V110.WebAuthn;

namespace ATframework3demo.TestCases;

public class Case_RecentRecipe : CaseCollectionBuilder
{
    protected override List<TestCase> GetCases()
    {
        var caseCollection = new List<TestCase>();
        caseCollection.Add(new TestCase("Проверка добавления в недавние", (mainPage, info) => AddedInRecent(mainPage, info)));
        return caseCollection;
    }

    private void AddedInRecent(MainPage mainPage, PortalInfo info)
    {
        // Заходим в свой аккаунт
        Header
            .EnterLoginPage()
            .LogIn(info.PortalAdmin);
        
        // Создаем объект рецепта
        var recipe = Generator.RandomRecipe();
        
        // Создаем рецепт на сайте
        Header
            .EnterRecipeCreationPage()
            .CreateRecipe(recipe);

        // Находим рецепт в поиске
        Header
            .SearchRecipeByName(recipe.Name)
        // Переходим на детальную страницу
            .EnterRecipePage(recipe.Name);
        
        // Переходим обратно в каталог
        Header
            .EnterMainPage();
        
        // Проверяем есть ли название рецепта в недавних
        Header
            .AssertLastRecentRecipeName(recipe.Name);
    }
}