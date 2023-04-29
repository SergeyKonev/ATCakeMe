using ATframework3demo.Utils;

namespace atFrameWork2.TestEntities;

public enum Unit
{
    [StringValue("грамм")]
    Gram,
    [StringValue("зубчика")]
    Сlove,
    [StringValue("кг")]
    Kg,
    [StringValue("куска")]
    Slice,
    [StringValue("л")]
    L,
    [StringValue("мл")]
    Ml,
    [StringValue("по вкусу")]
    ToTaste,
    [StringValue("ст. ложки")]
    Tablespoon,
    [StringValue("стакан")]
    Glass,
    [StringValue("ч. ложки")]
    Teaspoon,
    [StringValue("штук")]
    Piece
}