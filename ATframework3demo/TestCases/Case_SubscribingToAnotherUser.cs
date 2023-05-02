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


        void Subscribing(MainPage mainPage, PortalInfo info)
        {
            //регистрация 1 пользователя
            var user1 = new User(
                login: Generator.RandomString(Generator.RandomInt(3, 10)),
                password: Generator.RandomString(Generator.RandomInt(6, 15)),
                email: Generator.RandomString(Generator.RandomInt(5, 10)) + "@mail.ru",
                firstName: Generator.RandomString(Generator.RandomInt(1, 10)),
                secondName: Generator.RandomString(Generator.RandomInt(1, 10)),
                gender: Generator.RandomGender(),
                additionalInfo: Generator.RandomString(15),
                city: Generator.RandomString(10)
            );
            
            Header.EnterRegisterPage().RegisterNewUser(user1);
            //регистрация 2-го пользователя
            var user2 = new User(
                login: Generator.RandomString(Generator.RandomInt(3, 10)),
                password: Generator.RandomString(Generator.RandomInt(6, 15)),
                email: Generator.RandomString(Generator.RandomInt(5, 10)) + "@mail.ru",
                firstName: Generator.RandomString(Generator.RandomInt(1, 10)),
                secondName: Generator.RandomString(Generator.RandomInt(1, 10)),
                gender: Generator.RandomGender(),
                additionalInfo: Generator.RandomString(15),
                city: Generator.RandomString(10)
            );
            Header.EnterRegisterPage().RegisterNewUser(user2).LogIn(user2);
            //подписка второго пользователя на первого
            ProfilePage profile = Header.EnterSearchUsersPage().SearchForUser(user1.FirstName, user1.SecondName);
            profile.Subscribe();
            if (!profile.IsSubscribed())
                Log.Error("Не получилось подписаться, либо не отобразилась кнопка отписки");
        }
    }
}
