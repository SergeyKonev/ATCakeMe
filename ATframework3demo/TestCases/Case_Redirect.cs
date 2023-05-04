using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using ATframework3demo.Utils;

namespace ATframework3demo.TestCases
{
    public class Case_Redirect : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            
            caseCollection.Add(new TestCase("Переход из карточки чужого рецепта на автора", (mainPage, info) => AuthorFromCard(mainPage,info)));
            caseCollection.Add(new TestCase("Переход из карточки своего рецепта на свою страницу", (mainPage, info) => OnMeFromCard(mainPage,info)));
            caseCollection.Add(new TestCase("Переход на страницу автора чужого рецепта из детальной страницы", (mainPage, info) => AuthorFromDetail(mainPage,info)));
            caseCollection.Add(new TestCase("Переход на страницу профиля из детальной страницы своего рецепта", (mainPage, info) => OnMeFromDetail(mainPage,info)));

            return caseCollection;
        }


        void AuthorFromCard(MainPage mainPage, PortalInfo info)
        {
            // Логинимся в аккаунт
            Header
                .EnterLoginPage()
                .LogIn(info.PortalAdmin);
            if (!Header.IsAuthorized())
                Log.Error("Не появилась кнопка входа в профиль после авторизации");

            // Получаем информацию о пользователе, чтобы потом проверить её
            var user1 = Header
                .EnterProfile()
                .OpenProfileEditor()
                .GetUserInfo();
            
            // Создаем объект тестового рецепта
            Recipe recipe1 = Generator.RandomRecipe();

            // Создаем рецепт на сайте
            Header
                .EnterRecipeCreationPage()
                .CreateRecipe(recipe1);
            
            // Выходим со страницы
            Header
                .Logout();

            // Создаем объект второго пользователя и регистрируем его
            var user2 = Generator.RandomUser();
            Header
                .EnterRegisterPage()
                .RegisterNewUser(user2)
                .LogIn(user2);

            // Находим созданный рецепт
            Header
                .SearchRecipeByName(recipe1.Name)
                // Переходим по ссылке на автора этого рецепта
                .OpenRecipeAuthorPage(recipe1.Name)
                // Проверяем открылась страница автора или другая
                .CheckUser(user1);

        }

        void OnMeFromCard(MainPage mainPage, PortalInfo info)
        {
            // Логинимся в аккаунт
            Header
                .EnterLoginPage()
                .LogIn(info.PortalAdmin);
            if (!Header.IsAuthorized())
                Log.Error("Не появилась кнопка входа в профиль после авторизации");
            
            // Получаем информацию о пользователе, чтобы потом проверить её
            var user1 = Header
                .EnterProfile()
                .OpenProfileEditor()
                .GetUserInfo();
            
            // Создаем объект тестового рецепта
            Recipe recipe1 = Generator.RandomRecipe();

            // Создаем рецепт на сайте
            Header
                .EnterRecipeCreationPage()
                .CreateRecipe(recipe1);
            
            // Находим созданный рецепт
            Header
                .SearchRecipeByName(recipe1.Name)
                // Переходим по ссылке на автора этого рецепта
                .OpenRecipeAuthorPage(recipe1.Name)
                // Проверяем открылась страница автора или другая
                .CheckUser(user1);
        }

        void AuthorFromDetail(MainPage mainPage, PortalInfo info)
        {
            // Логинимся в аккаунт
            Header
                .EnterLoginPage()
                .LogIn(info.PortalAdmin);
            if (!Header.IsAuthorized())
                Log.Error("Не появилась кнопка входа в профиль после авторизации");

            // Получаем информацию о пользователе, чтобы потом проверить её
            var user1 = Header
                .EnterProfile()
                .OpenProfileEditor()
                .GetUserInfo();
            
            // Создаем объект тестового рецепта
            Recipe recipe1 = Generator.RandomRecipe();

            // Создаем рецепт на сайте
            Header
                .EnterRecipeCreationPage()
                .CreateRecipe(recipe1);
            
            // Выходим со страницы
            Header
                .Logout();
            
            // Создаем объект второго пользователя и регистрируем его
            var user2 = Generator.RandomUser();
            Header
                .EnterRegisterPage()
                .RegisterNewUser(user2)
                .LogIn(user2);

            // Находим созданный рецепт
            Header
                .SearchRecipeByName(recipe1.Name)
                // Переходим по ссылке на автора этого рецепта
                .OpenRecipeDetailPage(recipe1.Name)
                // Проверяем открылась страница автора или другая
                .OpenAuthorProfilePage()
                .CheckUser(user1);
        }
        
        void OnMeFromDetail(MainPage mainPage, PortalInfo info)
        {
            // Логинимся в аккаунт
            Header
                .EnterLoginPage()
                .LogIn(info.PortalAdmin);
            if (!Header.IsAuthorized())
                Log.Error("Не появилась кнопка входа в профиль после авторизации");
            
            // Получаем информацию о пользователе, чтобы потом проверить её
            var user1 = Header
                .EnterProfile()
                .OpenProfileEditor()
                .GetUserInfo();
            
            // Создаем объект тестового рецепта
            Recipe recipe1 = Generator.RandomRecipe();

            // Создаем рецепт на сайте
            Header
                .EnterRecipeCreationPage()
                .CreateRecipe(recipe1);
            
            // Находим созданный рецепт
            Header
                .SearchRecipeByName(recipe1.Name)
                // Переходим по ссылке на автора этого рецепта
                .OpenRecipeDetailPage(recipe1.Name)
                // Проверяем открылась страница автора или другая
                .OpenAuthorProfilePage()
                .CheckUser(user1);
        }
    }
}