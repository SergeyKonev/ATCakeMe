using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;

namespace ATframework3demo.TestCases
{
    public class Case_LogIn : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Проверка авторизации", (mainPage, info) => Login(mainPage,info)));
            return caseCollection;
        }

        /// <summary>
        /// Проверка авторизации пользователя, сравнение логина, указываемого при входе, с отображаемым в профиле
        /// </summary>
        /// <param name="mainPage"></param>
        /// <param name="info"></param>
        void Login(MainPage mainPage, PortalInfo info)
        {
            Header.EnterLoginPage().LogIn(info.PortalAdmin);
            if (!Header.IsAuthorized())
                Log.Error("Не появилась кнопка входа в профиль после авторизации");
            User user = Header.EnterProfile().OpenProfileEditor().GetUserInfo();
            if (user.Login != info.PortalAdmin.Login) 
            {
                Log.Error("У пользователя отображается неверный логин");
            }
        }

        /// <summary>
        /// NOT IMPLEMENTED
        /// </summary>
        /// <param name="mainPage"></param>
        /// <param name="info"></param>
        void LoginFromRegistrationPage(MainPage mainPage, PortalInfo info)
        {
            Header.EnterRegisterPage().EnterLoginPage();
            
        }
    }
}
