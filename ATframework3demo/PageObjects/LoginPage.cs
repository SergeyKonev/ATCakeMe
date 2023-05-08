using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    public class LoginPage
    {
        WebItem loginField = new WebItem("//input[@name=\"USER_LOGIN\"]", "Поле ввода логина");
        WebItem passwordField = new WebItem("//input[@name=\"USER_PASSWORD\"]", "Поле ввода пароля");
        WebItem submitButton = new WebItem("//input[@name=\"Login\"]", "Кнопка войти");

        /// <summary>
        /// Вход в аккаунт с информацией из объекта пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public MainPage LogIn(User user) 
        {
            loginField.ClearAndSendKeys(user.Login ?? "");
            passwordField.SendKeys(user.Password ?? "");
            submitButton.Click();
            return new MainPage();
        }
    }
}