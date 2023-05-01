using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.Utils;

namespace ATframework3demo.PageObjects
{
    public class ProfilePage
    {
        /// <summary>
        /// Проверяет соответствуют ли данные пользователя тем, что в профиле
        /// </summary>
        /// <param name="user">Данные о пользователе</param>
        public void CheckUser(User user)
        {
            var nameField = new WebItem("//div[@class=\"profile-header\"]", "имя фамилия с профиля");
            var genderField = new WebItem("//div[contains(p,\"Пол:\")]", "пол с профиля");
            var cityField = new WebItem("//div[contains(p,\"Город проживания:\")]", "город проживания с профиля");
            var descrField = new WebItem("//div[contains(p,\"Описание:\")]", "описание с профиля");

            nameField.AssertTextContains($"{user.FirstName} {user.SecondName}",
                "Имя фамилия зарегистрированного пользователя не совпадают с тем, что в профиле");
            genderField.AssertTextContains(user.Gender.DisplayName(),
                "Пол зарегистрированного пользователя не совпадает с тем, что в профиле");
            cityField.AssertTextContains(user.City,
                "Город зарегистрированного пользователя не совпадает с тем, что в профиле");
            descrField.AssertTextContains(user.AdditionalInfo,
                "Описание зарегистрированного пользователя не совпадает с тем, что в профиле");
        }
    }

}