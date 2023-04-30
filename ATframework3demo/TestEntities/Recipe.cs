namespace atFrameWork2.TestEntities;

public class Recipe
{
    public string Name { get; set; }
    public List<string> Images { get; set; }
    public int PortionNum { get; set; }
    public int CookTime { get; set; }
    public int Calories { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public List<Category> Categories { get; set; }
    public List<RecipeStep> Steps { get; set; }
}