using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class Header
    {
        public LoginPage EnterLoginPage()
        {
            new WebItem("//img[@aria-controls=\"dropdown-menu4\"]", "Выпадающее меню").Hover();
            new WebItem("//a[@href=\"/auth/\"]", "Кнопка LogIn").Click();
            return new LoginPage();
        }


        public ProfilePage EnterProfile()
        {
            new WebItem("//img[@aria-controls=\"dropdown-menu4\"]", "Выпадающее меню").Hover();
            Thread.Sleep(500);
            new WebItem("//a[@href=\"/profile/\"]", "Кнопка перехода в профиль").Click();
            return new ProfilePage();
        }


        public bool IsAuthorized()
        {
            new WebItem("//img[@aria-controls=\"dropdown-menu4\"]", "Выпадающее меню").Hover();
            Thread.Sleep(500);
            return new WebItem("//a[@href=\"/profile/\"]", "Кнопка перехода в профиль").WaitElementDisplayed();
        }


        public RecipeCreationPage EnterRecipeCreationPage()
        {
            new WebItem("//a[@href=\"/recipe/create/\"]", "Кнопка добаления рецепта").Click();
            return new RecipeCreationPage();
        }


        public void Logout()
        {
            new WebItem("//img[@aria-controls=\"dropdown-menu4\"]", "Выпадающее меню").Hover();
            Thread.Sleep(500);
            new WebItem("//a[@href=\"/logout/\"]", "Кнопка выхода из аккаунта").Click();
        }
    }
}
