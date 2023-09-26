namespace MinCosmos.Captcha.Core;

public static class TypeConverterExtensions
{
    public static int ToInt(this string value)
    {
        Int32.TryParse(value, out var result);

        return result;
    }

    public static TimeSpan ToTimeSpan(this string value)
    {
        if (value.EndsWith("s", StringComparison.CurrentCultureIgnoreCase))
        {
            return TimeSpan.FromSeconds(value.TrimEnd('s', 'S').ToInt());
        }

        if (value.EndsWith("m", StringComparison.CurrentCultureIgnoreCase))
        {
            return TimeSpan.FromSeconds(value.TrimEnd('m', 'M').ToInt());
        }

        if (value.EndsWith("h", StringComparison.CurrentCultureIgnoreCase))
        {
            return TimeSpan.FromSeconds(value.TrimEnd('h', 'H').ToInt());
        }

        throw new FormatException("不支持的时间格式, 仅支持时分秒(h,m,s)作为时间单位");
    }
}
