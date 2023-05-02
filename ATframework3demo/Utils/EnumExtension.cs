using System.Collections.Concurrent;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.TestEntities;

namespace ATframework3demo.Utils;

public static class EnumExtensions
{
    // Note that we never need to expire these cache items, so we just use ConcurrentDictionary rather than MemoryCache
    private static readonly ConcurrentDictionary<string, string> DisplayNameCache = new ConcurrentDictionary<string, string>();

    public static string DisplayName(this Enum value)
    {
        var key = $"{value.GetType().FullName}.{value}";

        var displayName = DisplayNameCache.GetOrAdd(key, x =>
        {
            var name = (DescriptionAttribute[])value
                .GetType()
                .GetTypeInfo()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return name.Length > 0 ? name[0].Description : value.ToString();
        });

        return displayName;
    }

    public static T GetByName<T>(string name)
    {
        foreach (var field in typeof(T).GetFields())
        {
            if (field.IsLiteral && field.GetCustomAttribute(typeof(DescriptionAttribute)).Equals(new DescriptionAttribute(name)))
                //              return field.?;
                return (T)field.GetValue(null);
        }

        Log.Error($"Не найдена такая опция {name} в нумераторе {typeof(T)}");
        throw new ArgumentException("Not found.", nameof(name));
    }
}