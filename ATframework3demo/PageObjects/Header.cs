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
            dropdownProfileMenu.Hover();
            // Thread.Sleep(500); // TODO - заменить на Waiter
        }

        public static bool IsRecipeInFeed(String recipeName)
        {
            new WebItem("//input[@name=\"search-string\" and @type=\"text\"]", "Строка поиска").SendKeys(recipeName);
            new WebItem("//input[@alt=\"Submit Form\" and @name=\"search-string\"]", "Кнопка поиска").Click();
            return new WebItem($"//a[contains(text(), \"{recipeName}\")]", "Карточка с рецептом").WaitElementDisplayed();
        }

        public static SearchUsersPage EnterSearchUsersPage()
        {
            dropdownProfileMenu.Hover();
            new WebItem("//a[@href=\"/search/users/\"]", "Кнопка найти пользователя").Click();
            return new SearchUsersPage();
        }
    }
}
