using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.PageObjects
{
    public class SearchUsersPage
    {
        /// <summary>
        /// Класс страницы поиска других пользователей
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <returns></returns>
        public ProfilePage SearchForUser(User user) 
        {
            new WebItem("//input[@id=\"search-input\"]", "Поле ввода").SendKeys(user.Login);
            new WebItem("//button[@type=\"submit\"]", "Кнопка поиска").Click();
            new WebItem($"//strong[text() = \"{user.FirstName} {user.SecondName} ({user.Login})\"]", "Карточка профиля").Click();
            return new ProfilePage();
        }
    }
}
