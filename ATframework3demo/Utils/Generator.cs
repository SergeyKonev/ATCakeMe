using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;

namespace ATframework3demo.Utils;

public static class Generator
{
    private static Random random = new Random();

    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    /// <summary>
    /// Создает рецепт на основе переданных параметров
    /// </summary>
    /// <returns>Объект рецепта</returns>
    public static Recipe RandomRecipe(
        int descrMinLen = 10, int descrMaxLen = 50, bool haveDescr = true,
        int imagesMinCount = 1, int imagesMaxCount = 5, bool haveImages = true,
        int portionsMinCount = 1, int portionsMaxCount = 10, bool havePortionNum = true,
        int cookTimeMin = 1, int cookTimeMax = 100, bool haveCookTime = true,
        int caloriesMin = 1, int caloriesMax = 3000, bool haveCalories = true,
        int ingredientsMin = 1, int ingredientsMax = 5, bool haveIngredients = true,
        int categoriesMin = 1, int categoriesMax = 6, bool haveCategories = true,
        int stepsMin = 1, int stepsMax = 10, int stepSizeMin = 1, int stepSizeMax = 100, bool haveSteps = true
        )
    {
        return new Recipe(
            name : DateTime.Now.Ticks.ToString(),
            description: haveDescr ? RandomString(RandomInt(descrMinLen, descrMaxLen)) : null,
            portionNum: havePortionNum ? RandomInt(portionsMinCount, portionsMaxCount) : null,
            cookTime: haveCookTime ? RandomInt(cookTimeMin, cookTimeMax) : null,
            calories: haveCalories ? RandomInt(caloriesMin,caloriesMax) : null,
            ingredients: haveIngredients ? GenerateIngredients(RandomInt(ingredientsMin, ingredientsMax)) : null,
            categories: haveCategories ? GenerateCategories(RandomInt(categoriesMin, categoriesMax)) : null,
            steps: haveSteps ? GenerateRecipeSteps(RandomInt(stepsMin, stepsMax), RandomInt(stepSizeMin, stepSizeMax)) : null,
            images: haveImages ? new List<string> { new Image("1.png").Path } : null
            );
    }

    /// <summary>
    /// Создает некоторое количество объектов ингредиента
    /// </summary>
    /// <param name="count">Количество ингредиентов</param>
    /// <returns>Список ингредиентов</returns>
    public static List<Ingredient> GenerateIngredients(int count)
    {
        var ingredients = new List<Ingredient>();
        var names = new List<string>() { "соль", "помидоры", "вода", "картофель", "сахар" };
        names.Shuffle();
        for (int i = 0; i < count; i++)
            ingredients.Add(new Ingredient(i, RandomInt(1, 50), RandomUnit(), names[i]));
        return ingredients;
    }

    /// <summary>
    /// Создает некоторое количество шагов с описанием и картинками
    /// </summary>
    /// <param name="count">Количество шагов</param>
    /// <param name="size">Минимальный размер описания</param>
    /// <returns>Список шагов</returns>
    public static List<RecipeStep> GenerateRecipeSteps(int count, int size)
    {
        var steps = new List<RecipeStep>();
        for (int i = 0; i < count; i++)
            steps.Add(new RecipeStep(i, description: RandomString(size), image: new Image("1.png").Path));
        return steps;
    }

    /// <summary>
    /// Создает некоторое количество категорий, которые будут добавлены к рецепту
    /// </summary>
    /// <param name="count">Количество категорий</param>
    /// <returns>Список категорий</returns>
    public static List<Category> GenerateCategories(int count)
    {
        var categories = new List<Category>();
        var values = Enum.GetValues(typeof(Category)).OfType<Category>().ToList(); ;
        values.Shuffle();
        for (int i = 0; i < count; i++)
            categories.Add((Category)values[i]);
        return categories;
    }

    /// <summary>
    /// Создает объект пользователя на основе переданных параметров
    /// </summary>
    /// <returns>Объект пользователя</returns>
    public static User RandomUser(
        int loginMinLen = 3, int loginMaxLen = 10, bool haveLogin = true,
        int passMinLen = 6, int passMaxLen = 15, bool havePass = true,
        int emailMinLen = 5, int emailMaxLen = 10, bool haveEmail = true,
        int firstMinLen = 5, int firstMaxLen = 10, bool haveFirst = true,
        int secondMinLen = 5, int secondMaxLen = 10, bool haveSecond = true,
        bool haveGender = true,
        int notesMinLen = 15, int notesMaxLen = 20, bool haveNotes = true,
        int cityMinLen = 10, int cityMaxLen = 15, bool haveCity = true
        )
    {
        return new User(
            login: haveLogin ? Generator.RandomString(Generator.RandomInt(loginMinLen, loginMaxLen)) : null,
            password: havePass ? Generator.RandomString(Generator.RandomInt(passMinLen, passMaxLen)) : null,
            email: haveEmail ? Generator.RandomString(Generator.RandomInt(emailMinLen, emailMaxLen)) + "@mail.ru" : null,
            firstName: haveFirst ? Generator.RandomString(Generator.RandomInt(firstMinLen, firstMaxLen)) : null,
            secondName: haveSecond ? Generator.RandomString(Generator.RandomInt(secondMinLen, secondMaxLen)) : null,
            gender: haveGender ? Generator.RandomGender() : null,
            additionalInfo: haveNotes ? Generator.RandomString(Generator.RandomInt(notesMinLen, notesMaxLen)) : null,
            city: haveCity ? Generator.RandomString(Generator.RandomInt(cityMinLen, cityMaxLen)) : null
        );
    }
    
    /// <summary>
    /// Генерирует случайный пол
    /// </summary>
    /// <returns></returns>
    public static Gender RandomGender()
    {
        Type t = typeof(Gender);
        Array values = Enum.GetValues(t);
        int index = random.Next(values.Length);
        var value = (Gender)values.GetValue(index);
        return value;
    }
    
    /// <summary>
    /// Генерирует случайную категорию
    /// </summary>
    /// <returns></returns>
    public static Category RandomCategory()
    {
        Type t = typeof(Category);
        Array values = Enum.GetValues(t);
        int index = random.Next(values.Length);
        var value = (Category)values.GetValue(index);
        return value;
    }
    
    /// <summary>
    /// Генерирует случайную единицу измерения
    /// </summary>
    /// <returns></returns>
    public static Unit RandomUnit()
    {
        Type t = typeof(Unit);
        Array values = Enum.GetValues(t);
        int index = random.Next(values.Length);
        var value = (Unit)values.GetValue(index);
        return value;
    }
    
    /// <summary>
    /// Генерирует случайное число
    /// </summary>
    /// <param name="from">минимальное значение</param>
    /// <param name="to">максимальное значение</param>
    /// <returns></returns>
    public static int RandomInt(int from = 0, int to = 1000) => random.Next(from, to);

    /// <summary>
    /// Перемешивает список
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    public static void Shuffle<T>(this IList<T> list)
    {
        Random rng = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
