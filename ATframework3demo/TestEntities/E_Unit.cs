using System.ComponentModel;
using ATframework3demo.Utils;

namespace atFrameWork2.TestEntities;

public enum Unit
{
    [Description("грамм")]
    Gram,
    [Description("зубчика")]
    Сlove,
    [Description("кг")]
    Kg,
    [Description("куска")]
    Slice,
    [Description("л")]
    L,
    [Description("мл")]
    Ml,
    [Description("по вкусу")]
    ToTaste,
    [Description("ст. ложки")]
    Tablespoon,
    [Description("стакан")]
    Glass,
    [Description("ч. ложки")]
    Teaspoon,
    [Description("штук")]
    Piece
}