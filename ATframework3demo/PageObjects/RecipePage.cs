using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.Utils;
using OpenQA.Selenium;


namespace ATframework3demo.PageObjects
{
    public class RecipePage
    {
        string cookTimeString = new WebItem("//div[contains(text(),\"Время приготовления:\")]", "Время приготовления").InnerText().Split(" ")[2];
        string caloriesString = new WebItem("//div[contains(text(),\"Калории:\")]", "Количество калорий").InnerText().Split(" ")[1];
        string portionsString = new WebItem("//div[contains(text(),\"Количество порций:\")]", "Количество порций").InnerText().Split(" ")[2];

        private WebItem editBtn = new("//a[contains(@href, \"recipe/edit\")]", "Кнопка редактирования рецепта");
        private WebItem authorOfRecipe = new("//p[@class=\"title is-4\"]/a", "Переход на страницу автора");
        private WebItem commentTextarea = new("//textarea[@id=\"comment-textarea\"]", "Поле ввода комментария");
        private WebItem sendComment = new("//input[@alt=\"Submit Form\" and ./parent::form[@id=\"comment-form\"]]", "Кнопка отправки комментария");
        public Recipe GetRecipe()
        {
            return new Recipe(
                name: new WebItem("//div[@class=\"title mb-2\"]", "Название рецепта").InnerText(),
                description: new WebItem("//div[@class=\"content is-size-6\"]//child::p", "Описание рецепта").InnerText(),
                portionNum: Convert.ToInt32(portionsString),
                cookTime: Convert.ToInt32(cookTimeString),
                calories: Convert.ToInt32(caloriesString)
                );
        }

        public RecipeCreationPage EnterRecipeEditorPage()
        {
            editBtn.Click();
            return new RecipeCreationPage();
        }

        public ProfilePage OpenAuthorProfilePage()
        {
            authorOfRecipe.Click();
            return new ProfilePage();
        }

        public void WriteComment(string text) 
        {
            commentTextarea.SendKeys(text);
            sendComment.Click();
        }

        public bool IsCommentExists(User user, String text)
        {
            return new WebItem($"//div[.//child::a[contains(text(), \"{user.FirstName + " " + user.SecondName}\")] and .//child::p[contains(text(), \"{text}\")] and @class=\"card\"]", "Комментарий").WaitElementDisplayed();
        }
    }
}
