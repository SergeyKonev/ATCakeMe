namespace atFrameWork2.TestEntities;

public class Ingredient
{
    public Ingredient(int id, int? amount = null, Unit? unit = null, string? name = null)
    {
        Id = id;
        Amount = amount;
        Unit = unit;
        Name = name;
    }

    public int Id { get; set; }
    public int? Amount { get; set; }
    public Unit? Unit { get; set; }
    public string? Name { get; set; }
}