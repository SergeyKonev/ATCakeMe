using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;

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
            city: haveCity ? Generator.RandomString(Generator.RandomInt(cityMaxLen, cityMinLen)) : null
        );
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
