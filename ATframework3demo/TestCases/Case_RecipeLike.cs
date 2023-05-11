using atFrameWork2.SeleniumFramework;
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using ATframework3demo.Utils;
using OpenQA.Selenium.DevTools.V108.Audits;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

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
            // Тестовые данные
            var user1 = Generator.RandomUser();
            var recipe = Generator.RandomRecipe();
            var user2 = Generator.RandomUser();

            // Регистрация 1 пользователя
            Header.EnterRegisterPage().RegisterNewUser(user1).LogIn(user1);

            // Создание рецепта
            Header.EnterRecipeCreationPage().CreateRecipe(recipe);

            // Проверка лайков при создании
            if (Header.EnterProfile().CheckLikes(recipe) != 0)
            {
                Log.Error("У рецепта изначально не 0 лайков");
                return;
            }

            // Выход из аккаунта
            Header.Logout();

            // Регистрация 2-го пользователя и вход в аккаунт
            Header.EnterRegisterPage().RegisterNewUser(user2).LogIn(user2);

            // Поиск рецепта в ленте
            Header.SearchRecipeByName(recipe.Name);

            // Установка лайка на рецепте
            mainPage.LikeRecipe(recipe);

            // Обновление страницы
            DriverActions.Refresh();

            // Поиск рецепта в ленте
            Header.SearchRecipeByName(recipe.Name);

            // Проверка лайка
            if (!mainPage.HasLike(recipe))
            {
                Log.Error("Не получилось поставить лайк");
                return;
            }

            // Выход из аккаунта
            Header.Logout();

            // Авторизация 1-го пользователя
            Header.EnterLoginPage().LogIn(user1);

            // Проверка появления лайка в профиле у первого пользователя
            if (Header.EnterProfile().CheckLikes(recipe) != 1)
            {
                Log.Error("У рецепта отображается неправильное количество лайков");
            }
        }
    }
}
