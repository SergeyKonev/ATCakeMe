using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.Utils;

namespace ATframework3demo.PageObjects
{
    public class RecipeCreationPage
    {
        /// <summary>
        /// Класс страницы создания рецепта
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
        WebItem addCategoryButton = new WebItem("//a[@class=\"tag-button button is-primary is-light\"]", "Кнопка добавления категории");
        WebItem addImageButton = new WebItem("//a[@class=\"image-button button is-primary is-light\"]", "Кнопка добавления изображений");

        /// <summary>
        /// Заполнение полей рецепта информацией из объекта
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        public MainPage CreateRecipe(Recipe recipe)            
        {
            nameField.ClearAndSendKeys(recipe.Name);
            descriptionField.ClearAndSendKeys(recipe.Description ?? "");
            portionNumField.ClearAndSendKeys(recipe.PortionNum.ToString() ?? "");
            cookingTimeField.ClearAndSendKeys(recipe.CookTime.ToString() ?? "");
            caloriesField.ClearAndSendKeys(recipe.Calories.ToString() ?? "");

            this.AddImages(recipe.Images);
            this.AddCategories(recipe.Categories);
            this.AddIngredients(recipe.Ingredients);
            this.AddSteps(recipe.Steps);
            Thread.Sleep(5000); // test
            submitButton.Click();
            return new MainPage();
        }

        private void AddSteps(List<RecipeStep>? steps)
        {
            if (steps != null)
            {
                for (int i = 0; i < steps.Count; i++)
                {
                    if (i>0) addStepButton.Click();
                    if (steps[i].Image != null)
                        new WebItem($"//div[@class=\"field update-instruction-delete-{i+1}\"]//child::input", $"Шаг {i+1} Изображение").ClearAndSendKeys(steps[i].Image);
                    new WebItem($"//div[@class=\"field update-instruction-delete-{i+1}\"]//child::textarea", $"Шаг {i+1} Описание").ClearAndSendKeys(steps[i].Description ?? "");
                }
            }
        }

        private void AddIngredients(List<Ingredient>? ingredients)
        {
            if (ingredients != null)
            {
                for (int i = 0; i < ingredients.Count; i++)
                {
                    if (i > 0) addIngredientButton.Click();
                    new WebItem($"//tr[@class=\"update-ingredient-delete-{i + 1}\"]//child::input[@name=\"RECIPE_INGREDIENT[NAME][]\"]", $"Ингредиент {i + 1} Название").ClearAndSendKeys(ingredients[i].Name ?? "");
                    new WebItem($"//tr[@class=\"update-ingredient-delete-{i + 1}\"]//child::input[@name=\"RECIPE_INGREDIENT[VALUE][]\"]", $"Ингредиент {i + 1} Количество").ClearAndSendKeys(ingredients[i].Amount.ToString() ?? "");
                    new WebItem($"//tr[@class=\"update-ingredient-delete-{i + 1}\"]//child::select[@name=\"RECIPE_INGREDIENT[TYPE][]\"]", "Единица измерения").SelectListItemByText(ingredients[i].Unit?.DisplayName() ?? "");
                }
            }
        }

        private void AddCategories(List<Category>? categories)
        {
            if (categories != null)
            {
                for (int i = 0; i < categories.Count; i++)
                {
                    if (i > 0) addCategoryButton.Click();
                    new WebItem($"//div[@class=\"select add-recipe-tags-select update-tag-delete-{i+1}\"]//child::select", $"Категория {i + 1}").SelectListItemByText(categories[i].DisplayName());
                }
            }
        }

        private void AddImages(List<string>? images)
        {
            if (images != null)
            {
                for (int i = 0; i < images.Count; i++)
                {
                    if (i>0) addImageButton.Click();
                    new WebItem($"//div[@class=\"field update-image-delete-{i+1}\"]//child::input[@type=\"file\"]", $"Изображение {i + 1}").ClearAndSendKeys(images[i]);
                }
            }    
        }
    }
}
