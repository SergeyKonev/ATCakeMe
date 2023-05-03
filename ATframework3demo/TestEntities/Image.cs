namespace atFrameWork2.TestEntities;

public class Image
{
    public string Name;
    public string Path;

    public Image(string name)
    {
        Name = name;
        string workingDirectory = Environment.CurrentDirectory;
        Path = Directory.GetParent(workingDirectory).Parent.Parent.FullName + $"\\src\\{name}";
    }
}