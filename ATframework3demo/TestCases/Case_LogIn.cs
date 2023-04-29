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
            caseCollection.Add(new TestCase("Проверка авторизации", (mainPage, info) => SendToAllByDefault(mainPage,info)));
            return caseCollection;
        }


        void SendToAllByDefault(MainPage mainPage, PortalInfo info)
        {
            mainPage.EnterLoginPage().LogIn(info);
            if (!mainPage.IsAuthorized())
                Log.Error("Не появилась кнопка входа в профиль после авторизации");
        }
    }
}
