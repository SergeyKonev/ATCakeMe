using ATframework3demo.Utils;

namespace atFrameWork2.TestEntities;

public enum Category
{
    [StringValue("Выпечка")]
    Baking,
    [StringValue("Супы")]
    Soups,
    [StringValue("Салаты")]
    Salads,
    [StringValue("Горячее блюдо")]
    HotDish,
    [StringValue("Холодное блюдо")]
    ColdDish,
    [StringValue("Диетическое")]
    Dietary,
    [StringValue("Сытное")]
    Satisfying,
    [StringValue("Сладкое")]
    Sweet,
    [StringValue("Веганское")]
    Vegan,
    [StringValue("Мясное")]
    Meat,
    [StringValue("Напитки")]
    Drinks,
    [StringValue("Закуска")]
    Snack,
    [StringValue("Соусы")]
    Sauces
}