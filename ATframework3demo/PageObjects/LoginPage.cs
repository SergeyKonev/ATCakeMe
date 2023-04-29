using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    public class LoginPage
    {
        public MainPage LogIn(PortalInfo info) 
        {
            new WebItem("//input[@name=\"USER_LOGIN\"]", "Поле ввода логина").SendKeys(Keys.Control + "A");
            new WebItem("//input[@name=\"USER_LOGIN\"]", "Поле ввода логина").SendKeys(Keys.Delete);
            new WebItem("//input[@name=\"USER_LOGIN\"]", "Поле ввода логина").SendKeys(info.PortalAdmin.Login);
            new WebItem("//input[@name=\"USER_PASSWORD\"]", "Поле ввода пароля").SendKeys(info.PortalAdmin.Password);
            new WebItem("//input[@name=\"Login\"]", "Кнопка войти").Click();
            return new MainPage();
        }
    }
}