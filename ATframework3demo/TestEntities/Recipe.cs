namespace atFrameWork2.TestEntities;
using atFrameWork2.BaseFramework.LogTools;

public class Recipe
{
    public Recipe(string name, string? description = null, List<string>? images = null, int? portionNum = null, int? cookTime = null, int? calories = null, List<Ingredient>? ingredients = null, List<Category>? categories = null, List<RecipeStep>? steps = null)
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
        string log = "";
        log += "Тестовая информация рецепта:\n" +
            $"Название: {name}\n" +
            $"Описание: {description}\n" +
            $"Количество порций: {portionNum}\n" +
            $"Время готовки: {cookTime}\n" +
            $"Калории: {calories}\n";

        if (ingredients != null)
        {
            log += "Ингредиенты:\n";
            foreach (Ingredient i in ingredients)
            {
                log += (i.Name ?? "") + (i.Amount.ToString() ?? "") + (i.Unit.ToString() ?? "") + "\n";
            }
        }
        if (categories != null)
        {
            log += "Категории:\n";
            foreach (Category c in categories)
            {
                log += (c.ToString() ?? "Без названия") + "\n";
            }
        }
        if (steps != null)
        {
            log += "Шаги:\n";
            foreach (RecipeStep s in steps)
            {
                log += (s.Description ?? "Нет описания") + "\n";
            }
        }
        Log.Info(log);
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

    /// <summary>
    /// Сравнение с другим объектом рецепта по основным полям
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(Recipe? other)
    {
        return (
            Name == other.Name &&
            Description == other.Description &&
            PortionNum == other.PortionNum &&
            CookTime == other.CookTime &&
            Calories == other.Calories
            //TODO images, steps, ingredients, categories
            );
    }
}