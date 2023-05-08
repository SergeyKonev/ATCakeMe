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

        /// <summary>
        /// Кейс создания нового рецепта
        /// </summary>
        /// <param name="mainPage"></param>
        /// <param name="info"></param>
        void RecipeCreation(MainPage mainPage, PortalInfo info)
        {
            // Генерация тестовых данных
            Recipe recipe = Generator.RandomRecipe();

            // Авторизация
            Header.EnterLoginPage().LogIn(info.PortalAdmin);
            
            // Создание рецептов
            Header.EnterRecipeCreationPage().CreateRecipe(recipe);

            // Переход в каталог рецептов
            Header.EnterMainPage();
             
            // Проверка отображения рецептов в общей ленте
            if (!Header.IsRecipeInFeed(recipe.Name))
            {
                Log.Error("Рецепт не появился в ленте");
                return;
            }

            // Переход на страницу рецепта, получение информации о рецепте
            Recipe recipeOnPage = mainPage.EnterRecipePage(recipe.Name).GetRecipe();

            // Проверка отображаемых данных на странице рецепта
            if (!recipeOnPage.Equals(recipe))
            {
                Log.Error("Отображаемые на странице рецепта данные не совпадают с теми, которые вводились при создании");
            }
        }

        /// <summary>
        /// Кейс создания рецепта с последующим удалением
        /// </summary>
        /// <param name="mainPage"></param>
        /// <param name="info"></param>
        void RecipeDeletion(MainPage mainPage, PortalInfo info)
        {
            // Генерация тестовых данных
            Recipe recipe = Generator.RandomRecipe();
            var user = Generator.RandomUser();

            // Создание нового пользователя и авторизация
            Header.EnterRegisterPage().RegisterNewUser(user).LogIn(user);

            // Создание рецепта
            Header.EnterRecipeCreationPage().CreateRecipe(recipe);

            // Переход в ленту рецептов пользователя и удаление рецепта
            Header.EnterProfile().DeleteRecipe(recipe.Name);

            // Переход в каталог рецептов
            Header.EnterMainPage();

            // Проверка, удалился ли рецепт из общей ленты
            if (Header.IsRecipeInFeed(recipe.Name))
                Log.Error("Рецепт до сих пор отображается в ленте");
        }
    }
}