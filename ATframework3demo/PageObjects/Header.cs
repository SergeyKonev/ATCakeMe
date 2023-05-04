using System.Security.Cryptography.Xml;
using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium.DevTools.V109.Audits;

namespace ATframework3demo.PageObjects
{
    public static class Header
    {
        static WebItem dropdownProfileMenu = new("//img[@class=\"profile-image \" and @aria-controls=\"dropdown-menu4\"]", "Выпадающее меню профиля");
        public static LoginPage EnterLoginPage()
        {
            OpenDropDownProfile();
            new WebItem("//a[@href=\"/auth/\"]", "Кнопка LogIn").Click();
            return new LoginPage();
        }
        
        public static RegisterPage EnterRegisterPage()
        {
            OpenDropDownProfile();
            new WebItem("//a[@href=\"/register/\"]", "Кнопка перехода на региcтрацию").Click();
            return new RegisterPage();
        }

        public static ProfilePage EnterProfile()
        {
            OpenDropDownProfile();
            new WebItem("//a[@href=\"/profile/\"]", "Кнопка перехода в профиль").Click();
            return new ProfilePage();
        }


        public static bool IsAuthorized()
        {
            OpenDropDownProfile();
            return new WebItem("//a[@href=\"/profile/\"]", "Кнопка перехода в профиль").WaitElementDisplayed();
        }


        public static RecipeCreationPage EnterRecipeCreationPage()
        {
            new WebItem("//a[@href=\"/recipe/create/\"]", "Кнопка добаления рецепта").Click();
            return new RecipeCreationPage();
        }


        public static void Logout()
        {
            OpenDropDownProfile();
            new WebItem("//a[@href=\"/logout/\"]", "Кнопка выхода из аккаунта").Click();
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
            new WebItem("//input[@name=\"search-string\" and @type=\"text\"]", "Строка поиска").SendKeys(recipeName);
            new WebItem("//input[@alt=\"Submit Form\" and @name=\"search-string\"]", "Кнопка поиска").Click();
            return new MainPage();
        }
        public static SearchUsersPage EnterSearchUsersPage()
        {
            dropdownProfileMenu.Hover();
            new WebItem("//a[@href=\"/search/users/\"]", "Кнопка найти пользователя").Click();
            return new SearchUsersPage();
        }

        public static MainPage EnterMainPage()
        {
            new WebItem("//a[@href=\"/\"]", "Кнопка перехода на главную страницу").Click();
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
            new WebItem("//a[@href=\"/\"]", "Кнопка перехода на главную страницу").Click();
        }
    }
}
