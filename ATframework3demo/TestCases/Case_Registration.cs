﻿using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using ATframework3demo.Utils;

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
            var regUser = Generator.RandomUser();
            
            Header
            // Открываем страницу регистрации
                .EnterRegisterPage()
            // Регистрируем пользователя
                .RegisterNewUser(regUser)
            // Авторизируемся
                .LogIn(regUser);
            // Проверяем авторизацию
            if (!Header.IsAuthorized())
            {
                Log.Error("Не появилась кнопка входа в профиль после авторизации");
                return;
            }
            Header 
            // Открываем профиль
                .EnterProfile()
            // Проверяем данные пользователя
                .CheckUser(regUser);
            
        }
    }
}