using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.Utils;

namespace ATframework3demo.PageObjects
{
    public class ProfilePage
    {
        private WebItem unsubscribeBtn = new("//a[contains(@href, \"subsDel\")]", "Кнопка отписки");
        private WebItem subscribeBtn = new("//a[contains(@href, \"?subs\")]", "Кнопка подписки");
        private WebItem editProfilePageBtn = new WebItem("//a[@href=\"/profile/edit/\"]", "Кнопка перехода в режим редактирования профиля");
        
        /// <summary>
        /// Проверяет соответствуют ли данные пользователя тем, что в профиле
        /// </summary>
        /// <param name="user">Данные о пользователе</param>
        public ProfilePage CheckUser(User user)
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
            return this;
        }

        /// <summary>
        /// Открыть страницу редактирования данных пользователя 
        /// </summary>
        /// <returns></returns>
        public ProfileEditorPage OpenProfileEditor()
        {
            editProfilePageBtn.Click();
            return new ProfileEditorPage();
        }

        /// <summary>
        /// Подписаться на пользователя
        /// </summary>
        public ProfilePage Subscribe()
        {
            subscribeBtn.Click();
            return this;
        }

        /// <summary>
        /// Проверить подписаны ли мы на пользователя
        /// </summary>
        /// <returns></returns>
        public bool IsSubscribed()
        {
            return unsubscribeBtn.WaitElementDisplayed();
        }

        /// <summary>
        /// Удалить рецепт по названию
        /// </summary>
        /// <param name="name">Название удаляемого рецепта</param>
        public void DeleteRecipe(string name)
        {
            new WebItem($"//button[./../..//child::a[text() = \"{name} \" ]]", "Кнопка удаления рецепта").Click();
        }

        /// <summary>
        /// Проверка количества лайков на рецепте
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        public int CheckLikes(Recipe recipe)
        {
            return Convert.ToInt32(new WebItem($"//div[@class=\"card-footer-item\" and  ../parent::div[.//child::a[contains(text(), \"{recipe.Name}\")]]]", "Лайки на карточке").InnerText().Split(" ")[1]);            
        }
    }
}