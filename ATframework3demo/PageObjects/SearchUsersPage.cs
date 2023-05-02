using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class SearchUsersPage
    {
        public ProfilePage SearchForUser(string firstName, string secondName) 
        {
            new WebItem("//input[@name=\"search_name\"]", "Поле ввода имени").SendKeys(firstName);
            new WebItem("//input[@name=\"search_last\"]", "Поле ввода фамилии").SendKeys(secondName);
            new WebItem("//button[@type=\"submit\"]", "Кнопка поиска").Click();
            new WebItem($"//strong[text() = \"{firstName} {secondName}\"]", "Карточка профиля").Click();
            return new ProfilePage();
        }
    }
}
