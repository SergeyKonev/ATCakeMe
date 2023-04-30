using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.PageObjects
{
    public class RecipeCreationPage
    {
        /// <summary>
        /// Class of recipe creation page
        /// </summary>
        /// <returns></returns>

        WebItem nameField = new WebItem("//input[@name=\"RECIPE_NAME\"]", "Поле ввода названия рецепта");
        WebItem descriptionField = new WebItem("//textarea[@name=\"RECIPE_DESC\"]", "Поле ввода описания рецепта");
        WebItem portionNumField = new WebItem("//input[@name=\"RECIPE_PORTION\"]", "Поле ввода количества порций");
        WebItem cookingTimeField = new WebItem("//input[@name=\"RECIPE_TIME\"]", "Поле ввода времени приготовления рецепта");
        WebItem caloriesField = new WebItem("//input[@name=\"RECIPE_CALORIES\"]", "Поле ввода количества калорий");
        WebItem submitButton = new WebItem("//input[@name=\"addRecipe\"]", "Кнопка сохранения рецета");
        WebItem addStepButton = new WebItem("//a[contains(@class,\"instruction-button\")]", "Кнопка добавления шага рецепта");
        WebItem addIngredientButton = new WebItem("//a[@class=\"table-button button is-primary is-light\"]", "Кнопка добавления ингредиента");

        /// <summary>
        /// Filling information on recipe creation page according to recipe object
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        public MainPage CreateRecipe(Recipe recipe)            
        {
            nameField.SendKeys(recipe.Name ?? "");
            descriptionField.SendKeys(recipe.Description ?? "");
            portionNumField.SendKeys(recipe.PortionNum.ToString() ?? "");
            cookingTimeField.SendKeys(recipe.CookTime.ToString() ?? "");
            caloriesField.SendKeys(recipe.Calories.ToString() ?? "");

            ///not implemented
            /* this.AddImages(recipe.Images);
            this.AddCategories(recipe.Categories);
            this.AddIngredients(recipe.Ingredients);*/
            ///
            this.AddSteps(recipe.Steps);
            Thread.Sleep(10000); // test
            submitButton.Click();
            return new MainPage();
        }

        private void AddSteps(List<RecipeStep>? steps)
        {
            if (steps != null)
            {
                new WebItem("//textarea[@name=\"RECIPE_INSTRUCTION[]\"]", "Шаг 1 Описание").SendKeys(steps[0].Description ?? "");
                //new WebItem("//input[@name=\"RECIPE_INSTRUCTION_IMAGES[]\"]", "Шаг 1 Изображение").SendKeys(steps[0].Image ?? "");
                for (int i = 1; i < steps.Count; i++)
                {
                    addStepButton.Click();
                    //TODO добавление изображений
                    new WebItem($"//div[@class=\"field update-instruction-delete-{i+1}\"]//child::textarea", $"Шаг {i+1} Описание").SendKeys(steps[i].Description ?? "");
                }
            }
        }

        private void AddIngredients(List<Ingredient>? ingredients)
        {
            if (ingredients != null)
            {
                /*new WebItem("//textarea[@name=\"RECIPE_INSTRUCTION[]\"]", "Шаг 1 Описание").SendKeys(ingredients[0].Name ?? "");
                //new WebItem("//input[@name=\"RECIPE_INSTRUCTION_IMAGES[]\"]", "Шаг 1 Изображение").SendKeys(steps[0].Image ?? "");
                for (int i = 1; i < steps.Count; i++)
                {
                    addStepButton.Click();
                    //TODO добавление изображений
                    new WebItem($"//div[@class=\"field update-instruction-delete-{i + 1}\"]//child::textarea", $"Шаг {i + 1} Описание").SendKeys(steps[i].Description ?? "");
                }*/
            }
        }

        private void AddCategories(List<Category>? categories)
        {
            throw new NotImplementedException();
        }

        private void AddImages(List<string>? images)
        {
            throw new NotImplementedException();
        }
    }
}
