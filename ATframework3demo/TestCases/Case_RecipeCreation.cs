using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using OpenQA.Selenium;

namespace ATframework3demo.TestCases
{
    public class Case_RecipeCreation : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Добавление рецепта(не завершено)", (mainPage, info) => SendToAllByDefault(mainPage, info)));
            return caseCollection;
        }


        void SendToAllByDefault(MainPage mainPage, PortalInfo info)
        {
            mainPage = Header.EnterLoginPage().LogIn(info);

            var recipeSteps = new List<RecipeStep> { new RecipeStep(1, description: "Шаг 1 описание"),
                new RecipeStep(2, description: "Step 2"),
                new RecipeStep(3, description: "    Шаг  "),
                new RecipeStep(4)
            };

            var recipeIngredients = new List<Ingredient> { new Ingredient(1, name: "Соль"), new Ingredient(1, name: "Вода") };
            //TODO: категории и изображения


            Recipe recipe = new Recipe(
                name: DateTime.Now.Ticks.ToString(),
                description: DateTime.Now.ToString(),
                images: null,
                portionNum: DateTime.Now.Hour,
                cookTime: DateTime.Now.Minute,
                calories: DateTime.Now.Minute * 10,
                ingredients: null,
                categories: null,
                steps: recipeSteps);
            Header.EnterRecipeCreationPage().CreateRecipe(recipe);

            //Проверка появления рецепта
        }
    }
}