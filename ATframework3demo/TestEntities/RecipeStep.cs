namespace atFrameWork2.TestEntities;

public class RecipeStep
{
    public RecipeStep(int id, string? image = null, string? description = null)
    {
        Id = id;
        Image = image;
        Description = description;
    }

    public int Id { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
}