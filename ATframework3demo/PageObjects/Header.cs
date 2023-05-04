using System.Security.Cryptography.Xml;
using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium.DevTools.V108.IndexedDB;
using OpenQA.Selenium.DevTools.V109.Audits;

namespace ATframework3demo.PageObjects
{
    public static class Header
    {
        private static WebItem mainPageBtn = new("//a[@href=\"/\"]", "Кнопка перехода на главную страницу");
        private static WebItem createRecipeBtn = new("//a[@href=\"/recipe/create/\"]", "Кнопка добаления рецепта");
        private static WebItem recentRecipeBtn = new WebItem("//a[@onclick=\"displayRecentRecipes()\"]","Кнопка открытия недавних рецептов");
        private static WebItem profileBtn = new("//a[@href=\"/profile/\"]", "Кнопка перехода в профиль");
        private static WebItem registerBtn = new("//a[@href=\"/register/\"]", "Кнопка перехода на региcтрацию");
        private static WebItem loginBtn = new("//a[@href=\"/auth/\"]", "Кнопка LogIn");
        private static WebItem logoutBtn = new("//a[@href=\"/logout/\"]", "Кнопка выхода из аккаунта");
        private static WebItem dropdownProfileMenu = new("//img[@class=\"profile-image \" and @aria-controls=\"dropdown-menu4\"]", "Выпадающее меню профиля");
        private static WebItem searchUserBtn = new("//a[@href=\"/search/users/\"]", "Кнопка найти пользователя");
        private static WebItem searchField = new("//input[@name=\"search-string\" and @type=\"text\"]", "Строка поиска");
        private static WebItem searchBtn = new("//input[@alt=\"Submit Form\" and @name=\"search-string\"]", "Кнопка поиска");
        /// <summary>
        /// Открытие страницы авторизации
        /// </summary>
        /// <returns></returns>
        public static LoginPage EnterLoginPage()
        {
            OpenDropDownProfile();
            loginBtn.Click();
            return new LoginPage();
        }
        /// <summary>
        ///  Открытие страницы регистрации
        /// </summary>
        /// <returns></returns>
        public static RegisterPage EnterRegisterPage()
        {
            OpenDropDownProfile();
            registerBtn.Click();
            return new RegisterPage();
        }
        /// <summary>
        /// Открытие своего профиля
        /// </summary>
        /// <returns></returns>
        public static ProfilePage EnterProfile()
        {
            OpenDropDownProfile();
            profileBtn.Click();
            return new ProfilePage();
        }

        /// <summary>
        /// Проверка авторизации
        /// </summary>
        /// <returns></returns>
        public static bool IsAuthorized()
        {
            OpenDropDownProfile();
            return loginBtn.WaitElementDisplayed();
        }

        /// <summary>
        /// Открытие страницы создания рецепта
        /// </summary>
        /// <returns></returns>
        public static RecipeCreationPage EnterRecipeCreationPage()
        {
            createRecipeBtn.Click();
            return new RecipeCreationPage();
        }

        /// <summary>
        /// Выход из аккаунта
        /// </summary>
        public static void Logout()
        {
            OpenDropDownProfile();
            logoutBtn.Click();
        }
        /// <summary>
        /// Открытие выпадающего списка опций с пользователем
        /// </summary>
        private static void OpenDropDownProfile()
        {
            dropdownProfileMenu.WaitElementDisplayed();
            dropdownProfileMenu.Hover();
            //new WebItem("//div[@class=\"dropdown-content\" and .//parent::div[@id=\"dropdown-menu5\"]]", "Содержимое выпадающего меню").WaitElementDisplayed();
        }

        /// <summary>
        /// Есть ли рецепт в каталоге
        /// </summary>
        /// <param name="recipeName">Название рецепта</param>
        /// <returns></returns>
        public static bool IsRecipeInFeed(String recipeName)
        {
            SearchRecipeByName(recipeName);
            return new WebItem($"//a[contains(text(), \"{recipeName}\")]", "Карточка с рецептом").WaitElementDisplayed();
        }

        /// <summary>
        /// Поиск рецепта в каталоге
        /// </summary>
        /// <param name="recipeName">Название рецепта</param>
        /// <returns></returns>
        public static MainPage SearchRecipeByName(string recipeName)
        {
            searchField.SendKeys(recipeName);
            searchBtn.Click();
            return new MainPage();
        }
        
        /// <summary>
        /// Открытие страницы поиска пользователя
        /// </summary>
        /// <returns></returns>
        public static SearchUsersPage EnterSearchUsersPage()
        {
            dropdownProfileMenu.Hover();
            searchUserBtn.Click();
            return new SearchUsersPage();
        }

        /// <summary>
        /// Переход на главную страницу
        /// </summary>
        /// <returns></returns>
        public static MainPage EnterMainPage()
        {
            mainPageBtn.Click();
            return new MainPage();
        }

        /// <summary>
        /// Провека, есть ли рецепт в недавно посещенных
        /// </summary>
        /// <param name="name">Название</param>
        public static void AssertLastRecentRecipeName(string name)
        { 
            OpenRecentRecipeBox();
            var lastRecipeName = new WebItem(
                "//a[@onclick=\"displayRecentRecipes()\"]/..//div[@class=\"content\"]/div[@class=\"box box-user-search\"]",
                "Имя последнего рецепта");
            lastRecipeName.AssertTextContains(name, "Последний посещенный рецепт не совпадает с действительным");
        }
        
        /// <summary>
        /// Открытие списка недавно посещенных рецептов
        /// </summary>
        public static void OpenRecentRecipeBox()
        {
            recentRecipeBtn.Click();
        }
    }
}
