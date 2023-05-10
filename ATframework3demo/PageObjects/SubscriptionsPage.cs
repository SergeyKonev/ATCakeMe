using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.PageObjects
{
    public class SubscriptionsPage
    {

        /// <summary>
        /// Проверка отображения указанного пользователя в подписках
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsSubscribed(User user)
        {
            return new WebItem($"//strong[text() = \"{user.FirstName} {user.SecondName} ({user.Login})\"]", "Карточка пользователя").WaitElementDisplayed();
        }
        
    }
}