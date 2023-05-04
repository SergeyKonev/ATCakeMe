using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.PageObjects
{
    public class SearchUsersPage
    {
        private WebItem searchField = new("//input[@id=\"search-input\"]", "Поле ввода");
        private WebItem searchBtn = new("//button[@type=\"submit\"]", "Кнопка поиска");
        /// <summary>
        /// Класс страницы поиска других пользователей
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <returns></returns>
        public ProfilePage SearchForUser(User user) 
        {
            searchField.SendKeys(user.Login);
            searchBtn.Click();
            new WebItem($"//strong[text() = \"{user.FirstName} {user.SecondName} ({user.Login})\"]", "Карточка профиля").Click();
            return new ProfilePage();
        }
    }
}
