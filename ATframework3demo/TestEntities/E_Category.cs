using System.ComponentModel;
using ATframework3demo.Utils;

namespace atFrameWork2.TestEntities;

public enum Category
{
    [Description("Выпечка")]
    Baking,
    [Description("Супы")]
    Soups,
    [Description("Салаты")]
    Salads,
    [Description("Горячее блюдо")]
    HotDish,
    [Description("Холодное блюдо")]
    ColdDish,
    [Description("Диетическое")]
    Dietary,
    [Description("Сытное")]
    Satisfying,
    [Description("Сладкое")]
    Sweet,
    [Description("Веганское")]
    Vegan,
    [Description("Мясное")]
    Meat,
    [Description("Напитки")]
    Drinks,
    [Description("Закуска")]
    Snack,
    [Description("Соусы")]
    Sauces
}