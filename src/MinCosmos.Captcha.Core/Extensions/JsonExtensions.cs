using Newtonsoft.Json;

namespace MinCosmos.Captcha.Core.Extensions;

public static class JsonExtensions
{
    public static T? ToObject<T>(this string? json)
    {
        if (string.IsNullOrWhiteSpace(json)) return default(T);

        try
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public static string ToJson(this object? value)
    {
        if (value is null) return string.Empty;

        try
        {
            return JsonConvert.SerializeObject(value);
        }
        catch (Exception e)
        {
            throw;
        }
    }
}