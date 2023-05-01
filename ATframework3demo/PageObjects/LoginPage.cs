using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    /// <summary>
    /// Login Page Class
    /// </summary>
    public class LoginPage
    {
        WebItem loginField = new WebItem("//input[@name=\"USER_LOGIN\"]", "Поле ввода логина");
        WebItem passwordField = new WebItem("//input[@name=\"USER_PASSWORD\"]", "Поле ввода пароля");
        WebItem submitButton = new WebItem("//input[@name=\"Login\"]", "Кнопка войти");

        /// <summary>
        /// Login to account using test information
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public MainPage LogIn(User user) 
        {
            loginField.SendKeys(Keys.Control + "A");
            loginField.SendKeys(Keys.Delete);
            loginField.SendKeys(user.Login ?? "");
            passwordField.SendKeys(user.Password ?? "");
            submitButton.Click();
            return new MainPage();
        }
    }
}