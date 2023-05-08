using atFrameWork2.SeleniumFramework;
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using ATframework3demo.Utils;
using OpenQA.Selenium.DevTools.V108.Audits;

namespace ATframework3demo.TestCases
{
    public class Case_SubscribingToAnotherUser : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Подписка на другого пользователя", (mainPage, info) => Subscribing(mainPage, info)));
            return caseCollection;
        }

        /// <summary>
        /// Кейс подписки одного пользователя на другого
        /// </summary>
        /// <param name="mainPage"></param>
        /// <param name="info"></param>
        void Subscribing(MainPage mainPage, PortalInfo info)
        {
            // Генерация тестовых данных
            var user1 = Generator.RandomUser();
            var user2 = Generator.RandomUser();

            // Регистрация 1 пользователя
            Header.EnterRegisterPage().RegisterNewUser(user1);

            // Регистрация 2-го пользователя и вход в аккаунт
            Header.EnterRegisterPage().RegisterNewUser(user2).LogIn(user2);

            // Проверка, что первый пользователь отсутствует в подписках
            if (Header.EnterSubscriptions().IsSubscribed(user1))
            {
                Log.Error("Пользователь отображется в подписках без подписки на него");
                return;
            }

            // Поиск и переход на страницу первого пользователя
            ProfilePage profile = Header.EnterSearchUsersPage().SearchForUser(user1);

            // Подписка второго пользователя на первого
            profile.Subscribe();

            // Обновление страницы
            DriverActions.Refresh();

            // Проверка успешности подписки
            if (!profile.IsSubscribed()) {
                Log.Error("Не получилось подписаться, либо не отобразилась кнопка отписки");
                return;
            }

            // Проверка появления пользователя в подписках
            if (!Header.EnterSubscriptions().IsSubscribed(user1))
            {
                Log.Error("Пользователь не отображается в подписках");
            }
                
        }
    }
}
