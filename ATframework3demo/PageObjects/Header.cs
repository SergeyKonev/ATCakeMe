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
        public static LoginPage EnterLoginPage()
        {
            OpenDropDownProfile();
            loginBtn.Click();
            return new LoginPage();
        }
        
        public static RegisterPage EnterRegisterPage()
        {
            OpenDropDownProfile();
            registerBtn.Click();
            return new RegisterPage();
        }

        public static ProfilePage EnterProfile()
        {
            OpenDropDownProfile();
            profileBtn.Click();
            return new ProfilePage();
        }


        public static bool IsAuthorized()
        {
            OpenDropDownProfile();
            return loginBtn.WaitElementDisplayed();
        }


        public static RecipeCreationPage EnterRecipeCreationPage()
        {
            createRecipeBtn.Click();
            return new RecipeCreationPage();
        }


        public static void Logout()
        {
            OpenDropDownProfile();
            logoutBtn.Click();
        }

        private static void OpenDropDownProfile()
        {
            dropdownProfileMenu.WaitElementDisplayed();
            dropdownProfileMenu.Hover();
            //new WebItem("//div[@class=\"dropdown-content\" and .//parent::div[@id=\"dropdown-menu5\"]]", "Содержимое выпадающего меню").WaitElementDisplayed();
        }

        public static bool IsRecipeInFeed(String recipeName)
        {
            SearchRecipeByName(recipeName);
            return new WebItem($"//a[contains(text(), \"{recipeName}\")]", "Карточка с рецептом").WaitElementDisplayed();
        }

        public static MainPage SearchRecipeByName(string recipeName)
        {
            searchField.SendKeys(recipeName);
            searchBtn.Click();
            return new MainPage();
        }
        public static SearchUsersPage EnterSearchUsersPage()
        {
            dropdownProfileMenu.Hover();
            searchUserBtn.Click();
            return new SearchUsersPage();
        }

        public static MainPage EnterMainPage()
        {
            mainPageBtn.Click();
            return new MainPage();
        }

        public static void AssertLastRecipeName(string name)
        { 
            OpenRecentRecipeBox();
            var lastRecipeName = new WebItem(
                "//a[@onclick=\"displayRecentRecipes()\"]/..//div[@class=\"content\"]/div[@class=\"box box-user-search\"]",
                "Имя последнего рецепта");
            lastRecipeName.AssertTextContains(name, "Последний посещенный рецепт не совпадает с действительным");
        }
        public static void OpenRecentRecipeBox()
        {
            recentRecipeBtn.Click();
        }
    }
}
