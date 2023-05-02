using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.Utils;

namespace ATframework3demo.PageObjects;

public class ProfileEditorPage
{
    WebItem loginField = new WebItem("//input[@name=\"LOGIN\"]", "Поле ввода логина");
    WebItem emailField = new WebItem("//input[@name=\"EMAIL\"]", "Поле ввода Email");
    WebItem newPasswdField = new WebItem("//input[@name=\"NEW_PASSWORD\"]", "Поле ввода нового пароля");
    WebItem confirmNewPasswdField = new WebItem("//input[@name=\"NEW_PASSWORD_CONFIRM\"]", "Поле подтверждения пороля");
    WebItem fNameField = new WebItem("//input[@name=\"NAME\"]", "Поле ввода имени");
    WebItem lNameField = new WebItem("//input[@name=\"LAST_NAME\"]", "Поле ввода фамилии");
    WebItem genderDrop = new WebItem("//select[@name=\"PERSONAL_GENDER\"]", "Выпадающий список ввода пола");
    WebItem notesField  = new WebItem("//textarea[@name=\"PERSONAL_NOTES\"]", "Поле ввода дополнительной информации");
    WebItem cityField  = new WebItem("//input[@name=\"PERSONAL_CITY\"]", "Поле ввода города");
    WebItem saveBut = new WebItem("//input[@name=\"register_submit_button\"]", "Кнопка регистрации");

    public User GetUserInfo()
    {
        var login = loginField.GetAttribute("value");
        var email = emailField.GetAttribute("value");
        var fName = fNameField.GetAttribute("value");
        var lName = lNameField.GetAttribute("value");
        var genderName = genderDrop.GetSelectedText();
        var notes = notesField.GetAttribute("value");
        var city = cityField.GetAttribute("value");
        
        Gender gender = EnumExtensions.GetByName<Gender>(genderName);

        User user = new User(
            login: login,
            email: email,
            firstName: fName,
            secondName: lName,
            additionalInfo: notes,
            city: city,
            gender: gender
            );
        return user;
    }
}