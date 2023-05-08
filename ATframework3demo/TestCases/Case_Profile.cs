using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using ATframework3demo.Utils;

namespace ATframework3demo.TestCases;

public class Case_Profile : CaseCollectionBuilder
{
    protected override List<TestCase> GetCases()
    {
        var caseCollection = new List<TestCase>();
        caseCollection.Add(new TestCase("Проверка изменения данных профиля", (mainPage, info) => EditProfile(mainPage, info)));
        caseCollection.Add(new TestCase("Проверка изменения аутентификационных данных аккаунта", (mainPage, info) => EditAuthData(mainPage, info)));
        return caseCollection;
    }

    private void EditAuthData(MainPage mainPage, PortalInfo info)
    {
        // Входим в свой профиль
        Header
            .EnterLoginPage()
            .LogIn(info.PortalAdmin);
        // Открываем профиль
        var profileEditor = Header
            .EnterProfile()
            // Открываем редактирование профиля
            .OpenProfileEditor();
        
        // Создаем объект нового пользователя
        User newUser = Generator.RandomUser(
            haveEmail: false,
            haveCity: false,
            haveFirst: false,
            haveGender: false,
            haveNotes: false,
            haveSecond: false
        );

        // Изменяем аутентификационные данные о пользователе
        profileEditor
            .EditUserAuthenticationInfo(newUser)
            .SaveEditedInfo();
        
        // Выходим из аккаунта
        Header
            .Logout();
        
        // Пытаемся войти в аккаунт
        Header
            .EnterLoginPage()
            .LogIn(newUser);
        
        // Проверяем вход
        if (!Header.IsAuthorized())
            Log.Error("Не появилась кнопка входа в профиль после авторизации");

        // Возвращаем данные обратно
        Header
            .EnterProfile()
            .OpenProfileEditor()
            .EditUserAuthenticationInfo(info.PortalAdmin)
            .SaveEditedInfo();
    }

    void EditProfile(MainPage mainPage, PortalInfo info)
    {
        // Входим в свой профиль
        Header
            .EnterLoginPage()
            .LogIn(info.PortalAdmin);
        // Открываем профиль
        var profileEditor = Header
            .EnterProfile()
        // Открываем редактирование профиля
            .OpenProfileEditor();
        
        // Сохраняем данные о пользователе
        var oldUser = profileEditor.GetUserInfo();
        
        // Создаем объект нового пользователя
        User newUser = Generator.RandomUser(
            haveEmail: false,
            haveLogin: false,
            havePass: false
            );

        // Изменяем данные о пользователе
        profileEditor
            .EditUserProfileInfo(newUser)
            .SaveEditedInfo();
        
        // Проверяем пользовательские данные
        Header
            .EnterProfile()
            .CheckUser(newUser)
            .OpenProfileEditor()
            .EditUserProfileInfo(oldUser)
            .SaveEditedInfo();
    }
}