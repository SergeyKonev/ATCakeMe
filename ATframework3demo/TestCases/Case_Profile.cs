using atFrameWork2.BaseFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;

namespace ATframework3demo.TestCases;

public class Case_Profile : CaseCollectionBuilder
{
    protected override List<TestCase> GetCases()
    {
        var caseCollection = new List<TestCase>();
        caseCollection.Add(new TestCase("Проверка изменения профиля", (mainPage, info) => EditProfile(mainPage, info)));
        return caseCollection;
    }

    void EditProfile(MainPage mainPage, PortalInfo info)
    {
        // Входим в свой профиль
        Header
            .EnterLoginPage()
            .LogIn(info.PortalAdmin);
        var oldUser = Header
            .EnterProfile()
            .OpenProfileEditor()
            .GetUserInfo();
    }
}