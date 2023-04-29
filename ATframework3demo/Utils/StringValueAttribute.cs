namespace ATframework3demo.Utils;

public class StringValueAttribute : System.Attribute
{

    private string _value;

    public StringValueAttribute(string value)
    {
        _value = value;
    }

    public string Value
    {
        get { return _value; }
    }

}