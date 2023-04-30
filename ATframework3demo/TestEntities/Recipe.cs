namespace atFrameWork2.TestEntities;

public class Recipe
{
    public Recipe(string? name = null, string? description = null, List<string>? images = null, int? portionNum = null, int? cookTime = null, int? calories = null, List<Ingredient>? ingredients = null, List<Category>? categories = null, List<RecipeStep>? steps = null)
    {
        Name = name;
        Description = description;
        Images = images;
        PortionNum = portionNum;
        CookTime = cookTime;
        Calories = calories;
        Ingredients = ingredients;
        Categories = categories;
        Steps = steps;
    }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<string>? Images { get; set; }
    public int? PortionNum { get; set; }
    public int? CookTime { get; set; }
    public int? Calories { get; set; }
    public List<Ingredient>? Ingredients { get; set; }
    public List<Category>? Categories { get; set; }
    public List<RecipeStep>? Steps { get; set; }
}