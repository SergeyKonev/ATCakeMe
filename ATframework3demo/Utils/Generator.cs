using atFrameWork2.TestEntities;

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

    
    public static Gender RandomGender()
    {
        Type t = typeof(Gender);
        Array values = Enum.GetValues(t);
        int index = random.Next(values.Length);
        var value = (Gender)values.GetValue(index);
        return value;
    }
    
    public static Category RandomCategory()
    {
        Type t = typeof(Category);
        Array values = Enum.GetValues(t);
        int index = random.Next(values.Length);
        var value = (Category)values.GetValue(index);
        return value;
    }
    
    public static Unit RandomUnit()
    {
        Type t = typeof(Unit);
        Array values = Enum.GetValues(t);
        int index = random.Next(values.Length);
        var value = (Unit)values.GetValue(index);
        return value;
    }
    
    public static int RandomInt(int from = 0, int to = 1000) => random.Next(from, to);
}
