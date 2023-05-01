using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using ATframework3demo.Utils;
using OpenQA.Selenium.DevTools.V108.Audits;

namespace ATframework3demo.TestCases
{
    public class CaseRegistration : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Проверка регистрации", (mainPage, info) => SuccessfulRegistration(mainPage, info)));
            return caseCollection;
        }


        void SuccessfulRegistration(MainPage mainPage, PortalInfo info)
        {
            // Регистрационные данные
            var regUser = new User(
                login: Generator.RandomString(Generator.RandomInt(3, 10)),
                password: Generator.RandomString(Generator.RandomInt(6, 15)),
                email: Generator.RandomString(Generator.RandomInt(5, 10)) + "@mail.ru",
                firstName: Generator.RandomString(Generator.RandomInt(1, 10)),
                secondName: Generator.RandomString(Generator.RandomInt(1, 10)),
                gender: Generator.RandomGender(),
                additionalInfo: Generator.RandomString(15),
                city: Generator.RandomString(10)
            );
            Header
            // Открываем страницу регистрации
                .EnterRegisterPage()
            // Регистрируем пользователя
                .RegisterNewUser(regUser)
            // Авторизируемся
                .LogIn(regUser);
            // Проверяем авторизацию
            if (!Header.IsAuthorized())
                Log.Error("Не появилась кнопка входа в профиль после авторизации");
            Header 
            // Открываем профиль
                .EnterProfile()
            // Проверяем данные пользователя
                .CheckUser(regUser);
            
        }
    }
}