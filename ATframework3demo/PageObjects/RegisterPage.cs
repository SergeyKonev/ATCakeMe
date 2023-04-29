using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    public class RegisterPage
    {
        /// <summary>
        /// Класс страницы регистрации
        /// </summary>
        WebItem loginField = new WebItem("//input[@name=\"REGISTER[LOGIN]\"]", "Поле ввода логина");
        WebItem emailField = new WebItem("//input[@name=\"REGISTER[EMAIL]\"]", "Поле ввода Email");
        WebItem passwdField = new WebItem("//input[@name=\"REGISTER[PASSWORD]\"]", "Поле ввода пароля");
        WebItem confirmPasswdField = new WebItem("//input[@name=\"REGISTER[CONFIRM_PASSWORD]\"]", "Поле подтверждения пороля");
        WebItem fNameField = new WebItem("//input[@name=\"REGISTER[NAME]\"]", "Поле ввода имени");
        WebItem lNameField = new WebItem("//input[@name=\"REGISTER[LAST_NAME]\"]", "Поле ввода фамилии");
        WebItem genderDrop = new WebItem("//input[@name=\"REGISTER[PERSONAL_GENDER]\"]", "Выпадающий список ввода пола");
        WebItem notesField  = new WebItem("//input[@name=\"REGISTER[PERSONAL_NOTES]\"]", "Поле ввода дополнительной информации");
        WebItem cityField  = new WebItem("//input[@name=\"REGISTER[PERSONAL_CITY]\"]", "Поле ввода города");
        WebItem registerBut = new WebItem("//input[@name=\"register_submit_button\"]", "Кнопка регистрации");
        
        /// <summary>
        /// Заполняет форму и регистрирует пользователя
        /// </summary>
        /// <param name="user">Информация, которой заполняем форму</param>
        /// <returns>Страница авторизации</returns>
        public LoginPage RegisterNewUser(User user)
        {
            loginField.SendKeys(user.Login);
            emailField.SendKeys(user.Email);
            passwdField.SendKeys(user.Password);
            confirmPasswdField.SendKeys(user.Password);
            fNameField.SendKeys(user.FirstName);
            lNameField.SendKeys(user.SecondName);
            genderDrop.SelectListItemByText(((char)user.Gender).ToString());
            notesField.SendKeys(user.AdditionalInfo ?? "");
            cityField.SendKeys(user.City ?? "");
            
            registerBut.Click();
            return new LoginPage();
        }
    }
}
