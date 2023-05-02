using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using OpenQA.Selenium;
using ATframework3demo.Utils;

namespace ATframework3demo.TestCases
{
    public class Case_RecipeCreation : CaseCollectionBuilder
    {
        
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Добавление рецепта с фиксированным количеством данных", (mainPage, info) => RecipeCreation(mainPage, info)));
            return caseCollection;
        }


        void RecipeCreation(MainPage mainPage, PortalInfo info)
        {
            mainPage = Header.EnterLoginPage().LogIn(info.PortalAdmin);

            var recipeSteps = new List<RecipeStep> 
            { 
                new RecipeStep(1, description: Generator.RandomString(Generator.RandomInt(1, 10))),
                new RecipeStep(2, description: Generator.RandomString(Generator.RandomInt(1, 10))),
                new RecipeStep(3, description: Generator.RandomString(Generator.RandomInt(1, 10))),
                new RecipeStep(4, description: Generator.RandomString(Generator.RandomInt(1, 10))),
            };
        
            var recipeIngredients = new List<Ingredient> 
            {
                new Ingredient(1, name: "Соль", unit: Generator.RandomUnit(), amount: Generator.RandomInt()), 
                new Ingredient(1, name: "Вода",  unit: Generator.RandomUnit(), amount: Generator.RandomInt()) 
            };

            var recipeCategories = new List<Category>
            {
                Generator.RandomCategory(),
                Generator.RandomCategory()
            };

            var mainImages = new List<string> {  };

            Recipe recipe = new Recipe(
                name: DateTime.Now.Ticks.ToString(),
                description: DateTime.Now.ToString(),
                images: mainImages,
                portionNum: Generator.RandomInt(1, 9),
                cookTime: Generator.RandomInt(1, 100),
                calories: Generator.RandomInt(1, 1000),
                ingredients: recipeIngredients,
                categories: recipeCategories,
                steps: recipeSteps);
            Header.EnterRecipeCreationPage().CreateRecipe(recipe);
            if (!Header.IsRecipeInFeed(recipe.Name))
                Log.Error("Рецепт не появился в ленте");
        }
    }
}