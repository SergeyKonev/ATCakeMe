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

        public List<Category> GetCategories()
        {
            /*var elements = DriverActions.FindElements("//span[@class=\"tag is-danger is-light\"]");
            var categories = new List<Category>();
            foreach (var element in elements)
            {
                categories.Add();
            }*/
            return new List<Category>();
        }

        public List<Ingredient> GetIngredients()
        {
            return new List<Ingredient>();
        }

        public List<RecipeStep> GetSteps()
        {
            return new List<RecipeStep>();
        }

        public Recipe GetRecipe()
        {
            return new Recipe(
                name: new WebItem("//div[@class=\"title mb-2\"]", "Название рецепта").InnerText(),
                description: new WebItem("//div[@class=\"content is-size-6\"]//child::p", "Описание рецепта").InnerText(),
                portionNum: Convert.ToInt32(portionsString),
                cookTime: Convert.ToInt32(cookTimeString),
                calories: Convert.ToInt32(caloriesString)
                //TODO: категории, шаги, ингредиенты
                );
        }

        public RecipeCreationPage EnterRecipeEditorPage()
        {
            new WebItem("//a[contains(@href, \"recipe/edit\")]", "Кнопка редактирования рецепта").Click();
            return new RecipeCreationPage();
        }

        
    }
}
