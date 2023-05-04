using atFrameWork2.SeleniumFramework;
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using ATframework3demo.Utils;
using OpenQA.Selenium.DevTools.V108.Audits;

namespace ATframework3demo.TestCases
{
    public class Case_RecipeLike : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Установка лайка", (mainPage, info) => RecipeLike(mainPage, info)));
            return caseCollection;
        }

        /// <summary>
        /// Кейс лайка рецепта
        /// </summary>
        /// <param name="mainPage"></param>
        /// <param name="info"></param>
        void RecipeLike(MainPage mainPage, PortalInfo info)
        {
            //тестовые данные
            var user1 = Generator.RandomUser();
            var recipe = Generator.RandomRecipe();
            var user2 = Generator.RandomUser();

            //регистрация 1 пользователя
            Header.EnterRegisterPage().RegisterNewUser(user1).LogIn(user1);

            //создание рецепта
            Header.EnterRecipeCreationPage().CreateRecipe(recipe);

            //выход из аккаунта
            Header.Logout();

            //регистрация 2-го пользователя и вход в аккаунт
            Header.EnterRegisterPage().RegisterNewUser(user2).LogIn(user2);

            //поиск рецепта в ленте
            Header.SearchRecipeByName(recipe.Name);

            //установка лайка на рецепте
            mainPage.LikeRecipe(recipe);

            //обновление страницы
            DriverActions.Refresh();

            //проверка лайка
            if (!mainPage.HasLike(recipe))
                Log.Error("Не получилось поставить лайк");
        }
    }
}
