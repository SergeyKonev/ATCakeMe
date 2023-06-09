﻿using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using ATframework3demo.Utils;

namespace ATframework3demo.TestCases
{
    public class Case_Comments : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Проверка добавления комментария", (mainPage, info) => CommentAdding(mainPage, info)));
            return caseCollection;
        }

        /// <summary>
        /// Написание комментария одним пользователем к рецепту другого пользователя
        /// </summary>
        /// <param name="mainPage"></param>
        /// <param name="info"></param>
        void CommentAdding(MainPage mainPage, PortalInfo info)
        {
            // Генерация тестовых данных
            var user1 = Generator.RandomUser();
            var user2 = Generator.RandomUser();
            var recipe = Generator.RandomRecipe();
            var comment = Generator.RandomString(Generator.RandomInt(1, 200));

            // Регистрация 1 пользователя и вход в аккаунт
            Header.EnterRegisterPage().RegisterNewUser(user1).LogIn(user1);

            // Создание нового рецепта
            Header.EnterRecipeCreationPage().CreateRecipe(recipe);

            // Выход из аккаунта
            Header.Logout();

            // Регистрация 2 пользователя и вход в аккаунт
            Header.EnterRegisterPage().RegisterNewUser(user2).LogIn(user2);

            // Поиск созданного рецепта и переход на страницу
            RecipePage recipePage = Header.SearchRecipeByName(recipe.Name).EnterRecipePage(recipe.Name);

            // Добавление комментария
            recipePage.WriteComment(comment);

            // Обновление страницы
            DriverActions.Refresh();

            // Проверка, что комментарий отображается
            if (!recipePage.IsCommentExists(user2 ,comment))
                Log.Error("Комментарий не добавился");
            
        }
    }
}
